using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSIRT
{
    public class History
    {
        
        public string Date { get; private set; }        
        public string Time { get; private set; }
        public string Url { get; private set; }

        public History(string url, string date, string time)
        {
            Url = url;
            Date = date;
            Time = time;
        }


    }
}
