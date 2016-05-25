using OSIRT.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeExtractor;

namespace OSIRT
{
    public class YouTubeVideoDownloader
    {

        private string Url;
        public event EventHandler DownloadProgress = delegate { };
        public event EventHandler DownloadComplete = delegate { };

        public YouTubeVideoDownloader(string url)
        {
            Url = url;
        }

        public void Download()
        {
            IEnumerable<VideoInfo> videoInfos = DownloadUrlResolver.GetDownloadUrls(Url);

            /*
             * Select the first .mp4 video with 360p resolution
             */
            VideoInfo video = videoInfos
                .First(info => info.VideoType == VideoType.Mp4 && info.Resolution == 360);

            if (video.RequiresDecryption)
            {
                DownloadUrlResolver.DecryptDownloadUrl(video);
            }

            //TODO: check this path! Video names could have a "/" (slash) in them. For example: Joe w/ [shortent with] Jen

            
            var videoDownloader = new VideoDownloader(video, Constants.TempVideoFile);

            // Register the ProgressChanged event and print the current progress
            videoDownloader.DownloadProgressChanged += VideoDownloader_DownloadProgressChanged;
            videoDownloader.DownloadFinished += VideoDownloader_DownloadFinished;
            videoDownloader.Execute(); //this is synchronous
        }

        private void VideoDownloader_DownloadFinished(object sender, EventArgs e)
        {
            DownloadComplete?.Invoke(this, e);
        }

        private void VideoDownloader_DownloadProgressChanged(object sender, ProgressEventArgs e)
        {
            //Debug.WriteLine(e.ProgressPercentage);
            DownloadProgress?.Invoke(this, e);
        }
    }
}
