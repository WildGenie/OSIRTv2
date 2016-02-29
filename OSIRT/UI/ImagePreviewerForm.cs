using Cyotek.Windows.Forms;
using ImageMagick;
using OSIRT.Helpers;
using OSIRT.Properties;
using System;
using System.ComponentModel;
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
            else //too big, display a panel with a label and link to open in the system's default application
            {
                ShowCannotOpenPanel();
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

        private void ShowCannotOpenPanel()
        {
            //TODO: Display a reduced sized image?
            CannotOpenImagePanel cantOpen = new CannotOpenImagePanel();
            cantOpen.Dock = DockStyle.Fill;
            uiSplitContainer.Panel2.Controls.Add(cantOpen);
        }

        private void LoadImage(Image image)
        {
            imageBox.Image = image;
            imageBox.ZoomToFit();
            //imageBox.Refresh();
        }

        private void ImagePreviewerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
       
            imageBox?.Image.Dispose();
            //imageBox.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (MagickImage image = new MagickImage(imagePath))
            {
                using (MagickImage watermark = new MagickImage(@"C:\Users\Joe\Documents\ccculogo.gif"))
                {
                    image.Composite(watermark, Gravity.Southeast, CompositeOperator.Over);
                    watermark.Evaluate(Channels.Alpha, EvaluateOperator.Divide, 1);
                }
                image.Format = MagickFormat.Pdf;
                image.Write(@"C:\Users\Joe\Documents\testimage.pdf");
            }
        }

        private void ImagePreviewerForm_Load(object sender, EventArgs e)
        {

        }
    }
}
