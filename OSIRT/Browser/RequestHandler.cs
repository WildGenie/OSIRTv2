using CefSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using OSIRT.UI;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Http;
using OSIRT.Helpers;
using System.Security.Cryptography;

namespace OSIRT.Browser
{
    public class RequestHandler : IRequestHandler
    {
        
        

        public bool GetAuthCredentials(IWebBrowser browserControl, IBrowser browser, IFrame frame, bool isProxy, string host, int port, string realm, string scheme, IAuthCallback callback)
        {

            using (AuthenticationForm auth = new AuthenticationForm())
            {
                auth.TopMost = true; //this isn't always setting to top, need to check

                //use attempts counter to stop basic auth dialog popping up in continually incorrect un and pass entered.
                //test here: https://www.httpwatch.com/httpgallery/authentication/
                System.Windows.Forms.DialogResult dr = auth.ShowDialog();
                if (dr == System.Windows.Forms.DialogResult.OK)
                {
                    callback.Continue(auth.UserName, auth.Password);
                    return true;
                }
                else
                {
                    callback.Dispose();
                    return false;
                }
            }
            //callback.Dispose();
            //return false;
        }

        private Dictionary<ulong, MemoryStreamResponseFilter> responseDictionary = new Dictionary<ulong, MemoryStreamResponseFilter>();
        public IResponseFilter GetResourceResponseFilter(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, IResponse response)
        {
            //if (!RuntimeSettings.EnableWebDownloadMode) return null;


            var dataFilter = new MemoryStreamResponseFilter();
            responseDictionary.Add(request.Identifier, dataFilter);
            return dataFilter;

           
            //return null;
        }

        public bool OnBeforeBrowse(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, bool isRedirect)
        {
            return false;
        }


        public CefReturnValue OnBeforeResourceLoad(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, IRequestCallback callback)
        {

            //List<string> ua = new List<string>()
            //{
            //    "Mozilla/5.0 (compatible; MSIE 8.0; Windows NT 6.0; Trident/4.0; Acoo Browser 1.98.744; .NET CLR 3.5.30729)",
            //    "Mozilla/5.0 (Windows NT 6.1; WOW64; Trident/7.0; AS; rv:11.0) like Gecko",
            //    "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 7.0; InfoPath.3; .NET CLR 3.1.40767; Trident/6.0; en-IN)",
            //    "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2228.0 Safari/537.36"
            //};

            //var headers = request.Headers;

            //var userAgent = headers["User-Agent"];
            //headers["User-Agent"] = ua[new Random().Next(0, ua.Count)];
            //request.Headers = headers;

            callback.Dispose();
            return CefReturnValue.Continue;
        }

        public bool OnCertificateError(IWebBrowser browserControl, IBrowser browser, CefErrorCode errorCode, string requestUrl, ISslInfo sslInfo, IRequestCallback callback)
        {
            callback.Dispose();
            return false;
        }

        public bool OnOpenUrlFromTab(IWebBrowser browserControl, IBrowser browser, IFrame frame, string targetUrl, WindowOpenDisposition targetDisposition, bool userGesture)
        {
            return false;
        }

        public void OnPluginCrashed(IWebBrowser browserControl, IBrowser browser, string pluginPath)
        {
            
        }

        public bool OnProtocolExecution(IWebBrowser browserControl, IBrowser browser, string url)
        {
            return false;
        }

        public bool OnQuotaRequest(IWebBrowser browserControl, IBrowser browser, string originUrl, long newSize, IRequestCallback callback)
        {
            callback.Dispose();
            return false;
        }

        public void OnRenderProcessTerminated(IWebBrowser browserControl, IBrowser browser, CefTerminationStatus status)
        {
            
        }

        public void OnRenderViewReady(IWebBrowser browserControl, IBrowser browser)
        {
           
        }


        private string oldAddress = "";
        public HashSet<RequestWrapper> Resources { get; private set; } = new HashSet<RequestWrapper>();
        public List<HeaderWrapper> ResponseHeaders { get; private set; } = new List<HeaderWrapper>();

        public void OnResourceLoadComplete(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, IResponse response, UrlRequestStatus status, long receivedContentLength)
        {
            if (oldAddress != browserControl.Address || oldAddress == "")
            {
                oldAddress = browserControl.Address;
                Resources.Clear();
                ResponseHeaders.Clear();
            }

            var dict = response.ResponseHeaders.AllKeys.ToDictionary(x => x, x => response.ResponseHeaders[x]);
            ResponseHeaders.Add(new HeaderWrapper(request.Identifier, dict));

            MemoryStreamResponseFilter filter;
            if (responseDictionary.TryGetValue(request.Identifier, out filter))
            {
                var data = filter.Data;
                Resources.Add(new RequestWrapper(request.Url, request.ResourceType, response.MimeType, data, request.Identifier));
            }

        }


        public void OnResourceRedirect(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, IResponse response, ref string newUrl)
        {
            
        }

        public bool OnResourceResponse(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, IResponse response)
        {

            

            return false;
        }

        public bool OnSelectClientCertificate(IWebBrowser browserControl, IBrowser browser, bool isProxy, string host, int port, X509Certificate2Collection certificates, ISelectClientCertificateCallback callback)
        {
            callback.Dispose();
            return false;
        }
    }
}
