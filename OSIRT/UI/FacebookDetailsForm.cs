using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSIRT.UI
{
    public partial class FacebookDetailsForm : Form
    {
        public FacebookDetailsForm(string source)
        {
            InitializeComponent();

            string token = @"/ajax/messaging/composer.php?ids%5B0%5D="; //example: "/ajax/messaging/composer.php?ids%5B0%5D=1234567"
            int index = source.IndexOf(token);
            string sourceTrim = source.Substring(index + token.Length, 40);
            string id = "";
            foreach(char c in sourceTrim)
            {
                if (c == '&')
                    break;

                if (char.IsDigit(c))
                    id += c;
            }

            if(string.IsNullOrWhiteSpace(id))
            {
                uiProfileIdLabel.Text = "Not found...";
            }
            else
            {
                uiProfileIdLabel.Text = id.ToString();
            }
            
            
        }

        private void FacebookDetailsForm_Load(object sender, EventArgs e)
        {
            //pass in page source as string
            //parse out number ",uid:"
            //that's the user id
        }
    }
}
