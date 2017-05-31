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

namespace OSIRT.UI
{

    public partial class BrowserPanel : UserControl
    {

        public event EventHandler CaseClosing;
        public static bool IsUsingTor; //we're being naughter here, as we need to know we're in tor mode and this is the easiest way for now.
        private string userAgent;
        private Form parentForm;

        public BrowserPanel(bool isUsingTor, string userAgent, Form parent)
        {
            
            IsUsingTor = isUsingTor;
            this.userAgent = userAgent;
            parentForm = parent;
            CheckAdvancedOptions();
            InitializeComponent();
            uiTabbedBrowserControl.SetAddressBar(uiURLComboBox);
            PopulateFavourites();

            if (isUsingTor)
            {
                uiURLComboBox.BackColor = Color.MediumPurple;
                uiURLComboBox.ForeColor = Color.White;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.F))
            {
                ShowFindForm();
                return true;
            }
            if(keyData == (Keys.Control | Keys.D))
            {
                Browser_AddBookmark(this, EventArgs.Empty);
                return true;
            }


            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void PopulateFavourites()
        {
            string[] lines = File.ReadAllLines(Constants.Favourites);
            OsirtHelper.Favourites = lines.Select(l => l.Split('=')).ToDictionary(a => a[0], a => a[1]);

            foreach(var item in OsirtHelper.Favourites)
            {
                ToolStripMenuItem menuItem = new ToolStripMenuItem();
                menuItem.Text = item.Key; //this will be the page title
                menuItem.Tag = item.Value; //this will be the URL
                menuItem.Click += MenuItem_Click;
                uiBookMarksToolStripMenuItem.DropDownItems.Add(menuItem);
            }

        }

        private void Browser_AddBookmark(object sender, EventArgs e)
        {
       
            ToolStripMenuItem menuItem = new ToolStripMenuItem();
            this.InvokeIfRequired(() => OsirtHelper.Favourites[uiTabbedBrowserControl.CurrentTab.Browser.Title] = uiTabbedBrowserControl.CurrentTab.Browser.URL);
            this.InvokeIfRequired(() => menuItem.Text = uiTabbedBrowserControl.CurrentTab.Browser.Title);
            this.InvokeIfRequired(() => menuItem.Tag = uiTabbedBrowserControl.CurrentTab.Browser.URL);
            this.InvokeIfRequired(() => uiBookMarksToolStripMenuItem.DropDownItems.Add(menuItem));
            menuItem.Click += MenuItem_Click;
        }

        private void MenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
            this.InvokeIfRequired(() => uiTabbedBrowserControl.CreateTab(clickedItem.Tag.ToString()));
            //open new tab with url from Tag.
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
            uiTabbedBrowserControl.CurrentTab.Browser.AddBookmark += Browser_AddBookmark;
        }



        private void UiTabbedBrowserControl_UpdateNavigation(object sender, EventArgs e)
        {
            this.InvokeIfRequired(() =>  uiForwardButton.Enabled =  ((NavigationalEventArgs)e).CanGoForward);
            this.InvokeIfRequired(() => uiLBackButton.Enabled = ((NavigationalEventArgs)e).CanGoBack);
        }

