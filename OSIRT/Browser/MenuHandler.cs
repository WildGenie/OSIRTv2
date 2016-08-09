using CefSharp;
using OSIRT.UI.ViewSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OSIRT.Browser
{
    internal class MenuHandler : IContextMenuHandler
    {
        private const int ShowDevTools = 26501;
        private const int CloseDevTools = 26502;
        private const int MenuSaveImage = 26503;
        private const int ViewSource = 26504;

        public event EventHandler DownloadImage = delegate { };
        public event EventHandler ViewPageSource = delegate { };

        void IContextMenuHandler.OnBeforeContextMenu(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model)
        {
            //Removing existing menu item
            model.Remove(CefMenuCommand.ViewSource); // Remove "View Source" option
           
            //Add new custom menu items
            model.AddItem((CefMenuCommand)ViewSource, "View Page Source");
            if (parameters.TypeFlags.HasFlag(ContextMenuType.Media) && parameters.HasImageContents)
            {
                model.AddItem((CefMenuCommand)MenuSaveImage, "Save image as...");
                model.AddSeparator();
            }

        }

         bool  IContextMenuHandler.OnContextMenuCommand(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, CefMenuCommand commandId, CefEventFlags eventFlags)
        {
            if ((int)commandId == ShowDevTools)
            {
                browser.ShowDevTools();
            }
            if ((int)commandId == CloseDevTools)
            {
                browser.CloseDevTools();
            }
            if ((int)commandId == MenuSaveImage)
            {
                DownloadImage?.Invoke(this, new DownloadImageViaContextMenuEventArgs(parameters.SourceUrl));
            }
            if ((int)commandId == ViewSource)
            {
                //trigger event and display elsewhere.
                ViewPageSource?.Invoke(this, null);
            }
            return false;
        }

        void IContextMenuHandler.OnContextMenuDismissed(IWebBrowser browserControl, IBrowser browser, IFrame frame)
        {

        }

        bool IContextMenuHandler.RunContextMenu(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model, IRunContextMenuCallback callback)
        {
            return false;
        }
    }
}
