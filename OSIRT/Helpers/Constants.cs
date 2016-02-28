using OSIRT.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace OSIRT.Helpers
{
    public class Constants
    {

        //Actions
        public static class Actions
        {
            public static string Screenshot { get { return strings.ScreenshotAction; } }
            public static string Loaded { get { return strings.LoadedAction; } }

        }



        //Case container Directories
        public static string CasePath { get; set; }
        public static string CaseContainerName { get; set; }
        public static string DatabaseFileName { get { return @"\\case.db"; } }
        public static readonly string CacheLocation = Path.Combine(Application.StartupPath, "cache");


        /// <summary>
        /// Returns the location of the container, with the container's name in the path
        /// </summary>
        public static string ContainerLocation
        {
            get { return Path.Combine(CasePath, CaseContainerName); }
        }

        public class Directories
        {

            private static readonly Dictionary<string, string> directories = new Dictionary<string, string>
            {
                { "images", @"images" },
                { "screenshots", @"images\screenshots" }, //removed leading and trailing slashes in order to use Path.Combine
                { "scraped", @"images\scraped" },
                { "snippet", @"images\snippets" },
                { "batchsnap", @"images\batchsnap" },
                { "saved", @"images\saved" },
                { "attachment", @"attachments" },
                { "videos", @"videos" },
                { "downloads", @"downloads" },
                { "source", @"downloads\source_code" },
                { "report", @"reports" },
            };

       



            public static List<string> GetCaseDirectories()
            {
                List<string> values = new List<string>(directories.Values);
                return values;
            }

            public static string GetSpecifiedCaseDirectory(string key)
            {
                string value = "";
                if (!directories.TryGetValue(key, out value))
                    throw new KeyNotFoundException($"The key {key} does not exist.");

                return value;
            }


        }
    }
}
