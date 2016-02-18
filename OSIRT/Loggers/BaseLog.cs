using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSIRT.Loggers
{
    public class BaseLog
    {

        private string time;
        private string date;
        private string action;


        public BaseLog(string action)
        {
            Action = action;
        }

        public string Action
        {
            get
            {
                return this.action;
            }
            set
            {
                this.action = value;
            }

        }

        public string Date
        {
            get
            {
                return DateTime.Now.ToString("yyyy-MM-dd");
            }
            set
            {
                this.date = value;
            }
           
        }

        public string Time
        {
            get
            {
                return DateTime.Now.ToString("HH:mm:ss");
            }
            set
            {
                this.time = value;
            }
        }

    }
}
