using System;

namespace OSIRT.Enums
{
    public class ScreenshotDetails
    {
        public ScreenshotDetails(string url)
        {
            Url = url;
            Date = DateTime.Now.ToString("yyyy-MM-dd");
            Time = DateTime.Now.ToString("HH:mm:ss");
        }

        public string Url { get; private set; } 
        public string Date { get; private set; }
        public string Time { get; private set; }


    }
}
