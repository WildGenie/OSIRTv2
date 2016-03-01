using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cyotek.Windows.Forms;
using ImageMagick;
using System.IO;
using OSIRT.Helpers;
using System.Threading;
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
            //TODO: Refactor (duplication)
            string tempImgPath = Path.Combine(Constants.CacheLocation, "scaled.png");
            imageBox.Image = Image.FromFile(tempImgPath);
        }

        private void ScaleImageBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            CreateScaledImage();
        }

        private void SetLinkLabelText()
        {
            uiCantOpenLinkLabel.Text = $@"Unable to display this image in full size [Original size: {originalImageSize.Width} x {originalImageSize.Height}]." + System.Environment.NewLine + "Click here to view the image in the system's default image viewing application.";
        }

        private void AddImageBox()
        {
            imageBox = new ImageBox();
            imageBox.Dock = DockStyle.Fill;
            uiUnableToDisplayImgTableLayout.Controls.Add(imageBox, 1, 0);
        }

     
        private void CreateScaledImage()
        {
            string tempImgPath = Path.Combine(Constants.CacheLocation, "scaled.png");
            using (MagickImage image = new MagickImage(imagePath))
            {
                image.Scale(new Percentage(25));
                image.Write(tempImgPath);
            }
            //TODO: need to release memory from opened image!
            //imageBox.Image = Image.FromFile(tempImgPath);

        }

        private void uiCantOpenLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start(Path.Combine(Constants.CacheLocation, "temp.png"));
            }
            catch (FileNotFoundException fnf)
            {
                MessageBox.Show("Image not found.");
            }
        }
    }
}
