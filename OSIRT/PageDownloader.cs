using OSIRT.Browser;
using OSIRT.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OSIRT
{
    public class PageDownloader
    {

        private string output = "";
        private HttpClient client = new HttpClient();
        private string directory;
        private IProgress<string> progress;

        public PageDownloader(TabbedBrowserControl tabs)
        {
            var progressHandler = new Progress<string>(value =>
            {
                tabs.SetStatusLabel(value);
            });

            progress = progressHandler as IProgress<string>;
        }

        public string Output { get { return output; } }
        public string LogDirectory { get { return directory; } }

        public async void Download(List<RequestWrapper> requests)
        {
            directory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), DateTime.Now.ToString("ddMMyyyyHHmmss"));
            Directory.CreateDirectory(directory);
            //requests = RequestHandler.requestList.ToList(); //Could this list actually be an istance so it can work over multiple tabs?

            //requests = uiTabbedBrowserControl.CurrentTab.Browser.Requests().ToList();


            //TODO: Set this to OSIRT's UA?
            client.DefaultRequestHeaders.UserAgent.ParseAdd(@"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/60.0.3112.90 Safari/537.36");

            foreach (var r in requests)
            {
                try
                {
                    using (HttpResponseMessage response = await client.GetAsync(r.RequestUrl))
                    {
                        output += "=================================================================================\r\n";
                        output += "Request URL: " + r.RequestUrl + "\r\n";
                        output += "Resource Type: " + r.ResourceType + "\r\n";
                        output += "Mime Type: " + r.MimeType + "\r\n";

                        if (response.IsSuccessStatusCode)
                        {
                            using (HttpContent content = response.Content)
                            {
                                var file = await content.ReadAsByteArrayAsync();

                                if (file.Length > 0 && r.FileName().Length > 0)
                                {
                                    using (FileStream fs = new FileStream($@"{directory}\{r.FileName()}", FileMode.Create, FileAccess.Write))
                                    {
                                        progress.Report("Downloaded: " + $@"{directory}\{r.FileName()}");
                                        try
                                        {
                                            fs.Write(file, 0, file.Length);

                                            //causing IOException as it has not finished writing
                                            //string hash = OsirtHelper.GetFileHash($@"{directory}\{r.FileName()}");


                                            output += "File saved as: " + r.FileName() + "\r\n";
                                            //output += "Hash [" + UserSettings.Load().Hash + "]" + hash;
                                            output += "Download completed at: " + DateTime.Now.ToString("yyyy-MM-dd-HH:mm:ss.fffffff") + "\r\n";
                                            output += "=================================================================================\r\n";
                                        }
                                        catch
                                        {
                                            output += "Unabled to save this file \r\n";
                                            output += "=================================================================================\r\n";
                                        }
                                    }
                                }
                                else
                                {
                                    output += "Unable to save this file as the Content-Length is 0\r\n";
                                    output += "=================================================================================\r\n";
                                }
                            }
                        }
                        else
                        {
                            output += $"Unable to save this file, HTTP Status Code returned {response.StatusCode.ToString()}  \r\n";
                            output += "=================================================================================\r\n";
                        }
                    }
                }
                catch { }
            }
            ImageDiskCache.RemoveItemsInCache();
        }

    }
}
