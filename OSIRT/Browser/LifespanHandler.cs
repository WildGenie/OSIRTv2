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
using OSIRT.Helpers;

namespace OSIRT.Browser
{
    public class LifespanHandler : ILifeSpanHandler
    {
        public event EventHandler OpenInNewTab;

        bool ILifeSpanHandler.OnBeforePopup(IWebBrowser browserControl, IBrowser browser, IFrame frame, string targetUrl, string targetFrameName, WindowOpenDisposition targetDisposition, bool userGesture, IPopupFeatures popupFeatures, IWindowInfo windowInfo, IBrowserSettings browserSettings, ref bool noJavascriptAccess, out IWebBrowser newBrowser)
        {

            newBrowser = null;

            //if (RuntimeSettings.EnableWebDownloadMode) return true; //this prevents all pop-ups.

            OpenInNewTab?.Invoke(this, new NewTabEventArgs(targetUrl));
            return true;
        }

        void ILifeSpanHandler.OnAfterCreated(IWebBrowser browserControl, IBrowser browser)
        {

        }

        bool ILifeSpanHandler.DoClose(IWebBrowser browserControl, IBrowser browser)
        {

            //browserControl.Dispose();
            return true; //was true
        }

        void ILifeSpanHandler.OnBeforeClose(IWebBrowser browserControl, IBrowser browser)
        {
        }
    }
}
