using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSIRT.Helpers
{
    public class DatabaseHandler
    {

        private string connection = "";
        private readonly string DatabaseFileName = "case.db";
        private readonly string TestDatabaseLocation = @"D:\TestDB\";

        public DatabaseHandler()
        {
           
        }

        private void CreateCaseDatabase()
        {
            string casePath = TestDatabaseLocation + DatabaseFileName;
            connection = "Data Source=" + casePath + ";Version=3;";

            if (!File.Exists(casePath))
            {
                SQLiteConnection.CreateFile(casePath);
            }

        }

        private void LoadDatabase()
        {

        }

        public bool Insert(/* table name, data */)
        {
            return false;
        }

    }
}
