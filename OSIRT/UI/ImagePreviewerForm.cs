using Cyotek.Windows.Forms;
using ImageMagick;
using Jacksonsoft;
using OSIRT.Helpers;
using OSIRT.Loggers;
using OSIRT.Properties;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
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

        public string FileName { get { return uiImageNameComboBox.Text; } }
        public string FileExtension { get { return uiFileExtensionComboBox.Text; } }
        public string Note { get { return uiNoteSpellBox.Text; } }

        public ImagePreviewerForm()
        {
            InitializeComponent();

        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            uiHashTextBox.Text = e.Result.ToString();
            uiHashCalcProgressBar.Visible = false;
            uiCalculatingHashLabel.Text = $"{Settings.Default.Hash.ToUpperInvariant()} Hash";
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            HashService hashService = HashServiceFactory.Create(Settings.Default.Hash);
            string hash = "";
            Thread.Sleep(1000);
            using (FileStream fileStream = File.OpenRead(imagePath))
            {
                hash = hashService.ToHex(hashService.ComputeHash(fileStream));
            }

            e.Result = hash;
        }

        public ImagePreviewerForm(ScreenshotDetails details) : this()
        {
            this.imagePath = Constants.TempImgFile;
            this.details = details;
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
            uiURLTextBox.Text = details.URL;
            uiDateAndTimeTextBox.Text = details.Date + " " + details.Time;
        }


        private void CreateAndShowImageBox()
        {
            imageBox = new ImageBox();
            imageBox.Dock = DockStyle.Fill;
            uiSplitContainer.Panel2.Controls.Add(imageBox);
            LoadImage(new Bitmap(Image.FromFile(imagePath)));
        }

        private void ShowCannotOpenPanel(Size originalSize)
        {
            //TODO: Display a reduced sized image?
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
            imageBox?.Image.Dispose();
            imageBox?.Dispose();
            cantOpenPanel?.CleanUp();
        }


        private void ImagePreviewerForm_Load(object sender, EventArgs e)
        {
            uiFileExtensionComboBox.Items.Add(SaveableFileTypes.Png);
            uiFileExtensionComboBox.Items.Add(SaveableFileTypes.Pdf);
            uiFileExtensionComboBox.SelectedIndex = 0;

            //TODO: Remove extension from file name, too.
            string path = Path.Combine(Constants.ContainerLocation, Constants.Directories.GetSpecifiedCaseDirectory(CaseDirectory.Screenshots));
            string[] files =  Directory.GetFiles(path).Select(p => Path.GetFileName(p)).ToArray();
            uiImageNameComboBox.Items.AddRange(files);

        }

        private void uiOKButton_Click(object sender, EventArgs e)
        {


            if (!IsValidFileName())
            {
                //display lable instead. MessageBox for now
                MessageBox.Show("Please enter a valid file name. This one may already exist");
                return;
            }


            if (string.IsNullOrWhiteSpace(Note))
            {
                //display lable instead. MessageBox for now
                MessageBox.Show("Must enter a note.");
                return;
            }


            if (FileExtension == SaveableFileTypes.Pdf)
            {
                WaitWindow.Show(SaveAsPDF, "Saving as PDF. Please Wait...", FileName);
            }
            else if (FileExtension == SaveableFileTypes.Png)
            {
                SaveAsPNG(FileName);
            }
            else
            {
                SaveAsPNG(FileName);
            }


            Log();

            //TODO: delete cache
            //TODO: trigger dialogresult OK

        }

        private void Log()
        {
            string hash = uiHashTextBox.Text;
            string note = uiNoteSpellBox.Text;
            Logger.Log(new WebpageActionsLog(details.URL, Constants.Actions.Screenshot, hash, FileName + FileExtension, note));
        }

        private void SaveAsPDF(object sender, WaitWindowEventArgs e)
        {
            //TODO: Will need to rehash
            string message = "";
            string fileName = e.Arguments[0].ToString();
            string pathToSave = "";
            bool thrown = false;
            try
            {
                using (MagickImage image = new MagickImage(imagePath))
                {
                    image.Format = MagickFormat.Pdf;
                    //TODO: may not always be "screenshots" for specified case directory (may be snippet, for example). Enum?
                    pathToSave = Path.Combine(Constants.ContainerLocation, Constants.Directories.GetSpecifiedCaseDirectory(CaseDirectory.Screenshots), fileName + SaveableFileTypes.Pdf);
                    image.Write(pathToSave);
                }
            }
            catch (Exception ex) when (ex is MagickErrorException || ex is System.Runtime.InteropServices.SEHException || ex is ArgumentException || ex is System.Reflection.TargetInvocationException)
            {
                thrown = true;
                message = "Unable to save as PDF. Reverting to saving as PNG.";
                e.Window.Message = message;
                Task.Delay(2000).Wait(); //just so the user can see we're saving as PNG instead
                SaveAsPNG(fileName);
            }
            finally
            {
                //delete temp pdf file
                if (thrown)
                    File.Delete(pathToSave);
            }


        }

        private void SaveAsPNG(string name)
        {
            try
            {
                string destLocation = Path.Combine(Constants.ContainerLocation, Constants.Directories.GetSpecifiedCaseDirectory(CaseDirectory.Screenshots), name + SaveableFileTypes.Png);
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
            //TODO: needs to fire when the combobox has changed index
            string path = Path.Combine(Constants.ContainerLocation, Constants.Directories.GetSpecifiedCaseDirectory(CaseDirectory.Screenshots), FileName + FileExtension);
            return !(File.Exists(path) || string.IsNullOrWhiteSpace(FileName));
        }



        private void CheckValidFileName()
        {

            if (IsValidFileName())
            {
                uiDoesFileExistPictureBox.Image = Properties.Resources.ok;
            }
            else
            {
                uiDoesFileExistPictureBox.Image = Properties.Resources.file_clash;
            }
        }

        private void uiFileExtensionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckValidFileName();
        }


        private void uiImageNameComboBox_KeyUp(object sender, KeyEventArgs e)
        {
            CheckValidFileName();
        }


        //private void button1_Click(object sender, EventArgs e)
        //{
        //    using (MagickImage image = new MagickImage(imagePath))
        //    {
        //        //using (MagickImage watermark = new MagickImage(@"C:\Users\Joe\Documents\ccculogo.gif"))
        //        //{
        //        //    image.Composite(watermark, Gravity.Southeast, CompositeOperator.Over);
        //        //    watermark.Evaluate(Channels.Alpha, EvaluateOperator.Divide, 1);
        //        //}
        //        image.Format = MagickFormat.Pdf;
        //        image.Write(@"C:\Users\Joe\Documents\testimage.pdf");
        //    }
        //}


    }
}
