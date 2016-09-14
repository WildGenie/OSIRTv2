using CefSharp;
using OSIRT.UI.ViewSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using OSIRT.Helpers;
using System.Diagnostics;

namespace OSIRT.Browser
{
    internal class MenuHandler : IContextMenuHandler
    {
        private const int OpenLinkInNewTab = 26501;
        private const int CloseDevTools = 26502;
        private const int MenuSaveImage = 26503;
        private const int ViewSource = 26504;
        private const int SaveYouTubeVideo = 26505;
        private const int ViewImageExifData = 26506;
        private const int ViewFacebookId = 26507;
        private const int CopyImgLocation = 26508;

        public event EventHandler DownloadImage = delegate { };
        public event EventHandler ViewPageSource = delegate { };
        public event EventHandler DownloadYouTubeVideo = delegate { };
        public event EventHandler ViewImageExif = delegate { };
        public event EventHandler ViewFacebookIdNum = delegate { };
        public event EventHandler OpenInNewTabContextMenu = delegate { };
        public event EventHandler CopyImageLocation = delegate { };

        void IContextMenuHandler.OnBeforeContextMenu(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model)
        {
            //Removing existing menu item
            model.Remove(CefMenuCommand.ViewSource); // Remove "View Source" option
            model.Remove(CefMenuCommand.Print);
            //Add new custom menu items
            model.AddItem((CefMenuCommand)ViewSource, "View Page Source");
            if (parameters.TypeFlags.HasFlag(ContextMenuType.Media) && parameters.HasImageContents)
            {
                if(OsirtHelper.HasJpegExtension(parameters.SourceUrl))
                {
                    model.AddItem((CefMenuCommand)ViewImageExifData, "View image EXIF data");
                }
                model.AddItem((CefMenuCommand)MenuSaveImage, "Save image");
                model.AddItem((CefMenuCommand)CopyImgLocation, "Copy image location to clipboard");
            }
            if(OsirtHelper.IsOnYouTube(browserControl.Address))
            {
                model.AddItem((CefMenuCommand)SaveYouTubeVideo, "Extract YouTube video");
            }
            if (OsirtHelper.IsOnFacebook(browserControl.Address))
            {
                model.AddItem((CefMenuCommand)ViewFacebookId, "Show Facebook profile ID");
            }
            if(!string.IsNullOrEmpty(parameters.UnfilteredLinkUrl))
            {
                model.AddItem((CefMenuCommand)26501, "Open link in new tab");
            }
        }

         bool  IContextMenuHandler.OnContextMenuCommand(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, CefMenuCommand commandId, CefEventFlags eventFlags)
         {
            if ((int)commandId == OpenLinkInNewTab)
            {
                //browser.ShowDevTools();
                OpenInNewTabContextMenu?.Invoke(this, new NewTabEventArgs(parameters.UnfilteredLinkUrl));
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
                ViewPageSource?.Invoke(this, null);
            }
            if ((int)commandId == SaveYouTubeVideo)
            {
                DownloadYouTubeVideo?.Invoke(this, null);   //we have the address, anyway, so don't need to pass it via event args.
            }
            if ((int)commandId == ViewImageExifData)
            {
                ViewImageExif?.Invoke(this, new ExifViewerEventArgs(parameters.SourceUrl)); 
            }
            if ((int)commandId == ViewFacebookId)
            {
                ViewFacebookIdNum?.Invoke(this, EventArgs.Empty);
            }
            if ((int)commandId == CopyImgLocation)
            {
                CopyImageLocation?.Invoke(this, new ExifViewerEventArgs(parameters.SourceUrl));
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
