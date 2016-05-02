namespace OSIRT.UI.AuditLog
{
    partial class AuditLogForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.uiAuditLogSplitContainer = new System.Windows.Forms.SplitContainer();
            this.uiAuditOptionsToolStrip = new System.Windows.Forms.ToolStrip();
            this.uiSearchToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.uiExportReportToolStripButton = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.uiAuditLogSplitContainer)).BeginInit();
            this.uiAuditLogSplitContainer.SuspendLayout();
            this.uiAuditOptionsToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiAuditLogSplitContainer
            // 
            this.uiAuditLogSplitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiAuditLogSplitContainer.Location = new System.Drawing.Point(0, 38);
            this.uiAuditLogSplitContainer.Name = "uiAuditLogSplitContainer";
            // 
            // uiAuditLogSplitContainer.Panel1
            // 
            this.uiAuditLogSplitContainer.Panel1.BackColor = System.Drawing.Color.SteelBlue;
            // 
            // uiAuditLogSplitContainer.Panel2
            // 
            this.uiAuditLogSplitContainer.Panel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.uiAuditLogSplitContainer.Size = new System.Drawing.Size(967, 638);
            this.uiAuditLogSplitContainer.SplitterDistance = 315;
            this.uiAuditLogSplitContainer.TabIndex = 0;
            // 
            // uiAuditOptionsToolStrip
            // 
            this.uiAuditOptionsToolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.uiAuditOptionsToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uiSearchToolStripButton,
            this.toolStripSeparator1,
            this.uiExportReportToolStripButton});
            this.uiAuditOptionsToolStrip.Location = new System.Drawing.Point(0, 0);
            this.uiAuditOptionsToolStrip.Name = "uiAuditOptionsToolStrip";
            this.uiAuditOptionsToolStrip.Size = new System.Drawing.Size(967, 39);
            this.uiAuditOptionsToolStrip.TabIndex = 14;
            this.uiAuditOptionsToolStrip.Text = "toolStrip1";
            // 
            // uiSearchToolStripButton
            // 
            this.uiSearchToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.uiSearchToolStripButton.Enabled = false;
            this.uiSearchToolStripButton.Image = global::OSIRT.Properties.Resources.search;
            this.uiSearchToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uiSearchToolStripButton.Name = "uiSearchToolStripButton";
            this.uiSearchToolStripButton.Size = new System.Drawing.Size(36, 36);
            this.uiSearchToolStripButton.Text = "Search";
            this.uiSearchToolStripButton.Click += new System.EventHandler(this.uiSearchToolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // uiExportReportToolStripButton
            // 
            this.uiExportReportToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.uiExportReportToolStripButton.Image = global::OSIRT.Properties.Resources.report;
            this.uiExportReportToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uiExportReportToolStripButton.Name = "uiExportReportToolStripButton";
            this.uiExportReportToolStripButton.Size = new System.Drawing.Size(36, 36);
            this.uiExportReportToolStripButton.Text = "Export report ";
            this.uiExportReportToolStripButton.Click += new System.EventHandler(this.uiExportReportToolStripButton_Click);
            // 
            // AuditLogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 676);
            this.Controls.Add(this.uiAuditOptionsToolStrip);
            this.Controls.Add(this.uiAuditLogSplitContainer);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "AuditLogForm";
            this.Text = "Audit Log";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AuditLogForm_FormClosing);
            this.Load += new System.EventHandler(this.uiAuditLogForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uiAuditLogSplitContainer)).EndInit();
            this.uiAuditLogSplitContainer.ResumeLayout(false);
            this.uiAuditOptionsToolStrip.ResumeLayout(false);
            this.uiAuditOptionsToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer uiAuditLogSplitContainer;
        private System.Windows.Forms.ToolStrip uiAuditOptionsToolStrip;
        private System.Windows.Forms.ToolStripButton uiSearchToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton uiExportReportToolStripButton;
    }
}