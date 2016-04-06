namespace OSIRT.UI.AuditLog
{
    partial class RowDetailsPanel
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
            this.uiFileDetailsGroupBox = new System.Windows.Forms.GroupBox();
            this.uiFileDetailsLabel = new System.Windows.Forms.Label();
            this.FilePreviewImage = new System.Windows.Forms.PictureBox();
            this.RowDetailsGroupBox = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.DateTimeTextBox = new System.Windows.Forms.TextBox();
            this.NotesTextBox = new System.Windows.Forms.TextBox();
            this.ActionTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.HashTextBox = new System.Windows.Forms.TextBox();
            this.UrlTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.FileTextBox = new System.Windows.Forms.TextBox();
            this.uiFileDetailsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FilePreviewImage)).BeginInit();
            this.RowDetailsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiFileDetailsGroupBox
            // 
            this.uiFileDetailsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiFileDetailsGroupBox.Controls.Add(this.uiFileDetailsLabel);
            this.uiFileDetailsGroupBox.Controls.Add(this.FilePreviewImage);
            this.uiFileDetailsGroupBox.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.uiFileDetailsGroupBox.Location = new System.Drawing.Point(9, 361);
            this.uiFileDetailsGroupBox.Name = "uiFileDetailsGroupBox";
            this.uiFileDetailsGroupBox.Size = new System.Drawing.Size(289, 289);
            this.uiFileDetailsGroupBox.TabIndex = 17;
            this.uiFileDetailsGroupBox.TabStop = false;
            this.uiFileDetailsGroupBox.Text = "File Previewer";
            // 
            // uiFileDetailsLabel
            // 
            this.uiFileDetailsLabel.AutoSize = true;
            this.uiFileDetailsLabel.Location = new System.Drawing.Point(16, 204);
            this.uiFileDetailsLabel.Name = "uiFileDetailsLabel";
            this.uiFileDetailsLabel.Size = new System.Drawing.Size(35, 13);
            this.uiFileDetailsLabel.TabIndex = 1;
            this.uiFileDetailsLabel.Text = "label7";
            // 
            // uiFilePreviewPictureBox
            // 
            this.FilePreviewImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FilePreviewImage.Location = new System.Drawing.Point(15, 19);
            this.FilePreviewImage.Name = "FilePreviewImage";
            this.FilePreviewImage.Size = new System.Drawing.Size(254, 183);
            this.FilePreviewImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.FilePreviewImage.TabIndex = 0;
            this.FilePreviewImage.TabStop = false;
            // 
            // uiRowDetailsGroupBox
            // 
            this.RowDetailsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RowDetailsGroupBox.Controls.Add(this.label1);
            this.RowDetailsGroupBox.Controls.Add(this.label6);
            this.RowDetailsGroupBox.Controls.Add(this.DateTimeTextBox);
            this.RowDetailsGroupBox.Controls.Add(this.NotesTextBox);
            this.RowDetailsGroupBox.Controls.Add(this.ActionTextBox);
            this.RowDetailsGroupBox.Controls.Add(this.label5);
            this.RowDetailsGroupBox.Controls.Add(this.label2);
            this.RowDetailsGroupBox.Controls.Add(this.HashTextBox);
            this.RowDetailsGroupBox.Controls.Add(this.UrlTextBox);
            this.RowDetailsGroupBox.Controls.Add(this.label4);
            this.RowDetailsGroupBox.Controls.Add(this.label3);
            this.RowDetailsGroupBox.Controls.Add(this.FileTextBox);
            this.RowDetailsGroupBox.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.RowDetailsGroupBox.Location = new System.Drawing.Point(9, 18);
            this.RowDetailsGroupBox.Name = "RowDetailsGroupBox";
            this.RowDetailsGroupBox.Size = new System.Drawing.Size(289, 337);
            this.RowDetailsGroupBox.TabIndex = 16;
            this.RowDetailsGroupBox.TabStop = false;
            this.RowDetailsGroupBox.Text = "Row Details";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Date and Time";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 213);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Note";
            // 
            // uiDateAndTimeTextBox
            // 
            this.DateTimeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DateTimeTextBox.Location = new System.Drawing.Point(15, 34);
            this.DateTimeTextBox.Name = "DateTimeTextBox";
            this.DateTimeTextBox.ReadOnly = true;
            this.DateTimeTextBox.Size = new System.Drawing.Size(254, 20);
            this.DateTimeTextBox.TabIndex = 0;
            this.DateTimeTextBox.Tag = "dateAndTime";
            // 
            // uiNoteTextBox
            // 
            this.NotesTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NotesTextBox.Location = new System.Drawing.Point(15, 229);
            this.NotesTextBox.Multiline = true;
            this.NotesTextBox.Name = "NotesTextBox";
            this.NotesTextBox.ReadOnly = true;
            this.NotesTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.NotesTextBox.Size = new System.Drawing.Size(254, 98);
            this.NotesTextBox.TabIndex = 10;
            this.NotesTextBox.Tag = "note";
            // 
            // uiActionTextBox
            // 
            this.ActionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ActionTextBox.Location = new System.Drawing.Point(15, 73);
            this.ActionTextBox.Name = "ActionTextBox";
            this.ActionTextBox.ReadOnly = true;
            this.ActionTextBox.Size = new System.Drawing.Size(254, 20);
            this.ActionTextBox.TabIndex = 1;
            this.ActionTextBox.Tag = "action";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 174);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Hash";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Action";
            // 
            // uiHashTextBox
            // 
            this.HashTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HashTextBox.Location = new System.Drawing.Point(15, 190);
            this.HashTextBox.Name = "HashTextBox";
            this.HashTextBox.ReadOnly = true;
            this.HashTextBox.Size = new System.Drawing.Size(254, 20);
            this.HashTextBox.TabIndex = 8;
            this.HashTextBox.Tag = "hash";
            // 
            // uiURLTextBox
            // 
            this.UrlTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UrlTextBox.Location = new System.Drawing.Point(15, 112);
            this.UrlTextBox.Name = "URLTextBox";
            this.UrlTextBox.ReadOnly = true;
            this.UrlTextBox.Size = new System.Drawing.Size(254, 20);
            this.UrlTextBox.TabIndex = 4;
            this.UrlTextBox.Tag = "url";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "File";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "URL";
            // 
            // uiFileNameTextBox
            // 
            this.FileTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FileTextBox.Location = new System.Drawing.Point(15, 151);
            this.FileTextBox.Name = "FileTextBox";
            this.FileTextBox.ReadOnly = true;
            this.FileTextBox.Size = new System.Drawing.Size(254, 20);
            this.FileTextBox.TabIndex = 6;
            this.FileTextBox.Tag = "file";
            // 
            // RowDetailsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.Controls.Add(this.uiFileDetailsGroupBox);
            this.Controls.Add(this.RowDetailsGroupBox);
            this.Name = "RowDetailsPanel";
            this.Size = new System.Drawing.Size(307, 691);
            this.Load += new System.EventHandler(this.RowDetailsPanel_Load);
            this.uiFileDetailsGroupBox.ResumeLayout(false);
            this.uiFileDetailsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FilePreviewImage)).EndInit();
            this.RowDetailsGroupBox.ResumeLayout(false);
            this.RowDetailsGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox uiFileDetailsGroupBox;
        private System.Windows.Forms.Label uiFileDetailsLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}
