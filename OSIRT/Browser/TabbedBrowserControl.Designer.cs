namespace OSIRT.Browser
{
    partial class TabbedBrowserControl
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
            this.uiBrowserTabControl = new System.Windows.Forms.TabControl();
            this.SuspendLayout();
            // 
            // uiBrowserTabControl
            // 
            this.uiBrowserTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiBrowserTabControl.Location = new System.Drawing.Point(0, 0);
            this.uiBrowserTabControl.Name = "uiBrowserTabControl";
            this.uiBrowserTabControl.SelectedIndex = 0;
            this.uiBrowserTabControl.Size = new System.Drawing.Size(800, 600);
            this.uiBrowserTabControl.TabIndex = 0;
            this.uiBrowserTabControl.SelectedIndexChanged += new System.EventHandler(this.uiBrowserTabControl_SelectedIndexChanged);
            // 
            // TabbedBrowserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uiBrowserTabControl);
            this.Name = "TabbedBrowserControl";
            this.Size = new System.Drawing.Size(800, 600);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl uiBrowserTabControl;
    }
}
