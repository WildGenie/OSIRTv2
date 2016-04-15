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
            this.uiAttachButton = new System.Windows.Forms.Button();
            this.uiCancelButton = new System.Windows.Forms.Button();
            this.uiFileDetailsGroupBox = new System.Windows.Forms.GroupBox();
            this.uiAttachFileProgressPanel = new System.Windows.Forms.Panel();
            this.uiAddANotherFileLable = new System.Windows.Forms.Label();
            this.uiFileCopyDetailLabel = new System.Windows.Forms.Label();
            this.uiFileCopyingProgressBar = new System.Windows.Forms.ProgressBar();
            this.uiFileDetailsLabel = new System.Windows.Forms.Label();
            this.uiFileIconPictureBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.uiNoteSpellBox = new OSIRT.UI.SpellBox();
            this.hostedComponent6 = new System.Windows.Controls.TextBox();
            this.uiFileDetailsGroupBox.SuspendLayout();
            this.uiAttachFileProgressPanel.SuspendLayout();
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
            // uiAttachButton
            // 
            this.uiAttachButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiAttachButton.Location = new System.Drawing.Point(299, 345);
            this.uiAttachButton.Name = "uiAttachButton";
            this.uiAttachButton.Size = new System.Drawing.Size(75, 23);
            this.uiAttachButton.TabIndex = 3;
            this.uiAttachButton.Text = "Attach File";
            this.uiAttachButton.UseVisualStyleBackColor = true;
            this.uiAttachButton.Click += new System.EventHandler(this.uiAttachButton_Click);
            // 
            // uiCancelButton
            // 
            this.uiCancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiCancelButton.Location = new System.Drawing.Point(219, 345);
            this.uiCancelButton.Name = "uiCancelButton";
            this.uiCancelButton.Size = new System.Drawing.Size(75, 23);
            this.uiCancelButton.TabIndex = 4;
            this.uiCancelButton.Text = "Close";
            this.uiCancelButton.UseVisualStyleBackColor = true;
            this.uiCancelButton.Click += new System.EventHandler(this.uiCancelButton_Click);
            // 
            // uiFileDetailsGroupBox
            // 
            this.uiFileDetailsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiFileDetailsGroupBox.Controls.Add(this.uiAttachFileProgressPanel);
            this.uiFileDetailsGroupBox.Controls.Add(this.uiFileDetailsLabel);
            this.uiFileDetailsGroupBox.Controls.Add(this.uiFileIconPictureBox);
            this.uiFileDetailsGroupBox.Location = new System.Drawing.Point(21, 39);
            this.uiFileDetailsGroupBox.Name = "uiFileDetailsGroupBox";
            this.uiFileDetailsGroupBox.Size = new System.Drawing.Size(353, 115);
            this.uiFileDetailsGroupBox.TabIndex = 5;
            this.uiFileDetailsGroupBox.TabStop = false;
            this.uiFileDetailsGroupBox.Text = "File Details";
            // 
            // uiAttachFileProgressPanel
            // 
            this.uiAttachFileProgressPanel.Controls.Add(this.uiAddANotherFileLable);
            this.uiAttachFileProgressPanel.Controls.Add(this.uiFileCopyDetailLabel);
            this.uiAttachFileProgressPanel.Controls.Add(this.uiFileCopyingProgressBar);
            this.uiAttachFileProgressPanel.Location = new System.Drawing.Point(80, 19);
            this.uiAttachFileProgressPanel.Name = "uiAttachFileProgressPanel";
            this.uiAttachFileProgressPanel.Size = new System.Drawing.Size(272, 64);
            this.uiAttachFileProgressPanel.TabIndex = 6;
            // 
            // uiAddANotherFileLable
            // 
            this.uiAddANotherFileLable.AutoSize = true;
            this.uiAddANotherFileLable.Location = new System.Drawing.Point(3, 39);
            this.uiAddANotherFileLable.Name = "uiAddANotherFileLable";
            this.uiAddANotherFileLable.Size = new System.Drawing.Size(35, 13);
            this.uiAddANotherFileLable.TabIndex = 6;
            this.uiAddANotherFileLable.Text = "label2";
            // 
            // uiFileCopyDetailLabel
            // 
            this.uiFileCopyDetailLabel.AutoSize = true;
            this.uiFileCopyDetailLabel.Location = new System.Drawing.Point(3, 4);
            this.uiFileCopyDetailLabel.Name = "uiFileCopyDetailLabel";
            this.uiFileCopyDetailLabel.Size = new System.Drawing.Size(80, 13);
            this.uiFileCopyDetailLabel.TabIndex = 5;
            this.uiFileCopyDetailLabel.Text = "Attaching File...";
            // 
            // uiFileCopyingProgressBar
            // 
            this.uiFileCopyingProgressBar.Location = new System.Drawing.Point(3, 21);
            this.uiFileCopyingProgressBar.Name = "uiFileCopyingProgressBar";
            this.uiFileCopyingProgressBar.Size = new System.Drawing.Size(267, 15);
            this.uiFileCopyingProgressBar.TabIndex = 4;
            // 
            // uiFileDetailsLabel
            // 
            this.uiFileDetailsLabel.AutoSize = true;
            this.uiFileDetailsLabel.Location = new System.Drawing.Point(77, 19);
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
            this.label1.Location = new System.Drawing.Point(18, 157);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Note (Required)";
            // 
            // uiNoteSpellBox
            // 
            this.uiNoteSpellBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiNoteSpellBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiNoteSpellBox.Location = new System.Drawing.Point(21, 173);
            this.uiNoteSpellBox.Multiline = true;
            this.uiNoteSpellBox.Name = "uiNoteSpellBox";
            this.uiNoteSpellBox.Size = new System.Drawing.Size(354, 166);
            this.uiNoteSpellBox.TabIndex = 2;
            // 
            // AttachmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 376);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.uiNoteSpellBox);
            this.Controls.Add(this.uiCancelButton);
            this.Controls.Add(this.uiAttachButton);
            this.Controls.Add(this.uiBrowseButton);
            this.Controls.Add(this.uiFilePathTextBox);
            this.Controls.Add(this.uiFileDetailsGroupBox);
            this.MinimumSize = new System.Drawing.Size(406, 395);
            this.Name = "AttachmentForm";
            this.Text = "Attach File to Case";
            this.Load += new System.EventHandler(this.AttachmentForm_Load);
            this.uiFileDetailsGroupBox.ResumeLayout(false);
            this.uiFileDetailsGroupBox.PerformLayout();
            this.uiAttachFileProgressPanel.ResumeLayout(false);
            this.uiAttachFileProgressPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiFileIconPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox uiFilePathTextBox;
        private System.Windows.Forms.Button uiBrowseButton;
        private SpellBox uiNoteSpellBox;
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
        private System.Windows.Controls.TextBox hostedComponent3;
        private System.Windows.Forms.Panel uiAttachFileProgressPanel;
        private System.Windows.Controls.TextBox hostedComponent4;
        private System.Windows.Forms.Label uiAddANotherFileLable;
        private System.Windows.Controls.TextBox hostedComponent5;
        private System.Windows.Controls.TextBox hostedComponent6;
    }
}