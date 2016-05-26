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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuditLogForm));
            this.uiAuditLogSplitContainer = new System.Windows.Forms.SplitContainer();
            this.uiAuditOptionsToolStrip = new System.Windows.Forms.ToolStrip();
            this.uiExportReportToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.uiBackToAuditLogToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.uiSearchSelectionComboBox = new System.Windows.Forms.ComboBox();
            this.uiSearchButton = new System.Windows.Forms.Button();
            this.uiSearchTextBox = new System.Windows.Forms.TextBox();
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
            this.uiExportReportToolStripButton,
            this.uiBackToAuditLogToolStripButton});
            this.uiAuditOptionsToolStrip.Location = new System.Drawing.Point(0, 0);
            this.uiAuditOptionsToolStrip.Name = "uiAuditOptionsToolStrip";
            this.uiAuditOptionsToolStrip.Size = new System.Drawing.Size(967, 39);
            this.uiAuditOptionsToolStrip.TabIndex = 14;
            this.uiAuditOptionsToolStrip.Text = "toolStrip1";
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
            // uiBackToAuditLogToolStripButton
            // 
            this.uiBackToAuditLogToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.uiBackToAuditLogToolStripButton.Enabled = false;
            this.uiBackToAuditLogToolStripButton.Image = global::OSIRT.Properties.Resources.log;
            this.uiBackToAuditLogToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uiBackToAuditLogToolStripButton.Name = "uiBackToAuditLogToolStripButton";
            this.uiBackToAuditLogToolStripButton.Size = new System.Drawing.Size(36, 36);
            this.uiBackToAuditLogToolStripButton.ToolTipText = "Back to audit log";
            this.uiBackToAuditLogToolStripButton.Click += new System.EventHandler(this.uiBackToAuditLogToolStripButton_Click);
            // 
            // uiSearchSelectionComboBox
            // 
            this.uiSearchSelectionComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiSearchSelectionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.uiSearchSelectionComboBox.FormattingEnabled = true;
            this.uiSearchSelectionComboBox.Items.AddRange(new object[] {
            "Current Tab",
            "All Tabs",
            "This Page"});
            this.uiSearchSelectionComboBox.Location = new System.Drawing.Point(742, 10);
            this.uiSearchSelectionComboBox.Name = "uiSearchSelectionComboBox";
            this.uiSearchSelectionComboBox.Size = new System.Drawing.Size(135, 21);
            this.uiSearchSelectionComboBox.TabIndex = 17;
            // 
            // uiSearchButton
            // 
            this.uiSearchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiSearchButton.Location = new System.Drawing.Point(883, 10);
            this.uiSearchButton.Name = "uiSearchButton";
            this.uiSearchButton.Size = new System.Drawing.Size(75, 21);
            this.uiSearchButton.TabIndex = 16;
            this.uiSearchButton.Text = "Search";
            this.uiSearchButton.UseVisualStyleBackColor = true;
            this.uiSearchButton.Click += new System.EventHandler(this.uiSearchButton_Click);
            // 
            // uiSearchTextBox
            // 
            this.uiSearchTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiSearchTextBox.Location = new System.Drawing.Point(481, 10);
            this.uiSearchTextBox.Name = "uiSearchTextBox";
            this.uiSearchTextBox.Size = new System.Drawing.Size(255, 20);
            this.uiSearchTextBox.TabIndex = 15;
            this.uiSearchTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uiSearchTextBox_KeyDown);
            // 
            // AuditLogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 676);
            this.Controls.Add(this.uiSearchSelectionComboBox);
            this.Controls.Add(this.uiSearchButton);
            this.Controls.Add(this.uiSearchTextBox);
            this.Controls.Add(this.uiAuditOptionsToolStrip);
            this.Controls.Add(this.uiAuditLogSplitContainer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
        private System.Windows.Forms.ToolStripButton uiExportReportToolStripButton;
        private System.Windows.Forms.ComboBox uiSearchSelectionComboBox;
        private System.Windows.Forms.Button uiSearchButton;
        private System.Windows.Forms.TextBox uiSearchTextBox;
        private System.Windows.Forms.ToolStripButton uiBackToAuditLogToolStripButton;
    }
}