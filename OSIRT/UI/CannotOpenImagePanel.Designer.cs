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
            this.uiCantOpenLinkLabel = new System.Windows.Forms.LinkLabel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.uiCantOpenLinkLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(513, 408);
            this.panel1.TabIndex = 0;
            // 
            // uiCantOpenLinkLabel
            // 
            this.uiCantOpenLinkLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.uiCantOpenLinkLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiCantOpenLinkLabel.Location = new System.Drawing.Point(0, 0);
            this.uiCantOpenLinkLabel.Name = "uiCantOpenLinkLabel";
            this.uiCantOpenLinkLabel.Size = new System.Drawing.Size(513, 408);
            this.uiCantOpenLinkLabel.TabIndex = 0;
            this.uiCantOpenLinkLabel.TabStop = true;
            this.uiCantOpenLinkLabel.Text = "Unable to display this image due to its size. \r\nClick here to view the image in t" +
    "he system\'s default image viewing application.";
            this.uiCantOpenLinkLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CannotOpenImagePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "CannotOpenImagePanel";
            this.Size = new System.Drawing.Size(513, 408);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.LinkLabel uiCantOpenLinkLabel;
    }
}
