using NYoutubeDL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OSIRT.Extensions;
using NYoutubeDL.Models;
using OSIRT.Helpers;
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace OSIRT.UI
{
    public partial class VideoDownloader : Form
    {
        private YoutubeDL youtubeDl;
        private bool hasFired = false;
        public event EventHandler VideoDownloadComplete = delegate { };

        public VideoDownloader()
        {
            InitializeComponent();
        }

        private  void UiDownloadButton_Click(object sender, EventArgs e)
        {
            string url = uiUrlTextBox.Text;
            if (String.IsNullOrWhiteSpace(url))
            {
                MessageBox.Show("Please enter a video URL", "No URL Entered", MessageBoxButtons.OK, MessageBoxIcon.Error);
                uiUrlTextBox.Focus();
                return;
            }

            uiDownloadButton.Enabled = false;
            string videoLocation = Path.Combine(Constants.VideoCacheLocation, "temp_video_download.mp4");
            this.InvokeIfRequired(() => uiStatusLabel.Text = "Starting download... Please wait as this can take a few seconds to start.");

            try
            {
                youtubeDl = new YoutubeDL
                {
                    YoutubeDlPath = "youtube-dl.exe",
                    VideoUrl = url,        
                };
                youtubeDl.Options.FilesystemOptions.Output = videoLocation;
                youtubeDl.Options.GeneralOptions.IgnoreErrors = true;
                youtubeDl.PrepareDownload();

                youtubeDl.Info.PropertyChanged += (o, args) =>
                {
                    DownloadInfo info = (DownloadInfo)o;
                    string status = info.Status;
                    this.InvokeIfRequired(() => uiDownloadProgressBar.Value = info.VideoProgress);
                    this.InvokeIfRequired(() => uiStatusLabel.Text = $"Status: {status} Video size: {info.VideoSize} Download speed: {info.DownloadRate} ETA: {info.Eta}");

                    if (status == "Error")
                    {
                        this.InvokeIfRequired(() => uiStatusLabel.Text = "Error downloading video.");
                        this.InvokeIfRequired(() => uiDownloadButton.Enabled = true);
                        youtubeDl.KillProcess();
                    }

                    if (status == "Done" || info.VideoProgress == 100)
                    {
                        this.InvokeIfRequired(() => uiDownloadButton.Enabled = true);
                        this.InvokeIfRequired(() => uiStatusLabel.Text = "Status: Download complete. Processing video.");
                        if (!hasFired) //this can fire multiple times, so stop it from happening with flag. Need to reset after download completed! 
                    {
                            hasFired = true;
                            youtubeDl.KillProcess();
                            VideoDownloadComplete?.Invoke(this, EventArgs.Empty);
                            this.InvokeIfRequired(() => Close());
                        }
                    }
                };
                youtubeDl.DownloadAsync();
            }
            catch(ArgumentOutOfRangeException)
            {
                MessageBox.Show("An error has occured attempting to download this video.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void VideoDownloader_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                byte[] pdf = Properties.Resources.video_downloader_instructions;
                MemoryStream ms = new MemoryStream(pdf);
                FileStream f = new FileStream("help.pdf", FileMode.OpenOrCreate);

                ms.WriteTo(f);
                f.Close();
                ms.Close();

                Process.Start("help.pdf");

            }
            catch { MessageBox.Show("Unable to open help file. No PDF reader installed or set as default."); }
        }
    }
}
