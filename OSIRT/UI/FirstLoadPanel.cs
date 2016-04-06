using System;
using System.Windows.Forms;

namespace OSIRT.UI
{
    public partial class FirstLoadPanel : UserControl
    {

        public event EventHandler NewCaseClick;
        public event EventHandler LoadOldCaseClick;
        //public event EventHandler LoadReport_Click;

        public FirstLoadPanel()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
           
        }

   

        private void uiFirstLoadPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void uiNewCaseButton_Click(object sender, EventArgs e)
        {
            NewCaseClick?.Invoke(this, e);
        }

        private void uiNewCaseButton_MouseHover(object sender, EventArgs e)
        {
            uiHelpLabelLabel.Text = Resources.strings.NewCase;
        }

        private void uiLoadExistingCaseButton_MouseHover(object sender, EventArgs e)
        {
            uiHelpLabelLabel.Text = Resources.strings.ExisitingCase;
        }

        private void uiLoadReportButton_MouseHover(object sender, EventArgs e)
        {
            uiHelpLabelLabel.Text = Resources.strings.LoadReport;
        }

        private void uiImagePanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void uiLoadExistingCaseButton_Click(object sender, EventArgs e)
        {
            LoadOldCaseClick?.Invoke(this, e);
        }

        private void uiLoadReportButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("COMING SOON");
        }
    }
}
