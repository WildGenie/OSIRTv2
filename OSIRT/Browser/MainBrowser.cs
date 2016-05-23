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

namespace OSIRT.Browser
{
    public class ExtendedBrowser : WebBrowser
    {
        public event EventHandler ScreenshotCompleted = delegate { };
        public event EventHandler DownloadingProgress = delegate { };
        public event EventHandler DownloadComplete = delegate { };
        public event EventHandler NewTab = delegate { };

        private int MaxScrollHeight => 15000;
        private readonly int MaxWait = 500;
        private ContextMenuStrip contextMenu;
        private HtmlElement element;
        private PictureBox mouseTrail = new PictureBox();
        private bool firstLoad = true;


        public ExtendedBrowser()
        {
            SetLatestIEKeyforWebBrowserControl();
            NativeMethods.DisableClickSounds();
            ScriptErrorsSuppressed = true;
            DocumentCompleted += ExtendedBrowser_DocumentCompleted;
            InitialiseConextMenu();
            DisableNewWindowsOpening();
            InitialiseMouseTrail();
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
            mouseTrail.BackColor = Color.Red;
            mouseTrail.Size = new Size(12, 12);
            Controls.Add(mouseTrail);
            MouseTrailVisible = false;
        }


        private void InitialiseConextMenu()
        {
            contextMenu = new ContextMenuStrip();

            contextMenu.Items.Add("Save image as...", Properties.Resources.picture_save, SaveImageAs_Click);
            contextMenu.Items.Add("Save page source", Properties.Resources.source_code, SaveSource_Click);
            contextMenu.Items.Add("View page source", null, ViewSource_Click);
            contextMenu.Items.Add(new ToolStripSeparator());
            contextMenu.Items.Add("Open link in new tab", Properties.Resources.new_tab, OpenNewTab_Click);
            contextMenu.Items.Add(new ToolStripSeparator());
            contextMenu.Items.Add("Download all images", Properties.Resources.download_cloud, DownloadAllImages_Click);

            contextMenu.Items[0].Enabled = false;
            contextMenu.Items[4].Enabled = false;
            contextMenu.Opening += new CancelEventHandler(contextMenuStrip_Opening);
            ContextMenuStrip = contextMenu;
        }

        


        private void ExtendedBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (firstLoad) AttachMouseEventHandlers();

            if (e.Url.AbsolutePath != ((WebBrowser) sender).Url.AbsolutePath)
                return;

            Logger.Log(new WebsiteLog(Url.AbsoluteUri));


            //How to scroll a webpage using the mouse. Perhaps a useful start for a selection capture.
            //https://social.msdn.microsoft.com/Forums/vstudio/en-US/2c7b0977-7491-4dee-aa5e-c6eceb3b9f52/scroll-up-and-down-by-clicking-and-dragging?forum=csharpgeneral
        }

        private void AttachMouseEventHandlers()
        {
            Document.MouseDown += Document_MouseDown;
            Document.MouseMove += Document_MouseMove;
            firstLoad = false;
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

        public bool Enable
        {
            get
            {
                return ((Control)this).Enabled;
            }
            set
            {
                ((Control)this).Enabled = value;
            }
        }

        public async Task PutTaskDelay()
        {
            await Task.Delay(MaxWait);
        }

        private async void FullpageScreenshotByScrolling()
        {
            
            Enable = false;
            int viewportHeight = ClientRectangle.Size.Height;
            int viewportWidth = ClientRectangle.Size.Width;
            int scrollHeight = ScrollHeight();
            ToggleScrollbars(false);


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

                    ScrollTo(0, count * viewportHeight);

                    count++;

                    await PutTaskDelay(); //we do need these delays. Some pages, like facebook, may need to load viewport content.
                    using (Bitmap image = GetCurrentViewScreenshot())
                    {
                        cache.AddImage(count, image);
                    }
                }
                else //TODO: what if it's exactly divisible?
                {
                    //find out what's left of the page to scroll, then take screenshot
                    //if it's the last image, we're going to need to crop what we need, as it'll take
                    //a capture of the entire viewport.

                    Navigate("javascript:var s = function() { window.scrollBy(0," + pageLeft + "); }; s();");

                    atBottom = true;
                    count++;

                    await PutTaskDelay(); //may need to place larger delay

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
                ToggleFixedElements(false);
                Debug.WriteLine($"IN WHILE --- PAGE LEFT: {pageLeft}. VIEWPORT HEIGHT: {viewportHeight}");
            }//end while

            ToggleScrollbars(true);
            ToggleFixedElements(true);
            Document.Body.ScrollIntoView(true);//scroll page back to the top

            Enable = true;
            WaitWindow.Show(GetScreenshot, Resources.strings.CombineScreenshots);
            FireScreenshotCompleteEvent();
        }

