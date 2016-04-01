using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OSIRT.Extensions;
using OSIRT.Enums;
using System.Windows.Media.Imaging;
using OSIRT.Helpers;
using System.IO;
using System.Diagnostics;

namespace OSIRT.UI.AuditLog
{
    public partial class RowDetailsPanel : UserControl
    {
        private string filePath = "";
        private ToolTip tooltip = new ToolTip();


        public RowDetailsPanel()
        {
            InitializeComponent();
        }

        public TextBox DateTimeTextBox { get { return uiDateAndTimeTextBox; } }
        public TextBox ActionTextBox { get { return uiActionTextBox; } }
        public TextBox URLTextBox { get { return uiURLTextBox; } }
        public TextBox FileTextBox { get { return uiFileNameTextBox; } }
        public TextBox HashTextBox { get { return uiHashTextBox; } }
        public TextBox NotesTextBox { get { return uiNoteTextBox; } }
        public GroupBox RowDetailsGroupBox { get { return uiRowDetailsGroupBox; } }
        public PictureBox FilePreviewImage { get { return uiFilePreviewPictureBox; } }

        private void SetFileLabelText(string text)
        {
            uiFileDetailsLabel.Text = text;
        }

        public void ClearFilePreviewer()
        {
            uiFilePreviewPictureBox.Image = null;
            uiFileDetailsLabel.Text = "";
        }


        public void PopulateTextBoxes(Dictionary<string, string> rowDetails)
        {
            var textBoxes = RowDetailsGroupBox.GetChildControls<TextBox>();

            DateTimeTextBox.Text = rowDetails["date"] + " " + rowDetails["time"];

            foreach (TextBox textBox in textBoxes)
            {
                if (textBox == DateTimeTextBox)
                    continue;


                string value = "";
                string key = textBox.Tag.ToString();
                if (rowDetails.TryGetValue(key, out value))
                {
                    if (textBox == FileTextBox)
                    {
                        Actions directory;
                        Enum.TryParse(rowDetails["action"], true, out directory);
                        DisplayFileIconWithFileSize(rowDetails["file"], directory);
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

        private void DisplayFileIconWithFileSize(string file, Actions caseDirectory)
        {
            IconManager iconManager = new IconManager();
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
