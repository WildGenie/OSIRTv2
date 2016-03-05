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
            AddNewTab();
        }

        private void ConfigureUI()
        {
            this.Dock = DockStyle.Fill;
            uiBrowserToolStrip.ImageScalingSize = new Size(32, 32);
            uiURLComboBox.KeyDown += UiURLComboBox_KeyDown;

        }

        private void UiURLComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                uiTabbedBrowserControl.Navigate(uiURLComboBox.Text);
                e.SuppressKeyPress = true; //stops "ding" sound when enter is pushed
            }
        }

        private void uiAddTabButton_Click(object sender, EventArgs e)
        {
            AddNewTab();
        }


        private void uiScreenshotButton_Click(object sender, EventArgs e)
        {
            uiTabbedBrowserControl.GetFullPageScreenshot();
        }

        private void AddNewTab()
        {
            uiTabbedBrowserControl.NewTab("http://google.com", uiURLComboBox);
        }

        private void uiBrowserMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void uiCaseNotesButton_Click(object sender, EventArgs e)
        {
            using (ImagePreviewerForm pg = new ImagePreviewerForm(new ScreenshotDetails("test.com")))
            {
                pg.ShowDialog();
            } 
        }
    }
}
