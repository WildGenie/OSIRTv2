namespace OSIRT.UI
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
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.uiAuditLogTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiAuditLogTabControl
            // 
            this.uiAuditLogTabControl.Controls.Add(this.tabPage1);
            this.uiAuditLogTabControl.Controls.Add(this.tabPage2);
            this.uiAuditLogTabControl.Controls.Add(this.tabPage3);
            this.uiAuditLogTabControl.Controls.Add(this.tabPage4);
            this.uiAuditLogTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiAuditLogTabControl.Location = new System.Drawing.Point(0, 0);
            this.uiAuditLogTabControl.Name = "uiAuditLogTabControl";
            this.uiAuditLogTabControl.SelectedIndex = 0;
            this.uiAuditLogTabControl.Size = new System.Drawing.Size(800, 600);
            this.uiAuditLogTabControl.TabIndex = 0;
            this.uiAuditLogTabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(792, 574);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Websites Loaded ";
            this.tabPage1.UseVisualStyleBackColor = true;
         
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(792, 574);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Website Actions";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(792, 574);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "OSIRT Actions";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(792, 574);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Attachments";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // TabbedAuditLogControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uiAuditLogTabControl);
            this.Name = "TabbedAuditLogControl";
            this.Size = new System.Drawing.Size(800, 600);
            this.uiAuditLogTabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl uiAuditLogTabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;

    }
}
