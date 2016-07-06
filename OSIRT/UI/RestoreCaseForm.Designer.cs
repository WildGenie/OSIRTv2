namespace OSIRT.UI
{
    partial class RestoreCaseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RestoreCaseForm));
            this.uiRestoreSplitContainer = new System.Windows.Forms.SplitContainer();
            this.uiRecoverButton = new System.Windows.Forms.Button();
            this.uiRecoveringProgressBar = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.uiBrowseButton = new System.Windows.Forms.Button();
            this.uiPathTextBox = new System.Windows.Forms.TextBox();
            this.uiInfoRichTextBox = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.uiRestoreSplitContainer)).BeginInit();
            this.uiRestoreSplitContainer.Panel1.SuspendLayout();
            this.uiRestoreSplitContainer.Panel2.SuspendLayout();
            this.uiRestoreSplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiRestoreSplitContainer
            // 
            this.uiRestoreSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiRestoreSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.uiRestoreSplitContainer.Name = "uiRestoreSplitContainer";
            // 
            // uiRestoreSplitContainer.Panel1
            // 
            this.uiRestoreSplitContainer.Panel1.Controls.Add(this.uiRecoverButton);
            this.uiRestoreSplitContainer.Panel1.Controls.Add(this.uiRecoveringProgressBar);
            this.uiRestoreSplitContainer.Panel1.Controls.Add(this.label1);
            this.uiRestoreSplitContainer.Panel1.Controls.Add(this.uiBrowseButton);
            this.uiRestoreSplitContainer.Panel1.Controls.Add(this.uiPathTextBox);
            // 
            // uiRestoreSplitContainer.Panel2
            // 
            this.uiRestoreSplitContainer.Panel2.Controls.Add(this.uiInfoRichTextBox);
            this.uiRestoreSplitContainer.Size = new System.Drawing.Size(624, 187);
            this.uiRestoreSplitContainer.SplitterDistance = 368;
            this.uiRestoreSplitContainer.TabIndex = 0;
            // 
            // uiRecoverButton
            // 
            this.uiRecoverButton.Location = new System.Drawing.Point(12, 56);
            this.uiRecoverButton.Name = "uiRecoverButton";
            this.uiRecoverButton.Size = new System.Drawing.Size(340, 58);
            this.uiRecoverButton.TabIndex = 4;
            this.uiRecoverButton.Text = "Recover";
            this.uiRecoverButton.UseVisualStyleBackColor = true;
            this.uiRecoverButton.Click += new System.EventHandler(this.uiRecoverButton_Click);
            // 
            // uiRecoveringProgressBar
            // 
            this.uiRecoveringProgressBar.Location = new System.Drawing.Point(12, 120);
            this.uiRecoveringProgressBar.MarqueeAnimationSpeed = 10;
            this.uiRecoveringProgressBar.Maximum = 1000;
            this.uiRecoveringProgressBar.Name = "uiRecoveringProgressBar";
            this.uiRecoveringProgressBar.Size = new System.Drawing.Size(340, 23);
            this.uiRecoveringProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.uiRecoveringProgressBar.TabIndex = 3;
            this.uiRecoveringProgressBar.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Extracted case location:";
            // 
            // uiBrowseButton
            // 
            this.uiBrowseButton.Location = new System.Drawing.Point(277, 30);
            this.uiBrowseButton.Name = "uiBrowseButton";
            this.uiBrowseButton.Size = new System.Drawing.Size(75, 19);
            this.uiBrowseButton.TabIndex = 1;
            this.uiBrowseButton.Text = "Browse...";
            this.uiBrowseButton.UseVisualStyleBackColor = true;
            this.uiBrowseButton.Click += new System.EventHandler(this.uiBrowseButton_Click);
            // 
            // uiPathTextBox
            // 
            this.uiPathTextBox.Location = new System.Drawing.Point(12, 30);
            this.uiPathTextBox.Name = "uiPathTextBox";
            this.uiPathTextBox.ReadOnly = true;
            this.uiPathTextBox.Size = new System.Drawing.Size(258, 20);
            this.uiPathTextBox.TabIndex = 0;
            // 
            // uiInfoRichTextBox
            // 
            this.uiInfoRichTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.uiInfoRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiInfoRichTextBox.Location = new System.Drawing.Point(0, 0);
            this.uiInfoRichTextBox.Name = "uiInfoRichTextBox";
            this.uiInfoRichTextBox.ReadOnly = true;
            this.uiInfoRichTextBox.Size = new System.Drawing.Size(252, 187);
            this.uiInfoRichTextBox.TabIndex = 0;
            this.uiInfoRichTextBox.Text = resources.GetString("uiInfoRichTextBox.Text");
            // 
            // RestoreCaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 187);
            this.Controls.Add(this.uiRestoreSplitContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RestoreCaseForm";
            this.Text = "Restore Case";
            this.uiRestoreSplitContainer.Panel1.ResumeLayout(false);
            this.uiRestoreSplitContainer.Panel1.PerformLayout();
            this.uiRestoreSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiRestoreSplitContainer)).EndInit();
            this.uiRestoreSplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer uiRestoreSplitContainer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button uiBrowseButton;
        private System.Windows.Forms.TextBox uiPathTextBox;
        private System.Windows.Forms.RichTextBox uiInfoRichTextBox;
        private System.Windows.Forms.Button uiRecoverButton;
        private System.Windows.Forms.ProgressBar uiRecoveringProgressBar;
    }
}