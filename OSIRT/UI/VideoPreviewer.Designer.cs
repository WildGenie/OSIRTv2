namespace OSIRT.UI
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.uiDoesFileExistPictureBox = new System.Windows.Forms.PictureBox();
            this.uiVideoNameComboBox = new System.Windows.Forms.ComboBox();
            this.uiNotePictureBox = new System.Windows.Forms.PictureBox();
            this.uiCancelButton = new System.Windows.Forms.Button();
            this.uiOKButton = new System.Windows.Forms.Button();
            this.uiNoteSpellBox = new OSIRT.UI.SpellBox();
            this.hostedComponent2 = new System.Windows.Controls.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.uiCalculatingHashLabel = new System.Windows.Forms.Label();
            this.uiHashCalcProgressBar = new System.Windows.Forms.ProgressBar();
            this.uiHashTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.uiDateAndTimeTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.uiVideoMediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiDoesFileExistPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiNotePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiVideoMediaPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.splitContainer1.Panel1.Controls.Add(this.uiDoesFileExistPictureBox);
            this.splitContainer1.Panel1.Controls.Add(this.uiVideoNameComboBox);
            this.splitContainer1.Panel1.Controls.Add(this.uiNotePictureBox);
            this.splitContainer1.Panel1.Controls.Add(this.uiCancelButton);
            this.splitContainer1.Panel1.Controls.Add(this.uiOKButton);
            this.splitContainer1.Panel1.Controls.Add(this.uiNoteSpellBox);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.uiCalculatingHashLabel);
            this.splitContainer1.Panel1.Controls.Add(this.uiHashCalcProgressBar);
            this.splitContainer1.Panel1.Controls.Add(this.uiHashTextBox);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.uiDateAndTimeTextBox);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.uiVideoMediaPlayer);
            this.splitContainer1.Size = new System.Drawing.Size(955, 632);
            this.splitContainer1.SplitterDistance = 355;
            this.splitContainer1.TabIndex = 0;
            // 
            // uiDoesFileExistPictureBox
            // 
            this.uiDoesFileExistPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiDoesFileExistPictureBox.Location = new System.Drawing.Point(297, 34);
            this.uiDoesFileExistPictureBox.Name = "uiDoesFileExistPictureBox";
            this.uiDoesFileExistPictureBox.Size = new System.Drawing.Size(17, 16);
            this.uiDoesFileExistPictureBox.TabIndex = 29;
            this.uiDoesFileExistPictureBox.TabStop = false;
            // 
            // uiVideoNameComboBox
            // 
            this.uiVideoNameComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiVideoNameComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.uiVideoNameComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.uiVideoNameComboBox.FormattingEnabled = true;
            this.uiVideoNameComboBox.Location = new System.Drawing.Point(12, 29);
            this.uiVideoNameComboBox.MaxLength = 128;
            this.uiVideoNameComboBox.Name = "uiVideoNameComboBox";
            this.uiVideoNameComboBox.Size = new System.Drawing.Size(279, 21);
            this.uiVideoNameComboBox.TabIndex = 27;
            // 
            // uiNotePictureBox
            // 
            this.uiNotePictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiNotePictureBox.Location = new System.Drawing.Point(319, 366);
            this.uiNotePictureBox.Name = "uiNotePictureBox";
            this.uiNotePictureBox.Size = new System.Drawing.Size(17, 16);
            this.uiNotePictureBox.TabIndex = 26;
            this.uiNotePictureBox.TabStop = false;
            // 
            // uiCancelButton
            // 
            this.uiCancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.uiCancelButton.Location = new System.Drawing.Point(153, 388);
            this.uiCancelButton.Name = "uiCancelButton";
            this.uiCancelButton.Size = new System.Drawing.Size(79, 23);
            this.uiCancelButton.TabIndex = 25;
            this.uiCancelButton.Text = "Cancel";
            this.uiCancelButton.UseVisualStyleBackColor = true;
            // 
            // uiOKButton
            // 
            this.uiOKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiOKButton.Location = new System.Drawing.Point(237, 388);
            this.uiOKButton.Name = "uiOKButton";
            this.uiOKButton.Size = new System.Drawing.Size(79, 23);
            this.uiOKButton.TabIndex = 23;
            this.uiOKButton.Text = "Log";
            this.uiOKButton.UseVisualStyleBackColor = true;
            this.uiOKButton.Click += new System.EventHandler(this.uiOKButton_Click);
            // 
            // uiNoteSpellBox
            // 
            this.uiNoteSpellBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiNoteSpellBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiNoteSpellBox.Location = new System.Drawing.Point(15, 195);
            this.uiNoteSpellBox.Multiline = true;
            this.uiNoteSpellBox.Name = "uiNoteSpellBox";
            this.uiNoteSpellBox.Size = new System.Drawing.Size(301, 187);
            this.uiNoteSpellBox.TabIndex = 22;
            this.uiNoteSpellBox.WordWrap = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.Location = new System.Drawing.Point(14, 178);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Note (Required)";
            // 
            // uiCalculatingHashLabel
            // 
            this.uiCalculatingHashLabel.AutoSize = true;
            this.uiCalculatingHashLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.uiCalculatingHashLabel.Location = new System.Drawing.Point(12, 124);
            this.uiCalculatingHashLabel.Name = "uiCalculatingHashLabel";
            this.uiCalculatingHashLabel.Size = new System.Drawing.Size(96, 13);
            this.uiCalculatingHashLabel.TabIndex = 21;
            this.uiCalculatingHashLabel.Text = "Calculating Hash...";
            // 
            // uiHashCalcProgressBar
            // 
            this.uiHashCalcProgressBar.Location = new System.Drawing.Point(15, 140);
            this.uiHashCalcProgressBar.MarqueeAnimationSpeed = 30;
            this.uiHashCalcProgressBar.Name = "uiHashCalcProgressBar";
            this.uiHashCalcProgressBar.Size = new System.Drawing.Size(300, 20);
            this.uiHashCalcProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.uiHashCalcProgressBar.TabIndex = 20;
            // 
            // uiHashTextBox
            // 
            this.uiHashTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiHashTextBox.Location = new System.Drawing.Point(15, 140);
            this.uiHashTextBox.Name = "uiHashTextBox";
            this.uiHashTextBox.ReadOnly = true;
            this.uiHashTextBox.Size = new System.Drawing.Size(299, 20);
            this.uiHashTextBox.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(12, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Date and Time";
            // 
            // uiDateAndTimeTextBox
            // 
            this.uiDateAndTimeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiDateAndTimeTextBox.Location = new System.Drawing.Point(15, 85);
            this.uiDateAndTimeTextBox.Name = "uiDateAndTimeTextBox";
            this.uiDateAndTimeTextBox.ReadOnly = true;
            this.uiDateAndTimeTextBox.Size = new System.Drawing.Size(299, 20);
            this.uiDateAndTimeTextBox.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "File Name:";
            // 
            // uiVideoMediaPlayer
            // 
            this.uiVideoMediaPlayer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.uiVideoMediaPlayer.Enabled = true;
            this.uiVideoMediaPlayer.Location = new System.Drawing.Point(3, 104);
            this.uiVideoMediaPlayer.Name = "uiVideoMediaPlayer";
            this.uiVideoMediaPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("uiVideoMediaPlayer.OcxState")));
            this.uiVideoMediaPlayer.Size = new System.Drawing.Size(587, 411);
            this.uiVideoMediaPlayer.TabIndex = 0;
            // 
            // VideoPreviewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 632);
            this.Controls.Add(this.splitContainer1);
            this.Name = "VideoPreviewer";
            this.Text = "Video Previewer";
            this.Load += new System.EventHandler(this.VideoPreviewer_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiDoesFileExistPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiNotePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiVideoMediaPlayer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private AxWMPLib.AxWindowsMediaPlayer uiVideoMediaPlayer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label uiCalculatingHashLabel;
        private System.Windows.Forms.ProgressBar uiHashCalcProgressBar;
        private System.Windows.Forms.TextBox uiHashTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox uiDateAndTimeTextBox;
        private System.Windows.Forms.PictureBox uiNotePictureBox;
        private System.Windows.Forms.Button uiCancelButton;
        private System.Windows.Forms.Button uiOKButton;
        private SpellBox uiNoteSpellBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Controls.TextBox hostedComponent1;
        private System.Windows.Forms.PictureBox uiDoesFileExistPictureBox;
        private System.Windows.Forms.ComboBox uiVideoNameComboBox;
        private System.Windows.Controls.TextBox hostedComponent2;
    }
}