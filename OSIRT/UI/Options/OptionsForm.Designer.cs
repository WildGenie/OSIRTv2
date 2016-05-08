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
            this.uiOptionsTabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.uiRecordingOptionsGroupBox = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.uiCaptureGroupBox = new System.Windows.Forms.GroupBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.uiShowMouseTrailCheckBox = new System.Windows.Forms.CheckBox();
            this.uiAudioGroupBox = new System.Windows.Forms.GroupBox();
            this.uiOptionsTabControl.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.uiRecordingOptionsGroupBox.SuspendLayout();
            this.uiCaptureGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiOptionsTabControl
            // 
            this.uiOptionsTabControl.Controls.Add(this.tabPage1);
            this.uiOptionsTabControl.Controls.Add(this.tabPage2);
            this.uiOptionsTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiOptionsTabControl.Location = new System.Drawing.Point(0, 0);
            this.uiOptionsTabControl.Name = "uiOptionsTabControl";
            this.uiOptionsTabControl.SelectedIndex = 0;
            this.uiOptionsTabControl.Size = new System.Drawing.Size(491, 397);
            this.uiOptionsTabControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(483, 371);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.uiRecordingOptionsGroupBox);
            this.tabPage2.Controls.Add(this.uiCaptureGroupBox);
            this.tabPage2.Controls.Add(this.uiAudioGroupBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(483, 371);
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
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 397);
            this.Controls.Add(this.uiOptionsTabControl);
            this.Name = "OptionsForm";
            this.Text = "Options Form";
            this.Load += new System.EventHandler(this.OptionsForm_Load);
            this.uiOptionsTabControl.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.uiRecordingOptionsGroupBox.ResumeLayout(false);
            this.uiRecordingOptionsGroupBox.PerformLayout();
            this.uiCaptureGroupBox.ResumeLayout(false);
            this.uiCaptureGroupBox.PerformLayout();
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
    }
}