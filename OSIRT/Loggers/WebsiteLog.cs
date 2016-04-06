using OSIRT.Enums;

namespace OSIRT.Loggers
{
    public class WebsiteLog : BaseLog
    {
        public WebsiteLog(string loadedUrl, Actions action) : base(action)
        {
            Url = loadedUrl;

        }

        public WebsiteLog(string loadedUrl) : this(loadedUrl, Actions.Loaded) { }
       


        public string Url { get; private set; }
    }
}
