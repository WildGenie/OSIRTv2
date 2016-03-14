using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OSIRT.Extensions;
using OSIRT.Helpers;
using System.Windows.Media.Imaging;
using System.Drawing.Imaging;
using System.Windows;

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
            //TODO: Tidy up code in NativeMethods and the GetBitmap method (below) - move to helper class.
        }

        


    }
}
