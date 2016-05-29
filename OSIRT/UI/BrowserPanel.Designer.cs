namespace OSIRT.UI
{
    partial class BrowserPanel
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BrowserPanel));
            this.uiBrowserPanel = new System.Windows.Forms.Panel();
            this.uiBrowserToolStrip = new System.Windows.Forms.ToolStrip();
            this.uiHomeButton = new System.Windows.Forms.ToolStripButton();
            this.uiLBackButton = new System.Windows.Forms.ToolStripButton();
            this.uiForwardButton = new System.Windows.Forms.ToolStripButton();
            this.uiRefreshButton = new System.Windows.Forms.ToolStripButton();
            this.uiScreenshotButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.snippetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.currentViewScreenshotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.currentViewTimedScreenshotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uiVideoCaptureButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.markerWindowToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.uiAttachmentToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.uiCaseNotesButton = new System.Windows.Forms.ToolStripButton();
            this.uiURLComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.uiAuditLogToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.uiOptionsToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.uiBrowserMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeCaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uiTabbedBrowserControl = new OSIRT.Browser.TabbedBrowserControl();
            this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
            this.uiBrowserPanel.SuspendLayout();
            this.uiBrowserToolStrip.SuspendLayout();
            this.uiBrowserMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiBrowserPanel
            // 
            this.uiBrowserPanel.Controls.Add(this.uiBrowserToolStrip);
            this.uiBrowserPanel.Controls.Add(this.uiBrowserMenuStrip);
            this.uiBrowserPanel.Controls.Add(this.uiTabbedBrowserControl);
            this.uiBrowserPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiBrowserPanel.Location = new System.Drawing.Point(0, 0);
            this.uiBrowserPanel.Name = "uiBrowserPanel";
            this.uiBrowserPanel.Size = new System.Drawing.Size(1089, 698);
            this.uiBrowserPanel.TabIndex = 0;
            // 
            // uiBrowserToolStrip
            // 
            this.uiBrowserToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uiHomeButton,
            this.uiLBackButton,
            this.uiForwardButton,
            this.uiRefreshButton,
            this.uiScreenshotButton,
            this.toolStripDropDownButton1,
            this.uiVideoCaptureButton,
            this.toolStripDropDownButton2,
            this.uiAttachmentToolStripButton,
            this.uiCaseNotesButton,
            this.uiURLComboBox,
            this.uiAuditLogToolStripButton,
            this.uiOptionsToolStripButton});
            this.uiBrowserToolStrip.Location = new System.Drawing.Point(0, 0);
            this.uiBrowserToolStrip.Name = "uiBrowserToolStrip";
            this.uiBrowserToolStrip.Size = new System.Drawing.Size(1089, 25);
            this.uiBrowserToolStrip.TabIndex = 1;
            // 
            // uiHomeButton
            // 
            this.uiHomeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.uiHomeButton.Image = global::OSIRT.Properties.Resources.house;
            this.uiHomeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uiHomeButton.Name = "uiHomeButton";
            this.uiHomeButton.Size = new System.Drawing.Size(23, 22);
            this.uiHomeButton.ToolTipText = "Home";
            // 
            // uiLBackButton
            // 
            this.uiLBackButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.uiLBackButton.Image = global::OSIRT.Properties.Resources.arrow_left;
            this.uiLBackButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uiLBackButton.Name = "uiLBackButton";
            this.uiLBackButton.Size = new System.Drawing.Size(23, 22);
            this.uiLBackButton.ToolTipText = "Go Back";
            this.uiLBackButton.Click += new System.EventHandler(this.uiLBackButton_Click);
            // 
            // uiForwardButton
            // 
            this.uiForwardButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.uiForwardButton.Image = global::OSIRT.Properties.Resources.arrow_right;
            this.uiForwardButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uiForwardButton.Name = "uiForwardButton";
            this.uiForwardButton.Size = new System.Drawing.Size(23, 22);
            this.uiForwardButton.Text = "uiRightButton";
            this.uiForwardButton.ToolTipText = "Go Forward";
            this.uiForwardButton.Click += new System.EventHandler(this.uiForwardButton_Click);
            // 
            // uiRefreshButton
            // 
            this.uiRefreshButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.uiRefreshButton.Image = global::OSIRT.Properties.Resources.arrow_rotate_clockwise;
            this.uiRefreshButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uiRefreshButton.Name = "uiRefreshButton";
            this.uiRefreshButton.Size = new System.Drawing.Size(23, 22);
            this.uiRefreshButton.Text = "toolStripButton4";
            this.uiRefreshButton.ToolTipText = "Refresh Page";
            this.uiRefreshButton.Click += new System.EventHandler(this.uiRefreshButton_Click);
            // 
            // uiScreenshotButton
            // 
            this.uiScreenshotButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.uiScreenshotButton.Image = global::OSIRT.Properties.Resources.camera;
            this.uiScreenshotButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uiScreenshotButton.Name = "uiScreenshotButton";
            this.uiScreenshotButton.Size = new System.Drawing.Size(23, 22);
            this.uiScreenshotButton.Text = "toolStripButton1";
            this.uiScreenshotButton.ToolTipText = "Capture screenshot";
            this.uiScreenshotButton.Click += new System.EventHandler(this.uiScreenshotButton_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.AutoSize = false;
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.snippetToolStripMenuItem,
            this.currentViewScreenshotToolStripMenuItem,
            this.currentViewTimedScreenshotToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(18, 22);
            this.toolStripDropDownButton1.ToolTipText = "More screen capture options";
            // 
            // snippetToolStripMenuItem
            // 
            this.snippetToolStripMenuItem.Image = global::OSIRT.Properties.Resources.cut;
            this.snippetToolStripMenuItem.Name = "snippetToolStripMenuItem";
            this.snippetToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.snippetToolStripMenuItem.Text = "Snippet";
            this.snippetToolStripMenuItem.Click += new System.EventHandler(this.snippetToolStripMenuItem_Click);
            // 
            // currentViewScreenshotToolStripMenuItem
            // 
            this.currentViewScreenshotToolStripMenuItem.Image = global::OSIRT.Properties.Resources.measure_crop;
            this.currentViewScreenshotToolStripMenuItem.Name = "currentViewScreenshotToolStripMenuItem";
            this.currentViewScreenshotToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.currentViewScreenshotToolStripMenuItem.Text = "Current View Screenshot";
            this.currentViewScreenshotToolStripMenuItem.Click += new System.EventHandler(this.currentViewScreenshotToolStripMenuItem_Click);
            // 
            // currentViewTimedScreenshotToolStripMenuItem
            // 
            this.currentViewTimedScreenshotToolStripMenuItem.Image = global::OSIRT.Properties.Resources.hourglass;
            this.currentViewTimedScreenshotToolStripMenuItem.Name = "currentViewTimedScreenshotToolStripMenuItem";
            this.currentViewTimedScreenshotToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.currentViewTimedScreenshotToolStripMenuItem.Text = "Current View Timed Screenshot";
            this.currentViewTimedScreenshotToolStripMenuItem.Click += new System.EventHandler(this.currentViewTimedScreenshotToolStripMenuItem_Click);
            // 
            // uiVideoCaptureButton
            // 
            this.uiVideoCaptureButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.uiVideoCaptureButton.Image = global::OSIRT.Properties.Resources.start_rec;
            this.uiVideoCaptureButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uiVideoCaptureButton.Name = "uiVideoCaptureButton";
            this.uiVideoCaptureButton.Size = new System.Drawing.Size(23, 22);
            this.uiVideoCaptureButton.ToolTipText = "Start video capture";
            this.uiVideoCaptureButton.Click += new System.EventHandler(this.uiVideoCaptureButton_Click);
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.AutoSize = false;
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.markerWindowToolStripMenuItem1});
            this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(18, 22);
            this.toolStripDropDownButton2.Text = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.ToolTipText = "More video options";
            // 
            // markerWindowToolStripMenuItem1
            // 
            this.markerWindowToolStripMenuItem1.Image = global::OSIRT.Properties.Resources.transform_crop;
            this.markerWindowToolStripMenuItem1.Name = "markerWindowToolStripMenuItem1";
            this.markerWindowToolStripMenuItem1.Size = new System.Drawing.Size(158, 22);
            this.markerWindowToolStripMenuItem1.Text = "Marker Window";
            this.markerWindowToolStripMenuItem1.Click += new System.EventHandler(this.markerWindowToolStripMenuItem1_Click);
            // 
            // uiAttachmentToolStripButton
            // 
            this.uiAttachmentToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.uiAttachmentToolStripButton.Image = global::OSIRT.Properties.Resources.attach;
            this.uiAttachmentToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uiAttachmentToolStripButton.Name = "uiAttachmentToolStripButton";
            this.uiAttachmentToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.uiAttachmentToolStripButton.ToolTipText = "Attach item to this case";
            this.uiAttachmentToolStripButton.Click += new System.EventHandler(this.uiAttachmentToolStripButton_Click);
            // 
            // uiCaseNotesButton
            // 
            this.uiCaseNotesButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.uiCaseNotesButton.Image = global::OSIRT.Properties.Resources.notepad;
            this.uiCaseNotesButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uiCaseNotesButton.Name = "uiCaseNotesButton";
            this.uiCaseNotesButton.Size = new System.Drawing.Size(23, 22);
            this.uiCaseNotesButton.ToolTipText = "Add note to case";
            this.uiCaseNotesButton.Click += new System.EventHandler(this.uiCaseNotesButton_Click);
            // 
            // uiURLComboBox
            // 
            this.uiURLComboBox.Name = "uiURLComboBox";
            this.uiURLComboBox.Size = new System.Drawing.Size(350, 25);
            // 
            // uiAuditLogToolStripButton
            // 
            this.uiAuditLogToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.uiAuditLogToolStripButton.Image = global::OSIRT.Properties.Resources.log;
            this.uiAuditLogToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uiAuditLogToolStripButton.Name = "uiAuditLogToolStripButton";
            this.uiAuditLogToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.uiAuditLogToolStripButton.Text = "Audit Log";
            this.uiAuditLogToolStripButton.ToolTipText = "Display audit log";
            this.uiAuditLogToolStripButton.Click += new System.EventHandler(this.uiAuditLogToolStripButton_Click);
            // 
            // uiOptionsToolStripButton
            // 
            this.uiOptionsToolStripButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.uiOptionsToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.uiOptionsToolStripButton.Image = global::OSIRT.Properties.Resources.options;
            this.uiOptionsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uiOptionsToolStripButton.Name = "uiOptionsToolStripButton";
            this.uiOptionsToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.uiOptionsToolStripButton.Text = "Options";
            this.uiOptionsToolStripButton.Click += new System.EventHandler(this.uiOptionsToolStripButton_Click);
            // 
            // uiBrowserMenuStrip
            // 
            this.uiBrowserMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.uiBrowserMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.uiBrowserMenuStrip.Name = "uiBrowserMenuStrip";
            this.uiBrowserMenuStrip.Size = new System.Drawing.Size(1089, 24);
            this.uiBrowserMenuStrip.TabIndex = 0;
            this.uiBrowserMenuStrip.Visible = false;
            this.uiBrowserMenuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.uiBrowserMenuStrip_ItemClicked);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeCaseToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // closeCaseToolStripMenuItem
            // 
            this.closeCaseToolStripMenuItem.Name = "closeCaseToolStripMenuItem";
            this.closeCaseToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.closeCaseToolStripMenuItem.Text = "Close Case";
            this.closeCaseToolStripMenuItem.Click += new System.EventHandler(this.closeCaseToolStripMenuItem_Click);
            // 
            // uiTabbedBrowserControl
            // 
            this.uiTabbedBrowserControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiTabbedBrowserControl.Location = new System.Drawing.Point(0, 39);
            this.uiTabbedBrowserControl.Name = "uiTabbedBrowserControl";
            this.uiTabbedBrowserControl.Size = new System.Drawing.Size(1089, 659);
            this.uiTabbedBrowserControl.TabIndex = 2;
            // 
            // BottomToolStripPanel
            // 
            this.BottomToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.BottomToolStripPanel.Name = "BottomToolStripPanel";
            this.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.BottomToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.BottomToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // TopToolStripPanel
            // 
            this.TopToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.TopToolStripPanel.Name = "TopToolStripPanel";
            this.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.TopToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.TopToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // RightToolStripPanel
            // 
            this.RightToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.RightToolStripPanel.Name = "RightToolStripPanel";
            this.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.RightToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.RightToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // LeftToolStripPanel
            // 
            this.LeftToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftToolStripPanel.Name = "LeftToolStripPanel";
            this.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.LeftToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.LeftToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // ContentPanel
            // 
            this.ContentPanel.Size = new System.Drawing.Size(343, 147);
            // 
            // BrowserPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.uiBrowserPanel);
            this.Name = "BrowserPanel";
            this.Size = new System.Drawing.Size(1089, 698);
            this.Load += new System.EventHandler(this.BrowserPanel_Load);
            this.uiBrowserPanel.ResumeLayout(false);
            this.uiBrowserPanel.PerformLayout();
            this.uiBrowserToolStrip.ResumeLayout(false);
            this.uiBrowserToolStrip.PerformLayout();
            this.uiBrowserMenuStrip.ResumeLayout(false);
            this.uiBrowserMenuStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel uiBrowserPanel;
        private System.Windows.Forms.ToolStrip uiBrowserToolStrip;
        private System.Windows.Forms.ToolStripButton uiHomeButton;
        private System.Windows.Forms.ToolStripButton uiLBackButton;
        private System.Windows.Forms.ToolStripButton uiForwardButton;
        private System.Windows.Forms.ToolStripButton uiRefreshButton;
        private System.Windows.Forms.ToolStripButton uiScreenshotButton;
        private System.Windows.Forms.ToolStripButton uiVideoCaptureButton;
        private System.Windows.Forms.ToolStripComboBox uiURLComboBox;
        private System.Windows.Forms.ToolStripButton uiCaseNotesButton;
        private System.Windows.Forms.ToolStripButton uiAttachmentToolStripButton;
        private Browser.TabbedBrowserControl uiTabbedBrowserControl;
        private System.Windows.Forms.MenuStrip uiBrowserMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeCaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripPanel BottomToolStripPanel;
        private System.Windows.Forms.ToolStripPanel TopToolStripPanel;
        private System.Windows.Forms.ToolStripPanel RightToolStripPanel;
        private System.Windows.Forms.ToolStripPanel LeftToolStripPanel;
        private System.Windows.Forms.ToolStripContentPanel ContentPanel;
        private System.Windows.Forms.ToolStripButton uiAuditLogToolStripButton;
        private System.Windows.Forms.ToolStripButton uiOptionsToolStripButton;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem snippetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem currentViewScreenshotToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem currentViewTimedScreenshotToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem markerWindowToolStripMenuItem1;
    }
}
