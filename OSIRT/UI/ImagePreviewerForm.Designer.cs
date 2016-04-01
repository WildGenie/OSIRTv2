namespace OSIRT.UI
{
    partial class ImagePreviewerForm
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
            this.components = new System.ComponentModel.Container();
            this.uiSplitContainer = new System.Windows.Forms.SplitContainer();
            this.uiNotePictureBox = new System.Windows.Forms.PictureBox();
            this.uiFileExtensionComboBox = new System.Windows.Forms.ComboBox();
            this.uiDoesFileExistPictureBox = new System.Windows.Forms.PictureBox();
            this.uiCalculatingHashLabel = new System.Windows.Forms.Label();
            this.uiHashCalcProgressBar = new System.Windows.Forms.ProgressBar();
            this.uiHashTextBox = new System.Windows.Forms.TextBox();
            this.uiCancelButton = new System.Windows.Forms.Button();
            this.uiOKButton = new System.Windows.Forms.Button();
            this.uiNoteSpellBox = new OSIRT.UI.SpellBox();
            this.hostedComponent6 = new System.Windows.Controls.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.uiURLTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.uiDateAndTimeTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.uiImageNameComboBox = new System.Windows.Forms.ComboBox();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.uiSplitContainer)).BeginInit();
            this.uiSplitContainer.Panel1.SuspendLayout();
            this.uiSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiNotePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiDoesFileExistPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // uiSplitContainer
            // 
            this.uiSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.uiSplitContainer.Name = "uiSplitContainer";
            // 
            // uiSplitContainer.Panel1
            // 
            this.uiSplitContainer.Panel1.Controls.Add(this.uiNotePictureBox);
            this.uiSplitContainer.Panel1.Controls.Add(this.uiFileExtensionComboBox);
            this.uiSplitContainer.Panel1.Controls.Add(this.uiDoesFileExistPictureBox);
            this.uiSplitContainer.Panel1.Controls.Add(this.uiCalculatingHashLabel);
            this.uiSplitContainer.Panel1.Controls.Add(this.uiHashCalcProgressBar);
            this.uiSplitContainer.Panel1.Controls.Add(this.uiHashTextBox);
            this.uiSplitContainer.Panel1.Controls.Add(this.uiCancelButton);
            this.uiSplitContainer.Panel1.Controls.Add(this.uiOKButton);
            this.uiSplitContainer.Panel1.Controls.Add(this.uiNoteSpellBox);
            this.uiSplitContainer.Panel1.Controls.Add(this.label5);
            this.uiSplitContainer.Panel1.Controls.Add(this.label3);
            this.uiSplitContainer.Panel1.Controls.Add(this.uiURLTextBox);
            this.uiSplitContainer.Panel1.Controls.Add(this.label2);
            this.uiSplitContainer.Panel1.Controls.Add(this.uiDateAndTimeTextBox);
            this.uiSplitContainer.Panel1.Controls.Add(this.label1);
            this.uiSplitContainer.Panel1.Controls.Add(this.uiImageNameComboBox);
            this.uiSplitContainer.Size = new System.Drawing.Size(1004, 592);
            this.uiSplitContainer.SplitterDistance = 346;
            this.uiSplitContainer.TabIndex = 0;
            // 
            // uiNotePictureBox
            // 
            this.uiNotePictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiNotePictureBox.Location = new System.Drawing.Point(318, 418);
            this.uiNotePictureBox.Name = "uiNotePictureBox";
            this.uiNotePictureBox.Size = new System.Drawing.Size(17, 16);
            this.uiNotePictureBox.TabIndex = 19;
            this.uiNotePictureBox.TabStop = false;
            this.ToolTip.SetToolTip(this.uiNotePictureBox, "\r\n");
            // 
            // uiFileExtensionComboBox
            // 
            this.uiFileExtensionComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiFileExtensionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.uiFileExtensionComboBox.FormattingEnabled = true;
            this.uiFileExtensionComboBox.Location = new System.Drawing.Point(247, 25);
            this.uiFileExtensionComboBox.Name = "uiFileExtensionComboBox";
            this.uiFileExtensionComboBox.Size = new System.Drawing.Size(64, 21);
            this.uiFileExtensionComboBox.TabIndex = 1;
            this.uiFileExtensionComboBox.SelectedIndexChanged += new System.EventHandler(this.uiFileExtensionComboBox_SelectedIndexChanged);
            // 
            // uiDoesFileExistPictureBox
            // 
            this.uiDoesFileExistPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiDoesFileExistPictureBox.Location = new System.Drawing.Point(318, 27);
            this.uiDoesFileExistPictureBox.Name = "uiDoesFileExistPictureBox";
            this.uiDoesFileExistPictureBox.Size = new System.Drawing.Size(17, 16);
            this.uiDoesFileExistPictureBox.TabIndex = 17;
            this.uiDoesFileExistPictureBox.TabStop = false;
            this.ToolTip.SetToolTip(this.uiDoesFileExistPictureBox, "\r\n");
            // 
            // uiCalculatingHashLabel
            // 
            this.uiCalculatingHashLabel.AutoSize = true;
            this.uiCalculatingHashLabel.Location = new System.Drawing.Point(12, 166);
            this.uiCalculatingHashLabel.Name = "uiCalculatingHashLabel";
            this.uiCalculatingHashLabel.Size = new System.Drawing.Size(96, 13);
            this.uiCalculatingHashLabel.TabIndex = 16;
            this.uiCalculatingHashLabel.Text = "Calculating Hash...";
            // 
            // uiHashCalcProgressBar
            // 
            this.uiHashCalcProgressBar.Location = new System.Drawing.Point(15, 182);
            this.uiHashCalcProgressBar.MarqueeAnimationSpeed = 30;
            this.uiHashCalcProgressBar.Name = "uiHashCalcProgressBar";
            this.uiHashCalcProgressBar.Size = new System.Drawing.Size(300, 20);
            this.uiHashCalcProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.uiHashCalcProgressBar.TabIndex = 15;
            // 
            // uiHashTextBox
            // 
            this.uiHashTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiHashTextBox.Location = new System.Drawing.Point(15, 182);
            this.uiHashTextBox.Name = "uiHashTextBox";
            this.uiHashTextBox.ReadOnly = true;
            this.uiHashTextBox.Size = new System.Drawing.Size(300, 20);
            this.uiHashTextBox.TabIndex = 14;
            // 
            // uiCancelButton
            // 
            this.uiCancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.uiCancelButton.Location = new System.Drawing.Point(152, 440);
            this.uiCancelButton.Name = "uiCancelButton";
            this.uiCancelButton.Size = new System.Drawing.Size(79, 23);
            this.uiCancelButton.TabIndex = 12;
            this.uiCancelButton.Text = "Cancel";
            this.ToolTip.SetToolTip(this.uiCancelButton, "Do not log this image and close the Image Previewer");
            this.uiCancelButton.UseVisualStyleBackColor = true;
            this.uiCancelButton.Click += new System.EventHandler(this.uiCancelButton_Click);
            // 
            // uiOKButton
            // 
            this.uiOKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiOKButton.Location = new System.Drawing.Point(236, 440);
            this.uiOKButton.Name = "uiOKButton";
            this.uiOKButton.Size = new System.Drawing.Size(79, 23);
            this.uiOKButton.TabIndex = 3;
            this.uiOKButton.Text = "OK";
            this.ToolTip.SetToolTip(this.uiOKButton, "Log this image and associated details");
            this.uiOKButton.UseVisualStyleBackColor = true;
            this.uiOKButton.Click += new System.EventHandler(this.uiOKButton_Click);
            // 
            // uiNoteSpellBox
            // 
            this.uiNoteSpellBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiNoteSpellBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiNoteSpellBox.Location = new System.Drawing.Point(13, 247);
            this.uiNoteSpellBox.Multiline = true;
            this.uiNoteSpellBox.Name = "uiNoteSpellBox";
            this.uiNoteSpellBox.Size = new System.Drawing.Size(302, 187);
            this.uiNoteSpellBox.TabIndex = 2;
            this.uiNoteSpellBox.WordWrap = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 230);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Note (Required)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "URL";
            // 
            // uiURLTextBox
            // 
            this.uiURLTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiURLTextBox.Location = new System.Drawing.Point(15, 75);
            this.uiURLTextBox.Name = "uiURLTextBox";
            this.uiURLTextBox.ReadOnly = true;
            this.uiURLTextBox.Size = new System.Drawing.Size(300, 20);
            this.uiURLTextBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Date and Time";
            // 
            // uiDateAndTimeTextBox
            // 
            this.uiDateAndTimeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiDateAndTimeTextBox.Location = new System.Drawing.Point(15, 127);
            this.uiDateAndTimeTextBox.Name = "uiDateAndTimeTextBox";
            this.uiDateAndTimeTextBox.ReadOnly = true;
            this.uiDateAndTimeTextBox.Size = new System.Drawing.Size(300, 20);
            this.uiDateAndTimeTextBox.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Image Name";
            // 
            // uiImageNameComboBox
            // 
            this.uiImageNameComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiImageNameComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.uiImageNameComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.uiImageNameComboBox.FormattingEnabled = true;
            this.uiImageNameComboBox.Location = new System.Drawing.Point(15, 25);
            this.uiImageNameComboBox.MaxLength = 128;
            this.uiImageNameComboBox.Name = "uiImageNameComboBox";
            this.uiImageNameComboBox.Size = new System.Drawing.Size(226, 21);
            this.uiImageNameComboBox.TabIndex = 0;
            this.uiImageNameComboBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.uiImageNameComboBox_KeyUp);
            // 
            // ImagePreviewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 592);
            this.Controls.Add(this.uiSplitContainer);
            this.MinimumSize = new System.Drawing.Size(800, 454);
            this.Name = "ImagePreviewerForm";
            this.Text = "Image Previewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ImagePreviewerForm_FormClosing);
            this.Load += new System.EventHandler(this.ImagePreviewerForm_Load);
            this.uiSplitContainer.Panel1.ResumeLayout(false);
            this.uiSplitContainer.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiSplitContainer)).EndInit();
            this.uiSplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiNotePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiDoesFileExistPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer uiSplitContainer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox uiURLTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox uiDateAndTimeTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox uiImageNameComboBox;
        private SpellBox uiNoteSpellBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button uiCancelButton;
        private System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.Button uiOKButton;
        private System.Windows.Forms.TextBox uiHashTextBox;
        private System.Windows.Forms.Label uiCalculatingHashLabel;
        private System.Windows.Forms.ProgressBar uiHashCalcProgressBar;
        private System.Windows.Forms.PictureBox uiDoesFileExistPictureBox;
        private System.Windows.Forms.ComboBox uiFileExtensionComboBox;
        private System.Windows.Controls.TextBox hostedComponent13;
        private System.Windows.Controls.TextBox hostedComponent1;
        private System.Windows.Controls.TextBox hostedComponent2;
        private System.Windows.Forms.PictureBox uiNotePictureBox;
        private System.Windows.Controls.TextBox hostedComponent3;
        private System.Windows.Controls.TextBox hostedComponent4;
        private System.Windows.Controls.TextBox hostedComponent5;
        private System.Windows.Controls.TextBox hostedComponent6;
    }
}