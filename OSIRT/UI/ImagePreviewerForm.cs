using Cyotek.Windows.Forms;
using ImageMagick;
using OSIRT.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSIRT.UI
{
    public partial class ImagePreviewerForm : Form
    {

        private ImageBox imageBox;
        private Image image;
        private string imagePath;


        public ImagePreviewerForm()
        {
            InitializeComponent();
        }

        public ImagePreviewerForm(string imagePath) : this()
        {
            this.imagePath = imagePath;
        }

        public ImagePreviewerForm(Image image) : this()
        {
            this.image = image;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            imageBox = new ImageBox();
            
            imageBox.Dock = DockStyle.Fill;
            uiSplitContainer.Panel2.Controls.Add(imageBox);

            //TODO: very large images cause this to just die.
            //LoadImage(Image.FromFile(@"D:/FinalImage.png"));
            //Path.Combine(Constants.ContainerLocation, Constants.Directories.GetSpecifiedCaseDirectory("screenshots"), "temp.png")
            LoadImage(image);

        }

        private void LoadImage(Image image)
        {
         
            imageBox.Image = image;
            imageBox.ZoomToFit();
            //imageBox.Refresh();
            //imageBox.ZoomToFit();
        }



        private void ImagePreviewerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            imageBox.Image.Dispose();
            imageBox.Dispose();
        }

        private void ImagePreviewerForm_Load(object sender, EventArgs e)
        {

        }
    }
}
