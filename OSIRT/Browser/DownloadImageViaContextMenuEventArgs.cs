using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSIRT.Browser
{
    class DownloadImageViaContextMenuEventArgs : EventArgs
    {
        public string Url { get; private set; }

        public DownloadImageViaContextMenuEventArgs(string Url)
        {
            this.Url = Url;
        }

    }
}
