using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OSIRT.Helpers;
using System.Diagnostics;
using OSIRT.UI.CaseClosing;

namespace OSIRT.UI
{
    public partial class CloseCasePanel : UserControl
    {
        public event EventHandler PasswordCorrect;
        public delegate void EventHandler(object sender, CaseClosingEventArgs args);


        public CloseCasePanel()
        {
            InitializeComponent();
        }

        private void CloseCasePanel_Load(object sender, EventArgs e)
        {
            Dock = DockStyle.Fill;
            uiPasswordTextBox.Focus();
        }

        private void uiOKButton_Click(object sender, EventArgs e)
        {
            string password = uiPasswordTextBox.Text;
            string hash = new DatabaseHandler().GetPasswordHash();
            bool isMatch = SecurePasswordHasher.Verify(password, hash);
            if(!isMatch)
            {
                uiInvalidPasswordLabel.Visible = true;
            }
            else
            {
                PasswordCorrect?.Invoke(this, new CaseClosingEventArgs(password));
            }
        }
    }
}
