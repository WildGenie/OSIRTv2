namespace OSIRT.UI
{
    partial class ExifViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExifViewer));
            this.uiExifDatGridView = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uiThumbnailPictureBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.uiSaveAsTextButton = new System.Windows.Forms.Button();
            this.uiGoogleMapsButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.uiExifDatGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiThumbnailPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // uiExifDatGridView
            // 
            this.uiExifDatGridView.AllowUserToDeleteRows = false;
            this.uiExifDatGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiExifDatGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.uiExifDatGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.uiExifDatGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.uiExifDatGridView.Location = new System.Drawing.Point(1, 1);
            this.uiExifDatGridView.Name = "uiExifDatGridView";
            this.uiExifDatGridView.ReadOnly = true;
            this.uiExifDatGridView.Size = new System.Drawing.Size(432, 477);
            this.uiExifDatGridView.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Property";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 71;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Value";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 59;
            // 
            // uiThumbnailPictureBox
            // 
            this.uiThumbnailPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.uiThumbnailPictureBox.Location = new System.Drawing.Point(1, 496);
            this.uiThumbnailPictureBox.Name = "uiThumbnailPictureBox";
            this.uiThumbnailPictureBox.Size = new System.Drawing.Size(109, 91);
            this.uiThumbnailPictureBox.TabIndex = 1;
            this.uiThumbnailPictureBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-1, 481);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Thumbnail";
            // 
            // uiSaveAsTextButton
            // 
            this.uiSaveAsTextButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiSaveAsTextButton.Location = new System.Drawing.Point(353, 481);
            this.uiSaveAsTextButton.Name = "uiSaveAsTextButton";
            this.uiSaveAsTextButton.Size = new System.Drawing.Size(80, 23);
            this.uiSaveAsTextButton.TabIndex = 3;
            this.uiSaveAsTextButton.Text = "Log exif data";
            this.uiSaveAsTextButton.UseVisualStyleBackColor = true;
            this.uiSaveAsTextButton.Click += new System.EventHandler(this.uiSaveAsTextButton_Click);
            // 
            // uiGoogleMapsButton
            // 
            this.uiGoogleMapsButton.Location = new System.Drawing.Point(306, 564);
            this.uiGoogleMapsButton.Name = "uiGoogleMapsButton";
            this.uiGoogleMapsButton.Size = new System.Drawing.Size(127, 23);
            this.uiGoogleMapsButton.TabIndex = 4;
            this.uiGoogleMapsButton.Text = "View on Google Maps";
            this.uiGoogleMapsButton.UseVisualStyleBackColor = true;
            this.uiGoogleMapsButton.Visible = false;
            this.uiGoogleMapsButton.Click += new System.EventHandler(this.uiGoogleMapsButton_Click);
            // 
            // ExifViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 589);
            this.Controls.Add(this.uiGoogleMapsButton);
            this.Controls.Add(this.uiSaveAsTextButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.uiThumbnailPictureBox);
            this.Controls.Add(this.uiExifDatGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(450, 627);
            this.Name = "ExifViewer";
            this.Text = "Exif Viewer";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uiExifDatGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiThumbnailPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView uiExifDatGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.PictureBox uiThumbnailPictureBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button uiSaveAsTextButton;
        private System.Windows.Forms.Button uiGoogleMapsButton;
    }
}

