using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSIRT.Loggers
{
    public class OsirtActionsLog : BaseLog
    {
        private string hash = "";

        public string Hash
        {
            get
            {
                return this.hash;
            }
            set
            {
                this.hash = value;
            }
        }

    }
}
