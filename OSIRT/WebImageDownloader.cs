using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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

        //url, filename
        public Dictionary<string, string> GetSafeUrls()
        {
            //TODO: rather than load the page again via url, parse the current document
            //HtmlDocument document = new HtmlDocument();
            //document.LoadHtml();

            var document = new HtmlWeb().Load(url);
            var urls = document.DocumentNode.Descendants("img")
                                            .Select(e => e.GetAttributeValue("src", null))
                                            .Where(s => !string.IsNullOrEmpty(s));


            Dictionary<string, string> files = new Dictionary<string, string>();

            foreach (string url in urls)
            {
                string fullUrl = GetSafeUrl(url);
                string filename = Path.GetFileName(fullUrl);


                if (files.ContainsKey(fullUrl)) continue;

                files.Add(fullUrl, filename);
            }
            return files;
        }


        private string GetSafeUrl(string url)
        {
            if (url.StartsWith(@"//"))
            {
                url = "http:" + url;
            }

            if (IsRelativeUrl(url))
            {
                url = "http://" + new Uri(url).Host + url;
            }

            return url;
        }

        private string GetSafeFilename(string file)
        {
            if(!Helpers.OsirtHelper.IsValidFilename(file))
            {
                string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff",
                                        CultureInfo.InvariantCulture);
                file = timestamp.Replace(@"/", "_").Replace(":", "_").Replace(" ", "_").Replace(".", "_").Replace(" ", "") + ".png";
            }


            return file;
        }

        private bool IsRelativeUrl(string url)
        {
            //http://stackoverflow.com/questions/10687099/how-to-test-if-a-url-string-is-absolute-or-relative
            //Geo
            return !System.Text.RegularExpressions.Regex.Match(url, @"^(?:[a-z]+:)?//").Success;
        }


    }
}
