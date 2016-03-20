using OSIRT.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSIRT.Loggers
{
    public class BaseLog
    {
        
        public BaseLog(Actions action)
        {
            Action = action;
            Date = DateTime.Now.ToString("yyyy-MM-dd");
            Time = DateTime.Now.ToString("HH:mm:ss");
        }

        public Actions Action { get; private set; }

        public string Date
        {
            get; private set;
        }

        public string Time
        {
            get;  private set;
        }

    }
}
