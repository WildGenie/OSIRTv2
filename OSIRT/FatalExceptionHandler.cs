using OSIRT.Helpers;
using OSIRT.UI;
using OSIRT.UI.CaseClosing;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
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
            if (exception is SQLiteException) return;

            if(exception is DllNotFoundException)
            {
                MessageBox.Show("A required library is missing that OSIRT needs. Please ensure that OSIRT is running within the extracted folder. See the 'Running OSIRT' section in the user guide.", "Missing Library", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Application.Exit();
                return;
            }
            else if(exception is MissingMethodException)
            {
                MessageBox.Show("You require the .NET Framework 4.6 or later. Please see the 'System Requirements' section of the user guide to install the correct version of the .NET framework ", "Old version of the .NET framework installed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Application.Exit();
                return;
            }
            //else if(exception is ImageMagick.MagickDelegateErrorException)
            //{
            //    MessageBox.Show("There has been an error combining the screenshot (MagickDelegateErrorException). Try taking the screenshot again.", "Error combining screenshot" ,MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            //    // Application.Exit();
            //    return;
            //}


            using (UnhandledExceptionForm exceptionFrom = new UnhandledExceptionForm(exception.ToString()))
            {
                if (DialogResult.OK == exceptionFrom.ShowDialog())
                {
                    new CaseCleanUpLogic("", false);
                    Application.Exit();
                }
            }



        }

    }
}
