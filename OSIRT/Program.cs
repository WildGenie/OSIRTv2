using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSIRT
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

         
            /* 
            * 
            * TODO: If the application ended abruptly before, check the log (CREATE THE LOG)
            * Log where the application was originally loaded from, as It should be where it was "unzipped"
            * Display a pop-up when OSIRT is re-launched. Example: "It appears as though [CASE] did not shut down correctly. Would you like to re-load this case?"
            * If "no" is selected, we will still need to re-archive this case, as it will just be an exposed directory.
            * Couple of answers here (no code, but some advice): http://stackoverflow.com/questions/2481047/executing-code-on-application-crash
            **/

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
