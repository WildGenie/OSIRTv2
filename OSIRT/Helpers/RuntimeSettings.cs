using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSIRT.Helpers
{
    public class RuntimeSettings
    {
        //add IsUsingTor

        public static bool IsUsingTor = false;
        public static bool EnableWebDownloadMode = false;
        public static bool JsDisabled = false;
        public static bool ImagesDisabled = false;
        public static bool PluginsDisabled = false;
        public static bool SaveHeaders = false;
                                                                                       //change to mydocuments when released 
        //public static string WebpageDownloadSaveLocation = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);


    }
}
