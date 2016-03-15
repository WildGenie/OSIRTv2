using OSIRT.Database;
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
        public int MaxPages { get { return 25; } }
        private int totalRowCount = 0;

        public AuditTab(string title, string table) : base(title) 
        {
            AuditLogGrid = new DataGridView();
            AuditLogGrid.AllowUserToAddRows = false;
            AuditLogGrid.AllowUserToDeleteRows = false;
            AuditLogGrid.Dock = DockStyle.Fill;
            AuditLogGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            AuditLogGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            AuditLogGrid.ColumnAdded += AuditLogGrid_ColumnAdded;
            AuditLogGrid.RowEnter += AuditLogGrid_RowEnter;
            TableName = table;

            //TODO: Refactor this, DRY.
            DatabaseHandler db = new DatabaseHandler();
            Table = db.GetDataTable(table, 1);
            PopulateGrid(Table);

            Controls.Add(AuditLogGrid);

            totalRowCount = TotalRowCount();
            Page = 1;
        }


        public int NumberOfPages
        {
            get { return TotalRowCount() / MaxPages; }
        }

        /// <summary>
        /// Gets the number of rows for this particular tab in the DataGridView
        /// </summary>
        public int TotalRowCount()
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

        

        public string PageDescription()
        {
            return $"Page {Page} of {NumberOfPages}";
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
