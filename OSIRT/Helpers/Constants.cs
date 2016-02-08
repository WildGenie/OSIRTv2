using OSIRT.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSIRT.Helpers
{
    public class Constants
    {

        //private  List<string> caseDetails = new List<string>() { strings.InvestigatingOfficer, strings.InvestigatingAgency, strings.OperationName, strings.CaseReference, strings.EvidenceReference, strings.CaseLocation, strings.HashFunction, strings.CaseNotes };
        //public  readonly List<string> CaseDetailFields { get { return caseDetails; } }

        //Directory constants


        public class Directories
        {

            //images
            public static string Screenshots { get { return @"\images\screenshots\"; } }
            public static string Scraped { get { return @"\images\scraped\"; } }
            public static string Snippet { get { return @"\images\snippets\"; } }
            public static string Batchsnap { get { return @"\images\batchsnap\"; } }
            public static string Saved { get { return @"\images\saved\"; } }


            public static string Attachment { get { return @"\attachments\"; } }
            public static string Video { get { return @"\videos\"; } }
            public static string Download { get { return @"\downloads\"; } }
            public static string SourceCode { get { return @"\downloads\source_code"; } }
            public static string Report { get { return @"\reports\"; } }
        }
    }
}
