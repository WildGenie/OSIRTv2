using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSIRT.Loggers
{
    class AttachmentsLog : BaseLog
    {

        public AttachmentsLog(string action, string hash, string notes) : base(action)
        {

        }

        public string Hash { get; set; }
        public string Notes { get; set; }

    }
}
