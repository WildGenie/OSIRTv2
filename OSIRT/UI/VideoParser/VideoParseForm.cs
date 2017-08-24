using OSIRT.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        public string DownloadUrl { get { return uiUrlTextBox.Text.Trim(); } }

        public VideoParseForm()
        {
            InitializeComponent();
        }

        private void VideoParseForm_Load(object sender, EventArgs e)
        {

        }

        private void uiUrlTextBox_TextChanged(object sender, EventArgs e)
        {
            if(OsirtHelper.IsOnFacebook(DownloadUrl))
            {
                uiDownloadButton.Enabled = true;
            }
        }

        private void uiDownloadButton_Click(object sender, EventArgs e)
        {
            string videoUrl = DownloadUrl;
            string url;
            try
            {
                using (WebClient wc = new WebClient())
                {
                    wc.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/60.0.3112.101 Safari/537.36");
                    string source = wc.DownloadString(videoUrl);

                    int hdLoc = source.IndexOf("hd_src:");
                    int sdLoc = source.IndexOf(",sd_src:");
                    int length = sdLoc - hdLoc;
                    url = source.Substring(hdLoc, length);
                    url = Regex.Match(url, "\"([^\"]*)\"").ToString().Replace("\"", "");
                }

                using (WebClient downloader = new WebClient())
                {
                    //TODO: check this is writing to cache
                    //open it in video previewer
                    //what happens if user is using the screen recorder?
                    downloader.DownloadFileAsync(new Uri(url), Constants.TempVideoFile);
                    downloader.DownloadProgressChanged += Downloader_DownloadProgressChanged;
                }
            }
            catch
            {
                MessageBox.Show("Unable to download this video.", "Error downloading video", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Downloader_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            uiDownloadProgressBar.Value = e.ProgressPercentage;
        }
    }
}
