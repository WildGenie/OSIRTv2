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
            if(DialogResult.OK == MessageBox.Show($"Something went really wrong. Exception: {exception}"))
                Process.GetCurrentProcess().Kill();
        }

    }
}
