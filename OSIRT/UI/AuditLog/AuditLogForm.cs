using System;
using System.Windows.Forms;
using OSIRT.Database;
using OSIRT.Helpers;
using System.Data;
using System.Diagnostics;
using System.Linq;

namespace OSIRT.UI.AuditLog
{
    public partial class AuditLogForm : Form
    {

        private RowDetailsPanel rowDetailsPanel;
        private AuditTabControlPanel auditTabControlPanel;
        private TempSearchPanel rightSearchPanel;
        private ExportAuditOptionsPanel exportReportOptionsPanel;
        private bool isSearchPanel;
        private bool isReportExportPanel;


        public AuditLogForm()
        {
            InitializeComponent();
        }

        private void uiAuditLogForm_Load(object sender, EventArgs e)
        {
            
            rowDetailsPanel = new RowDetailsPanel();
            uiAuditLogSplitContainer.Panel1.Controls.Add(rowDetailsPanel);

            auditTabControlPanel = new AuditTabControlPanel();
            uiAuditLogSplitContainer.Panel2.Controls.Add(auditTabControlPanel);
            AttachRowEventHandler(auditTabControlPanel);

            rightSearchPanel = new TempSearchPanel();
            uiAuditLogSplitContainer.Panel2.Controls.Add(rightSearchPanel);

            exportReportOptionsPanel = new ExportAuditOptionsPanel();
            uiAuditLogSplitContainer.Panel1.Controls.Add(exportReportOptionsPanel);

            rightSearchPanel.Visible = false;
            exportReportOptionsPanel.Visible = false;

            InitialiseSearchComboBox();
            AddCompleteAuditTrail();
        }

        private OsirtGridView completeGridView;
        private DataTable dt = new DataTable();
        private DataTable temp = new DataTable();
        private void AddCompleteAuditTrail()
        {
            //Complete tab
            completeGridView = new OsirtGridView();
            completeGridView.RowEntered += Grid_RowEntered;

            //lazy loading commented out. Partially works, but misses last few records which is probably down to the limit variable
            //need a closer look

            //completeGridView.Scroll += CompleteGridView_Scroll;
            //dt = new DatabaseHandler().GetAllDatabaseData();
            //foreach(DataColumn c in dt.Columns)
            //{ 
            //    temp.Columns.Add(c.ColumnName, c.DataType);
            //}
            completeGridView.DataSource = new DatabaseHandler().GetAllDatabaseData();
            completeGridView.Dock = DockStyle.Fill;
            auditTabControlPanel.AddGridToTab(completeGridView, "Complete");
            //AddRows();
        }

       

        //private void CompleteGridView_Scroll(object sender, ScrollEventArgs e)
        //{
        //    if (e.Type == ScrollEventType.SmallIncrement || e.Type == ScrollEventType.LargeIncrement)
        //    {
        //        if (e.NewValue >= completeGridView.Rows.Count - GetDisplayedRowsCount())
        //        {
        //            TimeSpan ts = DateTime.Now - lastLoading;
        //            if (ts.TotalMilliseconds > 100)
        //            {
        //                firstVisibleRow = e.NewValue;
        //                AddRows();
        //            }
        //            else
        //            {
        //                completeGridView.FirstDisplayedScrollingRowIndex = completeGridView.RowCount - 10;
        //            }
        //        }
        //    }
        //}

        //private const int limit = 10;
        //private int current = 0;
        //private DateTime lastLoading;
        //private int firstVisibleRow = 0;

        //private void AddRows()
        //{
        //    //HideScrollBar(); //this stays commented out
        //    lastLoading = DateTime.Now;
        //    int total_after = limit + current;
        //    while (current < total_after)
        //    {
        //        if (dt.Rows.Count >= total_after)
        //        {
        //            DataRow dr = dt.Rows[current++];
        //            temp.Rows.Add(dr.ItemArray);
        //        }
        //        else
        //            break;
        //    }
        //    if (firstVisibleRow > -1)
        //    {
        //        //ShowScrollBars(); //this stays commented out
        //        try
        //        {
        //            completeGridView.FirstDisplayedScrollingRowIndex = completeGridView.RowCount - 10;
        //        }
        //        catch { }

