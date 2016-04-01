namespace OSIRT.UI.AuditLog
{
    partial class TempSearchPanel
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
            this.uiSearchingPictureBox = new System.Windows.Forms.PictureBox();
            this.uiSearchHelpLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.uiSearchingPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // uiSearchingPictureBox
            // 
            this.uiSearchingPictureBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.uiSearchingPictureBox.Image = global::OSIRT.Properties.Resources.magnify;
            this.uiSearchingPictureBox.InitialImage = global::OSIRT.Properties.Resources.magnify;
            this.uiSearchingPictureBox.Location = new System.Drawing.Point(367, 276);
            this.uiSearchingPictureBox.Name = "uiSearchingPictureBox";
            this.uiSearchingPictureBox.Size = new System.Drawing.Size(145, 137);
            this.uiSearchingPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.uiSearchingPictureBox.TabIndex = 0;
            this.uiSearchingPictureBox.TabStop = false;
            // 
            // uiSearchHelpLabel
            // 
            this.uiSearchHelpLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.uiSearchHelpLabel.AutoSize = true;
            this.uiSearchHelpLabel.Location = new System.Drawing.Point(326, 416);
            this.uiSearchHelpLabel.Name = "uiSearchHelpLabel";
            this.uiSearchHelpLabel.Size = new System.Drawing.Size(258, 13);
            this.uiSearchHelpLabel.TabIndex = 1;
            this.uiSearchHelpLabel.Text = "Enter your search criteria on the left and press search";
            // 
            // TempSearchPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.uiSearchHelpLabel);
            this.Controls.Add(this.uiSearchingPictureBox);
            this.Name = "TempSearchPanel";
            this.Size = new System.Drawing.Size(884, 739);
            this.Load += new System.EventHandler(this.TempSearchPanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uiSearchingPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox uiSearchingPictureBox;
        private System.Windows.Forms.Label uiSearchHelpLabel;
    }
}
