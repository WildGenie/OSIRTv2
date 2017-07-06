using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSIRT
{
    class BookmarkJsonHelper
    {
    }

    public class Links
    {
        public string CentralOps { get; set; }
        public string WhoIsMind { get; set; }
        public string MXToolbox { get; set; }
        public string Google { get; set; }
        public string Bing { get; set; }
        public string Yahoo { get; set; }
        public string Pipl { get; set; }
        public string KnowEm { get; set; }
        public string NameCheck { get; set; }
    }

    public class Bookmark
    {
        public string title { get; set; }
        public string icon { get; set; }
        public Links links { get; set; }
    }

    public class Bookmarks
    {
        public List<Bookmark> bookmark { get; set; }
    }

    public class RootObject
    {
        public Bookmarks bookmarks { get; set; }
    }

}
