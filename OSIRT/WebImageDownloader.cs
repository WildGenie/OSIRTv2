using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSIRT
{
    public class WebImageDownloader
    {

        private string url;

        public WebImageDownloader(string url)
        {
            this.url = url;
        }

        public void DownloadAll()
        {
            var document = new HtmlWeb().Load(url);
            var urls = document.DocumentNode.Descendants("img")
                                            .Select(e => e.GetAttributeValue("src", null))
                                            .Where(s => !string.IsNullOrEmpty(s));
        }

    }
}
