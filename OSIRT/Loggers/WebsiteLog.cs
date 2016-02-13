using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSIRT
{
    public class WebsiteLog : BaseLog
    {
        private string url = "";


        public string URL
        {
            get
            {
                return url;
            }
            set
            {
                this.url = value;
            }
        }

    }
}
