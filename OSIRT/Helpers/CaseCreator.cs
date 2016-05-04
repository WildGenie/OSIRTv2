using OSIRT.Loggers;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using OSIRT.Database;
using OSIRT.Extensions;

namespace OSIRT.Helpers
{
    public class CaseCreator
    {
        
        private Dictionary<string, string> caseDetails;
     
        public CaseCreator(Dictionary<string,string> caseDetails, DatabaseTableHelper tables)
        {
            this.caseDetails = caseDetails;
            Constants.CaseContainerName = caseDetails["case_reference"];
            CreateCaseContainer();
            CreateCaseDatabase();
            tables.CreateTables();
            AddCaseDetailsToDb();

            UserSettings settings = UserSettings.Load();
            settings.Hash = caseDetails["hash_function"];
            settings.Save();

            Logger.Log(new OsirtActionsLog(Enums.Actions.CaseLoaded, "[No Hash - Case Created]", Constants.CaseContainerName));
        }



        private void CreateCaseContainer()
        {

            Directory.CreateDirectory(Constants.ContainerLocation);

            List<string> directories = Constants.Directories.GetCaseDirectories();
            foreach (string directory in directories)
            {
                Directory.CreateDirectory(Path.Combine(Constants.ContainerLocation, directory));
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

        private void AddCaseDetailsToDb()
        {
            DatabaseHandler handler = new DatabaseHandler();
            handler.Insert("case_details", caseDetails);
        }

   
     


    }
}
