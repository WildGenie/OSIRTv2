namespace OSIRT.UI.CaseNotes
{
    partial class CaseNotesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CaseNotesForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.uiCaseNotesTextBox = new System.Windows.Forms.TextBox();
            this.uiButtonPanel = new System.Windows.Forms.Panel();
            this.uiAddNoteButton = new System.Windows.Forms.Button();
            this.uiEnteredNoteSpellBox = new OSIRT.UI.SpellBox();
            this.hostedComponent5 = new System.Windows.Controls.TextBox();
            this.uiOptionsToolStrip = new System.Windows.Forms.ToolStrip();
            this.uiExportAsPDFToolStripButton = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.uiButtonPanel.SuspendLayout();
            this.uiOptionsToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.uiCaseNotesTextBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.uiButtonPanel);
            this.splitContainer1.Panel2.Controls.Add(this.uiEnteredNoteSpellBox);
            this.splitContainer1.Size = new System.Drawing.Size(696, 536);
            this.splitContainer1.SplitterDistance = 381;
            this.splitContainer1.TabIndex = 1;
            // 
            // uiCaseNotesTextBox
            // 
            this.uiCaseNotesTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiCaseNotesTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiCaseNotesTextBox.Location = new System.Drawing.Point(0, 41);
            this.uiCaseNotesTextBox.Multiline = true;
            this.uiCaseNotesTextBox.Name = "uiCaseNotesTextBox";
            this.uiCaseNotesTextBox.ReadOnly = true;
            this.uiCaseNotesTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.uiCaseNotesTextBox.Size = new System.Drawing.Size(696, 336);
            this.uiCaseNotesTextBox.TabIndex = 0;
            // 
            // uiButtonPanel
            // 
            this.uiButtonPanel.Controls.Add(this.uiAddNoteButton);
            this.uiButtonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.uiButtonPanel.Location = new System.Drawing.Point(0, 120);
            this.uiButtonPanel.Name = "uiButtonPanel";
            this.uiButtonPanel.Size = new System.Drawing.Size(696, 31);
            this.uiButtonPanel.TabIndex = 1;
            // 
            // uiAddNoteButton
            // 
            this.uiAddNoteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiAddNoteButton.Location = new System.Drawing.Point(602, 3);
            this.uiAddNoteButton.Name = "uiAddNoteButton";
            this.uiAddNoteButton.Size = new System.Drawing.Size(88, 23);
            this.uiAddNoteButton.TabIndex = 0;
            this.uiAddNoteButton.Text = "Add Note";
            this.uiAddNoteButton.UseVisualStyleBackColor = true;
            this.uiAddNoteButton.Click += new System.EventHandler(this.uiAddNoteButton_Click);
            // 
            // uiEnteredNoteSpellBox
            // 
            this.uiEnteredNoteSpellBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiEnteredNoteSpellBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiEnteredNoteSpellBox.Location = new System.Drawing.Point(0, 0);
            this.uiEnteredNoteSpellBox.Multiline = true;
            this.uiEnteredNoteSpellBox.Name = "uiEnteredNoteSpellBox";
            this.uiEnteredNoteSpellBox.Size = new System.Drawing.Size(696, 121);
            this.uiEnteredNoteSpellBox.TabIndex = 0;
            this.uiEnteredNoteSpellBox.WordWrap = true;
            // 
            // uiOptionsToolStrip
            // 
            this.uiOptionsToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uiExportAsPDFToolStripButton});
            this.uiOptionsToolStrip.Location = new System.Drawing.Point(0, 0);
            this.uiOptionsToolStrip.Name = "uiOptionsToolStrip";
            this.uiOptionsToolStrip.Size = new System.Drawing.Size(696, 25);
            this.uiOptionsToolStrip.TabIndex = 1;
            this.uiOptionsToolStrip.Text = "toolStrip1";
            // 
            // uiExportAsPDFToolStripButton
            // 
            this.uiExportAsPDFToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.uiExportAsPDFToolStripButton.Image = global::OSIRT.Properties.Resources.pdf_icon;
            this.uiExportAsPDFToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uiExportAsPDFToolStripButton.Name = "uiExportAsPDFToolStripButton";
            this.uiExportAsPDFToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.uiExportAsPDFToolStripButton.Text = "p";
            this.uiExportAsPDFToolStripButton.ToolTipText = "Export as PDF";
            this.uiExportAsPDFToolStripButton.Click += new System.EventHandler(this.uiExportAsPDFToolStripButton_Click);
            // 
            // CaseNotesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 536);
            this.Controls.Add(this.uiOptionsToolStrip);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CaseNotesForm";
            this.Text = "Case Notes";
            this.Load += new System.EventHandler(this.CaseNotesForm_Load);
            this.Shown += new System.EventHandler(this.CaseNotesForm_Shown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.uiButtonPanel.ResumeLayout(false);
            this.uiOptionsToolStrip.ResumeLayout(false);
            this.uiOptionsToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox uiCaseNotesTextBox;
        private SpellBox uiEnteredNoteSpellBox;
        private System.Windows.Controls.TextBox hostedComponent1;
        private System.Windows.Forms.ToolStrip uiOptionsToolStrip;
        private System.Windows.Forms.ToolStripButton uiExportAsPDFToolStripButton;
        private System.Windows.Forms.Panel uiButtonPanel;
        private System.Windows.Forms.Button uiAddNoteButton;
        private System.Windows.Controls.TextBox hostedComponent2;
        private System.Windows.Controls.TextBox hostedComponent3;
        private System.Windows.Controls.TextBox hostedComponent4;
        private System.Windows.Controls.TextBox hostedComponent5;
    }
}