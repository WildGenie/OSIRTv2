using OSIRT.Enums;

namespace OSIRT.Loggers
{
    public class OsirtActionsLog : BaseLog 
    {
       

        public OsirtActionsLog(Actions action, string hash) : base(action)
        {
            Hash = hash;
        }

        public string Hash{ get; set; }

    }
}
