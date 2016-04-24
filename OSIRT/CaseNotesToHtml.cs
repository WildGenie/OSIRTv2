using System.Data;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using OSIRT.Database;
using OSIRT.Helpers;

namespace OSIRT
{
    public class CaseNotesToHtml
    {
        private CaseNotesToHtml() { }

        public static string CreateHtml()
        {
            string caseDetails = CaseDetailsToHtml();
            string caseNotes = GetCaseNotesToHtml();
            string htmlResource = OsirtHelper.GetResource("casenotes.html");
            htmlResource = htmlResource.Replace("<%%CASE_NOTES%%>", caseNotes)
                                       .Replace("<%%CASE_DETAILS%%>", caseDetails);
            return htmlResource;
        }

        private static string GetCaseNotesToHtml()
        {
            DataTable table = new DatabaseHandler().GetRowsFromColumns("case_notes", "", "date", "time", "note");
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
            return stringBuilder.ToString();
        }

        private static string CaseDetailsToHtml()
        {
            
            DataTable table = new DatabaseHandler().GetRowsFromColumns("case_details", "investigating_agency", "operation_name", "case_reference", "evidence_reference");
            StringBuilder stringBuilder = new StringBuilder();
            foreach (DataRow row in table.Rows)
            {
                foreach (DataColumn column in table.Columns)
                {
                    string columnName = column.ColumnName.Replace("_", " ").ToLower();
                    string html = $@"<p><strong>{CultureInfo.CurrentCulture.TextInfo.ToTitleCase(columnName)}</strong>: {row[column]} </p>";
                    stringBuilder.Append(html);
                }
            }
            return stringBuilder.ToString();
        }



    }
}
