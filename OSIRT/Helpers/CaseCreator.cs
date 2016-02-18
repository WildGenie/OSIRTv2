using OSIRT.Database;
using OSIRT.Helpers;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace OSIRT.Database
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
            //let's zip it up
            //CompressContainer();
        }

        private void CompressContainer()
        {
            ZipFile.CreateFromDirectory(Constants.ContainerLocation, Constants.ContainerLocation + ".osirt", CompressionLevel.Fastest, false);
            CleanUp();
        }

        private void CleanUp()
        {
            Directory.Delete(Constants.ContainerLocation, true);
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

        private void AddCaseDetailsToDB()
        {
            DatabaseHandler handler = new DatabaseHandler();
            handler.Insert("case_details", caseDetails);
        }

   
     


    }
}
