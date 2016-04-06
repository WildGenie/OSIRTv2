using System;
using System.Windows.Forms;

namespace OSIRT.Browser
{
    public class BrowserTab : TabPage
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
            Text = Browser.DocumentTitle;
        }

    }
}
