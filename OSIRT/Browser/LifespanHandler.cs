using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OSIRT.Extensions;

namespace OSIRT.Browser
{
    public class LifespanHandler : ILifeSpanHandler
    {
        public event EventHandler OpenInNewTab;

        bool ILifeSpanHandler.OnBeforePopup(IWebBrowser browserControl, IBrowser browser, IFrame frame, string targetUrl, string targetFrameName, WindowOpenDisposition targetDisposition, bool userGesture, IPopupFeatures popupFeatures, IWindowInfo windowInfo, IBrowserSettings browserSettings, ref bool noJavascriptAccess, out IWebBrowser newBrowser)
        {
            newBrowser = null;
            //opening in new tab is turning out to be troublesome, just open it in the current browser for now.
            //browserControl.Load(targetUrl);
            Console.WriteLine("in handler: " +  targetUrl);
            OpenInNewTab?.Invoke(this, new NewTabEventArgs(targetUrl));
            return true;
        }

        void ILifeSpanHandler.OnAfterCreated(IWebBrowser browserControl, IBrowser browser)
        {

        }

        bool ILifeSpanHandler.DoClose(IWebBrowser browserControl, IBrowser browser)
        {
            browserControl.Dispose();
            return true; //was false
        }

        void ILifeSpanHandler.OnBeforeClose(IWebBrowser browserControl, IBrowser browser)
        {
        }
    }
}
