namespace OSIRT.UI
{
    partial class UnhandledExceptionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UnhandledExceptionForm));
            this.uiExceptionMessageTextBox = new System.Windows.Forms.TextBox();
            this.uiErrorLabel = new System.Windows.Forms.Label();
            this.uiQuitButton = new System.Windows.Forms.Button();
            this.uiCopyToClipboardButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // uiExceptionMessageTextBox
            // 
            this.uiExceptionMessageTextBox.Location = new System.Drawing.Point(12, 129);
            this.uiExceptionMessageTextBox.Multiline = true;
            this.uiExceptionMessageTextBox.Name = "uiExceptionMessageTextBox";
            this.uiExceptionMessageTextBox.ReadOnly = true;
            this.uiExceptionMessageTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.uiExceptionMessageTextBox.Size = new System.Drawing.Size(562, 134);
            this.uiExceptionMessageTextBox.TabIndex = 0;
            // 
            // uiErrorLabel
            // 
            this.uiErrorLabel.AutoSize = true;
            this.uiErrorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiErrorLabel.Location = new System.Drawing.Point(9, 22);
            this.uiErrorLabel.Name = "uiErrorLabel";
            this.uiErrorLabel.Size = new System.Drawing.Size(568, 104);
            this.uiErrorLabel.TabIndex = 1;
            this.uiErrorLabel.Text = resources.GetString("uiErrorLabel.Text");
            // 
            // uiQuitButton
            // 
            this.uiQuitButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.uiQuitButton.Location = new System.Drawing.Point(498, 269);
            this.uiQuitButton.Name = "uiQuitButton";
            this.uiQuitButton.Size = new System.Drawing.Size(75, 23);
            this.uiQuitButton.TabIndex = 2;
            this.uiQuitButton.Text = "Close";
            this.uiQuitButton.UseVisualStyleBackColor = true;
            // 
            // uiCopyToClipboardButton
            // 
            this.uiCopyToClipboardButton.Location = new System.Drawing.Point(319, 269);
            this.uiCopyToClipboardButton.Name = "uiCopyToClipboardButton";
            this.uiCopyToClipboardButton.Size = new System.Drawing.Size(173, 23);
            this.uiCopyToClipboardButton.TabIndex = 3;
            this.uiCopyToClipboardButton.Text = "Put error message on clipboard";
            this.uiCopyToClipboardButton.UseVisualStyleBackColor = true;
            this.uiCopyToClipboardButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // UnhandledExceptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 304);
            this.Controls.Add(this.uiCopyToClipboardButton);
            this.Controls.Add(this.uiQuitButton);
            this.Controls.Add(this.uiErrorLabel);
            this.Controls.Add(this.uiExceptionMessageTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UnhandledExceptionForm";
            this.Text = "Fatal Error";
            this.Load += new System.EventHandler(this.UnhandledExceptionForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox uiExceptionMessageTextBox;
        private System.Windows.Forms.Label uiErrorLabel;
        private System.Windows.Forms.Button uiQuitButton;
        private System.Windows.Forms.Button uiCopyToClipboardButton;
    }
}