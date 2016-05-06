using OSIRT.Database;
using System;
using System.Collections.Generic;
using System.Data;
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
