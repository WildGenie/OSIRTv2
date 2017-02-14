namespace OSIRT.UI
{
    partial class CaseDetailsPanel2
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.uiPasswordGroupBox = new System.Windows.Forms.GroupBox();
            this.uiRequiresPasswordCheckbox = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.uiConfirmPasswordTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.uiFirstPasswordTextBox = new System.Windows.Forms.TextBox();
            this.uiCaseDetailsGroupBox = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.uiEvidenceReferenceTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.uiCaseReferenceTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.uiOperationTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.uiAgencyTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.uiInvestigatingOfficer = new System.Windows.Forms.TextBox();
            this.uiNextButton = new System.Windows.Forms.Button();
            this.uiCaseOptionsGroupBox = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.uiCasePathTextBox = new System.Windows.Forms.TextBox();
            this.uiBrowsButton = new System.Windows.Forms.Button();
            this.uiHashFunctionComboBox = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.uiHelpLabelLabel = new System.Windows.Forms.Label();
            this.uiHashHelpLabel = new System.Windows.Forms.Label();
            this.uiCaserefDetailsLabel = new System.Windows.Forms.Label();
            this.uiNotesTextBox = new OSIRT.UI.SpellBox();
            this.hostedComponent7 = new System.Windows.Controls.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.uiPasswordGroupBox.SuspendLayout();
            this.uiCaseDetailsGroupBox.SuspendLayout();
            this.uiCaseOptionsGroupBox.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 68);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.uiPasswordGroupBox);
            this.splitContainer1.Panel1.Controls.Add(this.uiCaseDetailsGroupBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.uiNextButton);
            this.splitContainer1.Panel2.Controls.Add(this.uiCaseOptionsGroupBox);
            this.splitContainer1.Size = new System.Drawing.Size(1049, 537);
            this.splitContainer1.SplitterDistance = 484;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.TabStop = false;
            // 
            // uiPasswordGroupBox
            // 
            this.uiPasswordGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiPasswordGroupBox.Controls.Add(this.uiRequiresPasswordCheckbox);
            this.uiPasswordGroupBox.Controls.Add(this.label10);
            this.uiPasswordGroupBox.Controls.Add(this.uiConfirmPasswordTextBox);
            this.uiPasswordGroupBox.Controls.Add(this.label9);
            this.uiPasswordGroupBox.Controls.Add(this.uiFirstPasswordTextBox);
            this.uiPasswordGroupBox.Location = new System.Drawing.Point(3, 290);
            this.uiPasswordGroupBox.Name = "uiPasswordGroupBox";
            this.uiPasswordGroupBox.Size = new System.Drawing.Size(459, 159);
            this.uiPasswordGroupBox.TabIndex = 58;
            this.uiPasswordGroupBox.TabStop = false;
            this.uiPasswordGroupBox.Text = "Container Password [In Beta, recommended for testers only]";
            // 
            // uiRequiresPasswordCheckbox
            // 
            this.uiRequiresPasswordCheckbox.AutoSize = true;
            this.uiRequiresPasswordCheckbox.Location = new System.Drawing.Point(10, 25);
            this.uiRequiresPasswordCheckbox.Name = "uiRequiresPasswordCheckbox";
            this.uiRequiresPasswordCheckbox.Size = new System.Drawing.Size(119, 17);
            this.uiRequiresPasswordCheckbox.TabIndex = 7;
            this.uiRequiresPasswordCheckbox.Text = "Password required?";
            this.uiRequiresPasswordCheckbox.UseVisualStyleBackColor = true;
            this.uiRequiresPasswordCheckbox.CheckedChanged += new System.EventHandler(this.uiRequiresPasswordCheckbox_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 105);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(91, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "Confirm Password";
            // 
            // uiConfirmPasswordTextBox
            // 
            this.uiConfirmPasswordTextBox.Enabled = false;
            this.uiConfirmPasswordTextBox.Location = new System.Drawing.Point(9, 121);
            this.uiConfirmPasswordTextBox.Name = "uiConfirmPasswordTextBox";
            this.uiConfirmPasswordTextBox.Size = new System.Drawing.Size(228, 20);
            this.uiConfirmPasswordTextBox.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 56);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Password";
            // 
            // uiFirstPasswordTextBox
            // 
            this.uiFirstPasswordTextBox.Enabled = false;
            this.uiFirstPasswordTextBox.Location = new System.Drawing.Point(9, 72);
            this.uiFirstPasswordTextBox.Name = "uiFirstPasswordTextBox";
            this.uiFirstPasswordTextBox.Size = new System.Drawing.Size(228, 20);
            this.uiFirstPasswordTextBox.TabIndex = 5;
            this.uiFirstPasswordTextBox.TextChanged += new System.EventHandler(this.uiFirstPasswordTextBox_TextChanged);
            // 
            // uiCaseDetailsGroupBox
            // 
            this.uiCaseDetailsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiCaseDetailsGroupBox.Controls.Add(this.uiCaserefDetailsLabel);
            this.uiCaseDetailsGroupBox.Controls.Add(this.label5);
            this.uiCaseDetailsGroupBox.Controls.Add(this.uiEvidenceReferenceTextBox);
            this.uiCaseDetailsGroupBox.Controls.Add(this.label4);
            this.uiCaseDetailsGroupBox.Controls.Add(this.uiCaseReferenceTextBox);
            this.uiCaseDetailsGroupBox.Controls.Add(this.label3);
            this.uiCaseDetailsGroupBox.Controls.Add(this.uiOperationTextBox);
            this.uiCaseDetailsGroupBox.Controls.Add(this.label2);
            this.uiCaseDetailsGroupBox.Controls.Add(this.uiAgencyTextBox);
            this.uiCaseDetailsGroupBox.Controls.Add(this.label1);
            this.uiCaseDetailsGroupBox.Controls.Add(this.uiInvestigatingOfficer);
            this.uiCaseDetailsGroupBox.Location = new System.Drawing.Point(6, 6);
            this.uiCaseDetailsGroupBox.Name = "uiCaseDetailsGroupBox";
            this.uiCaseDetailsGroupBox.Size = new System.Drawing.Size(456, 278);
            this.uiCaseDetailsGroupBox.TabIndex = 0;
            this.uiCaseDetailsGroupBox.TabStop = false;
            this.uiCaseDetailsGroupBox.Text = "Case Details";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 225);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 13);
            this.label5.TabIndex = 57;
            this.label5.Text = "Evidence Reference";
            // 
            // uiEvidenceReferenceTextBox
            // 
            this.uiEvidenceReferenceTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiEvidenceReferenceTextBox.Location = new System.Drawing.Point(6, 241);
            this.uiEvidenceReferenceTextBox.Name = "uiEvidenceReferenceTextBox";
            this.uiEvidenceReferenceTextBox.Size = new System.Drawing.Size(419, 20);
            this.uiEvidenceReferenceTextBox.TabIndex = 4;
            this.uiEvidenceReferenceTextBox.Tag = "evidence_reference";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 174);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 55;
            this.label4.Text = "Case Reference";
            // 
            // uiCaseReferenceTextBox
            // 
            this.uiCaseReferenceTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiCaseReferenceTextBox.Location = new System.Drawing.Point(6, 190);
            this.uiCaseReferenceTextBox.Name = "uiCaseReferenceTextBox";
            this.uiCaseReferenceTextBox.Size = new System.Drawing.Size(419, 20);
            this.uiCaseReferenceTextBox.TabIndex = 3;
            this.uiCaseReferenceTextBox.Tag = "case_reference";
            this.uiCaseReferenceTextBox.Enter += new System.EventHandler(this.uiCaseReferenceTextBox_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 53;
            this.label3.Text = "Operation Name";
            // 
            // uiOperationTextBox
            // 
            this.uiOperationTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiOperationTextBox.Location = new System.Drawing.Point(6, 138);
            this.uiOperationTextBox.Name = "uiOperationTextBox";
            this.uiOperationTextBox.Size = new System.Drawing.Size(419, 20);
            this.uiOperationTextBox.TabIndex = 2;
            this.uiOperationTextBox.Tag = "operation_name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 51;
            this.label2.Text = "Investigating Agency";
            // 
            // uiAgencyTextBox
            // 
            this.uiAgencyTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiAgencyTextBox.Location = new System.Drawing.Point(6, 90);
            this.uiAgencyTextBox.Name = "uiAgencyTextBox";
            this.uiAgencyTextBox.Size = new System.Drawing.Size(419, 20);
            this.uiAgencyTextBox.TabIndex = 1;
            this.uiAgencyTextBox.Tag = "investigating_agency";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 49;
            this.label1.Text = "Investigating Officer";
            // 
            // uiInvestigatingOfficer
            // 
            this.uiInvestigatingOfficer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiInvestigatingOfficer.Location = new System.Drawing.Point(6, 40);
            this.uiInvestigatingOfficer.Name = "uiInvestigatingOfficer";
            this.uiInvestigatingOfficer.Size = new System.Drawing.Size(419, 20);
            this.uiInvestigatingOfficer.TabIndex = 0;
            this.uiInvestigatingOfficer.Tag = "investigating_officer";
            // 
            // uiNextButton
            // 
            this.uiNextButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.uiNextButton.Location = new System.Drawing.Point(469, 511);
            this.uiNextButton.Name = "uiNextButton";
            this.uiNextButton.Size = new System.Drawing.Size(79, 23);
            this.uiNextButton.TabIndex = 10;
            this.uiNextButton.Text = "Next";
            this.uiNextButton.UseVisualStyleBackColor = true;
            this.uiNextButton.Click += new System.EventHandler(this.uiNextButton_Click);
            // 
            // uiCaseOptionsGroupBox
            // 
            this.uiCaseOptionsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiCaseOptionsGroupBox.Controls.Add(this.label8);
            this.uiCaseOptionsGroupBox.Controls.Add(this.label7);
            this.uiCaseOptionsGroupBox.Controls.Add(this.label6);
            this.uiCaseOptionsGroupBox.Controls.Add(this.uiCasePathTextBox);
            this.uiCaseOptionsGroupBox.Controls.Add(this.uiBrowsButton);
            this.uiCaseOptionsGroupBox.Controls.Add(this.uiHashHelpLabel);
            this.uiCaseOptionsGroupBox.Controls.Add(this.uiHashFunctionComboBox);
            this.uiCaseOptionsGroupBox.Controls.Add(this.uiNotesTextBox);
            this.uiCaseOptionsGroupBox.Location = new System.Drawing.Point(3, 6);
            this.uiCaseOptionsGroupBox.Name = "uiCaseOptionsGroupBox";
            this.uiCaseOptionsGroupBox.Size = new System.Drawing.Size(545, 443);
            this.uiCaseOptionsGroupBox.TabIndex = 0;
            this.uiCaseOptionsGroupBox.TabStop = false;
            this.uiCaseOptionsGroupBox.Text = "Case Options";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 122);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 60;
            this.label8.Text = "Notes";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 13);
            this.label7.TabIndex = 59;
            this.label7.Text = "Hash Function";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 13);
            this.label6.TabIndex = 58;
            this.label6.Text = "Case Save Location";
            // 
            // uiCasePathTextBox
            // 
            this.uiCasePathTextBox.Location = new System.Drawing.Point(6, 37);
            this.uiCasePathTextBox.Name = "uiCasePathTextBox";
            this.uiCasePathTextBox.ReadOnly = true;
            this.uiCasePathTextBox.Size = new System.Drawing.Size(351, 20);
            this.uiCasePathTextBox.TabIndex = 57;
            this.uiCasePathTextBox.TabStop = false;
            this.uiCasePathTextBox.Tag = "case_location";
            // 
            // uiBrowsButton
            // 
            this.uiBrowsButton.Location = new System.Drawing.Point(363, 35);
            this.uiBrowsButton.Name = "uiBrowsButton";
            this.uiBrowsButton.Size = new System.Drawing.Size(67, 23);
            this.uiBrowsButton.TabIndex = 7;
            this.uiBrowsButton.Text = "Browse...";
            this.uiBrowsButton.UseVisualStyleBackColor = true;
            this.uiBrowsButton.Click += new System.EventHandler(this.uiBrowsButton_Click);
            // 
            // uiHashFunctionComboBox
            // 
            this.uiHashFunctionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.uiHashFunctionComboBox.FormattingEnabled = true;
            this.uiHashFunctionComboBox.Items.AddRange(new object[] {
            "md5",
            "sha1",
            "sha256",
            "sha384",
            "sha512"});
            this.uiHashFunctionComboBox.Location = new System.Drawing.Point(6, 89);
            this.uiHashFunctionComboBox.Name = "uiHashFunctionComboBox";
            this.uiHashFunctionComboBox.Size = new System.Drawing.Size(124, 21);
            this.uiHashFunctionComboBox.TabIndex = 8;
            this.uiHashFunctionComboBox.Tag = "hash_function";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1049, 71);
            this.panel1.TabIndex = 62;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel2.Controls.Add(this.uiHelpLabelLabel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 608);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1049, 72);
            this.panel2.TabIndex = 59;
            // 
            // uiHelpLabelLabel
            // 
            this.uiHelpLabelLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiHelpLabelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiHelpLabelLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.uiHelpLabelLabel.Location = new System.Drawing.Point(0, 0);
            this.uiHelpLabelLabel.Name = "uiHelpLabelLabel";
            this.uiHelpLabelLabel.Size = new System.Drawing.Size(1049, 72);
            this.uiHelpLabelLabel.TabIndex = 1;
            this.uiHelpLabelLabel.Text = "Create New Case";
            this.uiHelpLabelLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiHashHelpLabel
            // 
            this.uiHashHelpLabel.AutoSize = true;
            this.uiHashHelpLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiHashHelpLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiHashHelpLabel.Location = new System.Drawing.Point(136, 89);
            this.uiHashHelpLabel.Name = "uiHashHelpLabel";
            this.uiHashHelpLabel.Size = new System.Drawing.Size(23, 16);
            this.uiHashHelpLabel.TabIndex = 55;
            this.uiHashHelpLabel.Text = "[?]";
            this.uiHashHelpLabel.Click += new System.EventHandler(this.uiHashHelpLabel_Click);
            // 
            // uiCaserefDetailsLabel
            // 
            this.uiCaserefDetailsLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.uiCaserefDetailsLabel.AutoSize = true;
            this.uiCaserefDetailsLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiCaserefDetailsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiCaserefDetailsLabel.Location = new System.Drawing.Point(89, 171);
            this.uiCaserefDetailsLabel.Name = "uiCaserefDetailsLabel";
            this.uiCaserefDetailsLabel.Size = new System.Drawing.Size(23, 16);
            this.uiCaserefDetailsLabel.TabIndex = 61;
            this.uiCaserefDetailsLabel.Text = "[?]";
            this.uiCaserefDetailsLabel.Click += new System.EventHandler(this.uiCaserefDetailsLabel_Click);
            // 
            // uiNotesTextBox
            // 
            this.uiNotesTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiNotesTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiNotesTextBox.Location = new System.Drawing.Point(3, 138);
            this.uiNotesTextBox.Multiline = true;
            this.uiNotesTextBox.Name = "uiNotesTextBox";
            this.uiNotesTextBox.Size = new System.Drawing.Size(503, 296);
            this.uiNotesTextBox.TabIndex = 9;
            this.uiNotesTextBox.Tag = "notes";
            this.uiNotesTextBox.WordWrap = true;
            // 
            // CaseDetailsPanel2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.splitContainer1);
            this.Name = "CaseDetailsPanel2";
            this.Size = new System.Drawing.Size(1049, 680);
            this.Load += new System.EventHandler(this.CaseDetailsPanel2_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.uiPasswordGroupBox.ResumeLayout(false);
            this.uiPasswordGroupBox.PerformLayout();
            this.uiCaseDetailsGroupBox.ResumeLayout(false);
            this.uiCaseDetailsGroupBox.PerformLayout();
            this.uiCaseOptionsGroupBox.ResumeLayout(false);
            this.uiCaseOptionsGroupBox.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox uiCaseDetailsGroupBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox uiEvidenceReferenceTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox uiCaseReferenceTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox uiOperationTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox uiAgencyTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox uiInvestigatingOfficer;
        private System.Windows.Forms.GroupBox uiCaseOptionsGroupBox;
        private System.Windows.Forms.GroupBox uiPasswordGroupBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox uiConfirmPasswordTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox uiFirstPasswordTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox uiCasePathTextBox;
        private System.Windows.Forms.Button uiBrowsButton;
        private System.Windows.Forms.ComboBox uiHashFunctionComboBox;
        private SpellBox uiNotesTextBox;
        private System.Windows.Controls.TextBox hostedComponent1;
        private System.Windows.Forms.Button uiNextButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label uiHelpLabelLabel;
        private System.Windows.Controls.TextBox hostedComponent2;
        private System.Windows.Controls.TextBox hostedComponent3;
        private System.Windows.Controls.TextBox hostedComponent4;
        private System.Windows.Controls.TextBox hostedComponent5;
        private System.Windows.Forms.CheckBox uiRequiresPasswordCheckbox;
        private System.Windows.Controls.TextBox hostedComponent6;
        private System.Windows.Controls.TextBox hostedComponent7;
        private System.Windows.Forms.Label uiCaserefDetailsLabel;
        private System.Windows.Forms.Label uiHashHelpLabel;
    }
}
