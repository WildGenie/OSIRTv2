using OSIRT.Enums;
using OSIRT.Helpers;
using OSIRT.Loggers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
        private int count;
        private int numFiles;

        public DownloadForm(Dictionary<string, string> files, Actions action)
        {
            InitializeComponent();
            this.files = files;
            this.action = action;
            numFiles = files.Count;
        }

        private void Download()
        {
            filename = files.First().Value;
            savePath = Path.Combine(Constants.ContainerLocation, Constants.Directories.GetSpecifiedCaseDirectory(action), filename);
            url = files.First().Key;

            Debug.WriteLine("FILENAME: " + filename);
            try
            {
                client.DownloadFileAsync(new Uri(url), savePath);
                count++;
            }
            catch (Exception e)
            {
                count++;
            }
        }

        private void StartDownload()
        {
            client = new WebClient();
            client.DownloadProgressChanged += Client_DownloadProgressChanged;
            client.DownloadFileCompleted += Client_DownloadFileCompleted;

            if (files.Count > 0)
            {
                Download();
            }
        }





        private void Client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            Logger.Log(new WebpageActionsLog(url, action, OsirtHelper.GetFileHash(savePath), filename, @"[N/A]"));

            files.Remove(files.First().Key);
            if (files.Count > 0)
            {
                Download();
            }
        }

        private void Client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            uiDownloadProgressBar.Value = e.ProgressPercentage;
            uiFileLabel.Text = $"Downloading { filename }";
            uiCompleteLabel.Text = $"Downloading {count} of {numFiles} images";
        }

        private void DownloadForm_Load(object sender, EventArgs e)
        {
           
        }

        private void DownloadForm_Shown(object sender, EventArgs e)
        {
            StartDownload();
        }

        private void uiCompleteLabel_SizeChanged(object sender, EventArgs e)
        {
            uiCompleteLabel.Left = (ClientSize.Width - uiCompleteLabel.Size.Width) / 2;
        }
    }
}
