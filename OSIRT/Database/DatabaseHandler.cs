using OSIRT.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSIRT.Helpers
{
    public class DatabaseHandler 
    {

        private string connectionString = ""; 
        
        public DatabaseHandler()
        {
           connectionString = "Data Source=" + Constants.ContainerLocation + Constants.DatabaseFileName + ";Version=3;";
        }


        public int GetTotalRowsFromTable(string table)
        {
            //TODO: DRY! Strip out the datatable query (using statements) to their own method
            string query = $"SELECT * FROM {table}";
            DataTable dataTable = new DataTable();
            using (SQLiteConnection conn = new SQLiteConnection(connectionString, true))
            {
                using (SQLiteCommand command = new SQLiteCommand(conn))
                {
                    conn.Open();
                    command.CommandText = query;
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        dataTable.Load(reader);
                    }
                }
            }
            int count = dataTable.Rows.Count;
            return count;

        }

        public DataTable GetDataTable(string table, int page)
        {
            string query = "";
            if (page == 1)
            {
                query = $"SELECT * FROM {table} LIMIT 25"; //TODO: have LIMIT 25 be a user option
            }
            else
            {
                int offset = (page - 1) * 25;
                query = $"SELECT * FROM {table} LIMIT {offset}, 25"; //get 25 rows after page (e.g; 75).
            }

            DataTable dataTable = new DataTable();
            using (SQLiteConnection conn = new SQLiteConnection(connectionString, true))
            {
                using (SQLiteCommand command = new SQLiteCommand(conn))
                {
                    conn.Open();
                    command.CommandText = query;
                    using(SQLiteDataReader reader = command.ExecuteReader())
                    {
                        dataTable.Load(reader);
                    }
                }
            }
            return dataTable;
        }

        
        public int ExecuteNonQuery(string sql)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString, true))
            {
                int rowsUpdated = 0;
                using (SQLiteCommand mycommand = new SQLiteCommand(conn))
                {
                    conn.Open();
                    mycommand.CommandText = sql;
                    rowsUpdated = mycommand.ExecuteNonQuery();

                }
                return rowsUpdated;
            }
           
        }
       

        public void Insert(string tableName, Dictionary<string,string> dataToInsert)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString, true))
            {
                using (SQLiteCommand command = new SQLiteCommand(conn))
                {
                    conn.Open();
                    StringBuilder sbCol = new StringBuilder();
                    StringBuilder sbVal = new StringBuilder();

                    foreach (KeyValuePair<string, string> kv in dataToInsert)
                    {
                        if (sbCol.Length == 0)
                        {
                            sbCol.Append("insert into ");
                            sbCol.Append(tableName);
                            sbCol.Append("(");
                        }
                        else
                        {
                            sbCol.Append(",");
                        }

                        sbCol.Append("`");
                        sbCol.Append(kv.Key);
                        sbCol.Append("`");

                        if (sbVal.Length == 0)
                        {
                            sbVal.Append(" values(");
                        }
                        else
                        {
                            sbVal.Append(", ");
                        }

                        sbVal.Append("@v");
                        sbVal.Append(kv.Key);
                    }

                    sbCol.Append(") ");
                    sbVal.Append(");");

                    command.CommandText = sbCol.ToString() + sbVal.ToString();

                    foreach (KeyValuePair<string, string> kv in dataToInsert)
                    {
                        command.Parameters.AddWithValue("@v" + kv.Key, kv.Value);
                    }

                    //ExecuteNonQuery(command.CommandText);
                    command.ExecuteNonQuery();
                }
            }
        }

    }
}
