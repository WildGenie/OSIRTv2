namespace OSIRT.UI
{
    partial class ImagePreviewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImagePreviewer));
            this.hostedComponent11 = new System.Windows.Controls.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.uiURLTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.uiPreviewerSplitContainer)).BeginInit();
            this.uiPreviewerSplitContainer.Panel1.SuspendLayout();
            this.uiPreviewerSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiNotePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiDoesFileExistPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // uiPreviewerSplitContainer
            // 
            // 
            // uiPreviewerSplitContainer.Panel1
            // 
            this.uiPreviewerSplitContainer.Panel1.Controls.Add(this.uiURLTextBox);
            this.uiPreviewerSplitContainer.Panel1.Controls.Add(this.label3);
            this.uiPreviewerSplitContainer.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.uiPreviewerSplitContainer_Panel1_Paint);
            this.uiPreviewerSplitContainer.Size = new System.Drawing.Size(1058, 553);
            this.uiPreviewerSplitContainer.SplitterDistance = 372;
            // 
            // uiNotePictureBox
            // 
            this.uiNotePictureBox.Image = ((System.Drawing.Image)(resources.GetObject("uiNotePictureBox.Image")));
            this.uiNotePictureBox.Location = new System.Drawing.Point(346, 413);
            // 
            // uiFileExtensionComboBox
            // 
            this.uiFileExtensionComboBox.Items.AddRange(new object[] {
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            ""});
            this.uiFileExtensionComboBox.Location = new System.Drawing.Point(276, 25);
            // 
            // uiDoesFileExistPictureBox
            // 
            this.uiDoesFileExistPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("uiDoesFileExistPictureBox.Image")));
            this.uiDoesFileExistPictureBox.Location = new System.Drawing.Point(346, 30);
            // 
            // uiCalculatingHashLabel
            // 
            this.uiCalculatingHashLabel.Location = new System.Drawing.Point(12, 110);
            // 
            // uiHashCalcProgressBar
            // 
            this.uiHashCalcProgressBar.Location = new System.Drawing.Point(15, 126);
            this.uiHashCalcProgressBar.Size = new System.Drawing.Size(330, 20);
            // 
            // uiHashTextBox
            // 
            this.uiHashTextBox.Location = new System.Drawing.Point(15, 126);
            this.uiHashTextBox.Size = new System.Drawing.Size(325, 20);
            // 
            // uiCancelButton
            // 
            this.uiCancelButton.Location = new System.Drawing.Point(176, 435);
            this.uiCancelButton.Click += new System.EventHandler(this.uiCancelButton_Click);
            // 
            // uiOKButton
            // 
            this.uiOKButton.Location = new System.Drawing.Point(261, 435);
            this.uiOKButton.Click += new System.EventHandler(this.uiOKButton_Click);
            // 
            // uiNoteSpellBox
            // 
            this.uiNoteSpellBox.Location = new System.Drawing.Point(13, 242);
            this.uiNoteSpellBox.Size = new System.Drawing.Size(327, 187);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(12, 225);
            // 
            // uiDateAndTimeTextBox
            // 
            this.uiDateAndTimeTextBox.Size = new System.Drawing.Size(325, 20);
            // 
            // uiFileNameComboBox
            // 
            this.uiFileNameComboBox.Size = new System.Drawing.Size(255, 21);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(12, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 36;
            this.label3.Text = "URL";
            // 
            // uiURLTextBox
            // 
            this.uiURLTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiURLTextBox.Location = new System.Drawing.Point(15, 180);
            this.uiURLTextBox.Name = "uiURLTextBox";
            this.uiURLTextBox.ReadOnly = true;
            this.uiURLTextBox.Size = new System.Drawing.Size(330, 20);
            this.uiURLTextBox.TabIndex = 37;
            // 
            // ImagePreviewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1058, 553);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ImagePreviewer";
            this.Text = "Image Previewer";
            this.Load += new System.EventHandler(this.ImagePrevEx_Load);
            this.uiPreviewerSplitContainer.Panel1.ResumeLayout(false);
            this.uiPreviewerSplitContainer.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiPreviewerSplitContainer)).EndInit();
            this.uiPreviewerSplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiNotePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiDoesFileExistPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox uiURLTextBox;
        private System.Windows.Forms.Label label3;
        protected System.Windows.Controls.TextBox hostedComponent1;
        protected System.Windows.Controls.TextBox hostedComponent2;
        protected System.Windows.Controls.TextBox hostedComponent3;
        protected System.Windows.Controls.TextBox hostedComponent4;
        protected System.Windows.Controls.TextBox hostedComponent5;
        protected System.Windows.Controls.TextBox hostedComponent6;
        protected System.Windows.Controls.TextBox hostedComponent7;
        protected System.Windows.Controls.TextBox hostedComponent8;
        protected System.Windows.Controls.TextBox hostedComponent9;
        protected System.Windows.Controls.TextBox hostedComponent10;
        protected System.Windows.Controls.TextBox hostedComponent11;
    }
}