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

        private readonly string url;

        public WebImageDownloader(string url)
        {
            this.url = url;
        }

        //pUrl, filename
        public Dictionary<string, string> GetSafeUrls()
        {
            //TODO: rather than load the page again via pUrl, parse the current document
            //HtmlDocument document = new HtmlDocument();
            //document.LoadHtml();

            var document = new HtmlWeb().Load(url);
            var urls = document.DocumentNode.Descendants("img")
                                            .Select(e => e.GetAttributeValue("src", null))
                                            .Where(s => !string.IsNullOrEmpty(s));


            Dictionary<string, string> files = new Dictionary<string, string>();

            foreach (string u in urls)
            {
                string fullUrl = GetSafeUrl(u);
                string filename = GetSafeFilename(Path.GetFileName(fullUrl));


                if (files.ContainsKey(fullUrl)) continue;

                files.Add(fullUrl, filename);
            }
            return files;
        }


        private string GetSafeUrl(string pUrl)
        {
            if (pUrl.StartsWith(@"//"))
            {
                pUrl = "http:" + pUrl;
            }

            if (IsRelativeUrl(pUrl))
            {
                pUrl = "http://" + new Uri(url).Host + pUrl;
            }
            return pUrl;
        }

        private string GetSafeFilename(string file)
        {
            if (Helpers.OsirtHelper.IsValidFilename(file)) return file;
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fffff",
                CultureInfo.InvariantCulture);
            file = timestamp.Replace(@"/", "_").Replace(":", "_").Replace(" ", "_").Replace(".", "_").Replace(" ", "") + ".png";


            return file;
        }

        private bool IsRelativeUrl(string pUrl)
        {
            //http://stackoverflow.com/questions/10687099/how-to-test-if-a-pUrl-string-is-absolute-or-relative
            //Geo
            return !System.Text.RegularExpressions.Regex.Match(pUrl, @"^(?:[a-z]+:)?//").Success;
        }


    }
}
