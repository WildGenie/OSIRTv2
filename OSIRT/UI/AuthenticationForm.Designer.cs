namespace OSIRT.UI
{
    partial class AuthenticationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuthenticationForm));
            this.label1 = new System.Windows.Forms.Label();
            this.uiUserNameTextBox = new System.Windows.Forms.TextBox();
            this.uiPasswordTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.uiOKButton = new System.Windows.Forms.Button();
            this.uiCancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(367, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "The server has requires a username and password due to restricted access. ";
            // 
            // uiUserNameTextBox
            // 
            this.uiUserNameTextBox.Location = new System.Drawing.Point(86, 45);
            this.uiUserNameTextBox.Name = "uiUserNameTextBox";
            this.uiUserNameTextBox.Size = new System.Drawing.Size(528, 20);
            this.uiUserNameTextBox.TabIndex = 1;
            // 
            // uiPasswordTextBox
            // 
            this.uiPasswordTextBox.Location = new System.Drawing.Point(86, 71);
            this.uiPasswordTextBox.Name = "uiPasswordTextBox";
            this.uiPasswordTextBox.PasswordChar = '*';
            this.uiPasswordTextBox.Size = new System.Drawing.Size(528, 20);
            this.uiPasswordTextBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "User Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Password:";
            // 
            // uiOKButton
            // 
            this.uiOKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.uiOKButton.Location = new System.Drawing.Point(340, 97);
            this.uiOKButton.Name = "uiOKButton";
            this.uiOKButton.Size = new System.Drawing.Size(75, 23);
            this.uiOKButton.TabIndex = 5;
            this.uiOKButton.Text = "OK";
            this.uiOKButton.UseVisualStyleBackColor = true;
            this.uiOKButton.Click += new System.EventHandler(this.uiOKButton_Click);
            // 
            // uiCancelButton
            // 
            this.uiCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.uiCancelButton.Location = new System.Drawing.Point(259, 97);
            this.uiCancelButton.Name = "uiCancelButton";
            this.uiCancelButton.Size = new System.Drawing.Size(75, 23);
            this.uiCancelButton.TabIndex = 6;
            this.uiCancelButton.Text = "Cancel";
            this.uiCancelButton.UseVisualStyleBackColor = true;
            // 
            // AuthenticationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 129);
            this.Controls.Add(this.uiCancelButton);
            this.Controls.Add(this.uiOKButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.uiPasswordTextBox);
            this.Controls.Add(this.uiUserNameTextBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AuthenticationForm";
            this.Text = "Authentication Required";
            this.Load += new System.EventHandler(this.AuthenticationForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox uiUserNameTextBox;
        private System.Windows.Forms.TextBox uiPasswordTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button uiOKButton;
        private System.Windows.Forms.Button uiCancelButton;
    }
}