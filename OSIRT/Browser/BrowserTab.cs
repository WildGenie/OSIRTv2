using DotNetChromeTabs;
using System;
using System.Diagnostics;
using System.Windows.Forms;
using OSIRT.Extensions;
using OSIRT.Loggers;
using CefSharp.WinForms;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using CefSharp;
using System.Threading;
using System.Net;

namespace OSIRT.Browser
{
    public class BrowserTab : ChromeTabControl.TabPage
    {
        public ExtendedBrowser Browser { get; private set; }
        public string CurrentUrl { get; set; }
        private ToolStripComboBox addressBar;
        private IntPtr browserHandle;
        public event EventHandler AddressChanged = delegate { };

        public BrowserTab(ToolStripComboBox addressBar)
        {
            this.addressBar = addressBar;

            Browser = new ExtendedBrowser {Dock = DockStyle.Fill};
            Browser.TitleChanged += Browser_TitleChanged;
            Browser.AddressChanged += Browser_AddressChanged;
            Browser.DownloadHandler = new DownloadHandler();
            Browser.LifeSpanHandler = new LifespanHandler();
            Browser.HandleCreated += Browser_HandleCreated;
            Browser.MouseMove += Browser_MouseMove;
            Controls.Add(Browser);
        }


        private void Browser_MouseMove(object sender, MouseEventArgs e)
        {
            //Debug.WriteLine($"{e.X} {e.Y}");
        }

        private void Browser_HandleCreated(object sender, EventArgs e)
        {
            browserHandle = Browser.Handle;
        }

        private void Browser_AddressChanged(object sender, AddressChangedEventArgs e)
        {
            Logger.Log(new WebsiteLog(e.Address));
            this.InvokeIfRequired(() => addressBar.Text = e.Address);
        }

        private void Browser_TitleChanged(object sender, TitleChangedEventArgs e)
        {
            this.InvokeIfRequired(() => Title = e.Title);
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
