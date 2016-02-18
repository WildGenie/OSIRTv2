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


        public WebpageActionsLog(string url, string action, string hash, string fileName, string note) : base(url, action)
        {
            this.Hash = hash;
            this.FileName = fileName;
            this.Note = note;
        }

        public string Hash
        {
            get
            {
                return this.hash;
            }
            private set
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
            private set
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
            private set
            {
                this.fileName = value;
            }
        }


    }
}
