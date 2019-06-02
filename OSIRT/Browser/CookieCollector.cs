using CefSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSIRT.Browser
{
    class CookieCollector : ICookieVisitor
    {

        private readonly List<Cookie> _cookies = new List<Cookie>();
        private readonly TaskCompletionSource<List<Cookie>> _source = new TaskCompletionSource<List<Cookie>>();
        public Task<List<Cookie>> Task => _source.Task;

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public static string GetCookieHeader(List<Cookie> cookies)
        {

            StringBuilder cookieString = new StringBuilder();
            string delimiter = string.Empty;

            foreach (var cookie in cookies)
            {
                cookieString.Append(delimiter);
                cookieString.Append(cookie.Name);
                cookieString.Append('=');
                cookieString.Append(cookie.Value);
                delimiter = "; ";
            }

            return cookieString.ToString();
        }


        public bool Visit(Cookie cookie, int count, int total, ref bool deleteCookie)
        {
            _cookies.Add(cookie);

            if (count == (total - 1))
            {
                _source.SetResult(_cookies);
            }

            return true;
        }
    }
}
