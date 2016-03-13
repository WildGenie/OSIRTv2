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
    public partial class AuditTabControlPanel : UserControl
    {
        private TabbedAuditLogControl tabbedAuditLog;

        public AuditTabControlPanel()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Dock = DockStyle.Fill;
            tabbedAuditLog = new TabbedAuditLogControl();
            tabbedAuditLog.Dock = DockStyle.Fill;
            uiGridViewPanel.Controls.Add(tabbedAuditLog);

           


        }

        public TabControl.TabPageCollection GetAuditTabs()
        {
            //tabbedAuditLog

            //return (tabbedAuditLog.CurrentTab as AuditTab);
            return tabbedAuditLog.AuditTabs;
        }

        private void uiGridViewPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
