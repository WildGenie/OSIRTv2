using System;
using System.Drawing;
using System.Windows.Forms;
using OSIRT.UI.Attachment;
using OSIRT.UI.AuditLog;
using OSIRT.UI.CaseNotes;
using OSIRT.VideoCapture;
using OSIRT.UI.Options;
using OSIRT.UI.SnippetTool;
using OSIRT.Helpers;
using OSIRT.UI.ViewSource;
using System.IO;
using System.Text;
using OSIRT.Loggers;
using Whois;
using System.Net;
using System.Diagnostics;
using OSIRT.Extensions;
using OSIRT.Browser;
using CefSharp;
using Tor;
using OSIRT.Browser.SearchFinder;
using System.Collections.Generic;
using System.Linq;
using Jacksonsoft;
using OSIRT.UI.CaseClosing;
using System.Threading.Tasks;
using System.Threading;
using Whois.NET;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Net.Http;
using Ionic.Zip;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using OSIRT.UI.VideoParser;

namespace OSIRT.UI
{

    public partial class BrowserPanel : UserControl
    {

        public event EventHandler CaseClosing;
        private string userAgent;
        private Form parentForm;
        public static bool isDownloadingPage = false;

        public BrowserPanel(string userAgent, Form parent)
        {
            this.userAgent = userAgent;
            parentForm = parent;
            CheckAdvancedOptions();
            InitializeComponent();
            uiTabbedBrowserControl.SetAddressBar(uiURLComboBox);
            uiTabbedBrowserControl.BookmarkAdded += UiTabbedBrowserControl_BookmarkAdded;
            PopulateFavourites();

            if (RuntimeSettings.IsUsingTor)
            {
                uiURLComboBox.BackColor = Color.MediumPurple;
                uiURLComboBox.ForeColor = Color.White;
                whatsTheIPToolStripMenuItem.Enabled = false;
            }
            if (RuntimeSettings.EnableWebDownloadMode)
            {
                uiURLComboBox.BackColor = Color.CadetBlue;
                uiURLComboBox.ForeColor = Color.White;
                uiDownloadWebpageToolStripButton.Visible = true;
            }
        }

       

        private void UiTabbedBrowserControl_BookmarkAdded(object sender, EventArgs e)
        {
            this.InvokeIfRequired(() => PopulateFavourites());
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.F))
            {
                ShowFindForm();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public void PopulateFavourites()
        {
            string[] lines = File.ReadAllLines(Constants.Favourites);
            OsirtHelper.Favourites = lines.Select(l => l.Split('=')).ToDictionary(a => a[0], a => a[1]);
            var manager = uiBookmarksToolStripDropDownButton.DropDownItems[0];
            uiBookmarksToolStripDropDownButton.DropDownItems.Clear();
            uiBookmarksToolStripDropDownButton.DropDownItems.Add(manager);
            uiBookmarksToolStripDropDownButton.DropDownItems.Add(new ToolStripSeparator());
            foreach (var item in OsirtHelper.Favourites)
            {
                ToolStripMenuItem menuItem = new ToolStripMenuItem()
                {
                    Text = item.Key, //page title
                    Tag = item.Value //URL
                };
                menuItem.Click += MenuItem_Click;
                uiBookmarksToolStripDropDownButton.DropDownItems.Add(menuItem);
            }
        }


        private void MenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
            this.InvokeIfRequired(() => uiTabbedBrowserControl.CreateTab(clickedItem.Tag.ToString()));
        }

