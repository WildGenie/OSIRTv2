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

namespace OSIRT.UI.BrowserOptions
{
    public partial class BrowserOptionsForm : Form
    {

        public bool IsUsingTor { get; private set; }
        public string UserAgent{ get; private set; }

        public BrowserOptionsForm()
        {
            InitializeComponent();
        }

        private void uiUserAgentListLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start("http://ua.theafh.net/");
            }
            catch
            {
                MessageBox.Show("Unable to open link. This may be due to there being no default application on this system to open web links with", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void uiOKButton_Click(object sender, EventArgs e)
        {
            IsUsingTor = uiConnectToTorCheckBox.Checked;
            UserAgent = uiUserAgentTextBox.Text;
        }

        private void BrowserOptionsForm_Load(object sender, EventArgs e)
        {

        }
    }
}
