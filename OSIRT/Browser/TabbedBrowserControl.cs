using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            //uiBrowserTabControl.DrawMode = TabDrawMode.OwnerDrawFixed;
            //uiBrowserTabControl.SizeMode = TabSizeMode.Fixed;
            //uiBrowserTabControl.ItemSize = new Size(50, 30);
            uiBrowserTabControl.DrawItem += uiBrowserTabControl_DrawItem;
        }

        void uiBrowserTabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            //e.Graphics.DrawString("x", e.Font, Brushes.Black, e.Bounds.Right - 15, e.Bounds.Top + 4);
            //e.Graphics.DrawString(this.uiBrowserTabControl.TabPages[e.Index].Text, e.Font, Brushes.Black, e.Bounds.Left + 12, e.Bounds.Top + 4);
            //e.DrawFocusRectangle();   
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

        BrowserTab CreateTab()
        {
            BrowserTab tab = new BrowserTab();
            uiBrowserTabControl.TabPages.Add(tab);
            uiBrowserTabControl.SelectedTab = tab;
            //uiBrowserTabControl.SelectedTab.Scrollbars
            return tab;
        }

        public string GetFullPageScreenshot()
        {
            if (CurrentTab == null)
                throw new Exception("No tabs to screenshot"); //TODO: Handle this better

            return CurrentTab.Browser.GetFullpageScreenshot();
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
