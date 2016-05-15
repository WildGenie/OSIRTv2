using System;

namespace OSIRT
{
    public class UserSettings : CaseSettings<UserSettings>
    {
        public string Homepage = "http://google.com";
        public string Hash = "MD5";
        public string IconAsBase64 = "";
        public bool ClearCacheOnClose = false;
        public bool DefaultSaveAsPdf = false;
        public bool HashContainerOnClose = false;
        public bool AuditLogNewestFirst = false;
        public bool CaseHasPassword = false;
        public int NumberOfRowsPerPage = 25;


        //reporting
        public bool PrintImagesInReport = true;
        public bool PrintAuditNotes = true;
        public bool ShowVideosInReport = true;
        public string HashExportLocation = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

        //video recording
        public bool ShowMouseTrail = false;
    }
}
