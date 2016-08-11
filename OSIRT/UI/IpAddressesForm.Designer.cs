namespace OSIRT.UI
{
    partial class IpAddressesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IpAddressesForm));
            this.uiIpAddressesTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // uiIpAddressesTextBox
            // 
            this.uiIpAddressesTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiIpAddressesTextBox.Location = new System.Drawing.Point(0, 0);
            this.uiIpAddressesTextBox.Multiline = true;
            this.uiIpAddressesTextBox.Name = "uiIpAddressesTextBox";
            this.uiIpAddressesTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.uiIpAddressesTextBox.Size = new System.Drawing.Size(309, 274);
            this.uiIpAddressesTextBox.TabIndex = 0;
            // 
            // IpAddressesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 274);
            this.Controls.Add(this.uiIpAddressesTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "IpAddressesForm";
            this.Text = "IP Addresses";
            this.Load += new System.EventHandler(this.IpAddressesForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox uiIpAddressesTextBox;
    }
}