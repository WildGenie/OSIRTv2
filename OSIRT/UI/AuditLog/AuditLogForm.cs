using System;
using System.Windows.Forms;
using OSIRT.Database;
using OSIRT.Helpers;

namespace OSIRT.UI.AuditLog
{
    public partial class AuditLogForm : Form
    {

        private RowDetailsPanel rowDetailsPanel;
        private AuditTabControlPanel auditTabControlPanel;
        private SearchPanel searchPanel;
        private TempSearchPanel rightSearchPanel;
        private ExportAuditOptionsPanel exportReportOptions;
        private bool isSearchPanel;


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

            searchPanel = new SearchPanel(auditTabControlPanel.Tabs());
            uiAuditLogSplitContainer.Panel1.Controls.Add(searchPanel);
            searchPanel.SearchCompleted += SearchPanel_SearchCompleted;

            rightSearchPanel = new TempSearchPanel();
            uiAuditLogSplitContainer.Panel2.Controls.Add(rightSearchPanel);

            exportReportOptions = new ExportAuditOptionsPanel();
            uiAuditLogSplitContainer.Panel1.Controls.Add(exportReportOptions);

            rightSearchPanel.Visible = false;
            searchPanel.Visible = false;
            exportReportOptions.Visible = false;

        }

        private void uiSearchToolStripButton_Click(object sender, EventArgs e)
        {
            SwapPanels(isSearchPanel);
            isSearchPanel = !isSearchPanel;
        }

        private void SwapPanels(bool on)
        {
            rowDetailsPanel.Visible = on;
            auditTabControlPanel.Visible = on;
            rightSearchPanel.Visible = !on;
            searchPanel.Visible = !on;

            uiSearchToolStripButton.Image = !on ? Properties.Resources.table : Properties.Resources.search;
            string tooltip = !on ? "Audit Log" : "Search";
            uiSearchToolStripButton.ToolTipText = tooltip;
        }

        private void SearchPanel_SearchCompleted(object sender, EventArgs e)
        {
            SearchCompletedEventArgs args = (SearchCompletedEventArgs)e;
            uiAuditLogSplitContainer.Panel2.Controls.Clear();

            //TODO: find a way to use AuditGridView with this
            //disabling this for now, as panel switching is not quite there

            //DataGridView grid = new DataGridView();
            //grid.DataSource = args.SearchTable;
            //grid.Dock = DockStyle.Fill;
            //uiAuditLogSplitContainer.Panel2.Controls.Add(grid);

        }

        private void AttachRowEventHandler(AuditTabControlPanel pAuditTabControlPanel)
        {
            var tabs = pAuditTabControlPanel.AuditTabs;

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
            db.ExecuteNonQuery("UPDATE webpage_log SET print = 'true'");
            db.ExecuteNonQuery("UPDATE webpage_actions SET print = 'true'");
            db.ExecuteNonQuery("UPDATE osirt_actions SET print = 'true'");
            db.ExecuteNonQuery("UPDATE attachments SET print = 'true'");
            db.ExecuteNonQuery("UPDATE videos SET print = 'true'");
            //can't UPDATE multiple tables... look into transactions:
            //http://stackoverflow.com/questions/2044467/how-to-update-two-tables-in-one-statement-in-sql-server-2005
            //http://www.jokecamp.com/blog/make-your-sqlite-bulk-inserts-very-fast-in-c/
        }


        private void uiExportAsHtmlToolStripButton_Click(object sender, EventArgs e)
        {
            
        }

        private void uiExportReportToolStripButton_Click(object sender, EventArgs e)
        {
            exportReportOptions.Visible = true;
            searchPanel.Visible = false;
            rowDetailsPanel.Visible = false;
        }
    }
}
