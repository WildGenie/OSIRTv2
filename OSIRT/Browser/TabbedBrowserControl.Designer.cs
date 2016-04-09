namespace OSIRT.Browser
{
    partial class TabbedBrowserControl
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
            this.uiBrowserStatusStrip = new System.Windows.Forms.StatusStrip();
            this.uiStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.uiActionLoggedToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.uiBrowserTabControl = new DotNetChromeTabs.ChromeTabControl();
            this.uiBrowserPanel.SuspendLayout();
            this.uiBrowserStatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiBrowserPanel
            // 
            this.uiBrowserPanel.Controls.Add(this.uiBrowserTabControl);
            this.uiBrowserPanel.Controls.Add(this.uiBrowserStatusStrip);
            this.uiBrowserPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiBrowserPanel.Location = new System.Drawing.Point(0, 0);
            this.uiBrowserPanel.Name = "uiBrowserPanel";
            this.uiBrowserPanel.Size = new System.Drawing.Size(800, 615);
            this.uiBrowserPanel.TabIndex = 1;
            // 
            // uiBrowserStatusStrip
            // 
            this.uiBrowserStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uiStatusLabel,
            this.toolStripStatusLabel1,
            this.uiActionLoggedToolStripStatusLabel});
            this.uiBrowserStatusStrip.Location = new System.Drawing.Point(0, 593);
            this.uiBrowserStatusStrip.Name = "uiBrowserStatusStrip";
            this.uiBrowserStatusStrip.Size = new System.Drawing.Size(800, 22);
            this.uiBrowserStatusStrip.TabIndex = 0;
            this.uiBrowserStatusStrip.Text = "statusStrip1";
            this.uiBrowserStatusStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.uiBrowserStatusStrip_ItemClicked);
            // 
            // uiStatusLabel
            // 
            this.uiStatusLabel.Name = "uiStatusLabel";
            this.uiStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(785, 17);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // uiActionLoggedToolStripStatusLabel
            // 
            this.uiActionLoggedToolStripStatusLabel.Name = "uiActionLoggedToolStripStatusLabel";
            this.uiActionLoggedToolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // uiBrowserTabControl
            // 
            this.uiBrowserTabControl.AllowDrop = true;
            this.uiBrowserTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiBrowserTabControl.Location = new System.Drawing.Point(0, 0);
            this.uiBrowserTabControl.Name = "uiBrowserTabControl";
            this.uiBrowserTabControl.NewTabButton = true;
            this.uiBrowserTabControl.Size = new System.Drawing.Size(800, 596);
            this.uiBrowserTabControl.TabIndex = 1;
            this.uiBrowserTabControl.Text = "chromeTabControl1";
            this.uiBrowserTabControl.Click += new System.EventHandler(this.uiBrowserTabControl_Click);
            // 
            // TabbedBrowserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uiBrowserPanel);
            this.Name = "TabbedBrowserControl";
            this.Size = new System.Drawing.Size(800, 615);
            this.uiBrowserPanel.ResumeLayout(false);
            this.uiBrowserPanel.PerformLayout();
            this.uiBrowserStatusStrip.ResumeLayout(false);
            this.uiBrowserStatusStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel uiBrowserPanel;
        private System.Windows.Forms.StatusStrip uiBrowserStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel uiStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel uiActionLoggedToolStripStatusLabel;
        private DotNetChromeTabs.ChromeTabControl uiBrowserTabControl;
    }
}
