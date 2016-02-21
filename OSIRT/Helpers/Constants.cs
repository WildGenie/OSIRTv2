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

            //images
            /*
            public static string Screenshots { get { return @"\images\screenshots\"; } }
            public static string Scraped { get { return @"\images\scraped\"; } }
            public static string Snippet { get { return @"\images\snippets\"; } }
            public static string Batchsnap { get { return @"\images\batchsnap\"; } }
            public static string Saved { get { return @"\images\saved\"; } }


            public static string Attachment { get { return @"\attachments\"; } }
            public static string Video { get { return @"\videos\"; } }
            public static string Download { get { return @"\downloads\"; } }
            public static string SourceCode { get { return @"\downloads\source_code"; } }
            public static string Report { get { return @"\reports\"; } }
             */



        }
    }
}
