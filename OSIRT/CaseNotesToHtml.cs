using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OSIRT
{
    public class CaseNotesToHtml
    {
        private CaseNotesToHtml() { }

        public static string CreateHtml(DataTable table)
        {
            
            StringBuilder stringBuilder = new StringBuilder();
            foreach (DataRow row in table.Rows)
            {
                string html = $@"   
                                    <div id='note'>
                                        <p class='date-time'>{row["date"]} {row["time"]}</p>
                                        <hr class='underline'>
                                        <p class='note'>{row["note"]}</p>
                                    </div>
                                ";
                stringBuilder.Append(html);
            }
            return GetHtmlResource().Replace("<%%CASE_NOTES%%>", stringBuilder.ToString());
        }

        private static string GetHtmlResource() //TODO: move this into helpers, change name to GetHtmlResourceFromFile(string file //E.g; casenotes.html)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "OSIRT.Resources.casenotes.html";
            string result;

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                result = reader.ReadToEnd();
            }

            return result;

        }


    }
}
