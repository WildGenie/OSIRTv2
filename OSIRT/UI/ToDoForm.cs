using OSIRT.Browser;
using OSIRT.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSIRT.UI
{
    public partial class ToDoForm : Form
    {
        public event EventHandler LinkClicked = delegate { };

        public ToDoForm()
        {
            InitializeComponent();
        }

        private void ToDoForm_Load(object sender, EventArgs e)
        {
            uiToDoUrlDataGridView.ColumnCount = 1;
            uiToDoUrlDataGridView.Columns[0].Name = "To Do URL";
            uiToDoUrlDataGridView.CellClick += UiToDoUrlDataGridView_CellClick;
            uiToDoUrlDataGridView.CellMouseEnter += UiToDoUrlDataGridView_CellMouseEnter;

            foreach (string url in OsirtHelper.toDo)
            {
                uiToDoUrlDataGridView.Rows.Add(url);
            }
            uiToDoUrlDataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }

        private void UiToDoUrlDataGridView_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;

            if (e.ColumnIndex == 0) uiToDoUrlDataGridView.Cursor = Cursors.Hand;
        }

        private void UiToDoUrlDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int col = e.ColumnIndex;

            if (col < 0) return;

            int rowIndex = e.RowIndex;
            DataGridViewRow row = uiToDoUrlDataGridView.Rows[rowIndex];
            string key = row.Cells[0].Value.ToString();
            LinkClicked?.Invoke(this, new TextEventArgs(key));
        }

        private void uiExportToDoButton_Click(object sender, EventArgs e)
        {
            if (!(OsirtHelper.toDo.Count > 0))
            {
                MessageBox.Show("No 'To Do' URLs to export", "No URLs to Export", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            SaveToDoList();
        }

        private void SaveToDoList()
        {
            string urls = "";
            foreach (string url in OsirtHelper.toDo)
            {
                urls += url + Environment.NewLine;
            }

            SaveFileDialog sfd = new SaveFileDialog
            {
                FileName = $"todolist_{DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss")}.txt",
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(sfd.FileName, urls);
                MessageBox.Show("'To Do' list exported", "Export Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
