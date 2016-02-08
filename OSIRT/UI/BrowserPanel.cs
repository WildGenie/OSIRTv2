using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSIRT.UI
{
    public partial class BrowserPanel : UserControl
    {
        public BrowserPanel()
        {
            InitializeComponent();
        }

        private void BrowserPanel_Load(object sender, EventArgs e)
        {
            ConfigureUI();
        }

        private void ConfigureUI()
        {
            this.Dock = DockStyle.Fill;
            uiBrowserToolStrip.ImageScalingSize = new Size(32, 32);
        }

        private void newTabToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void uiCaseNotesButton_Click(object sender, EventArgs e)
        {

        }

        private void uiAddTabButton_Click(object sender, EventArgs e)
        {
            uiTabbedBrowserControl.NewTab("http://google.com");
        }

        private void uiBrowserToolStrip_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                uiTabbedBrowserControl.Navigate(uiURLComboBox.Text);
                e.SuppressKeyPress = true; //stops "ding" sound when enter is pushed
            }
        }

        private void uiBrowserMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void uiScreenshotButton_Click(object sender, EventArgs e)
        {
            uiTabbedBrowserControl.GetFullPageScreenshot();
        }

       
    }
}
