using System;

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
