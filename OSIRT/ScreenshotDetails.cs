using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSIRT
{
    public class ScreenshotDetails
    {
        public ScreenshotDetails(string url, string hash)
        {
            URL = url;
            Hash = hash;
            Date = DateTime.Now.ToString("yyyy-MM-dd");
            Time = DateTime.Now.ToString("HH:mm:ss");
        }

        public string URL { get; private set; } 
        public string Date { get; private set; }
        public string Time { get; private set; }
        public string Hash { get; private set; } 

    }
}
