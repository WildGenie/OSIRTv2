using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using OSIRT.Extensions;
using OSIRT.Enums;
using System.Windows.Media.Imaging;
using OSIRT.Helpers;
using System.IO;
using System.Diagnostics;
using System.Linq;

namespace OSIRT.UI.AuditLog
{
    public partial class RowDetailsPanel : UserControl
    {
        private string filePath = "";
        private ToolTip tooltip = new ToolTip();


        public RowDetailsPanel()
        {
            InitializeComponent();
            uiFileDetailsLabel.Text = "";
        }

        public TextBox DateTimeTextBox { get; private set; }
        public TextBox ActionTextBox { get; private set; }
        public TextBox UrlTextBox { get; private set; }
        public TextBox FileTextBox { get; private set; }
        public TextBox HashTextBox { get; private set; }
        public TextBox NotesTextBox { get; private set; }
        public GroupBox RowDetailsGroupBox { get; private set; }
        public PictureBox FilePreviewImage { get; private set; }

        private void SetFileLabelText(string text)
        {
            uiFileDetailsLabel.Text = text;
        }

        public void ClearFilePreviewer()
        {
            FilePreviewImage.Image = null;
            uiFileDetailsLabel.Text = "";
        }


        public void PopulateTextBoxes(Dictionary<string, string> rowDetails)
        {
            var textBoxes = RowDetailsGroupBox.GetChildControls<TextBox>();

            DateTimeTextBox.Text = rowDetails["date"] + " " + rowDetails["time"];

            foreach (TextBox textBox in textBoxes.Where(textBox => textBox != DateTimeTextBox))
            {
                string value;
                string key = textBox.Tag.ToString();
                if (rowDetails.TryGetValue(key, out value))
                {
                    if (textBox == FileTextBox)
                    {
                        Actions directory;
                        Enum.TryParse(rowDetails["action"].Replace(" ", ""), true, out directory);
                        if (Path.HasExtension(rowDetails["file"]) && directory != Actions.CaseNotes)
                        {
                            DisplayFileIconWithFileSize(rowDetails["file"], directory);
                        }
                        else
                        {
                            ClearFilePreviewer();
                            filePath = "";
                        }
                    }
                    else
                    {
                        //TODO: File previewer still not quite right. File icon still displays when action is on Loaded.
                        //Enabling below means the file previewer doesn't show anything at all, because it gets overwritten.

                        //ClearFilePreviewer();
                        //filePath = "";
                    }

                }
                textBox.Text = value;
            }
        }

        private void DisplayFileIconWithFileSize(string file, Actions caseDirectory)
        {
            BitmapSource icon = IconManager.GetLargeIcon(file, true, false);
            FilePreviewImage.Image = OsirtHelper.GetBitmap(icon);
            string caseDir = Constants.Directories.GetSpecifiedCaseDirectory(caseDirectory);
            filePath = Path.Combine(Constants.ContainerLocation, caseDir, file);
            SetFileLabelText($"File size: {OsirtHelper.GetHumanReadableFileSize(filePath)}. File type: {Path.GetExtension(filePath.ToUpperInvariant())}");

        }

        private void uiRowDetailsPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void RowDetailsPanel_Load(object sender, EventArgs e)
        {
            Dock = DockStyle.Fill;
            FilePreviewImage.Cursor = Cursors.Hand;
            //TODO: don't want this to display or be clickable if there isn't a file in the previewer
            FilePreviewImage.MouseClick += FilePreviewImage_MouseClick;
            tooltip.SetToolTip(FilePreviewImage, "Click to open file in the system's default application.");
        }

        private void FilePreviewImage_MouseClick(object sender, MouseEventArgs e)
        {
            if (filePath == "")
                return;

            try
            {
                Process.Start(filePath);
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show($"Unable to open file ({filePath}) as the file is not found");
            }
            catch (Win32Exception we)
            {
                MessageBox.Show($"Unable to open file ({filePath}). Reason: {we} ");
            }
        }
    }
}
