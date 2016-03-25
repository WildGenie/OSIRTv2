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
using Jacksonsoft;

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
            uiPasswordTextBox.UseSystemPasswordChar = true;
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

            bool isCorrectPassword = (bool) WaitWindow.Show(VerifyPassword, "Verifying password... Please Wait", enteredPassword);

            if (isCorrectPassword)
            {
                //var result = SecurePasswordHasher.Verify(enteredPassword, hash);
                //TODO: store the hash in the database so we can validate it at the end. (Put the in waitwindow)

                //string hash = SecurePasswordHasher.Hash(enteredPassword);
                WaitWindow.Show(LoadCase, "Extracting case... Please Wait", enteredPassword);
                PasswordCheckClick?.Invoke(this, e);
            }
            else
            {
                MessageBox.Show("BAD PASSWORD");
            }
    
        }

        private void VerifyPassword(object sender, WaitWindowEventArgs e)
        {
            string password = e.Arguments[0].ToString();
            e.Result = ZipFile.CheckZipPassword(file.FullName, password);
        }

        private void LoadCase(object sender, WaitWindowEventArgs e)
        {
            string password = e.Arguments[0].ToString();

            //TODO: tidy this, just a test.
            DirectoryInfo parentDir = Directory.GetParent(file.FullName);
            using (ZipFile zip = ZipFile.Read(file.FullName))
            {
                zip.Password = password;
                zip.ExtractAll(parentDir.FullName, ExtractExistingFileAction.OverwriteSilently);
            }

            try
            {
                //TODO: disabled for testing. Remember to re-enable.
                //File.Delete(filenameWithPath);
            }
            catch (IOException io)
            {
                MessageBox.Show($"unable to delete: {io}");
            }

            Constants.CasePath = parentDir.FullName;
            Constants.CaseContainerName = Path.GetFileName(file.FullName.Replace(".osr", ""));
        }


    }
}
