using OSIRT.Browser;
using OSIRT.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSIRT.UI.HistoryViewer
{
    public partial class HistoryViewForm : Form
    {
        public event EventHandler HistoryLinkClicked;


        public HistoryViewForm()
        {
            InitializeComponent();
        }

        private void HistoryViewForm_Load(object sender, EventArgs e)
        {
            var history = new BindingList<History>(OsirtHelper.history);
            uiHistoryDataGridView.DataSource = history;
            uiHistoryDataGridView.CellClick += UiHistoryDataGridView_CellClick;
            TidyColumns();

        }

        private void UiHistoryDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int col = e.ColumnIndex;
            if (col < 0 || e.RowIndex < 0) return;

            int rowIndex = e.RowIndex;
            DataGridViewRow row = uiHistoryDataGridView.Rows[rowIndex];
            string key = "";

            if(col == 2)
            {
                key = row.Cells[2].Value.ToString();
                HistoryLinkClicked?.Invoke(this, new TextEventArgs(key));
            }

      
        }

        private void TidyColumns()
        {
            uiHistoryDataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            uiHistoryDataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            uiHistoryDataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            uiHistoryDataGridView.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;

        }

        private void uiSearchTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            string s = uiSearchTextBox.Text;
            uiHistoryDataGridView.DataSource = new BindingList<History>(OsirtHelper.history.Where(m => m.Url.Contains(s)  || m.Date.Contains(s) || m.Time.Contains(s)).ToList());
        }

        private void uiHistoryDataGridView_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
            {
                return;
            }
            var dataGridView = (sender as DataGridView);
            //Check the condition as per the requirement casting the cell value to the appropriate type
            if (e.ColumnIndex == 2)
            {
                dataGridView.Cursor = Cursors.Hand;
            }
            else
            {
                dataGridView.Cursor = Cursors.Default;
            }
        }
    }
}
