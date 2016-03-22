namespace OSIRT.UI
{
    partial class NoRecordsToShowPanel
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
            this.uiNoRecordsPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.uiNoRecordsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiNoRecordsPanel
            // 
            this.uiNoRecordsPanel.Controls.Add(this.label1);
            this.uiNoRecordsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiNoRecordsPanel.Location = new System.Drawing.Point(0, 0);
            this.uiNoRecordsPanel.Name = "uiNoRecordsPanel";
            this.uiNoRecordsPanel.Size = new System.Drawing.Size(852, 606);
            this.uiNoRecordsPanel.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(852, 606);
            this.label1.TabIndex = 0;
            this.label1.Text = "No records to show. Please select another tab.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NoRecordsToShowPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uiNoRecordsPanel);
            this.Name = "NoRecordsToShowPanel";
            this.Size = new System.Drawing.Size(852, 606);
            this.uiNoRecordsPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel uiNoRecordsPanel;
        private System.Windows.Forms.Label label1;
    }
}
