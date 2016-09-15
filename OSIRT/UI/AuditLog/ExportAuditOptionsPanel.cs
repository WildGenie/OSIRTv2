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
using Jacksonsoft;
using System.ComponentModel;
using System.Threading;

namespace OSIRT.UI.AuditLog
{
    public partial class ExportAuditOptionsPanel : UserControl
    {

        public string ExportPath { get; private set; }
        public string ReportContainerName { get; private set; }
        public string GSCP { get; private set; }
        private bool openReport = true;
   
        public ExportAuditOptionsPanel()
        {
            InitializeComponent();
        }

        private void ExportAuditOptions_Load(object sender, EventArgs e)
        {
            ToggleExportFileButtons(false);
            uiGSCPComboBox.SelectedIndex = 0;
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
                string table = cb.Tag.ToString();
                if (dbHandler.TableIsEmpty(table))
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
                string save = HtmlHelper.GetFormattedPage(table, ExportPath, ReportContainerName, GSCP, true);
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



        private void ExportAsPdf()
        {
            string page = DatatableToHtml.ConvertToHtml(GetMergedDataTable(), ExportPath, ReportContainerName);
            string save = HtmlHelper.ReplaceReportDetails(page, GSCP, false);
            HtmLtoPdf.SaveHtmltoPdf(save, GSCP ,"audit log", Path.Combine(ExportPath, ReportContainerName, Constants.PdfReportName));
            string hash = OsirtHelper.CreateHashForFolder(Path.Combine(ExportPath, ReportContainerName));
            Logger.Log(new OsirtActionsLog(Enums.Actions.Report, hash, ReportContainerName));
            if (openReport)
                Process.Start(Path.Combine(ExportPath, ReportContainerName, Constants.PdfReportName));
        }

        private void EnableOptionsGroupboxes(bool enabled)
        {
            uiExportAsGroupBox.Enabled = enabled;
            uiReportOptionsGroupBox.Enabled = enabled;
            uiExportAsGroupBox.Enabled = enabled;
            uiReportSelectionGroupBox.Enabled = enabled;
            uiProgressGroupBox.Enabled = !enabled;
        }

        private void ExportAsHtml()
        {
            string navBar = HtmlHelper.GetHtmlNavBar(GetSelectedTables());
            foreach (var value in GetHtml())
            {
                string savePath = Path.Combine(ExportPath, ReportContainerName, $"{value.Item1}.html");
                string page = value.Item2.Replace("<%%NAV%%>", navBar);
                File.WriteAllText(savePath, page);
            }

            //combined
            string combined = DatatableToHtml.ConvertToHtml(GetMergedDataTable(), ExportPath, ReportContainerName);
            string save = HtmlHelper.ReplaceReportDetails(combined, GSCP, true);
            save = save.Replace("<%%NAV%%>", navBar);
            File.WriteAllText(Path.Combine(ExportPath, ReportContainerName, "combined.html"), save);
            Thread.Sleep(750);
            string hash = OsirtHelper.CreateHashForFolder(Path.Combine(ExportPath, ReportContainerName));
            Logger.Log(new OsirtActionsLog(Enums.Actions.Report, hash, ReportContainerName));
            if(openReport)
                Process.Start(Path.Combine(ExportPath, ReportContainerName, "combined.html"));
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

            //added
            if(uiMergeCaseNotesCheckBox.Checked)
            {
                DataTable dt = new DatabaseHandler().GetRowsFromColumns("case_notes", "", "date", "time", "note");
                merged.Merge(dt, true, MissingSchemaAction.Add);
            }

            //end ad

            merged.TableName = "merged";
            DataView view = new DataView(merged);
            view.Sort = "date asc, time asc";
            DataTable sortedTable = view.ToTable();
            return sortedTable;
        }

        private void RunWorker(Action method)
        {
            
            var backgroundWorker = new BackgroundWorker();
            uiProgressGroupBox.Show();
            backgroundWorker.DoWork += delegate
            {
                method.Invoke();
            };
            backgroundWorker.RunWorkerCompleted += delegate
            {
                uiProgressGroupBox.Hide();
                if(!openReport)
                    MessageBox.Show("Report successfully exported", "Report Exported", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };
            backgroundWorker.RunWorkerAsync();
        }

        private void uiExportAsHtmlButton_Click(object sender, EventArgs e)
        {
            ReportContainerName = Constants.ReportContainerName.Replace("%%dt%%", DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss"));
            if (ReportExists(ExportPath))
            {
                if (CanOverwriteReport())
                    RunWorker(ExportAsHtml);
            }
            else
            {
                RunWorker(ExportAsHtml);
            }
        }

        private void uiExportAsPdfButton_Click(object sender, EventArgs e)
        {
            ReportContainerName = Constants.ReportContainerName.Replace("%%dt%%", DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss"));
            if (ReportExists(ExportPath))
            {
                if (CanOverwriteReport())
                    RunWorker(ExportAsPdf);
            }
            else
            {
                RunWorker(ExportAsPdf);
            }
        }

        private bool ReportExists(string selectedPath)
        {
            return Directory.Exists(Path.Combine(selectedPath, ReportContainerName));
        }

        private bool CanOverwriteReport()
        {
            DialogResult overwrite = MessageBox.Show("A report for this case already exists at this location. Do you want to overwrite the existing report?", "Report Already Exists", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            return overwrite == DialogResult.Yes;
        }

        private void uiBrowseButton_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                DialogResult result = folderDialog.ShowDialog();
                if (result != DialogResult.OK)
                    return;

                string selectedPath = folderDialog.SelectedPath;
                ExportPath = selectedPath;
                Debug.WriteLine(ExportPath);
                uiPathTextBox.Text = ExportPath; //+ DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                ReportContainerName = Constants.ReportContainerName.Replace("%%dt%%", DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss"));

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
            uiReportExportHelpLabel.Text = $"Export report as CSV (spreadsheet friendly) file. {Environment.NewLine} Note: this only exports the audit log with no artefacts.";
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

        private void ExportAsCsv()
        {
            StringBuilder sb = new StringBuilder();
            DataTable dt = GetMergedDataTable();
            IEnumerable<string> columnNames = dt.Columns.Cast<DataColumn>().
                                              Select(column => column.ColumnName);
            sb.AppendLine(string.Join(",", columnNames));

            foreach (DataRow row in dt.Rows)
            {
                IEnumerable<string> fields = row.ItemArray.Select(field => field.ToString());
                sb.AppendLine(string.Join(",", fields));
            }

            string csvPath = Path.Combine(ExportPath, ReportContainerName + ".csv");
            File.WriteAllText(csvPath, sb.ToString());
            Logger.Log(new OsirtActionsLog(Enums.Actions.Report, OsirtHelper.GetFileHash(csvPath), ReportContainerName));
            if (openReport)
                Process.Start(csvPath);
        }

        private void uiExportAsCaseFileButton_Click(object sender, EventArgs e)
        {
            RunWorker(ExportAsCsv);
        }

        private void uiOpenReportCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            openReport = uiOpenReportCheckBox.Checked;
        }
    }
}
