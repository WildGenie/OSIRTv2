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
using OSIRT.Extensions;
using CefSharp;
using Tor;
using System.IO;
using System.Threading;

namespace OSIRT.Browser
{


    public partial class TabbedBrowserControl : UserControl
    {
        private ToolStripComboBox addressBar;
        private ToolStripMenuItem menuItem;
        private ExtendedBrowser CurrentBrowser => CurrentTab?.Browser;
        public event EventHandler ScreenshotComplete;
        private RouterCollection allRouters;

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

        public void SetMenuItem(ToolStripMenuItem menuItem)
        {
            this.menuItem = menuItem;
        }


        public TabbedBrowserControl()
        {
            InitializeComponent();
            //due to browser control not releasing memory, and there not being a fix at the moment, prevent multi-tab.
            uiBrowserTabControl.NewTabClicked += control_NewTabClicked;
            uiBrowserTabControl.SelectedIndexChange += uiBrowserTabControl_SelectedIndexChange;
            uiBrowserTabControl.Closed += UiBrowserTabControl_Closed;
            uiDownloadProgressBar.Visible = false;

        }



        private void UiBrowserTabControl_Closed(object sender, EventArgs e)
        {
            //CurrentTab?.Browser?.Dispose();
        }

        private void uiBrowserTabControl_SelectedIndexChange(object sender, EventArgs e)
        {
            //TODO: had a play in ChromeTabControl.
            //Not had time to fully inspect ramifications of this event.
            //It's not quite 100%, so needs work.
            //Problems arise when drag-moving tab.
            addressBar.Text = CurrentTab?.Browser.Address;

            //UpdateForwardAndBackButtons?.Invoke(this, EventArgs.Empty);

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

        public void CreateTab(string url)
        {
            BrowserTab tab = new BrowserTab(addressBar);
            uiBrowserTabControl.TabPages.Add(tab);
            AddBrowserEvents();
            Navigate(url);
        }

        private void CreateTab()
        {
            CreateTab(UserSettings.Load().Homepage);
        }

        private void AddBrowserEvents()
        {
            CurrentBrowser.ScreenshotCompleted += Screenshot_Completed;
            CurrentBrowser.DownloadingProgress += currentBrowser_DownloadingProgress;
            CurrentBrowser.DownloadComplete += CurrentBrowser_DownloadComplete;
            CurrentBrowser.YouTubeDownloadProgress += CurrentBrowser_YouTubeDownloadProgress;
            CurrentBrowser.YouTubeDownloadComplete += CurrentBrowser_YouTubeDownloadComplete;
        }

        private void CurrentBrowser_DownloadComplete(object sender, EventArgs e)
        {
            AsyncCompletedEventArgs evt = (AsyncCompletedEventArgs)e;
            string filename = evt.UserState.ToString();
            this.InvokeIfRequired(() => uiDownloadProgressBar.Visible = false);
            ShowImagePreviewer(Actions.Saved, filename);
        }

        private void currentBrowser_DownloadingProgress(object sender, EventArgs e)
        {
            Invoke((MethodInvoker)delegate
            {
                if (!uiDownloadProgressBar.Visible)
                    uiDownloadProgressBar.Visible = true;

                int progress = ((DownloadProgressChangedEventArgs)e).ProgressPercentage;
                uiDownloadProgressBar.Value = progress;
            });

        }

        private void CurrentBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            //CurrentTab.CurrentUrl = CurrentBrowser.Url.AbsoluteUri;
            addressBar.Text = CurrentTab.CurrentUrl;

            if (e.Url.Equals(((WebBrowser)sender).Url))
            {
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
            Invoke((MethodInvoker)delegate
            {
                ScreenshotDetails details = new ScreenshotDetails(CurrentBrowser.URL);
                DialogResult dialogRes;
                string fileName;
                string dateAndtime;

                using (Previewer previewForm = new ImagePreviewer(action, CurrentBrowser.URL, imagePath))
                {
                    dialogRes = previewForm.ShowDialog();
                    fileName = previewForm.FileName + previewForm.FileExtension;
                    dateAndtime = previewForm.DateAndTime;
                }
                ImageDiskCache.RemoveItemsInCache();
                if (dialogRes != DialogResult.OK)
                    return;

                DisplaySavedLabel(fileName, dateAndtime);
            });

        }

        private void DisplaySavedLabel(string fileName, string dateTime)
        {
            uiActionLoggedToolStripStatusLabel.Text = $"{fileName} logged at {dateTime}";

            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer { Interval = 5000 };
            timer.Start();
            timer.Tick += (s, e) => { uiActionLoggedToolStripStatusLabel.Text = ""; timer.Stop(); };
        }

        void Browser_StatusTextChanged(object sender, EventArgs e)
        {
            //uiStatusLabel.Text = CurrentBrowser.StatusText;
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
            Debug.WriteLine("url in navigate: " + url);
            CurrentTab.Browser.Load(url);
        }

        private void CurrentBrowser_YouTubeDownloadComplete(object sender, EventArgs e)
        {
            Invoke((MethodInvoker)delegate
            {
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

            Invoke((MethodInvoker)delegate
            {
                if (!uiDownloadProgressBar.Visible)
                    uiDownloadProgressBar.Visible = true;

                uiDownloadProgressBar.Value = (int)progress.ProgressPercentage;
            });
        }

        private void uiBrowserTabControl_Click(object sender, EventArgs e)
        {

        }

        private void TabbedBrowserControl_Load(object sender, EventArgs e)
        {
            if (DesignMode)
            {
                uiBrowserTabControl.NewTabButton = false;
            }
            else
            {
                uiBrowserTabControl.NewTabButton = UserSettings.Load().AllowMultipleTabs;

                //user agent spoofer: it works.
                CefSettings cfsettings = new CefSettings();
                cfsettings.UserAgent = "Opera/12.02 (Android 4.1; Linux; Opera Mobi/ADR-1111101157; U; en-US) Presto/2.9.201 Version/12.02";
                Cef.Initialize(cfsettings);

                /*
                CefSettings settings = new CefSettings();
                settings.CefCommandLineArgs.Add("proxy-server", "127.0.0.1:8182");
                Cef.Initialize(settings);

                Process[] previous = Process.GetProcessesByName("tor");
                if (previous != null && previous.Length > 0)
                {
                    foreach (Process process in previous)
                        process.Kill();
                }

                ClientCreateParams createParameters = new ClientCreateParams();
                createParameters.ConfigurationFile = "";
                createParameters.ControlPassword = "";
                createParameters.ControlPort = 9051;
                createParameters.DefaultConfigurationFile = "";
                createParameters.Path = @"Tor\Tor\tor.exe";
                */
                //createParameters.SetConfig(ConfigurationNames.AvoidDiskWrites, true);
                //createParameters.SetConfig(ConfigurationNames.GeoIPFile, Path.Combine(Environment.CurrentDirectory, @"Tor\Data\Tor\geoip"));
                //createParameters.SetConfig(ConfigurationNames.GeoIPv6File, Path.Combine(Environment.CurrentDirectory, @"Tor\Data\Tor\geoip6"));

                /*
                Client client = Client.Create(createParameters);

                if (!client.IsRunning)
                {
                    //SetStatusProgress(PROGRESS_DISABLED);
                    //SetStatusText("The tor client could not be created");
                    return;
                }
                */

                //client.Status.BandwidthChanged += OnClientBandwidthChanged;
                //client.Status.CircuitsChanged += OnClientCircuitsChanged;
                //client.Status.ORConnectionsChanged += OnClientConnectionsChanged;
                //client.Status.StreamsChanged += OnClientStreamsChanged;
                //client.Configuration.PropertyChanged += (s, e) => { Invoke((Action)delegate { configGrid.Refresh(); }); };
                //client.Shutdown += new EventHandler(OnClientShutdown);

                //SetStatusProgress(PROGRESS_DISABLED);
                //SetStatusText("Ready");

                //configGrid.SelectedObject = client.Configuration;

                //SetStatusText("Downloading routers");
                //SetStatusProgress(PROGRESS_INDETERMINATE);

                //    ThreadPool.QueueUserWorkItem(state =>
                //    {
                //        allRouters = client.Status.GetAllRouters();

                //        if (allRouters == null)
                //        {
                //            //SetStatusText("Could not download routers");
                //            //SetStatusProgress(PROGRESS_DISABLED);
                //        }
                //        else
                //        {
                //            Invoke((Action)delegate
                //            {
                //                //routerList.BeginUpdate();

                //                //foreach (Router router in allRouters)
                //                //    routerList.Items.Add(string.Format("{0} [{1}] ({2}/s)", router.Nickname, router.IPAddress, router.Bandwidth));

                //                //routerList.EndUpdate();
                //            });

                //            //SetStatusText("Ready");
                //            //SetStatusProgress(PROGRESS_DISABLED);
                //            //ShowTorReady();
                //        }
                //    });
                //}

                CreateTab();

            }
        }




    }
}
