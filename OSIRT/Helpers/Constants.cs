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


        /// <summary>
        /// Returns the location of the container, with the container's name in the path
        /// </summary>
        public static string ContainerLocation
        {
            get { return Path.Combine(CasePath, CaseContainerName); }
        }

        public static string ReportContainerName => $"report_{CaseContainerName}"; 


        //Image Cache Constants
        public static readonly string CacheLocation = Path.Combine(Application.StartupPath, "cache");
        public static readonly string ApplicationLog = Path.Combine(Application.StartupPath, "log.config");
        private static readonly string TempImgName = "temp.png";
        private static readonly string ScaledImgName = "scaled.png";
        private static readonly string TempVideoName = "temp.mp4";
        public static readonly string TempImgFile = Path.Combine(CacheLocation, TempImgName);
        public static readonly string ScaledImgFile = Path.Combine(CacheLocation, ScaledImgName);
        public static readonly string TempVideoFile = Path.Combine(CacheLocation, TempVideoName);




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
                string value;
                if (!directories.TryGetValue(key, out value))
                    throw new KeyNotFoundException($"The key, {key}, does not exist.");

                return value;
            }


        }
    }
}
