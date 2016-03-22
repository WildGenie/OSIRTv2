using OSIRT.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSIRT.UI
{
    public class AuditTab : TabPage
    {

        public DataGridView AuditLogGrid { get; private set; }
        public event EventHandler RowEntered;
        public string TableName { get; private set; }
        public DataTable Table { get; private set; }
        public int Page { get; private set; }
        public int MaxPages { get { return 25; } } //TODO: this will be a user setting
        private int totalRowCount = 0;
        private List<string> columnNames;

        public AuditTab(string title, string table) : base(title)
        {
            
            TableName = table;
            totalRowCount = TotalRowCount(); //do this to "cache" the total row count. It can't change once this has loaded, anyway.

            //TODO: look at shifting some of this to load
            if (totalRowCount > 0)
            {
                InitialiseDataGridView();
                Page = 1;
                GoToPage(Page);
                SetColumnNames();
            }
            else
            {
                NoRecordsToShowPanel noRecordsPanel = new NoRecordsToShowPanel();
                noRecordsPanel.Dock = DockStyle.Fill; //TODO: make sure the user control has this property set instead (the panel does, but not the underlying control).
                Controls.Add(noRecordsPanel);
            }
        }

        private void InitialiseDataGridView()
        {
            AuditLogGrid = new DataGridView();
            AuditLogGrid.AllowUserToAddRows = false;
            AuditLogGrid.AllowUserToDeleteRows = false;
            AuditLogGrid.Dock = DockStyle.Fill;
            AuditLogGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            AuditLogGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            AuditLogGrid.ColumnAdded += AuditLogGrid_ColumnAdded;
            AuditLogGrid.RowEnter += AuditLogGrid_RowEnter;
            AuditLogGrid.CellClick += AuditLogGrid_CellClick;
            Controls.Add(AuditLogGrid);
        }

        private void SetColumnNames()
        {
            columnNames = Table.Columns.Cast<DataColumn>()
                                 .Select(x => x.ColumnName)
                                 .ToList();

            columnNames.Remove("id");
            columnNames.Remove("print");
        }

        private string BuildQueryString(string pattern)
        {
            StringBuilder sb = new StringBuilder();
            string lastItem = columnNames.Last();
            string or = "OR";

            foreach (string item in columnNames)
            {
                if (item == lastItem)
                    or = "";

                sb.Append($"{item} LIKE '%{pattern}%' {or} ");
            }

           return sb.ToString();

        }


        //TODO: This only deals with the page user is on. (that is, the top _n_ rows)
        public void Search(string pattern)
        {
            DataTable data = null;
            DataRow[] dataRows = Table.Select(BuildQueryString(pattern));
            if (dataRows.Count() > 0) //can't copy to dataTable if there are no DataRows
            {
                data = dataRows.CopyToDataTable();
            }
            PopulateGrid(data);
        }


        private void AuditLogGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Don't want this to execute when the column header is clicked (OOB)
            if (e.RowIndex < 0)
                return;

            if (AuditLogGrid.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewCheckBoxCell)
            {
                DataGridViewCheckBoxCell column = AuditLogGrid.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewCheckBoxCell;
                if (column.Value != null)
                {
                    bool isChecked = (bool)column.Value;
                    string id = AuditLogGrid.Rows[e.RowIndex].Cells["id"].Value.ToString();
                    DatabaseHandler db = new DatabaseHandler();
                    string query = $"UPDATE {TableName} SET print = '{(!isChecked)}' WHERE id='{id}'";
                    db.ExecuteNonQuery(query); //TODO: Perhaps place an Update method in the db handler   
                }
            }
        }
        /// <summary>
        /// Gets the number of pages as an integer of the DataTable
        /// </summary>
        public int NumberOfPages
        {
            get
            {
                int rowCount = totalRowCount;
                int numPages = rowCount / MaxPages;
                if (rowCount % MaxPages > 0)
                {
                    numPages++;
                }
                return numPages;
            }
        }

        /// <summary>
        /// Gets the number of rows for this particular tab in the DataGridView
        /// </summary>
        private int TotalRowCount()
        {
            DatabaseHandler db = new DatabaseHandler();
            int count = db.GetTotalRowsFromTable(TableName);
            return count;
        }

        private void AuditLogGrid_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            Dictionary<string, string> rowCells = new Dictionary<string, string>();
            int cellCount = AuditLogGrid.Rows[e.RowIndex].Cells.Count;
            for (int i = 0; i < cellCount; i++)
            {
                rowCells.Add(AuditLogGrid.Columns[i].Name, AuditLogGrid.Rows[e.RowIndex].Cells[i].Value.ToString());
            }

            ExtendedRowEnterEventArgs eventArgs = new ExtendedRowEnterEventArgs(e, rowCells);
            RowEntered?.Invoke(this, eventArgs);
        }

        private void AuditLogGrid_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            if (e.Column is DataGridViewColumn)
            {
                DataGridViewColumn column = e.Column as DataGridViewColumn;
                column.ReadOnly = true;
                if (column.Name == "print")
                {
                    column.ReadOnly = false;
                }
            }
        }


        public string PagesLeftDescription()
        {
            string desc = "";
            if (NumberOfPages > 0)
            {
                desc = $"Page {Page} of {NumberOfPages}";
            }
            else
            {
                desc = $"No records";
            }
            return desc;
        }


        public bool CanGoToNextPage()
        {
            return Page < NumberOfPages;
        }

        public bool CanGoToPreviousPage()
        {
            return Page > 1;
        }

        public void NextPage()
        {
            if (CanGoToNextPage())
                Page++;

            GoToPage(Page);
        }

        public void PreviousPage()
        {
            if (CanGoToPreviousPage())
                Page--;

            GoToPage(Page);
        }

        public void FirstPage()
        {
            Page = 1;
            GoToPage(Page);
        }

        public void LastPage()
        {
            Page = NumberOfPages;
            GoToPage(Page);
        }

        private void GoToPage(int page)
        {
            DatabaseHandler db = new DatabaseHandler();
            Table = db.GetDataTable(TableName, page);
            PopulateGrid(Table);
        }


        public void PopulateGrid(DataTable dataTable)
        {
            AuditLogGrid.DataSource = dataTable;
        }

    }
}
