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
using System.Windows.Media.Imaging;

namespace OSIRT.UI.Attachment
{
    public partial class AttachmentForm : Form
    {
        private ToolTip tooltip = new ToolTip();

        public AttachmentForm()
        {
            InitializeComponent();
        }

        private void uiBrowseButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFile = new OpenFileDialog())
            {
                DialogResult result = openFile.ShowDialog();
                if (result != DialogResult.OK)
                    return;

                string fileNameWithPath = openFile.FileName;
                string fileName = openFile.SafeFileName;
                string hash =  OsirtHelper.GetFileHash(fileNameWithPath);
                tooltip.SetToolTip(uiFileDetailsLabel, "Hash: " + hash);
                uiFilePathTextBox.Text = fileNameWithPath;
                uiFileDetailsLabel.Text = $"{fileName}{Environment.NewLine}{OsirtHelper.GetHumanReadableFileSize(fileNameWithPath)}{Environment.NewLine}{TrimHash(hash)}";

                IconManager iconManager = new IconManager();
                BitmapSource icon = IconManager.GetLargeIcon(fileNameWithPath, false, false);
                uiFileIconPictureBox.Image = OsirtHelper.GetBitmap(icon);

            }
        }

        private string TrimHash(string hash)
        {
            return hash.Substring(0, 30) + "...";
        }

        private void AttachmentForm_Load(object sender, EventArgs e)
        {
           
        }
    }
}
