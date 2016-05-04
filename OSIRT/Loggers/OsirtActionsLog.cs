using OSIRT.Enums;

namespace OSIRT.Loggers
{
    public class OsirtActionsLog : BaseLog 
    {
       

        public OsirtActionsLog(Actions action, string hash, string file) : base(action)
        {
            Hash = hash;
            File = file;
        }

        public string Hash { get; set; }
        public string File { get; set; }

    }
}
