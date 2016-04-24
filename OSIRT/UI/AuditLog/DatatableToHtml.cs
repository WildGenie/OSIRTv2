using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSIRT.UI.AuditLog
{
    class DatatableToHtml
    {

        //http://stackoverflow.com/questions/19682996/datatable-to-html-table
        public static string ConvertToHtml(DataTable table)
        {
            string html = "<table>";
            //add header row
            html += "<tr>";
            for (int i = 0; i < table.Columns.Count; i++)
                html += "<th>" + CultureInfo.CurrentCulture.TextInfo.ToTitleCase(table.Columns[i].ColumnName) + "</th>";
            html += "</tr>";
            //add rows
            for (int i = 0; i < table.Rows.Count; i++)
            {
                html += "<tr>";
                for (int j = 0; j < table.Columns.Count; j++)
                    html += "<td>" + table.Rows[i][j].ToString() + "</td>";
                html += "</tr>";
            }
            html += "</table>";
            return html;
        }

    }
}
