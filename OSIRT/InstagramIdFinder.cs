using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSIRT
{
    class InstagramIdFinder : IIdFinder
    {
        public string FindId(string source)
        {
            int start = source.IndexOf(@"""owner"": {""id"":");
            string chop = source.Substring(start, 40);
            string id = "";

            foreach (char c in chop)
            {
                if (char.IsDigit(c))
                {
                    id += c;
                }
                if (c == '}')
                {
                    break;
                }
            }

            return id;

      
        }
    }
}
