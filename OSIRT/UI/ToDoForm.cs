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
        public ToDoForm()
        {
            InitializeComponent();
        }

        private void ToDoForm_Load(object sender, EventArgs e)
        {
            uiToDoUrlDataGridView.ColumnCount = 1;
            uiToDoUrlDataGridView.Columns[0].Name = "To Do URL";

            foreach (string url in OsirtHelper.toDo)
            {
                uiToDoUrlDataGridView.Rows.Add(url);
            }
            uiToDoUrlDataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
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
