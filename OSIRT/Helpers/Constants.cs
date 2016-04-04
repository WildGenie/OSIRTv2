using OSIRT.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using OSIRT.Enums;

namespace OSIRT.Helpers
{
    public class Constants
    {

        //Actions
        //Using Enum instead
        //public static class Actions
        //{
        //    //public static string Screenshot { get { return strings.ScreenshotAction; } }
        //    //public static string Loaded { get { return strings.LoadedAction; } }

        //}

        //Case container Directories and files
        public static string CasePath { get; set; }
        public static string CaseContainerName { get; set; }
        public static string DatabaseFileName { get { return @"\\case.db"; } }
        public static string ContainerExtension { get { return ".osr"; } }


        /// <summary>
        /// Returns the location of the container, with the container's name in the path
        /// </summary>
        public static string ContainerLocation
        {
            get { return Path.Combine(CasePath, CaseContainerName); }
        }



        //Image Cache Constants
        public static readonly string CacheLocation = Path.Combine(Application.StartupPath, "cache");
        private static readonly string TempImgName = "temp.png";
        private static readonly string ScaledImgName = "scaled.png";
        public static readonly string TempImgFile = Path.Combine(CacheLocation, TempImgName);
        public static readonly string ScaledImgFile = Path.Combine(CacheLocation, ScaledImgName);




        public class Directories
        {

            private static readonly Dictionary<Enums.Actions, string> directories = new Dictionary<Enums.Actions, string>
            {
                { Enums.Actions.Images, @"images" },
                { Enums.Actions.Screenshot, @"images\screenshots" }, //remove leading and trailing slashes in order to use Path.Combine
                { Enums.Actions.Scraped, @"images\scraped" },
                { Enums.Actions.Snippet, @"images\snippets" },
                { Enums.Actions.Batchsnap, @"images\batchsnap" },
                { Enums.Actions.Saved, @"images\saved" },
                { Enums.Actions.Attachment, @"attachments" },
                { Enums.Actions.Video, @"videos" },
                { Enums.Actions.Download, @"downloads" },
                { Enums.Actions.Source, @"downloads\source_code" },
                { Enums.Actions.Report, @"reports" },
            };




            public static List<string> GetCaseDirectories()
            {
                List<string> values = new List<string>(directories.Values);
                return values;
            }

            public static string GetSpecifiedCaseDirectory(Enums.Actions key)
            {
                string value = "";
                if (!directories.TryGetValue(key, out value))
                    throw new KeyNotFoundException($"The key, {key}, does not exist.");

                return value;
            }


        }
    }
}
