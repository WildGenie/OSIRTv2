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
            CurrentBrowser.Screenshot_Completed += DisplayImagePreviewer;


            return tab;
        }

        private void DisplayImagePreviewer(object sender, ScreenshotCompletedArgs e)
        {
            ScreenshotDetails details = e.ScreenshotDetails;

            ImagePreviewerForm previewForm = new ImagePreviewerForm(Path.Combine(Constants.CacheLocation, "temp.png"), details);
            DialogResult res =  previewForm.ShowDialog();
            
            if(res != DialogResult.OK)
            {

            }

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

        public void NewTab(string url)
        {
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
