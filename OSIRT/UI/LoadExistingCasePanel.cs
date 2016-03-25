using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using OSIRT.Helpers;
using Ionic.Zip;
using System.Diagnostics;

namespace OSIRT.UI
{
    public partial class LoadExistingCasePanel : UserControl
    {

        public event EventHandler PasswordCheckClick;

        private FileInfo file;

        public LoadExistingCasePanel(FileInfo file)
        {
            InitializeComponent();
            this.file = file;
        }

        private void InitialiseFileDetailFields()
        {
            uiFileNameTextBox.Text = file.Name;
            uiLastModifiedTextBox.Text = file.LastAccessTime.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void LoadExistingCasePanel_Load(object sender, EventArgs e)
        {
            Dock = DockStyle.Fill;
            uiPasswordTextBox.Focus();
            InitialiseFileDetailFields();
            BackgroundWorker backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += BackgroundWorker_DoWork;
            backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;
            backgroundWorker.RunWorkerAsync();

        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string result = e.Result.ToString();
            uiFileHashTextBox.Text = result;
            uiHashProgressBar.Visible = false;
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = OsirtHelper.GetFileHash(file.FullName);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
         
        }

        private void uiOpenCaseButton_Click(object sender, EventArgs e)
        {
            //Check password zip: http://stackoverflow.com/questions/30071304/how-to-check-if-file-is-password-protected-password-passed-by-user-is-correct

            string enteredPassword = uiPasswordTextBox.Text;
            string hash = SecurePasswordHasher.Hash(enteredPassword);
            if (ZipFile.CheckZipPassword(file.FullName, enteredPassword))
            {
                //TODO: does verify know the salt?
                //TODO: Use the background worker
                //var result = SecurePasswordHasher.Verify(enteredPassword, hash);
                //store the hash in the database so we can validate it at the end.
                //extract archive to current location
                PasswordCheckClick?.Invoke(this, e);
            }
            else
            {
                MessageBox.Show("BAD PASSWORD");
                //5 strikes and close that app for security?
            }


        }
    }
}
