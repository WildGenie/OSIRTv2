using OSIRT.Enums;
using OSIRT.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSIRT.UI.DownloadClient
{
    public partial class DownloadForm : Form
    {
        private string downloadPath;
        private Actions action;

        public DownloadForm(string pathToDownload, Actions action)
        {
            InitializeComponent();
            downloadPath = pathToDownload;
            this.action = action;
        }

        private void StartDownload()
        {
            WebClient client = new WebClient();
            client.DownloadProgressChanged += Client_DownloadProgressChanged;
            client.DownloadFileCompleted += Client_DownloadFileCompleted;

            //string savePath = Path.Combine(Constants.ContainerLocation, Constants.Directories.GetSpecifiedCaseDirectory(action), "test");
            client.DownloadFileAsync(new Uri(downloadPath),  @"D:/test");
        }

        private void Client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            //Log it (webpage action)
            //perhaps fire event and let calling class handle what to do.
        }

        private void Client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            uiDownloadProgressBar.Value = e.ProgressPercentage;
        }

        private void DownloadForm_Load(object sender, EventArgs e)
        {

        }
    }
}
