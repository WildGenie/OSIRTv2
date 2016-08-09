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
        public event EventHandler OnPopUp;

        bool ILifeSpanHandler.OnBeforePopup(IWebBrowser browserControl, IBrowser browser, IFrame frame, string targetUrl, string targetFrameName, WindowOpenDisposition targetDisposition, bool userGesture, IPopupFeatures popupFeatures, IWindowInfo windowInfo, IBrowserSettings browserSettings, ref bool noJavascriptAccess, out IWebBrowser newBrowser)
        {
            newBrowser = null;
            //we know the url that's going to pop-up, handle this. 
            //invoke event, pass the target url, make new tab.
            //Debug.WriteLine("Target url on before pop-up in lifespan handler: " + targetUrl);

            //Control c = (Control)browserControl;

            //c.InvokeIfRequired(() => OnPopUp?.Invoke(this, new OnPopUpEventArgs(targetUrl)));

            browserControl.Load(targetUrl);
            return true;
        }

        void ILifeSpanHandler.OnAfterCreated(IWebBrowser browserControl, IBrowser browser)
        {

        }

        bool ILifeSpanHandler.DoClose(IWebBrowser browserControl, IBrowser browser)
        {
            return false;
        }

        void ILifeSpanHandler.OnBeforeClose(IWebBrowser browserControl, IBrowser browser)
        {
        }
    }
}
