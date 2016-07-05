using Ionic.Zip;
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
    public partial class RestoreCaseForm : Form
    {

        private string path;

        public RestoreCaseForm()
        {
            InitializeComponent();
        }

        private void uiBrowseButton_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();
                if (result != DialogResult.OK)
                    return;

                path = fbd.SelectedPath;
                uiPathTextBox.Text = path;
            }
        }

        private void RezipCase(string path)
        {
            using (ZipFile zip = new ZipFile())
            {
                zip.AddDirectory(path, Path.GetFileName(path));
                zip.Save(Path.Combine(Directory.GetParent(path).FullName, Path.GetFileName(path) + Constants.ContainerExtension));
            }
            OsirtHelper.DeleteDirectory(path);
        }


        private bool IsExtractedCase(string path)
        {
            return Directory.GetFiles(path, "case.db").Length != 0;
        }

        private void FlipUi(bool on, string buttonMessage)
        {
            uiRecoverButton.Enabled = !on;
            uiBrowseButton.Enabled = !on;
            uiRecoveringProgressBar.Visible = on;
            uiRecoverButton.Text = buttonMessage;
        }

        private void uiRecoverButton_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(path))
            {
                MessageBox.Show("Please select an extracted OSIRT case file", "No case path selected", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            if (!IsExtractedCase(path))
            {
                MessageBox.Show("This doesn't appear to be an extracted OSIRT case file. Directory is missing case.db file.", "Not extracted OSIRT case", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FlipUi(true, "Recovering...");
            var backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += delegate
            {
                System.Threading.Thread.Sleep(1000);
                RezipCase(path);
            };
            backgroundWorker.RunWorkerCompleted += delegate
            {
                FlipUi(false, "Recover");
            };
            backgroundWorker.RunWorkerAsync();
        }
    }
}
