using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Cyotek.Windows.Forms;
using ImageMagick;
using System.IO;
using OSIRT.Database;
using System.Diagnostics;

namespace OSIRT.UI
{
    public partial class CannotOpenImagePanel : UserControl
    {

        private string imagePath;
        private ImageBox imageBox;
        private Size originalImageSize;
        private BackgroundWorker scaleImageBackgroundWorker;

        public CannotOpenImagePanel(string imagePath, Size originalImageSize)
        {
            InitializeComponent();
            this.imagePath = imagePath;
            this.originalImageSize = originalImageSize;
        }

        private void CannotOpenImagePanel_Load(object sender, EventArgs e)
        {
            scaleImageBackgroundWorker = new BackgroundWorker();
            scaleImageBackgroundWorker.DoWork += ScaleImageBackgroundWorker_DoWork;
            scaleImageBackgroundWorker.RunWorkerCompleted += ScaleImageBackgroundWorker_RunWorkerCompleted;

            SetLinkLabelText();
            scaleImageBackgroundWorker.RunWorkerAsync();
        }



        private void ScaleImageBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            uiUnableToDisplayImgTableLayout.Controls.Remove(uiScaledImagePanel);
            AddImageBox();
            imageBox.Image = Image.FromFile(Constants.ScaledImgFile);
        }

        private void ScaleImageBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            CreateScaledImage();
        }

        private void SetLinkLabelText()
        {
            uiCantOpenLinkLabel.Text = $"Unable to display this image in full size [Original size: {originalImageSize.Width} x {originalImageSize.Height}]." + Environment.NewLine + "Click here to view the image in the system's default image viewing application.";
        }

        private void AddImageBox()
        {
            imageBox = new ImageBox();
            imageBox.Dock = DockStyle.Fill;
            uiUnableToDisplayImgTableLayout.Controls.Add(imageBox, 1, 0);
        }

     
        private void CreateScaledImage()
        {
   
            using (MagickImage image = new MagickImage(imagePath))
            {
                //TODO: Perhaps see what the original size is then scale based on that
                //Keeping it at 25% may "punish" those images that are barely over the limit
                image.Scale(new Percentage(25));
                image.Write(Constants.ScaledImgFile);
            }
        }

        public void CleanUp()
        {
            imageBox?.Image.Dispose();
            imageBox?.Dispose();
            Dispose();
        }

        private void uiCantOpenLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start(Constants.TempImgFile);
            }
            catch (FileNotFoundException fnf)
            {
                MessageBox.Show($"Image not found. Error: {fnf}");
            }
        }
    }
}
