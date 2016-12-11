using CefSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSIRT
{
    class DownloadEventArgs : EventArgs
    {
        public DownloadItem DownloadItems { get; set; }

        public DownloadEventArgs(DownloadItem items)
        {
            DownloadItems = items;
        }


    }
}
