using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace OSIRT.Helpers
{
    public class Constants
    {

        //Case container Directories and files
        public static string CasePath { get; set; }
        public static string CaseContainerName { get; set; }
        public static string DatabaseFileName => @"\\case.db";
        public static string PdfReportName => "report.pdf";
        public static string ContainerExtension => ".osr";
        public static string Artefacts => "artefacts";

        //versions
        public static string OsirtVersion = "4.5.0";
        public static string CefVersion = "(Cef 65)";

        /// <summary>
        /// Returns the location of the container, with the container's name in the path
        /// </summary>
        public static string ContainerLocation
        {
            get { return Path.Combine(CasePath, CaseContainerName); }
        }

        public static string ReportContainerName => $"report_{CaseContainerName}_%%dt%%";
        public static string ExportedHashFileName => $"{CaseContainerName}_hash_%%dt%%.txt";
        public static string PageSourceFileName => $"%%dt%%_%%name%%_%%action%%.txt";

        //Image Cache Constants
        public static readonly string CacheLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "osirt" ,"cache");
        public static readonly string VideoCacheLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "osirt" ,"videocache");
        public static readonly string TextCacheLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "osirt", "textcache");
        public static readonly string ApplicationLog = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "osirt", "log.config");
        public static readonly string Favourites = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "osirt", "favourites.config");
        public static readonly string ProxySettingsFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "osirt", "proxy.config");
        public static readonly string BrowserSettingsFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "osirt", "browser.config");
        public static readonly string UserAgentsFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "osirt", "ua.config");

        private static readonly string TempImgName = "temp.png";
        private static readonly string TempLogoName = "templogo.png";
        private static readonly string ScaledImgName = "scaled.png";
        private static readonly string TempVideoName = "temp.mp4";
        private static readonly string TempTextName = "temp.txt";

        public static readonly string TempImgFile = Path.Combine(CacheLocation, TempImgName);
        public static readonly string TempLogoFile = Path.Combine(CacheLocation, TempLogoName);
        public static readonly string ScaledImgFile = Path.Combine(CacheLocation, ScaledImgName);
        public static readonly string TempVideoFile = Path.Combine(VideoCacheLocation, TempVideoName);
        public static readonly string TempTextFile = Path.Combine(TextCacheLocation, TempTextName);



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
                { Enums.Actions.Whois, @"downloads\who_is" },
                { Enums.Actions.Ipaddress, @"downloads\ip_addresses" },
                { Enums.Actions.Links, @"downloads\links" },
                { Enums.Actions.Text, @"downloads\saved_text" },
                { Enums.Actions.Exif, @"downloads\exif" },
                { Enums.Actions.Report, @"reports" },
            };



            public static List<string> GetCaseDirectories()
            {
                List<string> values = new List<string>(directories.Values);
                return values;
            }

            public static string GetSpecifiedCaseDirectory(Enums.Actions key)
            {
                string value;
                if (!directories.TryGetValue(key, out value))
                    throw new KeyNotFoundException($"The key, {key}, does not exist.");

                //to ensure backwards compatability with old cases. Create a the directory if it doesn't exist
                Directory.CreateDirectory(Path.Combine(ContainerLocation, value));
                return value;
            }


        }
    }
}
