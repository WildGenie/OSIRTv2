using OSIRT.Database;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSIRT.Helpers
{
    public class CaseCreator
    {
        
        private Dictionary<string, string> caseDetails;
     
        public CaseCreator(Dictionary<string,string> caseDetails, DatabaseTableCreator tables)
        {
            this.caseDetails = caseDetails;
            Constants.CaseContainerName = caseDetails["case_reference"];
            CreateCaseContainer();
            CreateCaseDatabase();
            tables.Create();
            AddCaseDetailsToDB();
        }

        private void CreateCaseContainer()
        {
            Directory.CreateDirectory(Constants.ContainerLocation);
            
            List<string> directories = Constants.Directories.GetDirectories();
            foreach (string directory in directories)
            {
                Directory.CreateDirectory(Constants.ContainerLocation + directory);
            }
        }

        private void CreateCaseDatabase()
        {
            string casePath = Path.Combine(Constants.ContainerLocation + Constants.DatabaseFileName);
            if (!File.Exists(casePath))
            {
                SQLiteConnection.CreateFile(casePath);
            }
        }

        private void AddCaseDetailsToDB()
        {
            DatabaseHandler handler = new DatabaseHandler();
            handler.Insert("case_details", caseDetails);
        }

   
     


    }
}
