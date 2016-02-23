using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSIRT.Loggers
{
    public class BaseLog
    {

        private string action;


        public BaseLog(string action)
        {
            Action = action;
            Date = DateTime.Now.ToString("yyyy-MM-dd");
            Time = DateTime.Now.ToString("HH:mm:ss");
        }

        public string Action
        {
            get
            {
                return this.action;
            }
            private set
            {
                this.action = value;
            }

        }

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
