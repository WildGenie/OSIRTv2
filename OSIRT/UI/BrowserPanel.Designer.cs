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
            this.uiBrowserPanel = new System.Windows.Forms.Panel();
            this.uiTabbedBrowserControl = new OSIRT.Browser.TabbedBrowserControl();
            this.uiBrowserToolStrip = new System.Windows.Forms.ToolStrip();
            this.uiHomeButton = new System.Windows.Forms.ToolStripButton();
            this.uiLBackButton = new System.Windows.Forms.ToolStripButton();
            this.uiForwardButton = new System.Windows.Forms.ToolStripButton();
            this.uiRefreshButton = new System.Windows.Forms.ToolStripButton();
            this.uiScreenshotButton = new System.Windows.Forms.ToolStripButton();
            this.uiVideoCaptureButton = new System.Windows.Forms.ToolStripButton();
            this.uiAttachmentToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.uiURLComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.uiCaseNotesButton = new System.Windows.Forms.ToolStripButton();
            this.uiAddTabButton = new System.Windows.Forms.ToolStripButton();
            this.uiBrowserMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newTabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.auditLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uiBrowserPanel.SuspendLayout();
            this.uiBrowserToolStrip.SuspendLayout();
            this.uiBrowserMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiBrowserPanel
            // 
            this.uiBrowserPanel.Controls.Add(this.uiTabbedBrowserControl);
            this.uiBrowserPanel.Controls.Add(this.uiBrowserToolStrip);
            this.uiBrowserPanel.Controls.Add(this.uiBrowserMenuStrip);
            this.uiBrowserPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiBrowserPanel.Location = new System.Drawing.Point(0, 0);
            this.uiBrowserPanel.Name = "uiBrowserPanel";
            this.uiBrowserPanel.Size = new System.Drawing.Size(838, 525);
            this.uiBrowserPanel.TabIndex = 0;
            // 
            // uiTabbedBrowserControl
            // 
            this.uiTabbedBrowserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTabbedBrowserControl.Location = new System.Drawing.Point(0, 49);
            this.uiTabbedBrowserControl.Name = "uiTabbedBrowserControl";
            this.uiTabbedBrowserControl.Size = new System.Drawing.Size(838, 476);
            this.uiTabbedBrowserControl.TabIndex = 2;
            this.uiTabbedBrowserControl.Load += new System.EventHandler(this.uiTabbedBrowserControl_Load);
            // 
            // uiBrowserToolStrip
            // 
            this.uiBrowserToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uiHomeButton,
            this.uiLBackButton,
            this.uiForwardButton,
            this.uiRefreshButton,
            this.uiScreenshotButton,
            this.uiVideoCaptureButton,
            this.uiAttachmentToolStripButton,
            this.uiURLComboBox,
            this.uiCaseNotesButton,
            this.uiAddTabButton});
            this.uiBrowserToolStrip.Location = new System.Drawing.Point(0, 24);
            this.uiBrowserToolStrip.Name = "uiBrowserToolStrip";
            this.uiBrowserToolStrip.Size = new System.Drawing.Size(838, 25);
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
            // uiVideoCaptureButton
            // 
            this.uiVideoCaptureButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.uiVideoCaptureButton.Image = global::OSIRT.Properties.Resources.film;
            this.uiVideoCaptureButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uiVideoCaptureButton.Name = "uiVideoCaptureButton";
            this.uiVideoCaptureButton.Size = new System.Drawing.Size(23, 22);
            this.uiVideoCaptureButton.ToolTipText = "Start video capture";
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
            // uiURLComboBox
            // 
            this.uiURLComboBox.Name = "uiURLComboBox";
            this.uiURLComboBox.Size = new System.Drawing.Size(350, 25);
            // 
            // uiCaseNotesButton
            // 
            this.uiCaseNotesButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.uiCaseNotesButton.Image = global::OSIRT.Properties.Resources.notepad;
            this.uiCaseNotesButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uiCaseNotesButton.Name = "uiCaseNotesButton";
            this.uiCaseNotesButton.Size = new System.Drawing.Size(23, 22);
            this.uiCaseNotesButton.Click += new System.EventHandler(this.uiCaseNotesButton_Click);
            // 
            // uiAddTabButton
            // 
            this.uiAddTabButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.uiAddTabButton.Image = global::OSIRT.Properties.Resources.new_tab;
            this.uiAddTabButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uiAddTabButton.Name = "uiAddTabButton";
            this.uiAddTabButton.Size = new System.Drawing.Size(23, 22);
            this.uiAddTabButton.Text = "toolStripButton1";
            this.uiAddTabButton.ToolTipText = "Open a new tab";
            this.uiAddTabButton.Click += new System.EventHandler(this.uiAddTabButton_Click);
            // 
            // uiBrowserMenuStrip
            // 
            this.uiBrowserMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.uiBrowserMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.uiBrowserMenuStrip.Name = "uiBrowserMenuStrip";
            this.uiBrowserMenuStrip.Size = new System.Drawing.Size(838, 24);
            this.uiBrowserMenuStrip.TabIndex = 0;
            this.uiBrowserMenuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.uiBrowserMenuStrip_ItemClicked);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newTabToolStripMenuItem,
            this.auditLogToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newTabToolStripMenuItem
            // 
            this.newTabToolStripMenuItem.Name = "newTabToolStripMenuItem";
            this.newTabToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.newTabToolStripMenuItem.Text = "New Tab";
            // 
            // auditLogToolStripMenuItem
            // 
            this.auditLogToolStripMenuItem.Name = "auditLogToolStripMenuItem";
            this.auditLogToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.auditLogToolStripMenuItem.Text = "Audit Log";
            this.auditLogToolStripMenuItem.Click += new System.EventHandler(this.auditLogToolStripMenuItem_Click);
            // 
            // BrowserPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            //this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.uiBrowserPanel);
            this.Name = "BrowserPanel";
            this.Size = new System.Drawing.Size(838, 525);
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
        private System.Windows.Forms.MenuStrip uiBrowserMenuStrip;
        private Browser.TabbedBrowserControl uiTabbedBrowserControl;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newTabToolStripMenuItem;
        private System.Windows.Forms.ToolStrip uiBrowserToolStrip;
        private System.Windows.Forms.ToolStripButton uiHomeButton;
        private System.Windows.Forms.ToolStripButton uiLBackButton;
        private System.Windows.Forms.ToolStripButton uiForwardButton;
        private System.Windows.Forms.ToolStripButton uiRefreshButton;
        private System.Windows.Forms.ToolStripButton uiScreenshotButton;
        private System.Windows.Forms.ToolStripButton uiVideoCaptureButton;
        private System.Windows.Forms.ToolStripComboBox uiURLComboBox;
        private System.Windows.Forms.ToolStripButton uiCaseNotesButton;
        private System.Windows.Forms.ToolStripButton uiAddTabButton;
        private System.Windows.Forms.ToolStripButton uiAttachmentToolStripButton;
        private System.Windows.Forms.ToolStripMenuItem auditLogToolStripMenuItem;
    }
}
