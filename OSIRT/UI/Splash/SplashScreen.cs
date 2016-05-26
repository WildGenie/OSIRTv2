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
            //check log to see if closed properly (background worker)
        }

        private  void SplashScreen_Load(object sender, EventArgs e)
        {
            var backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork +=  delegate
            {

                Thread.Sleep(3500);
                string[] log =  OsirtLogWriter.ReadLog();
                if (!Convert.ToBoolean(log[1]))
                {
                    if (!File.Exists(log[0] + ".osr"))
                    {
                        backgroundWorker.ReportProgress(10, $"Archiving {log[0] + ".osr"}");
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
