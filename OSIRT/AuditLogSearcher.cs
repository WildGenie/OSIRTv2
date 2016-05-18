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


        private static DataTable GetMergedDataTable()
        {
            DatabaseHandler db = new DatabaseHandler();
            DataTable merged = new DataTable();
            foreach (string table in DatabaseTableHelper.GetTables())
            {
                string columns = DatabaseTableHelper.GetTableColumns(table);
                DataTable dt = db.GetRowsFromColumns(table: table, columns: columns);
                merged.Merge(dt, true, MissingSchemaAction.Add);
            }
            merged.TableName = "merged";
            DataView view = new DataView(merged);
            view.Sort = "date asc, time asc";
            DataTable sortedTable = view.ToTable();
            return sortedTable;
        }


        public static DataTable Search(string databaseTable, string pattern)
        {
            if (databaseTable == "all")
            {
                tableToSearch = GetMergedDataTable();
            }
            else
            {
                DatabaseHandler dbHandler = new DatabaseHandler();
                tableToSearch = dbHandler.GetAllRows(databaseTable);
            }

            SetColumnNames();
            DataRow[] dataRows = tableToSearch.Select(BuildQueryString(pattern));

            if (dataRows.Any()) //can't copy to dataTable if there are no DataRows
            {
                tableToSearch = dataRows.CopyToDataTable();
            }
            else
            {
                tableToSearch = null;
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
