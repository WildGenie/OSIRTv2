namespace OSIRT.UI
{
    partial class CannotOpenImagePanel
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.uiUnableToDisplayImgTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.uiCantOpenLinkLabel = new System.Windows.Forms.LinkLabel();
            this.uiScaledImagePanel = new System.Windows.Forms.Panel();
            this.uiPleaseWaitLabel = new System.Windows.Forms.Label();
            this.uiScaledImagePictureBox = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.uiUnableToDisplayImgTableLayout.SuspendLayout();
            this.uiScaledImagePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiScaledImagePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.uiUnableToDisplayImgTableLayout);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(969, 633);
            this.panel1.TabIndex = 0;
            // 
            // uiUnableToDisplayImgTableLayout
            // 
            this.uiUnableToDisplayImgTableLayout.ColumnCount = 1;
            this.uiUnableToDisplayImgTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.uiUnableToDisplayImgTableLayout.Controls.Add(this.uiCantOpenLinkLabel, 0, 1);
            this.uiUnableToDisplayImgTableLayout.Controls.Add(this.uiScaledImagePanel, 0, 0);
            this.uiUnableToDisplayImgTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiUnableToDisplayImgTableLayout.Location = new System.Drawing.Point(0, 0);
            this.uiUnableToDisplayImgTableLayout.Name = "uiUnableToDisplayImgTableLayout";
            this.uiUnableToDisplayImgTableLayout.RowCount = 2;
            this.uiUnableToDisplayImgTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87.13355F));
            this.uiUnableToDisplayImgTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.86645F));
            this.uiUnableToDisplayImgTableLayout.Size = new System.Drawing.Size(969, 633);
            this.uiUnableToDisplayImgTableLayout.TabIndex = 1;
            // 
            // uiCantOpenLinkLabel
            // 
            this.uiCantOpenLinkLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.uiCantOpenLinkLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiCantOpenLinkLabel.Location = new System.Drawing.Point(3, 551);
            this.uiCantOpenLinkLabel.Name = "uiCantOpenLinkLabel";
            this.uiCantOpenLinkLabel.Size = new System.Drawing.Size(963, 82);
            this.uiCantOpenLinkLabel.TabIndex = 0;
            this.uiCantOpenLinkLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiCantOpenLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.uiCantOpenLinkLabel_LinkClicked);
            // 
            // uiScaledImagePanel
            // 
            this.uiScaledImagePanel.BackColor = System.Drawing.Color.White;
            this.uiScaledImagePanel.Controls.Add(this.uiPleaseWaitLabel);
            this.uiScaledImagePanel.Controls.Add(this.uiScaledImagePictureBox);
            this.uiScaledImagePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiScaledImagePanel.Location = new System.Drawing.Point(3, 3);
            this.uiScaledImagePanel.Name = "uiScaledImagePanel";
            this.uiScaledImagePanel.Size = new System.Drawing.Size(963, 545);
            this.uiScaledImagePanel.TabIndex = 1;
            // 
            // uiPleaseWaitLabel
            // 
            this.uiPleaseWaitLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.uiPleaseWaitLabel.AutoSize = true;
            this.uiPleaseWaitLabel.Location = new System.Drawing.Point(383, 343);
            this.uiPleaseWaitLabel.Name = "uiPleaseWaitLabel";
            this.uiPleaseWaitLabel.Size = new System.Drawing.Size(172, 13);
            this.uiPleaseWaitLabel.TabIndex = 1;
            this.uiPleaseWaitLabel.Text = "Loading scaled image, please wait.";
            // 
            // uiScaledImagePictureBox
            // 
            this.uiScaledImagePictureBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.uiScaledImagePictureBox.Image = global::OSIRT.Properties.Resources.spinner;
            this.uiScaledImagePictureBox.Location = new System.Drawing.Point(403, 210);
            this.uiScaledImagePictureBox.Name = "uiScaledImagePictureBox";
            this.uiScaledImagePictureBox.Size = new System.Drawing.Size(131, 130);
            this.uiScaledImagePictureBox.TabIndex = 0;
            this.uiScaledImagePictureBox.TabStop = false;
            // 
            // CannotOpenImagePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "CannotOpenImagePanel";
            this.Size = new System.Drawing.Size(969, 633);
            this.Load += new System.EventHandler(this.CannotOpenImagePanel_Load);
            this.panel1.ResumeLayout(false);
            this.uiUnableToDisplayImgTableLayout.ResumeLayout(false);
            this.uiScaledImagePanel.ResumeLayout(false);
            this.uiScaledImagePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiScaledImagePictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.LinkLabel uiCantOpenLinkLabel;
        private System.Windows.Forms.TableLayoutPanel uiUnableToDisplayImgTableLayout;
        private System.Windows.Forms.Panel uiScaledImagePanel;
        private System.Windows.Forms.Label uiPleaseWaitLabel;
        private System.Windows.Forms.PictureBox uiScaledImagePictureBox;
    }
}
