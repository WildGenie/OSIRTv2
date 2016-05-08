namespace OSIRT
{
    public class UserSettings : CaseSettings<UserSettings>
    {
        public string Homepage = "http://google.com";
        public string Hash = "MD5";
        public bool ClearCacheOnClose = false;
        public bool DefaultSaveAsPdf = false;
        public bool HashContainerOnClose = false;
        public bool AuditLogNewestFirst = false;
        public int NumberOfRowsPerPage = 25;

        //reporting
        public bool PrintImagesInReport = true;
        public bool PrintAuditNotes = true;
        public bool ShowVideosInReport = true;

        //video recording
        public bool ShowMouseTrail = false;
    }
}