        private void BrowserPanel_Load(object sender, EventArgs e)
        {
            ConfigureUi();
            uiTabbedBrowserControl.ScreenshotComplete += UiTabbedBrowserControl_ScreenshotComplete;
            uiTabbedBrowserControl.CurrentTab.Browser.SavePageSource += Browser_SavePageSource;
            uiTabbedBrowserControl.CurrentTab.AddressChanged += CurrentTab_AddressChanged;
            OsirtVideoCapture.VideoCaptureComplete += osirtVideoCapture_VideoCaptureComplete;
            uiTabbedBrowserControl.CurrentTab.Browser.StatusMessage += Browser_StatusMessage;
            uiTabbedBrowserControl.UpdateNavigation += UiTabbedBrowserControl_UpdateNavigation;


            var bm = new BookmarksToolbar(uiBookmarkHelperToolStrip);
            bm.ItemClicked += Bm_ItemClicked;

        }

        private void Bm_ItemClicked(object sender, EventArgs e)
        {
            this.InvokeIfRequired(() => uiTabbedBrowserControl.CreateTab(((TextEventArgs)e).Result));
        }


        private void UiTabbedBrowserControl_UpdateNavigation(object sender, EventArgs e)
        {
            this.InvokeIfRequired(() => uiForwardButton.Enabled = ((NavigationalEventArgs)e).CanGoForward);
            this.InvokeIfRequired(() => uiLBackButton.Enabled = ((NavigationalEventArgs)e).CanGoBack);
        }

        private void Browser_StatusMessage(object sender, StatusMessageEventArgs e)
        {
            this.InvokeIfRequired(() => uiTabbedBrowserControl.SetStatusLabel(e.Value));
        }

        private void UiTabbedBrowserControl_UpdateForwardAndBackButtons(object sender, EventArgs e)
        {
            this.InvokeIfRequired(() => uiLBackButton.Enabled = uiTabbedBrowserControl.CurrentTab.Browser.CanGoBack);
            this.InvokeIfRequired(() => uiForwardButton.Enabled = uiTabbedBrowserControl.CurrentTab.Browser.CanGoForward);
        }


        private void CurrentTab_AddressChanged(object sender, EventArgs e)
        {

        }

        private void CurrentTab_OpenNewTab(object sender, EventArgs e)
        { 

            string url = ((OnPopUpEventArgs)e).TargetUrl;
            this.InvokeIfRequired(() => uiTabbedBrowserControl.CurrentTab.Browser.Load(url));
        }


        private void Browser_NavigationComplete(object sender, EventArgs e)
        {
            Uri url = new Uri(uiTabbedBrowserControl.CurrentTab.Browser.URL);
            IPAddress[] addresses = Dns.GetHostAddresses(url.Host);

            foreach (var address in addresses)
            {
                whatsTheIPToolStripMenuItem.Text = address.ToString();
            }
        }

        private void Browser_SavePageSource(object sender, EventArgs e)
        {
            var args = ((SaveSourceEventArgs)e);
            string filename = Constants.PageSourceFileName.Replace("%%dt%%", DateTime.Now.ToString("yyyy-MM-dd_hh_mm_ss")).Replace("%%name%%", args.Domain);
            string path = Path.Combine(Constants.ContainerLocation, Constants.Directories.GetSpecifiedCaseDirectory(Enums.Actions.Source), filename);
            using (FileStream fileStream = new FileStream(path, FileMode.Create))
            {
                using (StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.UTF8))
                {
                    streamWriter.WriteLine(args.Source);
                }
            }

