using OSIRT.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSIRT
{
    public static class FatalExceptionHandler
    {

        public static void Handle(object exception)
        {
            //ZIP up case
            //verify case closed
            //restart app?
            //case closing form

            //we have CaseCleanUpLogic class
            //we'll need to prompt the user for their password, if there is one.

            using (UnhandledExceptionForm exceptionFrom = new UnhandledExceptionForm(exception.ToString()))
            {
                if (DialogResult.OK == exceptionFrom.ShowDialog())
                    Process.GetCurrentProcess().Kill();
            }



        }

    }
}
