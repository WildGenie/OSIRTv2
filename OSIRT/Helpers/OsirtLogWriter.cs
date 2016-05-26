using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSIRT.Helpers
{
    public class OsirtLogWriter
    {
        private OsirtLogWriter() { }

        public static void Write(string caseLocation, bool closedSafely)
        {
            File.WriteAllText(Constants.ApplicationLog, $"{caseLocation},{closedSafely}");
        }

        public static string[] ReadLog()
        {
            return File.ReadAllText(Constants.ApplicationLog).Split(',');
        }


    }
}
