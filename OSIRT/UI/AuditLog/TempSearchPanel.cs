using System;
using System.Windows.Forms;

namespace OSIRT.UI.AuditLog
{
    public partial class TempSearchPanel : UserControl
    {
        public TempSearchPanel() : this("Enter your search criteria on the left and press search")
        {
            
        }

        public TempSearchPanel(string message)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            uiSearchHelpLabel.Text = message;
        }

    public void SetMessage(string message)
        {

        }

        private void TempSearchPanel_Load(object sender, EventArgs e)
        {
           
        }
    }
}
