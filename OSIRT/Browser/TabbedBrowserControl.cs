using System;
using System.Windows.Forms;
using OSIRT.Enums;
using OSIRT.UI;
using OSIRT.Helpers;

namespace OSIRT.Browser
{


    public partial class TabbedBrowserControl : UserControl
    {

        private ToolStripComboBox addressBar;

        public TabbedBrowserControl()
        {
            InitializeComponent();
            //uiBrowserTabControl.DrawMode = TabDrawMode.OwnerDrawFixed;
            //uiBrowserTabControl.DrawItem += UiBrowserTabControl_DrawItem;
        }
  
        private void UiBrowserTabControl_DrawItem(object sender, DrawItemEventArgs e)
        {

           
        }

        public BrowserTab CurrentTab => uiBrowserTabControl?.SelectedTab as BrowserTab;
        private ExtendedBrowser CurrentBrowser => CurrentTab.Browser;

        private BrowserTab CreateTab()
        {
            BrowserTab tab = new BrowserTab();
            uiBrowserTabControl.TabPages.Add(tab);
            uiBrowserTabControl.SelectedTab = tab;
            //TODO: Unsubscribe from these events once tab has closed?
            AddBrowserEvents();
            return tab;
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
    
            ScreenshotDetails details = new ScreenshotDetails(CurrentBrowser.URL);
            DialogResult dialogRes;
            string fileName = "";
            using (ImagePreviewerForm previewForm = new ImagePreviewerForm(details))
            {
                dialogRes = previewForm.ShowDialog();
                fileName = previewForm.FileName + previewForm.FileExtension;
            }

            //always want to delete items in cache, regardless of DialogResult.
            ImageDiskCache.RemoveItemsInCache();

            if (dialogRes != DialogResult.OK)
                return;

            uiActionLoggedToolStripStatusLabel.Text = $"{fileName} logged at {12}";

            Timer timer = new Timer {Interval = 3500};
            timer.Start();
            timer.Tick += (s, evt) => { uiActionLoggedToolStripStatusLabel.Text = ""; timer.Stop(); };

        }

        void Browser_StatusTextChanged(object sender, EventArgs e)
        {
            uiStatusLabel.Text = CurrentBrowser.StatusText;
        }

        public void GetFullPageScreenshot()
        {
            if (CurrentTab == null)
                throw new NullReferenceException("No tabs to screenshot");

            CurrentBrowser.GenerateFullpageScreenshot(); 
        }

        public void NewTab(string url, ToolStripComboBox urlBar)
        {
            addressBar =  urlBar;
            CreateTab();
            Navigate(url);
        }

        public void Navigate(string url)
        {
            if (CurrentBrowser != null)
            {
                CurrentTab.Browser.Navigate(url);
            }
        }

        private void uiBrowserTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {

            if(CurrentTab.Browser != null)
                addressBar.Text = CurrentTab.CurrentUrl;
        }

        private void uiBrowserStatusStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
