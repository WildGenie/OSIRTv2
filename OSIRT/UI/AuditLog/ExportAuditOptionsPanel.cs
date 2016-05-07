using System;
using System.Windows.Forms;
using System.Linq;
using System.Collections;
using OSIRT.Database;
using OSIRT.Helpers;
using OSIRT.Extensions;
using System.Diagnostics;
using System.Collections.Generic;
using System.IO;
using OSIRT.Loggers;
using System.Data;
using System.Text;
using System.Globalization;

namespace OSIRT.UI.AuditLog
{
    public partial class ExportAuditOptionsPanel : UserControl
    {

        public string ExportPath { get; private set; }
        public string GSCP { get; private set; }


        public ExportAuditOptionsPanel()
        {
            InitializeComponent();
        }

        private void ExportAuditOptions_Load(object sender, EventArgs e)
        {
            ToggleExportFileButtons(false);
            GSCP = "";
        }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            EnableTablesToPrint();
            Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
        }

        private void EnableTablesToPrint()
        {
            DatabaseHandler dbHandler = new DatabaseHandler();
            var checkboxes = uiReportSelectionGroupBox.GetChildControls<CheckBox>();
            foreach (CheckBox cb in checkboxes)
            {
                if (dbHandler.TableIsEmpty(cb.Tag.ToString()))
                {
                    cb.Enabled = false;
                    cb.Checked = false;
                }
            }
        }

        private IEnumerable<Tuple<string, string>> GetHtml()
        {
            foreach (string table in GetSelectedTables())
            {
                string save = HtmlHelper.GetFormattedPage(table, ExportPath, GSCP, true);
                yield return Tuple.Create(table, save);
            }
        }

        public List<string> GetSelectedTables()
        {
            List<string> selectedTables = new List<string>();
            var checkboxes = uiReportSelectionGroupBox.GetChildControls<CheckBox>();
            foreach (CheckBox cb in checkboxes)
            {
                if (!cb.Checked) continue;

                selectedTables.Add(cb.Tag.ToString());
            }
            return selectedTables;
        }

        private void uiToggleCheckedButton_Click(object sender, EventArgs e)
        {
        }

        private void uiExportAsHtmlButton_Click(object sender, EventArgs e)
        {

            //TODO: working on adding nav for html report.
            //This can probably go in htmlhelper class
            StringBuilder navBuilder = new StringBuilder();
            navBuilder.Append("<ul>");
            foreach (string table in GetSelectedTables())
            {
                navBuilder.Append($"<li><a href={table}.html>{table}</a></li>");
            }
            navBuilder.Append("</ul>");


            foreach (var value in GetHtml())
            {
                string savePath = Path.Combine(ExportPath, Constants.ReportContainerName, $"{value.Item1}.html");
                string page = value.Item2;
                File.WriteAllText(savePath, page);
            }

            string hash = OsirtHelper.CreateHashForFolder(Path.Combine(ExportPath, Constants.ReportContainerName));
            Logger.Log(new OsirtActionsLog(Enums.Actions.Report, hash, Constants.ReportContainerName));
        }

        private DataTable GetMergedDataTable()
        {
            DatabaseHandler db = new DatabaseHandler();
            DataTable merged = new DataTable();
            foreach (string table in GetSelectedTables())
            {
                string columns = DatabaseTableHelper.GetTableColumns(table);
                DataTable dt = db.GetRowsFromColumns(table: table, columns: columns);
                merged.Merge(dt, true, MissingSchemaAction.Add);
            }
            merged.TableName = "merged";
            DataView view = new DataView(merged);
            view.Sort = "date asc, time asc";
            DataTable sortedTable = view.ToTable();
            return sortedTable;
        }



        private void uiExportAsPdfButton_Click(object sender, EventArgs e)
        {
            string page = DatatableToHtml.ConvertToHtml(GetMergedDataTable(), ExportPath);
            string save = HtmlHelper.ReplaceReportDetails(page, GSCP, false);

            HtmLtoPdf.SaveHtmltoPdf(save, "audit log", Path.Combine(ExportPath, Constants.ReportContainerName, Constants.PdfReportName));
            string hash = OsirtHelper.CreateHashForFolder(Path.Combine(ExportPath, Constants.ReportContainerName));
            Logger.Log(new OsirtActionsLog(Enums.Actions.Report, hash, Constants.ReportContainerName));
        }

        private void uiBrowseButton_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                DialogResult result = folderDialog.ShowDialog();
                if (result != DialogResult.OK)
                    return;

                ExportPath = folderDialog.SelectedPath;
                uiPathTextBox.Text = ExportPath;
            }
        }

        private void ToggleExportFileButtons(bool enabled)
        {
            uiExportAsPdfButton.Enabled = enabled;
            uiExportAsHtmlButton.Enabled = enabled;
            uiExportAsCaseFileButton.Enabled = enabled;
    
        }

        private void uiPathTextBox_TextChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(ExportPath))
                ToggleExportFileButtons(true);
        }

        private void uiExportAsHtmlButton_MouseHover(object sender, EventArgs e)
        {
            uiReportExportHelpLabel.Text = "Export report as HTML";
        }

        private void uiExportAsPdfButton_MouseHover(object sender, EventArgs e)
        {
            uiReportExportHelpLabel.Text = "Export report as PDF";
        }

        private void uiExportAsCaseFileButton_MouseHover(object sender, EventArgs e)
        {
            uiReportExportHelpLabel.Text = "Export report as OSRR file";
        }

        private void uiDisplayImagesCheckBox_CheckedChanged(object sender, EventArgs e)
        {

            UserSettings settings = UserSettings.Load();
            settings.PrintImagesInReport = uiDisplayImagesCheckBox.Checked;
            settings.Save();
        }

        private void uiPrintNotesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            UserSettings settings = UserSettings.Load();
            settings.PrintAuditNotes = uiPrintNotesCheckBox.Checked;
            settings.Save();
        }

        private void uiDisplayVideosCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            UserSettings settings = UserSettings.Load();
            settings.ShowVideosInReport = uiDisplayVideosCheckBox.Checked;
            settings.Save();
        }

        private void uiGSCPComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            GSCP = uiGSCPComboBox.Text;
        }
    }
}
