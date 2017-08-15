using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace OSIRT
{
    public class GlobalSettings<T> where T : new()
    {
        private static readonly string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "osirt", "global_settings.json");

        public void Save()
        {
            File.WriteAllText(fileName, new JavaScriptSerializer().Serialize(this));
        }

        public static void Save(T pSettings)
        {
            File.WriteAllText(fileName, new JavaScriptSerializer().Serialize(pSettings));
        }

        public static T Load()
        {
            T t = new T();
            if (File.Exists(fileName))
                t = (new JavaScriptSerializer()).Deserialize<T>(File.ReadAllText(fileName));
            return t;
        }
    
    }
}
