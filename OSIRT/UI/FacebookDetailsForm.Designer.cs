namespace OSIRT.UI
{
    partial class FacebookDetailsForm
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
            this.uiFacebookIdTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // uiFacebookIdTextBox
            // 
            this.uiFacebookIdTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiFacebookIdTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiFacebookIdTextBox.Location = new System.Drawing.Point(0, 0);
            this.uiFacebookIdTextBox.Multiline = true;
            this.uiFacebookIdTextBox.Name = "uiFacebookIdTextBox";
            this.uiFacebookIdTextBox.ReadOnly = true;
            this.uiFacebookIdTextBox.Size = new System.Drawing.Size(265, 25);
            this.uiFacebookIdTextBox.TabIndex = 0;
            this.uiFacebookIdTextBox.Text = "Not found...";
            // 
            // FacebookDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(265, 25);
            this.Controls.Add(this.uiFacebookIdTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FacebookDetailsForm";
            this.Text = "Facebook Profile ID";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FacebookDetailsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox uiFacebookIdTextBox;
    }
}