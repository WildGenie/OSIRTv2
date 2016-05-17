using System;
using System.ComponentModel;
using System.Windows.Forms;
using OSIRT.Loggers;
using Ionic.Zip;
using System.Diagnostics;
using System.IO;
using OSIRT.Helpers;

namespace OSIRT.UI.CaseClosing
{
    public partial class CaseClosingCleanUpPanel : UserControl
    {

        private BackgroundWorker backgroundWorker;
        private bool isReportView;

        public CaseClosingCleanUpPanel(string password, bool isReportView) 
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            uiInfoLabel.Text = "Cleaning up... Please Wait";
            this.isReportView = isReportView;
            backgroundWorker = new BackgroundWorker();
            backgroundWorker.WorkerSupportsCancellation = true;
            backgroundWorker.DoWork += BackgroundWorker_DoWork;
            backgroundWorker.ProgressChanged += BackgroundWorker_ProgressChanged;
            backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;
            backgroundWorker.RunWorkerAsync(password);
        }


        public CaseClosingCleanUpPanel(string password) : this(password, false)
        {
           
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            OsirtLogWriter.Write(Constants.ContainerLocation, true);
            Application.Exit();
        }

        private void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
         
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            CleanUp(e.Argument.ToString());
        }

        private void CleanUp(string password)
        {

            if (UserSettings.Load().ClearCacheOnClose)
            {
                WebBrowserHelper.ClearCache();
                UpdateLabel("Deleting browser cache... Please Wait");
            }

            //Need this log here, as database entry.
            if(isReportView)
                Logger.Log(new OsirtActionsLog(Enums.Actions.CaseClosed, $"[Case closed - Hash exported]", Constants.CaseContainerName));
            UpdateLabel("Encrypting container... Please Wait");
            ZipContainer(password);
            if (isReportView)
            {
                UpdateLabel("Hashing case container... Please Wait");
                HashCase();
            }
            UpdateLabel("Performing clean up operations... Please Wait");
            CleanUpDirectories();
            DeleteImageMagickFiles();
            //TODO: check cache to make sure all deleted, too
        }

        private void UpdateLabel(string message)
        {
            System.Threading.Thread.Sleep(600);
            Invoke((MethodInvoker)(() => uiInfoLabel.Text = message));
        }

        private void CleanUpDirectories()
        {
            int attempts = 0;
            Timer timer = new Timer { Interval = 1000 };
            timer.Start();
            timer.Tick += (s, e) => 
            {
                attempts++;
                string directory = Path.Combine(Constants.CasePath, Constants.CaseContainerName);
                if (!Directory.Exists(directory) || attempts == 5) timer.Stop();
            };
        }

        private void DeleteImageMagickFiles()
        {
            string[] files = Directory.GetFiles(Path.GetTempPath(), "magick-*");

            foreach (string file in files)
                File.Delete(file);

        }

        private void HashCase()
        {
            string hash = OsirtHelper.GetFileHash(Path.Combine(Constants.CasePath, Constants.CaseContainerName + Constants.ContainerExtension));
            File.WriteAllText(Path.Combine(UserSettings.Load().HashExportLocation, Constants.ExportedHashFileName.Replace("%%dt%%", $"{DateTime.Now.ToString("yyyy-MM-dd_hh_mm_ss")}" )), hash);
        }

        private void ZipContainer(string password)
        {
            using (ZipFile zip = new ZipFile())
            {
                if (password.Length > 0)
                {
                    zip.Password = password;
                    zip.Encryption = EncryptionAlgorithm.WinZipAes256;
                }
                //else
                //{
                    //zip.Password = "";  <--- NO, DON'T DO THIS!
                    //empty string password means it can't be opened in Windows
                    //Just don't use a password AT ALL!
               //}


                zip.AddDirectory(Constants.ContainerLocation, Constants.CaseContainerName);
                zip.Save(Path.Combine(Constants.CasePath, Constants.CaseContainerName + Constants.ContainerExtension));
            }
        }

        private void uiInfoLabel_SizeChanged(object sender, EventArgs e)
        {
            uiInfoLabel.Left = (groupBox.Width - uiInfoLabel.Size.Width) / 2;
        }
    }
}
