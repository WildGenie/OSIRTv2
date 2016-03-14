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

        public TabControl.TabPageCollection AuditTabs
        {
             get { return tabbedAuditLog.AuditTabs; }
        }


        int count = 0; //TODO: best place to put this logic.
                        //probably in the AuditTab.
        private void uiNextPageButton_Click(object sender, EventArgs e)
        {
            //if count < max pages?
            count++;
            tabbedAuditLog.CurrentTab.NextPage(count);
            
            
        }

        private void uiPreviousPageButton_Click(object sender, EventArgs e)
        {
            if(count > 1)
                count--;

            tabbedAuditLog.CurrentTab.NextPage(count);
            
        }
    }
}
