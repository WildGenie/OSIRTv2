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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DownloadForm));
            this.uiDownloadProgressBar = new System.Windows.Forms.ProgressBar();
            this.uiFileLabel = new System.Windows.Forms.Label();
            this.uiCompleteLabel = new System.Windows.Forms.Label();
            this.uiCloseButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // uiDownloadProgressBar
            // 
            this.uiDownloadProgressBar.Location = new System.Drawing.Point(151, 29);
            this.uiDownloadProgressBar.Name = "uiDownloadProgressBar";
            this.uiDownloadProgressBar.Size = new System.Drawing.Size(520, 23);
            this.uiDownloadProgressBar.TabIndex = 0;
            // 
            // uiFileLabel
            // 
            this.uiFileLabel.AutoSize = true;
            this.uiFileLabel.Location = new System.Drawing.Point(152, 12);
            this.uiFileLabel.Name = "uiFileLabel";
            this.uiFileLabel.Size = new System.Drawing.Size(35, 13);
            this.uiFileLabel.TabIndex = 1;
            this.uiFileLabel.Text = "label1";
            // 
            // uiCompleteLabel
            // 
            this.uiCompleteLabel.AutoSize = true;
            this.uiCompleteLabel.Location = new System.Drawing.Point(385, 55);
            this.uiCompleteLabel.Name = "uiCompleteLabel";
            this.uiCompleteLabel.Size = new System.Drawing.Size(35, 13);
            this.uiCompleteLabel.TabIndex = 2;
            this.uiCompleteLabel.Text = "label1";
            this.uiCompleteLabel.SizeChanged += new System.EventHandler(this.uiCompleteLabel_SizeChanged);
            // 
            // uiCloseButton
            // 
            this.uiCloseButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.uiCloseButton.Enabled = false;
            this.uiCloseButton.Location = new System.Drawing.Point(596, 120);
            this.uiCloseButton.Name = "uiCloseButton";
            this.uiCloseButton.Size = new System.Drawing.Size(75, 23);
            this.uiCloseButton.TabIndex = 3;
            this.uiCloseButton.Text = "Close";
            this.uiCloseButton.UseVisualStyleBackColor = true;
            this.uiCloseButton.Click += new System.EventHandler(this.uiCloseButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Image = global::OSIRT.Properties.Resources.computing_cloud;
            this.pictureBox1.Location = new System.Drawing.Point(13, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(133, 131);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // DownloadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 151);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.uiCloseButton);
            this.Controls.Add(this.uiCompleteLabel);
            this.Controls.Add(this.uiFileLabel);
            this.Controls.Add(this.uiDownloadProgressBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DownloadForm";
            this.Text = "Download";
            this.Load += new System.EventHandler(this.DownloadForm_Load);
            this.Shown += new System.EventHandler(this.DownloadForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar uiDownloadProgressBar;
        private System.Windows.Forms.Label uiFileLabel;
        private System.Windows.Forms.Label uiCompleteLabel;
        private System.Windows.Forms.Button uiCloseButton;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}