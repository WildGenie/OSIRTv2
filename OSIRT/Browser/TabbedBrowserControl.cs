using System;
using System.Windows.Forms;
using OSIRT.Enums;
using OSIRT.UI;
using OSIRT.Helpers;
using System.Drawing;
using System.Diagnostics;
using System.Collections.Generic;

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
            CreateTab();
        }

        void control_NewTabClicked(object sender, EventArgs e)
        {
            CreateTab();
        }

        
        private void CreateTab()
        {
            BrowserTab tab = new BrowserTab();
            uiBrowserTabControl.TabPages.Add(tab);
            AddBrowserEvents();
            Navigate(/*UserSettings.Load().Homepage*/ "http://google.co.uk");
        }

        private void AddBrowserEvents()
        {
            CurrentBrowser.StatusTextChanged += Browser_StatusTextChanged;
            CurrentBrowser.Navigated += CurrentBrowser_Navigated;
            CurrentBrowser.ScreenshotCompleted += Screenshot_Completed;
        }

        private void CurrentBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            CurrentTab.CurrentUrl = CurrentBrowser.Url.AbsoluteUri;
            addressBar.Text = CurrentTab.CurrentUrl;
        }

        private void Screenshot_Completed(object sender, ScreenshotCompletedEventArgs e)
        {
            ScreenshotComplete?.Invoke(this, new EventArgs());
            ScreenshotDetails details = new ScreenshotDetails(CurrentBrowser.URL);
            DialogResult dialogRes;
            string fileName;
            string dateAndtime;
            using (ImagePreviewerForm previewForm = new ImagePreviewerForm(details))
            {
                dialogRes = previewForm.ShowDialog();
                fileName = previewForm.FileName + previewForm.FileExtension;
                dateAndtime = previewForm.DateAndTime;
            }

            //always want to delete items in cache, regardless of DialogResult.
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


        public void Navigate(string url)
        {
             CurrentTab?.Browser?.Navigate(url);
        }

        private void uiBrowserTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {

            if(CurrentTab.Browser != null)
                addressBar.Text = CurrentTab.CurrentUrl;
        }

        private void uiBrowserStatusStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void uiBrowserTabControl_Click(object sender, EventArgs e)
        {

        }
    }
}
