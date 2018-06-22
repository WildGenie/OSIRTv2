namespace OSIRT.UI
{
    partial class VideoDownloader
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VideoDownloader));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.uiStatusLabel = new System.Windows.Forms.Label();
            this.uiDownloadProgressBar = new System.Windows.Forms.ProgressBar();
            this.uiDownloadButton = new System.Windows.Forms.Button();
            this.uiUrlTextBox = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.uiStatusLabel);
            this.groupBox1.Controls.Add(this.uiDownloadProgressBar);
            this.groupBox1.Controls.Add(this.uiDownloadButton);
            this.groupBox1.Controls.Add(this.uiUrlTextBox);
            this.groupBox1.Location = new System.Drawing.Point(146, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(556, 121);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Video Downloader";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Enter Video Address:";
            // 
            // uiStatusLabel
            // 
            this.uiStatusLabel.AutoSize = true;
            this.uiStatusLabel.Location = new System.Drawing.Point(17, 89);
            this.uiStatusLabel.Name = "uiStatusLabel";
            this.uiStatusLabel.Size = new System.Drawing.Size(126, 13);
            this.uiStatusLabel.TabIndex = 4;
            this.uiStatusLabel.Text = "Status:  Waiting for video";
            // 
            // uiDownloadProgressBar
            // 
            this.uiDownloadProgressBar.Location = new System.Drawing.Point(20, 63);
            this.uiDownloadProgressBar.Name = "uiDownloadProgressBar";
            this.uiDownloadProgressBar.Size = new System.Drawing.Size(448, 23);
            this.uiDownloadProgressBar.TabIndex = 3;
            // 
            // uiDownloadButton
            // 
            this.uiDownloadButton.Location = new System.Drawing.Point(474, 63);
            this.uiDownloadButton.Name = "uiDownloadButton";
            this.uiDownloadButton.Size = new System.Drawing.Size(75, 23);
            this.uiDownloadButton.TabIndex = 2;
            this.uiDownloadButton.Text = "Download";
            this.uiDownloadButton.UseVisualStyleBackColor = true;
            this.uiDownloadButton.Click += new System.EventHandler(this.UiDownloadButton_Click);
            // 
            // uiUrlTextBox
            // 
            this.uiUrlTextBox.Location = new System.Drawing.Point(20, 37);
            this.uiUrlTextBox.Name = "uiUrlTextBox";
            this.uiUrlTextBox.Size = new System.Drawing.Size(529, 20);
            this.uiUrlTextBox.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::OSIRT.Properties.Resources.download_vid;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 121);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(531, 136);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(171, 13);
            this.linkLabel1.TabIndex = 2;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Help with downloader (opens PDF)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(458, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Video downloader can download from: YouTube, Facebook, Instagram, Twitter and Dai" +
    "lyMotion";
            // 
            // VideoDownloader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(713, 159);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VideoDownloader";
            this.Text = "Video Downloader";
            this.Load += new System.EventHandler(this.VideoDownloader_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button uiDownloadButton;
        private System.Windows.Forms.TextBox uiUrlTextBox;
        private System.Windows.Forms.Label uiStatusLabel;
        private System.Windows.Forms.ProgressBar uiDownloadProgressBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label2;
    }
}