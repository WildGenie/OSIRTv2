using System;

namespace OSIRT
{
    public class UserSettings : CaseSettings<UserSettings>
    {
        public string Homepage = "http://google.com";
        public string Hash = "MD5";
        public string ConstabIcon = @"iVBORw0KGgoAAAANSUhEUgAAAMQAAADECAIAAABPxBk8AAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAAFsSURBVHja7NJBDQAACMQwwL/nQwMJz1bCsk5S8GEkwEyYCTOBmTATZsJMYCbMhJnATJgJM2EmMBNmwkxgJsyEmTATmAkzYSYwE2bCTJgJzISZMBOYCTNhJswEZsJMmAnMhJkwE2YCM2EmzARmwkyYCTOBmTATZsJMYCbMhJnATJgJM2EmMBNmwkxgJsyEmTATmAkzYSYwE2bCTJgJzISZMBOYCTNhJswEZsJMmAnMhJkwE2YCM2EmzARmwkyYCTOBmTATZgIzYSbMhJnATJgJM2EmMBNmwkxgJsyEmTATmAkzYSYwE2bCTJgJzISZMBOYCTNhJswEZsJMmAnMhJkwE2YCM2EmzARmwkyYCTOBmTATZgIzYSbMhJnATJgJM4GZMBNmwkxgJsyEmTATmAkzYSYwE2bCTJgJzISZMBOYCTNhJswEZsJMmAnMhJkwE2YCM2EmzARmwkyYCTOBmTATZgIzYSbMhJngYgUYAPYwBIX3y9zlAAAAAElFTkSuQmCC";
        public bool ClearCacheOnClose = true;
        public bool DefaultSaveAsPdf = false;
        public bool HashContainerOnClose = false;
        public bool AuditLogNewestFirst = false;
        public bool CaseHasPassword = false;
        public int NumberOfRowsPerPage = 25;
        public bool ExportHashOnClose = true;
        public bool EnterInCaseNotesNewLine = false;
        public bool AllowMultipleTabs = true;

        //browser
        public bool AllowImages = true;
        public bool AllowJavaScript = true;
        public bool AllowPlugins = true;

        //reporting
        public bool PrintImagesInReport = true;
        public bool PrintAuditNotes = true;
        public bool ShowVideosInReport = true;
        public string HashExportLocation = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        //video recording
        public bool ShowMouseTrail = false;
        public bool ShowMouseClick = false;
        public int FramesPerSecond = 30;
        public bool UseStereoMix = true;
        public bool UseMicrophone = false;




    }
}
