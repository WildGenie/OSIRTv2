namespace OSIRT.UI.AuditLog
{
    partial class TabbedAuditLogControl
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
            this.uiAuditLogTabControl = new System.Windows.Forms.TabControl();
            this.SuspendLayout();
            // 
            // uiAuditLogTabControl
            // 
            this.uiAuditLogTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiAuditLogTabControl.Location = new System.Drawing.Point(0, 0);
            this.uiAuditLogTabControl.Name = "uiAuditLogTabControl";
            this.uiAuditLogTabControl.SelectedIndex = 0;
            this.uiAuditLogTabControl.Size = new System.Drawing.Size(800, 600);
            this.uiAuditLogTabControl.TabIndex = 0;
            this.uiAuditLogTabControl.SelectedIndexChanged += new System.EventHandler(this.uiAuditLogTabControl_SelectedIndexChanged);
            // 
            // TabbedAuditLogControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            //this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.uiAuditLogTabControl);
            this.Name = "TabbedAuditLogControl";
            this.Size = new System.Drawing.Size(800, 600);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl uiAuditLogTabControl;

    }
}
