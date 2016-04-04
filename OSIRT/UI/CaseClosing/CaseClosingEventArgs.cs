using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSIRT.UI.CaseClosing
{
    public class CaseClosingEventArgs : EventArgs
    {

        public string Password { get; private set; }

        public CaseClosingEventArgs(string password)
        {
            Password = password;
        }




    }
}
