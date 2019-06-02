using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSIRT
{
    public class GSettings : GlobalSettings<GSettings>
    {
        public bool SaveHttpHeaders = false;
        public bool OpenDirectory = true;
        public string SaveDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);


    }
}
