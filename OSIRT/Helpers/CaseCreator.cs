using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSIRT.Helpers
{
    public class CaseCreator
    {
        
        //update database

        //create directory structure
        public CaseCreator(Dictionary<string,string> caseDetails)
        {
            CreateCaseContainer();
           
        }

        private void CreateCaseContainer()
        {
            List<string> directories = Constants.Directories.GetDirectories();
            foreach (string directory in directories)
            {
                Directory.CreateDirectory(Constants.Directories.CasePath + directory);
            }
        }


     


    }
}
