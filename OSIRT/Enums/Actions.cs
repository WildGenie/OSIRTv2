using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSIRT.Enums
{
    //TODO: these can be used as actions, too.
    //We have const strings that store actions in Constants.cs
    //Bit Silly, let's just use this.
    public enum Actions
    {
        Images,
        Screenshot,
        Scraped,
        Snippet,
        Batchsnap,
        Saved,
        Attachment,
        Video,
        Download,
        Source,
        Report,
        Loaded,
        CaseLoaded,
        CaseClosed,
        CaseNotes

    }
}
