using OSIRT.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace OSIRT.Helpers
{
    public class OsirtHelper
    {
        public static bool IsValidFilename(string fileName)
        {
            //< > : " / \ | ? *
            return fileName.IndexOfAny(Path.GetInvalidFileNameChars()) == -1;
        }

        public static FileStream WaitForFile(string fullPath)
        {
            for (int numTries = 0; numTries < 10; numTries++)
            {
                try
                {
                    FileStream fs = new FileStream(fullPath, FileMode.Open, FileAccess.ReadWrite,FileShare.None);

                    fs.ReadByte();
                    fs.Seek(0, SeekOrigin.Begin);

                    return fs;
                }
                catch (IOException)
                {
                    Thread.Sleep(50);
                }
            }

            return null;
        }



        public static bool ValidCaseContainer(string containerFile)
        {
            var directories = Directory.EnumerateDirectories(containerFile, "*", SearchOption.AllDirectories);

            //TODO: Fix this mess!
            string[] files = Directory.GetDirectories(containerFile, "*", SearchOption.AllDirectories);
            string[] expectedFiles = Constants.Directories.GetCaseDirectories().ToArray();







            return false;
            //List<string> tempFiles = new List<string>();

            //foreach (string file in directories)
            //{
            //    tempFiles.Add(file.Remove(0, containerFile.Length).Trim('\\'));
            //}

            //string[] expectedFiles = Constants.Directories.GetCaseDirectories().ToArray();
            //Array.Sort(expectedFiles);
            //Array.Sort(tempFiles.ToArray());



            //return Enumerable.SequenceEqual(tempFiles, expectedFiles); ;
        }

    }
}
