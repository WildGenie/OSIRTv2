namespace OSIRT.UI
{
    partial class SearchPanel
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
            this.uiSearchCriteriaGroupBox = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.uiSearchButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.uiSearchCriteriaGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiSearchCriteriaGroupBox
            // 
            this.uiSearchCriteriaGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiSearchCriteriaGroupBox.Controls.Add(this.label1);
            this.uiSearchCriteriaGroupBox.Controls.Add(this.uiSearchButton);
            this.uiSearchCriteriaGroupBox.Controls.Add(this.textBox1);
            this.uiSearchCriteriaGroupBox.Location = new System.Drawing.Point(13, 12);
            this.uiSearchCriteriaGroupBox.Name = "uiSearchCriteriaGroupBox";
            this.uiSearchCriteriaGroupBox.Size = new System.Drawing.Size(280, 190);
            this.uiSearchCriteriaGroupBox.TabIndex = 1;
            this.uiSearchCriteriaGroupBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Search Text:";
            // 
            // uiSearchButton
            // 
            this.uiSearchButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.uiSearchButton.Location = new System.Drawing.Point(97, 161);
            this.uiSearchButton.Name = "uiSearchButton";
            this.uiSearchButton.Size = new System.Drawing.Size(75, 23);
            this.uiSearchButton.TabIndex = 1;
            this.uiSearchButton.Text = "Search";
            this.uiSearchButton.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(6, 38);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(268, 20);
            this.textBox1.TabIndex = 0;
            // 
            // SearchPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.Controls.Add(this.uiSearchCriteriaGroupBox);
            this.Name = "SearchPanel";
            this.Size = new System.Drawing.Size(308, 700);
            this.Load += new System.EventHandler(this.SearchPanel_Load);
            this.uiSearchCriteriaGroupBox.ResumeLayout(false);
            this.uiSearchCriteriaGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox uiSearchCriteriaGroupBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button uiSearchButton;
        private System.Windows.Forms.TextBox textBox1;
    }
}
