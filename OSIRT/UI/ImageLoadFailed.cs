using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using OSIRT.Helpers;
using System.IO;

namespace OSIRT.UI
{
    public partial class ImageLoadFailed : UserControl
    {
        public ImageLoadFailed()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(Path.Combine(Constants.CacheLocation, Constants.TempImgFile));
        }
    }
}
