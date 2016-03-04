using Cyotek.Windows.Forms;
using ImageMagick;
using Jacksonsoft;
using OSIRT.Helpers;
using OSIRT.Properties;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSIRT.UI
{
    public partial class ImagePreviewerForm : Form
    {

        private ImageBox imageBox;
        private Image image;
        private string imagePath;
        private ScreenshotDetails details;
        private readonly int MaxImageHeight = 12500;
        private BackgroundWorker hashCalcBackgroundWorker;
        private CannotOpenImagePanel cantOpen;

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

        public ImagePreviewerForm(string imagePath, ScreenshotDetails details) : this()
        {
            this.imagePath = imagePath;
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
                 CreateAnShowImageBox();
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
            //uiHashTextBox.Text = details.Hash;
            uiDateAndTimeTextBox.Text = details.Date + " " + details.Time;
        }


        private void CreateAnShowImageBox()
        {
            imageBox = new ImageBox();
            imageBox.Dock = DockStyle.Fill;
            uiSplitContainer.Panel2.Controls.Add(imageBox);
            LoadImage(Image.FromFile(imagePath));
        }

        private void ShowCannotOpenPanel(Size originalSize)
        {
            //TODO: Display a reduced sized image?
            cantOpen = new CannotOpenImagePanel(imagePath, originalSize);
            cantOpen.Dock = DockStyle.Fill;
            uiSplitContainer.Panel2.Controls.Add(cantOpen);
        }

        private void LoadImage(Image image)
        {
            imageBox.Image = image;
            imageBox.ZoomToFit();
        }

        private void ImagePreviewerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            imageBox?.Image.Dispose();
            cantOpen?.CleanUp(); 
        }


        private void ImagePreviewerForm_Load(object sender, EventArgs e)
        {
            uiFileExtensionComboBox.SelectedIndex = 0;
            uiFileExtensionComboBox.DataSource = Enum.GetValues(typeof(SaveableFileTypes));
        }

        private void uiOKButton_Click(object sender, EventArgs e)
        {

            if (!IsValidFileName())
            {
                //display lable instead. MessageBox for now
                MessageBox.Show("Please enter a valid file name. This one may already exist");
                return;
            }


            if(string.IsNullOrWhiteSpace(Note))
            {
                //display lable instead. MessageBox for now
                MessageBox.Show("Must enter a note.");
                return;
            }

                //we're here, we have a valid file name and note.
              
                SaveableFileTypes fileType;
                bool validFileType = Enum.TryParse(uiFileExtensionComboBox.SelectedValue.ToString(), out fileType);

                if(validFileType)
                {
                    if(fileType == SaveableFileTypes.PDF)
                    {
                        //save as PDF with please wait window
                        WaitWindow.Show(SaveAsPDF, "Saving as PDF. Please Wait...", FileName);
                    }
                    else if (fileType == SaveableFileTypes.PNG)
                    {
                    //save as PNG (already have the png, just need to move it from cache)
                        SaveAsPNG(FileName);
                    }
                    else
                    {
                    //gone wrong? save as png, anyway.
                        SaveAsPNG(FileName);
                    }
                }
            //log in database
            //delete cache


        }

        private void SaveAsPDF(object sender, WaitWindowEventArgs e)
        {
            string message = "";
            string fileName = e.Arguments[0].ToString();
            try
            {
                Debug.WriteLine($"--- Image path in save as pdf: {imagePath}");
                using (MagickImage image = new MagickImage(imagePath))
                {
                    image.Format = MagickFormat.Pdf;
                    //TODO: may not always be "screenshots" for specified case directory. Enum?
                    //TODO: Better way to get FileExtension!
                    string pathToSave = Path.Combine(Constants.ContainerLocation, Constants.Directories.GetSpecifiedCaseDirectory("screenshots"), fileName + ".pdf");
                    image.Write(pathToSave);
                }
            }
            catch (Exception ex) when (ex is MagickErrorException || ex is System.Runtime.InteropServices.SEHException || ex is ArgumentException || ex is System.Reflection.TargetInvocationException)
            {
                message = "Unable to save as PDF. Reverting to saving as PNG.";
            }

            e.Window.Message = message;
            Task.Delay(2000).Wait(); //just so the user can see we're saving as PNG instead
            SaveAsPNG(fileName);


        }

        private void SaveAsPNG(string name)
        {
            //TODO: This only works if image is in cache. What about screenshots not in cache.
            try
            {
                string destLocation = Path.Combine(Constants.ContainerLocation, Constants.Directories.GetSpecifiedCaseDirectory("screenshots"), name + ".png");
                string sourceFile = Path.Combine(Constants.CacheLocation, Constants.TempImgFile);
                File.Move(sourceFile, destLocation);
            }
            catch (IOException ioe)
            {
                MessageBox.Show("Can't move file to container due to an IOExcpetion...");
            }
            catch (UnauthorizedAccessException uae)
            {
                MessageBox.Show("Can't move file to container due to an Unauthorised Access Attempt...");
            }
        }


        private void uiImageNameComboBox_KeyUp(object sender, KeyEventArgs e)
        {
            CheckValidFileName();
        }

        private bool IsValidFileName()
        {
            string path = Path.Combine(Constants.Directories.GetSpecifiedCaseDirectory("screenshots"), FileName); //will also need extension
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
