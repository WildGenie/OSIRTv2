using OSIRT.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSIRT.Loggers
{
    public class OsirtActionsLog : BaseLog 
    {
       

        public OsirtActionsLog(Actions action, string hash) : base(action)
        {
            Hash = hash;
        }

        public string Hash{ get; set; }

    }
}
