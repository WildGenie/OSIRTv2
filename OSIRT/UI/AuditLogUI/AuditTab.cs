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


            DatabaseHandler db = new DatabaseHandler();
            DataTable dataTable = db.GetDataTable(table);
            PopulateGrid(dataTable);

            Controls.Add(AuditLogGrid);

        


        }

        private void AuditLogGrid_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

            var collection = AuditLogGrid.Rows;

            //TODO: Trying to think of a sensible way to send this data back to the UI
            //Problems: Varying columns in each tab. How do you know which string belongs
            //in which textbox
            int cellCount = AuditLogGrid.Rows[e.RowIndex].Cells.Count;
            string[] rowDetails = new string[cellCount];
            for (int i = 0; i < cellCount; i++)
            {
                rowDetails[i] = AuditLogGrid.Rows[e.RowIndex].Cells[i].Value.ToString();
            }
            //string joinedRowDetails = string.Join(",", rowDetails);


            RowEntered?.Invoke(this, e);
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

        //TODO: For future to populate the gridview... 
        public void PopulateGrid(DataTable dataTable)
        {
            AuditLogGrid.DataSource = dataTable;
        }

    }
}
