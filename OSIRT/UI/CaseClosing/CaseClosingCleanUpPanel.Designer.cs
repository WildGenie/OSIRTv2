namespace OSIRT.UI.CaseClosing
{
    partial class CaseClosingCleanUpPanel
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
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.uiInfoLabel = new System.Windows.Forms.Label();
            this.uiSpinnerPictureBox = new System.Windows.Forms.PictureBox();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiSpinnerPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox.Controls.Add(this.uiInfoLabel);
            this.groupBox.Controls.Add(this.uiSpinnerPictureBox);
            this.groupBox.Location = new System.Drawing.Point(200, 109);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(591, 321);
            this.groupBox.TabIndex = 0;
            this.groupBox.TabStop = false;
            // 
            // uiInfoLabel
            // 
            this.uiInfoLabel.AutoSize = true;
            this.uiInfoLabel.Location = new System.Drawing.Point(263, 152);
            this.uiInfoLabel.Name = "uiInfoLabel";
            this.uiInfoLabel.Size = new System.Drawing.Size(35, 13);
            this.uiInfoLabel.TabIndex = 1;
            this.uiInfoLabel.Text = "label1";
            this.uiInfoLabel.SizeChanged += new System.EventHandler(this.uiInfoLabel_SizeChanged);
            // 
            // uiSpinnerPictureBox
            // 
            this.uiSpinnerPictureBox.Image = global::OSIRT.Properties.Resources.squares;
            this.uiSpinnerPictureBox.Location = new System.Drawing.Point(209, 19);
            this.uiSpinnerPictureBox.Name = "uiSpinnerPictureBox";
            this.uiSpinnerPictureBox.Size = new System.Drawing.Size(150, 150);
            this.uiSpinnerPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.uiSpinnerPictureBox.TabIndex = 0;
            this.uiSpinnerPictureBox.TabStop = false;
            // 
            // CaseClosingCleanUpPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox);
            this.Name = "CaseClosingCleanUpPanel";
            this.Size = new System.Drawing.Size(979, 641);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiSpinnerPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.PictureBox uiSpinnerPictureBox;
        private System.Windows.Forms.Label uiInfoLabel;
    }
}
