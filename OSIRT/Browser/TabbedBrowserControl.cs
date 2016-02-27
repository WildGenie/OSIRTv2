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
using System.Drawing.Drawing2D;
using OSIRT.Loggers;

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
            //TODO: will need to reset this text when tabs are switched back
            CurrentTab.CurrentURL = CurrentBrowser.Url.AbsoluteUri;
            addressBar.Text = CurrentTab.CurrentURL;
          
        }

        private void Screenshot_Completed(object sender, ScreenshotCompletedEventArgs e)
        {
            ScreenshotDetails details = e.ScreenshotDetails;

            ImagePreviewerForm previewForm = new ImagePreviewerForm(Path.Combine(Constants.CacheLocation, "temp.png"), details);
            DialogResult res =  previewForm.ShowDialog();

            //Will need this check later, disable for now for testing
               //if (res != DialogResult.OK)
              //  return;

            //Log: Perhaps move this into the ImagePreviewer?
            HashService hashService = HashServiceFactory.Create("SHA1");
            string hash = hashService.ToHex(hashService.ComputeHash(File.OpenRead(Path.Combine(Constants.CacheLocation, "temp.png"))));

            MessageBox.Show("Hash: " + hash);

            Logger.Log(new WebpageActionsLog("www.example.com", "Screenshot", hash, "temp.png", "Blah"));


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
