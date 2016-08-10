using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSIRT.Browser
{
    public class ExifViewerEventArgs : EventArgs
    {
        public string ImageUrl { get; set; }
        
        public ExifViewerEventArgs(string url)
        {
            ImageUrl = url;
        }


    }
}
