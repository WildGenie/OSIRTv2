using Cyotek.Windows.Forms;
using ImageMagick;
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

        public ImagePreviewerForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            imageBox = new ImageBox();
            imageBox.Dock = DockStyle.Fill;
            uiSplitContainer.Panel2.Controls.Add(imageBox);

            //TODO: very long images cause this to just die.
            LoadImage(Image.FromFile(@"D:/FinalImage.png"));
               
        }

        private void LoadImage(Image image)
        {
            imageBox.Image = image;
            //imageBox.Refresh();
            //imageBox.ZoomToFit();
        }

      

        private void ImagePreviewerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //imageBox.Image.Dispose();
        }
    }
}
