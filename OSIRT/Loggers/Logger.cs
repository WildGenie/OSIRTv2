using System;
using System.Collections.Generic;
using OSIRT.Database;


namespace OSIRT.Loggers
{
    public class Logger
    {
        private Logger() { }

        /// <summary>
        /// Logs the specified 
        /// </summary>
        /// <param name="log"></param>
        public static void Log(BaseLog log)
        {

            Type logType = log.GetType();
            Dictionary<string, string> toLog = new Dictionary<string, string>();
            toLog.Add("print", "true"); //This appears to work. Only checked for webpage_actions.
            toLog.Add("date", log.Date);
            toLog.Add("time", log.Time);
            toLog.Add("action", log.Action);

            DatabaseHandler handler = new DatabaseHandler();

            if (logType == typeof(WebpageActionsLog))
            {
                //webpage_actions (date TEXT, time TEXT, action TEXT, url TEXT, file_name TEXT, hash TEXT, note TEXT
                WebpageActionsLog webpageAction = (WebpageActionsLog)log;
                toLog.Add("url", webpageAction.URL);
                toLog.Add("file_name", webpageAction.FileName);
                toLog.Add("hash", webpageAction.Hash);
                toLog.Add("note", webpageAction.Note);
                handler.Insert("webpage_actions", toLog);
            }
            else if(logType == typeof(WebsiteLog))
            {
                //webpage_log (date TEXT, time TEXT, action TEXT, url TEXT)"
                WebsiteLog webSiteLog = (WebsiteLog)log;
                toLog.Add("url", webSiteLog.URL);
                handler.Insert("webpage_log", toLog);
                
            }
           
                    
           

          
        }


    }
}
