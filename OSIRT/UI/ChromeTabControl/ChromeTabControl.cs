/*
    ChromeTabControl is a .Net control that mimics Google Chrome's tab bar.
    Copyright (C) 2013  Brandon Francis

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using OSIRT.UI.ChromeTabControl;

namespace DotNetChromeTabs
{

    [System.ComponentModel.ToolboxItem(true)]
    public class ChromeTabControl : Control
    {

        /// <summary>
        /// Creates a new tab control.
        /// </summary>
        public ChromeTabControl()
        {
            // Set up some Windows variables
            this.DoubleBuffered = true;
            this.AllowDrop = true;
            SetStyle(System.Windows.Forms.ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.ContainerControl, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);

            // Set up some local variables
            _tabPages = new TabPage.TabPageCollection(this);
            _trayItems = new TrayItem.TrayItemCollection(this);
            CLOSE_BUTTON_IMAGES = CreateCloseButtonImages();

            // Create the context menu strip
            contextMenuStrip = new ContextMenuStrip();
            pinItem = new ToolStripMenuItem("Pin tab");
            reopenItem = new ToolStripMenuItem("Reopen last closed tab");
            contextMenuStrip.Opening += contextMenuStrip_Opening;
            pinItem.Click += pinItem_Click;
            reopenItem.Click += reopenItem_Click;
            contextMenuStrip.Items.Add(pinItem);
            contextMenuStrip.Items.Add(new ToolStripSeparator());
            contextMenuStrip.Items.Add(reopenItem);

        }

        #region Windows Functions

        [DllImport("user32.dll", SetLastError = true)]
        public static extern long ReleaseCapture();

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage
                    (IntPtr hWnd, int msg, int wParam, int lParam);

        #endregion

        #region Cosntants

        public const float TABSTRIP_HEIGHT = 27;
        public const int CONTROL_SHADOW_SIZE = 3;
        private const float TAB_SPACING = 0;
        private const float TAB_BEZIER_WIDTH = 13;
        private const float TRAY_ITEM_SPACING = 5;
        private const int TRAY_ITEM_SIZE = 16;
        private const int TRAY_AREA_Y_OFFSET = 0;

        #endregion

        #region Pens and Brushes

        private Pen OUTLINE_PEN = new Pen(Brushes.DimGray);
        private Brush CONTENT_BRUSH = new SolidBrush(Color.White);
        private Brush UNSELECTED_BRUSH = new SolidBrush(Color.FromArgb(210, 207, 217, 228));
        private Brush HOVER_BRUSH = new SolidBrush(Color.FromArgb(210, 224, 231, 238));
        private Brush HOVER_DOWN_BRUSH = new SolidBrush(Color.FromArgb(210, 224 - 30, 231 - 30, 238 - 30));
        private Pen UNSELECTED_OUTLINE_PEN = new Pen(new SolidBrush(Color.FromArgb(200, Color.DimGray)));
        private Pen UNSELECTED_WHITE_ACCENT = new Pen(Color.FromArgb(70, 255, 255, 255));
        private Font TABSTRIP_FONT = new Font("Segoe UI", 12, GraphicsUnit.Pixel);
        private Brush TABSTRIP_FONT_BRUSH = new SolidBrush(Color.FromArgb(200, 0, 0, 0));

        #endregion

        #region Instance Variables

        private Bitmap[] CLOSE_BUTTON_IMAGES;
        private TabPage _canvas;
        private bool _dontUpdateTabWidth = false;

        #endregion

        #region Events

        /// <summary>
        /// Gets called when the new tab button is clicked.
        /// </summary>
        public event NewTabClickedEventHandler NewTabClicked;
        public delegate void NewTabClickedEventHandler(object sender, EventArgs e);

        //TODO: Added.
        public event TabSwitched SelectedIndexChange;
        public delegate void TabSwitched(object sender, TabChangedEventArgs e);


        #endregion

        #region Public Properties

        /// <summary>
        /// The currently opened pages.
        /// </summary>
        public TabPage.TabPageCollection TabPages
        {
            get { return _tabPages; }
        }
        private TabPage.TabPageCollection _tabPages;

        /// <summary>
        /// The current tray items being shown.
        /// </summary>
        public TrayItem.TrayItemCollection TrayItems
        {
            get { return _trayItems; }
        }
        private TrayItem.TrayItemCollection _trayItems;

        /// <summary>
        /// The current width of normal tabs.
        /// </summary>
        public float TabWidth
        {
            get { return _TabWidth; }
        }
        private float _TabWidth;

        /// <summary>
        /// Whether or not to show the new tab button.
        /// </summary>
        public bool NewTabButton
        {
            get { return _newTabButton; }
            set
            {
                bool flag = _newTabButton != value;
                _newTabButton = value;
                if (flag)
                {
                    UpdateAreas();
                    Invalidate();
                }
            }
        }
        private bool _newTabButton = true;

        #endregion

        #region Computed Areas and Paths

        private RectangleF _trayArea;
        private RectangleF _TabstripArea;
        private RectangleF _ContentArea;
        private GraphicsPath _ContentAreaPath;

        #endregion

        #region Menu Strip Properties

        private int hoverAtTimeOfMenuOpening = -1;
        private ContextMenuStrip contextMenuStrip;
        private ToolStripMenuItem pinItem;
        private ToolStripMenuItem reopenItem;
        void pinItem_Click(object sender, EventArgs e)
        {
            _tabPages[hoverAtTimeOfMenuOpening].Pinned = !_tabPages[hoverAtTimeOfMenuOpening].Pinned;
        }
        void reopenItem_Click(object sender, EventArgs e)
        {
            _tabPages.ReopenTab();
        }
        void contextMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            hoverAtTimeOfMenuOpening = _hoverTabIndex;
            pinItem.Text = "Pin Tab";
            // The >= accounts for the new tab button
            if (_hoverTabIndex < 0 || _hoverTabIndex >= _tabPages.Count)
            {
                pinItem.Enabled = false;
            }
            else if (!_tabPages[hoverAtTimeOfMenuOpening].CanSelect)
            {
                pinItem.Enabled = false;
            }
            else
            {
                if (_tabPages[hoverAtTimeOfMenuOpening].Pinned)
                    pinItem.Text = "Unpin Tab";
                pinItem.Enabled = _tabPages[hoverAtTimeOfMenuOpening].CanPin;
            }
            reopenItem.Text = "Reopen last closed tab";
            reopenItem.Enabled = _tabPages.HasTabToReopen();
            if (reopenItem.Enabled)
                reopenItem.Text = "Reopen \"" + _tabPages.GetTabToReopen().Title + "\"";
        }
        #endregion

        #region Updating Methods

        /// <summary>
        /// Updates the areas to draw into. Usually called when resized.
        /// </summary>
        public void UpdateAreas()
        {
            // Update the areas
            _trayArea = new RectangleF(this.Width - ((TRAY_ITEM_SIZE + TRAY_ITEM_SPACING) * TrayItems.Count), (TABSTRIP_HEIGHT / 2) - (TRAY_ITEM_SIZE / 2) + TRAY_AREA_Y_OFFSET, ((TRAY_ITEM_SIZE + TRAY_ITEM_SPACING) * TrayItems.Count) - CONTROL_SHADOW_SIZE, TRAY_ITEM_SIZE);
            // _ContentArea = New RectangleF(CONTROL_SHADOW_SIZE, TABSTRIP_HEIGHT, Me.Width - (CONTROL_SHADOW_SIZE * 2) - 1, Me.Height - TABSTRIP_HEIGHT - CONTROL_SHADOW_SIZE - 1)
            _ContentArea = new RectangleF(0, TABSTRIP_HEIGHT, this.Width - 1, this.Height - TABSTRIP_HEIGHT - 1);
            _ContentAreaPath = Utils.GetRoundedRectanglePath(_ContentArea, 3);
            // _TabstripArea = New RectangleF(CONTROL_SHADOW_SIZE + 3 + TAB_BEZIER_WIDTH, CONTROL_SHADOW_SIZE, Me.Width - (CONTROL_SHADOW_SIZE * 2) - TAB_BEZIER_WIDTH - 6 - (Me.Width - _trayArea.X), TABSTRIP_HEIGHT - CONTROL_SHADOW_SIZE)
            _TabstripArea = new RectangleF(3 + TAB_BEZIER_WIDTH, CONTROL_SHADOW_SIZE, this.Width - TAB_BEZIER_WIDTH - 6 - (this.Width - _trayArea.X), TABSTRIP_HEIGHT - CONTROL_SHADOW_SIZE);
            if (_newTabButton)
                _TabstripArea.Width -= 40;

            // Update tab width and fix for non-full tabs
            if (_dontUpdateTabWidth == false)
            {
                _TabWidth = Convert.ToSingle((_TabstripArea.Width - (TAB_SPACING * _tabPages.Count)) / _tabPages.Count);
                if ((_tabPages != null))
                {
                    if (_tabPages.Count > 0)
                    {
                        float _totalSubtractor = 0;
                        int _totalModified = 0;
                        for (int i = 0; i <= _tabPages.Count - 1; i++)
                        {
                            if (_tabPages[i].TabWidth > -1)
                            {
                                _totalSubtractor += (_TabWidth - _tabPages[i].TabWidth);
                                _totalModified += 1;
                            }
                        }
                        if (_tabPages.Count > _totalModified)
                        {
                            _TabWidth += _totalSubtractor / (_tabPages.Count - _totalModified);
                        }
                    }
                }
                _TabWidth = Math.Min(_TabWidth, 175);
                _TabWidth = Math.Max(_TabWidth, 50);
            }

            // Redraw the control
            Invalidate();

            // Call a mouse reclip
            ReclipMouse();

        }

        /// <summary>
        /// Sets the current page to act as the canvas.
        /// </summary>
        /// <param name="page">The page to set.</param>
        internal void SetCanvas(TabPage page)
        {
            // If we already have a canvas in place, let's let it know
            // it's no longer the canvas
            if (_canvas != null)
            {
                _canvas.OnDeselected();
            }

            if (page == null)
            {
                this.Controls.Clear();
                _canvas = null;
                return;
            }
            _canvas = page;
            _canvas.Location = new Point(10, (int)TABSTRIP_HEIGHT + 10 + 1);
            _canvas.Size = new Size(this.Width - 20, this.Height - 20 - (int)TABSTRIP_HEIGHT - 1);
            _canvas.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
            _canvas.BackColor = Color.White;
            this.Controls.Clear();
            this.Controls.Add(_canvas);
            //_canvas.BringToFront();
            _canvas.Focus();

            // Let the page know it's now the canvas
            _canvas.OnSelected();

        }

        /// <summary>
        /// Gets called when this control gets resized.
        /// </summary>
        /// <param name="e">The event paramaters.</param>
        protected override void OnResize(System.EventArgs e)
        {
            base.OnResize(e);
            UpdateAreas();
            Invalidate();
        }

        /// <summary>
        /// Creates the array of images used to close tabs.
        /// </summary>
        /// <returns>An array of bitmaps with the close tab images.</returns>
        private Bitmap[] CreateCloseButtonImages()
        {

            float penWidth = 1.6f;

            Bitmap normal = new Bitmap(16, 16);
            Graphics g1 = Graphics.FromImage(normal);
            g1.SmoothingMode = SmoothingMode.AntiAlias;
            g1.DrawLine(new Pen(Color.FromArgb(204, 132, 144, 159), penWidth), 5, 5, 11, 11);
            g1.DrawLine(new Pen(Color.FromArgb(204, 132, 144, 159), penWidth), 5, 11, 11, 5);
            g1.Dispose();

            Bitmap hover = new Bitmap(16, 16);
            Graphics g2 = Graphics.FromImage(hover);
            g2.SmoothingMode = SmoothingMode.AntiAlias;
            g2.FillEllipse(new SolidBrush(Color.FromArgb(204, 149, 15, 15)), 2, 2, 12, 12);
            g2.DrawLine(new Pen(Color.FromArgb(204, Color.White), penWidth), 5, 5, 11, 11);
            g2.DrawLine(new Pen(Color.FromArgb(204, Color.White), penWidth), 5, 11, 11, 5);
            g2.Dispose();

            Bitmap hoverDown = new Bitmap(16, 16);
            Graphics g3 = Graphics.FromImage(hoverDown);
            g3.SmoothingMode = SmoothingMode.AntiAlias;
            g3.FillEllipse(new SolidBrush(Color.FromArgb(204, Color.Black)), 2, 2, 12, 12);
            g3.DrawLine(new Pen(Color.FromArgb(204, Color.White), penWidth), 5, 5, 11, 11);
            g3.DrawLine(new Pen(Color.FromArgb(204, Color.White), penWidth), 5, 11, 11, 5);
            g3.Dispose();



            return new Bitmap[] {
                normal,
                hover,
                hoverDown,
                Utils.SetBitmapOpacity(hover, 80),
                Utils.SetBitmapOpacity(hoverDown, 80)
            };

        }

        #endregion

        #region Painting Methods

        /// <summary>
        /// Gets the rectangle associated with the new tab button.
        /// </summary>
        /// <param name="rects">The rectangles </param>
        /// <returns></returns>
        private RectangleF GetNewTabButtonRect(List<RectangleF> rects)
        {
            float height = TABSTRIP_HEIGHT * .6f;
            if (rects.Count > 0)
                return new RectangleF(rects[rects.Count - 1].Right - (TAB_BEZIER_WIDTH / 2), rects[rects.Count - 1].Y + ((TABSTRIP_HEIGHT / 2) - (height / 2)) - 2, 30, height);
            else
                return new RectangleF(_TabstripArea.X, _TabstripArea.Y + ((TABSTRIP_HEIGHT / 2) - (height / 2)) - 2, 30, height);
        }

        /// <summary>
        /// Gets called when the control gets painted.
        /// </summary>
        /// <param name="e">The PaintEventArgs for this event.</param>
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Draw each unselected tab
            List<RectangleF> rects = new List<RectangleF>();
            float totalSubtractor = 0;
            for (int i = 0; i <= _tabPages.Count - 1; i++)
            {
                float thisSubtractor = 0;
                if (_tabPages[i].TabWidth > -1)
                    thisSubtractor = _TabWidth - (_tabPages[i].TabWidth);
                RectangleF rect = new RectangleF(_TabstripArea.X + (_TabWidth * i) + (TAB_SPACING * i) - totalSubtractor, _TabstripArea.Y, _TabWidth - thisSubtractor, _TabstripArea.Height);
                rects.Add(rect);
                totalSubtractor += thisSubtractor;
            }
            for (int i = rects.Count - 1; i >= 0; i += -1)
            {
                if (_tabPages.SelectedIndex != i)
                {
                    if (_tabPages[i].Width > 100)
                         DrawTab(e.Graphics, i, rects[i]);
                }
            }

            // Draw the content box and outline
            Utils.DrawPathShadow(e.Graphics, _ContentAreaPath, CONTROL_SHADOW_SIZE);
            e.Graphics.FillPath(CONTENT_BRUSH, _ContentAreaPath);
            e.Graphics.DrawPath(OUTLINE_PEN, _ContentAreaPath);

            // Draw the selected tab
            if (_tabPages.SelectedIndex > -1)
            {
                if (_tabPages[_tabPages.SelectedIndex].Width > 3)
                    DrawTab(e.Graphics, _tabPages.SelectedIndex, rects[_tabPages.SelectedIndex]);
            }

            // Draw the new tab button
            if (_newTabButton)
            {
                RectangleF newTabButtonRect = GetNewTabButtonRect(rects);
                GraphicsPath path = new GraphicsPath();
                path.AddPath(Utils.GetRoundedRectanglePath(newTabButtonRect, 2.5f), false);
                Matrix mat = new Matrix();
                mat.Shear(.4f, 0f);
                path.Transform(mat);
                GraphicsPath path2 = (GraphicsPath)path.Clone();
                Utils.ScalePath(path2, -1);
                Utils.DrawPathShadow(e.Graphics, path, 1);
                if (_hoverTabIndex == _tabPages.Count)
                {
                    if (_hoverTabCloseDownIndex == _tabPages.Count)
                        e.Graphics.FillPath(HOVER_DOWN_BRUSH, path);
                    else
                        e.Graphics.FillPath(HOVER_BRUSH, path);
                    e.Graphics.DrawPath(OUTLINE_PEN, path);
                } 
                else
                {
                    e.Graphics.FillPath(UNSELECTED_BRUSH, path);
                    e.Graphics.DrawPath(UNSELECTED_OUTLINE_PEN, path);
                    e.Graphics.DrawPath(UNSELECTED_WHITE_ACCENT, path2);
                }
            }

            // Draw the tray items
            for (int i = 0; i <= TrayItems.Count - 1; i++)
            {
                RectangleF rect = new RectangleF(_trayArea.Right - (i * (TRAY_ITEM_SIZE + TRAY_ITEM_SPACING)) - TRAY_ITEM_SIZE, _trayArea.Y, TRAY_ITEM_SIZE, TRAY_ITEM_SIZE);
                if (HoverTrayIndex == i)
                {
                    if (HoverTrayDownIndex == i)
                        e.Graphics.DrawImage(TrayItems[i].Image16Dark, rect);
                    else
                        e.Graphics.DrawImage(TrayItems[i].Image16, rect);
                }
                else
                    e.Graphics.DrawImage(TrayItems[i].Image16Transparent, rect);
            }
        }

        /// <summary>
        /// Gets called when the control paints its background.
        /// </summary>
        /// <param name="pevent"></param>
        protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs pevent)
        {
            if (this.BackColor == Color.Transparent)
                return;
            else
                base.OnPaintBackground(pevent);
        }

        /// <summary>
        /// The different ways to draw the tabs.
        /// </summary>
        private enum TabDrawType : byte
        {
            Normal = 0,
            Hover = 1,
            Selected = 2
        }

        /// <summary>
        /// Draws a specific tab to the control.
        /// </summary>
        /// <param name="g">The graphics to use when drawing.</param>
        /// <param name="index">The index of the tab.</param>
        /// <param name="rect">The rectangle associated with the tab.</param>
        private void DrawTab(Graphics g, int index, RectangleF rect)
        {

            // Change the rect around a little
            rect.X -= TAB_BEZIER_WIDTH;
            rect.Width += TAB_BEZIER_WIDTH;

            // Prevent clipping issues between the two sides
            if (rect.Width < TAB_BEZIER_WIDTH * 2)
                rect.Width = TAB_BEZIER_WIDTH * 2;

            // See if we should draw this being dragged around
            if (index == dragIndex)
            {
                // Set the new x corresponding to the mouse
                rect.X = (float)PointToClient(new Point(MousePosition.X - (int)dragStartOffset, (int)rect.Y)).X;

                // Make sure we don't clip outside the box
                if (rect.Left < this._TabstripArea.Left - TAB_BEZIER_WIDTH)
                    rect.X = _TabstripArea.X - TAB_BEZIER_WIDTH;
                if (rect.Right + TAB_BEZIER_WIDTH > this._TabstripArea.Right)
                    rect.X = _TabstripArea.Right - rect.Width - TAB_BEZIER_WIDTH;
            }

            // Create the tab path
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddBezier(rect.X, rect.Bottom, Convert.ToSingle(rect.X + (TAB_BEZIER_WIDTH / 2)), Convert.ToSingle(rect.Bottom - (TAB_BEZIER_WIDTH / 4)), Convert.ToSingle(rect.X + (TAB_BEZIER_WIDTH / 2)), Convert.ToSingle(rect.Top + (TAB_BEZIER_WIDTH / 4)), rect.X + TAB_BEZIER_WIDTH, rect.Top);
            path.AddBezier(rect.Right - TAB_BEZIER_WIDTH, rect.Top, Convert.ToSingle(rect.Right - (TAB_BEZIER_WIDTH / 2)), Convert.ToSingle(rect.Top + (TAB_BEZIER_WIDTH / 4)), Convert.ToSingle(rect.Right - (TAB_BEZIER_WIDTH / 2)), Convert.ToSingle(rect.Bottom - (TAB_BEZIER_WIDTH / 4)), rect.Right, rect.Bottom);
            path.CloseFigure();

            // Draw the tab background
            if (index == TabPages.SelectedIndex)
            {
                Utils.DrawPathShadow(g, path, CONTROL_SHADOW_SIZE);
                g.FillPath(CONTENT_BRUSH, path);
                g.DrawPath(OUTLINE_PEN, path);
                g.DrawLine(new Pen(CONTENT_BRUSH), rect.Left + 1f, rect.Bottom, rect.Right - 1f, rect.Bottom);
                g.FillRectangle(CONTENT_BRUSH, rect.Left + 1f, rect.Bottom, rect.Width - 2f, CONTROL_SHADOW_SIZE + 1);
            }
            else if (index == HoverTabIndex)
            {
                CompositingMode _mode = g.CompositingMode;
                g.CompositingMode = CompositingMode.SourceCopy;
                g.FillPath(HOVER_BRUSH, path);
                g.CompositingMode = _mode;
                g.DrawPath(UNSELECTED_OUTLINE_PEN, path);
            }
            else
            {
                CompositingMode _mode = g.CompositingMode;
                g.CompositingMode = CompositingMode.SourceCopy;
                g.FillPath(UNSELECTED_BRUSH, path);
                g.CompositingMode = _mode;
                g.DrawPath(UNSELECTED_OUTLINE_PEN, path);
                GraphicsPath path2 = (GraphicsPath)path.Clone();
                Utils.MovePath(path2, 0, 1);
                g.DrawPath(UNSELECTED_WHITE_ACCENT, path2);
            }

            // Setup the offset modifiers
            int inside_padding = 5;
            RectangleF inside_box = new RectangleF(rect.X + TAB_BEZIER_WIDTH + 3, rect.Y + (rect.Height / 2) - 8, rect.Width - (TAB_BEZIER_WIDTH * 2) - 6, 16);
            float left_modifier = 0;
            float right_modifier = 0;

            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            // If pinned and its currently not shrinking
            if (TabPages[index].Pinned && TabPages[index].Animator.Working == false)
            {
                if (TabPages[index].Image == null)
                    return;
                if (index == TabPages.SelectedIndex)
                    g.DrawImage(TabPages[index].Image16, inside_box.X + (inside_box.Width / 2) - 8, inside_box.Y, 16, 16);
                else if (index == HoverTabIndex)
                    g.DrawImage(TabPages[index].Image16, inside_box.X + (inside_box.Width / 2) - 8, inside_box.Y, 16, 16);
                else
                    g.DrawImage(TabPages[index].Image16Transparent, inside_box.X + (inside_box.Width / 2) - 8, inside_box.Y, 16, 16);
                return;
            }

            // Draw the image if it has one
            if (inside_box.Width > 10)
            {
                if ((TabPages[index].Image != null))
                {
                    if (index == TabPages.SelectedIndex)
                        g.DrawImage(TabPages[index].Image16, inside_box.X + 1,inside_box.Y, 16, 16);
                    else if (index == HoverTabIndex)
                        g.DrawImage(TabPages[index].Image16, inside_box.X + 1, inside_box.Y, 16, 16);
                    else
                        g.DrawImage(TabPages[index].Image16Transparent, inside_box.X + 1, inside_box.Y, 16, 16);
                    left_modifier += 16 + inside_padding;
                }
            }

            // Draw the close button
            if (TabPages[index].CanClose == true && TabPages[index].Animator.Working == false)
            {
                if (HoverTabCloseIndex == index)
                {
                    if (index == TabPages.SelectedIndex)
                    {
                        if (HoverTabCloseDownIndex == index)
                            g.DrawImage(CLOSE_BUTTON_IMAGES[2], inside_box.Right - 14, inside_box.Y, 16, 16);
                        else
                            g.DrawImage(CLOSE_BUTTON_IMAGES[1], inside_box.Right - 14, inside_box.Y, 16, 16);
                    }
                    else
                    {
                        if (HoverTabCloseDownIndex == index)
                            g.DrawImage(CLOSE_BUTTON_IMAGES[4], inside_box.Right - 14, inside_box.Y, 16, 16);
                        else
                            g.DrawImage(CLOSE_BUTTON_IMAGES[3], inside_box.Right - 14, inside_box.Y, 16, 16);
                    }
                }
                else
                    g.DrawImage(CLOSE_BUTTON_IMAGES[0], inside_box.Right - 14, inside_box.Y, 16, 16);
                right_modifier += 8 + inside_padding;
            }

            //Draw the text
            inside_box.X += left_modifier;
            inside_box.Width -= left_modifier;
            inside_box.Width -= right_modifier;
            if (inside_box.Width > 5)
            {
                if (!string.IsNullOrEmpty(TabPages[index].Title))
                {
                    g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                    if (HoverTabIndex == index || TabPages.SelectedIndex == index)
                        g.DrawString(TabPages[index].Title, TABSTRIP_FONT, Brushes.Black, inside_box);
                    else
                        g.DrawString(TabPages[index].Title, TABSTRIP_FONT, TABSTRIP_FONT_BRUSH, inside_box);
                }
            }

        }

        #endregion

        #region Mouse Variables

        private bool _mouseIsDown = false;
        private bool _mouseWasDown = false;
        private int _hoverTabIndex = -1;
        private int HoverTabIndex
        {
            get { return _hoverTabIndex; }
            set
            {
                if (value < -1)
                    value = -1;
                bool flag = value != _hoverTabIndex;
                _hoverTabIndex = value;
                if (flag)
                    Invalidate();
            }
        }
        private int _hoverTabCloseIndex = -1;
        private int HoverTabCloseIndex
        {
            get { return _hoverTabCloseIndex; }
            set
            {
                if (value < -1)
                    value = -1;
                if (value != HoverTabIndex)
                    value = -1;
                bool flag = value != _hoverTabCloseIndex;
                _hoverTabCloseIndex = value;
                if (flag)
                    Invalidate();
            }
        }
        private int _hoverTabCloseDownIndex = -1;
        private int HoverTabCloseDownIndex
        {
            get { return _hoverTabCloseDownIndex; }
            set
            {
                if (value < -1)
                    value = -1;
                bool flag = value != _hoverTabCloseDownIndex;
                _hoverTabCloseDownIndex = value;
                if (flag)
                    Invalidate();
            }
        }
        private int _hoverTrayIndex = -1;
        private int HoverTrayIndex
        {
            get { return _hoverTrayIndex; }
            set
            {
                if (value < -1)
                    value = -1;
                bool flag = value != _hoverTrayIndex;
                _hoverTrayIndex = value;
                if (flag)
                    Invalidate();
            }
        }
        private int _hoverTrayDownIndex = -1;
        private int HoverTrayDownIndex
        {
            get { return _hoverTrayDownIndex; }
            set
            {
                if (value < -1)
                    value = -1;
                bool flag = value != _hoverTrayDownIndex;
                _hoverTrayDownIndex = value;
                if (flag)
                    Invalidate();
            }
        }

        #endregion

        #region Mouse Tracking Methods

        /// <summary>
        /// Returns the tab page index given a point on the screen.
        /// </summary>
        /// <param name="pnt">The point on the screen.</param>
        /// <returns>The index of the tab that the point is over.</returns>
        private int PointToTabIndex(PointF pnt)
        {
            if (_TabstripArea.Contains(pnt) == false)
                return -1;
            float _subtractor = 0;
            for (int i = 0; i <= _tabPages.Count - 1; i++)
            {
                float _thisSubtractor = 0;
                if ((_tabPages[i].TabWidth > -1))
                    _thisSubtractor = _TabWidth - _tabPages[i].TabWidth;
                if (new RectangleF(_TabstripArea.X + (_TabWidth * i) + (TAB_SPACING * i) - _subtractor - (TAB_BEZIER_WIDTH / 2), _TabstripArea.Y, _TabWidth - _thisSubtractor, _TabstripArea.Height).Contains(pnt))
                    return i;
                if ((_tabPages[i].TabWidth > -1))
                    _subtractor += _thisSubtractor;
            }
            return -1;
        }

        /// <summary>
        /// Causes the mouse move event to be triggered without the mouse having to be moved.
        /// </summary>
        internal void ReclipMouse()
        {
            // Call a "Mouse Move" event without having the user move the mouse
            Point pnt = PointToClient(MousePosition);
            OnMouseMove(new MouseEventArgs(System.Windows.Forms.MouseButtons.None, 0, pnt.X, pnt.Y, 0));
        }

        // Used for animating the currently dragged item
        float dragStartOffset = 0;
        int dragIndex = -1;
        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseMove(e);

            //Check the tabs
            RectangleF newTabStripArea = new RectangleF(_TabstripArea.Location, _TabstripArea.Size);
            if (NewTabButton)
                newTabStripArea.Width += 40;
            if (newTabStripArea.Contains(e.Location))
            {
                PointF newPoint = e.Location;
                float totalSubtractor = 0;
                bool changed = false;
                List<RectangleF> rects = new List<RectangleF>();
                for (int i = 0; i <= _tabPages.Count - 1; i++)
                {
                    float thisSubtractor = 0;
                    if (_tabPages[i].TabWidth > -1)
                        thisSubtractor = _TabWidth - _tabPages[i].TabWidth;
                    RectangleF viewRect = new RectangleF(_TabstripArea.X + (_TabWidth * i) + (TAB_SPACING * i) - totalSubtractor, _TabstripArea.Y, _TabWidth - thisSubtractor, _TabstripArea.Height);
                    RectangleF clipRect = new RectangleF(_TabstripArea.X + (_TabWidth * i) + (TAB_SPACING * i) - totalSubtractor - (TAB_BEZIER_WIDTH / 2), _TabstripArea.Y, _TabWidth - thisSubtractor, _TabstripArea.Height);
                    rects.Add(viewRect);
                    if (clipRect.Contains(newPoint))
                    {
                        HoverTabIndex = i;

                        //Get the box for the close button and check it
                        float x = (_TabstripArea.X + (_TabWidth * i) + (TAB_SPACING * i) - totalSubtractor) + TAB_BEZIER_WIDTH + 3 + (TabWidth - thisSubtractor - (TAB_BEZIER_WIDTH * 2) - 6) - 14;
                        RectangleF close_box = new RectangleF(x, _TabstripArea.Y + (_TabstripArea.Height / 2) - 8, 16, 16);
                        if (close_box.Contains(e.Location) && TabPages[i].Pinned == false && TabPages[i].CanClose)
                            HoverTabCloseIndex = i;
                        else
                            HoverTabCloseIndex = -1;

                        //Drag, make sure were not hovering over the close button and that a close button anywhere isnt pressed
                        //And _mouseDownTrayIndex = -1 Then
                        if (_hoverTabCloseIndex != i && HoverTabCloseDownIndex == -1 && TabPages.SelectedIndex == i && HoverTrayDownIndex == -1)
                        {
                            if (e.Button == System.Windows.Forms.MouseButtons.Left && _mouseIsDown && _mouseWasDown)
                            {
                                if (TabPages[i].TabDraggable && TabPages[i].TabSelectable && TabPages.Count > 1)
                                {
                                    // Set the drag index and offset from the mouse
                                    dragIndex = i;
                                    dragStartOffset = newPoint.X - clipRect.X;

                                    // Let's not show the new tab button if we're showing it
                                    bool before = _newTabButton;
                                    NewTabButton = false;
                                    
                                    // Do the drag
                                    DoDragDrop(new TabPage.DragShell(TabPages[i]), DragDropEffects.All);

                                    // Reset the index and the tab button
                                    NewTabButton = before;
                                    dragIndex = -1;
                                }
                            }
                        }

                        changed = true;
                        break;
                    }
                    totalSubtractor += thisSubtractor;
                }

                if (!changed && _newTabButton)
                {
                    RectangleF newTabButtonRect = GetNewTabButtonRect(rects);
                    newTabButtonRect.X += 6; // make up for the skew
                    if (newTabButtonRect.Contains(newPoint))
                    {
                        _hoverTabIndex = _tabPages.Count;
                        changed = true;
                    }
                }

                //Change them in bulk
                if (!changed)
                {
                    _hoverTabIndex = -1;
                    _hoverTabCloseIndex = -1;
                }
                _hoverTrayIndex = -1;
                Invalidate();

            }
            else if (_trayArea.Contains(e.Location))
            {
                if (_dontUpdateTabWidth)
                {
                    _dontUpdateTabWidth = false;
                    UpdateAreas();
                }

                bool changed = false;
                RectangleF rect = new RectangleF(_trayArea.Right - TRAY_ITEM_SIZE, _trayArea.Y, TRAY_ITEM_SIZE, TRAY_ITEM_SIZE);
                for (int i = 0; i <= TrayItems.Count - 1; i++)
                {
                    if (rect.Contains(e.Location))
                    {
                        _hoverTrayIndex = i;
                        changed = true;
                        break;
                    }
                    rect.X -= (TRAY_ITEM_SIZE + TRAY_ITEM_SPACING);
                }
                if (!changed)
                    _hoverTrayIndex = -1;
                _hoverTabIndex = -1;
                _hoverTabCloseIndex = -1;
                Invalidate();
            }
            else
            {
                if (_dontUpdateTabWidth)
                {
                    _dontUpdateTabWidth = false;
                    UpdateAreas();
                }

                // Not over the tabs or tray
                _hoverTabIndex = -1;
                _hoverTabCloseIndex = -1;
                _hoverTrayIndex = -1;
                Invalidate();
            }

            // Update the mouse variables
            if (_mouseIsDown == true && _mouseWasDown == false)
                _mouseWasDown = true;

        }

        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDown(e);

            // Only deal with the left button
            if (e.Button != System.Windows.Forms.MouseButtons.Left)
                return;

            // Check if something is being hovered
            if (HoverTabIndex > -1 && HoverTabIndex < _tabPages.Count)
            {
                if (HoverTabCloseIndex == HoverTabIndex)
                {
                    HoverTabCloseDownIndex = HoverTabCloseIndex;
                }
                else
                {
                    TabPages.SelectedIndex = HoverTabIndex;
                    HoverTabCloseDownIndex = -1;
                }
            }
            else if (HoverTabIndex == _tabPages.Count)
            {
                HoverTabCloseDownIndex = _tabPages.Count;
            }
            else if (HoverTrayIndex > -1)
            {
                HoverTrayDownIndex = HoverTrayIndex;
            }
            else if (_ContentArea.Contains(e.Location))
            {
                // Do nothing
            }
            else
            {
                try
                {
                    if (this.Parent != null)
                    {
                        if (this.Parent is Form)
                        {
                            ChromeTabControl.ReleaseCapture();
                            ChromeTabControl.SendMessage(this.Parent.Handle, 0xA1, 2, 0);
                        }
                    }
                }
                catch
                {
                }
            }

            //Update the mouse down boolean
            _mouseIsDown = true;

        }

        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseUp(e);

            // Check for a right click
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (_TabstripArea.Contains(e.Location))
                    contextMenuStrip.Show(MousePosition);
                return;
            }

            //Deal only with the left button
            if (e.Button != System.Windows.Forms.MouseButtons.Left)
                return;


            //TODO: Added
            SelectedIndexChange?.Invoke(this, new TabChangedEventArgs(TabPages.SelectedIndex));

            // Check to see if we clicked the new tab button
            if (_hoverTabIndex == _tabPages.Count && NewTabButton)
                if (NewTabClicked != null)
                    NewTabClicked(this, new EventArgs());

            if (HoverTabCloseDownIndex > -1 && HoverTabCloseIndex == HoverTabCloseDownIndex && HoverTabCloseIndex < _tabPages.Count && HoverTabCloseDownIndex < _tabPages.Count)
            {
                if (_tabPages[HoverTabCloseDownIndex].CanClose)
                {
                    if (HoverTabCloseDownIndex < _tabPages.Count - 1)
                        _dontUpdateTabWidth = true;
                    TabPages.RemoveAt(HoverTabCloseDownIndex);
                    //TODO: Added below
                    SelectedIndexChange?.Invoke(this, new TabChangedEventArgs(TabPages.SelectedIndex));
                }
            }
            if (HoverTrayDownIndex > -1 && HoverTrayIndex == HoverTrayDownIndex && HoverTrayIndex < _trayItems.Count)
            {
                RectangleF rect = new RectangleF(_trayArea.Right - (HoverTrayDownIndex * (TRAY_ITEM_SIZE + TRAY_ITEM_SPACING)) - TRAY_ITEM_SIZE, _trayArea.Y, TRAY_ITEM_SIZE, TRAY_ITEM_SIZE);
                TrayItems[HoverTrayDownIndex].RaiseClicked(rect);
            }

            HoverTrayDownIndex = -1;
            HoverTabCloseDownIndex = -1;

            //Update the mouse variables
            _mouseIsDown = false;
            _mouseWasDown = false;

        }

        protected override void OnMouseLeave(System.EventArgs e)
        {
            base.OnMouseLeave(e);
            if (_dontUpdateTabWidth)
            {
                _dontUpdateTabWidth = false;
                UpdateAreas();
            }
            _hoverTabCloseIndex = -1;
            _hoverTabIndex = -1;
            _hoverTrayIndex = -1;
            Invalidate();
        }

        protected override void OnDragOver(System.Windows.Forms.DragEventArgs drgevent)
        {
            base.OnDragOver(drgevent);

            //Moving tabs around
            if ((drgevent.Data.GetDataPresent(typeof(TabPage.DragShell))))
            {
                //Make sure we're dragging over the tab area
                Point drag_point = PointToClient(new Point(drgevent.X, drgevent.Y));
                if (_TabstripArea.Contains(drag_point) == false)
                {
                    // Let's see if we're close, to give the 
                    if (_TabstripArea.Contains(new Point(drag_point.X, drag_point.Y + 10)))
                        drag_point.Y += 10;
                    else if (_TabstripArea.Contains(new Point(drag_point.X, drag_point.Y - 10)))
                        drag_point.Y -= 10;
                    else
                    {
                        drgevent.Effect = DragDropEffects.None;
                        return;
                    }
                }

                //Get the dragged tab
                TabPage drag_tab = ((TabPage.DragShell)drgevent.Data.GetData(typeof(TabPage.DragShell))).Tab;

                //Check if the managers equal
                if (!this.Equals(drag_tab._tabControl))
                {
                    drgevent.Effect = DragDropEffects.None;
                }
                else
                {
                    drgevent.Effect = DragDropEffects.Move;
                    int drag_index = TabPages.IndexOf(drag_tab);
                    if (drag_index < 0)
                        return;
                    int drop_index = PointToTabIndex(drag_point);
                    if (drop_index < 0)
                    {
                        drgevent.Effect = DragDropEffects.None;
                        return;
                    }
                    if (TabPages[drop_index].TabDraggable == false)
                    {
                        drgevent.Effect = DragDropEffects.None;
                        return;
                    }
                    //allow to switch pins only with other pins
                    if (drag_tab.Pinned != TabPages[drop_index].Pinned)
                    {
                        drgevent.Effect = DragDropEffects.None;
                        return;
                    }
                    if (drag_index != drop_index)
                    {
                        TabPages.MoveItem(drag_index, drop_index);

                        // We need to change the index of the drag to show the correct item drag
                        dragIndex = drop_index;
                    }
                }
            }

            // Invalidate to show any changes to the drag animation
            Invalidate();

        }


        #endregion
        
        [System.ComponentModel.ToolboxItem(false)]
        /// <summary>
        /// Pages that work with the TabControl.
        /// </summary>
        public class TabPage : UserControl
        {

            internal ChromeTabControl _tabControl;

            /// <summary>
            /// Creates a new tab page.
            /// </summary>
            public TabPage()
            {
                this.DoubleBuffered = true;
                this.AutoScroll = true;
            }

            /// <summary>
            /// Overrides the OnScroll event for this conrol.
            /// </summary>
            /// <param name="se">The ScrollEventArgs for this event.</param>
            protected override void OnScroll(ScrollEventArgs se)
            {
                base.OnScroll(se);
                Invalidate();
            }

            /// <summary>
            /// Overrides the OnLoad event for this control.
            /// </summary>
            /// <param name="e">The EventArgs for this event.</param>
            protected override void OnLoad(EventArgs e)
            {
                Focus();
                base.OnLoad(e);
            }

            /// <summary>
            /// Gets triggered when this page is selected in the tab control.
            /// </summary>
            internal virtual void OnSelected()
            {
            }

            /// <summary>
            /// Gets triggered when this page is no longer selected in the tab control.
            /// </summary>
            internal virtual void OnDeselected()
            {
            }

            /// <summary>
            /// Sets the owner of this tab.
            /// </summary>
            /// <param name="tabcontrol">The owner of this tab.</param>
            internal void SetOwnerTabControl(ChromeTabControl tabcontrol)
            {
                _tabControl = tabcontrol;
            }

            /// <summary>
            /// Updates the parent control's areas.
            /// </summary>
            private void Changed()
            {
                if ((_tabControl != null))
                {
                    _tabControl.UpdateAreas();
                }
            }

            /// <summary>
            /// Invalidates the parent control.
            /// </summary>
            private void RefreshControl()
            {
                if ((_tabControl != null))
                {
                    _tabControl.Invalidate();
                }
            }

            /// <summary>
            /// Closes this page.
            /// </summary>
            public void Close()
            {
                if (_tabControl == null)
                    return;
                int index = _tabControl.TabPages.IndexOf(this);
                if (index < 0)
                    return;
                _tabControl.TabPages.RemoveAt(index);
            }

            /// <summary>
            /// Gets called when the tab is being closed. Return true to cancel.
            /// </summary>
            /// <returns>True to allow the closing. False to not allow it.</returns>
            internal virtual bool TabClosingAllowed()
            {
                return true;
            }

            /// <summary>
            /// Makes this tab the selected tab in the control.
            /// </summary>
            public void EnsureVisible()
            {
                if (_tabControl == null)
                    return;
                int index = _tabControl.TabPages.IndexOf(this);
                if (index < 0)
                    return;
                _tabControl.TabPages.SelectedIndex = index;
            }

            /// <summary>
            /// Whether or not there can only be one instance of a tab.
            /// </summary>
            public bool SingleInstance
            {
                get { return singleInstance; }
                set { singleInstance = value; }
            }
            private bool singleInstance = true;

            /// <summary>
            /// Gets called when a new instance of this tab page is attempted to be opened.
            /// </summary>
            internal virtual bool NewInstanceAttempted(TabPage newInstance)
            {
                return false;
            }

            /// <summary>
            /// Gets called when the parent TabControl is disposing.
            /// </summary>
            new protected virtual void Dispose()
            {
            }

            /// <summary>
            /// Gets called when the parent TabControl is disposing.
            /// </summary>
            protected override void Dispose(bool disposing)
            {
                base.Dispose(disposing);
                Dispose();
            }

            /// <summary>
            /// The animator that animates the tab.
            /// </summary>
            public TabAnimator Animator
            {
                get
                {
                    if (_animator == null)
                        _animator = new TabAnimator(this);
                    return _animator;
                }
            }
            private TabAnimator _animator;

            /// <summary>
            /// Whether or not this page can be closed.
            /// </summary>
            public bool CanClose
            {

               

                get
                {

                    if (_tabControl.TabPages.Count == 1) return false;
                    else return _canClose;


                }
                set
                {
                    bool flag = false;
                    if (value != _canClose)
                        flag = true;
                    _canClose = value;
                    if (flag)
                        RefreshControl();
                }
            }
            private bool _canClose = true;

            /// <summary>
            /// Whether or not this page can be reopened.
            /// </summary>
            public bool CanReopen
            {
                get { return _canReopen; }
                set { _canReopen = value; }
            }
            private bool _canReopen = true;

            /// <summary>
            /// Whether or not this page can be pinned.
            /// </summary>
            public bool CanPin
            {
                get { return _canPin; }
                set { _canPin = value; }
            }
            private bool _canPin = true;

            /// <summary>
            /// The title of the page that shows up on the tab.
            /// </summary>
            public string Title
            {
                get { return _title; }
                set
                {
                    bool flag = false;
                    if (value != _title)
                        flag = true;
                    _title = value;
                    if (flag)
                        RefreshControl();
                }
            }
            private string _title = "No Title";

            /// <summary>
            /// The current width in pixels of the tab on top.
            /// </summary>
            public float TabWidth
            {
                get { return _width; }
                set
                {
                    _width = value;
                    Changed();
                }
            }
            private float _width = -1;

            /// <summary>
            /// The full sized image for this page.
            /// </summary>
            public Bitmap Image
            {
                get { return _image; }
                set
                {
                    _image = value;
                    _image16 = Utils.ResizeBitmap(_image, new Size(16, 16));
                    _image16Transparent = Utils.SetBitmapOpacity(_image16, 80);
                    RefreshControl();
                }
            }
            private Bitmap _image;

            /// <summary>
            /// The 16x16 image for this page
            /// </summary>
            public Bitmap Image16
            {
                get { return _image16; }
            }
            private Bitmap _image16;

            /// <summary>
            /// The slightly transparent 16x16 image for this page.
            /// </summary>
            public Bitmap Image16Transparent
            {
                get { return _image16Transparent; }
            }
            private Bitmap _image16Transparent;

            /// <summary>
            /// Whether or not this tab is selectable or not.
            /// </summary>
            public bool TabSelectable
            {
                get { return _tabEnabled; }
                set
                {
                    bool flag = false;
                    if (value != _tabEnabled)
                        flag = true;
                    _tabEnabled = value;
                    if (flag)
                    {
                        if ((_tabControl != null))
                        {
                            _tabControl.ReclipMouse();
                        }
                    }
                }
            }
            private bool _tabEnabled = true;

            /// <summary>
            /// Whether or not this tab is pinned.
            /// </summary>
            public bool Pinned
            {
                get { return _pinned; }
                set
                {
                    if (value)
                    {

                        // If we're pinned or we cannot pin, let's get out of here
                        if (Pinned || !CanPin)
                            return;

                        // Move this to the first open pin spot
                        if ((_tabControl != null))
                        {

                            // Let's find the spot to move it to
                            int i = 0;
                            while (i < _tabControl.TabPages.Count)
                            {
                                if (_tabControl.TabPages[i].Pinned)
                                {
                                    if (i == _tabControl.TabPages.IndexOf(this))
                                        break;
                                    i += 1;
                                }
                                else
                                {
                                    break;
                                }
                            }

                            // Now let's move it
                            _tabControl.TabPages.MoveItem(_tabControl.TabPages.IndexOf(this), i);
                        }

                        // We're pinned, let's do the animation
                        _pinned = true;
                        if ((_tabControl != null))
                        {
                            Animator.Enable(TabAnimator.AnimationType.ToPin);
                            while (Animator.Working)
                                Application.DoEvents();
                            RefreshControl();
                        }
                        else
                            this.TabWidth = TabAnimator.PIN_SIZE;

                    }
                    else
                    {

                        // If we're already not pinned, let's get out of here
                        if (!Pinned)
                            return;

                        // Move this past any pinned tabs
                        if ((_tabControl != null))
                        {

                            // Let's find the spot to move to
                            int i = _tabControl.TabPages.IndexOf(this);
                            int cur = i;
                            while (i < _tabControl.TabPages.Count)
                            {
                                if (i + 1 < _tabControl.TabPages.Count)
                                {
                                    if (_tabControl.TabPages[i + 1].Pinned)
                                        i++;
                                    else
                                        break;
                                }
                                else
                                    break;
                            }

                            // Now let's move it
                            _tabControl.TabPages.MoveItem(cur, i);
                        }

                        // We're no longer pinned, let's animate it
                        _pinned = false;
                        if ((_tabControl != null))
                        {
                            Animator.Enable(TabAnimator.AnimationType.ToFull);
                            while (Animator.Working)
                                Application.DoEvents();
                            RefreshControl();
                        }
                        else
                            this.TabWidth = -1;

                    }
                }
            }
            private bool _pinned = false;

            /// <summary>
            /// Whether or not this tab is draggable.
            /// </summary>
            public bool TabDraggable
            {
                get { return _tabDraggable; }
                set { _tabDraggable = value; }
            }
            private bool _tabDraggable = true;

            /// <summary>
            /// Used for animating tabs.
            /// </summary>
            public class TabAnimator
            {

                /// <summary>
                /// The tab we're going to animate.
                /// </summary>
                private TabPage _tab;

                /// <summary>
                /// The timer in charge of iterating.
                /// </summary>
                private Timer _timer;

                /// <summary>
                /// The size of a pinned tab.
                /// </summary>
                public const float PIN_SIZE = 40;

                // Some instance variables
                private bool _wasTabEnabled = true;
                private int _step = 20;
                private AnimationType _type;

                /// <summary>
                /// Creates a new TabAnimator given a tab.
                /// </summary>
                /// <param name="tab">The tab to animate.</param>
                public TabAnimator(TabPage tab)
                {
                    _tab = tab;
                    _timer = new Timer();
                    _timer.Interval = 1;
                    _timer.Tick += new EventHandler(Tick);
                }

                /// <summary>
                /// The different animation types.
                /// </summary>
                public enum AnimationType : byte
                {
                    ToZero = 0,
                    ToFull = 1,
                    ToPin = 2
                }

                /// <summary>
                /// Starts the animation given a type.
                /// </summary>
                /// <param name="type">The animation type to start.</param>
                public void Enable(AnimationType type)
                {
                    if (_timer.Enabled)
                    {
                        Finish();
                    }
                    _type = type;
                    _wasTabEnabled = _tab.TabSelectable;
                    _tab.TabSelectable = false;
                    _timer.Interval = 1;
                    _timer.Start();
                }

                /// <summary>
                /// Finishes an animation.
                /// </summary>
                public void Finish()
                {
                    _timer.Stop();
                    _tab.TabSelectable = _wasTabEnabled;
                }

                /// <summary>
                /// Whether or not this animator is animating.
                /// </summary>
                public bool Working
                {
                    get { return _timer.Enabled; }
                }

                /// <summary>
                /// Gets triggered when the timer updates.
                /// </summary>
                /// <param name="sender">The sender object.</param>
                /// <param name="e">The event args.</param>
                private void Tick(Object sender, EventArgs e)
                {
                    if (_type == AnimationType.ToFull)
                    {
                        if (_tab.TabWidth == -1)
                            Finish();
                        if (_tab._tabControl == null)
                            Finish();
                        if (_tab.TabWidth < _tab._tabControl.TabWidth)
                        {
                            if (_tab._tabControl.TabWidth - _tab.TabWidth < _step)
                                _tab.TabWidth += _tab._tabControl.TabWidth - _tab.TabWidth;
                            else
                                _tab.TabWidth += _step;
                        }
                        else
                        {
                            _tab.TabWidth = -1;
                            Finish();
                        }

                    }
                    else if (_type == AnimationType.ToZero)
                    {
                        if (_tab._tabControl == null)
                            Finish();
                        if (_tab.TabWidth == -1)
                            _tab.TabWidth = _tab._tabControl.TabWidth - _step;
                        if (_tab.TabWidth > 0)
                        {
                            if (_tab.TabWidth - _step < 0)
                                _tab.TabWidth = 0;
                            else
                                _tab.TabWidth -= _step;
                        }
                        else
                        {
                            _tab.TabWidth = 0;
                            Finish();
                        }

                    }
                    else if (_type == AnimationType.ToPin)
                    {
                        if (_tab._tabControl == null)
                            Finish();
                        if (_tab.TabWidth == -1)
                            _tab.TabWidth = _tab._tabControl.TabWidth;
                        if (_tab.TabWidth > PIN_SIZE)
                        {
                            if (_tab.TabWidth - _step < PIN_SIZE)
                            {
                                _tab.TabWidth = PIN_SIZE;
                                Finish();
                            }
                            else
                                _tab.TabWidth -= _step;
                        }
                        else if (_tab.TabWidth < PIN_SIZE)
                        {
                            if (_tab.TabWidth + _step > PIN_SIZE)
                            {
                                _tab.TabWidth = PIN_SIZE;
                                Finish();
                            }
                            else
                                _tab.TabWidth += _step;
                        }
                    }
                    else
                        Finish();                
                }

            }

            /// <summary>
            /// Used for tab dragging.
            /// Keeps necessary information in the drag event.
            /// </summary>
            public class DragShell
            {

                TabPage _tab;
                public DragShell(TabPage tab1)
                {
                    _tab = tab1;
                }

                public TabPage Tab
                {
                    get { return _tab; }
                }

            }

            /// <summary>
            /// Collection of tab pages that syncs with the tab control.
            /// </summary>
            public class TabPageCollection : IList<TabPage>
            {

                private const int REOPEN_LIST_MAX = 3;
                private List<TabPage> _list = new List<TabPage>();
                private List<TabPage> _reopenList = new List<TabPage>();
                private List<int> _reopenListIndexes = new List<int>();

                // Events
                public delegate void TabPageCollectionEvent();
                public event TabPageCollectionEvent NoItemsLeft;

                private ChromeTabControl _tabControl;
                internal void Changed()
                {
                    CheckList();
                    if ((_tabControl != null))
                    {
                        _tabControl.UpdateAreas();
                    }
                }

                private void CheckList()
                {
                    if (_list.Count > 0 && _selectedIndex == -1)
                        SelectedIndex = 0;
                    if (_list.Count == 0 && _selectedIndex != -1)
                    {
                        if ((_tabControl != null))
                        {
                            _tabControl.SetCanvas(null);
                        }
                    }
                }

                private void CheckReopenList()
                {
                    int i = 0;
                    while (i < _reopenList.Count)
                    {
                        if (_reopenList[i].CanReopen == false || i >= REOPEN_LIST_MAX)
                        {
                            _reopenList[i].Dispose();
                            _reopenList.RemoveAt(i);
                            _reopenListIndexes.RemoveAt(i);
                        }
                        else
                        {
                            i += 1;
                        }
                    }
                }

                /// <summary>
                /// Gets the index of an already opened instance of a tab. -1 for not found.
                /// </summary>
                private int[] GetInstanceIndices(TabPage page, List<TabPage> tlist)
                {
                    List<int> rtn = new List<int>();
                    if (!page.SingleInstance)
                        return rtn.ToArray();
                    for (int i = 0; i < _list.Count; i++)
                    {
                        if (tlist[i].Name == page.Name &&
                            tlist[i].GetType() == page.GetType() &&
                            tlist[i].SingleInstance)
                            rtn.Add(i);
                    }
                    return rtn.ToArray();
                }
                private bool CheckInstance(TabPage page)
                {
                    int[] indices = GetInstanceIndices(page, _list);
                    for (int i = 0; i < indices.Length; i++)
                    {
                        if (indices[i] > -1)
                        {
                            SelectedIndex = indices[i];
                            bool answer = _list[indices[i]].NewInstanceAttempted(page);
                            if (answer == false)
                                return true;
                        }
                    }
                    return false;
                }

                /// <summary>
                /// Whether or not there is a tab available to be reopened.
                /// </summary>
                /// <returns>True if a tab is ready.</returns>
                public bool HasTabToReopen()
                {
                    CheckReopenList();
                    if (_reopenList.Count > 0)
                        return true;
                    return false;
                }

                /// <summary>
                /// Reopened the last closed tab.
                /// </summary>
                public void ReopenTab()
                {
                    if (HasTabToReopen() == false)
                        return;
                    int index = _reopenListIndexes[0];
                    if (index > _list.Count)
                        index = _list.Count;
                    if (index < 0)
                        index = 0;
                    Insert(index, _reopenList[0]);
                    _reopenList.RemoveAt(0);
                    _reopenListIndexes.RemoveAt(0);
                    _selectedIndex = -1;
                    //force a recanvas
                    SelectedIndex = index;
                }

                /// <summary>
                /// Returns the tab that is next on line to be reopened.
                /// </summary>
                /// <returns></returns>
                public TabPage GetTabToReopen()
                {
                    if (HasTabToReopen() == false)
                        return null;
                    return _reopenList[0];
                }

                /// <summary>
                /// The index of the currently selected tab.
                /// </summary>
                public int SelectedIndex
                {
                    get { return _selectedIndex; }
                    set
                    {
                        if (value > _list.Count - 1)
                            value = _list.Count - 1;
                        if (value < -1)
                            value = -1;
                        if (value == _selectedIndex)
                            return;
                        bool flag = false;
                        if (value != _selectedIndex)
                            flag = true;
                        _selectedIndex = value;
                        if (flag)
                        {
                            if ((_tabControl != null))
                            {
                                _tabControl.Invalidate();
                                if (value > -1)
                                {
                                    _tabControl.SetCanvas(_list[value]);
                                }
                                else
                                {
                                    _tabControl.SetCanvas((TabPage)null);
                                }
                            }
                        }
                    }
                }
                private int _selectedIndex = -1;

                public TabPageCollection(ChromeTabControl owner)
                {
                    _tabControl = owner;
                }

                /// <summary>
                /// Adds a page to the list and animates it in.
                /// </summary>
                /// <param name="item">The item to open.</param>
                public void Add(TabPage item)
                {
                    if (CheckInstance(item))
                        return;
                    item.SetOwnerTabControl(_tabControl);
                    item.TabWidth = 0;
                    _list.Add(item);
                    Changed();
                    item.Animator.Enable(TabPage.TabAnimator.AnimationType.ToFull);
                    SelectedIndex = _list.Count - 1;
                }

                /// <summary>
                /// Adds a page to the list but doesn't animate it when it opens.
                /// </summary>
                /// <param name="item">The item to open.</param>
                public void AddNoAnimate(TabPage item)
                {
                    if (CheckInstance(item))
                        return;
                    item.SetOwnerTabControl(_tabControl);
                    _list.Add(item);
                    Changed();
                }

                /// <summary>
                /// Should never really be called.
                /// </summary>
                public void Clear()
                {
                    _list.Clear();
                    _reopenList.Clear();
                    _reopenListIndexes.Clear();
                    Changed();
                    if (NoItemsLeft != null)
                        NoItemsLeft();
                }

                public bool Contains(TabPage item)
                {
                    return _list.Contains(item);
                }

                public void CopyTo(TabPage[] array, int arrayIndex)
                {
                    _list.CopyTo(array, arrayIndex);
                }

                public int Count
                {
                    get { return _list.Count; }
                }

                public bool IsReadOnly
                {
                    get { return false; }
                }

                public bool Remove(TabPage item)
                {
                    int index = _list.IndexOf(item);
                    if (index < 0)
                        return false;
                    if (!_list[index].CanClose)
                        return false;
                    if (!_list[index].TabClosingAllowed())
                        return false;
                    RemoveAt(index);
                    if (_list.Count == 0)
                        if (NoItemsLeft != null)
                            NoItemsLeft();
                    return true;
                }

                public void OverrideTab(int indexToOverride, TabPage newPage)
                {
                    if (CheckInstance(newPage))
                    {
                        return;
                    }
                    newPage.SetOwnerTabControl(_tabControl);
                    _list[indexToOverride] = newPage;
                    if (indexToOverride == SelectedIndex)
                        _tabControl.SetCanvas(_list[indexToOverride]);
                    _tabControl.Invalidate();
                }

                public System.Collections.Generic.IEnumerator<TabPage> GetEnumerator()
                {
                    return _list.GetEnumerator();
                }

                public int IndexOf(TabPage item)
                {
                    return _list.IndexOf(item);
                }

                public void Insert(int index, TabPage item)
                {
                    if (CheckInstance(item))
                        return;
                    item.SetOwnerTabControl(_tabControl);
                    item.TabWidth = 0;
                    _list.Insert(index, item);
                    Changed();
                    item.Animator.Enable(TabPage.TabAnimator.AnimationType.ToFull);
                }

                public TabPage this[int index]
                {

                    get { return _list[index]; }
                    set
                    {
                        value.SetOwnerTabControl(_tabControl);
                        _list[index] = value;
                        Changed();
                    }
                }

                public void RemoveAt(int index)
                {
                    //Don't allow the removal of pinned tabs
                    if (_list[index].Pinned)
                        return;

                    // Don't try to close it if it doesn't want to
                    if (!_list[index].CanClose)
                        return;

                    // Don't remove if the tab cancels the close
                    if (!_list[index].TabClosingAllowed())
                        return;

                    //Calculate and change the selected index according to which is closing
                    int indexToChangeTo = _selectedIndex;
                    if (_selectedIndex > -1)
                    {
                        if (_selectedIndex == index)
                        {
                            if (index == 0)
                            {
                                if (_list.Count > 1)
                                {
                                    indexToChangeTo = _selectedIndex;
                                    SelectedIndex += 1;
                                }
                                else
                                {
                                    indexToChangeTo = -1;
                                    SelectedIndex = -1;
                                }
                            }
                            else if (index == _list.Count - 1)
                            {
                                SelectedIndex -= 1;
                                indexToChangeTo = _selectedIndex;
                            }
                            else
                            {
                                indexToChangeTo = _selectedIndex;
                                SelectedIndex += 1;
                            }
                        }
                        else if (_selectedIndex > index)
                        {
                            indexToChangeTo = _selectedIndex - 1;
                        }
                    }
                    else
                    {
                        indexToChangeTo = -1;
                    }

                    //Do the animation and actual removal
                    _list[index].Animator.Enable(TabPage.TabAnimator.AnimationType.ToZero);
                    try
                    {
                        while (_list[index].Animator.Working)
                        {
                            Application.DoEvents();
                        }
                    }
                    catch { }


                    //Add to the reopen list if needed
                    if (index < _list.Count)
                    {
                        if (_list[index].CanReopen)
                        {
                            TabPage tab = _list[index];
                            _list.RemoveAt(index);
                            tab.SetOwnerTabControl(null);
                            tab.TabWidth = -1;
                            tab.Pinned = false;
                            _reopenList.Insert(0, tab);
                            _reopenListIndexes.Insert(0, index);
                        }
                        else
                        {
                            _list[index].Dispose();
                            _list.RemoveAt(index);
                        }
                    }

                    //Change the selected index and dont refresh until finished
                    if (indexToChangeTo != _selectedIndex)
                    {
                        _selectedIndex = indexToChangeTo;
                    }

                    if (_list.Count == 0)
                        if (NoItemsLeft != null)
                            NoItemsLeft();

                    Changed();

                }

                public System.Collections.IEnumerator GetEnumerator1()
                {
                    return _list.GetEnumerator();
                }
                System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
                {
                    return GetEnumerator1();
                }

                /// <summary>
                /// Moves a page from one index to another.
                /// </summary>
                /// <param name="oldIndex">The index it is currently at.</param>
                /// <param name="newIndex">The new index you want it to be at.</param>
                public void MoveItem(int oldIndex, int newIndex)
                {
                    if (oldIndex == newIndex)
                        return;
                    if (newIndex > _list.Count - 1)
                        newIndex = _list.Count - 1;
                    if (newIndex < 0)
                        newIndex = 0;
                    int curselected = _selectedIndex;
                    TabPage temp = _list[oldIndex];
                    _list.RemoveAt(oldIndex);
                    _list.Insert(newIndex, temp);
                    if (_selectedIndex == oldIndex)
                    {
                        _selectedIndex = newIndex;
                    }
                    else if (_selectedIndex > oldIndex)
                    {
                        if (newIndex >= _selectedIndex)
                        {
                            _selectedIndex -= 1;
                        }
                    }
                    else if (_selectedIndex < oldIndex)
                    {
                        if (newIndex <= _selectedIndex)
                        {
                            _selectedIndex += 1;
                        }
                    }
                    Changed();
                }

            }

        }

        /// <summary>
        /// Items that go in the tab cotrol's tray.
        /// </summary>
        public class TrayItem
        {

            /// <summary>
            /// Raises a clicked event for this tray item.
            /// </summary>
            /// <param name="rect">The rectangle of this item.</param>
            internal void RaiseClicked(RectangleF rect)
            {
                if (_type == TrayItemType.Button)
                    if (Clicked != null)
                        Clicked(rect);
            }
            public event ClickedEventHandler Clicked;
            public delegate void ClickedEventHandler(RectangleF rect);

            /// <summary>
            /// Sets the TabControl that owns this tray item.
            /// This is used for refreshing the TabControl when
            /// this item is updated.
            /// </summary>
            /// <param name="owner">The TabControl that owns this tray item.</param>
            internal void SetOwnerTabControl(ChromeTabControl owner)
            {
                _tabControl = owner;
            }
            private ChromeTabControl _tabControl;

            /// <summary>
            /// Creates a new tray item given an icon.
            /// </summary>
            /// <param name="icon">The icon to display for this item.</param>
            public TrayItem(Bitmap icon)
            {
                Image = icon;
            }

            /// <summary>
            /// Invalidates the tab control that owns this tray item.
            /// </summary>
            private void RefreshControl()
            {
                if ((_tabControl != null))
                    _tabControl.Invalidate();
            }

            /// <summary>
            /// The different tray item functionality types.
            /// </summary>
            public enum TrayItemType : byte
            {
                Button = 0,
                Icon = 1
            }
            
            /// <summary>
            /// The tray item type for this tray item.
            /// This decides what functionality the item has.
            /// </summary>
            public TrayItemType Type
            {
                get { return _type; }
                set
                {
                    if (value != _type)
                    {
                        _type = value;
                        RefreshControl();
                    }
                }
            }
            private TrayItemType _type = TrayItemType.Button;

            /// <summary>
            /// Sets the image for this tray item.
            /// </summary>
            public Bitmap Image
            {
                set
                {
                    _image16 = Utils.ResizeBitmap(value, new Size(16, 16));
                    _image16Transparent = Utils.SetBitmapOpacity(_image16, 80);
                    _image16Dark = Utils.TintBitmap(_image16, Color.Black, 30);
                    RefreshControl();
                }
            }

            /// <summary>
            /// The 16x16 image for this tray item.
            /// </summary>
            public Bitmap Image16
            {
                get { return _image16; }
            }
            private Bitmap _image16;

            /// <summary>
            /// The 16x16 slightly transparent image for this tray item.
            /// </summary>
            public Bitmap Image16Transparent
            {
                get { return _image16Transparent; }
            }
            private Bitmap _image16Transparent;

            /// <summary>
            /// The 16x16 dark image for this tray item.
            /// </summary>
            public Bitmap Image16Dark
            {
                get { return _image16Dark; }
            }
            private Bitmap _image16Dark;

            /// <summary>
            /// Collection of tray items that syncs with the tab control.
            /// </summary>
            public class TrayItemCollection : IList<TrayItem>
            {

                ChromeTabControl _tabControl;

                List<TrayItem> _list = new List<TrayItem>();
                internal void Changed()
                {
                    if ((_tabControl != null))
                    {
                        _tabControl.UpdateAreas();
                    }
                }

                public TrayItemCollection(ChromeTabControl owner)
                {
                    _tabControl = owner;
                }

                public void Add(TrayItem item)
                {
                    item.SetOwnerTabControl(_tabControl);
                    _list.Add(item);
                    Changed();
                }

                public void Clear()
                {
                    for (int i = 0; i <= _list.Count - 1; i++)
                    {
                        _list[i].SetOwnerTabControl((ChromeTabControl)null);
                    }
                    _list.Clear();
                    Changed();
                }

                public bool Contains(TrayItem item)
                {
                    return _list.Contains(item);
                }

                public void CopyTo(TrayItem[] array, int arrayIndex)
                {
                    _list.CopyTo(array, arrayIndex);
                }

                public int Count
                {
                    get { return _list.Count; }
                }

                public bool IsReadOnly
                {
                    get { return true; }
                }

                public bool Remove(TrayItem item)
                {
                    bool rtn = _list.Remove(item);
                    Changed();
                    return rtn;
                }

                public System.Collections.Generic.IEnumerator<TrayItem> GetEnumerator()
                {
                    return _list.GetEnumerator();
                }

                public int IndexOf(TrayItem item)
                {
                    return _list.IndexOf(item);
                }

                public void Insert(int index, TrayItem item)
                {
                    item.SetOwnerTabControl(_tabControl);
                    _list.Insert(index, item);
                    Changed();
                }

                public TrayItem this[int index]
                {
                    get { return _list[index]; }
                    set
                    {
                        value.SetOwnerTabControl(_tabControl);
                        _list[index] = value;
                        Changed();
                    }
                }

                public void RemoveAt(int index)
                {
                    _list.RemoveAt(index);
                    Changed();
                }

                public System.Collections.IEnumerator GetEnumerator1()
                {
                    return _list.GetEnumerator();
                }
                System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
                {
                    return GetEnumerator1();
                }

            }

        }

        /// <summary>
        /// Static utility methods.
        /// </summary>
        public class Utils
        {

            /// <summary>
            /// Tints an image with a specified color and opacity.
            /// </summary>
            /// <param name="source">The bitmap to tint.</param>
            /// <param name="tintcolor">The color to tint the bitmap.</param>
            /// <param name="opacityPercent">The opacity of the tint.</param>
            /// <returns>The new tinted bitmap.</returns>
            public static Bitmap TintBitmap(Bitmap source, Color tintcolor, float opacityPercent)
            {
                if (opacityPercent == 0)
                    return source;
                Bitmap rtn = new Bitmap(source);

                Bitmap source2 = new Bitmap(rtn);
                BitmapPixelManipulator manipulator = new BitmapPixelManipulator(source2);
                manipulator.LockBits();
                for (int y = 0; y <= manipulator.Height - 1; y++)
                {
                    for (int x = 0; x <= manipulator.Width - 1; x++)
                    {
                        Color pix = manipulator.GetPixel(x, y);
                        if (pix.A > 0)
                        {
                            manipulator.SetPixel(x, y, Color.FromArgb(pix.A, tintcolor));
                        }
                    }
                }
                manipulator.UnlockBits();

                Graphics g = Graphics.FromImage(rtn);
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.DrawImage(Utils.SetBitmapOpacity(source, opacityPercent), new Rectangle(0, 0, rtn.Width, rtn.Height));
                g.Dispose();
                return rtn;
            }

            /// <summary>
            /// Resizes a bitmap to a new size. Unconstrained.
            /// </summary>
            /// <param name="source">The image to resize.</param>
            /// <param name="size">The size to resize the image to.</param>
            /// <returns>A resized image as a bitmap.</returns>
            public static Bitmap ResizeBitmap(Bitmap source, Size size)
            {
                if (source.Size.Equals(size))
                    return source;
                Bitmap b = new Bitmap(size.Width, size.Height);
                Graphics g = Graphics.FromImage(b);
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(source, 0, 0, size.Width, size.Height);
                g.Dispose();
                return b;
            }

            /// <summary>
            /// Draws an image with a specific opacity.
            /// </summary>
            /// <param name="g">Graphics to use.</param>
            /// <param name="source">The source image to draw.</param>
            /// <param name="rect">The bounds for the image to draw.</param>
            /// <param name="opacityPercent">The opacity as a percent.</param>
            public static void DrawImageTransparent(Graphics g, Bitmap source, RectangleF rect, float opacityPercent)
            {
                if (opacityPercent > 100)
                    opacityPercent = 100;
                if (opacityPercent < 0)
                    opacityPercent = 0;
                if (opacityPercent == 0)
                    return;
                if (opacityPercent == 100)
                {
                    g.DrawImage(source, rect);
                    return;
                }
                System.Drawing.Imaging.ImageAttributes ia = new System.Drawing.Imaging.ImageAttributes();
                System.Drawing.Imaging.ColorMatrix cm = new System.Drawing.Imaging.ColorMatrix();
                cm.Matrix33 = (opacityPercent / 100);
                ia.SetColorMatrix(cm);
                PointF[] destPoints = new PointF[] { new PointF(rect.X, rect.Y), new PointF(rect.X + source.Width, rect.Y), new PointF(rect.X, rect.Y + source.Height) };
                g.DrawImage(source, destPoints, new Rectangle(0, 0, source.Width, source.Height), GraphicsUnit.Pixel, ia);
            }

            /// <summary>
            /// Draws an image with a specific opacity.
            /// </summary>
            /// <param name="g">The graphics to use.</param>
            /// <param name="source">The image to draw.</param>
            /// <param name="x">The x-coordinate to draw to.</param>
            /// <param name="y">The y-coordinate to draw to.</param>
            /// <param name="opacityPercent">The opacity as a percent.</param>
            public static void DrawImageTransparent(Graphics g, Bitmap source, float x, float y, float opacityPercent)
            {
                DrawImageTransparent(g, source, new RectangleF(x, y, source.Width, source.Height), opacityPercent);
            }


            /// <summary>
            /// Sets the opacity of the bitmap.
            /// </summary>
            /// <param name="source">The bitmap to set the opacity of.</param>
            /// <param name="opacityPercent">The percent of the opacity between 0 and 100.</param>
            /// <returns>The new bitmap.</returns>
            public static Bitmap SetBitmapOpacity(Bitmap source, float opacityPercent)
            {
                Bitmap rtn = new Bitmap(source.Width, source.Height);
                Graphics g = Graphics.FromImage(rtn);
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                DrawImageTransparent(g, source, new RectangleF(0, 0, source.Width, source.Height), opacityPercent);
                g.Dispose();
                return rtn;
            }

            /// <summary>
            /// Returns a rounded rectangle graphics path according to a base rectangle and radius.
            /// </summary>
            /// <param name="g">Graphics to use. For extension purposes.</param>
            /// <param name="baseRect">The rectangle to copy from.</param>
            /// <param name="radius">The radius of the rounded corners.</param>
            /// <returns>A rounded rectangle as a graphics path.</returns>
            public static GraphicsPath GetRoundedRectanglePath(RectangleF baseRect, float radius)
            {
                // Set up the graphics path
                GraphicsPath path = new GraphicsPath();

                // Return the original rectangle if radius is 0
                if (radius <= 0f)
                {
                    path.AddRectangle(baseRect);
                    path.CloseFigure();
                    return path;
                }

                // Return a capsule if needed
                if (radius >= (Math.Min(baseRect.Width, baseRect.Height) / 2.0f))
                    return GetCapsulePath(baseRect);

                // Create the arc
                float diameter = radius * 2.0f;
                SizeF sizef = new SizeF(diameter, diameter);
                RectangleF arc = new RectangleF(baseRect.Location, sizef);

                // Top left arc
                path.AddArc(arc, 180, 90);

                // Top right arc
                arc.X = baseRect.Right - diameter;
                path.AddArc(arc, 270, 90);

                // Bottom right arc
                arc.Y = baseRect.Bottom - diameter;
                path.AddArc(arc, 0, 90);

                // Bottom left arc
                arc.X = baseRect.Left;
                path.AddArc(arc, 90, 90);

                // Close and return
                path.CloseFigure();
                return path;

            }

            /// <summary>
            /// Returns a capsule according to a base rectangle.
            /// </summary>
            /// <param name="g">Graphics to use. For extension purposes.</param>
            /// <param name="baseRect">The base rectangle to copy from.</param>
            /// <returns>A capsule as a graphics path.</returns>
            public static GraphicsPath GetCapsulePath(RectangleF baseRect)
            {
                float diameter;
                RectangleF arc;
                GraphicsPath path = new GraphicsPath();
                try
                {
                    if (baseRect.Width > baseRect.Height)
                    {
                        diameter = baseRect.Height;
                        SizeF sizef = new SizeF(diameter, diameter);
                        arc = new RectangleF(baseRect.Location, sizef);
                        path.AddArc(arc, 90, 180);
                        arc.X = baseRect.Right - diameter;
                        path.AddArc(arc, 270, 180);
                    }
                    else if (baseRect.Width < baseRect.Height)
                    {
                        diameter = baseRect.Height;
                        SizeF sizef = new SizeF(diameter, diameter);
                        arc = new RectangleF(baseRect.Location, sizef);
                        path.AddArc(arc, 180, 180);
                        arc.Y = baseRect.Bottom - diameter;
                        path.AddArc(arc, 0, 180);
                    }
                    else { path.AddEllipse(baseRect); }
                }
                catch { path.AddEllipse(baseRect); }
                finally { path.CloseFigure(); }
                return path;
            }

            /// <summary>
            /// Draws a path's shadow.
            /// </summary>
            /// <param name="g">The graphics to use.</param>
            /// <param name="path">The path to get the shadow for.</param>
            /// <param name="size">The size in pixels of the shadow.</param>
            public static void DrawPathShadow(Graphics g, GraphicsPath path, int size)
            {
                if (size <= 0)
                    return;

                //Create the new path and scale it
                GraphicsPath path2 = (GraphicsPath)path.Clone();
                ScalePath(path2, size);

                //Start stepping through
                int maxOpacity = 35;
                int stepsize = maxOpacity / size;
                for (int i = size - 1; i >= 0; i += -1)
                {
                    //g.FillPath(New SolidBrush(Color.FromArgb(maxOpacity - (stepsize * i), Color.DimGray)), path2)
                    g.DrawPath(new Pen(Color.FromArgb(maxOpacity - (stepsize * i), Color.DimGray)), path2);
                    ScalePath(path2, -1);
                }

            }

            /// <summary>
            /// Scales a graphics path a specific number of pixels.
            /// </summary>
            /// <param name="path">The path to scale.</param>
            /// <param name="pixels">The amount to scale in pixels.</param>
            public static void ScalePath(GraphicsPath path, float pixels)
            {
                RectangleF rect = path.GetBounds();
                path.Warp(new PointF[] {
            new PointF(rect.X - pixels, rect.Y - pixels),
            new PointF(rect.Right + pixels, rect.Y - pixels),
            new PointF(rect.X - pixels, rect.Bottom + pixels)
            }, rect);
            }

            /// <summary>
            /// Moves a graphics path a certain amount of pixels.
            /// </summary>
            /// <param name="path">The path to move.</param>
            /// <param name="xmodifier">The pixels to move in the x position.</param>
            /// <param name="ymodifier">The pixels to move in the y position.</param>
            public static void MovePath(GraphicsPath path, float xmodifier, float ymodifier)
            {
                Matrix translator = new Matrix();
                translator.Translate(xmodifier, ymodifier);
                path.Transform(translator);
            }

            /// <summary>
            /// Draws a rectangle's shadow.
            /// </summary>
            /// <param name="g">The graphics to use.</param>
            /// <param name="rect">The retangle to get the shadow of.</param>
            /// <param name="size">The size of the shadow in pixels.</param>
            public static void DrawPathShadow(Graphics g, RectangleF rect, int size)
            {
                if (size <= 0)
                    return;
                GraphicsPath path = new GraphicsPath();
                path.AddRectangle(rect);
                DrawPathShadow(g, path, size);
            }

            /// <summary>
            /// Locks and unlocks bitmap bits for faster pixel manipulation.
            /// </summary>
            public class BitmapPixelManipulator
            {

                private Bitmap source = null;
                private IntPtr Iptr = IntPtr.Zero;

                private System.Drawing.Imaging.BitmapData bitmapData = null;
                private byte[] _pixels;
                public byte[] Pixels
                {
                    get { return _pixels; }
                    set { _pixels = value; }
                }

                private int _depth;
                public int Depth
                {
                    get { return _depth; }
                    private set { _depth = value; }
                }

                private int _width;
                public int Width
                {
                    get { return _width; }
                    private set { _width = value; }
                }

                private int _height;
                public int Height
                {
                    get { return _height; }
                    private set { _height = value; }
                }

                public BitmapPixelManipulator(Bitmap source)
                {
                    this.source = source;
                }

                public void LockBits()
                {
                    // Get width and height of bitmap
                    Width = source.Width;
                    Height = source.Height;

                    // get total locked pixels count
                    int PixelCount = Width * Height;

                    // Create rectangle to lock
                    Rectangle rect = new Rectangle(0, 0, Width, Height);

                    // get source bitmap pixel format size
                    Depth = System.Drawing.Bitmap.GetPixelFormatSize(source.PixelFormat);

                    // Check if bpp (Bits Per Pixel) is 8, 24, or 32
                    if (Depth != 8 && Depth != 24 && Depth != 32)
                    {
                        throw new ArgumentException("Only 8, 24 and 32 bpp images are supported.");
                    }

                    // Lock bitmap and return bitmap data
                    bitmapData = source.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, source.PixelFormat);

                    // create byte array to copy pixel values
                    int step = Depth / 8;
                    Pixels = new byte[PixelCount * step];
                    Iptr = bitmapData.Scan0;

                    // Copy data from pointer to array
                    System.Runtime.InteropServices.Marshal.Copy(Iptr, Pixels, 0, Pixels.Length);
                }

                public void UnlockBits()
                {
                    // Copy data from byte array to pointer
                    System.Runtime.InteropServices.Marshal.Copy(Pixels, 0, Iptr, Pixels.Length);

                    // Unlock bitmap data
                    source.UnlockBits(bitmapData);
                }

                public Color GetPixel(int x, int y)
                {
                    Color clr = Color.Empty;

                    // Get color components count
                    int cCount = Depth / 8;

                    // Get start index of the specified pixel
                    int i = ((y * Width) + x) * cCount;

                    if (i > Pixels.Length - cCount)
                    {
                        throw new IndexOutOfRangeException();
                    }

                    if (Depth == 32)
                    {
                        // For 32 bpp get Red, Green, Blue and Alpha
                        byte b = Pixels[i];
                        byte g = Pixels[i + 1];
                        byte r = Pixels[i + 2];
                        byte a = Pixels[i + 3];
                        // a
                        clr = Color.FromArgb(a, r, g, b);
                    }
                    if (Depth == 24)
                    {
                        // For 24 bpp get Red, Green and Blue
                        byte b = Pixels[i];
                        byte g = Pixels[i + 1];
                        byte r = Pixels[i + 2];
                        clr = Color.FromArgb(r, g, b);
                    }
                    if (Depth == 8)
                    {
                        // For 8 bpp get color value (Red, Green and Blue values are the same)
                        byte c = Pixels[i];
                        clr = Color.FromArgb(c, c, c);
                    }
                    return clr;
                }

                public void SetPixel(int x, int y, Color color)
                {
                    // Get color components count
                    int cCount = Depth / 8;

                    // Get start index of the specified pixel
                    int i = ((y * Width) + x) * cCount;

                    if (Depth == 32)
                    {
                        // For 32 bpp set Red, Green, Blue and Alpha
                        Pixels[i] = color.B;
                        Pixels[i + 1] = color.G;
                        Pixels[i + 2] = color.R;
                        Pixels[i + 3] = color.A;
                    }
                    if (Depth == 24)
                    {
                        // For 24 bpp set Red, Green and Blue
                        Pixels[i] = color.B;
                        Pixels[i + 1] = color.G;
                        Pixels[i + 2] = color.R;
                    }
                    if (Depth == 8)
                    {
                        // For 8 bpp set color value (Red, Green and Blue values are the same)
                        Pixels[i] = color.B;
                    }
                }

            }

        }

        /// <summary>
        /// Functions designed to extend the glass of aero into the client.
        /// Allowing the Chrome look feel more genuine.
        /// </summary>
        public class AeroFunctions
        {

            [DllImport("dwmapi.dll", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Auto)]
            public static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref Margins pMarinset);

            [DllImport("dwmapi.dll", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Auto)]
            public static extern void DwmIsCompositionEnabled(ref int enabledptr);

            /// <summary>
            /// Determines whether or not Aero is enabled on the system.
            /// </summary>
            /// <returns>True if enabled.</returns>
            public static bool IsWindowsAeroEnabled()
            {
                System.OperatingSystem osInfo = System.Environment.OSVersion;
                if (osInfo.Version.Major < 6)
                    return false;
                int compositionEnabled = 0;
                DwmIsCompositionEnabled(ref compositionEnabled);
                if (compositionEnabled > 0)
                    return true;
                else
                    return false;
            }
            
            /// <summary>
            /// The margins defined for the API calls.
            /// </summary>
            public struct Margins
            {
                public int cxLeftWidth;
                public int cxRightWidth;
                public int cyTopHeight;
                public int cyBottomHeight;
            }

            /// <summary>
            /// Makes a form have aero glass extend on it.
            /// </summary>
            /// <param name="hWnd">The handle of the form.</param>
            /// <param name="leftMargin">The left margin.</param>
            /// <param name="rightMargin">The right margin.</param>
            /// <param name="topMargin">The top margin.</param>
            /// <param name="bottomMargin">The bottom margin.</param>
            public static bool MakeWindowGlass(IntPtr hWnd, int leftMargin, int rightMargin, int topMargin, int bottomMargin)
            {
                if (!IsWindowsAeroEnabled())
                    return false;
                Margins margins = new Margins();
                {
                    margins.cxLeftWidth = leftMargin;
                    margins.cxRightWidth = rightMargin;
                    margins.cyTopHeight = topMargin;
                    margins.cyBottomHeight = bottomMargin;
                }
                DwmExtendFrameIntoClientArea(hWnd, ref margins);
                return true;
            }

            /// <summary>
            /// Gives a form a transparent tab control strip if the tab control is docked
            /// as fill.
            /// </summary>
            /// <param name="form">The form to prepare.</param>
            /// <returns>True if successful</returns>
            public static void ChromifyWindow(Form form, ChromeTabControl tabcontrol)
            {
                if (MakeWindowGlass(form.Handle, 5, 5, 40, 5))
                    tabcontrol.BackColor = Color.Transparent;
                else
                    tabcontrol.BackColor = Color.Gray;
            }

        }

    }
}
