using OSIRT.Enums;
using OSIRT.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSIRT.UI.AuditLog
{
    class DatatableToHtml
    {

  


        //http://stackoverflow.com/questions/19682996/datatable-to-html-table
        public static string ConvertToHtml(DataTable table, string exportPath)
        {

            //TODO: Have this similar logic when we create the case. DRY.
            //also fire every iteration, obviously don't want that.
            List<string> directories = Constants.Directories.GetCaseDirectories();
            foreach (string directory in directories)
            {
                Directory.CreateDirectory(Path.Combine($"{exportPath}", $"report_{Constants.CaseContainerName}", "artefacts", directory));
                //Debug.WriteLine("DIRECTORY: " + Path.Combine($"{exportPath}", $"report_{Constants.CaseContainerName}", "artefacts", directory));
            }




            string html = "<table>";
            html += "<tr>";
            for (int i = 0; i < table.Columns.Count; i++)
            {
                html += "<th>" + CultureInfo.CurrentCulture.TextInfo.ToTitleCase(table.Columns[i].ColumnName) + "</th>";
            }
            html += "</tr>";

            foreach (DataRow row in table.Rows)
            {
                html += "</tr>";
                foreach (DataColumn column in table.Columns)
                {
                    string cellValue = row[column] != null ? row[column].ToString() : "";
                    string columnName = column.ColumnName; 


                    if(columnName == "file")
                    {
                        Actions action = (Actions) Enum.Parse(typeof(Actions), row["action"].ToString());
                        string location = Constants.Directories.GetSpecifiedCaseDirectory(action);
                        string sourceFile = Path.Combine(Constants.ContainerLocation, location, cellValue);
                        string relativePath = Path.Combine("artefacts", location, cellValue);
                        string destination = Path.Combine( $"{exportPath}", $"report_{Constants.CaseContainerName}", relativePath); //TODO: use relative paths
                        File.Copy(sourceFile, destination, true); //TODO: overwrites existing file... Do we want that?

                        //TODO: Add previewer
                        switch (action)
                        {
                            case Actions.Screenshot:
                            case Actions.Snippet:
                            case Actions.Scraped:

                                break;
                        }

                        html += $@"<td><a href='{relativePath}'>{cellValue}</a></td>";
                    }
                    else
                    {
                        html += "<td>" + cellValue + "</td>";
                    }
                    

                }
                html += "</tr>";
            }
            html += "</table>";
            return html;
        }

    }
}
