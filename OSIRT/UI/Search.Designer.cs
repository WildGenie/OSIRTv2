namespace OSIRT.UI
{
    partial class Search
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
            this.uiSearchTextBox = new System.Windows.Forms.TextBox();
            this.uiSearchButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // uiSearchTextBox
            // 
            this.uiSearchTextBox.Location = new System.Drawing.Point(12, 27);
            this.uiSearchTextBox.Name = "uiSearchTextBox";
            this.uiSearchTextBox.Size = new System.Drawing.Size(260, 20);
            this.uiSearchTextBox.TabIndex = 0;
            // 
            // uiSearchButton
            // 
            this.uiSearchButton.Location = new System.Drawing.Point(197, 56);
            this.uiSearchButton.Name = "uiSearchButton";
            this.uiSearchButton.Size = new System.Drawing.Size(75, 23);
            this.uiSearchButton.TabIndex = 1;
            this.uiSearchButton.Text = "Search";
            this.uiSearchButton.UseVisualStyleBackColor = true;
            this.uiSearchButton.Click += new System.EventHandler(this.uiSearchButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Enter search text";
            // 
            // Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 87);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.uiSearchButton);
            this.Controls.Add(this.uiSearchTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Search";
            this.Text = "Search";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox uiSearchTextBox;
        private System.Windows.Forms.Button uiSearchButton;
        private System.Windows.Forms.Label label1;
    }
}