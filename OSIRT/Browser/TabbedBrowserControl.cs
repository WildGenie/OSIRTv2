using System;
using System.Windows.Forms;
using OSIRT.Enums;
using OSIRT.UI;
using OSIRT.Helpers;
using System.Drawing;
using System.Diagnostics;
using System.Collections.Generic;

namespace OSIRT.Browser
{


    public partial class TabbedBrowserControl : UserControl
    {

        private ToolStripComboBox addressBar;
        private Dictionary<int, Rectangle> rectangles = new Dictionary<int, Rectangle>();

        public TabbedBrowserControl()
        {
            InitializeComponent();
            uiBrowserTabControl.DrawMode = TabDrawMode.OwnerDrawFixed;
            uiBrowserTabControl.DrawItem += uiBrowserTabControl_DrawItem;
            uiBrowserTabControl.MouseDown += uiBrowserTabControl_MouseDown;
            uiBrowserTabControl.MouseHover += UiBrowserTabControl_MouseHover;
            uiBrowserPanel.MouseMove += UiBrowserPanel_MouseMove;
         

            uiBrowserTabControl.Padding = new Point(30, 3);

        }

        private void UiBrowserTabControl_MouseHover(object sender, EventArgs e)
        {
            //TODO: can;t get hand to show when hovering or on MouseMove
            Rectangle closeButton = rectangles[uiBrowserTabControl.SelectedIndex];

            var pos = uiBrowserTabControl.PointToClient(Cursor.Position);



            if (closeButton.Contains(new Rectangle(pos.X, pos.Y, 10, 10)))
            {
                Cursor.Current = Cursors.Hand;
            }
            else
            {
                Cursor.Current = Cursors.Default; ;
            }
        }

        private void UiBrowserPanel_MouseMove(object sender, MouseEventArgs e)
        {

            ////TODO:
            //Rectangle closeButton = rectangles[uiBrowserTabControl.SelectedIndex];

            //if (closeButton.Contains(e.Location))
            //{
            //    Cursor.Current = Cursors.Hand;
            //}
            //else
            //{
            //    Cursor.Current = Cursors.Default; ;
            //}

   
        }

        private void uiBrowserTabControl_MouseHover(object sender, EventArgs e)
        {
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // The forms graphics object
          

            base.OnPaint(e);
        }

        private void uiBrowserTabControl_MouseDown(object sender, MouseEventArgs e)
        {
            //don't want to close our only tab.
            if (uiBrowserTabControl.TabPages.Count == 1)
                return;

            //Rectangle r = uiBrowserTabControl.GetTabRect(uiBrowserTabControl.SelectedIndex);
            //Getting the position of the "x" mark.
            //Rectangle closeButton = new Rectangle(r.Right - 15, r.Top + 4, 10, 10);
            Rectangle closeButton = rectangles[uiBrowserTabControl.SelectedIndex];
            Debug.WriteLine("close: " + rectangles[uiBrowserTabControl.SelectedIndex]  + " INDEX: " + uiBrowserTabControl.SelectedIndex);
            Debug.WriteLine("LOCATION: " + e.Location);

            if (closeButton.Contains(e.Location))
            {
                if (MessageBox.Show("Would you like to Close this Tab?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    uiBrowserTabControl.TabPages.Remove(uiBrowserTabControl.SelectedTab);
                }
            }

        }

        private void uiBrowserTabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            Image img = new Bitmap(Properties.Resources.cross, new Size(10, 10));
            e.Graphics.DrawImage(img, new Point(e.Bounds.Right - 15, e.Bounds.Top + 4));
            e.Graphics.DrawString(uiBrowserTabControl.TabPages[e.Index].Text, e.Font, Brushes.Black, e.Bounds.Left + 12, e.Bounds.Top + 4);
            e.DrawFocusRectangle();

            Debug.WriteLine("SEL INDEX: " + uiBrowserTabControl.SelectedIndex);
            Rectangle rectangle = uiBrowserTabControl.GetTabRect(uiBrowserTabControl.SelectedIndex);
            Rectangle rect2 = new Rectangle(rectangle.Right - 15, rectangle.Top + 4, 10, 10);

            int index = uiBrowserTabControl.SelectedIndex;
            if (!rectangles.ContainsKey(index))
            {
                rectangles.Add(uiBrowserTabControl.SelectedIndex, rect2);
            }
            else
            {
                rectangles[index] = rect2;
            }
            Debug.WriteLine("LIST SIZE: " + rectangles.Count);
        }


        public BrowserTab CurrentTab => uiBrowserTabControl?.SelectedTab as BrowserTab;
        private ExtendedBrowser CurrentBrowser => CurrentTab.Browser;

        private BrowserTab CreateTab()
        {
            BrowserTab tab = new BrowserTab();
            uiBrowserTabControl.TabPages.Add(tab);
            uiBrowserTabControl.SelectedTab = tab;
            //TODO: Unsubscribe from these events once tab has closed?
            AddBrowserEvents();
            return tab;
        }

        private void AddBrowserEvents()
        {
            CurrentBrowser.StatusTextChanged += Browser_StatusTextChanged;
            CurrentBrowser.Navigated += CurrentBrowser_Navigated;
            CurrentBrowser.ScreenshotCompleted += Screenshot_Completed;
        }

        private void CurrentBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            CurrentTab.CurrentUrl = CurrentBrowser.Url.AbsoluteUri;
            addressBar.Text = CurrentTab.CurrentUrl;
        }

        private void Screenshot_Completed(object sender, ScreenshotCompletedEventArgs e)
        {
    
            ScreenshotDetails details = new ScreenshotDetails(CurrentBrowser.URL);
            DialogResult dialogRes;
            string fileName = "";
            using (ImagePreviewerForm previewForm = new ImagePreviewerForm(details))
            {
                dialogRes = previewForm.ShowDialog();
                fileName = previewForm.FileName + previewForm.FileExtension;
            }

            //always want to delete items in cache, regardless of DialogResult.
            ImageDiskCache.RemoveItemsInCache();

            if (dialogRes != DialogResult.OK)
                return;

            uiActionLoggedToolStripStatusLabel.Text = $"{fileName} logged at {12}";

            Timer timer = new Timer {Interval = 3500};
            timer.Start();
            timer.Tick += (s, evt) => { uiActionLoggedToolStripStatusLabel.Text = ""; timer.Stop(); };

        }

        void Browser_StatusTextChanged(object sender, EventArgs e)
        {
            uiStatusLabel.Text = CurrentBrowser.StatusText;
        }

        public void GetFullPageScreenshot()
        {
            if (CurrentTab == null)
                throw new NullReferenceException("No tabs to screenshot");

            CurrentBrowser.GenerateFullpageScreenshot(); 
        }

        public void NewTab(string url, ToolStripComboBox urlBar)
        {
            addressBar =  urlBar;
            CreateTab();
            Navigate(url);
        }

        public void Navigate(string url)
        {
            if (CurrentBrowser != null)
            {
                CurrentTab.Browser.Navigate(url);
            }
        }

        private void uiBrowserTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {

            if(CurrentTab.Browser != null)
                addressBar.Text = CurrentTab.CurrentUrl;
        }

        private void uiBrowserStatusStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
