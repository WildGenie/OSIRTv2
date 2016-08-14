using Jacksonsoft;
using Microsoft.Win32;
using mshtml;
using OSIRT.Browser.DownloadManager;
using OSIRT.Helpers;
using OSIRT.Loggers;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Net;
using OSIRT.Extensions;
using OSIRT.UI.DownloadClient;
using OSIRT.UI.ViewSource;
using OSIRT.UI;
using CefSharp.WinForms;
using System.Threading;
using System.Drawing.Imaging;
using CefSharp;

namespace OSIRT.Browser
{
    public class ExtendedBrowser : ChromiumWebBrowser
    {
        public event EventHandler ScreenshotCompleted = delegate { };
        public event EventHandler DownloadingProgress = delegate { };
        public event EventHandler DownloadComplete = delegate { };
        public event EventHandler NewTab = delegate { };
        public event EventHandler ViewPageSource = delegate { };
        public event EventHandler SavePageSource = delegate { };
        public event EventHandler OpenNewTabContextMenu = delegate { };
        public event EventHandler YouTubeDownloadProgress = delegate { };
        public event EventHandler YouTubeDownloadComplete = delegate { };
        public event EventHandler OnLoadingStateChanged = delegate { };
        private int MaxScrollHeight => 15000;
        private readonly int MaxWait = 500;
        private PictureBox mouseTrail = new PictureBox();


        public ExtendedBrowser() : base(UserSettings.Load().Homepage)
        {
            InitialiseMouseTrail();
            var handler = new MenuHandler();
            handler.DownloadImage += Handler_DownloadImage;
            handler.ViewPageSource += Handler_ViewPageSource;
            handler.DownloadYouTubeVideo += Handler_DownloadYouTubeVideo;
            handler.ViewImageExif += Handler_ViewImageExif;
            handler.ViewFacebookIdNum += Handler_ViewFacebookIdNum;
            handler.OpenInNewTabContextMenu += Handler_OpenInNewTabContextMenu;
            MenuHandler = handler;
            MouseMove += ExtendedBrowser_MouseMove;
            LoadingStateChanged += ExtendedBrowser_LoadingStateChanged;
        }

        private void ExtendedBrowser_LoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
        {
            OnLoadingStateChanged?.Invoke(this, e);
        }

        private void Handler_OpenInNewTabContextMenu(object sender, EventArgs e)
        {
            OpenNewTabContextMenu?.Invoke(this, (NewTabEventArgs)e);
        }

        private async void Handler_ViewFacebookIdNum(object sender, EventArgs e)
        {
            string source = await GetBrowser().MainFrame.GetSourceAsync();
            this.InvokeIfRequired(() => new FacebookDetailsForm(source).Show());
        }

        private void Handler_ViewImageExif(object sender, EventArgs e)
        {
            string path = ((ExifViewerEventArgs)e).ImageUrl;
            WebClient webClientexif = new WebClient();
            string file = Path.Combine(Constants.CacheLocation, Path.GetFileName(OsirtHelper.StripQueryFromPath(path)));
            webClientexif.DownloadFileAsync(new Uri(path), file, file);
            webClientexif.DownloadFileCompleted += (snd, evt) =>
            {
               this.InvokeIfRequired(() =>  new ExifViewer(evt.UserState.ToString(), path).Show());
            };
        }

        private void ExtendedBrowser_MouseMove(object sender, MouseEventArgs e)
        {
            if (UserSettings.Load().ShowMouseTrail)
            {
                mouseTrail.Location = new Point(e.X + 5, e.Y + 5);
                Debug.WriteLine($"{e.X + 5} {e.Y + 5}");
            }
        }

        private async void Handler_ViewPageSource(object sender, EventArgs e)
        {
            string source = await GetBrowser().MainFrame.GetSourceAsync();
            this.InvokeIfRequired(() => new ViewPageSource(source, new Tuple<string, string, string>(new Uri(URL).Host.Replace(".", ""), URL, "")  ).Show());
        }

        private void Handler_DownloadImage(object sender, EventArgs e)
        {
            DownloadFile(((DownloadImageViaContextMenuEventArgs)e).Url);
        }

        public bool MouseTrailVisible
        {
            get
            {
                return mouseTrail.Visible;
            }
            set
            {
                mouseTrail.Visible = value;
            }

        }

        private void InitialiseMouseTrail()
        {
            mouseTrail.BackColor = Color.Green;
            mouseTrail.Size = new Size(12, 12);
            Controls.Add(mouseTrail);
            MouseTrailVisible = false;
        }



        private void Document_MouseUp(object sender, HtmlElementEventArgs e)
        {
            if (UserSettings.Load().ShowMouseClick)
                mouseTrail.BackColor = Color.Green;
        }


