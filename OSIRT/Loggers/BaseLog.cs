using OSIRT.Enums;
using System;

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
