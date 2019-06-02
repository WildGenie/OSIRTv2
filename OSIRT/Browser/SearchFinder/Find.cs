using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSIRT.Browser.SearchFinder
{
    public partial class Find : Form
    {

        public event EventHandler FindNext;
        public event EventHandler FindPrevious;
        public event EventHandler FindClosing;

        public Find()
        {
            InitializeComponent();
        }

        private void uiNextButton_Click(object sender, EventArgs e)
        {
            string search = uiFindTextTextBox.Text;
            FindNext?.Invoke(this, new TextEventArgs(search));
        }

        private void uiFindPreviousButton_Click(object sender, EventArgs e)
        {
            string search = uiFindTextTextBox.Text;
            FindPrevious?.Invoke(this, new TextEventArgs(search));
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            FindClosing?.Invoke(this, EventArgs.Empty);
        }

        private void Find_Load(object sender, EventArgs e)
        {
            
        }
    }
}
