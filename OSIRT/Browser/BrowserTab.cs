using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSIRT.Browser
{
    public class BrowserTab : TabPage
    {
        public MainBrowser Browser { get; private set; }


        public BrowserTab() : base()
        {
            Browser = new MainBrowser();
            Browser.Dock = DockStyle.Fill;
            Browser.DocumentTitleChanged += Browser_DocumentTitleChanged;

            this.Controls.Add(Browser);
        }

        void Browser_DocumentTitleChanged(object sender, EventArgs e)
        {
            this.Text = Browser.DocumentTitle;
        }

    }
}
