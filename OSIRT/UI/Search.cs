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
    public partial class Search : Form
    {
        public string SearchText { get; set; }

        public Search()
        {
            InitializeComponent();
        }

        private void uiSearchButton_Click(object sender, EventArgs e)
        {
            SearchText = uiSearchTextBox.Text;
            DialogResult = DialogResult.OK;
        }
    }
}
