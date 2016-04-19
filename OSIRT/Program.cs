using System;
using System.Windows.Forms;
using OSIRT.UI;

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
            //TODO: SCALING: http://www.telerik.com/blogs/winforms-scaling-at-large-dpi-settings-is-it-even-possible-

            //Double Check sharex source, they appear to remove AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            //from theur [Form].Designer.cs

            /* 
            * 
            * TODO: If the application ended abruptly before, check the log (CREATE THE LOG)
            * Log where the application was originally loaded from, as It should be where it was "unzipped"
            * Display a pop-up when OSIRT is re-launched. Example: "It appears as though [CASE] did not shut down correctly. Would you like to re-load this case?"
            * If "no" is selected, we will still need to re-archive this case, as it will just be an exposed directory.
            * Couple of answers here (no code, but some advice): http://stackoverflow.com/questions/2481047/executing-code-on-application-crash
            **/

            try
            {
#if !DEBUG
                AppDomain.CurrentDomain.UnhandledException += (sender, e)
                => FatalExceptionObject(e.ExceptionObject);

                Application.ThreadException += (sender, e)
                => FatalExceptionHandler.Handle(e.Exception);

#endif
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());

            }
            catch (Exception e)
            {
#if !DEBUG
                FatalExceptionHandler.Handle(e);
#endif 
            }


        }//main

        //http://stackoverflow.com/questions/406385/handling-unhandled-exceptions-problem
        static void FatalExceptionObject(object exceptionObject)
        {
            var huh = exceptionObject as Exception;
            if (huh == null)
            {
                huh = new NotSupportedException(
                  "Unhandled exception doesn't derive from System.Exception: "
                   + exceptionObject.ToString()
                );
            }
            FatalExceptionHandler.Handle(huh);
        }




    }
}
