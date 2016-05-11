using OSIRT.Enums;
using OSIRT.Helpers;
using OSIRT.Loggers;
using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.IO;
using System.Linq;
using System.Net;

using System.Windows.Forms;

namespace OSIRT.UI.DownloadClient
{
    public partial class DownloadForm : Form
    {
        private Dictionary<string, string> files;
        private Actions action;
        private string savePath;
        private string filename;
        private string url;
        private WebClient client;

        public object Debug { get; private set; }

        public DownloadForm(Dictionary<string, string> files, Actions action)
        {
            InitializeComponent();
            this.files = files;
            this.action = action;
        }

        private void StartDownload()
        {
            //TODO: refactor this
            if(files.Count > 0)
            {
                client = new WebClient();
                client.DownloadProgressChanged += Client_DownloadProgressChanged;
                client.DownloadFileCompleted += Client_DownloadFileCompleted;

                savePath = Path.Combine(Constants.ContainerLocation, Constants.Directories.GetSpecifiedCaseDirectory(action), files.First().Value);
                url = files.First().Key;
                filename = files.First().Value;
                client.DownloadFileAsync(new Uri(url), savePath);
            }
        }





        private void Client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            Logger.Log(new WebpageActionsLog(url, action, OsirtHelper.GetFileHash(savePath), filename, @"[N/A]"));

            files.Remove(files.First().Key);
            if (files.Count > 0)
            {
                client.DownloadFileAsync(new Uri(files.First().Key), savePath);
                filename = files.First().Value;
            }
        }

        private void Client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            uiDownloadProgressBar.Value = e.ProgressPercentage;
            uiFileLabel.Text = $"Downloading { filename }";
            uiCompleteLabel.Text = $"Downloading [9] of [100] images";
        }

        private void DownloadForm_Load(object sender, EventArgs e)
        {
           
        }

        private void DownloadForm_Shown(object sender, EventArgs e)
        {
            StartDownload();
        }
    }
}
