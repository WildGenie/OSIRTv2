using System;
using System.Windows.Forms;
using OSIRT.Enums;
using OSIRT.UI;
using OSIRT.Helpers;
using System.Drawing;
using System.Diagnostics;
using System.Collections.Generic;
using System.Net;
using System.ComponentModel;
using OSIRT.Loggers;

namespace OSIRT.Browser
{


    public partial class TabbedBrowserControl : UserControl
    {

        private ToolStripComboBox addressBar;
        private ExtendedBrowser CurrentBrowser => CurrentTab?.Browser;
        public event EventHandler ScreenshotComplete;

        public BrowserTab CurrentTab
        {
            get
            {
                int selectedIndex = (int)uiBrowserTabControl?.TabPages?.SelectedIndex;
                return uiBrowserTabControl?.TabPages?[selectedIndex] as BrowserTab;
            }
        }


        public void SetAddressBar(ToolStripComboBox addressBar)
        {
            this.addressBar = addressBar;
        }


        public TabbedBrowserControl()
        {
            InitializeComponent();
            uiBrowserTabControl.NewTabClicked += control_NewTabClicked;
            uiBrowserTabControl.SelectedIndexChange += uiBrowserTabControl_SelectedIndexChange;
            uiBrowserTabControl.Closed += UiBrowserTabControl_Closed;

            uiDownloadProgressBar.Visible = false;
            CreateTab();
        }

        private void UiBrowserTabControl_Closed(object sender, EventArgs e)
        {
            //Debug.WriteLine("DISPOSE CALLED");
            CurrentTab?.Browser?.Dispose();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void uiBrowserTabControl_SelectedIndexChange(object sender, EventArgs e)
        {
            //TODO: had a play in ChromeTabControl.
            //Not had time to fully inspect ramifications of this event.
            //It's not quite 100%, so needs work.
            //Problems arise when drag-moving tab
            addressBar.Text = CurrentTab?.CurrentUrl;
        }

        private void uiBrowserPanel_TabIndexChanged(object sender, EventArgs e)
        {
            if (CurrentTab.Browser != null)
                addressBar.Text = CurrentTab.CurrentUrl;
        }

        void control_NewTabClicked(object sender, EventArgs e)
        {
            CreateTab();
        }

        
        private void CreateTab(string url = "http://google.co.uk")
        {
            BrowserTab tab = new BrowserTab();
            uiBrowserTabControl.TabPages.Add(tab);
            AddBrowserEvents();

            Navigate(url);

        }

        private void AddBrowserEvents()
        {
            CurrentBrowser.StatusTextChanged += Browser_StatusTextChanged;
            CurrentBrowser.Navigated += CurrentBrowser_Navigated;
            CurrentBrowser.ScreenshotCompleted += Screenshot_Completed;
            CurrentBrowser.DownloadingProgress += currentBrowser_DownloadingProgress;
            CurrentBrowser.DownloadComplete += CurrentBrowser_DownloadComplete;
            CurrentBrowser.NewTab += CurrentBrowser_NewTab;
            CurrentBrowser.YouTubeDownloadProgress += CurrentBrowser_YouTubeDownloadProgress;
            CurrentBrowser.YouTubeDownloadComplete += CurrentBrowser_YouTubeDownloadComplete;
        }


        private void CurrentBrowser_NewTab(object sender, EventArgs e)
        {
            CreateTab(((NewTabEventArgs)e).Url);
        }

        private void CurrentBrowser_DownloadComplete(object sender, EventArgs e)
        {
            AsyncCompletedEventArgs evt = (AsyncCompletedEventArgs)e;
            string filename = evt.UserState.ToString();
            uiDownloadProgressBar.Visible = false;
            ShowImagePreviewer(Actions.Saved, filename);
        }

        private void currentBrowser_DownloadingProgress(object sender, EventArgs e)
        {
            if(!uiDownloadProgressBar.Visible)
                uiDownloadProgressBar.Visible = true;

            int progress =  ((DownloadProgressChangedEventArgs)e).ProgressPercentage;
            uiDownloadProgressBar.Value = progress;
        }

        private void CurrentBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            CurrentTab.CurrentUrl = CurrentBrowser.Url.AbsoluteUri;
            addressBar.Text = CurrentTab.CurrentUrl;

            if (e.Url.Equals(((WebBrowser)sender).Url))
            {
                Console.WriteLine("LOGGED: " + ((WebBrowser)sender).Url);
                Logger.Log(new WebsiteLog(CurrentTab.CurrentUrl));
            }
        }

