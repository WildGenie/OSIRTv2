using Ionic.Zip;
using OSIRT.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSIRT.UI.Splash
{
    public partial class SplashScreen : Form
    {
        public event EventHandler CaseChecked = delegate { };


        public SplashScreen()
        {
            InitializeComponent();
        }

        private  void SplashScreen_Load(object sender, EventArgs e)
        {
            var backgroundWorker = new BackgroundWorker();
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.DoWork +=  delegate
            {
                Thread.Sleep(3500);
                string[] log = OsirtLogWriter.ReadLog();
                string path = log[0];

                if (!Convert.ToBoolean(log[1]))
                {
                    bool fileExists = !File.Exists(path + ".osr");
                    if (!fileExists)
                    {
                        backgroundWorker.ReportProgress(10, $"Previous Case not closed successfully. Re-Archiving: {log[0] + Constants.ContainerExtension}");
                        using (ZipFile zip = new ZipFile())
                        {
                            //if (password.Length > 0)
                            //{
                            //    zip.Password = password;
                            //    zip.Encryption = EncryptionAlgorithm.WinZipAes256;
                            //}
                            zip.AddDirectory(path);
                            zip.Save(Path.Combine(Directory.GetParent(path).FullName, Path.GetFileName(path) + Constants.ContainerExtension));
                        }

                        //Dear idiot, don't recursively delete your desktop again like a moron.
                        //Directory.Delete(Directory.GetParent(path).FullName, true);
                    }
                }
            };
            backgroundWorker.ProgressChanged += BackgroundWorker_ProgressChanged;
            backgroundWorker.RunWorkerCompleted += delegate
            {
                CaseChecked?.Invoke(this, e);
                Close();
            };
            backgroundWorker.RunWorkerAsync();
        }

        private void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            uiProgressLabel.Text = e.UserState.ToString();
        }
    }
}
