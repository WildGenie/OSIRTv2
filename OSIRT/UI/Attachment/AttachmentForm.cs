using OSIRT.Enums;
using OSIRT.Helpers;
using OSIRT.Loggers;
using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using OSIRT.Resources;

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

                UpdateFileDetailsUi();
                DisplayIcon();

            }
        }

        private void UpdateFileDetailsUi()
        {
            tooltip.SetToolTip(uiFileDetailsLabel, "Hash: " + hash);
            uiFilePathTextBox.Text = fileWithPath;
            uiFileDetailsLabel.Text = $"{file}{Environment.NewLine}{OsirtHelper.GetHumanReadableFileSize(fileWithPath)}{Environment.NewLine}{TrimHash(hash)}";
            uiFileDetailsLabel.Visible = true;
        }

        private void DisplayIcon()
        {
            BitmapSource icon = IconManager.GetLargeIcon(fileWithPath, false, false);
            uiFileIconPictureBox.Image = OsirtHelper.GetBitmap(icon);
        }

        private string TrimHash(string hashToTrim)
        {
            return hashToTrim.Substring(0, 30) + "...";
        }

        private void AttachmentForm_Load(object sender, EventArgs e)
        {
            uiAttachFileProgressPanel.Visible = false;
           
            uiFileDetailsLabel.Text = "Click 'Browse...' to select a file to attach.";
            uiFileIconPictureBox.SizeMode = PictureBoxSizeMode.CenterImage;


            //for attachment drag and drop.. possible feature
            //AllowDrop = true;
            //DragEnter += AttachmentForm_DragEnter;
            //DragDrop += AttachmentForm_DragDrop;
        }

        private void AttachmentForm_DragDrop(object sender, DragEventArgs e)
        {
            //string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            ////foreach (string file in files) Console.WriteLine(file);

            //if (string.IsNullOrWhiteSpace(uiNoteSpellBox.Text))
            //{
            //    MessageBox.Show(strings.Please_enter_a_note);
            //    return;
            //}
            //note = uiNoteSpellBox.Text;
            //string destination = Path.Combine(Constants.ContainerLocation, Constants.Directories.GetSpecifiedCaseDirectory(Actions.Attachment), Path.GetFileName(fileWithPath));
            //if (File.Exists(destination))
            //{
            //    MessageBox.Show(strings.File_with_this_name_already_exists_in_the_attachment_folder);
            //    return;
            //}

            //uiAttachFileProgressPanel.Visible = true;
            //uiCancelButton.Enabled = false;
            //CopyFile(files[0], destination);
        }

        private void AttachmentForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void uiAttachButton_Click(object sender, EventArgs e)
        {
            //TODO: Remove these mesageboxes
            if (string.IsNullOrWhiteSpace(uiNoteSpellBox.Text))
            {
                MessageBox.Show(strings.Please_enter_a_note);
                return;
            }
            note = uiNoteSpellBox.Text;
            string destination = Path.Combine(Constants.ContainerLocation, Constants.Directories.GetSpecifiedCaseDirectory(Actions.Attachment), Path.GetFileName(fileWithPath));
            if(File.Exists(destination))
            {
                MessageBox.Show(strings.File_with_this_name_already_exists_in_the_attachment_folder);
                return;
            }



            uiAttachFileProgressPanel.Visible = true;
            uiCancelButton.Enabled = false;
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
            uiFileCopyDetailLabel.Text = strings.AttacFile_successfully_attached_to_case_;
            uiAddANotherFileLable.Text = $"Click 'Browse...' to select another file{Environment.NewLine}or 'Close' to close this window.";
            uiFilePathTextBox.Text = "";
            uiFileDetailsLabel.Text = "";
            uiNoteSpellBox.Text = "";
            uiFileIconPictureBox.Image = Properties.Resources.tick_32;
            uiCancelButton.Enabled = true;
        }

        private void Client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            uiFileCopyingProgressBar.Value = e.ProgressPercentage;
        }

        private void uiCancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
