using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Text;
using OSIRT.Helpers;

namespace OSIRT.Database
{

    public class DatabaseHandler 
    {

        private readonly string connectionString; 
        
        public DatabaseHandler()
        {
           connectionString = "Data Source=" + Constants.ContainerLocation + Constants.DatabaseFileName + ";Version=3;";
        }


        public int GetTotalRowsFromTable(string table)
        {
            string query = $"SELECT * FROM {table}";
            int count = GetDataTableFromQuery(query).Rows.Count;
            return count;

        }

        public DataTable GetPaginatedDataTable(string table, int page)
        {
            string query = "";
            int limit = UserSettings.Load().NumberOfRowsPerPage;
            if (page == 1)
            {
                query = $"SELECT * FROM {table} LIMIT {limit}"; 
            }
            else
            {
                int offset = (page - 1) * limit;
                query = $"SELECT * FROM {table} LIMIT {offset}, {limit}"; //get 25 rows after page (e.g; 75).
            }

            return GetDataTableFromQuery(query);
        }


        public DataTable GetAllRows(string table)
        {
            string query = $"SELECT * FROM {table}";
            return GetDataTableFromQuery(query);
        }

        public DataTable GetRowsFromColumns(string table, params string[] columns)
        {
            string joinedColumn = string.Join(",", columns);
            string query = $"SELECT {joinedColumn} FROM {table}";
            return GetDataTableFromQuery(query);
        }
        
        private DataTable GetDataTableFromQuery(string query)
        {
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
            return dataTable;
        }
        
        public string GetPasswordHash()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString, true))
            {
                using (SQLiteCommand command = new SQLiteCommand(conn))
                {
                    conn.Open();
                    command.CommandText = "SELECT hashed_password FROM case_details";
                    return command.ExecuteScalar().ToString();
                }
            }
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

                        sbVal.Append(sbVal.Length == 0 ? " values(" : ", ");

                        sbVal.Append("@v");
                        sbVal.Append(kv.Key);
                    }

                    sbCol.Append(") ");
                    sbVal.Append(");");

                    command.CommandText = sbCol + sbVal.ToString();

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
