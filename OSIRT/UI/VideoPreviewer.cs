using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vlc.DotNet.Forms;

namespace OSIRT.UI
{
    public partial class VideoPreviewer : Form
    {
        public VideoPreviewer()
        {
            InitializeComponent();
        }

        private void VideoPreviewer_Load(object sender, EventArgs e)
        {


            try
            {
                var player = new VlcControl();
                player.Dock = DockStyle.Fill;
           
                player.SetMedia(new System.IO.FileInfo(@"D:/test.mp4"));
                splitContainer1.Panel2.Controls.Add(player);
                player.Play();
            }
            catch
            {

            }
        }
    }
}
