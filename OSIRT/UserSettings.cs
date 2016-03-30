using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSIRT
{
    public class UserSettings : CaseSettings<UserSettings>
    {
        public string homepage = "http://google.com";
        public string hash = "MD5";
        public bool clearCacheOnClose = false;
        public bool defaultSaveAsPDF = false;
        public bool hashContainerOnClose = false;
        public bool auditLogNewestFirst = false;
        public int numberOfRowsPerPage = 25;

    }
}
