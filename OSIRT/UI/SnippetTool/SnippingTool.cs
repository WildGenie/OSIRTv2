using OSIRT.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OSIRT.UI.SnippetTool
{
    public partial class SnippingTool : Form
    {


        private static Size BitmapSize;
        private static Graphics Graph;
        private static int[] bounds = { 0, 0, 0, 0 }; //minx, miny,maxbottom, maxright

        public SnippingTool()
        {
            InitializeComponent();
        }

        private static void FindMultiScreenSize()
        {

            int minX = Screen.AllScreens[0].Bounds.X;
            int minY = Screen.AllScreens[0].Bounds.Y;

            int maxRight = Screen.AllScreens[0].Bounds.Right;
            int maxBottom = Screen.AllScreens[0].Bounds.Bottom;


            foreach (Screen aScreen in Screen.AllScreens)
            {
                if (aScreen.Bounds.X < minX)
                {
                    minX = aScreen.Bounds.X;
                }

                if (aScreen.Bounds.Y < minY)
                {
                    minY = aScreen.Bounds.Y;
                }

                if (aScreen.Bounds.Right > maxRight)
                {
                    maxRight = aScreen.Bounds.Right;
                }

                if (aScreen.Bounds.Bottom > maxBottom)
                {
                    maxBottom = aScreen.Bounds.Bottom;
                }
            }

            bounds[0] = minX;
            bounds[1] = minY;
            bounds[2] = maxBottom;
            bounds[3] = maxRight;

        }
        public static bool Snip()
        {
            FindMultiScreenSize();
            Bitmap bmp = null;
            try
            {
                bmp = new Bitmap(bounds[3] - bounds[0], bounds[2] - bounds[1], System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            }
            catch (Exception e)
            {
            }

            Graphics gr = Graphics.FromImage(bmp);
            Graph = gr;
            gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            BitmapSize = bmp.Size;


            using (var snipper = new SnippingTool(bmp))
            {
                snipper.Location = new Point(bounds[0], bounds[1]);

                if (snipper.ShowDialog() == DialogResult.OK)
                {
                    ScreenshotHelper.SaveScreenshotToCache(snipper.Image);
                    return true;
                }
            }
            return false;
           
        }



        public SnippingTool(Image screenShot)
        {
            InitializeComponent();
            BackgroundImage = screenShot;
            ShowInTaskbar = false;
            FormBorderStyle = FormBorderStyle.None;

            DoubleBuffered = true;
        }
        public Image Image
        {
            get { return m_Image; }
            set { m_Image = value; }
        }

        private Image m_Image;

        private Rectangle rcSelect = new Rectangle();

        private Point pntStart;
        protected override void OnMouseDown(MouseEventArgs e)
        {
            // Start the snip on mouse down'
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            pntStart = e.Location;
            rcSelect = new Rectangle(e.Location, new Size(0, 0));
            this.Invalidate();
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            // Modify the selection on mouse move'
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            int x1 = Math.Min(e.X, pntStart.X);
            int y1 = Math.Min(e.Y, pntStart.Y);
            int x2 = Math.Max(e.X, pntStart.X);
            int y2 = Math.Max(e.Y, pntStart.Y);
            rcSelect = new Rectangle(x1, y1, x2 - x1, y2 - y1);
            this.Invalidate();
        }


        protected override void OnMouseUp(MouseEventArgs e)
        {
            // Complete the snip on mouse-up'
            if (rcSelect.Width <= 0 || rcSelect.Height <= 0)
            {
                return;
            }
            Image = new Bitmap(rcSelect.Width, rcSelect.Height);
            using (Graphics gr = Graphics.FromImage(Image))
            {
                gr.DrawImage(this.BackgroundImage, new Rectangle(0, 0, Image.Width, Image.Height), rcSelect, GraphicsUnit.Pixel);
            }
            DialogResult = DialogResult.OK;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            // Draw the current selection'
            using (Brush br = new SolidBrush(Color.FromArgb(120, Color.White)))
            {
                int x1 = rcSelect.X;
                int x2 = rcSelect.X + rcSelect.Width;
                int y1 = rcSelect.Y;
                int y2 = rcSelect.Y + rcSelect.Height;
                e.Graphics.FillRectangle(br, new Rectangle(0, 0, x1, this.Height));
                e.Graphics.FillRectangle(br, new Rectangle(x2, 0, this.Width - x2, this.Height));
                e.Graphics.FillRectangle(br, new Rectangle(x1, 0, x2 - x1, y1));
                e.Graphics.FillRectangle(br, new Rectangle(x1, y2, x2 - x1, this.Height - y2));
            }
            using (Pen pen = new Pen(Color.Red, 2))
            {
                e.Graphics.DrawRectangle(pen, rcSelect);
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // Allow canceling the snip with the Escape key'
            if (keyData == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            FindMultiScreenSize();

            //minx, miny,maxbottom, maxright
            this.Size = new Size(bounds[3] - bounds[0], bounds[2] - bounds[1]);

            Graph.CopyFromScreen(bounds[0], bounds[1], 0, 0, BitmapSize);
        }

        private void SnippingTool_Load(object sender, EventArgs e)
        {

        }
    }
}
