using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSIRT.Browser
{
    public class NewTabEventArgs : EventArgs
    {
        public string Url { get; private set; }
        public NewTabEventArgs(string url)
        {
            Url = url;
        }
    }
}
