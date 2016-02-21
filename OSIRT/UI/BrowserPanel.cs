using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using OSIRT.Helpers;


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


        private void uiScreenshotButton_Click(object sender, EventArgs e)
        {
            uiTabbedBrowserControl.GetFullPageScreenshot();
        }

  
    }
}
