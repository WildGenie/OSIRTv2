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


        public CaseClosingCleanUpPanel(string password)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            uiInfoLabel.Text = "Cleaning up... Please Wait";
            backgroundWorker = new BackgroundWorker();
            backgroundWorker.WorkerSupportsCancellation = true;
            backgroundWorker.DoWork += BackgroundWorker_DoWork;
            backgroundWorker.ProgressChanged += BackgroundWorker_ProgressChanged;
            backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;
            backgroundWorker.RunWorkerAsync(password);
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //throw new NotImplementedException();
            //case closed sucessfully message
            //close application... Fire event?
            Application.Exit();
        }

        private void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            CleanUp(e.Argument.ToString());
        }

        private void CleanUp(string password)
        {
            
            UpdateLabel("Deleting browser cache... Please Wait");
            DeleteCache();
            //Need this log here, as database entry.
            Logger.Log(new OsirtActionsLog(Enums.Actions.CaseClosed, $"[Case Closed - Hash exported as {Constants.CaseContainerName}_hash.txt", Constants.CaseContainerName));
            UpdateLabel("Encrypting container... Please Wait");
            ZipContainer(password);
            UpdateLabel("Hashing case container... Please Wait");
            HashCase();
            UpdateLabel("Performing clean up operations... Please Wait");
            CleanUpDirectories();
        }

        private void UpdateLabel(string message)
        {
            System.Threading.Thread.Sleep(600);
            Invoke((MethodInvoker)(() => uiInfoLabel.Text = message));
        }

        private void CleanUpDirectories()
        {

            //TODO: A handle is being left on the directory... What to do?
            //Or is it? Could be the WaitWindow, you know... Use background worker to test!
            //Idea: Have a timer, let it run for, say, 10 seconds and auto shut down app

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

        private void DeleteCache()
        {
            //TODO: clear IE cache if required
        }

        private void HashCase()
        {
            //TODO: have hash save location as an option
            string hash = OsirtHelper.GetFileHash(Path.Combine(Constants.CasePath, Constants.CaseContainerName + Constants.ContainerExtension));
            File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + $"\\{Constants.CaseContainerName}_hash.txt", hash);
        }

        private void ZipContainer(string password)
        {
            using (ZipFile zip = new ZipFile())
            {

                //zip.Password = password;
                //zip.Encryption = password != "" ? EncryptionAlgorithm.WinZipAes256 : EncryptionAlgorithm.None;


                if (password != "")
                {
                    zip.Password = password;
                    zip.Encryption = EncryptionAlgorithm.WinZipAes256;
                }
                else
                {
                    zip.Password = ""; //need to ensure blank password is reset
                }


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
