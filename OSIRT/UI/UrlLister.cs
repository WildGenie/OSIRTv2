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
    public partial class UrlLister : Form
    {
        private string Urls;

        public UrlLister(string urls)
        {
            InitializeComponent();
            Urls = urls;
        }

        private void UrlLister_Load(object sender, EventArgs e)
        {
            uiURLListTextBox.Text = Urls;
        }

        private void uiCopyUrlsButton_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();   
            Clipboard.SetText(uiURLListTextBox.Text);
        }

        private void uiCloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
