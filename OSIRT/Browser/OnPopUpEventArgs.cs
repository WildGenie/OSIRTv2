using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSIRT.Browser
{
    class OnPopUpEventArgs : EventArgs
    {

        public string TargetUrl { get; set; }

        public OnPopUpEventArgs(string targetUrl)
        {
            TargetUrl = targetUrl;
        }

    }
}
