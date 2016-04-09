using Cyotek.Windows.Forms;
using ImageMagick;
using Jacksonsoft;
using OSIRT.Enums;
using OSIRT.Helpers;
using OSIRT.Loggers;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSIRT.UI
{
    public partial class ImagePreviewerForm : Form
    {

        private ImageBox imageBox;
        private string imagePath;
        private ScreenshotDetails details;
        private readonly int MaxImageHeight = 12500;
        private BackgroundWorker hashCalcBackgroundWorker;
        private CannotOpenImagePanel cantOpenPanel;
        private ToolTip tooltip;

        public string FileName { get { return uiImageNameComboBox.Text; } }
        public string FileExtension { get { return uiFileExtensionComboBox.Text; } }
        public string Note { get { return uiNoteSpellBox.Text; } }
        public string Hash { get; private set; }
        public string DateAndTime { get { return uiDateAndTimeTextBox.Text; } }

        public ImagePreviewerForm()
        {
            InitializeComponent();
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
            e.Result = OsirtHelper.GetFileHash(imagePath);
        }

        public ImagePreviewerForm(ScreenshotDetails details) : this()
        {
            imagePath = Constants.TempImgFile;
            this.details = details;
            tooltip = new ToolTip();
            uiNoteSpellBox.KeyUp += UiNoteSpellBox_KeyUp;
        }



        private void InitialiseBackgroundWorker()
        {
            hashCalcBackgroundWorker = new BackgroundWorker();
            hashCalcBackgroundWorker.DoWork += BackgroundWorker_DoWork;
            hashCalcBackgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            InitialiseBackgroundWorker();
            PopulateDetails();
            CheckValidNoteEntry();
            Size imageSize = GetImageSize();

            if (imageSize.Height < MaxImageHeight)
            {
                CreateAndShowImageBox();
            }
            else
            {
                ShowCannotOpenPanel(imageSize);
            }

            hashCalcBackgroundWorker.RunWorkerAsync();

        }

        private Size GetImageSize()
        {
            int width, height;
            using (MagickImage image = new MagickImage(imagePath))
            {
                width = image.Width;
                height = image.Height;
            }

            return new Size(width, height);
        }

        private void PopulateDetails()
        {
            uiURLTextBox.Text = details.Url;
            uiDateAndTimeTextBox.Text = details.Date + " " + details.Time;
        }


        private void CreateAndShowImageBox()
        {
            imageBox = new ImageBox();
            imageBox.Dock = DockStyle.Fill;
            uiSplitContainer.Panel2.Controls.Add(imageBox);
            try
            {
                Image image = Image.FromFile(imagePath);
                LoadImage(new Bitmap(image));
            }
            catch (OutOfMemoryException oom)
            {
                MessageBox.Show(@"Debugging: Known issue. Webpage takes a large chunk of memory, causing the image loading in the previewer to fail. 
                                The image is still saved/logged/hashed, it just can't be previewed. Further debug info:  " + oom);
                //we can carry on, show the previewer so they can name the image and leave a note.
                //TODO: put a friendly message on the right, and a link to the image currently residing in the cache
                //so they can see it.
            }
            catch(FileNotFoundException fnf)
            {
                MessageBox.Show($"Unable to find the image file! Debug: {fnf}");
                //safely close OSIRT, here???
            }
        }

        private void ShowCannotOpenPanel(Size originalSize)
        {
            cantOpenPanel = new CannotOpenImagePanel(imagePath, originalSize);
            cantOpenPanel.Dock = DockStyle.Fill;
            uiSplitContainer.Panel2.Controls.Add(cantOpenPanel);
        }

        private void LoadImage(Image image)
        {
            imageBox.Image = image;
            imageBox.ZoomToFit();
        }

        private void ImagePreviewerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            imageBox?.Image?.Dispose(); //the image box can be not null, but the image CAN be null!
            imageBox?.Dispose();
            cantOpenPanel?.CleanUp();
        }


        private void ImagePreviewerForm_Load(object sender, EventArgs e)
        {
            uiFileExtensionComboBox.Items.Add(SaveableFileTypes.Png);
            uiFileExtensionComboBox.Items.Add(SaveableFileTypes.Pdf);
            uiFileExtensionComboBox.SelectedIndex = 0;

            PopulateComboboxWithFiles();

        }

        private void PopulateComboboxWithFiles()
        {
            string path = Path.Combine(Constants.ContainerLocation, Constants.Directories.GetSpecifiedCaseDirectory(Actions.Screenshot));
            string[] files = Directory.GetFiles(path).Select(Path.GetFileNameWithoutExtension).ToArray();
            uiImageNameComboBox.Items.AddRange(files);
        }


        private void uiOKButton_Click(object sender, EventArgs e)
        {

            if (FileExtension == SaveableFileTypes.Pdf)
            {
                WaitWindow.Show(SaveAsPdf, "Saving as PDF. Please Wait...", FileName);
            }
            else if (FileExtension == SaveableFileTypes.Png)
            {
                SaveAsPng(FileName);
            }
            else
            {
                SaveAsPng(FileName);
            }

            Logger.Log(new WebpageActionsLog(details.Url, Actions.Screenshot, Hash, FileName + FileExtension, Note));
            DialogResult = DialogResult.OK;
            Close();

        }


        private void SaveAsPdf(object sender, WaitWindowEventArgs e)
        {
            string fileName = e.Arguments[0].ToString();
            string pathToSave = "";
            bool thrown = false;
            try
            {
                using (MagickImage image = new MagickImage(imagePath))
                {
                    image.Format = MagickFormat.Pdf;
                    pathToSave = Path.Combine(Constants.ContainerLocation, Constants.Directories.GetSpecifiedCaseDirectory(Actions.Screenshot), fileName + SaveableFileTypes.Pdf);
                    image.Write(pathToSave);
                    e.Window.Message = "Rehashing PDF";
                    Hash = OsirtHelper.GetFileHash(pathToSave);
                }
            }
            catch (Exception ex) when (ex is MagickErrorException || ex is System.Runtime.InteropServices.SEHException || ex is ArgumentException || ex is System.Reflection.TargetInvocationException)
            {
                thrown = true;
                var message = "Unable to save as PDF. Reverting to saving as PNG.";
                Invoke((MethodInvoker)(() => uiFileExtensionComboBox.SelectedIndex = uiFileExtensionComboBox.Items.IndexOf(SaveableFileTypes.Png)));
                e.Window.Message = message;
                Task.Delay(2000).Wait(); //just so the user can see we're saving as PNG instead
                SaveAsPng(fileName);
            }
            finally
            {
                //delete temp pdf file
                if (thrown)
                {
                    if (File.Exists(pathToSave))
                    {
                        File.Delete(pathToSave);
                    }
                }
            }
        }

        private void SaveAsPng(string name)
        {
            try
            {
                string destLocation = Path.Combine(Constants.ContainerLocation, Constants.Directories.GetSpecifiedCaseDirectory(Actions.Screenshot), name + SaveableFileTypes.Png);
                string sourceFile = Path.Combine(Constants.CacheLocation, Constants.TempImgFile);
                File.Copy(sourceFile, destLocation); //use Copy for now, then delete cache later
            }
            catch (IOException ioe)
            {
                MessageBox.Show($"Can't move file to container due to an IOExcpetion... {ioe}");
            }
            catch (UnauthorizedAccessException uae)
            {
                MessageBox.Show($"Can't move file to container due to an Unauthorised Access Attempt... {uae}");
            }
        }



        private bool IsValidFileName()
        {
            bool valid = false;
            //must check this first, as trying to use Path.Combine with an illegal file char will throw an argument exception
            if(OsirtHelper.IsValidFilename(FileName))
            {
                string path = Path.Combine(Constants.ContainerLocation, Constants.Directories.GetSpecifiedCaseDirectory(Actions.Screenshot), FileName + FileExtension);
                if (!File.Exists(path))
                {
                    valid = true;
                }
            }
            return valid;
        }

        private void CheckValidFileName()
        {
            //TODO: Invalid entry (red cross) resource was deleted. Re-add.
            string tootipText;
            if (IsValidFileName())
            {
                uiDoesFileExistPictureBox.Image = Properties.Resources.ok;
                tootipText = "Filename OK";
            }
            else
            {
                //uiDoesFileExistPictureBox.Image = Properties.Resources.invalid_entry;
                tootipText = "Filename is not valid. File with that name may already exists, or filename contains illegal characters.";
            }

            tooltip.SetToolTip(uiDoesFileExistPictureBox, tootipText);
        }

        private void CheckValidNoteEntry()
        {
            if (string.IsNullOrWhiteSpace(Note))
            {
                tooltip.SetToolTip(uiNotePictureBox, "You must enter a note.");
                //uiNotePictureBox.Image = Properties.Resources.invalid_entry;
            }
            else
            {
                tooltip.SetToolTip(uiNotePictureBox, "Note OK.");
                uiNotePictureBox.Image = Properties.Resources.ok;
            }
        }

        private void UiNoteSpellBox_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            CheckValidNoteEntry();
        }

        private void uiFileExtensionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckValidFileName();
        }


        private void uiImageNameComboBox_KeyUp(object sender, KeyEventArgs e)
        {
            CheckValidFileName();
        }

        private void uiCancelButton_Click(object sender, EventArgs e)
        {
         
        }
    }
}
