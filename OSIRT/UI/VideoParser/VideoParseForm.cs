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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSIRT.UI.VideoParser
{
    public partial class VideoParseForm : Form
    {

        public event EventHandler VideoDownloadComplete;

        public string DownloadUrl { get { return uiUrlTextBox.Text.Trim(); } }

        public VideoParseForm()
        {
            InitializeComponent();
        }

        private void VideoParseForm_Load(object sender, EventArgs e)
        {
            uiPercentageLabel.Parent = uiDownloadProgressBar;
            uiDownloadProgressBar.Visible = false;
        }

        private void uiUrlTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void uiDownloadButton_Click(object sender, EventArgs e)
        {

            if(!OsirtHelper.IsOnFacebook(DownloadUrl))
            {
                MessageBox.Show("The download URL does not appear to be a Facebook video URL.", "Invalid Facebook Video URL", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            uiDownloadProgressBar.Visible = true;
            uiCancelButton.Enabled = false;
            string videoUrl = DownloadUrl;
            string url;
            try
            {
                using (WebClient wc = new WebClient())
                {
                    wc.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/60.0.3112.101 Safari/537.36");

                    //get page source from the url entered
                    string source = wc.DownloadString(videoUrl);
                    //simply parse the page source looking for simple tokens.
                    int hdLoc = source.IndexOf("hd_src:");
                    int sdLoc = source.IndexOf(",sd_src:");
                    int length = sdLoc - hdLoc;
                    url = source.Substring(hdLoc, length);
                    //find everything between quotes, in this case the Url
                    url = Regex.Match(url, "\"([^\"]*)\"").ToString().Replace("\"", "");
                }

                using (WebClient downloader = new WebClient())
                {
                    //need to rethink the video file in cache, could have multiple videos saving there
                    //need video recovery

                    string facebookVideoLocation = Path.Combine(Constants.VideoCacheLocation, "temp_facebook_vid.mp4");

                    downloader.DownloadFileAsync(new Uri(url), facebookVideoLocation);
                    downloader.DownloadProgressChanged += Downloader_DownloadProgressChanged;
                    downloader.DownloadFileCompleted += Downloader_DownloadFileCompleted;
                }
            }
            catch
            {
                MessageBox.Show("Unable to download this video. Make sure a valid video URL is entered.", "Error downloading video", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Downloader_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            uiDownloadProgressBar.Visible = false;
            uiCancelButton.Enabled = true;
            VideoDownloadComplete?.Invoke(this, EventArgs.Empty);
            DialogResult = DialogResult.OK;
        }

        private void Downloader_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            uiDownloadProgressBar.Value = e.ProgressPercentage;
            //uiPercentageLabel.Text = e.ProgressPercentage.ToString() + "%";
        }

    }
}
