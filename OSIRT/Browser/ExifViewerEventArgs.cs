using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSIRT.Browser
{
    public class TextEventArgs : EventArgs
    {
        public string Result { get; set; }
        
        public TextEventArgs(string result)
        {
            Result = result;
        }


    }
}
