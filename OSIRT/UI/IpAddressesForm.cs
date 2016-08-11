using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSIRT.UI
{
    public partial class IpAddressesForm : Form
    {
        public IpAddressesForm(IPAddress[] addresses)
        {
            InitializeComponent();

            string message = $"This domain has {addresses.Count()} IP Addresses associated with it.\r\n";
            foreach(var address in addresses)
            {
                message += address.ToString() + "\r\n";
            }
            uiIpAddressesTextBox.Text = message;

        }

        private void IpAddressesForm_Load(object sender, EventArgs e)
        {

        }
    }
}