        private void GetScreenshot(object sender, WaitWindowEventArgs e)
        {
            DirectoryInfo directory = new DirectoryInfo(Constants.CacheLocation);
            FileSystemInfo[] files = directory.GetFileSystemInfos();
            ScreenshotHelper.CombineScreenshot(files, e);
        }

        public string URL => Url.AbsoluteUri;


        private void FullpageScreenshotGdi()
        {
            int width = ScrollWidth();
            int height = ScrollHeight();

            Dock = DockStyle.None;
            ToggleScrollbars(false);
            Size = new Size(width, height);
            using (Bitmap screenshot = new Bitmap(width, height))
            {
                try
                {
                    NativeMethods.GetImage(ActiveXInstance, screenshot, Color.Black);
                    ScreenshotHelper.SaveScreenshotToCache(screenshot);
                }
                finally
                {
                    Dock = DockStyle.Fill;
                    ToggleScrollbars(true);
                }

            }
        }



        public void GenerateFullpageScreenshot()
        {
            try
            {
                if (ScrollHeight() > MaxScrollHeight)
                {
                    FullpageScreenshotByScrolling();
                }
                else
                {
                    FullpageScreenshotGdi();
                    FireScreenshotCompleteEvent();
                }
            }
            catch //so many edge cases, let's try scrolling.
            {
                FullpageScreenshotByScrolling();
            }

        }

        private void FireScreenshotCompleteEvent()
        {
            ScreenshotCompleted(this, new ScreenshotCompletedEventArgs());
        }

        private void ScrollTo(int x, int y)
        {
            Document.Window.ScrollTo(x, y);
        }



        /// <summary>
        /// Inspects the registry and uses the latest version of IE
        /// </summary>
        private void SetLatestIEKeyforWebBrowserControl()
        {

            const string BROWSER_EMULATION_KEY = @"Software\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION";

            string appname = Process.GetCurrentProcess().ProcessName + ".exe";

            // Internet Explorer 11. Webpages are displayed in IE11 edge mode, regardless of the !DOCTYPE directive.
            const int browserEmulationMode = 11001;

            RegistryKey browserEmulationKey =
            Registry.CurrentUser.OpenSubKey(BROWSER_EMULATION_KEY, RegistryKeyPermissionCheck.ReadWriteSubTree) ??
            Registry.CurrentUser.CreateSubKey(BROWSER_EMULATION_KEY);

            if (browserEmulationKey != null)
            {
                browserEmulationKey.SetValue(appname, browserEmulationMode, RegistryValueKind.DWord);
                browserEmulationKey.Close();
            }

        }

        /// <summary>
        /// Toggles the all the elements that has a property of "position:fixed" in the document
        /// </summary>
        /// <param name="toggle">Elements are visible if true, other hidden if false</param>
        public void ToggleFixedElements(bool toggle)
        {
            string property = toggle ? "visible" : "hidden";
            HtmlElement h = Document.GetElementsByTagName("head")[0];
            HtmlElement s = Document.CreateElement("script");
            IHTMLScriptElement el = (IHTMLScriptElement)s.DomElement;
            el.text = "javascript: var f = function() { var elements =	document.querySelectorAll('*'); for (var i = 0; i < elements.length; i++) { var position = window.getComputedStyle(elements[i]).position; if(position === 'fixed') { elements[i].style.visibility = '" + property + "';  } }	 }; f();";
            h.AppendChild(s);
        }

        /// <summary>
        /// Obtains the Height of the current document.
        /// Inspects the documents scroll height, client height, the body's scroll height and the bounds of the body using ScrollRectangle.
        /// The highest height is returned.
        /// </summary>
        /// <returns>The document's current Height</returns>
        public int ScrollHeight()
        {
            //TODO: If this is a PDF (or non webpage) it throws an exception.
            //The same for Width, I'd imagine.
     
            Rectangle bounds = Document.Body.ScrollRectangle;
            IHTMLElement2 body = Document.Body.DomElement as IHTMLElement2;
            IHTMLElement2 doc = (Document.DomDocument as IHTMLDocument3).documentElement as IHTMLElement2;

            int scrollHeight = new[] { body.scrollHeight, bounds.Height, doc.scrollHeight, Document.Body.OffsetRectangle.Height, doc.clientHeight }.Max();

            return scrollHeight;
        }

        /// <summary>
        /// Obtains the Width of the current document.
        /// Inspects the documents scroll width, client width, the body's scroll width and the bounds of the body using ScrollRectangle.
        /// The highest width is returned.
        /// </summary>
        /// <returns>The document's current Width</returns>
        public int ScrollWidth()
        {
            int scrollWidth = 0;

            Rectangle bounds = Document.Body.ScrollRectangle;
            IHTMLElement2 body = Document.Body.DomElement as IHTMLElement2;
            IHTMLElement2 doc = (Document.DomDocument as IHTMLDocument3).documentElement as IHTMLElement2;

            scrollWidth = new[] { body.scrollWidth, bounds.Width, doc.scrollWidth, Document.Body.OffsetRectangle.Width, doc.clientWidth }.Max();

            return scrollWidth;
        }

