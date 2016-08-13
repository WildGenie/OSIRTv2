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
            this.uiProfileIdLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // uiProfileIdLabel
            // 
            this.uiProfileIdLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiProfileIdLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiProfileIdLabel.ForeColor = System.Drawing.Color.SteelBlue;
            this.uiProfileIdLabel.Location = new System.Drawing.Point(0, 0);
            this.uiProfileIdLabel.Name = "uiProfileIdLabel";
            this.uiProfileIdLabel.Size = new System.Drawing.Size(265, 25);
            this.uiProfileIdLabel.TabIndex = 0;
            this.uiProfileIdLabel.Text = "label1";
            this.uiProfileIdLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FacebookDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(265, 25);
            this.Controls.Add(this.uiProfileIdLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FacebookDetailsForm";
            this.Text = "Facebook Profile ID";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FacebookDetailsForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label uiProfileIdLabel;
    }
}