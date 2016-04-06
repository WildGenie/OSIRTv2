using Jacksonsoft;
using OSIRT.Helpers;
using OSIRT.Loggers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OSIRT.Database;

namespace OSIRT.UI.CaseNotes
{
    //Icons free from: https://www.iconfinder.com/icons/64239/barsha_extension_file_pdf_icon#size=32
    public partial class CaseNotesForm : Form
    {
        public CaseNotesForm()
        {
            InitializeComponent();

        }

        private void CaseNotesForm_Load(object sender, EventArgs e)
        {
            uiOptionsToolStrip.ImageScalingSize = new Size(32, 32);
            uiOptionsToolStrip.Width = Width;
            uiEnteredNoteSpellBox.Select();
            uiCaseNotesTextBox.VisibleChanged += uiCaseNotesTextBox_VisibleChanged;
            uiCaseNotesTextBox.Text = GetExistingCaseNotes();

         
        }

        private void uiCaseNotesTextBox_VisibleChanged(object sender, EventArgs e)
        {
            if (uiCaseNotesTextBox.Visible)
            {
                uiCaseNotesTextBox.SelectionStart = uiCaseNotesTextBox.TextLength;
                uiCaseNotesTextBox.ScrollToCaret();
            }
        }

        private string GetExistingCaseNotes()
        {
            DataTable table = new DatabaseHandler().GetRowsFromColumns("case_notes", "date", "time", "note");
            StringBuilder stringBuilder = new StringBuilder();
            foreach (DataRow row in table.Rows)
            {
                foreach (DataColumn column in table.Columns)
                {
                    string cellValue = row[column].ToString();
                    string toAppend = column.ColumnName == "note" ? Environment.NewLine + cellValue : cellValue + " ";
                    stringBuilder.Append(toAppend);
                }
                stringBuilder.Append(Environment.NewLine + Environment.NewLine);
            }
            return stringBuilder.ToString();
        }

        private void uiAddNoteButton_Click(object sender, EventArgs e)
        {
            //DataTable table = new DatabaseHandler().GetSpecifiedColumnsDataTable("case_notes", "date", "time", "note");
            Dictionary<string, string> notes = new Dictionary<string, string>();
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            string time = DateTime.Now.ToString("HH:mm:ss");
            notes.Add("date", date);
            notes.Add("time", time);
            notes.Add("note", uiEnteredNoteSpellBox.Text);
            new DatabaseHandler().Insert("case_notes", notes);
            uiCaseNotesTextBox.AppendText($"{date}  {time}{Environment.NewLine}{uiEnteredNoteSpellBox.Text}{Environment.NewLine}{Environment.NewLine}");
            uiEnteredNoteSpellBox.ResetText();
            uiEnteredNoteSpellBox.Select();
        }

        private void uiExportAsPDFToolStripButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "PDF files|*.pdf";
            saveDialog.AddExtension = true;
            saveDialog.RestoreDirectory = true;

            if (saveDialog.ShowDialog() != DialogResult.OK)
                return;

            string file = saveDialog.FileName;
            WaitWindow.Show(CreatePDF, "Generating PDF. Please wait...", file);
            System.Diagnostics.Process.Start(file); //TODO: have as an option
        }

        private void CreatePDF(object sender, WaitWindowEventArgs e)
        {
            string path = e.Arguments[0].ToString();
            string html = CaseNotesToHtml.CreateHtml();
            HtmLtoPdf.SaveHtmltoPdf(html, "Case Notes", path);
            string hash = OsirtHelper.GetFileHash(path);
            Logger.Log(new OsirtActionsLog(Enums.Actions.CaseNotes, hash));
        }

        private void CaseNotesForm_Shown(object sender, EventArgs e)
        {
            uiCaseNotesTextBox.SelectionStart = uiCaseNotesTextBox.Text.Length;
            uiCaseNotesTextBox.ScrollToCaret();
        }
    }
}
