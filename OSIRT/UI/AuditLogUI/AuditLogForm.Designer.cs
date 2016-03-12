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
            this.uiDateAndTimetextBox = new System.Windows.Forms.TextBox();
            this.uiActionTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.uiAuditLogSplitContainer)).BeginInit();
            this.uiAuditLogSplitContainer.Panel1.SuspendLayout();
            this.uiAuditLogSplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiAuditLogSplitContainer
            // 
            this.uiAuditLogSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiAuditLogSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.uiAuditLogSplitContainer.Name = "uiAuditLogSplitContainer";
            // 
            // uiAuditLogSplitContainer.Panel1
            // 
            this.uiAuditLogSplitContainer.Panel1.Controls.Add(this.label2);
            this.uiAuditLogSplitContainer.Panel1.Controls.Add(this.label1);
            this.uiAuditLogSplitContainer.Panel1.Controls.Add(this.uiActionTextBox);
            this.uiAuditLogSplitContainer.Panel1.Controls.Add(this.uiDateAndTimetextBox);
            this.uiAuditLogSplitContainer.Size = new System.Drawing.Size(1045, 604);
            this.uiAuditLogSplitContainer.SplitterDistance = 283;
            this.uiAuditLogSplitContainer.TabIndex = 0;
            // 
            // uiDateAndTimetextBox
            // 
            this.uiDateAndTimetextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiDateAndTimetextBox.Location = new System.Drawing.Point(12, 30);
            this.uiDateAndTimetextBox.Name = "uiDateAndTimetextBox";
            this.uiDateAndTimetextBox.Size = new System.Drawing.Size(257, 20);
            this.uiDateAndTimetextBox.TabIndex = 0;
            // 
            // uiActionTextBox
            // 
            this.uiActionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiActionTextBox.Location = new System.Drawing.Point(12, 80);
            this.uiActionTextBox.Name = "uiActionTextBox";
            this.uiActionTextBox.Size = new System.Drawing.Size(257, 20);
            this.uiActionTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Date and Time";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Action";
            // 
            // AuditLogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 604);
            this.Controls.Add(this.uiAuditLogSplitContainer);
            this.Name = "AuditLogForm";
            this.Text = "Audit Log";
            this.Load += new System.EventHandler(this.uiAuditLogForm_Load);
            this.uiAuditLogSplitContainer.Panel1.ResumeLayout(false);
            this.uiAuditLogSplitContainer.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiAuditLogSplitContainer)).EndInit();
            this.uiAuditLogSplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer uiAuditLogSplitContainer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox uiActionTextBox;
        private System.Windows.Forms.TextBox uiDateAndTimetextBox;
    }
}