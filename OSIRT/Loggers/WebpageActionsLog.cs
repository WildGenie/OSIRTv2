using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSIRT.Loggers
{
    class WebpageActionsLog : WebsiteLog
    {
        private string hash = "";
        private string fileName = "";
        private string note = "";

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

        public string Note
        {
            get
            {
                return this.note;
            }
            set
            {
                this.note = value;
            }
        }

        public string FileName
        {
            get
            {
                return this.fileName;
            }
            set
            {
                this.fileName = value;
            }
        }


    }
}
