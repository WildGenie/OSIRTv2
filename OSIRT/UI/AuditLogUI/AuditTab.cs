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
        public string Table { get; private set; }

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
            Table = table;


            DatabaseHandler db = new DatabaseHandler();
            DataTable dataTable = db.GetDataTable(table, 1);
            PopulateGrid(dataTable);

            Controls.Add(AuditLogGrid);
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

        public void NextPage(int page)
        {
            DatabaseHandler db = new DatabaseHandler();
            DataTable dataTable = db.GetDataTable(Table, page);
            PopulateGrid(dataTable);
        }

       
        public void PopulateGrid(DataTable dataTable)
        {
            AuditLogGrid.DataSource = dataTable;
        }

    }
}
