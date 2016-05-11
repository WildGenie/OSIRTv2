namespace OSIRT.UI.DownloadClient
{
    partial class DownloadForm
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
            this.uiDownloadProgressBar = new System.Windows.Forms.ProgressBar();
            this.uiFileLabel = new System.Windows.Forms.Label();
            this.uiCompleteLabel = new System.Windows.Forms.Label();
            this.uiCloseButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // uiDownloadProgressBar
            // 
            this.uiDownloadProgressBar.Location = new System.Drawing.Point(12, 30);
            this.uiDownloadProgressBar.Name = "uiDownloadProgressBar";
            this.uiDownloadProgressBar.Size = new System.Drawing.Size(520, 23);
            this.uiDownloadProgressBar.TabIndex = 0;
            // 
            // uiFileLabel
            // 
            this.uiFileLabel.AutoSize = true;
            this.uiFileLabel.Location = new System.Drawing.Point(13, 13);
            this.uiFileLabel.Name = "uiFileLabel";
            this.uiFileLabel.Size = new System.Drawing.Size(35, 13);
            this.uiFileLabel.TabIndex = 1;
            this.uiFileLabel.Text = "label1";
            // 
            // uiCompleteLabel
            // 
            this.uiCompleteLabel.AutoSize = true;
            this.uiCompleteLabel.Location = new System.Drawing.Point(246, 56);
            this.uiCompleteLabel.Name = "uiCompleteLabel";
            this.uiCompleteLabel.Size = new System.Drawing.Size(35, 13);
            this.uiCompleteLabel.TabIndex = 2;
            this.uiCompleteLabel.Text = "label1";
            // 
            // uiCloseButton
            // 
            this.uiCloseButton.Location = new System.Drawing.Point(457, 124);
            this.uiCloseButton.Name = "uiCloseButton";
            this.uiCloseButton.Size = new System.Drawing.Size(75, 23);
            this.uiCloseButton.TabIndex = 3;
            this.uiCloseButton.Text = "Close";
            this.uiCloseButton.UseVisualStyleBackColor = true;
            // 
            // DownloadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 159);
            this.Controls.Add(this.uiCloseButton);
            this.Controls.Add(this.uiCompleteLabel);
            this.Controls.Add(this.uiFileLabel);
            this.Controls.Add(this.uiDownloadProgressBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "DownloadForm";
            this.Text = "Download Form";
            this.Load += new System.EventHandler(this.DownloadForm_Load);
            this.Shown += new System.EventHandler(this.DownloadForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar uiDownloadProgressBar;
        private System.Windows.Forms.Label uiFileLabel;
        private System.Windows.Forms.Label uiCompleteLabel;
        private System.Windows.Forms.Button uiCloseButton;
    }
}