        /// <summary>
        /// Displays or hides the document's scrollbars
        /// </summary>
        /// <param name="toggle">Scrolls visible if true, hidden if false</param>
        public void ToggleScrollbars(bool toggle)
        {
            string property = toggle ? "visible" : "hidden";
            string attribute = toggle ? "yes" : "no";
            Document.Body.Style = $"overflow:{property}";
            Document.Body.SetAttribute("scroll", attribute);
        }

        public void DisableNewWindowsOpening()
        {
            var activex = (SHDocVw.WebBrowser_V1)ActiveXInstance;
            activex.NewWindow += delegate (string URL, int Flags, string TargetFrameName, ref object PostData, string Headers, ref bool Processed)
            {
                Processed = true;
                object flags = Flags;
                object targetFrame = Type.Missing;
                object postData = PostData != null ? PostData : Type.Missing;
                object headers = !string.IsNullOrEmpty(Headers) ? Headers.ToString() : Type.Missing;
                activex.Navigate(URL, ref flags, ref targetFrame, ref postData, ref headers);
            };
        }


        #region Download Manager
        protected sealed class WebBrowserControlSite : WebBrowserSite, DownloadManager.IServiceProvider
        {
            private IDownloadManager manager;

            public WebBrowserControlSite(WebBrowser host) : base(host)
            {
                manager = new BrowserDownloadManager();
            }

            [return: MarshalAs(UnmanagedType.I4)]
            public int QueryService([In] ref Guid guidService, [In] ref Guid riid, [Out] out IntPtr ppvObject)
            {
                Guid SID_SDownloadManager = new Guid("988934A4-064B-11D3-BB80-00104B35E7F9");
                Guid IID_IDownloadManager = new Guid("988934A4-064B-11D3-BB80-00104B35E7F9");

                if ((guidService == IID_IDownloadManager && riid == IID_IDownloadManager))
                {
                    ppvObject = Marshal.GetComInterfaceForObject(manager, typeof(IDownloadManager));
                    return 0; //S_OK
                }
                ppvObject = IntPtr.Zero;
                return unchecked((int)0x80004002); //NON_INTERFACE
            }
        }

        protected override WebBrowserSiteBase CreateWebBrowserSiteBase()
        {
            return new WebBrowserControlSite(this);
        }

        #endregion

        #region context menu events

        private void contextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            if (element == null)
                return;

            contextMenu.Items[0].Enabled = (element.TagName == "IMG") && OsirtHelper.StripQueryFromPath(element.GetAttribute("src")).HasImageExtension();
            contextMenu.Items[4].Enabled = (element.TagName == "A");
            //contextMenu.Items[4].Enabled = (element.ContainsAnchor()) /*|| element.NextSibling.TagName == "A" */;
        }

        private void OpenNewTab_Click(object sender, EventArgs e)
        {
            //TODO: Validate this url!
            string url = element.GetAttribute("href");
            Debug.WriteLine(url);
            NewTab?.Invoke(this, new NewTabEventArgs(url));
        }

        private void DownloadAllImages_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Not yet implemented");
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

        private void SaveSource_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not yet implemented");
        }

        private void ViewSource_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not yet implemented!");
        }



        private void SaveImageAs_Click(object sender, EventArgs e)
        {
            string path = element.GetAttribute("src");
            DownloadFile(path);
        }

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


        #endregion

        #region mouse events
        private void Document_MouseDown(object sender, HtmlElementEventArgs e)
        {
            try
            {
                element = Document.GetElementFromPoint(PointToClient(MousePosition));

                if (e.MouseButtonsPressed == MouseButtons.Right && element.TagName == "INPUT")
                {
                    IsWebBrowserContextMenuEnabled = true;
                }
                else
                {
                    IsWebBrowserContextMenuEnabled = false;
                }

                if(e.MouseButtonsPressed == MouseButtons.Middle)
                {
                    HtmlElement el = Document.GetElementFromPoint(PointToClient(MousePosition));
                    //I assume I need to check if this element has child elements that contain a TagName "A"
               
                    if (el.TagName == "A" && !string.IsNullOrEmpty(el.GetAttribute("href")))//it means we have deal with href
                    {
                        Debug.WriteLine("Get link location, open in new tab.");
                        var url = el.GetAttribute("href");
                        Debug.WriteLine(url);
                    }
                    else
                        Debug.WriteLine(el.TagName);
                 

                    
                }
            }
            catch
            {
                //just swallow this exception, too many edge cases.
            }
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
