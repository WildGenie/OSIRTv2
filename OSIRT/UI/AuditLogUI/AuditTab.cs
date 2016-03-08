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
            AuditLogGrid.Dock = DockStyle.Fill;

      
            Database.DatabaseHandler db = new Database.DatabaseHandler();
            DataTable dataTable = db.GetDataTable(table);
            PopulateGrid(dataTable);

            Controls.Add(AuditLogGrid);

        }

        //TODO: For future to populate the gridview... 
        public void PopulateGrid(DataTable dataTable)
        {
            AuditLogGrid.DataSource = dataTable;
            
        }

    }
}
