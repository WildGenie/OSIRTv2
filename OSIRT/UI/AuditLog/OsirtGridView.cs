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

        public OsirtGridView()
        {
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
