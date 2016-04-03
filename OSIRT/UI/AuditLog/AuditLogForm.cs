using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OSIRT.Extensions;
using OSIRT.Helpers;
using System.Windows.Media.Imaging;
using OSIRT.Enums;
using System.Diagnostics;
using System.IO;
using OSIRT.UI.AuditLog;

namespace OSIRT.UI
{
    public partial class AuditLogForm : Form
    {

        private RowDetailsPanel rowDetailsPanel;
        private AuditTabControlPanel auditTabControlPanel;

        public AuditLogForm()
        {
            InitializeComponent();
        }

        private void uiAuditLogForm_Load(object sender, EventArgs e)
        {
            auditTabControlPanel = new AuditTabControlPanel();
            uiAuditLogSplitContainer.Panel2.Controls.Add(auditTabControlPanel);
            AttachRowEventHandler(auditTabControlPanel);
            rowDetailsPanel = new RowDetailsPanel();
            uiAuditLogSplitContainer.Panel1.Controls.Add(rowDetailsPanel);
        }

        private void uiSearchToolStripButton_Click(object sender, EventArgs e)
        {

            uiAuditLogSplitContainer.Panel1.Controls.Remove(rowDetailsPanel);

            SearchPanel searchPanel = new SearchPanel(auditTabControlPanel.Tabs());
            uiAuditLogSplitContainer.Panel1.Controls.Add(searchPanel);
            uiAuditLogSplitContainer.Panel2.Controls.Clear();
            uiAuditLogSplitContainer.Panel2.Controls.Add(new TempSearchPanel());
            searchPanel.SearchCompleted += SearchPanel_SearchCompleted; 
        }

        private void SearchPanel_SearchCompleted(object sender, EventArgs e)
        {
            SearchCompletedEventArgs args = (SearchCompletedEventArgs)e;
            uiAuditLogSplitContainer.Panel2.Controls.Clear();

            //TODO: find a way to use AuditGridView with this
            DataGridView grid = new DataGridView();
            grid.DataSource = args.SearchTable;
            grid.Dock = DockStyle.Fill;
            uiAuditLogSplitContainer.Panel2.Controls.Add(grid);

        }

        private void AttachRowEventHandler(AuditTabControlPanel auditTabControlPanel)
        {
            var tabs = auditTabControlPanel.AuditTabs;

            foreach (AuditTab tab in tabs)
            {
                tab.AuditLogGrid.RowEntered += AuditLogForm_RowEntered;
            }
        }

        private void AuditLogForm_RowEntered(object sender, EventArgs e)
        {
            ExtendedRowEnterEventArgs args = (ExtendedRowEnterEventArgs)e;
            rowDetailsPanel.PopulateTextBoxes(args.RowDetails);
        }

        private void AuditLogForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //re-update the database so print is all true again
            //perhaps wrap this in a wait window... "performing audit log closing functions... etc"

            DatabaseHandler db = new DatabaseHandler();
            db.ExecuteNonQuery($"UPDATE webpage_log SET print = 'true'");
            db.ExecuteNonQuery($"UPDATE webpage_actions SET print = 'true'");
            db.ExecuteNonQuery($"UPDATE osirt_actions SET print = 'true'");
            db.ExecuteNonQuery($"UPDATE attachments SET print = 'true'");
            //can't UPDATE multiple tables... look into transactions:
            //http://stackoverflow.com/questions/2044467/how-to-update-two-tables-in-one-statement-in-sql-server-2005
            //http://www.jokecamp.com/blog/make-your-sqlite-bulk-inserts-very-fast-in-c/
        }

    
    }
}
