using CefSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDownloader;

namespace OSIRT.Browser
{
    public class DownloadHandler : IDownloadHandler
    {
        public void OnBeforeDownload(IBrowser browser, DownloadItem downloadItem, IBeforeDownloadCallback callback)
        {
            if (!callback.IsDisposed)
            {
                using (callback)
                {
                                     //downloadPath, show default download dialog
                    //callback.Continue(downloadItem.SuggestedFileName, showDialog: true);

                    WebDownload manager = new WebDownload();
                    manager.FileToDownload = downloadItem.Url;
                    manager.Show();

                }
            }
        }

        public void OnDownloadUpdated(IBrowser browser, DownloadItem downloadItem, IDownloadItemCallback callback)
        {

        }
    }
}
