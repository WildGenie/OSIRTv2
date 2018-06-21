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
            uiDownloadButton.Enabled = false;
            string videoLocation = Path.Combine(Constants.VideoCacheLocation, "temp_video_download.mp4");
            string url = uiUrlTextBox.Text;

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

                if (status == "Done" || info.VideoProgress == 100)
                {
                    this.InvokeIfRequired(() => uiDownloadButton.Enabled = true);
                    this.InvokeIfRequired(() => uiStatusLabel.Text = "Status: Download complete. Processing video.");
                    if (!hasFired) //this can fire multiple times, so stop it from happening with flag. Need to reset after download completed! 
                    {
                        VideoDownloadComplete?.Invoke(this, EventArgs.Empty);
                        hasFired = true;
                    }
                }
            };
            youtubeDl.DownloadAsync();
        }

        private void VideoDownloader_Load(object sender, EventArgs e)
        {

        }
    }
}
