using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
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
            this.Load += TabbedBrowserControl_Load;
        }

        void TabbedBrowserControl_Load(object sender, EventArgs e)
        {

       
        }

  

        public BrowserTab CurrentTab //active tab
        {
            get
            {
                BrowserTab page = null;
                if (uiBrowserTabControl.SelectedTab != null)
                {
                    page = uiBrowserTabControl.SelectedTab as BrowserTab;
                }
                 return page;
             }
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
            CurrentBrowser.StatusTextChanged += Browser_StatusTextChanged;
            CurrentBrowser.Navigated += CurrentBrowser_Navigated;
            CurrentBrowser.Screenshot_Completed += Screenshot_Completed;


            return tab;
        }

        private void CurrentBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            //TODO: will need to reset this text when tabs are switched back
            string url = CurrentBrowser.Url.AbsoluteUri;
            addressBar.Text = url;
          
        }

        private void Screenshot_Completed(object sender, ScreenshotCompletedEventArgs e)
        {
            ScreenshotDetails details = e.ScreenshotDetails;

            ImagePreviewerForm previewForm = new ImagePreviewerForm(Path.Combine(Constants.CacheLocation, "temp.png"), details);
            DialogResult res =  previewForm.ShowDialog();

            if (res != DialogResult.OK)
                return;

            //Log


        }

        void Browser_StatusTextChanged(object sender, EventArgs e)
        {
            uiStatusLabel.Text = CurrentBrowser.StatusText;
        }

        public void GetFullPageScreenshot()
        {
            if (CurrentTab == null)
                throw new NullReferenceException("No tabs to screenshot"); //TODO: Handle this better

            CurrentTab.Browser.GetFullpageScreenshot(); 
            //return CurrentTab.Browser.GetFullpageScreenshot();
        }

        public void NewTab(string url, ToolStripComboBox urlBar)
        {
            addressBar =  urlBar;
            CreateTab();
            Navigate(url);
        }

        public void Navigate(string url)
        {
            if (CurrentTab != null)
                CurrentTab.Browser.Navigate(url);
        }

        private void uiBrowserTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


    }
}
