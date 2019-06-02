using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSIRT
{
    class FacebookIdFinder : IIdFinder
    {
        public string FindId(string source)
        {
            string token = @"/ajax/messaging/composer.php?ids%5B0%5D="; //example: "/ajax/messaging/composer.php?ids%5B0%5D=1234567"
            int index = source.IndexOf(token);

            if (index == -1)
            {
                token = ",\"uid\":";
                index = source.IndexOf(token);

            }

            string sourceTrim = source.Substring(index + token.Length, 40);
            string id = "";

            foreach (char c in sourceTrim)
            {
                if (c == '&' || c == '}')
                    break;

                if (char.IsDigit(c))
                    id += c;
            }

            return id;

            //if (string.IsNullOrWhiteSpace(id))
            //{
            //    uiFacebookIdTextBox.Text = "Not found...";
            //}
            //else
            //{
            //    uiFacebookIdTextBox.Text = id.ToString();
            //}

        }
    }
}
