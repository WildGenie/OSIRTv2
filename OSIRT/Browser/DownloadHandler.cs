using CefSharp;
using OSIRT.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WebDownloader;

namespace OSIRT.Browser
{
    public class DownloadHandler : IDownloadHandler
    {

        public event EventHandler DownloadUpdated;
        public event EventHandler DownloadCompleted;

        public void OnBeforeDownload(IBrowser browser, DownloadItem downloadItem, IBeforeDownloadCallback callback)
        {
            if (RuntimeSettings.EnableWebDownloadMode)
            {
                MessageBox.Show("Web downloads are disabled in this mode.", "Downloads Disabled", MessageBoxButton.OK, MessageBoxImage.Information);
                callback.Dispose();
                return;
            }

            if (!callback.IsDisposed)
            {
                using (callback)
                {
                    callback.Continue(downloadItem.SuggestedFileName, showDialog: true);
                }
            }
        }

        public void OnDownloadUpdated(IBrowser browser, DownloadItem downloadItem, IDownloadItemCallback callback)
        {
            if (RuntimeSettings.EnableWebDownloadMode)
            {
                callback.Dispose();
                return;
            }

            DownloadUpdated?.Invoke(this, new DownloadEventArgs(downloadItem));

            if (downloadItem.IsComplete)
            {
                DownloadCompleted?.Invoke(this, new DownloadEventArgs(downloadItem));
            
            }
        }

       

        

    }
}
