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
    public class MenuHandler : IContextMenuHandler
    {
        private const int OpenLinkInNewTab = 26501;
        private const int CloseDevTools = 26502;
        private const int MenuSaveImage = 26503;
        private const int ViewSource = 26504;
        private const int SaveYouTubeVideo = 26505;
        private const int ViewImageExifData = 26506;
        private const int ViewFacebookId = 26507;
        private const int CopyImgLocation = 26508;
        
        private const int ExtractAllLinks = 26510;
        private const int Bookmark = 26511;
        private const int ViewTwitterId = 26512;
        private const int SearchSelectedText = 26513;

        private const int ReverseImgSearchSubMenu = 26514;
        private const int ReverseImageSearchTineye = 26509;
        private const int ReverseImageSearchGoogle = 26515;
        private const int ReverseImageSearchYandex = 26516;

        public event EventHandler DownloadImage = delegate { };
        public event EventHandler ViewPageSource = delegate { };
        public event EventHandler DownloadYouTubeVideo = delegate { };
        public event EventHandler ViewImageExif = delegate { };
        public event EventHandler ViewFacebookIdNum = delegate { };
        public event EventHandler ViewTwitterIdNum = delegate { };
        public event EventHandler OpenInNewTabContextMenu = delegate { };
        public event EventHandler CopyImageLocation = delegate { };
        public event EventHandler ReverseImgSearch = delegate { };
        public event EventHandler ExtractLinks = delegate { };
        public event EventHandler AddPageToBookmarks = delegate { };
        public event EventHandler SearchText = delegate { };

        void IContextMenuHandler.OnBeforeContextMenu(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model)
        {
            //Removing existing menu item
            model.Clear();

            if (parameters.TypeFlags.HasFlag(ContextMenuType.Selection))
            {
                model.AddItem((CefMenuCommand)SearchSelectedText, "Search selected text using Google");
                model.AddSeparator();
            }

            if (!string.IsNullOrEmpty(parameters.UnfilteredLinkUrl))
            {
                model.AddItem((CefMenuCommand)26501, "Open link in new tab");
                model.AddSeparator();
            }
            if (parameters.TypeFlags.HasFlag(ContextMenuType.Media) && parameters.HasImageContents)
            {
                if (!UI.BrowserPanel.IsUsingTor)
                {
                    if (OsirtHelper.HasJpegExtension(parameters.SourceUrl))
                    {
                        model.AddItem((CefMenuCommand)ViewImageExifData, "View image EXIF data");
                    }
                    model.AddItem((CefMenuCommand)MenuSaveImage, "Save image");
                }          
                model.AddItem((CefMenuCommand)CopyImgLocation, "Copy image location to clipboard");

                var sub = model.AddSubMenu((CefMenuCommand)ReverseImgSearchSubMenu, "Reverse image search tools");
                sub.AddItem((CefMenuCommand)ReverseImageSearchTineye, "Reverse image search using TinEye");
                sub.AddItem((CefMenuCommand)ReverseImageSearchYandex, "Reverse image search using Yandex");
                sub.AddItem((CefMenuCommand)ReverseImageSearchGoogle, "Reverse image search using Google");
                model.AddSeparator();
                //
            }
            if(OsirtHelper.IsOnYouTube(browserControl.Address))
            {
                model.AddItem((CefMenuCommand)SaveYouTubeVideo, "Extract YouTube video");
            }
            if (OsirtHelper.IsOnFacebook(browserControl.Address))
            {
                model.AddItem((CefMenuCommand)ViewFacebookId, "Show Facebook profile ID");
            }
            if (OsirtHelper.IsOnTwitter(browserControl.Address))
            {
                model.AddItem((CefMenuCommand)ViewTwitterId, "Show Twitter profile ID");
            }

            model.AddItem((CefMenuCommand)ViewSource, "View page source");
            model.AddItem((CefMenuCommand)ExtractAllLinks, "Extract all links on page");
            model.AddItem((CefMenuCommand)Bookmark, "Add page to bookmarks");
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
                ViewImageExif?.Invoke(this, new TextEventArgs(parameters.SourceUrl)); 
            }
            if ((int)commandId == ViewFacebookId)
            {
                ViewFacebookIdNum?.Invoke(this, EventArgs.Empty);
            }
            if ((int)commandId == ViewTwitterId)
            {
                ViewTwitterIdNum?.Invoke(this, EventArgs.Empty);
            }
            if ((int)commandId == CopyImgLocation)
            {
                CopyImageLocation?.Invoke(this, new TextEventArgs(parameters.SourceUrl));
            }

            if ((int)commandId == ReverseImageSearchTineye)
            {
                ReverseImgSearch?.Invoke(this, new TextEventArgs("http://www.tineye.com/search/?url=" + parameters.SourceUrl));
            }
            if ((int)commandId == ReverseImageSearchGoogle)
            {
                ReverseImgSearch?.Invoke(this, new TextEventArgs("https://www.google.com/searchbyimage?&image_url=" + Uri.EscapeUriString(parameters.SourceUrl)));
            }
            if ((int)commandId == ReverseImageSearchYandex)
            {
                ReverseImgSearch?.Invoke(this, new TextEventArgs("https://yandex.com/images/search?url=" + Uri.EscapeUriString(parameters.SourceUrl) + "&rpt=imageview"));
            }

            if ((int)commandId == ExtractAllLinks)
            {
                ExtractLinks?.Invoke(this, EventArgs.Empty);
            }
            if((int)commandId == Bookmark)
            {
                AddPageToBookmarks?.Invoke(this, EventArgs.Empty);
            }
            if ((int)commandId == SearchSelectedText)
            {
                SearchText?.Invoke(this, new TextEventArgs(parameters.SelectionText));
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
