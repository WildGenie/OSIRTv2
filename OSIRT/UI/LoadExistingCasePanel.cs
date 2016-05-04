using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using OSIRT.Helpers;
using Ionic.Zip;
using Jacksonsoft;
using OSIRT.Database;
using OSIRT.Loggers;
using OSIRT.Enums;

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
            //We haven't extracted the case container, so we don't know the user setting.
            //We'll use SHA512 as the default for hashing and verifying containers.
            e.Result = OsirtHelper.GetFileHash(file.FullName, "SHA512");
        }


        private void uiOpenCaseButton_Click(object sender, EventArgs e)
        {
          
            //TODO: use secure string?
            string enteredPassword = uiPasswordTextBox.Text;
            bool isCorrectPassword = (bool) WaitWindow.Show(VerifyPassword, "Verifying password... Please Wait", enteredPassword);

            if (isCorrectPassword)
            {
                WaitWindow.Show(LoadCase, "Extracting case... Please Wait", enteredPassword);
                PasswordCheckClick?.Invoke(this, e);
            }
            else
            {
                uiInvalidPasswordLabel.Visible = true;
                uiPasswordTextBox.Focus();
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
            DirectoryInfo parentDir = Directory.GetParent(file.FullName);
            using (ZipFile zip = ZipFile.Read(file.FullName))
            {
                zip.Password = password;
                //zip.Encryption = EncryptionAlgorithm.WinZipAes256;
                zip.ExtractAll(parentDir.FullName, ExtractExistingFileAction.OverwriteSilently);
            }

            try
            {
                File.Delete(file.FullName);
            }
            catch (IOException io)
            {
                MessageBox.Show($"Unable to delete: {io}");
            }

            Constants.CasePath = parentDir.FullName;
            Constants.CaseContainerName = Path.GetFileName(file.FullName.Replace(".osr", ""));

            e.Window.Message = "Re-encrypting password... Please Wait";
            string hash = SecurePasswordHasher.Hash(password);
            UpdateCaseTableWithPassword(hash);

            //TODO: put the hash as a property rather than directly from textbox
            Logger.Log(new OsirtActionsLog(Actions.CaseLoaded, uiFileHashTextBox.Text, Constants.CaseContainerName));

        }

        private void UpdateCaseTableWithPassword(string hash)
        {
            DatabaseHandler dbHandler = new DatabaseHandler();
            dbHandler.ExecuteNonQuery($"UPDATE case_details SET hashed_password = '{hash}'");
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void uiWhySha512Label_Click(object sender, EventArgs e)
        {
            string message = "When the case is loaded and closed, OSIRT uses SHA512 to verify the integrity of the container. This ignores the user setting for specified hashing algorithm in this instance.";
            MessageBox.Show(message, "Why SHA512?", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