        /// <summary>
        /// Gets the current viewport of the browser
        /// </summary>
        /// <returns>A Bitmap of the current browser viewport</returns>
        private Bitmap GetCurrentViewScreenshot()
        {
            int width, height;
            width = ClientRectangle.Width;
            height = ClientRectangle.Height;
            using (Bitmap image = new Bitmap(width, height))
            {
                using (Graphics graphics = Graphics.FromImage(image))
                {
                    Point p, upperLeftDestination;
                    Point upperLeftSource = new Point(0, 0);
                    p = new Point(0, 0);
                    upperLeftSource = PointToScreen(p);
                    upperLeftDestination = new Point(0, 0);
                    Size blockRegionSize = ClientRectangle.Size;
                    graphics.CopyFromScreen(upperLeftSource, upperLeftDestination, blockRegionSize);

                }
                return new Bitmap(image);
            }
        }

        public void GetCurrentViewportScreenshot()
        {
            ScreenshotHelper.SaveScreenshotToCache(GetCurrentViewScreenshot());
            FireScreenshotCompleteEvent();
        }

        public async Task PutTaskDelay()
        {
            await Task.Delay(MaxWait);
        }

       private int GetDocHeight()
        {
            int scrollHeight = 0;
            var task = GetBrowser().MainFrame.EvaluateScriptAsync("(function() { var body = document.body, html = document.documentElement; return  Math.max( body.scrollHeight, body.offsetHeight, html.clientHeight, html.scrollHeight, html.offsetHeight ); })();", null);
            task.Wait();
            var response = task.Result;
            scrollHeight = (int)response.Result;
            return scrollHeight;
        }



        private async void FullpageScreenshotByScrolling()
        {
            int scrollHeight =  GetDocHeight();
            if (scrollHeight == 0)
                return;

            Enabled = false;
            int viewportHeight = ClientRectangle.Size.Height;
            int viewportWidth = ClientRectangle.Size.Width;
            await GetBrowser().MainFrame.EvaluateScriptAsync("(function() { document.documentElement.style.overflow = 'hidden'; })();");
            int count = 0;
            int pageLeft = scrollHeight;
            bool atBottom = false;
            Debug.WriteLine($"OUTSIDE --- PAGE LEFT: {pageLeft}. VIEWPORT HEIGHT: {viewportHeight}");
            ImageDiskCache cache = new ImageDiskCache();

            while (!atBottom)
            {
                if (pageLeft > viewportHeight)
                {
                    //if we can scroll using the viewport, let's do that
                    await GetBrowser().MainFrame.EvaluateScriptAsync("(function() { window.scroll(0," + (count * viewportHeight) + "); })();");
                    count++;
                    await PutTaskDelay();  //we do need these delays. Some pages, like facebook, may need to load viewport content.
                    using (Bitmap image = GetCurrentViewScreenshot())
                    {
                        cache.AddImage(count, image);
                    }
                    await GetBrowser().MainFrame.EvaluateScriptAsync("(function() { var elements = document.querySelectorAll('*'); for (var i = 0; i < elements.length; i++) { var position = window.getComputedStyle(elements[i]).position; if (position === 'fixed') { elements[i].style.visibility = 'hidden'; } } })(); ");
                }
                else 
                {
                    //find out what's left of the page to scroll, then take screenshot
                    //if it's the last image, we're going to need to crop what we need, as it'll take
                    //a capture of the entire viewport.

                    await GetBrowser().MainFrame.EvaluateScriptAsync("(function() { window.scrollBy(0," + pageLeft + "); })();");
                    atBottom = true;
                    count++;

                    await PutTaskDelay();
                    Rectangle cropRect = new Rectangle(new Point(0, viewportHeight - pageLeft), new Size(viewportWidth, pageLeft));

                    using (Bitmap src = GetCurrentViewScreenshot())
                    using (Bitmap target = new Bitmap(cropRect.Width, cropRect.Height))
                    using (Graphics g = Graphics.FromImage(target))
                    {
                        g.DrawImage(src, new Rectangle(0, 0, target.Width, target.Height), cropRect, GraphicsUnit.Pixel);
                        cache.AddImage(count, target);
                    }
                  
                }

                pageLeft = pageLeft - viewportHeight;
                Debug.WriteLine($"IN WHILE --- PAGE LEFT: {pageLeft}. VIEWPORT HEIGHT: {viewportHeight}");
            }//end while
            await GetBrowser().MainFrame.EvaluateScriptAsync("(function() { document.documentElement.style.overflow = 'auto'; })();");
            await GetBrowser().MainFrame.EvaluateScriptAsync("javascript:var s = function() { document.body.scrollTop = document.documentElement.scrollTop = 0;}; s();");
            await GetBrowser().MainFrame.EvaluateScriptAsync("(function() { var elements = document.querySelectorAll('*'); for (var i = 0; i < elements.length; i++) { var position = window.getComputedStyle(elements[i]).position; if (position === 'fixed') { elements[i].style.visibility = 'visible'; } } })(); ");
            Enabled = true;
            WaitWindow.Show(GetScreenshot, Resources.strings.CombineScreenshots);
            FireScreenshotCompleteEvent();
        }

