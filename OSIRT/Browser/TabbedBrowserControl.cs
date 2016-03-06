using System;
using System.Windows.Forms;
using System.IO;
using OSIRT.UI;
using OSIRT.Helpers;
using OSIRT.Loggers;
using System.Diagnostics;
using OSIRT.Properties;

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

        public BrowserTab CurrentTab //active tab
        {
            get { return uiBrowserTabControl?.SelectedTab as BrowserTab; }
        }

        private ExtendedBrowser CurrentBrowser
        {
            get
            {
                return CurrentTab.Browser;
            }
        }

        private BrowserTab CreateTab()
        {
            BrowserTab tab = new BrowserTab();
            uiBrowserTabControl.TabPages.Add(tab);
            uiBrowserTabControl.SelectedTab = tab;
            //TODO: Unsubscribe from this event once tab has closed?
            AddBrowserEvents();
            return tab;
        }

        private void AddBrowserEvents()
        {
            CurrentBrowser.StatusTextChanged += Browser_StatusTextChanged;
            CurrentBrowser.Navigated += CurrentBrowser_Navigated;
            CurrentBrowser.Screenshot_Completed += Screenshot_Completed;
        }

        private void CurrentBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            CurrentTab.CurrentURL = CurrentBrowser.Url.AbsoluteUri;
            addressBar.Text = CurrentTab.CurrentURL;
        }

        private void Screenshot_Completed(object sender, ScreenshotCompletedEventArgs e)
        {
    
            ScreenshotDetails details = new ScreenshotDetails(CurrentBrowser.URL);

            DialogResult dialogRes;
            using (ImagePreviewerForm previewForm = new ImagePreviewerForm(details))
            {
                dialogRes = previewForm.ShowDialog();
            }

            if (dialogRes != DialogResult.OK)
                return;
        
            ImageDiskCache.RemoveItemsInCache();

            //TODO: Display message in status bar to say it has been logged
        }

        void Browser_StatusTextChanged(object sender, EventArgs e)
        {
            uiStatusLabel.Text = CurrentBrowser.StatusText;
        }

        public void GetFullPageScreenshot()
        {
            if (CurrentTab == null)
                throw new NullReferenceException("No tabs to screenshot"); //TODO: Handle this better

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
                addressBar.Text = CurrentTab.CurrentURL;
        }


    }
}
