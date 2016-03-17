using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OSIRT.Extensions;
using OSIRT.Helpers;
using System.Windows.Media.Imaging;


namespace OSIRT.UI
{
    public partial class AuditLogForm : Form
    {
        public AuditLogForm()
        {
            InitializeComponent();
        }

        private void uiAuditLogForm_Load(object sender, EventArgs e)
        {
            AuditTabControlPanel auditTabControlPanel = new AuditTabControlPanel();
            uiAuditLogSplitContainer.Panel2.Controls.Add(auditTabControlPanel);

            AttachRowEventHandler(auditTabControlPanel);

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

            foreach (TextBox textBox in textBoxes)
            {
                if (textBox.Tag.ToString() == "dateAndTime")
                {
                    textBox.Text = rowDetails["date"] + " " + rowDetails["time"];
                    continue;
                }

                string value = "";
                if (rowDetails.TryGetValue(textBox.Tag.ToString(), out value))
                {
                    if(textBox.Tag.ToString() == "file_name")
                    {
                        DisplayFileIcon(rowDetails["file_name"]);
                    }
                    textBox.Text = value;
                }
                else
                {
                    textBox.Text = "";
                }
            }

        }


        private void DisplayFileIcon(string file)
        {
            //Icon icon = NativeMethods.GetFileIcon(file, NativeMethods.IconSize.Large, false);

            IconManager iconManager = new IconManager();
            BitmapSource icon = IconManager.GetLargeIcon(file, true, false);

            uiFilePreviewPictureBox.Image = OsirtHelper.GetBitmap(icon);
            //TODO: Display more details about this file.
            //In order to display more details, we require the relative path
        }

        private void AuditLogForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //re-update the database so print is all true again
            //perhaps wrap this in a wait window... "performing audit log closing functions... etc"

            Database.DatabaseHandler db = new Database.DatabaseHandler();
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
