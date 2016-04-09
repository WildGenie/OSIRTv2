using DotNetChromeTabs;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace OSIRT.Browser
{
    public class BrowserTab : /*TabPage*/ ChromeTabControl.TabPage
    {
        public ExtendedBrowser Browser { get; private set; }
        public string CurrentUrl { get; set; }

        public BrowserTab()
        {
            Browser = new ExtendedBrowser {Dock = DockStyle.Fill};
            Browser.DocumentTitleChanged += Browser_DocumentTitleChanged;
            Controls.Add(Browser);
        }


        void Browser_DocumentTitleChanged(object sender, EventArgs e)
        {
            Title = Browser.DocumentTitle;
        }

        internal override bool NewInstanceAttempted(ChromeTabControl.TabPage newInstance)
        {
            return true;
        }


        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // BrowserTab
            // 
            this.Name = "BrowserTab";
            this.Load += new System.EventHandler(this.BrowserTab_Load);
            this.ResumeLayout(false);

        }

        private void BrowserTab_Load(object sender, EventArgs e)
        {

        }
    }
}
