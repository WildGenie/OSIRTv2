using OSIRT.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSIRT.Database
{
    public class DatabaseTableCreator
    {
        public DatabaseTableCreator()
        {
           
        }

        public void Create()
        {
            List<string> tables = new List<string>();

            tables.Add(@"CREATE TABLE IF NOT EXISTS case_details (investigating_officer TEXT, investigating_agency TEXT, 
                        operation_name TEXT, case_reference TEXT PRIMARY KEY, evidence_reference TEXT, hash_function TEXT, notes TEXT)");
            tables.Add(@"CREATE TABLE IF NOT EXISTS webpage_log (print BOOLEAN, date TEXT, time TEXT, action TEXT, url TEXT)");
            tables.Add(@"CREATE TABLE IF NOT EXISTS webpage_actions (print BOOLEAN, date TEXT, time TEXT, action TEXT, url TEXT, file_name TEXT, hash TEXT, note TEXT)");
            tables.Add(@"CREATE TABLE IF NOT EXISTS osirt_actions (print BOOLEAN, date TEXT, time TEXT, action TEXT, hash TEXT)");
            tables.Add(@"CREATE TABLE IF NOT EXISTS attachments (print BOOLEAN, date TEXT, time TEXT, file TEXT, hash TEXT, notes TEXT)");

            DatabaseHandler handler = new DatabaseHandler();

            foreach (string table in tables)
            {
                handler.ExecuteNonQuery(table);
            }
        }

    

    }
}
