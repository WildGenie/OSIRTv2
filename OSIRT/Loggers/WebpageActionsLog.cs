using OSIRT.Enums;

namespace OSIRT.Loggers
{
    public class WebpageActionsLog : WebsiteLog
    {

        public WebpageActionsLog(string url, Actions action, string hash, string fileName, string note) : base(url, action)
        {
            Hash = hash;
            File = fileName;
            Note = note;
        }

        public string Hash { get; private set; }
        public string Note { get; private set; }
        public string File { get; private set; }
    }
}
