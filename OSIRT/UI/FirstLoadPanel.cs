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
    public partial class FirstLoadPanel : UserControl
    {

        public event EventHandler NewCase_Click;
        public event EventHandler LoadOldCase_Click;
        //public event EventHandler LoadReport_Click;

        public FirstLoadPanel()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
           
        }

   

        private void uiFirstLoadPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void uiNewCaseButton_Click(object sender, EventArgs e)
        {
            if (NewCase_Click != null)
                NewCase_Click(this, e);
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
            if (LoadOldCase_Click != null)
                LoadOldCase_Click(this, e);
        }
    }
}
