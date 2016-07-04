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

namespace OSIRT.UI
{

    public partial class BrowserPanel : UserControl
    {

        public event EventHandler CaseClosing;
        public event EventHandler ResizeMainForm;

        public BrowserPanel()
        {
            InitializeComponent();
            uiTabbedBrowserControl.SetAddressBar(uiURLComboBox);
        }

        private void BrowserPanel_Load(object sender, EventArgs e)
        {
            ConfigureUi();
            uiTabbedBrowserControl.ScreenshotComplete += UiTabbedBrowserControl_ScreenshotComplete;
            uiTabbedBrowserControl.CurrentTab.Browser.ViewPageSource += Browser_ViewPageSource;
            uiTabbedBrowserControl.CurrentTab.Browser.SavePageSource += Browser_SavePageSource;
            uiTabbedBrowserControl.CurrentTab.Browser.NavigationComplete += Browser_NavigationComplete;
            OsirtVideoCapture.VideoCaptureComplete += osirtVideoCapture_VideoCaptureComplete;
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
            string path = Path.Combine(Constants.ContainerLocation,  Constants.Directories.GetSpecifiedCaseDirectory(Enums.Actions.Source), filename);
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

        private void Browser_ViewPageSource(object sender, EventArgs e)
        {
            var args = ((ViewSourceEventArgs)e);
            string source = args.Source;
            string title = args.Title;
            new ViewPageSource(source, title).Show();
        }

        private void UiTabbedBrowserControl_ScreenshotComplete(object sender, EventArgs e)
        {
            uiScreenshotButton.Enabled = true;
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
                uiTabbedBrowserControl.Navigate(uiURLComboBox.Text);
                e.SuppressKeyPress = true; //stops "ding" sound when enter is pushed
            }
        }

    

        private void uiScreenshotButton_Click(object sender, EventArgs e)
        {
            uiScreenshotButton.Enabled = false;
            uiTabbedBrowserControl.FullPageScreenshot();
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
            using(AttachmentForm attachment = new AttachmentForm())
            {
                attachment.ShowDialog();
            }
        }

        private void uiLBackButton_Click(object sender, EventArgs e)
        {
            if(uiTabbedBrowserControl.CurrentTab.Browser.CanGoBack)
                uiTabbedBrowserControl.CurrentTab.Browser.GoBack();
        }

        private void uiForwardButton_Click(object sender, EventArgs e)
        {
            if (uiTabbedBrowserControl.CurrentTab.Browser.CanGoForward)
                uiTabbedBrowserControl.CurrentTab.Browser.GoForward();
        }

        private void uiRefreshButton_Click(object sender, EventArgs e)
        {
            uiTabbedBrowserControl.CurrentTab.Browser.Refresh();
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
            uiTabbedBrowserControl.CurrentTab.Browser.MouseTrailVisible = UserSettings.Load().ShowMouseTrail;

            ResizeMainForm?.Invoke(this, null);


            //TODO: this check is causing the user to have to click twice to stop/start recording??
            IntPtr handle;
            if (markerWindow != null && markerWindow.Visible)
                handle = markerWindow.Handle;
            else
                handle = Handle;


            if (!OsirtVideoCapture.IsRecording())
                OsirtVideoCapture.StartCapture(Width, Height, uiVideoCaptureButton, (uint)handle);
            else
                OsirtVideoCapture.StopCapture();
        }

        private void osirtVideoCapture_VideoCaptureComplete(object sender, EventArgs e)
        {
            if (markerWindow != null && markerWindow.Visible)
            {
                markerWindow.Close();
                markerWindow.Dispose();
            }

            uiTabbedBrowserControl.CurrentTab.Browser.MouseTrailVisible = false;
            VideoCaptureCompleteEventArgs ev = (VideoCaptureCompleteEventArgs)e;

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
            uiTabbedBrowserControl.CurrentTab.Browser.Navigate("http://google.co.uk");
        }

        private void whoIsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //get url from bar
            Uri url = new Uri(uiTabbedBrowserControl.CurrentTab.Browser.URL);
            try
            {
                string host = url.Host;
                if(!(host.EndsWith(".com") ||  host.EndsWith(".net")) )
                {
                    if (host.StartsWith("www."))
                        host = host.Remove(0, 4);
                }
                var whois = new WhoisLookup().Lookup(host);
                var view = new ViewPageSource(whois.ToString(), url.Host);
                view.Show();
            }
            catch
            {
                MessageBox.Show("Unable to obtain Whois? information for this website.", "Error obtaining Whois?", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void whatsTheIPToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void uiURLComboBox_MouseEnter(object sender, EventArgs e)
        {
        
        }
    }
}
