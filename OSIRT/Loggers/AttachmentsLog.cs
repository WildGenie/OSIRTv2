using OSIRT.Enums;

namespace OSIRT.Loggers
{
    class AttachmentsLog : BaseLog
    {

        public AttachmentsLog(Actions action, string file, string hash, string note) : base(action)
        {
            Hash = hash;
            Note = note;
            File = file;
        }

        public string Hash { get; private set; }
        public string Note { get; private set; }
        public string File { get; private set; }

    }
}
