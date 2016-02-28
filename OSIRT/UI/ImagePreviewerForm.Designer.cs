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
            this.uiCancelButton = new System.Windows.Forms.Button();
            this.uiOKButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.spellBox1 = new OSIRT.UI.SpellBox();
            this.hostedComponent1 = new System.Windows.Controls.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.uiURLTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.uiDateAndTimeTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.uiImageNameComboBox = new System.Windows.Forms.ComboBox();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.uiCalcHashLinkLabel = new System.Windows.Forms.LinkLabel();
            this.uiHashTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.uiSplitContainer)).BeginInit();
            this.uiSplitContainer.Panel1.SuspendLayout();
            this.uiSplitContainer.SuspendLayout();
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
            this.uiSplitContainer.Panel1.Controls.Add(this.uiHashTextBox);
            this.uiSplitContainer.Panel1.Controls.Add(this.uiCalcHashLinkLabel);
            this.uiSplitContainer.Panel1.Controls.Add(this.uiCancelButton);
            this.uiSplitContainer.Panel1.Controls.Add(this.uiOKButton);
            this.uiSplitContainer.Panel1.Controls.Add(this.button1);
            this.uiSplitContainer.Panel1.Controls.Add(this.spellBox1);
            this.uiSplitContainer.Panel1.Controls.Add(this.label5);
            this.uiSplitContainer.Panel1.Controls.Add(this.label3);
            this.uiSplitContainer.Panel1.Controls.Add(this.uiURLTextBox);
            this.uiSplitContainer.Panel1.Controls.Add(this.label2);
            this.uiSplitContainer.Panel1.Controls.Add(this.uiDateAndTimeTextBox);
            this.uiSplitContainer.Panel1.Controls.Add(this.label1);
            this.uiSplitContainer.Panel1.Controls.Add(this.uiImageNameComboBox);
            this.uiSplitContainer.Size = new System.Drawing.Size(1067, 589);
            this.uiSplitContainer.SplitterDistance = 370;
            this.uiSplitContainer.TabIndex = 0;
            // 
            // uiCancelButton
            // 
            this.uiCancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.uiCancelButton.Location = new System.Drawing.Point(176, 440);
            this.uiCancelButton.Name = "uiCancelButton";
            this.uiCancelButton.Size = new System.Drawing.Size(79, 23);
            this.uiCancelButton.TabIndex = 12;
            this.uiCancelButton.Text = "Cancel";
            this.ToolTip.SetToolTip(this.uiCancelButton, "Do not log this image and close the Image Previewer");
            this.uiCancelButton.UseVisualStyleBackColor = true;
            // 
            // uiOKButton
            // 
            this.uiOKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiOKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.uiOKButton.Location = new System.Drawing.Point(260, 440);
            this.uiOKButton.Name = "uiOKButton";
            this.uiOKButton.Size = new System.Drawing.Size(79, 23);
            this.uiOKButton.TabIndex = 11;
            this.uiOKButton.Text = "OK";
            this.ToolTip.SetToolTip(this.uiOKButton, "Log this image");
            this.uiOKButton.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(49, 541);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // spellBox1
            // 
            this.spellBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.spellBox1.Location = new System.Drawing.Point(13, 247);
            this.spellBox1.Multiline = true;
            this.spellBox1.Name = "spellBox1";
            this.spellBox1.Size = new System.Drawing.Size(326, 187);
            this.spellBox1.TabIndex = 9;
            this.spellBox1.WordWrap = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 230);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Notes";
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
            this.uiURLTextBox.Size = new System.Drawing.Size(324, 20);
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
            this.uiDateAndTimeTextBox.Size = new System.Drawing.Size(324, 20);
            this.uiDateAndTimeTextBox.TabIndex = 2;
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
            this.uiImageNameComboBox.FormattingEnabled = true;
            this.uiImageNameComboBox.Location = new System.Drawing.Point(15, 25);
            this.uiImageNameComboBox.Name = "uiImageNameComboBox";
            this.uiImageNameComboBox.Size = new System.Drawing.Size(324, 21);
            this.uiImageNameComboBox.TabIndex = 0;
            // 
            // uiCalcHashLinkLabel
            // 
            this.uiCalcHashLinkLabel.AutoSize = true;
            this.uiCalcHashLinkLabel.Location = new System.Drawing.Point(12, 166);
            this.uiCalcHashLinkLabel.Name = "uiCalcHashLinkLabel";
            this.uiCalcHashLinkLabel.Size = new System.Drawing.Size(79, 13);
            this.uiCalcHashLinkLabel.TabIndex = 13;
            this.uiCalcHashLinkLabel.TabStop = true;
            this.uiCalcHashLinkLabel.Text = "Calculate Hash";
            this.uiCalcHashLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.uiCalcHashLinkLabel_LinkClicked);
            // 
            // uiHashTextBox
            // 
            this.uiHashTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiHashTextBox.Location = new System.Drawing.Point(15, 182);
            this.uiHashTextBox.Name = "uiHashTextBox";
            this.uiHashTextBox.ReadOnly = true;
            this.uiHashTextBox.Size = new System.Drawing.Size(324, 20);
            this.uiHashTextBox.TabIndex = 14;
            // 
            // ImagePreviewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 589);
            this.Controls.Add(this.uiSplitContainer);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "ImagePreviewerForm";
            this.Text = "Image Previewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ImagePreviewerForm_FormClosing);
            this.Load += new System.EventHandler(this.ImagePreviewerForm_Load);
            this.uiSplitContainer.Panel1.ResumeLayout(false);
            this.uiSplitContainer.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiSplitContainer)).EndInit();
            this.uiSplitContainer.ResumeLayout(false);
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
        private SpellBox spellBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button uiCancelButton;
        private System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.Button uiOKButton;
        private System.Windows.Controls.TextBox hostedComponent2;
        private System.Windows.Forms.LinkLabel uiCalcHashLinkLabel;
        private System.Windows.Controls.TextBox hostedComponent1;
        private System.Windows.Forms.TextBox uiHashTextBox;
    }
}