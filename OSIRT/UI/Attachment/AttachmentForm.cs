using OSIRT.Enums;
using OSIRT.Helpers;
using OSIRT.Loggers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Imaging;

namespace OSIRT.UI.Attachment
{
    public partial class AttachmentForm : Form
    {
        private ToolTip tooltip = new ToolTip();
        private string hash = "";
        private string file = "";
        private string fileWithPath = "";
        private string note = "";

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

                uiAttachFileProgressPanel.Visible = false;
                fileWithPath = openFile.FileName;
                file = openFile.SafeFileName;
                hash =  OsirtHelper.GetFileHash(fileWithPath);
                tooltip.SetToolTip(uiFileDetailsLabel, "Hash: " + hash);
                uiFilePathTextBox.Text = fileWithPath;
                uiFileDetailsLabel.Text = $"{file}{Environment.NewLine}{OsirtHelper.GetHumanReadableFileSize(fileWithPath)}{Environment.NewLine}{TrimHash(hash)}";
                uiFileDetailsLabel.Visible = true;

                IconManager iconManager = new IconManager();
                BitmapSource icon = IconManager.GetLargeIcon(fileWithPath, false, false);
                uiFileIconPictureBox.Image = OsirtHelper.GetBitmap(icon);

            }
        }

        private string TrimHash(string hash)
        {
            return hash.Substring(0, 30) + "...";
        }

        private void AttachmentForm_Load(object sender, EventArgs e)
        {
            uiAttachFileProgressPanel.Visible = false;
           
            uiFileDetailsLabel.Text = "Click 'Browse...' to select a file to attach.";
        }

        private void uiAttachButton_Click(object sender, EventArgs e)
        {
            //TODO: Remove these mesageboxes
            if (string.IsNullOrWhiteSpace(uiNoteSpellBox.Text))
            {
                MessageBox.Show("Please enter a note.");
                return;
            }
            note = uiNoteSpellBox.Text;
            string destination = Path.Combine(Constants.ContainerLocation, Constants.Directories.GetSpecifiedCaseDirectory(Actions.Attachment), Path.GetFileName(fileWithPath));
            if(File.Exists(destination))
            {
                MessageBox.Show("File with this name already exists in the attachment folder.");
                return;
            }
            uiAttachFileProgressPanel.Visible = true;
            CopyFile(fileWithPath, destination);
        }

        private void CopyFile(string source, string destination)
        {
            WebClient client = new WebClient();
            client.DownloadProgressChanged += Client_DownloadProgressChanged;
            client.DownloadFileCompleted += Client_DownloadFileCompleted;
            client.DownloadFileAsync(new Uri(source), destination);
        }

        private void Client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            Logger.Log(new AttachmentsLog(Actions.Attachment, file, hash, note));
            uiFileCopyDetailLabel.Text = $"File successfully attached to case.";
            uiFilePathTextBox.Text = "";
            uiFileDetailsLabel.Text = "";
            uiNoteSpellBox.Text = "";
        }

        private void Client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            uiFileCopyingProgressBar.Value = e.ProgressPercentage;

        }
    }
}
