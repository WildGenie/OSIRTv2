using System.Collections.Generic;

namespace OSIRT.Database
{
    public class DatabaseTableCreator
    {
  

        public void Create()
        {
            List<string> tables = new List<string>
            {
                @"CREATE TABLE IF NOT EXISTS case_details (investigating_officer TEXT, investigating_agency TEXT, 
                        operation_name TEXT, case_reference TEXT PRIMARY KEY, evidence_reference TEXT, hash_function TEXT, notes TEXT, hashed_password TEXT)",
                @"CREATE TABLE IF NOT EXISTS webpage_log (id INTEGER PRIMARY KEY, print BOOLEAN, date TEXT, time TEXT, action TEXT, url TEXT)",
                @"CREATE TABLE IF NOT EXISTS webpage_actions (id INTEGER PRIMARY KEY, print BOOLEAN, date TEXT, time TEXT, action TEXT, url TEXT, file TEXT, hash TEXT, note TEXT)",
                @"CREATE TABLE IF NOT EXISTS osirt_actions (id INTEGER PRIMARY KEY, print BOOLEAN, date TEXT, time TEXT, action TEXT, hash TEXT)",
                @"CREATE TABLE IF NOT EXISTS videos (id INTEGER PRIMARY KEY, print BOOLEAN, date TEXT, time TEXT, action TEXT, file TEXT, hash TEXT, note TEXT)",
                @"CREATE TABLE IF NOT EXISTS attachments (id INTEGER PRIMARY KEY, print BOOLEAN, date TEXT, time TEXT, action TEXT, file TEXT, hash TEXT, note TEXT)",
                @"CREATE TABLE IF NOT EXISTS case_notes (id INTEGER PRIMARY KEY, date TEXT, time TEXT, note TEXT)"
            };


            DatabaseHandler handler = new DatabaseHandler();

            foreach (string table in tables)
            {
                handler.ExecuteNonQuery(table);
            }
        }

    

    }
}
