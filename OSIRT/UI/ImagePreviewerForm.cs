using Cyotek.Windows.Forms;
using ImageMagick;
using OSIRT.Helpers;
using OSIRT.Properties;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
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

        public ImagePreviewerForm(Image image) : this()
        {
            this.image = image;
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
        }

        private void uiOKButton_Click(object sender, EventArgs e)
        {
            


            //get file name
            //get file type (png/pdf)
            //check that file name does not already exist
            //convert to PDF if pdf required
            //save to directory 
            //log in database
        }

        private void uiImageNameComboBox_KeyUp(object sender, KeyEventArgs e)
        {
            CheckValidFileName();
        }



        private void CheckValidFileName()
        {
            string imageName = uiImageNameComboBox.Text;
            Debug.WriteLine($"Image name: {imageName}");
            string path = Path.Combine(Constants.Directories.GetSpecifiedCaseDirectory("screenshots"), imageName); //will also need extension
            if (File.Exists(path) || string.IsNullOrWhiteSpace(imageName))
            {
                uiDoesFileExistPictureBox.Image = Properties.Resources.file_clash;
            }
            else
            {
                uiDoesFileExistPictureBox.Image = Properties.Resources.ok;
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
