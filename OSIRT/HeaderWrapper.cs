using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSIRT
{
    public class HeaderWrapper
    {
        public ulong Identifer { get; private set; }
        public Dictionary<string, string> Headers { get; private set; }

        public HeaderWrapper(ulong id, Dictionary<string, string> headers)
        {
            Identifer = id;
            Headers = headers;
        }

    }
}
