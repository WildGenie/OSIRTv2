namespace OSIRT.UI
{
    partial class Previewer
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
            this.uiPreviewerSplitContainer = new System.Windows.Forms.SplitContainer();
            this.uiNotePictureBox = new System.Windows.Forms.PictureBox();
            this.uiFileExtensionComboBox = new System.Windows.Forms.ComboBox();
            this.uiDoesFileExistPictureBox = new System.Windows.Forms.PictureBox();
            this.uiCalculatingHashLabel = new System.Windows.Forms.Label();
            this.uiHashCalcProgressBar = new System.Windows.Forms.ProgressBar();
            this.uiHashTextBox = new System.Windows.Forms.TextBox();
            this.uiCancelButton = new System.Windows.Forms.Button();
            this.uiOKButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.uiDateAndTimeTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.uiFileNameComboBox = new System.Windows.Forms.ComboBox();
            this.uiNoteSpellBox = new OSIRT.UI.SpellBox();
            this.hostedComponent3 = new System.Windows.Controls.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.uiPreviewerSplitContainer)).BeginInit();
            this.uiPreviewerSplitContainer.Panel1.SuspendLayout();
            this.uiPreviewerSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiNotePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiDoesFileExistPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // uiPreviewerSplitContainer
            // 
            this.uiPreviewerSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiPreviewerSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.uiPreviewerSplitContainer.Name = "uiPreviewerSplitContainer";
            // 
            // uiPreviewerSplitContainer.Panel1
            // 
            this.uiPreviewerSplitContainer.Panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.uiPreviewerSplitContainer.Panel1.Controls.Add(this.uiNotePictureBox);
            this.uiPreviewerSplitContainer.Panel1.Controls.Add(this.uiFileExtensionComboBox);
            this.uiPreviewerSplitContainer.Panel1.Controls.Add(this.uiDoesFileExistPictureBox);
            this.uiPreviewerSplitContainer.Panel1.Controls.Add(this.uiCalculatingHashLabel);
            this.uiPreviewerSplitContainer.Panel1.Controls.Add(this.uiHashCalcProgressBar);
            this.uiPreviewerSplitContainer.Panel1.Controls.Add(this.uiHashTextBox);
            this.uiPreviewerSplitContainer.Panel1.Controls.Add(this.uiCancelButton);
            this.uiPreviewerSplitContainer.Panel1.Controls.Add(this.uiOKButton);
            this.uiPreviewerSplitContainer.Panel1.Controls.Add(this.uiNoteSpellBox);
            this.uiPreviewerSplitContainer.Panel1.Controls.Add(this.label5);
            this.uiPreviewerSplitContainer.Panel1.Controls.Add(this.label2);
            this.uiPreviewerSplitContainer.Panel1.Controls.Add(this.uiDateAndTimeTextBox);
            this.uiPreviewerSplitContainer.Panel1.Controls.Add(this.label1);
            this.uiPreviewerSplitContainer.Panel1.Controls.Add(this.uiFileNameComboBox);
            this.uiPreviewerSplitContainer.Size = new System.Drawing.Size(1073, 614);
            this.uiPreviewerSplitContainer.SplitterDistance = 365;
            this.uiPreviewerSplitContainer.TabIndex = 0;
            // 
            // uiNotePictureBox
            // 
            this.uiNotePictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiNotePictureBox.Location = new System.Drawing.Point(345, 378);
            this.uiNotePictureBox.Name = "uiNotePictureBox";
            this.uiNotePictureBox.Size = new System.Drawing.Size(17, 16);
            this.uiNotePictureBox.TabIndex = 35;
            this.uiNotePictureBox.TabStop = false;
            // 
            // uiFileExtensionComboBox
            // 
            this.uiFileExtensionComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiFileExtensionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.uiFileExtensionComboBox.FormattingEnabled = true;
            this.uiFileExtensionComboBox.Location = new System.Drawing.Point(274, 25);
            this.uiFileExtensionComboBox.Name = "uiFileExtensionComboBox";
            this.uiFileExtensionComboBox.Size = new System.Drawing.Size(64, 21);
            this.uiFileExtensionComboBox.TabIndex = 21;
            // 
            // uiDoesFileExistPictureBox
            // 
            this.uiDoesFileExistPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiDoesFileExistPictureBox.Location = new System.Drawing.Point(345, 30);
            this.uiDoesFileExistPictureBox.Name = "uiDoesFileExistPictureBox";
            this.uiDoesFileExistPictureBox.Size = new System.Drawing.Size(17, 16);
            this.uiDoesFileExistPictureBox.TabIndex = 34;
            this.uiDoesFileExistPictureBox.TabStop = false;
            // 
            // uiCalculatingHashLabel
            // 
            this.uiCalculatingHashLabel.AutoSize = true;
            this.uiCalculatingHashLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.uiCalculatingHashLabel.Location = new System.Drawing.Point(12, 114);
            this.uiCalculatingHashLabel.Name = "uiCalculatingHashLabel";
            this.uiCalculatingHashLabel.Size = new System.Drawing.Size(96, 13);
            this.uiCalculatingHashLabel.TabIndex = 33;
            this.uiCalculatingHashLabel.Text = "Calculating Hash...";
            // 
            // uiHashCalcProgressBar
            // 
            this.uiHashCalcProgressBar.Location = new System.Drawing.Point(15, 130);
            this.uiHashCalcProgressBar.MarqueeAnimationSpeed = 30;
            this.uiHashCalcProgressBar.Name = "uiHashCalcProgressBar";
            this.uiHashCalcProgressBar.Size = new System.Drawing.Size(323, 20);
            this.uiHashCalcProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.uiHashCalcProgressBar.TabIndex = 32;
            // 
            // uiHashTextBox
            // 
            this.uiHashTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiHashTextBox.Location = new System.Drawing.Point(15, 130);
            this.uiHashTextBox.Name = "uiHashTextBox";
            this.uiHashTextBox.ReadOnly = true;
            this.uiHashTextBox.Size = new System.Drawing.Size(324, 20);
            this.uiHashTextBox.TabIndex = 31;
            // 
            // uiCancelButton
            // 
            this.uiCancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.uiCancelButton.Location = new System.Drawing.Point(174, 400);
            this.uiCancelButton.Name = "uiCancelButton";
            this.uiCancelButton.Size = new System.Drawing.Size(79, 23);
            this.uiCancelButton.TabIndex = 30;
            this.uiCancelButton.Text = "Cancel";
            this.uiCancelButton.UseVisualStyleBackColor = true;
            // 
            // uiOKButton
            // 
            this.uiOKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiOKButton.Location = new System.Drawing.Point(259, 400);
            this.uiOKButton.Name = "uiOKButton";
            this.uiOKButton.Size = new System.Drawing.Size(79, 23);
            this.uiOKButton.TabIndex = 24;
            this.uiOKButton.Text = "Log";
            this.uiOKButton.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.Location = new System.Drawing.Point(12, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "Note (Required)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(12, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Date and Time";
            // 
            // uiDateAndTimeTextBox
            // 
            this.uiDateAndTimeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiDateAndTimeTextBox.Location = new System.Drawing.Point(15, 75);
            this.uiDateAndTimeTextBox.Name = "uiDateAndTimeTextBox";
            this.uiDateAndTimeTextBox.ReadOnly = true;
            this.uiDateAndTimeTextBox.Size = new System.Drawing.Size(324, 20);
            this.uiDateAndTimeTextBox.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "File Name";
            // 
            // uiFileNameComboBox
            // 
            this.uiFileNameComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiFileNameComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.uiFileNameComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.uiFileNameComboBox.FormattingEnabled = true;
            this.uiFileNameComboBox.Location = new System.Drawing.Point(15, 25);
            this.uiFileNameComboBox.MaxLength = 128;
            this.uiFileNameComboBox.Name = "uiFileNameComboBox";
            this.uiFileNameComboBox.Size = new System.Drawing.Size(253, 21);
            this.uiFileNameComboBox.TabIndex = 20;
            // 
            // uiNoteSpellBox
            // 
            this.uiNoteSpellBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiNoteSpellBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiNoteSpellBox.Location = new System.Drawing.Point(13, 207);
            this.uiNoteSpellBox.Multiline = true;
            this.uiNoteSpellBox.Name = "uiNoteSpellBox";
            this.uiNoteSpellBox.Size = new System.Drawing.Size(326, 187);
            this.uiNoteSpellBox.TabIndex = 23;
            this.uiNoteSpellBox.WordWrap = true;
            // 
            // Previewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1073, 614);
            this.Controls.Add(this.uiPreviewerSplitContainer);
            this.Name = "Previewer";
            this.Text = "Previewer";
            this.Load += new System.EventHandler(this.Previewer_Load);
            this.uiPreviewerSplitContainer.Panel1.ResumeLayout(false);
            this.uiPreviewerSplitContainer.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiPreviewerSplitContainer)).EndInit();
            this.uiPreviewerSplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiNotePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiDoesFileExistPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Controls.TextBox hostedComponent1;
        protected System.Windows.Controls.TextBox hostedComponent2;
        protected System.Windows.Forms.SplitContainer uiPreviewerSplitContainer;
        protected System.Windows.Forms.PictureBox uiNotePictureBox;
        protected System.Windows.Forms.ComboBox uiFileExtensionComboBox;
        protected System.Windows.Forms.PictureBox uiDoesFileExistPictureBox;
        protected System.Windows.Forms.Label uiCalculatingHashLabel;
        protected System.Windows.Forms.ProgressBar uiHashCalcProgressBar;
        protected System.Windows.Forms.TextBox uiHashTextBox;
        protected System.Windows.Forms.Button uiCancelButton;
        protected System.Windows.Forms.Button uiOKButton;
        protected SpellBox uiNoteSpellBox;
        protected System.Windows.Forms.Label label5;
        protected System.Windows.Forms.Label label2;
        protected System.Windows.Forms.TextBox uiDateAndTimeTextBox;
        protected System.Windows.Forms.Label label1;
        protected System.Windows.Forms.ComboBox uiFileNameComboBox;
        protected System.Windows.Controls.TextBox hostedComponent3;
    }
}