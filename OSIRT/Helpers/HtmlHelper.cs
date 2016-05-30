using OSIRT.Database;
using OSIRT.Extensions;
using OSIRT.UI.AuditLog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSIRT.Helpers
{
    public class HtmlHelper
    {
        public static string GetCaseDetails()
        {
            //TODO: investigating_agency missing from output? perhaps the audit log header is covering it.
            DataTable table = new DatabaseHandler().GetRowsFromColumns("case_details", "", "investigating_agency", "operation_name", "case_reference", "evidence_reference");
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

        public static string GetHtmlNavBar(List<string> tables)
        {
            StringBuilder navBuilder = new StringBuilder();
            navBuilder.Append("<ul id='nav'>");
            foreach (string table in tables)
            {
                navBuilder.Append($"<li><a href={table}.html>{table.ToTitleCase()}</a></li>");
            }
            navBuilder.Append($"<li><a href=combined.html>Combined</a></li>");
            navBuilder.Append("</ul>");
            return navBuilder.ToString();
        }

        public static string GetFormattedPage(string table, string exportPath, string gscp, bool isHtmlReport)
        {
            DatabaseHandler db = new DatabaseHandler();
            string columns = DatabaseTableHelper.GetTableColumns(table);
            string page = DatatableToHtml.ConvertToHtml(db.GetRowsFromColumns(table: table, columns: columns), exportPath);

            return ReplaceReportDetails(page, gscp, isHtmlReport);

        }

        public static string ReplaceReportDetails(string auditLog, string gscp, bool isHtmlReport)
        {
            string auditHtml = OsirtHelper.GetResource("auditlog.html");
            string timeZone = TimeZone.CurrentTimeZone.IsDaylightSavingTime(DateTime.Now) ? TimeZone.CurrentTimeZone.DaylightName : TimeZone.CurrentTimeZone.StandardName;
            string dateAndTime = $"{DateTime.Now.ToString("yyyy-MM-dd")}  {DateTime.Now.ToString("HH:mm:ss")} ({timeZone})";

            string caseDetails = "";
            if (!isHtmlReport)
            {
                caseDetails = CaseDetailsHtml();
                auditHtml = auditHtml.Replace("<%%NAV%%>", "");
            }

            string save = auditHtml.Replace("<%%AUDIT_LOG%%>", auditLog)
                                   .Replace("<%%CASE_DETAILS%%>", caseDetails);
                                   
            string save2 = save.Replace("<%%MORE_DETAILS%%>", GetCaseDetails())
                 .Replace("<%%CONSTAB_LOGO%%>", UserSettings.Load().ConstabIcon)
                .Replace("<%%DATE_TIME%%>", dateAndTime)
                .Replace("<%%_GSCP_%%>", gscp);
            return save2;
        }

        private static string CaseDetailsHtml()
        {
            string html = 
                $@"<div id='case-details'>
                <hr>
                <h2 id='log-title'>Audit Log <%%_GSCP_%%></h2>
                <img src='data:image/png;base64, <%%CONSTAB_LOGO%%>'>
                <%%MORE_DETAILS%%>
                <br>
                <p id='when-printed'>Created: <%%DATE_TIME%%></p>
                <hr>
            </div>
            <p style='page-break-after:always; '><!-- pagebreak --></p>";

            return html;
        }


    }
}
