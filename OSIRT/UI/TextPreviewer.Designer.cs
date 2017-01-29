namespace OSIRT.UI
{
    partial class TextPreviewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TextPreviewer));
            this.hostedComponent3 = new System.Windows.Controls.TextBox();
            this.uiURLTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
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
            this.uiPreviewerSplitContainer.Size = new System.Drawing.Size(1007, 573);
            this.uiPreviewerSplitContainer.SplitterDistance = 364;
            // 
            // uiNotePictureBox
            // 
            this.uiNotePictureBox.Image = ((System.Drawing.Image)(resources.GetObject("uiNotePictureBox.Image")));
            this.uiNotePictureBox.Location = new System.Drawing.Point(298, 408);
            // 
            // uiFileExtensionComboBox
            // 
            this.uiFileExtensionComboBox.Items.AddRange(new object[] {
            "",
            "",
            ""});
            this.uiFileExtensionComboBox.Location = new System.Drawing.Point(227, 25);
            // 
            // uiDoesFileExistPictureBox
            // 
            this.uiDoesFileExistPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("uiDoesFileExistPictureBox.Image")));
            this.uiDoesFileExistPictureBox.Location = new System.Drawing.Point(298, 30);
            // 
            // uiHashCalcProgressBar
            // 
            this.uiHashCalcProgressBar.Size = new System.Drawing.Size(276, 20);
            // 
            // uiHashTextBox
            // 
            this.uiHashTextBox.Size = new System.Drawing.Size(277, 20);
            // 
            // uiCancelButton
            // 
            this.uiCancelButton.Location = new System.Drawing.Point(127, 430);
            // 
            // uiOKButton
            // 
            this.uiOKButton.Location = new System.Drawing.Point(212, 430);
            this.uiOKButton.Click += new System.EventHandler(this.uiOKButton_Click);
            // 
            // uiNoteSpellBox
            // 
            this.uiNoteSpellBox.Location = new System.Drawing.Point(13, 237);
            this.uiNoteSpellBox.Size = new System.Drawing.Size(279, 187);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(12, 220);
            // 
            // uiDateAndTimeTextBox
            // 
            this.uiDateAndTimeTextBox.Size = new System.Drawing.Size(277, 20);
            // 
            // uiFileNameComboBox
            // 
            this.uiFileNameComboBox.Size = new System.Drawing.Size(206, 21);
            // 
            // uiURLTextBox
            // 
            this.uiURLTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiURLTextBox.Location = new System.Drawing.Point(15, 180);
            this.uiURLTextBox.Name = "uiURLTextBox";
            this.uiURLTextBox.ReadOnly = true;
            this.uiURLTextBox.Size = new System.Drawing.Size(276, 20);
            this.uiURLTextBox.TabIndex = 39;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(12, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 38;
            this.label3.Text = "URL";
            // 
            // TextPreviewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1007, 573);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TextPreviewer";
            this.Text = "Text Previewer";
            this.Load += new System.EventHandler(this.TextPreviewer_Load);
            this.uiPreviewerSplitContainer.Panel1.ResumeLayout(false);
            this.uiPreviewerSplitContainer.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiPreviewerSplitContainer)).EndInit();
            this.uiPreviewerSplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiNotePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiDoesFileExistPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Controls.TextBox hostedComponent1;
        protected System.Windows.Controls.TextBox hostedComponent2;
        private System.Windows.Forms.TextBox uiURLTextBox;
        private System.Windows.Forms.Label label3;
        protected System.Windows.Controls.TextBox hostedComponent3;
    }
}