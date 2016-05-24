using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSIRT.UI.ViewSource
{
    public class SaveSourceEventArgs : EventArgs
    {
        public string Source { get; private set; }
        public string Domain { get; private set; }
        public SaveSourceEventArgs(string  source, string domain)
        {
            Source = source;
            Domain = domain;
        }

    }
}
