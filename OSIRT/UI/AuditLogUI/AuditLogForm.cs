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
            AuditTabControlPanel auditTabControlPanel = new AuditTabControlPanel(this);
            uiAuditLogSplitContainer.Panel2.Controls.Add(auditTabControlPanel);


            auditTabControlPanel.GetAuditTab().RowEntered += AuditLogForm_RowEntered;

            //auditTabControlPanel.GetAuditTab().RowEnter += AuditLogForm_RowEnter;

        }

        private void AuditLogForm_RowEntered(object sender, EventArgs e)
        {

            DataGridViewCellEventArgs evt = (DataGridViewCellEventArgs) e;

            //TODO: When tab switches this event does not fire
            string rowDetails = "";

            AuditTab audit = (AuditTab)sender;
            DataGridView dgv = audit.AuditLogGrid;

            for (int i = 0; i < dgv.Rows[evt.RowIndex].Cells.Count; i++)
            {
                rowDetails += dgv.Rows[evt.RowIndex].Cells[i].Value.ToString() + " ";
            }

            Debug.WriteLine("ROW ENTER: -----------------" + rowDetails);
        }


    }
}