        //    }
        //    completeGridView.DataSource = temp;
        //}

        //ScrollBars gridscrollbar;
        //private void HideScrollBar()
        //{
        //    gridscrollbar = completeGridView.ScrollBars;
        //    completeGridView.ScrollBars = ScrollBars.None;
        //}
        //private void ShowScrollBars()
        //{
        //    completeGridView.ScrollBars = gridscrollbar;
        //}

        //private int GetDisplayedRowsCount()
        //{
        //    int count = completeGridView.Rows[completeGridView.FirstDisplayedScrollingRowIndex].Height;
        //    count = completeGridView.Height / count;
        //    return count;
        //}


        private void InitialiseSearchComboBox()
        {
            var tabs = auditTabControlPanel.Tabs();
            tabs.Add("All", "all");

            uiSearchSelectionComboBox.DataSource = new BindingSource(tabs, null);
            uiSearchSelectionComboBox.DisplayMember = "Key";
            uiSearchSelectionComboBox.ValueMember = "Value";

            uiSearchSelectionComboBox.SelectedIndex = uiSearchSelectionComboBox.Items.Count - 1; //to display "All" first
        }

        private void uiSearchButton_Click(object sender, EventArgs e)
        {
            string searchText = uiSearchTextBox.Text;
            string tableToSearch = uiSearchSelectionComboBox.SelectedValue.ToString();

            DataTable table = AuditLogSearcher.Search(tableToSearch, searchText);
            UpdateSearchResults(table, tableToSearch);
        }


        private void UpdateSearchResults(DataTable table, string tableToSearch)
        {
            uiAuditLogSplitContainer.Panel2.Controls.Clear();
            uiBackToAuditLogToolStripButton.Enabled = true;

            if (table == null)
            {
                uiAuditLogSplitContainer.Panel2.Controls.Add(new TempSearchPanel("No results to display. Please search another term."));
            }
            else
            {
                table.TableName = tableToSearch;
                OsirtGridView grid = new OsirtGridView(table.TableName);
                grid.RowEntered += Grid_RowEntered;
                grid.DataSource = table;
                grid.Dock = DockStyle.Fill;
                uiAuditLogSplitContainer.Panel2.Controls.Add(grid);
            }
        }

        private void Grid_RowEntered(object sender, EventArgs e)
        {
            ExtendedRowEnterEventArgs args = (ExtendedRowEnterEventArgs)e;
            rowDetailsPanel.PopulateTextBoxes(args.RowDetails);
        }

        private void uiExportReportToolStripButton_Click(object sender, EventArgs e)
        {
            exportReportOptionsPanel.Visible = !isReportExportPanel;
            rowDetailsPanel.Visible = isReportExportPanel;
            isReportExportPanel = !isReportExportPanel;
            uiExportReportToolStripButton.Image = isReportExportPanel ? Properties.Resources.table : Properties.Resources.report;
            uiExportReportToolStripButton.Text = isReportExportPanel ? "Row Details" : "Export Report";
        }


        private void uiBackToAuditLogToolStripButton_Click(object sender, EventArgs e)
        {
            uiAuditLogSplitContainer.Panel2.Controls.Clear();
            auditTabControlPanel = new AuditTabControlPanel();
            uiAuditLogSplitContainer.Panel2.Controls.Add(auditTabControlPanel);
            AttachRowEventHandler(auditTabControlPanel);
            uiBackToAuditLogToolStripButton.Enabled = false;
        }

        private void uiSearchToolStripButton_Click(object sender, EventArgs e)
        {
            SwapPanels(isSearchPanel);
            isSearchPanel = !isSearchPanel;
        }

        private void SwapPanels(bool on)
        {
            uiBackToAuditLogToolStripButton.Enabled = on;
            auditTabControlPanel.Visible = on;
            rightSearchPanel.Visible = !on;
        }

        private void AttachRowEventHandler(AuditTabControlPanel pAuditTabControlPanel)
        {
            var tabs = pAuditTabControlPanel.AuditTabs;

            foreach (AuditTab tab in tabs)
            {
                if (tab.Text == "Complete") continue;
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

        private void uiSearchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                uiSearchButton_Click(this, new EventArgs());
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
    }
}
