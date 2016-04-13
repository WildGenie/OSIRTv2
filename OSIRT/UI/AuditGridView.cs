using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using OSIRT.Database;

namespace OSIRT.UI
{
    public class AuditGridView : DataGridView
    {

        public event EventHandler RowEntered;
        private string TableName { get; }
        public DataTable Table { get; private set; }
        public int Page { get; private set; }
        public int MaxPages => UserSettings.Load().NumberOfRowsPerPage;
        private readonly int totalRowCount;


        public AuditGridView(string table)
            : this(new DatabaseHandler().GetAllRows(table))
        { }
     

        public AuditGridView(DataTable table)
        {
            TableName = table.TableName;
            totalRowCount = TotalRowCount();
            Page = 1;
            GoToPage(Page);
            InitialiseDataGridView();
        }

        private void PopulateGrid(DataTable dataTable)
        {
            DataSource = dataTable;
        }

        private void InitialiseDataGridView()
        {
            AllowUserToAddRows = false;
            AllowUserToDeleteRows = false;
            Dock = DockStyle.Fill;
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;

            ColumnAdded += AuditGridView_ColumnAdded;
            RowEnter += AuditGridView_RowEnter;
            CellClick += AuditLogGrid_CellClick;
        }

        private void AuditGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            Dictionary<string, string> rowCells = new Dictionary<string, string>();
            int cellCount = Rows[e.RowIndex].Cells.Count;
            for (int i = 0; i < cellCount; i++)
            {
                rowCells.Add(Columns[i].Name, Rows[e.RowIndex].Cells[i].Value.ToString());
            }

            ExtendedRowEnterEventArgs eventArgs = new ExtendedRowEnterEventArgs(e, rowCells);
            RowEntered?.Invoke(this, eventArgs);
        }


        //Makes the print column selectable, and keeps other columns readonly
        private void AuditGridView_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            DataGridViewColumn column = e.Column;
            column.ReadOnly = true;
            if (column.Name == "print")
            {
                column.ReadOnly = false;
            }

        }

        private void AuditLogGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Don't want this to execute when the column header/row is clicked (OOB)
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            if (Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewCheckBoxCell)
            {
                DataGridViewCheckBoxCell column = (DataGridViewCheckBoxCell) Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (column.Value != null)
                {
                    bool isChecked = (bool)column.Value;
                    string id = Rows[e.RowIndex].Cells["id"].Value.ToString();
                    string query = $"UPDATE {TableName} SET print = '{(!isChecked)}' WHERE id='{id}'";
                    DatabaseHandler db = new DatabaseHandler();
                    db.ExecuteNonQuery(query); //TODO: Place an Update method in the db handler   
                }
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

        public int TotalRows => totalRowCount;

        //PAGINATION

        ///// <summary>
        ///// Gets the number of pages as an integer of the DataTable
        ///// </summary>
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

        public string PagesLeftDescription()
        {
            var desc = NumberOfPages > 0 ? $"Page {Page} of {NumberOfPages}" : "No records";
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
            Table = db.GetPaginatedDataTable(TableName, page);
            PopulateGrid(Table);
        }




    }
}
