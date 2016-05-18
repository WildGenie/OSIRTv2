using Ionic.Zip;
using OSIRT.Helpers;
using OSIRT.Loggers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSIRT.UI.CaseClosing
{
    public class CaseCleanUpLogic
    {
        private BackgroundWorker backgroundWorker;
        private string password;
        public event EventHandler ReportProgress;
        private bool isInAuditViewMode;


        public CaseCleanUpLogic(string password, bool isInAuditViewMode)
        {
            this.password = password;
            this.isInAuditViewMode = isInAuditViewMode;
            backgroundWorker = new BackgroundWorker();
            backgroundWorker.WorkerSupportsCancellation = true;
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.DoWork += BackgroundWorker_DoWork;
            backgroundWorker.ProgressChanged += BackgroundWorker_ProgressChanged;
            backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;
           
        }

        public void Start()
        {
            backgroundWorker.RunWorkerAsync(password);
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            OsirtLogWriter.Write(Constants.ContainerLocation, true);
            Application.Exit();
        }

        private void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ReportProgress?.Invoke(this, e);
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (UserSettings.Load().ClearCacheOnClose)
            {
                (sender as BackgroundWorker).ReportProgress(10, "Deleting IE Cache... Please Wait");
                CleanInternetExporerCache();
            }
            if(!isInAuditViewMode) //Still getting logged due to this logic also exisitng in the MainForm close method
                Logger.Log(new OsirtActionsLog(Enums.Actions.CaseClosed, $"[Case closed - Hash exported]", Constants.CaseContainerName));

            (sender as BackgroundWorker).ReportProgress(10, "Archiving Case... Please Wait");
            ZipContainer(password);

            (sender as BackgroundWorker).ReportProgress(10, "Performing Clean Up Operations... Please Wait");
            DeleteImageMagickFiles();

            int attempts = 0;
            while (CleanUpDirectories())
            {
                if (++attempts > 10) break;
            }
        }

        private void CleanUp(BackgroundWorker bw, string password)
        {
       
        }

        private void UpdateProgress(BackgroundWorker bw, int percentage, string message)
        {
            //Debug.WriteLine("--------- IN REPORT -------" + message);
            //backgroundWorker.ReportProgress(percentage, message);
        } 

        public void CleanInternetExporerCache()
        {
            WebBrowserHelper.ClearCache();
        }

        public bool CleanUpDirectories()
        {
            //int attempts = 0;
            //Timer timer = new Timer { Interval = 1000 };

            //timer.Start();
            ////Timer.Tick is not effective!
            //timer.Tick += (s, e) =>
            //{
                //attempts++;
            string directory = Path.Combine(Constants.CasePath, Constants.CaseContainerName);
            OsirtHelper.DeleteDirectory(directory);
            return Directory.Exists(directory);
                //if (!Directory.Exists(directory) || attempts == 5) timer.Stop();
            //};
        }

        public void DeleteImageMagickFiles()
        {
            string[] files = Directory.GetFiles(Path.GetTempPath(), "magick-*");

            foreach (string file in files)
                File.Delete(file);

        }

        private void HashCase()
        {
            string hash = OsirtHelper.GetFileHash(Path.Combine(Constants.CasePath, Constants.CaseContainerName + Constants.ContainerExtension));
            File.WriteAllText(Path.Combine(UserSettings.Load().HashExportLocation, Constants.ExportedHashFileName.Replace("%%dt%%", $"{DateTime.Now.ToString("yyyy-MM-dd_hh_mm_ss")}")), hash);
        }


        public void ZipContainer(string password)
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


    }
}
