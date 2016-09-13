using OSIRT.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSIRT.UI.AuditLog
{
    public class OsirtGridView : DataGridView
    {

        public event EventHandler RowEntered;
        public string table;

        public OsirtGridView()
        {
            InitialiseDataGridView();
        }

        public OsirtGridView(string table)
        {
            this.table = table;
            InitialiseDataGridView();
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
            CellClick += OsirtGridView_CellClick;
           
        }

        protected virtual void OsirtGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Don't want this to execute when the column header/row is clicked (OOB)
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            if (Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewCheckBoxCell)
            {
                DataGridViewCheckBoxCell column = (DataGridViewCheckBoxCell)Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (column.Value != null)
                {
                    bool isChecked = (bool)column.Value;
                    string id = Rows[e.RowIndex].Cells["id"].Value.ToString();
                    string query = $"UPDATE {table} SET print = '{(!isChecked)}' WHERE id='{id}'";
                    System.Diagnostics.Debug.WriteLine("QUERY: " + query);
                    DatabaseHandler db = new DatabaseHandler();
                    db.ExecuteNonQuery(query); //TODO: Place an Update method in the db handler   
                }
            }
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



    }




}
