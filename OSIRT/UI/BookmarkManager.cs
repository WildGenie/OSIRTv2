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

namespace OSIRT.UI
{
    public partial class BookmarkManager : Form
    {

        public event EventHandler LinkClicked = delegate { };
        public event EventHandler BookmarkRemoved = delegate { };

        public BookmarkManager()
        {
            InitializeComponent();
        }

        private void BookmarkManager_Load(object sender, EventArgs e)
        {
            uiBookmarksDataGridView.AutoGenerateColumns = true;

            var favs = OsirtHelper.Favourites;

            uiBookmarksDataGridView.ColumnCount = 3;
            uiBookmarksDataGridView.Columns[0].Name = "Remove?";
            uiBookmarksDataGridView.Columns[1].Name = "Title";
            uiBookmarksDataGridView.Columns[2].Name = "URL";

            uiBookmarksDataGridView.Columns[0].DefaultCellStyle.ForeColor = Color.Red;

            foreach (var f in favs)
            {
                uiBookmarksDataGridView.Rows.Add("Remove", f.Key, f.Value);
            }
            uiBookmarksDataGridView.Refresh();
            uiBookmarksDataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }

        private void uiBookmarksDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int col = e.ColumnIndex;

            if (col < 0) return;

            int rowIndex = e.RowIndex;
            DataGridViewRow row = uiBookmarksDataGridView.Rows[rowIndex];
            string key = "";

            switch (col)
            {
                case 0:
                    DialogResult dr = MessageBox.Show("This will remove this bookmark. Are you sure?", "Remove Bookmark?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (dr != DialogResult.Yes) return;
                    key = row.Cells[1].Value.ToString();
                    OsirtHelper.Favourites.Remove(key);
                    uiBookmarksDataGridView.Rows.Remove(row);
                    uiBookmarksDataGridView.Update();
                    uiBookmarksDataGridView.Refresh();
                    OsirtHelper.WriteFavourites();
                    BookmarkRemoved?.Invoke(this, EventArgs.Empty);
                    break;
                case 2:
                    //click link
                    key = row.Cells[2].Value.ToString();
                    LinkClicked?.Invoke(this, new TextEventArgs(key));
                    break;
            }
         

         


        }

        private void uiBookmarksDataGridView_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;

            if (e.ColumnIndex == 0) uiBookmarksDataGridView.Cursor = Cursors.Hand;
            else uiBookmarksDataGridView.Cursor = Cursors.Arrow;

        }
    }
}
