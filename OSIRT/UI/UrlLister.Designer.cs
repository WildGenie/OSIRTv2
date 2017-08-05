namespace OSIRT.UI
{
    partial class UrlLister
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UrlLister));
            this.uiURLListTextBox = new System.Windows.Forms.TextBox();
            this.uiCopyUrlsButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.uiCloseButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiURLListTextBox
            // 
            this.uiURLListTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiURLListTextBox.Location = new System.Drawing.Point(6, 19);
            this.uiURLListTextBox.Multiline = true;
            this.uiURLListTextBox.Name = "uiURLListTextBox";
            this.uiURLListTextBox.ReadOnly = true;
            this.uiURLListTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.uiURLListTextBox.Size = new System.Drawing.Size(572, 179);
            this.uiURLListTextBox.TabIndex = 0;
            // 
            // uiCopyUrlsButton
            // 
            this.uiCopyUrlsButton.Location = new System.Drawing.Point(6, 204);
            this.uiCopyUrlsButton.Name = "uiCopyUrlsButton";
            this.uiCopyUrlsButton.Size = new System.Drawing.Size(117, 23);
            this.uiCopyUrlsButton.TabIndex = 1;
            this.uiCopyUrlsButton.Text = "Copy to Clipboard";
            this.uiCopyUrlsButton.UseVisualStyleBackColor = true;
            this.uiCopyUrlsButton.Click += new System.EventHandler(this.uiCopyUrlsButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.uiCopyUrlsButton);
            this.groupBox1.Controls.Add(this.uiURLListTextBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(584, 233);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Current Open URLs";
            // 
            // uiCloseButton
            // 
            this.uiCloseButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.uiCloseButton.Location = new System.Drawing.Point(521, 251);
            this.uiCloseButton.Name = "uiCloseButton";
            this.uiCloseButton.Size = new System.Drawing.Size(75, 23);
            this.uiCloseButton.TabIndex = 3;
            this.uiCloseButton.Text = "Close";
            this.uiCloseButton.UseVisualStyleBackColor = true;
            // 
            // UrlLister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 279);
            this.Controls.Add(this.uiCloseButton);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UrlLister";
            this.Text = "URL Lister";
            this.Load += new System.EventHandler(this.UrlLister_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox uiURLListTextBox;
        private System.Windows.Forms.Button uiCopyUrlsButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button uiCloseButton;
    }
}