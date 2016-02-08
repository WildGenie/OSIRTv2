namespace OSIRT.UI
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
            ((System.ComponentModel.ISupportInitialize)(this.uiAuditLogSplitContainer)).BeginInit();
            this.uiAuditLogSplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiAuditLogSplitContainer
            // 
            this.uiAuditLogSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiAuditLogSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.uiAuditLogSplitContainer.Name = "uiAuditLogSplitContainer";
            this.uiAuditLogSplitContainer.Size = new System.Drawing.Size(1006, 572);
            this.uiAuditLogSplitContainer.SplitterDistance = 398;
            this.uiAuditLogSplitContainer.TabIndex = 0;
            // 
            // AuditLogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 572);
            this.Controls.Add(this.uiAuditLogSplitContainer);
            this.Name = "AuditLogForm";
            this.Text = "Audit Log";
            this.Load += new System.EventHandler(this.uiAuditLogForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uiAuditLogSplitContainer)).EndInit();
            this.uiAuditLogSplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer uiAuditLogSplitContainer;
    }
}