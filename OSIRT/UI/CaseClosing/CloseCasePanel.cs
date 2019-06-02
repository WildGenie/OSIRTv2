using System;
using System.Windows.Forms;
using OSIRT.Database;
using OSIRT.Helpers;
using OSIRT.Resources;

namespace OSIRT.UI.CaseClosing
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
            uiPasswordTextBox.UseSystemPasswordChar = true;
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

        private void uiPasswordHelpLabel_Click(object sender, EventArgs e)
        {
            string message = "This is password entered when the case was first created.";
            MessageBox.Show(message, strings.CloseCasePanel_uiPasswordHelpLabel_Click_Password_Help, MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
