using OSIRT.Database;
using OSIRT.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TuesPechkin;

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
            uiCaseNotesTextBox.Text = GetExistingCaseNotes();

        }

        private string GetExistingCaseNotes()
        {
            DataTable table = new DatabaseHandler().GetSpecifiedColumnsDataTable("case_notes", "date", "time", "note");
            StringBuilder stringBuilder = new StringBuilder();
            foreach (DataRow row in table.Rows)
            {
                foreach (DataColumn column in table.Columns)
                {
                    string cellValue = row[column].ToString();
                    string toAppend = column.ColumnName == "note" ? (Environment.NewLine + cellValue) : (cellValue + " ");
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

        }

        private void uiExportAsPDFToolStripButton_Click(object sender, EventArgs e)
        {



            //TODO: Put this PDF HTML to PDF creation in it's own class.
            //Singleton could work well, here.

            //File.WriteAllBytes(@"D:\hello.pdf", result);
            HTMLtoPDF.SaveHTMLToPDF("<p>example</p>", "Case Notes", @"D:/hello2.pdf");


        }
    }
}