            Logger.Log(new WebpageActionsLog(uiTabbedBrowserControl.CurrentTab.Browser.URL, Enums.Actions.Source, OsirtHelper.GetFileHash(path), filename, "[Page source downloaded]"));
            MessageBox.Show("Page source saved successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void UiTabbedBrowserControl_ScreenshotComplete(object sender, EventArgs e)
        {
            //uiTabbedBrowserControl.CurrentTab.Browser.Enabled = false;
            if (RuntimeSettings.EnableWebDownloadMode && isDownloadingPage)
            {
                string savedDirectory = (string)WaitWindow.Show(SavePage, "Saving page... Please Wait");  
                isDownloadingPage = false;
                Process.Start(savedDirectory);
            }
            uiBrowserToolStrip.Enabled = true;
            uiBookmarkHelperToolStrip.Enabled = true;
        }


        private void ConfigureUi()
        {
            Dock = DockStyle.Fill;
            uiBrowserToolStrip.ImageScalingSize = new Size(32, 32);
            uiURLComboBox.KeyDown += UiURLComboBox_KeyDown;

        }

        private void UiURLComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                string searched = uiURLComboBox.Text;

                if (searched.StartsWith("?"))
                {
                    searched = searched.Remove(0, 1).Replace(" ", "+");
                    searched = "https://www.google.co.uk/search?q=" + searched;
                }

                uiTabbedBrowserControl.Navigate(searched);
                e.SuppressKeyPress = true; //stops "ding" sound when enter is pushed
            }
        }

        private void uiScreenshotButton_Click(object sender, EventArgs e)
        {
            try
            {
                ImageDiskCache.RemoveItemsInCache(); //may be old items in cache, don't want them getting appended to screenshot
                //ImageDiskCache.RemoveSpecificItemFromCache(Constants.TempVideoFile);
                uiBrowserToolStrip.Enabled = false;
                uiTabbedBrowserControl.FullPageScreenshot();
            }
            catch (ImageMagick.MagickDelegateErrorException mdee)
            {
                MessageBox.Show("There has been an error combining the screenshot (MagickDelegateErrorException). Try taking the screenshot again.", "Error combining screenshot", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ImageDiskCache.RemoveItemsInCache();
                ImageDiskCache.RemoveSpecificItemFromCache("temp.mp4");
                UiTabbedBrowserControl_ScreenshotComplete(sender, e);
            }
            finally
            {
                //uiBrowserToolStrip.Enabled = true;
            }
        }


        private void uiCaseNotesButton_Click(object sender, EventArgs e)
        {
            CaseNotesForm caseNotes = new CaseNotesForm();
            caseNotes.FormClosed += CaseNotes_FormClosed;
            caseNotes.Show();
            uiCaseNotesButton.Enabled = false;
        }

        private void CaseNotes_FormClosed(object sender, FormClosedEventArgs e)
        {
            uiCaseNotesButton.Enabled = true;
        }

        private void uiAttachmentToolStripButton_Click(object sender, EventArgs e)
        {
            using (AttachmentForm attachment = new AttachmentForm())
            {
                attachment.ShowDialog();
            }
        }

        private void uiLBackButton_Click(object sender, EventArgs e)
        {
            if (uiTabbedBrowserControl.CurrentTab.Browser.CanGoBack)
                uiTabbedBrowserControl.CurrentTab.Browser.GetBrowser().GoBack();
        }

        private void uiForwardButton_Click(object sender, EventArgs e)
        {
            if (uiTabbedBrowserControl.CurrentTab.Browser.CanGoForward)
                uiTabbedBrowserControl.CurrentTab.Browser.GetBrowser().GoForward();
        }

        private void uiRefreshButton_Click(object sender, EventArgs e)
        {
            uiTabbedBrowserControl.CurrentTab.Browser.Reload();
        }

        private void closeCaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CaseClosing?.Invoke(this, e);
        }

        private MarkerWindow markerWindow;
        private void markerWindowToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (markerWindow == null || markerWindow.IsDisposed)
            {
                markerWindow = new MarkerWindow();
            }
            try
            {
                markerWindow.Show();
            }
            catch { markerWindow = new MarkerWindow(); markerWindow.Show(); }
            markerWindow.TopMost = true;
        }

        private void uiVideoCaptureButton_Click(object sender, EventArgs e)
        {

            //uiTabbedBrowserControl.CurrentTab.Browser.InitialiseMouseTrail();
            //uiTabbedBrowserControl.CurrentTab.Browser.StartMouseTrailTimer();
            IntPtr handle = parentForm.Handle;
            if (markerWindow != null && markerWindow.Visible) handle = markerWindow.Handle;

            if (!OsirtVideoCapture.IsRecording())
            {
                OsirtVideoCapture.StartCapture(Width, Height, uiVideoCaptureButton, (uint)handle);
            }
            else
            {
                OsirtVideoCapture.StopCapture();
                //uiTabbedBrowserControl.CurrentTab.Browser.DisableMouseTrail();
            }
        }

        private void osirtVideoCapture_VideoCaptureComplete(object sender, EventArgs e)
        {
            if (markerWindow != null && markerWindow.Visible)
            {
                markerWindow.Close();
                markerWindow.Dispose();
            }

            using (VideoPreviewer vidPreviewer = new VideoPreviewer(Enums.Actions.Video))
            {
                vidPreviewer.ShowDialog();
            }

            ImageDiskCache.RemoveSpecificItemFromCache(Constants.TempVideoFile);
        }

        private void uiAuditLogToolStripButton_Click(object sender, EventArgs e)
        {
            using (AuditLogForm audit = new AuditLogForm())
            {
                audit.ShowDialog();
            }
        }

        private void uiOptionsToolStripButton_Click(object sender, EventArgs e)
        {
            using (OptionsForm options = new OptionsForm())
            {
                options.ShowDialog();
            }
        }

        private void snippetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!SnippingTool.Snip())
                    return;
            }
            catch
            {
                MessageBox.Show("Unable to use snipping tool. Try closing some tabs. If this continues, restart OSIRT.", "Unable to use snippet tool", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (Previewer imagePreviewer = new ImagePreviewer(Enums.Actions.Snippet, uiTabbedBrowserControl.CurrentTab.Browser.URL))
            {
                imagePreviewer.ShowDialog();
            }
            ImageDiskCache.RemoveItemsInCache();

        }

        private void currentViewScreenshotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uiTabbedBrowserControl.CurrentViewScreenshot();
        }

        private void currentViewTimedScreenshotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SelectTimeForm timeForm = new SelectTimeForm())
            {
                if (timeForm.ShowDialog() != DialogResult.OK)
                    return;

                uiTabbedBrowserControl.TimedScreenshot(timeForm.Time);
            }
        }

        private void uiHomeButton_Click(object sender, EventArgs e)
        {
            uiTabbedBrowserControl.CurrentTab.Browser.Load(UserSettings.Load().Homepage);
        }

        private void whoIsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string host = new Uri(uiTabbedBrowserControl.CurrentTab.Browser.URL).Host;
            this.InvokeIfRequired(() => uiTabbedBrowserControl.CreateTab($"https://centralops.net/co/DomainDossier.aspx?dom_whois=1&net_whois=1&dom_dns=1&addr={host}"));
        }

        private void whatsTheIPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = OsirtHelper.GetIpFromUrl(uiTabbedBrowserControl.CurrentTab.Browser.URL);
            File.WriteAllText(Constants.TempTextFile, message);
            this.InvokeIfRequired(() => new TextPreviewer(Enums.Actions.Ipaddress, uiTabbedBrowserControl.CurrentTab.Browser.URL).Show());
        }

        private void uiURLComboBox_MouseEnter(object sender, EventArgs e)
        {

        }


        private void CheckAdvancedOptions()
        {
            CefSettings settings = new CefSettings();

            string cefProxy = "";
            string torProxy = "127.0.0.1:8182";
            int controlPort = 9051;

            if (File.Exists(Constants.ProxySettingsFile))
            {
                string[] lines = File.ReadAllLines(Constants.ProxySettingsFile);

                var dict = lines.Select(l => l.Split('=')).ToDictionary(a => a[0], a => a[1]);
                cefProxy = dict["cefProxy"];
                torProxy = dict["torProxy"];
                controlPort = int.Parse(dict["torPort"]);
                if (dict.ContainsKey("disablewebrtc"))
                {
                    bool webRtc = false;
                    if(bool.TryParse("disablewebrtc", out webRtc))
                    {
                        OsirtHelper.DisableWebRtc = Convert.ToBoolean(dict["disablewebrtc"].Trim());
                    }
                }

            }
            //DPI settings >100% break screenshots. This prevents cefsharp from auto scaling the browser, meaning screenshots don't break.
            settings.CefCommandLineArgs.Add("force-device-scale-factor", "1");
            //settings.CefCommandLineArgs.Add("--enable-system-flash", "1");

            if (RuntimeSettings.EnableWebDownloadMode)
            {
                settings.CefCommandLineArgs.Add("disable-application-cache", "1");
            }


            if (!string.IsNullOrEmpty(userAgent))
            {
                settings.UserAgent = userAgent;
            }
            if (!RuntimeSettings.IsUsingTor)
            {
                if (!string.IsNullOrWhiteSpace(cefProxy))
                {
                    settings.CefCommandLineArgs.Add("proxy-server", cefProxy);
                }

                Cef.Initialize(settings);
                return;
            }

            //tor settings
            settings.CefCommandLineArgs.Add("proxy-server", "socks5://127.0.0.1:9050");



            Process[] previous = Process.GetProcessesByName("tor");
            if (previous != null && previous.Length > 0)
            {
                foreach (Process p in previous)
                    p.Kill();
            }

            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = @"Tor\Tor\tor.exe",
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden
                }
            };

            process.Start();
            WaitWindow.Show(LoadTor, "Loading Tor... Please Wait. This will take a few seconds.");
            Cef.Initialize(settings);

        }

        private void LoadTor(object sender, WaitWindowEventArgs e)
        {
            Thread.Sleep(5000); //give a chance for the tor process to load

            ClientRemoteParams remoteParams = new ClientRemoteParams();
            remoteParams.Address = "127.0.0.1";
            remoteParams.ControlPassword = "";
            remoteParams.ControlPort = 9050;

            Client client = Client.CreateForRemote(remoteParams);
            client.Status.BandwidthChanged += Status_BandwidthChanged;

        }

        private void Client_Shutdown(object sender, EventArgs e)
        {
            //MessageBox.Show("Tor client has shutdown without warning. It is highly recommended you restart OSIRT.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //return;
        }

        private void Status_BandwidthChanged(object sender, BandwidthEventArgs e)
        {
            Console.WriteLine(".... in BC ....");
            Invoke((Action)delegate
            {
                if (e.Downloaded.Value == 0 && e.Uploaded.Value == 0)
                    uiTabbedBrowserControl.SetLoggedLabel("");
                else
                    uiTabbedBrowserControl.SetLoggedLabel(string.Format("Down: {0}/s, Up: {1}/s", e.Downloaded, e.Uploaded));
            });
        }


        private void aboutOSIRTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutOSIRT().Show();
        }

        private void forceCacheRefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //uiTabbedBrowserControl.CurrentTab.Browser.Reload(true);
        }



        private void findOnPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFindForm();
        }

        private void ShowFindForm()
        {
            var findForm = new Find();
            findForm.Show();
            findForm.FindNext += FindForm_FindNext; ;
            findForm.FindPrevious += FindForm_FindPrevious;
            findForm.FindClosing += FindForm_FindClosing;
        }


        private void FindForm_FindClosing(object sender, EventArgs e)
        {
            uiTabbedBrowserControl.CurrentTab.Browser.StopFinding(true);
        }

        private void FindForm_FindPrevious(object sender, EventArgs e)
        {
            string search = ((TextEventArgs)e).Result;
            uiTabbedBrowserControl.CurrentTab.Browser.Find(0, search, false, false, false);
        }

        private void FindForm_FindNext(object sender, EventArgs e)
        {
            string search = ((TextEventArgs)e).Result;
            uiTabbedBrowserControl.CurrentTab.Browser.Find(0, search, true, false, false);
        }

        private void FindForm_FindComplete(object sender, EventArgs e)
        {
            string search = ((TextEventArgs)e).Result;
            uiTabbedBrowserControl.CurrentTab.Browser.Find(0, search, true, false, false);
        }

        private void shutdownCurrentCaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //clicked shutdown
            //warn if they want to shutdown
            //show archiving panel
            //-- need to handle case possibly having a password
            //first load panel button events are fired elsewhere, this needs a rewrite
        }

        private void textPrevToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new TextPreviewer(Enums.Actions.Source, "example text").Show();
        }

        private /*async*/ void AutoscrollstartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uiStopAutoScrollingToolStripButton.Visible = true;
            autoscrollstartToolStripMenuItem.Enabled = false;
            string scroll =
            @"
                var body = document.body, html = document.documentElement; 
                docHeight = Math.max(body.scrollHeight, body.offsetHeight, html.clientHeight, html.scrollHeight, html.offsetHeight);
	            window.scrollTo(0, docHeight);
           
	            if (prevDocHeight == docHeight){
                    clearInterval(pidScrollToEnd);
                    return true;
                }

                prevDocHeight = docHeight;
            ";

            int scrollTime = UserSettings.Load().ScrollTimer;
            string js = "var pidScrollToEnd; (function() { prevDocHeight = 0; window.scrollTo(0, Math.max(document.body.scrollHeight, document.documentElement.scrollHeight, document.documentElement.clientHeight) ); pidScrollToEnd = setInterval(function(){" + scroll + "}," + scrollTime  + "); })();";
            //await uiTabbedBrowserControl.CurrentTab.Browser.GetBrowser().MainFrame.EvaluateScriptAsync(js);
             uiTabbedBrowserControl.CurrentTab.Browser.GetBrowser().MainFrame.ExecuteJavaScriptAsync(js);
        }


        private async void toolStripButton1_Click(object sender, EventArgs e)
        {
            uiStopAutoScrollingToolStripButton.Visible = false;
            autoscrollstartToolStripMenuItem.Enabled = true;
            //TODO: stop button needs to be visible for all tabs, still as the javascript could be executing on another.
            //perhaps, in the mean time, only allow one tab to auto-scroll

            //also, when the page hits the bottom the stop button needs to be hidden
            await uiTabbedBrowserControl.CurrentTab.Browser.GetBrowser().MainFrame.EvaluateScriptAsync("clearInterval(pidScrollToEnd);");
        }

        private void manageBookmarksToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Bm_BookmarkRemoved(object sender, EventArgs e)
        {
            PopulateFavourites();
        }

        private void Bm_LinkClicked(object sender, EventArgs e)
        {
            string url = ((TextEventArgs)e).Result;
            this.InvokeIfRequired(() => uiTabbedBrowserControl.CreateTab(url));
        }

        private void manageBookmarksToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            BookmarkManager bm = new BookmarkManager();
            bm.LinkClicked += Bm_LinkClicked;
            bm.BookmarkRemoved += Bm_BookmarkRemoved;
            bm.Show();
        }

        private void uRLListerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string urls = "";

            foreach (var t in uiTabbedBrowserControl.TabPages)
            {
                BrowserTab bt = t as BrowserTab;
                urls += bt.Browser.URL + "\r\n";
            }
            new UrlLister(urls.Trim()).Show();
        }

        private void SavePage(object sender, WaitWindowEventArgs e)
        {
            string output = "";

            List<RequestWrapper> resources = uiTabbedBrowserControl.CurrentTab.Browser.ResourcesSet().OrderBy(q => q.Identifier).ToList();
            List<HeaderWrapper> headers = uiTabbedBrowserControl.CurrentTab.Browser.ResponseHeaders().OrderBy(q => q.Identifer).ToList();
            List<HeaderWrapper> requestHeaders = uiTabbedBrowserControl.CurrentTab.Browser.RequestHeaders().OrderBy(q => q.Identifer).ToList();

            string saveFolder = new Uri(uiTabbedBrowserControl.CurrentTab.Browser.URL).Host.Replace(".", "_") + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss-fff");
            string savePath = Path.Combine(GSettings.Load().SaveDirectory, saveFolder);
            string logSavePath = Path.Combine(savePath, "_complete_log");
            Directory.CreateDirectory(savePath);
            Directory.CreateDirectory(logSavePath);

            output += "=================================================================================\r\n";
            output += "Capture started: " + DateTime.Now.ToString("yyyy-MM-dd-HH:mm:ss.fff") + "\r\n";
            output += "URL: " + uiTabbedBrowserControl.CurrentTab.Browser.URL + "\r\n";
            output += "IP(s): " + OsirtHelper.GetIpFromUrl(uiTabbedBrowserControl.CurrentTab.Browser.URL).Replace("\r\n", " ") + "\r\n";
            output += "Screenshot Hash: " + OsirtHelper.GetFileHash(Constants.TempImgFile) + "\r\n";
            output += "=================================================================================\r\n";

            ulong count = 0;
            foreach (var resource in resources)
            {
                Directory.CreateDirectory($@"{savePath}\{resource.ResourceType}");
                string filename = resource.ResourceType == ResourceType.MainFrame ? "mainframe.html" : OsirtHelper.GetSafeFilename(resource.RequestUrl, resource.MimeType);
                e.Window.Message = "Saving: " + filename + "...Please Wait";

                if (File.Exists($@"{savePath}\{resource.ResourceType}\{filename}")  )
                {
                    filename = $"{++count}_{filename}";
                }
                
                File.WriteAllBytes($@"{savePath}\{resource.ResourceType}\{filename}", resource.Data);
                output += "=================================================================================\r\n";
                output += "Request ID: " + resource.Identifier + "\r\n";
                output += "Request URL: " + resource.RequestUrl + "\r\n";
                output += "Request URL IP(s): " + OsirtHelper.GetIpFromUrl(resource.RequestUrl).Replace("\r\n", " ")  + "\r\n";
                output += "Resource Type: " + resource.ResourceType + "\r\n";
                output += "Mime Type: " + resource.MimeType + "\r\n";
                output += "File Saved Location: " + $@"{savePath}\{resource.ResourceType}\{filename}" + "\r\n";
                output += $"Hash [{UserSettings.Load().Hash.ToUpper()}]: " + OsirtHelper.GetFileHash(resource.Data) + "\r\n";
                output += "Save completed at: " + DateTime.Now.ToString("yyyy-MM-dd-HH:mm:ss.fffffff") + "\r\n";
                output += "=================================================================================\r\n";
                e.Result = savePath;
            }

            output += "=================================================================================\r\n";
            output += "Capture finished: " + DateTime.Now.ToString("yyyy-MM-dd-HH:mm:ss.fff") + "\r\n";
            output += "=================================================================================\r\n";
            File.AppendAllText($@"{logSavePath}\_capture.txt", output);
            File.Copy(Constants.TempImgFile, $@"{logSavePath}\_website.png");

            if (GSettings.Load().SaveHttpHeaders)
            {
                string headerOutput = "";
                foreach (var k in headers)
                {
                    headerOutput += "====================================================\r\n";
                    headerOutput += "Request ID: " + k.Identifer + "\r\n";
                    foreach (KeyValuePair<string, string> kv in k.Headers)
                    {
                        headerOutput += $"{kv.Key} : {kv.Value}" + "\r\n";
                    }
                    headerOutput += "====================================================\r\n";
                }
                File.AppendAllText($@"{logSavePath}\_headers.txt", headerOutput);

                //string reqheaderOutput = "";
                //foreach (var k in requestHeaders)
                //{
                //    reqheaderOutput += "====================================================\r\n";
                //    reqheaderOutput += "Request ID: " + k.Identifer + "\r\n";
                //    foreach (KeyValuePair<string, string> kv in k.Headers)
                //    {
                //        reqheaderOutput += $"{kv.Key} : {kv.Value}" + "\r\n";
                //    }
                //    reqheaderOutput += "====================================================\r\n";
                //}
                //File.AppendAllText($@"{logSavePath}\_request_headers.txt", reqheaderOutput);
            }

            CopyPageSaveToCase(savePath, e);
        }

        private void CopyPageSaveToCase(string folder, WaitWindowEventArgs e)
        {
            using (ZipFile zip = new ZipFile())
            {
                zip.AddDirectory(folder);
                zip.Save(folder + ".zip");
                e.Window.Message = "Zipping...Please Wait";
            }

            string copyTo = Path.Combine(Constants.ContainerLocation, Constants.Directories.GetSpecifiedCaseDirectory(Enums.Actions.Download), Path.GetFileNameWithoutExtension(folder) + ".zip");
            File.Copy(folder + ".zip", copyTo);
            e.Window.Message = "Logging...Please Wait";
            Logger.Log(new WebpageActionsLog(uiTabbedBrowserControl.CurrentTab.Browser.URL, Enums.Actions.Download, OsirtHelper.GetFileHash(copyTo), Path.GetFileNameWithoutExtension(folder) + ".zip", "Webpage downloaded"));
            Thread.Sleep(2000);
            File.Delete(folder + ".zip");
            ImageDiskCache.RemoveItemsInCache();
        }

        private void uiDownloadWebpageToolStripButton_Click(object sender, EventArgs e)
        {
            isDownloadingPage = true;
            uiBrowserToolStrip.Enabled = false;
            uiBookmarkHelperToolStrip.Enabled = false;
            uiTabbedBrowserControl.FullPageScreenshot();
        }

        private void refreshCacheToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uiTabbedBrowserControl.CurrentTab.Browser.Reload(true);
        }

        private void deleteAllCookiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("This will delete ALL cookies for this session. Are you sure?", "Delete ALL Cookies?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr != DialogResult.Yes) return;

            var cookieManager = Cef.GetGlobalCookieManager();
            bool deleted = cookieManager.DeleteCookies("", "");
            if (deleted) { MessageBox.Show("Cookies are deleted.", "Cookies Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private async void getTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string text = await uiTabbedBrowserControl.CurrentTab.Browser.GetTextAsync();
            File.WriteAllText(Constants.TempTextFile, text);
            this.InvokeIfRequired(() => new TextPreviewer(Enums.Actions.Text, uiTabbedBrowserControl.CurrentTab.Browser.URL).Show());
        }

        private void H_HistoryLinkClicked(object sender, EventArgs e)
        {
            string url = ((TextEventArgs)e).Result;
            this.InvokeIfRequired(() => uiTabbedBrowserControl.CreateTab(url));
        }

        private void historyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HistoryViewer.HistoryViewForm h = new HistoryViewer.HistoryViewForm();
            h.HistoryLinkClicked += H_HistoryLinkClicked;
            h.Show();
        }

        private void twitterToolStripMenuItem_Click(object sender, EventArgs e)
        {

            using (VideoParseForm vid = new VideoParseForm())
            {
                vid.VideoDownloadComplete += Dialog_VideoDownloadComplete;
                vid.ShowDialog();
            }
        }

        private void Dialog_VideoDownloadComplete(object sender, EventArgs e)
        {
            //show video previewer

            using (VideoPreviewer vidPreviewer = new VideoPreviewer(Enums.Actions.Video, Path.Combine(Constants.VideoCacheLocation, "temp_facebook_vid.mp4")))
            {
               vidPreviewer.ShowDialog();
            }

            ImageDiskCache.RemoveSpecificItemFromCache(Path.Combine(Constants.VideoCacheLocation, "temp_facebook_vid.mp4"));

        }
    }
}

