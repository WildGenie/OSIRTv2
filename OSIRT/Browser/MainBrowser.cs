using ImageMagick;
using Jacksonsoft;
using Microsoft.Win32;
using mshtml;
using OSIRT.Database;
using OSIRT.Helpers;
using OSIRT.Loggers;
using OSIRT.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSIRT.Browser
{
    public class ExtendedBrowser : WebBrowser
    {

        public delegate void EventHandler(object sender, ScreenshotCompletedEventArgs args);
        public event EventHandler Screenshot_Completed = delegate { }; 

        private int MaxScrollHeight { get { return 15000; } }
        private readonly int MaxWait = 500;

        public ExtendedBrowser()
        {
            SetLatestIEKeyforWebBrowserControl();
            NativeMethods.DisableClickSounds();
            ScriptErrorsSuppressed = true;
            DocumentCompleted += ExtendedBrowser_DocumentCompleted;
        }

        private void ExtendedBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (e.Url.AbsolutePath != (sender as WebBrowser).Url.AbsolutePath)
                return;

            Logger.Log(new WebsiteLog(Url.AbsoluteUri));


            //How to scroll a webpage using the mouse. Perhaps a useful start for a selection capture.
            //https://social.msdn.microsoft.com/Forums/vstudio/en-US/2c7b0977-7491-4dee-aa5e-c6eceb3b9f52/scroll-up-and-down-by-clicking-and-dragging?forum=csharpgeneral
        }


        /// <summary>
        /// Gets the current viewport of the browser
        /// </summary>
        /// <returns>A Bitmap of the current browser viewport</returns>
        public Bitmap GetCurrentViewScreenshot()
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

        public async Task PutTaskDelay()
        {
            await Task.Delay(MaxWait);
        }

        private async void FullpageScreenshotByScrolling()
        {
            ((Control)this).Enabled = false; //prevent user clicks
            int viewportHeight = ClientRectangle.Size.Height;
            int viewportWidth = ClientRectangle.Size.Width;
            int scrollHeight = ScrollHeight();
            int scrollWidth = ScrollWidth();
            ToggleScrollbars(false);


            int count = 0;
            int pageLeft = scrollHeight;
            bool atBottom = false;

            ImageDiskCache cache = new ImageDiskCache();


            while (!atBottom)
            {
                if (pageLeft > viewportHeight)
                {
                   //if we can scroll using the viewport, let's do that

                    ScrollTo(0, count * viewportHeight);

                    count++;

                    await PutTaskDelay(); //we do need these delays. Some pages, like facebook, may need to load viewport content.
                    cache.AddImage(count, GetCurrentViewScreenshot());
                }
                else //TODO: what if it's exactly divisible?
                {
                    //find out what's left of the page to scroll, then take screenshot
                    //if it's the last image, we're going to need to crop what we need, as it'll take
                    //a capture of the entire viewport.

                    Navigate("javascript:var s = function() { window.scrollBy(0," + pageLeft.ToString() + "); }; s();");

                    atBottom = true;
                    count++;

                    await PutTaskDelay(); //may need to place larger delay
                    //Task.Delay(2000).Wait();
                    Rectangle cropRect = new Rectangle(new Point(0, viewportHeight - pageLeft), new Size(viewportWidth, pageLeft));

                    using (Bitmap src = GetCurrentViewScreenshot())
                    using (Bitmap target = new Bitmap(cropRect.Width, cropRect.Height))
                    using (Graphics g = Graphics.FromImage(target))
                    {
                        g.DrawImage(src, new Rectangle(0, 0, target.Width, target.Height), cropRect, GraphicsUnit.Pixel);
                        cache.AddImage(count, GetCurrentViewScreenshot());
                    }

                }

                pageLeft = pageLeft - viewportHeight;
                ToggleFixedElements(false);


            }//end while

            ToggleScrollbars(true);
            ToggleFixedElements(true);
            Document.Body.ScrollIntoView(true);//scroll page back to the top

            ((Control)this).Enabled = true;


            WaitWindow.Show(GetScreenshot, Resources.strings.CombineScreenshots);
            FireScreenshotCompleteEvent();
        }

        private void GetScreenshot(object sender, WaitWindowEventArgs e)
        {
            DirectoryInfo directory = new DirectoryInfo(Constants.CacheLocation);
            FileSystemInfo[] files = directory.GetFileSystemInfos();
            ScreenshotHelper.CombineScreenshot(files, e);

        }

        public string URL
        {
            get { return Url.AbsoluteUri; }
        }


        private void FullpageScreenshotGDI()
        {
            int width = ScrollWidth();
            int height = ScrollHeight();

            this.Dock = DockStyle.None;
            this.ToggleScrollbars(false);
            this.Size = new Size(width, height);
            using (Bitmap screenshot = new Bitmap(width, height))
            {
                //TODO: try catch finally here to reset the scrollbars and dockstyle if this fails
                NativeMethods.GetImage(ActiveXInstance, screenshot, Color.Black);
                Dock = DockStyle.Fill;
                ToggleScrollbars(true);
                ScreenshotHelper.SaveScreenshotToCache(screenshot);

            }
        }

        public void GenerateFullpageScreenshot()
        {

            if (ScrollHeight() > MaxScrollHeight)
            {
                FullpageScreenshotByScrolling();
            }
            else
            {
                FullpageScreenshotGDI();
                FireScreenshotCompleteEvent();
            }

        }

        private void FireScreenshotCompleteEvent()
        {
            Screenshot_Completed(this, new ScreenshotCompletedEventArgs());
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
            HtmlElement h = this.Document.GetElementsByTagName("head")[0];
            HtmlElement s = this.Document.CreateElement("script");
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
            int scrollHeight = 0;
            //TODO: If this is a PDF (or non webpage) it throws an exception.
            //The same for Width, I'd imagine.
            Rectangle bounds = this.Document.Body.ScrollRectangle;
            IHTMLElement2 body = this.Document.Body.DomElement as IHTMLElement2;
            IHTMLElement2 doc = (this.Document.DomDocument as IHTMLDocument3).documentElement as IHTMLElement2;

            scrollHeight = new[] { body.scrollHeight, bounds.Height, doc.scrollHeight, this.Document.Body.OffsetRectangle.Height, doc.clientHeight }.Max();

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

            Rectangle bounds = this.Document.Body.ScrollRectangle;
            IHTMLElement2 body = this.Document.Body.DomElement as IHTMLElement2;
            IHTMLElement2 doc = (this.Document.DomDocument as IHTMLDocument3).documentElement as IHTMLElement2;

            scrollWidth = new[] { body.scrollWidth, bounds.Width, doc.scrollWidth, this.Document.Body.OffsetRectangle.Width, doc.clientWidth }.Max();

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
            this.Document.Body.Style = string.Format("overflow:{0}", property);
            this.Document.Body.SetAttribute("scroll", attribute);
        }


    }
}
