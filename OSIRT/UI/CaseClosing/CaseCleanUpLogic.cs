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
            //don't want to exit if we're just shutting a case down.
            Application.Exit();
        }

        private void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ReportProgress?.Invoke(this, e);
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            string caseClosed = "[Case closed";
            caseClosed += UserSettings.Load().HashContainerOnClose ? "- Hash exported]" : "]" ;

            if(!isInAuditViewMode) //Still getting logged due to this logic also exisitng in the MainForm close method
                Logger.Log(new OsirtActionsLog(Enums.Actions.CaseClosed, caseClosed, Constants.CaseContainerName));

            (sender as BackgroundWorker).ReportProgress(10, "Archiving Case... Please Wait");
            ZipContainer(password);
            if (UserSettings.Load().ExportHashOnClose)
            {
                HashCase();
            }
            (sender as BackgroundWorker).ReportProgress(10, "Performing Clean Up Operations... Please Wait");
            //StopCapture();
            DeleteImageMagickFiles();
            ImageDiskCache.RemoveItemsInCache();
            ImageDiskCache.RemoveSpecificItemFromCache(Constants.TempVideoFile);
            TorCleanUp();
            WriteFavourites();
            int attempts = 0;
            while (CleanUpDirectories())
            {
                if (++attempts > 10) break;
            }
        }

        private void WriteFavourites()
        {
            string[] lines = OsirtHelper.Favourites.Select(kvp => kvp.Key + "=" + kvp.Value).ToArray();
            File.WriteAllLines(Constants.Favourites, lines);
        }

        private void StopCapture()
        {
            if(VideoCapture.OsirtVideoCapture.IsRecording()) VideoCapture.OsirtVideoCapture.StopCapture();
        }

        private void CleanUp(BackgroundWorker bw, string password)
        {
       
        }

        private void UpdateProgress(BackgroundWorker bw, int percentage, string message)
        {
            //Debug.WriteLine("--------- IN REPORT -------" + message);
            //backgroundWorker.ReportProgress(percentage, message);
        } 

        private void TorCleanUp()
        {
            Process[] previous = Process.GetProcessesByName("tor");
            if (previous != null && previous.Length > 0)
            {
                foreach (Process process in previous)
                    process.Kill();
            }
        }


        public bool CleanUpDirectories()
        {
            string directory = Path.Combine(Constants.CasePath, Constants.CaseContainerName);
            OsirtHelper.DeleteDirectory(directory);
            return Directory.Exists(directory);
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
            try
            {
                File.WriteAllText(Path.Combine(UserSettings.Load().HashExportLocation, Constants.ExportedHashFileName.Replace("%%dt%%", $"{DateTime.Now.ToString("yyyy-MM-dd_hh_mm_ss")}")), hash);
            }
            catch (Exception e)
            {
                File.WriteAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), Constants.ExportedHashFileName.Replace("%%dt%%", $"{DateTime.Now.ToString("yyyy-MM-dd_hh_mm_ss")}")), hash);
            }
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
