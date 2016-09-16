namespace OSIRT.Browser.SearchFinder
{
    partial class Find
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Find));
            this.uiFindTextTextBox = new System.Windows.Forms.TextBox();
            this.uiNextButton = new System.Windows.Forms.Button();
            this.uiFindPreviousButton = new System.Windows.Forms.Button();
            this.label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // uiFindTextTextBox
            // 
            this.uiFindTextTextBox.Location = new System.Drawing.Point(12, 31);
            this.uiFindTextTextBox.Name = "uiFindTextTextBox";
            this.uiFindTextTextBox.Size = new System.Drawing.Size(275, 20);
            this.uiFindTextTextBox.TabIndex = 0;
            // 
            // uiNextButton
            // 
            this.uiNextButton.Location = new System.Drawing.Point(12, 57);
            this.uiNextButton.Name = "uiNextButton";
            this.uiNextButton.Size = new System.Drawing.Size(75, 23);
            this.uiNextButton.TabIndex = 1;
            this.uiNextButton.Text = "Find Next";
            this.uiNextButton.UseVisualStyleBackColor = true;
            this.uiNextButton.Click += new System.EventHandler(this.uiNextButton_Click);
            // 
            // uiFindPreviousButton
            // 
            this.uiFindPreviousButton.Location = new System.Drawing.Point(207, 57);
            this.uiFindPreviousButton.Name = "uiFindPreviousButton";
            this.uiFindPreviousButton.Size = new System.Drawing.Size(75, 23);
            this.uiFindPreviousButton.TabIndex = 3;
            this.uiFindPreviousButton.Text = "Find Prev";
            this.uiFindPreviousButton.UseVisualStyleBackColor = true;
            this.uiFindPreviousButton.Click += new System.EventHandler(this.uiFindPreviousButton_Click);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(12, 9);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(118, 13);
            this.label.TabIndex = 4;
            this.label.Text = "Enter text to find below:";
            // 
            // Find
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 91);
            this.Controls.Add(this.label);
            this.Controls.Add(this.uiFindPreviousButton);
            this.Controls.Add(this.uiNextButton);
            this.Controls.Add(this.uiFindTextTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Find";
            this.Text = "Find";
            this.Load += new System.EventHandler(this.Find_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox uiFindTextTextBox;
        private System.Windows.Forms.Button uiNextButton;
        private System.Windows.Forms.Button uiFindPreviousButton;
        private System.Windows.Forms.Label label;
    }
}