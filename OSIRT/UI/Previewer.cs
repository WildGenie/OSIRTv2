using OSIRT.Enums;
using OSIRT.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSIRT.UI
{
    public partial class Previewer : System.Windows.Forms.Form
    {

        private BackgroundWorker hashCalcBackgroundWorker;
        private ToolTip tooltip;
        protected string filePath;
        protected Actions action;

        public string FileName { get { return uiFileNameComboBox.Text; } }
        public string FileExtension { get { return uiFileExtensionComboBox.Text; } }
        public string Note { get { return uiNoteSpellBox.Text; } }
        public string Hash { get; protected set; }
        public string DateAndTime { get; private set; }


        public Previewer()
        {
            InitializeComponent();
        }

        public Previewer(Actions action, string file) : this()
        {
            filePath = file;
            this.action = action;
            DateAndTime = $"{DateTime.Now.ToString("yyyy-MM-dd")} {DateTime.Now.ToString("HH:mm:ss")}";
            uiDateAndTimeTextBox.Text = DateAndTime;
            string appendDateStamp = System.Text.RegularExpressions.Regex.Replace(DateAndTime, @"[-|:|\s]", "_");
            if (action == Actions.Saved)
            {
                string extension = Path.GetExtension(filePath);
                uiFileNameComboBox.Text = Path.GetFileNameWithoutExtension(filePath) + "_" + appendDateStamp + extension;
                uiFileNameComboBox.Enabled = false;
                uiFileExtensionComboBox.Visible = false;
            }
            else
            {
                uiFileNameComboBox.Text = appendDateStamp;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            tooltip = new ToolTip();
            PopulateComboboxWithFiles();
            InitialiseKeyEvents();
            PopulateExtenions();
            CheckValidFileName();
            CheckValidNoteEntry();
        }

        private void Previewer_Load(object sender, EventArgs e)
        {
            InitialiseBackgroundWorker();
            hashCalcBackgroundWorker.RunWorkerAsync();
        }

       

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Hash = e.Result.ToString();
            uiHashTextBox.Text = Hash;
            uiHashCalcProgressBar.Visible = false;
            uiCalculatingHashLabel.Text = $"{UserSettings.Load().Hash.ToUpperInvariant()} Hash";
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Task.Delay(1000).Wait(); //just so user can "see" the image hashing
            e.Result = OsirtHelper.GetFileHash(filePath);
        }



        private void InitialiseBackgroundWorker()
        {
            hashCalcBackgroundWorker = new BackgroundWorker();
            hashCalcBackgroundWorker.DoWork += BackgroundWorker_DoWork;
            hashCalcBackgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;
        }

        private void PopulateComboboxWithFiles()
        {
            if (DesignMode) return; //This is causing design for inherited forms to break. Don't run this if in design mode

            string path = Path.Combine(Constants.ContainerLocation, Constants.Directories.GetSpecifiedCaseDirectory(action));
            string[] files = Directory.GetFiles(path).Select(Path.GetFileNameWithoutExtension).ToArray();
            uiFileNameComboBox.Items.AddRange(files);
        }

        private void PopulateExtenions()
        {
            uiFileExtensionComboBox.Items.Clear();
            string extensionsCsv = "";
            switch (action)
            {
                case Actions.Screenshot:
                case Actions.Scraped: //Scraped won't use previewer?
                case Actions.Snippet:
                    extensionsCsv = OsirtHelper.GetResource("ImageSaveableTypes.txt");
                    break;
                case Actions.Video:
                    extensionsCsv = OsirtHelper.GetResource("VideoSaveableFileTypes.txt");
                    break;
                //case Actions.Saved: //TODO: Give this its own case, as saved images can have many file extensions
                //    extensionsCsv = Path.GetExtension(filePath);
                //    break;
            }

            if (extensionsCsv.Contains(","))
            {
                string[] split = extensionsCsv.Split(',');
                uiFileExtensionComboBox.Items.AddRange(split);
            }
            else
            {
                uiFileExtensionComboBox.Items.Add(extensionsCsv);
            }
            uiFileExtensionComboBox.SelectedIndex = 0;
        }


        private bool IsValidFileName()
        {
            bool valid = false;
            //must check this first, as trying to use Path.Combine with an illegal file char will throw an argument exception
            if (OsirtHelper.IsValidFilename(FileName))
            {
                string path = Path.Combine(Constants.ContainerLocation, Constants.Directories.GetSpecifiedCaseDirectory(action), FileName + FileExtension);
                if (!File.Exists(path))
                {
                    valid = true;
                }
            }
            return valid;
        }

        private bool CheckValidFileName()
        {
            bool isValid = false;
            if (IsValidFileName())
            {
                SetMessage(uiDoesFileExistPictureBox, Properties.Resources.ok, "Filename OK", true);
                isValid = true;
            }
            else
            {
                SetMessage(uiDoesFileExistPictureBox, Properties.Resources.cross, "Filename is not valid. File with that name may already exists, or filename contains illegal characters.", false);
            }
            return isValid;
        }

        private void CheckValidNoteEntry()
        {
            if (!string.IsNullOrWhiteSpace(Note))
            {
                SetMessage(uiNotePictureBox, Properties.Resources.ok, "Note OK", true);
            }
            else
            {
                SetMessage(uiNotePictureBox, Properties.Resources.cross, "You must enter a note.", false);
            }
        }

        private void SetMessage(PictureBox picturebox, Bitmap resource, string message, bool enableLogBtn)
        {
            tooltip.SetToolTip(picturebox, message);
            picturebox.Image = resource;
            uiOKButton.Enabled = enableLogBtn;
        }


        private void InitialiseKeyEvents()
        {
            uiFileNameComboBox.KeyUp += uiFileExtensionComboBox_KeyUp;
            uiFileExtensionComboBox.SelectedIndexChanged += uiFileExtensionComboBox_SelectedIndexChanged;
            uiNoteSpellBox.KeyUp += uiNoteSpellBox_KeyUp;
        }

        private void uiNoteSpellBox_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            CheckValidNoteEntry();
        }

        private void uiFileExtensionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckValidFileName();
        }

        private void uiFileExtensionComboBox_KeyUp(object sender, KeyEventArgs e)
        {
            CheckValidFileName();
        }

        private void uiOKButton_Click(object sender, EventArgs e)
        {

        }
    }
}
