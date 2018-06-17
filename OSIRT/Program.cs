using System;
using System.Windows.Forms;
using OSIRT.UI;
using System.Threading;
using OSIRT.UI.Splash;
using CefSharp;
using OSIRT.Helpers;

namespace OSIRT
{
    static class Program
    {


        static Mutex mutex = new Mutex(true, "{AFD8BAF3-4E94-492F-9049-B52ADD704C84}");
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



#if !DEBUG
            try
            {

                AppDomain.CurrentDomain.UnhandledException += (sender, e)
                => FatalExceptionObject(e.ExceptionObject);

                Application.ThreadException += (sender, e)
                => FatalExceptionHandler.Handle(e.Exception);

#endif

            //prevent multi-instance (Matt Davis): http://stackoverflow.com/questions/19147/what-is-the-correct-way-to-create-a-single-instance-application
            if (mutex.WaitOne(TimeSpan.Zero, true))
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new MainForm());
                    mutex.ReleaseMutex();
                }
                else {
                    // send our Win32 message to make the currently running instance
                    // jump on top of all the other windows
                    NativeMethods.PostMessage(
                        (IntPtr)NativeMethods.HWND_BROADCAST,
                        NativeMethods.WM_SHOWME,
                        IntPtr.Zero,
                        IntPtr.Zero);
                }

                //https://github.com/cefsharp/CefSharp/wiki/General-Usage#high-dpi-displayssupport
                //https://github.com/cefsharp/CefSharp/issues/1757

                //OSIRT will crash immediately with no error message if cef.core.dll not available
                //that is, if OSIRT is installed via the MSI, OSIRT won't even load but Windows event viewer will 
                //show a 'System.IO.FileLoadException'
                //make sure appropiate VC++ redists are installed
                //it's this early call to CEF that does causes the issue... Do we event need it?

                Cef.EnableHighDPISupport(); 


#if !DEBUG
            }
            catch (Exception e)
            {
                FatalExceptionHandler.Handle(e);
            }
#endif


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
