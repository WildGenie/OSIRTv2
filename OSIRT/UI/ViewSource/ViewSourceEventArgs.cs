using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSIRT.UI.ViewSource
{
    public class ViewSourceEventArgs : EventArgs
    {

        public string Source { get; private set; }
        public string Title { get; private set; }
        public ViewSourceEventArgs(string source, string title)
        {
            Source = source;
            Title = title;
        }


    }
}
