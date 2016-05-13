namespace OSIRT
{
    partial class VideoPreviewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VideoPreviewer));
            this.hostedComponent2 = new System.Windows.Controls.TextBox();
            this.uiVideoMediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.uiPreviewerSplitContainer)).BeginInit();
            this.uiPreviewerSplitContainer.Panel1.SuspendLayout();
            this.uiPreviewerSplitContainer.Panel2.SuspendLayout();
            this.uiPreviewerSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiNotePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiDoesFileExistPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiVideoMediaPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // uiPreviewerSplitContainer
            // 
            // 
            // uiPreviewerSplitContainer.Panel2
            // 
            this.uiPreviewerSplitContainer.Panel2.Controls.Add(this.uiVideoMediaPlayer);
            this.uiPreviewerSplitContainer.Size = new System.Drawing.Size(1076, 535);
            this.uiPreviewerSplitContainer.SplitterDistance = 366;
            // 
            // uiNotePictureBox
            // 
            this.uiNotePictureBox.Image = ((System.Drawing.Image)(resources.GetObject("uiNotePictureBox.Image")));
            this.uiNotePictureBox.Location = new System.Drawing.Point(348, 354);
            // 
            // uiFileExtensionComboBox
            // 
            this.uiFileExtensionComboBox.Items.AddRange(new object[] {
            "",
            ""});
            this.uiFileExtensionComboBox.Location = new System.Drawing.Point(277, 25);
            // 
            // uiDoesFileExistPictureBox
            // 
            this.uiDoesFileExistPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("uiDoesFileExistPictureBox.Image")));
            this.uiDoesFileExistPictureBox.Location = new System.Drawing.Point(348, 30);
            // 
            // uiHashTextBox
            // 
            this.uiHashTextBox.Size = new System.Drawing.Size(327, 20);
            // 
            // uiCancelButton
            // 
            this.uiCancelButton.Location = new System.Drawing.Point(177, 376);
            // 
            // uiOKButton
            // 
            this.uiOKButton.Location = new System.Drawing.Point(262, 376);
            this.uiOKButton.Click += new System.EventHandler(this.uiOKButton_Click);
            // 
            // uiNoteSpellBox
            // 
            this.uiNoteSpellBox.Location = new System.Drawing.Point(13, 183);
            this.uiNoteSpellBox.Size = new System.Drawing.Size(329, 187);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(12, 166);
            // 
            // uiDateAndTimeTextBox
            // 
            this.uiDateAndTimeTextBox.Size = new System.Drawing.Size(327, 20);
            // 
            // uiFileNameComboBox
            // 
            this.uiFileNameComboBox.Size = new System.Drawing.Size(256, 21);
            // 
            // uiVideoMediaPlayer
            // 
            this.uiVideoMediaPlayer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.uiVideoMediaPlayer.Enabled = true;
            this.uiVideoMediaPlayer.Location = new System.Drawing.Point(3, 62);
            this.uiVideoMediaPlayer.Name = "uiVideoMediaPlayer";
            this.uiVideoMediaPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("uiVideoMediaPlayer.OcxState")));
            this.uiVideoMediaPlayer.Size = new System.Drawing.Size(700, 411);
            this.uiVideoMediaPlayer.TabIndex = 1;
            // 
            // VideoPreviewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1076, 535);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VideoPreviewer";
            this.Text = "VideoPreviewer";
            this.Load += new System.EventHandler(this.VideoPreviewer_Load);
            this.uiPreviewerSplitContainer.Panel1.ResumeLayout(false);
            this.uiPreviewerSplitContainer.Panel1.PerformLayout();
            this.uiPreviewerSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiPreviewerSplitContainer)).EndInit();
            this.uiPreviewerSplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiNotePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiDoesFileExistPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiVideoMediaPlayer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Controls.TextBox hostedComponent1;
        private AxWMPLib.AxWindowsMediaPlayer uiVideoMediaPlayer;
        protected System.Windows.Controls.TextBox hostedComponent2;
    }
}