namespace OSIRT.UI.ExtendedCaseNotes
{
    partial class ExtendedCaseNotes
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
            this.uiNotesRichTextBox = new System.Windows.Forms.RichTextBox();
            this.uiNoteEntryRichTextSpellBox = new OSIRT.RichTextSpellBox();
            this.hostedComponent2 = new System.Windows.Controls.RichTextBox();
            this.SuspendLayout();
            // 
            // uiNotesRichTextBox
            // 
            this.uiNotesRichTextBox.Enabled = false;
            this.uiNotesRichTextBox.Location = new System.Drawing.Point(4, 3);
            this.uiNotesRichTextBox.Name = "uiNotesRichTextBox";
            this.uiNotesRichTextBox.Size = new System.Drawing.Size(718, 367);
            this.uiNotesRichTextBox.TabIndex = 0;
            this.uiNotesRichTextBox.Text = "";
            // 
            // uiNoteEntryRichTextSpellBox
            // 
            this.uiNoteEntryRichTextSpellBox.Location = new System.Drawing.Point(4, 376);
            this.uiNoteEntryRichTextSpellBox.Multiline = true;
            this.uiNoteEntryRichTextSpellBox.Name = "uiNoteEntryRichTextSpellBox";
            this.uiNoteEntryRichTextSpellBox.Size = new System.Drawing.Size(718, 125);
            this.uiNoteEntryRichTextSpellBox.TabIndex = 1;
            this.uiNoteEntryRichTextSpellBox.Text = "richTextSpellBox1\r\n";
            // 
            // ExtendedCaseNotes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 539);
            this.Controls.Add(this.uiNoteEntryRichTextSpellBox);
            this.Controls.Add(this.uiNotesRichTextBox);
            this.Name = "ExtendedCaseNotes";
            this.Text = "ExtendedCaseNotes";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox uiNotesRichTextBox;
        private System.Windows.Controls.TextBox hostedComponent1;
        private RichTextSpellBox uiNoteEntryRichTextSpellBox;
        private System.Windows.Controls.RichTextBox hostedComponent2;
    }
}