        private void Browser_StatusMessage(object sender, StatusMessageEventArgs e)
        {
            this.InvokeIfRequired(() =>  uiTabbedBrowserControl.SetStatusLabel(e.Value));
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
            uiBrowserToolStrip.Enabled = true;
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
                
                if(searched.StartsWith("?"))
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
            catch(ImageMagick.MagickDelegateErrorException mdee)
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
            Uri url = new Uri(uiTabbedBrowserControl.CurrentTab.Browser.URL);
            try
            {
                string host = url.Host;
                if (!(host.EndsWith(".com") || host.EndsWith(".net")))
                {
                    if (host.StartsWith("www."))
                        host = host.Remove(0, 4);
                }
                var whois = new WhoisLookup().Lookup(host);
                File.WriteAllText(Constants.TempTextFile, whois.ToString());
                this.InvokeIfRequired(() => new TextPreviewer(Enums.Actions.Whois, uiTabbedBrowserControl.CurrentTab.Browser.URL).Show());
            }
            catch
            {
                MessageBox.Show("Unable to obtain Whois? information for this website.", "Error obtaining Whois?", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void whatsTheIPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Uri url = new Uri(uiTabbedBrowserControl.CurrentTab.Browser.URL);
            IPAddress[] addresses = Dns.GetHostAddresses(url.Host);

            string message = "";
            foreach (var address in addresses)
            {
                message += address.ToString() + "\r\n";
            }

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
            }

            //DPI settings >100% break screenshots. This prevents cefsharp from auto scaling the browser, meaning screenshots don't break.
            settings.CefCommandLineArgs.Add("force-device-scale-factor", "1");

            if (!string.IsNullOrEmpty(userAgent))
            {
                settings.UserAgent = userAgent;
            }
            if (!IsUsingTor)
            {
                if(!string.IsNullOrWhiteSpace(cefProxy))
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

            //Client client = Client.Create(createParameters); //causing a FormatException
            //client.Status.BandwidthChanged += Status_BandwidthChanged;
            //client.Shutdown += Client_Shutdown;
            Cef.Initialize(settings);

        }

        private void LoadTor(object sender, WaitWindowEventArgs e)
        {
            System.Threading.Thread.Sleep(5000); //give a chance for the tor process to load

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
            uiTabbedBrowserControl.CurrentTab.Browser.Reload(true);
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
            string search = ((ExifViewerEventArgs)e).ImageUrl;
            uiTabbedBrowserControl.CurrentTab.Browser.Find(0, search, false, false, false);
        }

        private void FindForm_FindNext(object sender, EventArgs e)
        {
            string search = ((ExifViewerEventArgs)e).ImageUrl;
            uiTabbedBrowserControl.CurrentTab.Browser.Find(0, search, true, false, false);
        }

        private void FindForm_FindComplete(object sender, EventArgs e)
        {
            string search = ((ExifViewerEventArgs)e).ImageUrl;
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

        private int DPI()
        {
            int currentDPI = 0;

            using (Graphics g = this.CreateGraphics())
            {
                currentDPI = (int)g.DpiX;
            }
            return currentDPI;
        }

        private void userAgentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //var task = uiTabbedBrowserControl.CurrentTab.Browser.GetZoomLevelAsync();

            //task.ContinueWith(previous =>
            //{
            //    if (previous.Status == System.Threading.Tasks.TaskStatus.RanToCompletion)
            //    {
            //        double zoom = 0.0;
            //        Debug.WriteLine("SCALE: " + DPI());
            //        switch(DPI())
            //        {
            //            case 96: //no scale
            //                break;
            //            case 120:
            //                zoom = -1.15;
            //                break;
            //            case 144:
            //                zoom = -1.6;
            //                break;
            //            case 192:
            //                zoom = -2.1;
            //                break;
            //        }

            //        var currentLevel = previous.Result;
            //        Debug.WriteLine("Current level: " + currentLevel);
            //        uiTabbedBrowserControl.CurrentTab.Browser.SetZoomLevel(zoom);
            //    }
            //    else
            //    {
            //        throw new InvalidOperationException("Unexpected failure of calling CEF->GetZoomLevelAsync", previous.Exception);
            //    }
            //}, System.Threading.Tasks.TaskContinuationOptions.ExecuteSynchronously);


        }

        //TODO: popping this here, we have duplicate logic in the main browser
        private int GetDocHeight()
        {
            try
            {
                int scrollHeight = 0;
                var task = uiTabbedBrowserControl.CurrentTab.Browser.GetBrowser()?.MainFrame?.EvaluateScriptAsync("(function() { var body = document.body, html = document.documentElement; return  Math.max( body.scrollHeight, body.offsetHeight, html.clientHeight, html.scrollHeight, html.offsetHeight ); })();", null);
                task.Wait();
                var response = task.Result;
                scrollHeight = (int)response.Result;
                return scrollHeight;
            }
            catch
            {
                MessageBox.Show("Unable to take full page capture. Consider using video capture, snippet or current view capture tools.", "Unable to take full page screenshot", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return 0;
            }
        }

        private bool stop = true;
        private CancellationTokenSource cts;
        private async void autoscrollstartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uiStopAutoScrollingToolStripButton.Visible = true;
            string scroll =
            @"
                docHeight = document.body.scrollHeight;
	            window.scrollTo(0, docHeight);
           
	            if (prevDocHeight == docHeight){
                    clearInterval(pidScrollToEnd);
                }

                prevDocHeight = docHeight;
            ";

            string js = "var pidScrollToEnd; (function() { prevDocHeight = 0; window.scrollTo(0, document.body.scrollHeight); pidScrollToEnd = setInterval(function(){" + scroll + "}, 750); })();";

            await uiTabbedBrowserControl.CurrentTab.Browser.GetBrowser().MainFrame.EvaluateScriptAsync(js);

            //int previousDocHeight = GetDocHeight();
            //int currentDocHeight = 0;

            ////TODO: make the stop button visible in tool bar
            //uiStopAutoScrollingToolStripButton.Visible = true;
            //if (cts == null)
            //{
            //    stop = true;
            //    cts = new CancellationTokenSource();
            //}

            //int n = 0;
            //while (n++ < 500 && stop)
            //{

            //    //if (currentDocHeight == previousDocHeight)
            //    //{
            //    //    cts.Cancel();
            //    //    uiStopAutoScrollingToolStripButton.Visible = false;
            //    //}

            //    await uiTabbedBrowserControl.CurrentTab.Browser.GetBrowser().MainFrame.EvaluateScriptAsync("(function() { window.scroll(0, window.pageYOffset +" + (n * 2500) + "); })();");
            //    await Task.Delay(175);
            //    try
            //    {
            //        if (cts.IsCancellationRequested)
            //        {
            //            stop = false;
            //            cts = null;
            //        }
            //    }
            //    catch { /*general catch as cts can throw a nullreference*/ }


            //    currentDocHeight = GetDocHeight();
            //    Console.WriteLine("PREVIOUS: " + previousDocHeight + " CURRENT| " + currentDocHeight);
            //}      
        }


        private async void toolStripButton1_Click(object sender, EventArgs e)
        {
            uiStopAutoScrollingToolStripButton.Visible = false;
            //TODO: stop button needs to be visible for all tabs, still.
            await uiTabbedBrowserControl.CurrentTab.Browser.GetBrowser().MainFrame.EvaluateScriptAsync("clearInterval(pidScrollToEnd);");
        }
    }
}
