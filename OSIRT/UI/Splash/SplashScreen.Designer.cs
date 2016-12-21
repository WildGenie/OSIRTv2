namespace OSIRT.UI.Splash
{
    partial class SplashScreen
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
            this.uiSplashLoadingProgressBar = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.uiProgressLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // uiSplashLoadingProgressBar
            // 
            this.uiSplashLoadingProgressBar.Location = new System.Drawing.Point(8, 235);
            this.uiSplashLoadingProgressBar.MarqueeAnimationSpeed = 10;
            this.uiSplashLoadingProgressBar.Maximum = 1000;
            this.uiSplashLoadingProgressBar.Name = "uiSplashLoadingProgressBar";
            this.uiSplashLoadingProgressBar.Size = new System.Drawing.Size(790, 23);
            this.uiSplashLoadingProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.uiSplashLoadingProgressBar.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(641, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Joseph Williams";
            // 
            // uiProgressLabel
            // 
            this.uiProgressLabel.AutoSize = true;
            this.uiProgressLabel.BackColor = System.Drawing.Color.Transparent;
            this.uiProgressLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.uiProgressLabel.Location = new System.Drawing.Point(538, 219);
            this.uiProgressLabel.Name = "uiProgressLabel";
            this.uiProgressLabel.Size = new System.Drawing.Size(224, 13);
            this.uiProgressLabel.TabIndex = 2;
            this.uiProgressLabel.Text = "Checking previous case closed successfully...";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "v 3.1.0 (Cef)";
            // 
            // SplashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::OSIRT.Properties.Resources.splash_screen_small;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(803, 261);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.uiProgressLabel);
            this.Controls.Add(this.uiSplashLoadingProgressBar);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SplashScreen";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SplashScreen";
            this.Load += new System.EventHandler(this.SplashScreen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar uiSplashLoadingProgressBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label uiProgressLabel;
        private System.Windows.Forms.Label label2;
    }
}