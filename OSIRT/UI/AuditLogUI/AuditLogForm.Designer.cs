namespace OSIRT.UI
{
    partial class AuditLogForm
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
            this.uiAuditLogSplitContainer = new System.Windows.Forms.SplitContainer();
            this.uiFileDetailsGroupBox = new System.Windows.Forms.GroupBox();
            this.uiFilePreviewPictureBox = new System.Windows.Forms.PictureBox();
            this.uiRowDetailsGroupBox = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.uiDateAndTimetextBox = new System.Windows.Forms.TextBox();
            this.uiNoteTextBox = new System.Windows.Forms.TextBox();
            this.uiActionTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.uiHashTextBox = new System.Windows.Forms.TextBox();
            this.uiURLTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.uiAuditLogSplitContainer)).BeginInit();
            this.uiAuditLogSplitContainer.Panel1.SuspendLayout();
            this.uiAuditLogSplitContainer.SuspendLayout();
            this.uiFileDetailsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiFilePreviewPictureBox)).BeginInit();
            this.uiRowDetailsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiAuditLogSplitContainer
            // 
            this.uiAuditLogSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiAuditLogSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.uiAuditLogSplitContainer.Name = "uiAuditLogSplitContainer";
            // 
            // uiAuditLogSplitContainer.Panel1
            // 
            this.uiAuditLogSplitContainer.Panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.uiAuditLogSplitContainer.Panel1.Controls.Add(this.uiFileDetailsGroupBox);
            this.uiAuditLogSplitContainer.Panel1.Controls.Add(this.uiRowDetailsGroupBox);
            // 
            // uiAuditLogSplitContainer.Panel2
            // 
            this.uiAuditLogSplitContainer.Panel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.uiAuditLogSplitContainer.Size = new System.Drawing.Size(990, 667);
            this.uiAuditLogSplitContainer.SplitterDistance = 324;
            this.uiAuditLogSplitContainer.TabIndex = 0;
            // 
            // uiFileDetailsGroupBox
            // 
            this.uiFileDetailsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiFileDetailsGroupBox.Controls.Add(this.uiFilePreviewPictureBox);
            this.uiFileDetailsGroupBox.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.uiFileDetailsGroupBox.Location = new System.Drawing.Point(12, 355);
            this.uiFileDetailsGroupBox.Name = "uiFileDetailsGroupBox";
            this.uiFileDetailsGroupBox.Size = new System.Drawing.Size(298, 300);
            this.uiFileDetailsGroupBox.TabIndex = 13;
            this.uiFileDetailsGroupBox.TabStop = false;
            this.uiFileDetailsGroupBox.Text = "File Previewer";
            // 
            // uiFilePreviewPictureBox
            // 
            this.uiFilePreviewPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiFilePreviewPictureBox.Location = new System.Drawing.Point(15, 19);
            this.uiFilePreviewPictureBox.Name = "uiFilePreviewPictureBox";
            this.uiFilePreviewPictureBox.Size = new System.Drawing.Size(263, 178);
            this.uiFilePreviewPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.uiFilePreviewPictureBox.TabIndex = 0;
            this.uiFilePreviewPictureBox.TabStop = false;
            // 
            // uiRowDetailsGroupBox
            // 
            this.uiRowDetailsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiRowDetailsGroupBox.Controls.Add(this.label1);
            this.uiRowDetailsGroupBox.Controls.Add(this.label6);
            this.uiRowDetailsGroupBox.Controls.Add(this.uiDateAndTimetextBox);
            this.uiRowDetailsGroupBox.Controls.Add(this.uiNoteTextBox);
            this.uiRowDetailsGroupBox.Controls.Add(this.uiActionTextBox);
            this.uiRowDetailsGroupBox.Controls.Add(this.label5);
            this.uiRowDetailsGroupBox.Controls.Add(this.label2);
            this.uiRowDetailsGroupBox.Controls.Add(this.uiHashTextBox);
            this.uiRowDetailsGroupBox.Controls.Add(this.uiURLTextBox);
            this.uiRowDetailsGroupBox.Controls.Add(this.label4);
            this.uiRowDetailsGroupBox.Controls.Add(this.label3);
            this.uiRowDetailsGroupBox.Controls.Add(this.textBox1);
            this.uiRowDetailsGroupBox.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.uiRowDetailsGroupBox.Location = new System.Drawing.Point(12, 12);
            this.uiRowDetailsGroupBox.Name = "uiRowDetailsGroupBox";
            this.uiRowDetailsGroupBox.Size = new System.Drawing.Size(298, 337);
            this.uiRowDetailsGroupBox.TabIndex = 12;
            this.uiRowDetailsGroupBox.TabStop = false;
            this.uiRowDetailsGroupBox.Text = "Row Details";
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
            // uiDateAndTimetextBox
            // 
            this.uiDateAndTimetextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiDateAndTimetextBox.Location = new System.Drawing.Point(15, 34);
            this.uiDateAndTimetextBox.Name = "uiDateAndTimetextBox";
            this.uiDateAndTimetextBox.ReadOnly = true;
            this.uiDateAndTimetextBox.Size = new System.Drawing.Size(263, 20);
            this.uiDateAndTimetextBox.TabIndex = 0;
            this.uiDateAndTimetextBox.Tag = "dateAndTime";
            // 
            // uiNoteTextBox
            // 
            this.uiNoteTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiNoteTextBox.Location = new System.Drawing.Point(15, 229);
            this.uiNoteTextBox.Multiline = true;
            this.uiNoteTextBox.Name = "uiNoteTextBox";
            this.uiNoteTextBox.ReadOnly = true;
            this.uiNoteTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.uiNoteTextBox.Size = new System.Drawing.Size(263, 98);
            this.uiNoteTextBox.TabIndex = 10;
            this.uiNoteTextBox.Tag = "note";
            // 
            // uiActionTextBox
            // 
            this.uiActionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiActionTextBox.Location = new System.Drawing.Point(15, 73);
            this.uiActionTextBox.Name = "uiActionTextBox";
            this.uiActionTextBox.ReadOnly = true;
            this.uiActionTextBox.Size = new System.Drawing.Size(263, 20);
            this.uiActionTextBox.TabIndex = 1;
            this.uiActionTextBox.Tag = "action";
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
            this.uiHashTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiHashTextBox.Location = new System.Drawing.Point(15, 190);
            this.uiHashTextBox.Name = "uiHashTextBox";
            this.uiHashTextBox.ReadOnly = true;
            this.uiHashTextBox.Size = new System.Drawing.Size(263, 20);
            this.uiHashTextBox.TabIndex = 8;
            this.uiHashTextBox.Tag = "hash";
            // 
            // uiURLTextBox
            // 
            this.uiURLTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiURLTextBox.Location = new System.Drawing.Point(15, 112);
            this.uiURLTextBox.Name = "uiURLTextBox";
            this.uiURLTextBox.ReadOnly = true;
            this.uiURLTextBox.Size = new System.Drawing.Size(263, 20);
            this.uiURLTextBox.TabIndex = 4;
            this.uiURLTextBox.Tag = "url";
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
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(15, 151);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(263, 20);
            this.textBox1.TabIndex = 6;
            this.textBox1.Tag = "file_name";
            // 
            // AuditLogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 667);
            this.Controls.Add(this.uiAuditLogSplitContainer);
            this.Name = "AuditLogForm";
            this.Text = "Audit Log";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AuditLogForm_FormClosing);
            this.Load += new System.EventHandler(this.uiAuditLogForm_Load);
            this.uiAuditLogSplitContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiAuditLogSplitContainer)).EndInit();
            this.uiAuditLogSplitContainer.ResumeLayout(false);
            this.uiFileDetailsGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiFilePreviewPictureBox)).EndInit();
            this.uiRowDetailsGroupBox.ResumeLayout(false);
            this.uiRowDetailsGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer uiAuditLogSplitContainer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox uiActionTextBox;
        private System.Windows.Forms.TextBox uiDateAndTimetextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox uiNoteTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox uiHashTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox uiURLTextBox;
        private System.Windows.Forms.GroupBox uiRowDetailsGroupBox;
        private System.Windows.Forms.GroupBox uiFileDetailsGroupBox;
        private System.Windows.Forms.PictureBox uiFilePreviewPictureBox;
    }
}