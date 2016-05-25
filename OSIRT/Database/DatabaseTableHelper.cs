using System.Collections.Generic;
using System.Text;

namespace OSIRT.Database
{
    public class DatabaseTableHelper
    {

        private static readonly Dictionary<string, string> tablesAndColumns = new Dictionary<string, string>()
        {
            //date TEXT, time TEXT, action TEXT, url TEXT
            {"webpage_log", "date, time, action, url" },
            {"webpage_actions", "date, time, action, url, file, hash, note" },
            {"osirt_actions", "date, time, action, file, hash" },
            {"videos", "date, time, action, file, hash, note" },
            {"attachments", "date, time, action, file, hash, note" },
        };

        public static string GetTableColumns(string table)
        {
            return tablesAndColumns[table];
        }

        public static Dictionary<string, string> GetTablesWithColumns()
        {
            return tablesAndColumns;
        }

        public static Dictionary<string,string>.KeyCollection GetTables()
        {
            return tablesAndColumns.Keys;
        }




        public void CreateTables()
        {
            
            List<string> tables = new List<string>();
            foreach (var kv in tablesAndColumns)
            {
                string insert = $@"CREATE TABLE IF NOT EXISTS {kv.Key} (id INTEGER PRIMARY KEY, print BOOLEAN, {kv.Value.Replace(",", " TEXT,")} ";
                insert += "TEXT)";

                tables.Add(insert);
            }

            tables.Add(@"CREATE TABLE IF NOT EXISTS case_details (investigating_officer TEXT, investigating_agency TEXT, 
                        operation_name TEXT, case_reference TEXT PRIMARY KEY, evidence_reference TEXT, hash_function TEXT, notes TEXT, hashed_password TEXT)");
            tables.Add(@"CREATE TABLE IF NOT EXISTS case_notes (id INTEGER PRIMARY KEY, date TEXT, time TEXT, note TEXT)");

            DatabaseHandler handler = new DatabaseHandler();

            foreach (string table in tables)
            {
                handler.ExecuteNonQuery(table);
            }
        }

    

    }
}
