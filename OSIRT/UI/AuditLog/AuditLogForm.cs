using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OSIRT.Extensions;
using OSIRT.Helpers;
using System.Windows.Media.Imaging;
using OSIRT.Enums;
using System.Diagnostics;
using System.IO;

namespace OSIRT.UI
{
    public partial class AuditLogForm : Form
    {

        private string filePath = "";
        private ToolTip tooltip = new ToolTip();

        public AuditLogForm()
        {
            InitializeComponent();
        }

        private void uiAuditLogForm_Load(object sender, EventArgs e)
        {
            AuditTabControlPanel auditTabControlPanel = new AuditTabControlPanel();
            uiAuditLogSplitContainer.Panel2.Controls.Add(auditTabControlPanel);

            AttachRowEventHandler(auditTabControlPanel);

            //TODO: don't want this to display or be clickable if there isn't a file in the previewer
            uiFilePreviewPictureBox.MouseClick += FilePreviewPictureBox_MouseClick;
            uiFilePreviewPictureBox.Cursor = Cursors.Hand;
            tooltip.SetToolTip(uiFilePreviewPictureBox, "Click to open file in the system's default application.");
        }


        private void FilePreviewPictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (filePath == "")
                return;

            try
            {
                Process.Start(filePath);
            }
            catch(FileNotFoundException)
            {
                MessageBox.Show($"Unable to open file ({filePath}) as the file is not found");
            }
            catch(System.ComponentModel.Win32Exception we)
            {
                MessageBox.Show($"Unable to open file ({filePath}). Reason: {we} ");
            }
        }

        private void AttachRowEventHandler(AuditTabControlPanel auditTabControlPanel)
        {
            var tabs = auditTabControlPanel.AuditTabs;

            foreach (AuditTab tab in tabs)
            {
                tab.RowEntered += AuditLogForm_RowEntered;
            }
        }

        private void AuditLogForm_RowEntered(object sender, EventArgs e)
        {

            ExtendedRowEnterEventArgs args = (ExtendedRowEnterEventArgs)e;
            Dictionary<string, string> rowDetails = args.RowDetails;
            var textBoxes = uiRowDetailsGroupBox.GetChildControls<TextBox>();

            uiDateAndTimeTextBox.Text = rowDetails["date"] + " " + rowDetails["time"];

            foreach (TextBox textBox in textBoxes)
            {
                if (textBox == uiDateAndTimeTextBox)
                    continue;
             

                string value = "";
                string key = textBox.Tag.ToString();
                if (rowDetails.TryGetValue(key, out value))
                {
                    if(textBox == uiFileNameTextBox)
                    {
                        CaseDirectory directory;
                        Enum.TryParse(rowDetails["action"], true, out directory);
                        DisplayFileIconWithFileSize(rowDetails["file_name"], directory);
                    }
                    else
                    {
                        ClearFilePreviewer();
                        filePath = "";
                    }
                    
                }
                textBox.Text = value;
            }
        }

        private void ClearFilePreviewer()
        {
            uiFilePreviewPictureBox.Image = null;
            uiFileDetailsLabel.Text = "";
        }




        private void DisplayFileIconWithFileSize(string file, CaseDirectory caseDirectory)
        {
            IconManager iconManager = new IconManager();
            BitmapSource icon = IconManager.GetLargeIcon(file, true, false);
            uiFilePreviewPictureBox.Image = OsirtHelper.GetBitmap(icon);
            string caseDir = Constants.Directories.GetSpecifiedCaseDirectory(caseDirectory);
            filePath = Path.Combine(Constants.ContainerLocation, caseDir, file);

            uiFileDetailsLabel.Text = $"File size: {OsirtHelper.GetHumanReadableFileSize(filePath)}. File type: {Path.GetExtension(filePath.ToUpperInvariant())}";
        }

        private void AuditLogForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //re-update the database so print is all true again
            //perhaps wrap this in a wait window... "performing audit log closing functions... etc"

            DatabaseHandler db = new DatabaseHandler();
            db.ExecuteNonQuery($"UPDATE webpage_log SET print = 'true'");
            db.ExecuteNonQuery($"UPDATE webpage_actions SET print = 'true'");
            db.ExecuteNonQuery($"UPDATE osirt_actions SET print = 'true'");
            db.ExecuteNonQuery($"UPDATE attachments SET print = 'true'");
            //can't UPDATE multiple tables... look into transactions:
            //http://stackoverflow.com/questions/2044467/how-to-update-two-tables-in-one-statement-in-sql-server-2005
            //http://www.jokecamp.com/blog/make-your-sqlite-bulk-inserts-very-fast-in-c/



        }
    }
}
