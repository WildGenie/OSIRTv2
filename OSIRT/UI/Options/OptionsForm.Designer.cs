namespace OSIRT.UI.Options
{
    partial class OptionsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsForm));
            this.uiOptionsTabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.uiDeleteCacheOnCloseCheckBox = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.uiHomePageTextBox = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.uiRecordingOptionsGroupBox = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.uiCaptureGroupBox = new System.Windows.Forms.GroupBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.uiShowMouseTrailCheckBox = new System.Windows.Forms.CheckBox();
            this.uiAudioGroupBox = new System.Windows.Forms.GroupBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.uiBrowseLocationButton = new System.Windows.Forms.Button();
            this.uiHashFileLocationTextBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.uiBrowseIconButton = new System.Windows.Forms.Button();
            this.uiConstabularyIconPictureBox = new System.Windows.Forms.PictureBox();
            this.uiCloseButton = new System.Windows.Forms.Button();
            this.uiOptionsTabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.uiRecordingOptionsGroupBox.SuspendLayout();
            this.uiCaptureGroupBox.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiConstabularyIconPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // uiOptionsTabControl
            // 
            this.uiOptionsTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiOptionsTabControl.Controls.Add(this.tabPage1);
            this.uiOptionsTabControl.Controls.Add(this.tabPage2);
            this.uiOptionsTabControl.Controls.Add(this.tabPage3);
            this.uiOptionsTabControl.Location = new System.Drawing.Point(0, 0);
            this.uiOptionsTabControl.Name = "uiOptionsTabControl";
            this.uiOptionsTabControl.SelectedIndex = 0;
            this.uiOptionsTabControl.Size = new System.Drawing.Size(491, 363);
            this.uiOptionsTabControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(483, 337);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Browser";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.uiDeleteCacheOnCloseCheckBox);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.uiHomePageTextBox);
            this.groupBox1.Location = new System.Drawing.Point(9, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(466, 121);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "General ";
            // 
            // uiDeleteCacheOnCloseCheckBox
            // 
            this.uiDeleteCacheOnCloseCheckBox.AutoSize = true;
            this.uiDeleteCacheOnCloseCheckBox.Location = new System.Drawing.Point(10, 88);
            this.uiDeleteCacheOnCloseCheckBox.Name = "uiDeleteCacheOnCloseCheckBox";
            this.uiDeleteCacheOnCloseCheckBox.Size = new System.Drawing.Size(133, 17);
            this.uiDeleteCacheOnCloseCheckBox.TabIndex = 3;
            this.uiDeleteCacheOnCloseCheckBox.Text = "Delete cache on close";
            this.uiDeleteCacheOnCloseCheckBox.UseVisualStyleBackColor = true;
            this.uiDeleteCacheOnCloseCheckBox.CheckedChanged += new System.EventHandler(this.uiDeleteCacheOnCloseCheckBox_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(376, 36);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Homepage";
            // 
            // uiHomePageTextBox
            // 
            this.uiHomePageTextBox.Enabled = false;
            this.uiHomePageTextBox.Location = new System.Drawing.Point(6, 39);
            this.uiHomePageTextBox.Name = "uiHomePageTextBox";
            this.uiHomePageTextBox.Size = new System.Drawing.Size(364, 20);
            this.uiHomePageTextBox.TabIndex = 0;
            this.uiHomePageTextBox.Text = "(Currently Disabled)";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.uiRecordingOptionsGroupBox);
            this.tabPage2.Controls.Add(this.uiCaptureGroupBox);
            this.tabPage2.Controls.Add(this.uiAudioGroupBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(483, 337);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Video Recording";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // uiRecordingOptionsGroupBox
            // 
            this.uiRecordingOptionsGroupBox.Controls.Add(this.label2);
            this.uiRecordingOptionsGroupBox.Controls.Add(this.label1);
            this.uiRecordingOptionsGroupBox.Location = new System.Drawing.Point(8, 99);
            this.uiRecordingOptionsGroupBox.Name = "uiRecordingOptionsGroupBox";
            this.uiRecordingOptionsGroupBox.Size = new System.Drawing.Size(467, 74);
            this.uiRecordingOptionsGroupBox.TabIndex = 1;
            this.uiRecordingOptionsGroupBox.TabStop = false;
            this.uiRecordingOptionsGroupBox.Text = "Recording";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(274, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Bir rate (these will be drop downs, just here to remind me)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "FPS";
            // 
            // uiCaptureGroupBox
            // 
            this.uiCaptureGroupBox.Controls.Add(this.checkBox2);
            this.uiCaptureGroupBox.Controls.Add(this.uiShowMouseTrailCheckBox);
            this.uiCaptureGroupBox.Location = new System.Drawing.Point(8, 179);
            this.uiCaptureGroupBox.Name = "uiCaptureGroupBox";
            this.uiCaptureGroupBox.Size = new System.Drawing.Size(467, 66);
            this.uiCaptureGroupBox.TabIndex = 1;
            this.uiCaptureGroupBox.TabStop = false;
            this.uiCaptureGroupBox.Text = "Capture";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(6, 42);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(117, 17);
            this.checkBox2.TabIndex = 1;
            this.checkBox2.Text = "Show mouse clicks";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // uiShowMouseTrailCheckBox
            // 
            this.uiShowMouseTrailCheckBox.AutoSize = true;
            this.uiShowMouseTrailCheckBox.Location = new System.Drawing.Point(6, 19);
            this.uiShowMouseTrailCheckBox.Name = "uiShowMouseTrailCheckBox";
            this.uiShowMouseTrailCheckBox.Size = new System.Drawing.Size(106, 17);
            this.uiShowMouseTrailCheckBox.TabIndex = 0;
            this.uiShowMouseTrailCheckBox.Text = "Show mouse trail";
            this.uiShowMouseTrailCheckBox.UseVisualStyleBackColor = true;
            this.uiShowMouseTrailCheckBox.CheckedChanged += new System.EventHandler(this.uiShowMouseTrailCheckBox_CheckedChanged);
            // 
            // uiAudioGroupBox
            // 
            this.uiAudioGroupBox.Location = new System.Drawing.Point(8, 6);
            this.uiAudioGroupBox.Name = "uiAudioGroupBox";
            this.uiAudioGroupBox.Size = new System.Drawing.Size(467, 87);
            this.uiAudioGroupBox.TabIndex = 0;
            this.uiAudioGroupBox.TabStop = false;
            this.uiAudioGroupBox.Text = "Audio";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox3);
            this.tabPage3.Controls.Add(this.groupBox2);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(483, 337);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "General";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.uiBrowseLocationButton);
            this.groupBox3.Controls.Add(this.uiHashFileLocationTextBox);
            this.groupBox3.Location = new System.Drawing.Point(9, 187);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(466, 67);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Hash Export Location";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(275, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Select where the hash file is saved after closing the case";
            // 
            // uiBrowseLocationButton
            // 
            this.uiBrowseLocationButton.Location = new System.Drawing.Point(385, 17);
            this.uiBrowseLocationButton.Name = "uiBrowseLocationButton";
            this.uiBrowseLocationButton.Size = new System.Drawing.Size(75, 23);
            this.uiBrowseLocationButton.TabIndex = 2;
            this.uiBrowseLocationButton.Text = "Browse...";
            this.uiBrowseLocationButton.UseVisualStyleBackColor = true;
            this.uiBrowseLocationButton.Click += new System.EventHandler(this.uiBrowseLocationButton_Click);
            // 
            // uiHashFileLocationTextBox
            // 
            this.uiHashFileLocationTextBox.Location = new System.Drawing.Point(6, 19);
            this.uiHashFileLocationTextBox.Name = "uiHashFileLocationTextBox";
            this.uiHashFileLocationTextBox.ReadOnly = true;
            this.uiHashFileLocationTextBox.Size = new System.Drawing.Size(373, 20);
            this.uiHashFileLocationTextBox.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.uiBrowseIconButton);
            this.groupBox2.Controls.Add(this.uiConstabularyIconPictureBox);
            this.groupBox2.Location = new System.Drawing.Point(8, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(467, 167);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Constabulary Icon";
            // 
            // uiBrowseIconButton
            // 
            this.uiBrowseIconButton.Location = new System.Drawing.Point(230, 134);
            this.uiBrowseIconButton.Name = "uiBrowseIconButton";
            this.uiBrowseIconButton.Size = new System.Drawing.Size(75, 23);
            this.uiBrowseIconButton.TabIndex = 1;
            this.uiBrowseIconButton.Text = "Browse...";
            this.uiBrowseIconButton.UseVisualStyleBackColor = true;
            this.uiBrowseIconButton.Click += new System.EventHandler(this.uiBrowseIconButton_Click);
            // 
            // uiConstabularyIconPictureBox
            // 
            this.uiConstabularyIconPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.uiConstabularyIconPictureBox.Location = new System.Drawing.Point(311, 15);
            this.uiConstabularyIconPictureBox.Name = "uiConstabularyIconPictureBox";
            this.uiConstabularyIconPictureBox.Size = new System.Drawing.Size(150, 142);
            this.uiConstabularyIconPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.uiConstabularyIconPictureBox.TabIndex = 0;
            this.uiConstabularyIconPictureBox.TabStop = false;
            // 
            // uiCloseButton
            // 
            this.uiCloseButton.Location = new System.Drawing.Point(412, 365);
            this.uiCloseButton.Name = "uiCloseButton";
            this.uiCloseButton.Size = new System.Drawing.Size(75, 23);
            this.uiCloseButton.TabIndex = 1;
            this.uiCloseButton.Text = "Close";
            this.uiCloseButton.UseVisualStyleBackColor = true;
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 391);
            this.Controls.Add(this.uiCloseButton);
            this.Controls.Add(this.uiOptionsTabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OptionsForm";
            this.Text = "Options Form";
            this.Load += new System.EventHandler(this.OptionsForm_Load);
            this.uiOptionsTabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.uiRecordingOptionsGroupBox.ResumeLayout(false);
            this.uiRecordingOptionsGroupBox.PerformLayout();
            this.uiCaptureGroupBox.ResumeLayout(false);
            this.uiCaptureGroupBox.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiConstabularyIconPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl uiOptionsTabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox uiCaptureGroupBox;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox uiShowMouseTrailCheckBox;
        private System.Windows.Forms.GroupBox uiAudioGroupBox;
        private System.Windows.Forms.GroupBox uiRecordingOptionsGroupBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox uiDeleteCacheOnCloseCheckBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox uiHomePageTextBox;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button uiBrowseIconButton;
        private System.Windows.Forms.PictureBox uiConstabularyIconPictureBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button uiBrowseLocationButton;
        private System.Windows.Forms.TextBox uiHashFileLocationTextBox;
        private System.Windows.Forms.Button uiCloseButton;
    }
}