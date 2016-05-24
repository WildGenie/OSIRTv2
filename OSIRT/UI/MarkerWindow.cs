using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OSIRT.UI
{
    public partial class MarkerWindow : Form
    {
        public MarkerWindow()
        {
            InitializeComponent();
        }

        private void MarkerWindow_Load(object sender, EventArgs e)
        {
            this.TransparencyKey = Color.Purple;
            //this.FormBorderStyle = FormBorderStyle.None;
           
        }
    }
}
