namespace OSIRT.UI.VideoParser
{
    partial class VideoParseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VideoParseForm));
            this.uiUrlTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.uiDownloadButton = new System.Windows.Forms.Button();
            this.uiDownloadProgressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // uiUrlTextBox
            // 
            this.uiUrlTextBox.Location = new System.Drawing.Point(15, 22);
            this.uiUrlTextBox.Name = "uiUrlTextBox";
            this.uiUrlTextBox.Size = new System.Drawing.Size(590, 20);
            this.uiUrlTextBox.TabIndex = 0;
            this.uiUrlTextBox.TextChanged += new System.EventHandler(this.uiUrlTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enter the video URL:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(596, 26);
            this.label2.TabIndex = 2;
            this.label2.Text = "To get the Facebook video URL, right click on the video and select \"Show video UR" +
    "L\". Copy and paste the video URL that \r\npops-up into the box above.";
            // 
            // uiDownloadButton
            // 
            this.uiDownloadButton.Enabled = false;
            this.uiDownloadButton.Location = new System.Drawing.Point(530, 74);
            this.uiDownloadButton.Name = "uiDownloadButton";
            this.uiDownloadButton.Size = new System.Drawing.Size(75, 23);
            this.uiDownloadButton.TabIndex = 3;
            this.uiDownloadButton.Text = "Download";
            this.uiDownloadButton.UseVisualStyleBackColor = true;
            this.uiDownloadButton.Click += new System.EventHandler(this.uiDownloadButton_Click);
            // 
            // uiDownloadProgressBar
            // 
            this.uiDownloadProgressBar.Location = new System.Drawing.Point(15, 74);
            this.uiDownloadProgressBar.Name = "uiDownloadProgressBar";
            this.uiDownloadProgressBar.Size = new System.Drawing.Size(509, 23);
            this.uiDownloadProgressBar.TabIndex = 4;
            // 
            // VideoParseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 106);
            this.Controls.Add(this.uiDownloadProgressBar);
            this.Controls.Add(this.uiDownloadButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.uiUrlTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VideoParseForm";
            this.Text = "Video Helper";
            this.Load += new System.EventHandler(this.VideoParseForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox uiUrlTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button uiDownloadButton;
        private System.Windows.Forms.ProgressBar uiDownloadProgressBar;
    }
}