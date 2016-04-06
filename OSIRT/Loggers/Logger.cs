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
            Dictionary<string, string> toLog = new Dictionary<string, string>
            {
                {"print", "true"},
                {"date", log.Date},
                {"time", log.Time},
                {"action", log.Action.ToString()}
            };

            DatabaseHandler handler = new DatabaseHandler();

            if (logType == typeof(WebpageActionsLog))
            {
                //webpage_actions (date TEXT, time TEXT, action TEXT, url TEXT, file_name TEXT, hash TEXT, note TEXT
                WebpageActionsLog webpageAction = (WebpageActionsLog)log;
                toLog.Add("url", webpageAction.Url);
                toLog.Add("file", webpageAction.File);
                toLog.Add("hash", webpageAction.Hash);
                toLog.Add("note", webpageAction.Note);
                handler.Insert("webpage_actions", toLog);
            }
            else if (logType == typeof(WebsiteLog))
            {
                //webpage_log (date TEXT, time TEXT, action TEXT, url TEXT)"
                WebsiteLog webSiteLog = (WebsiteLog)log;
                toLog.Add("url", webSiteLog.Url);
                handler.Insert("webpage_log", toLog);

            }
            else if (logType == typeof(AttachmentsLog))
            {
                //date TEXT, time TEXT, action, file TEXT , hash TEXT, notes TEXT)
                AttachmentsLog attachLog = (AttachmentsLog)log;
                toLog.Add("file", attachLog.File);
                toLog.Add("hash", attachLog.Hash);
                toLog.Add("note", attachLog.Note);
                handler.Insert("attachments", toLog);
            }
            else if(logType == typeof(OsirtActionsLog))
            {
                //osirt_actions (id INTEGER PRIMARY KEY, print BOOLEAN, date TEXT, time TEXT, action TEXT, hash TEXT)"
                OsirtActionsLog osirtAction = (OsirtActionsLog)log;
                toLog.Add("hash", osirtAction.Hash);
                handler.Insert("osirt_actions", toLog);
            }





        }


    }
}
