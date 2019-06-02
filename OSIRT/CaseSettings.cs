using OSIRT.Helpers;
using System;
using System.IO;
using System.Web.Script.Serialization;

namespace OSIRT
{
    //http://stackoverflow.com/questions/453161/best-practice-to-save-application-settings-in-a-windows-forms-application
    public class CaseSettings<T> where T : new()
    {
        private static readonly string fileName = Path.Combine(Constants.ContainerLocation, "settings.json");

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
