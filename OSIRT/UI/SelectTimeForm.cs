using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSIRT.UI
{
    public partial class SelectTimeForm : Form
    {
        public SelectTimeForm()
        {
            InitializeComponent();
        }

        public int Time => (int)uiTimeNumericUpDown.Value;

        private void SelectTimeForm_Load(object sender, EventArgs e)
        {

        }
    }
}
