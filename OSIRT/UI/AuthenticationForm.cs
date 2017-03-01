using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSIRT.UI
{
    public partial class AuthenticationForm : Form
    {

        public string UserName { get; set; }
        public string Password { get; set; }

        public AuthenticationForm()
        {
            InitializeComponent();
        }

        private void AuthenticationForm_Load(object sender, EventArgs e)
        {

        }

        private void uiOKButton_Click(object sender, EventArgs e)
        {
            UserName = uiUserNameTextBox.Text;
            Password = uiPasswordTextBox.Text;
        }
    }
}
