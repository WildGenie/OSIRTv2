using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSIRT.UI
{
    public partial class AuditLogForm : Form
    {
        public AuditLogForm()
        {
            InitializeComponent();
        }

        private void uiAuditLogForm_Load(object sender, EventArgs e)
        {
            TabbedAuditLogControl tabbedAuditLog = new TabbedAuditLogControl();


            tabbedAuditLog.Dock = DockStyle.Fill;
            uiAuditLogSplitContainer.Panel2.Controls.Add(tabbedAuditLog);
        }
    }
}
