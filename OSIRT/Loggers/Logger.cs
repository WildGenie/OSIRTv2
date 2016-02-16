using System;
using OSIRT.Database;


namespace OSIRT.Loggers
{
    public class Logger
    {
        public static void Log(BaseLog log)
        {

            Type logType = log.GetType();

            if(logType == typeof(WebpageActionsLog))
            {

            }
            else if(logType == typeof(WebsiteLog))
            {
                //((WebsiteLog)log);

                

                //Helpers.DatabaseHandler handler = new DatabaseHandler();


            Database.
                
            }
           
                    
           

          
        }


    }
}
