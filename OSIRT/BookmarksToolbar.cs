using OSIRT.Browser;
using OSIRT.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSIRT
{
    public class BookmarksToolbar
    {
        private ToolStrip bookmarkToolStrip;
        public event EventHandler ItemClicked;

        public BookmarksToolbar(ToolStrip toolStrip)
        {
            bookmarkToolStrip = toolStrip;
            AddMenuItem(Properties.Resources.magnifier, "Search Engines", searchEngines);
            AddMenuItem(Properties.Resources.network_tools1, "Network Tools", network);
            AddMenuItem(Properties.Resources.user_go, "People Search", peopleSearch);
            AddMenuItem(Properties.Resources.book_open, "Archive", archive);
            AddMenuItem(Properties.Resources.information, "OSINT", osintTools);

            if(RuntimeSettings.IsUsingTor) AddMenuItem(Properties.Resources.network_firewall, "Tor", torSites);
        }

        private void AddMenuItem(Bitmap icon, string title, Dictionary<string,string> links)
        {
            var dropDown = new ToolStripDropDownButton(title, icon);
            foreach(var k in links)
            {
                var item = new ToolStripMenuItem(k.Key)
                {
                    Tag = k.Value,
                    ToolTipText = k.Value
                };
                item.Click += Item_Click;
                dropDown.DropDownItems.Add(item);
            }
            bookmarkToolStrip.Items.Add(dropDown);
        }

        private void Item_Click(object sender, EventArgs e)
        {
            string url = ((ToolStripMenuItem)sender).Tag.ToString();
            ItemClicked?.Invoke(this, new TextEventArgs(url));
        }

        private Dictionary<string, string> searchEngines = new Dictionary<string, string>()
        {
            { "Google" , "http://google.co.uk"  },
            { "Bing" , "http://bing.co.uk" },
            { "DuckDuckGo" , "http://duckduckgo.co.uk" },
            { "Yahoo" , "https://search.yahoo.com" }
        };

        private Dictionary<string, string> osintTools = new Dictionary<string, string>()
        {
            { "Intel Techniques" , "https://inteltechniques.com/menu.html"  },
            { "OSINT Framework" , "http://osintframework.com/" },
            { "OnStrat" , "http://www.onstrat.com/osint/" },
            { "Toddington - Quick Guide", "https://1x7meb3bmahktmrx39tuiync-wpengine.netdna-ssl.com/wp-content/uploads/Online-Investigative-Process.pdf" }
        };

        private Dictionary<string, string> network = new Dictionary<string, string>()
        {
            { "CentralOps" , "https://centralops.net/co/"  },
            { "WhoIsMind" , "http://www.whoismind.com/" },
            { "MXToolbox", "https://mxtoolbox.com/" }
        };

        private Dictionary<string, string> peopleSearch = new Dictionary<string, string>()
        {
            { "Pipl", "https://pipl.com/" },
            { "KnowEm", "http://knowem.com/" },
            { "Namechk (user name checker)", "https://namechk.com/" }

        };

        private Dictionary<string, string> archive = new Dictionary<string, string>()
        {
            { "Wayback Machine", "https://archive.org/index.php" },
            { "Archive.is", "http://archive.is/" }
        };

        private Dictionary<string, string> torSites = new Dictionary<string, string>()
        {
            { "DuckDuckGo", "http://3g2upl4pq6kufc4m.onion/" },
            { "Hidden Wiki", "http://zqktlwi4fecvo6ri.onion/wiki/index.php/Main_Page" }
        };



    }
}
