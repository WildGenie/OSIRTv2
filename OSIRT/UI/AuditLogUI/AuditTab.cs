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

        public AuditTab(string title, string table) : base(title) 
        {
            AuditLogGrid = new DataGridView();
            //AuditLogGrid.ReadOnly = true;
            AuditLogGrid.AllowUserToAddRows = false;
            AuditLogGrid.AllowUserToDeleteRows = false;
            AuditLogGrid.Dock = DockStyle.Fill;
            //AuditLogGrid.ColumnAdded += AuditLogGrid_ColumnAdded;
            AuditLogGrid.DataBindingComplete += AuditLogGrid_DataBindingComplete;


            Database.DatabaseHandler db = new Database.DatabaseHandler();
            DataTable dataTable = db.GetDataTable(table);
            PopulateGrid(dataTable);

            Controls.Add(AuditLogGrid);

            


        }

        private void AuditLogGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewColumn column in AuditLogGrid.Columns)
            {
                column.ReadOnly = true;
                if (column.Name == "print")
                {
                    column.ReadOnly = false;
                }
            }
        }

        private void AuditLogGrid_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            if (e.Column is DataGridViewColumn)
            {
                DataGridViewColumn column = e.Column as DataGridViewColumn;
                column.ReadOnly = true;
                if (column.Name == "print")
                {
                    Debug.WriteLine("IN HERRRRRRRRRRRRRRRRRRRE: COL NAME: " + column.Name);
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