        private void Screenshot_Completed(object sender, EventArgs e)
        {
            ScreenshotComplete?.Invoke(this, new EventArgs());
            ShowImagePreviewer(Actions.Screenshot, Constants.TempImgFile);
        }

        private void ShowImagePreviewer(Actions action, string imagePath)
        {
            ScreenshotDetails details = new ScreenshotDetails(CurrentBrowser.URL);
            DialogResult dialogRes;
            string fileName;
            string dateAndtime;

            using(Previewer previewForm = new ImagePreviewer(action, CurrentBrowser.URL, imagePath))
            {
                dialogRes = previewForm.ShowDialog();
                fileName = previewForm.FileName + previewForm.FileExtension;
                dateAndtime = previewForm.DateAndTime;
            }

            ImageDiskCache.RemoveItemsInCache();
            if (dialogRes != DialogResult.OK)
                return;

            DisplaySavedLabel(fileName, dateAndtime);
        }

        private void DisplaySavedLabel(string fileName, string dateTime)
        {
            uiActionLoggedToolStripStatusLabel.Text = $"{fileName} logged at {dateTime}";

            Timer timer = new Timer { Interval = 5000 };
            timer.Start();
            timer.Tick += (s, e) => { uiActionLoggedToolStripStatusLabel.Text = ""; timer.Stop(); };
        }

        void Browser_StatusTextChanged(object sender, EventArgs e)
        {
            uiStatusLabel.Text = CurrentBrowser.StatusText;
        }

        public void FullPageScreenshot()
        {
            CurrentBrowser.GenerateFullpageScreenshot(); 
        }

        public void CurrentViewScreenshot()
        {
            CurrentBrowser.GetCurrentViewportScreenshot();
        }

        public void TimedScreenshot(int seconds)
        {
            var future = DateTime.Now.AddSeconds(seconds);
            do
            {
                uiActionLoggedToolStripStatusLabel.Text = string.Format("Screenshotting in: {0}", (future - DateTime.Now).ToString("ss"));
                Application.DoEvents();
            } while (future > DateTime.Now);
            uiActionLoggedToolStripStatusLabel.Text = "";
            CurrentBrowser.GetCurrentViewportScreenshot();
        }


        public void Navigate(string url)
        {
             CurrentTab?.Browser?.Navigate(url);
        }

        private void CurrentBrowser_YouTubeDownloadComplete(object sender, EventArgs e)
        {
            Invoke((MethodInvoker)delegate {
                uiDownloadProgressBar.Visible = false;
                DialogResult dialogRes;
                string fileName;
                string dateAndtime;

                using (VideoPreviewer vidPreviewer = new VideoPreviewer(Enums.Actions.Video))
                {
                    dialogRes = vidPreviewer.ShowDialog();
                    fileName = vidPreviewer.FileName + vidPreviewer.FileExtension; ;
                    dateAndtime = vidPreviewer.DateAndTime;
                }

                if (dialogRes != DialogResult.OK)
                    return;

                DisplaySavedLabel(fileName, dateAndtime);
                ImageDiskCache.RemoveSpecificItemFromCache(Constants.TempVideoFile);

            });
        }
       
        private void CurrentBrowser_YouTubeDownloadProgress(object sender, EventArgs e)
        {
            var progress = (YoutubeExtractor.ProgressEventArgs)e;

            Invoke((MethodInvoker)delegate {
                if (!uiDownloadProgressBar.Visible)
                    uiDownloadProgressBar.Visible = true;

                uiDownloadProgressBar.Value = (int)progress.ProgressPercentage;
            });
        }

        private void uiBrowserTabControl_Click(object sender, EventArgs e)
        {

        }
    }
}
