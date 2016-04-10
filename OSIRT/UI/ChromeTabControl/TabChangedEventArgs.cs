using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSIRT.UI.ChromeTabControl
{
    public class TabChangedEventArgs : EventArgs
    {
        public int CurrentIndex { get; private set; }

        public TabChangedEventArgs(int currentIndex)
        {
            CurrentIndex = currentIndex;
        }


    }
}
