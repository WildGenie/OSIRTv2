using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OSIRT.Helpers;
using System.Diagnostics;

namespace OSIRT.UI
{
    public partial class SearchPanel : UserControl
    {
        public event EventHandler SearchCompleted;
        private Dictionary<string, string> tabs;

        public SearchPanel(Dictionary<string, string> tabs)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            this.tabs = tabs;
        }

        private void SearchPanel_Load(object sender, EventArgs e)
        {
            uiTabletoSearchComboBox.DataSource = new BindingSource(tabs, null);
            uiTabletoSearchComboBox.DisplayMember = "Key";
            uiTabletoSearchComboBox.ValueMember = "Value";
        }

        private void uiSearchButton_Click(object sender, EventArgs e)
        {
            //get text from textbox
            string searchText = uiSearchTextTextBox.Text;
            string tableToSearch = uiTabletoSearchComboBox.SelectedValue.ToString();
            DatabaseHandler dbHandler = new DatabaseHandler();
            DataTable table = dbHandler.GetAllRows(tableToSearch); //limit this using pages?
            SetColumnNames(table);
            DataRow[] dataRows = table.Select(BuildQueryString(searchText));

            if (dataRows.Count() > 0) //can't copy to dataTable if there are no DataRows
            {
                table = dataRows.CopyToDataTable();
            }
            
            //grid view = table

            //remove temp search panel
            //add data grid view.
            //populate datagridview

            

        }


        //TODO: DUPLICATION HERE AND AUDIT TAB. MOVE THIS INTO A "SEARCH" CLASS.

        //Get all column names that aren't ID or print
        //This is for when we do a text search, we only want
        //rows the user will understand


        List<string> columnNames = new List<string>();
        private void SetColumnNames(DataTable Table)
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
    }
}
