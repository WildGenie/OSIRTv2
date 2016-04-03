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
using OSIRT.UI.AuditLog;

namespace OSIRT.UI
{
    public partial class SearchPanel : UserControl
    {
        public delegate void EventHandler(object sender, SearchCompletedEventArgs args);
        public event EventHandler SearchCompleted = delegate { };
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

            Debug.WriteLine("TABLE TO SEARCH: " + tableToSearch);
            Debug.WriteLine("SEARCH TEXT: " + searchText);

            DataTable table = AuditLogSearcher.Search(tableToSearch, searchText);
            SearchCompleted(this, new SearchCompletedEventArgs(table));




            //grid view = table

            //remove temp search panel
            //add data grid view.
            //populate datagridview



        }


   
    }
}
