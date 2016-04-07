using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using WebDownloader;

namespace OSIRT.Browser.DownloadManager
{
    public class BrowserDownloadManager : IDownloadManager
    {
        [return: MarshalAs(UnmanagedType.I4)]
        public int Download([In, MarshalAs(UnmanagedType.Interface)] IMoniker pmk, [In, MarshalAs(UnmanagedType.Interface)] IBindCtx pbc, [In, MarshalAs(UnmanagedType.U4)] uint dwBindVerb, [In] int grfBINDF, [In] IntPtr pBindInfo, [In, MarshalAs(UnmanagedType.LPWStr)] string pszHeaders, [In, MarshalAs(UnmanagedType.LPWStr)] string pszRedir, [In, MarshalAs(UnmanagedType.U4)] uint uiCP)
        {
            string name = string.Empty;
            pmk.GetDisplayName(pbc, null, out name);

            if (!string.IsNullOrEmpty(name))
            {
                Uri url = null;
                bool result = Uri.TryCreate(name, UriKind.Absolute, out url);

                if (result)
                {
                    WebDownload manager = new WebDownload();
                    manager.FileToDownload = url.AbsoluteUri;
                    manager.Show();
                    return 0;
                }
            }
            return 1;
        }
    }
}
