using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using OSIRT.Database;

namespace OSIRT
{
    public class AuditLogSearcher
    {
        private AuditLogSearcher() { }

        private static List<string> columnNames;
        private static DataTable tableToSearch;


        public static DataTable Search(string databaseTable, string pattern)
        {

            Debug.WriteLine("TABLE TO SEARCH IN SEARCHER: " + databaseTable);
            Debug.WriteLine("TABLE TO SEARCH IN SEARCHER: " + pattern);

            DatabaseHandler dbHandler = new DatabaseHandler();
            tableToSearch = dbHandler.GetAllRows(databaseTable);
            SetColumnNames();
            DataRow[] dataRows = tableToSearch.Select(BuildQueryString(pattern));

            if (dataRows.Any()) //can't copy to dataTable if there are no DataRows
            {
                tableToSearch = dataRows.CopyToDataTable();
            }

            return tableToSearch;
        }

        public static DataTable Search(DataTable table, string pattern)
        {
            tableToSearch = table;
            return null;
        }

        //Get all column names that aren't ID or print
        //This is for when we do a text search, we only want
        //rows the user will understand
        private static void SetColumnNames()
        {
            columnNames = tableToSearch.Columns.Cast<DataColumn>()
                                 .Select(x => x.ColumnName)
                                 .ToList();

            columnNames.Remove("id");
            columnNames.Remove("print");
        }

        private static string BuildQueryString(string pattern)
        {
            StringBuilder sb = new StringBuilder();
            string lastItem = columnNames.Last();
            string or = "OR";

            foreach (string item in columnNames)
            {
                if (item == lastItem)
                    or = "";

                sb.Append($"{item} LIKE '%{pattern}%' {or} ");
            }

            return sb.ToString();

        }

    }
}
