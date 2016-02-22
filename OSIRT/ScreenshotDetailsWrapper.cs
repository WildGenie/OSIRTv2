using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSIRT
{
    public class ScreenshotDetails
    {
        public ScreenshotDetails(string url, string dateAndTime, string hash)
        {
            URL = url;
            DateAndTime = dateAndTime;
            Hash = hash;
        }

        public string URL { get; private set; } 
        public string DateAndTime { get; private set; }
        public string Hash { get; private set; } 

    }
}
