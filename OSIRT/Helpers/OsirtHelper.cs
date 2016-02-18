using OSIRT.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSIRT.Database
{
    public class OsirtHelper
    {

        public static bool ValidCaseContainer(string containerFile)
        {

            
            //TODO: Fix this mess!
            string[] files = Directory.GetDirectories(containerFile,"*", SearchOption.AllDirectories);




            List<string> tempFiles = new List<string>();

            foreach (string file in files)
            {
                tempFiles.Add(file.Remove(0, containerFile.Length).Trim('\\'));
            }

            string[] expectedFiles = Constants.Directories.GetCaseDirectories().ToArray();
            Array.Sort(expectedFiles);
            Array.Sort(tempFiles.ToArray());



            return Enumerable.SequenceEqual(tempFiles, expectedFiles); ;
        }

    }
}
