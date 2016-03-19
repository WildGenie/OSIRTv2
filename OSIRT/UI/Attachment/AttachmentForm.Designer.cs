namespace OSIRT.UI.Attachment
{
    partial class AttachmentForm
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
            this.uiFilePathTextBox = new System.Windows.Forms.TextBox();
            this.uiBrowseButton = new System.Windows.Forms.Button();
            this.spellBox1 = new OSIRT.UI.SpellBox();
            this.hostedComponent2 = new System.Windows.Controls.TextBox();
            this.uiAttachButton = new System.Windows.Forms.Button();
            this.uiCancelButton = new System.Windows.Forms.Button();
            this.uiFileDetailsGroupBox = new System.Windows.Forms.GroupBox();
            this.uiFileDetailsLabel = new System.Windows.Forms.Label();
            this.uiFileIconPictureBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.uiFileCopyingProgressBar = new System.Windows.Forms.ProgressBar();
            this.uiFileCopyDetailLabel = new System.Windows.Forms.Label();
            this.uiFileDetailsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiFileIconPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // uiFilePathTextBox
            // 
            this.uiFilePathTextBox.Location = new System.Drawing.Point(21, 12);
            this.uiFilePathTextBox.Name = "uiFilePathTextBox";
            this.uiFilePathTextBox.ReadOnly = true;
            this.uiFilePathTextBox.Size = new System.Drawing.Size(272, 20);
            this.uiFilePathTextBox.TabIndex = 0;
            // 
            // uiBrowseButton
            // 
            this.uiBrowseButton.Location = new System.Drawing.Point(299, 10);
            this.uiBrowseButton.Name = "uiBrowseButton";
            this.uiBrowseButton.Size = new System.Drawing.Size(75, 23);
            this.uiBrowseButton.TabIndex = 1;
            this.uiBrowseButton.Text = "Browse...";
            this.uiBrowseButton.UseVisualStyleBackColor = true;
            this.uiBrowseButton.Click += new System.EventHandler(this.uiBrowseButton_Click);
            // 
            // spellBox1
            // 
            this.spellBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.spellBox1.Location = new System.Drawing.Point(21, 154);
            this.spellBox1.Name = "spellBox1";
            this.spellBox1.Size = new System.Drawing.Size(354, 166);
            this.spellBox1.TabIndex = 2;
            // 
            // uiAttachButton
            // 
            this.uiAttachButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiAttachButton.Location = new System.Drawing.Point(299, 326);
            this.uiAttachButton.Name = "uiAttachButton";
            this.uiAttachButton.Size = new System.Drawing.Size(75, 23);
            this.uiAttachButton.TabIndex = 3;
            this.uiAttachButton.Text = "Attach File";
            this.uiAttachButton.UseVisualStyleBackColor = true;
            // 
            // uiCancelButton
            // 
            this.uiCancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiCancelButton.Location = new System.Drawing.Point(219, 326);
            this.uiCancelButton.Name = "uiCancelButton";
            this.uiCancelButton.Size = new System.Drawing.Size(75, 23);
            this.uiCancelButton.TabIndex = 4;
            this.uiCancelButton.Text = "Cancel";
            this.uiCancelButton.UseVisualStyleBackColor = true;
            // 
            // uiFileDetailsGroupBox
            // 
            this.uiFileDetailsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiFileDetailsGroupBox.Controls.Add(this.uiFileDetailsLabel);
            this.uiFileDetailsGroupBox.Controls.Add(this.uiFileIconPictureBox);
            this.uiFileDetailsGroupBox.Location = new System.Drawing.Point(21, 39);
            this.uiFileDetailsGroupBox.Name = "uiFileDetailsGroupBox";
            this.uiFileDetailsGroupBox.Size = new System.Drawing.Size(353, 96);
            this.uiFileDetailsGroupBox.TabIndex = 5;
            this.uiFileDetailsGroupBox.TabStop = false;
            this.uiFileDetailsGroupBox.Text = "File Details";
            // 
            // uiFileDetailsLabel
            // 
            this.uiFileDetailsLabel.AutoSize = true;
            this.uiFileDetailsLabel.Location = new System.Drawing.Point(81, 20);
            this.uiFileDetailsLabel.Name = "uiFileDetailsLabel";
            this.uiFileDetailsLabel.Size = new System.Drawing.Size(35, 13);
            this.uiFileDetailsLabel.TabIndex = 1;
            this.uiFileDetailsLabel.Text = "label2";
            // 
            // uiFileIconPictureBox
            // 
            this.uiFileIconPictureBox.Location = new System.Drawing.Point(10, 19);
            this.uiFileIconPictureBox.Name = "uiFileIconPictureBox";
            this.uiFileIconPictureBox.Size = new System.Drawing.Size(64, 64);
            this.uiFileIconPictureBox.TabIndex = 0;
            this.uiFileIconPictureBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Note (Required)";
            // 
            // uiFileCopyingProgressBar
            // 
            this.uiFileCopyingProgressBar.Location = new System.Drawing.Point(26, 372);
            this.uiFileCopyingProgressBar.Name = "uiFileCopyingProgressBar";
            this.uiFileCopyingProgressBar.Size = new System.Drawing.Size(267, 23);
            this.uiFileCopyingProgressBar.TabIndex = 4;
            // 
            // uiFileCopyDetailLabel
            // 
            this.uiFileCopyDetailLabel.AutoSize = true;
            this.uiFileCopyDetailLabel.Location = new System.Drawing.Point(28, 356);
            this.uiFileCopyDetailLabel.Name = "uiFileCopyDetailLabel";
            this.uiFileCopyDetailLabel.Size = new System.Drawing.Size(83, 13);
            this.uiFileCopyDetailLabel.TabIndex = 5;
            this.uiFileCopyDetailLabel.Text = "Uploading File...";
            // 
            // AttachmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 410);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.uiFileCopyingProgressBar);
            this.Controls.Add(this.uiFileCopyDetailLabel);
            this.Controls.Add(this.spellBox1);
            this.Controls.Add(this.uiCancelButton);
            this.Controls.Add(this.uiAttachButton);
            this.Controls.Add(this.uiBrowseButton);
            this.Controls.Add(this.uiFilePathTextBox);
            this.Controls.Add(this.uiFileDetailsGroupBox);
            this.Name = "AttachmentForm";
            this.Text = "Attach File to Case";
            this.Load += new System.EventHandler(this.AttachmentForm_Load);
            this.uiFileDetailsGroupBox.ResumeLayout(false);
            this.uiFileDetailsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiFileIconPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox uiFilePathTextBox;
        private System.Windows.Forms.Button uiBrowseButton;
        private SpellBox spellBox1;
        private System.Windows.Controls.TextBox hostedComponent1;
        private System.Windows.Forms.Button uiAttachButton;
        private System.Windows.Forms.Button uiCancelButton;
        private System.Windows.Forms.GroupBox uiFileDetailsGroupBox;
        private System.Windows.Forms.Label uiFileDetailsLabel;
        private System.Windows.Forms.PictureBox uiFileIconPictureBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar uiFileCopyingProgressBar;
        private System.Windows.Forms.Label uiFileCopyDetailLabel;
        private System.Windows.Controls.TextBox hostedComponent2;
    }
}