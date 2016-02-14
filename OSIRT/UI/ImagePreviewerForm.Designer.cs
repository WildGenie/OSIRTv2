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
            this.uiSplitContainer = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.uiSplitContainer)).BeginInit();
            this.uiSplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiSplitContainer
            // 
            this.uiSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.uiSplitContainer.Name = "uiSplitContainer";
            this.uiSplitContainer.Size = new System.Drawing.Size(937, 543);
            this.uiSplitContainer.SplitterDistance = 447;
            this.uiSplitContainer.TabIndex = 0;
            // 
            // ImagePreviewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 543);
            this.Controls.Add(this.uiSplitContainer);
            this.Name = "ImagePreviewerForm";
            this.Text = "ImagePreviewerForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ImagePreviewerForm_FormClosing);
            //this.Load += new System.EventHandler(this.ImagePreviewerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uiSplitContainer)).EndInit();
            this.uiSplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer uiSplitContainer;
    }
}