namespace OSIRT.UI.AuditLog
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
            this.uiSearchTextTextBox = new System.Windows.Forms.TextBox();
            this.uiTabletoSearchComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.uiSearchCriteriaGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiSearchCriteriaGroupBox
            // 
            this.uiSearchCriteriaGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiSearchCriteriaGroupBox.Controls.Add(this.label2);
            this.uiSearchCriteriaGroupBox.Controls.Add(this.uiTabletoSearchComboBox);
            this.uiSearchCriteriaGroupBox.Controls.Add(this.label1);
            this.uiSearchCriteriaGroupBox.Controls.Add(this.uiSearchButton);
            this.uiSearchCriteriaGroupBox.Controls.Add(this.uiSearchTextTextBox);
            this.uiSearchCriteriaGroupBox.Location = new System.Drawing.Point(13, 12);
            this.uiSearchCriteriaGroupBox.Name = "uiSearchCriteriaGroupBox";
            this.uiSearchCriteriaGroupBox.Size = new System.Drawing.Size(280, 188);
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
            this.uiSearchButton.Location = new System.Drawing.Point(98, 129);
            this.uiSearchButton.Name = "uiSearchButton";
            this.uiSearchButton.Size = new System.Drawing.Size(75, 23);
            this.uiSearchButton.TabIndex = 1;
            this.uiSearchButton.Text = "Search";
            this.uiSearchButton.UseVisualStyleBackColor = true;
            this.uiSearchButton.Click += new System.EventHandler(this.uiSearchButton_Click);
            // 
            // uiSearchTextTextBox
            // 
            this.uiSearchTextTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiSearchTextTextBox.Location = new System.Drawing.Point(6, 38);
            this.uiSearchTextTextBox.Name = "uiSearchTextTextBox";
            this.uiSearchTextTextBox.Size = new System.Drawing.Size(268, 20);
            this.uiSearchTextTextBox.TabIndex = 0;
            // 
            // uiTabletoSearchComboBox
            // 
            this.uiTabletoSearchComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiTabletoSearchComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.uiTabletoSearchComboBox.FormattingEnabled = true;
            this.uiTabletoSearchComboBox.Location = new System.Drawing.Point(6, 91);
            this.uiTabletoSearchComboBox.Name = "uiTabletoSearchComboBox";
            this.uiTabletoSearchComboBox.Size = new System.Drawing.Size(268, 21);
            this.uiTabletoSearchComboBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(7, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Log To Search:";
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
        private System.Windows.Forms.TextBox uiSearchTextTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox uiTabletoSearchComboBox;
    }
}
