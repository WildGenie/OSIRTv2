namespace OSIRT.UI.CaseClosing
{
    partial class CloseCasePanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.uiPasswordTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.uiHelpLabel = new System.Windows.Forms.Label();
            this.uiOKButton = new System.Windows.Forms.Button();
            this.uiInvalidPasswordLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.uiPasswordHelpLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = global::OSIRT.Properties.Resources.lock_sm;
            this.pictureBox1.Location = new System.Drawing.Point(258, 43);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(118, 141);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // uiPasswordTextBox
            // 
            this.uiPasswordTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.uiPasswordTextBox.Location = new System.Drawing.Point(219, 212);
            this.uiPasswordTextBox.Name = "uiPasswordTextBox";
            this.uiPasswordTextBox.Size = new System.Drawing.Size(201, 20);
            this.uiPasswordTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(293, 196);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Password";
            // 
            // uiHelpLabel
            // 
            this.uiHelpLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.uiHelpLabel.AutoSize = true;
            this.uiHelpLabel.Location = new System.Drawing.Point(206, 312);
            this.uiHelpLabel.Name = "uiHelpLabel";
            this.uiHelpLabel.Size = new System.Drawing.Size(232, 13);
            this.uiHelpLabel.TabIndex = 3;
            this.uiHelpLabel.Text = "To secure the case, please enter the password.";
            // 
            // uiOKButton
            // 
            this.uiOKButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.uiOKButton.Location = new System.Drawing.Point(281, 238);
            this.uiOKButton.Name = "uiOKButton";
            this.uiOKButton.Size = new System.Drawing.Size(75, 23);
            this.uiOKButton.TabIndex = 4;
            this.uiOKButton.Text = "OK";
            this.uiOKButton.UseVisualStyleBackColor = true;
            this.uiOKButton.Click += new System.EventHandler(this.uiOKButton_Click);
            // 
            // uiInvalidPasswordLabel
            // 
            this.uiInvalidPasswordLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.uiInvalidPasswordLabel.AutoSize = true;
            this.uiInvalidPasswordLabel.ForeColor = System.Drawing.Color.Red;
            this.uiInvalidPasswordLabel.Location = new System.Drawing.Point(251, 274);
            this.uiInvalidPasswordLabel.Name = "uiInvalidPasswordLabel";
            this.uiInvalidPasswordLabel.Size = new System.Drawing.Size(136, 13);
            this.uiInvalidPasswordLabel.TabIndex = 5;
            this.uiInvalidPasswordLabel.Text = "Incorrect password entered";
            this.uiInvalidPasswordLabel.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.uiPasswordHelpLabel);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.uiHelpLabel);
            this.groupBox1.Controls.Add(this.uiInvalidPasswordLabel);
            this.groupBox1.Controls.Add(this.uiPasswordTextBox);
            this.groupBox1.Controls.Add(this.uiOKButton);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(133, 71);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(654, 341);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // uiPasswordHelpLabel
            // 
            this.uiPasswordHelpLabel.AutoSize = true;
            this.uiPasswordHelpLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiPasswordHelpLabel.Location = new System.Drawing.Point(424, 215);
            this.uiPasswordHelpLabel.Name = "uiPasswordHelpLabel";
            this.uiPasswordHelpLabel.Size = new System.Drawing.Size(19, 13);
            this.uiPasswordHelpLabel.TabIndex = 6;
            this.uiPasswordHelpLabel.Text = "[?]";
            this.uiPasswordHelpLabel.Click += new System.EventHandler(this.uiPasswordHelpLabel_Click);
            // 
            // CloseCasePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "CloseCasePanel";
            this.Size = new System.Drawing.Size(911, 664);
            this.Load += new System.EventHandler(this.CloseCasePanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox uiPasswordTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label uiHelpLabel;
        private System.Windows.Forms.Button uiOKButton;
        private System.Windows.Forms.Label uiInvalidPasswordLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label uiPasswordHelpLabel;
    }
}