        private void GetScreenshot(object sender, WaitWindowEventArgs e)
        {
            DirectoryInfo directory = new DirectoryInfo(Constants.CacheLocation);
            FileSystemInfo[] files = directory.GetFileSystemInfos();
            ScreenshotHelper.CombineScreenshot(files, e);
        }

        public string URL => Address;

        public void GenerateFullpageScreenshot()
        {
            try
            {
                FullpageScreenshotByScrolling();
            }
            catch
            {
                MessageBox.Show("Unable to take a full page capture. Please use video capture, snippet or current view screenshot.", "Cannot take fullpage screenshot", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                Dock = DockStyle.Fill;
            }

        }

        private void FireScreenshotCompleteEvent()
        {
            ScreenshotCompleted(this, new ScreenshotCompletedEventArgs());
        }


        private void DownloadAllImages_Click(object sender, EventArgs e)
        {
            var files = new WebImageDownloader(URL).GetSafeUrls();

            if (files.Count == 0)
            {
                MessageBox.Show("There are either no images to download from this page, or OSIRT is unable to download them.", "No Images to Download", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            using (var downloader = new DownloadForm(files, Enums.Actions.Scraped))
            {
                downloader.ShowDialog();
            }
        }



        #region YouTube downloading

        private async void Handler_DownloadYouTubeVideo(object sender, EventArgs e)
        {
            var downloader = new YouTubeVideoDownloader(URL);
            downloader.DownloadProgress += YouTubeDownloader_DownloadProgress;
            downloader.DownloadComplete += YouTubeDownloader_DownloadComplete;
            await Task.Run(() => downloader.Download()); //Download() is synchronous, need to wrap it like this as not to block UI 
        }

        private void YouTubeDownloader_DownloadComplete(object sender, EventArgs e)
        {
            YouTubeDownloadComplete?.Invoke(this, e);
        }

        private void YouTubeDownloader_DownloadProgress(object sender, EventArgs e)
        {
            YouTubeDownloadProgress?.Invoke(this, e);
        }
        #endregion



        private void DownloadFile(string path)
        {
            WebClient webClient = new WebClient();
            webClient.DownloadProgressChanged += webClient_DownloadProgressChanged;
            webClient.DownloadFileCompleted += webClient_DownloadFileCompleted;

            string file = Path.Combine(Constants.CacheLocation, Path.GetFileName(OsirtHelper.StripQueryFromPath(path)));
            webClient.DownloadFileAsync(new Uri(path), file, file);
        }

        private void webClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            DownloadComplete?.Invoke(this, e);
        }

        private void webClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            DownloadingProgress?.Invoke(this, e);
        }


   

        #region mouse events
        private void Document_MouseDown(object sender, HtmlElementEventArgs e)
        {
            //if (UserSettings.Load().ShowMouseClick)
            //    mouseTrail.BackColor = Color.Yellow;



            //try
            //{
            //    element = Document.GetElementFromPoint(PointToClient(MousePosition));

            //    if (e.MouseButtonsPressed == MouseButtons.Right && element.TagName == "INPUT")
            //    {
            //        IsWebBrowserContextMenuEnabled = true;
            //    }
            //    else
            //    {
            //        IsWebBrowserContextMenuEnabled = false;
            //    }

            //    if (e.MouseButtonsPressed == MouseButtons.Middle)
            //    {
            //        HtmlElement el = Document.GetElementFromPoint(PointToClient(MousePosition));
            //        //I assume I need to check if this element has child elements that contain a TagName "A"

            //        if (el.TagName == "A" && !string.IsNullOrEmpty(el.GetAttribute("href")))//it means we have deal with href
            //        {
            //            Debug.WriteLine("Get link location, open in new tab.");
            //            var url = el.GetAttribute("href");
            //            Debug.WriteLine(url);
            //        }
            //        else
            //            Debug.WriteLine(el.TagName);
            //    }
            //}
            //catch
            //{
            //    //just swallow this exception, too many edge cases.
            //}
        }






        private void Document_MouseMove(object sender, HtmlElementEventArgs e)
        {
            if (UserSettings.Load().ShowMouseTrail)
            {
                Point p = PointToClient(MousePosition);
                mouseTrail.Location = new Point(p.X + 5, p.Y + 5);
            }
        }

        #endregion

    }
}
