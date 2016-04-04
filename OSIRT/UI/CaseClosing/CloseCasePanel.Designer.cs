namespace OSIRT.UI
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = global::OSIRT.Properties.Resources.lock_sm;
            this.pictureBox1.Location = new System.Drawing.Point(405, 182);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(118, 141);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // uiPasswordTextBox
            // 
            this.uiPasswordTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.uiPasswordTextBox.Location = new System.Drawing.Point(366, 351);
            this.uiPasswordTextBox.Name = "uiPasswordTextBox";
            this.uiPasswordTextBox.Size = new System.Drawing.Size(201, 20);
            this.uiPasswordTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(440, 335);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Password";
            // 
            // uiHelpLabel
            // 
            this.uiHelpLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.uiHelpLabel.AutoSize = true;
            this.uiHelpLabel.Location = new System.Drawing.Point(351, 572);
            this.uiHelpLabel.Name = "uiHelpLabel";
            this.uiHelpLabel.Size = new System.Drawing.Size(232, 13);
            this.uiHelpLabel.TabIndex = 3;
            this.uiHelpLabel.Text = "To secure the case, please enter the password.";
            // 
            // uiOKButton
            // 
            this.uiOKButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.uiOKButton.Location = new System.Drawing.Point(431, 377);
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
            this.uiInvalidPasswordLabel.Location = new System.Drawing.Point(398, 413);
            this.uiInvalidPasswordLabel.Name = "uiInvalidPasswordLabel";
            this.uiInvalidPasswordLabel.Size = new System.Drawing.Size(136, 13);
            this.uiInvalidPasswordLabel.TabIndex = 5;
            this.uiInvalidPasswordLabel.Text = "Incorrect password entered";
            this.uiInvalidPasswordLabel.Visible = false;
            // 
            // CloseCasePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uiInvalidPasswordLabel);
            this.Controls.Add(this.uiOKButton);
            this.Controls.Add(this.uiHelpLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.uiPasswordTextBox);
            this.Controls.Add(this.pictureBox1);
            this.Name = "CloseCasePanel";
            this.Size = new System.Drawing.Size(911, 664);
            this.Load += new System.EventHandler(this.CloseCasePanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox uiPasswordTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label uiHelpLabel;
        private System.Windows.Forms.Button uiOKButton;
        private System.Windows.Forms.Label uiInvalidPasswordLabel;
    }
}
