using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSIRT.Browser
{
    public class NavigationalEventArgs : EventArgs
    {
        public bool CanGoForward { get; private set; }
        public bool CanGoBack { get; private set; }

        public NavigationalEventArgs(bool forward, bool back)
        {
            CanGoForward = forward;
            CanGoBack = back;
        }
    }
}
