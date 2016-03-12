namespace OSIRT.UI
{
    partial class AuditTabControlPanel
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
            this.uiAuditTabsPanel = new System.Windows.Forms.Panel();
            this.uiGridViewPanel = new System.Windows.Forms.Panel();
            this.uiSearchPanel = new System.Windows.Forms.Panel();
            this.uiSearchButton = new System.Windows.Forms.Button();
            this.uiSearchTextBox = new System.Windows.Forms.TextBox();
            this.uiPaginationPanel = new System.Windows.Forms.Panel();
            this.uiFirstPageButton = new System.Windows.Forms.Button();
            this.uiPreviousPageButton = new System.Windows.Forms.Button();
            this.uiNextPageButton = new System.Windows.Forms.Button();
            this.uiLastPageButton = new System.Windows.Forms.Button();
            this.uiAuditTabsPanel.SuspendLayout();
            this.uiGridViewPanel.SuspendLayout();
            this.uiSearchPanel.SuspendLayout();
            this.uiPaginationPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiAuditTabsPanel
            // 
            this.uiAuditTabsPanel.Controls.Add(this.uiGridViewPanel);
            this.uiAuditTabsPanel.Controls.Add(this.uiSearchPanel);
            this.uiAuditTabsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiAuditTabsPanel.Location = new System.Drawing.Point(0, 0);
            this.uiAuditTabsPanel.Name = "uiAuditTabsPanel";
            this.uiAuditTabsPanel.Size = new System.Drawing.Size(811, 606);
            this.uiAuditTabsPanel.TabIndex = 0;
            // 
            // uiGridViewPanel
            // 
            this.uiGridViewPanel.Controls.Add(this.uiPaginationPanel);
            this.uiGridViewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiGridViewPanel.Location = new System.Drawing.Point(0, 33);
            this.uiGridViewPanel.Name = "uiGridViewPanel";
            this.uiGridViewPanel.Size = new System.Drawing.Size(811, 573);
            this.uiGridViewPanel.TabIndex = 1;
            this.uiGridViewPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.uiGridViewPanel_Paint);
            // 
            // uiSearchPanel
            // 
            this.uiSearchPanel.Controls.Add(this.uiSearchButton);
            this.uiSearchPanel.Controls.Add(this.uiSearchTextBox);
            this.uiSearchPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiSearchPanel.Location = new System.Drawing.Point(0, 0);
            this.uiSearchPanel.Name = "uiSearchPanel";
            this.uiSearchPanel.Size = new System.Drawing.Size(811, 33);
            this.uiSearchPanel.TabIndex = 0;
            // 
            // uiSearchButton
            // 
            this.uiSearchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiSearchButton.Location = new System.Drawing.Point(733, 6);
            this.uiSearchButton.Name = "uiSearchButton";
            this.uiSearchButton.Size = new System.Drawing.Size(75, 21);
            this.uiSearchButton.TabIndex = 1;
            this.uiSearchButton.Text = "Search";
            this.uiSearchButton.UseVisualStyleBackColor = true;
            // 
            // uiSearchTextBox
            // 
            this.uiSearchTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiSearchTextBox.Location = new System.Drawing.Point(514, 7);
            this.uiSearchTextBox.Name = "uiSearchTextBox";
            this.uiSearchTextBox.Size = new System.Drawing.Size(213, 20);
            this.uiSearchTextBox.TabIndex = 0;
            // 
            // uiPaginationPanel
            // 
            this.uiPaginationPanel.Controls.Add(this.uiLastPageButton);
            this.uiPaginationPanel.Controls.Add(this.uiNextPageButton);
            this.uiPaginationPanel.Controls.Add(this.uiPreviousPageButton);
            this.uiPaginationPanel.Controls.Add(this.uiFirstPageButton);
            this.uiPaginationPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.uiPaginationPanel.Location = new System.Drawing.Point(0, 534);
            this.uiPaginationPanel.Name = "uiPaginationPanel";
            this.uiPaginationPanel.Size = new System.Drawing.Size(811, 39);
            this.uiPaginationPanel.TabIndex = 0;
            // 
            // uiFirstPageButton
            // 
            this.uiFirstPageButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.uiFirstPageButton.Location = new System.Drawing.Point(221, 8);
            this.uiFirstPageButton.Name = "uiFirstPageButton";
            this.uiFirstPageButton.Size = new System.Drawing.Size(75, 23);
            this.uiFirstPageButton.TabIndex = 0;
            this.uiFirstPageButton.Text = "<<";
            this.uiFirstPageButton.UseVisualStyleBackColor = true;
            // 
            // uiPreviousPageButton
            // 
            this.uiPreviousPageButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.uiPreviousPageButton.Location = new System.Drawing.Point(302, 8);
            this.uiPreviousPageButton.Name = "uiPreviousPageButton";
            this.uiPreviousPageButton.Size = new System.Drawing.Size(75, 23);
            this.uiPreviousPageButton.TabIndex = 1;
            this.uiPreviousPageButton.Text = "<";
            this.uiPreviousPageButton.UseVisualStyleBackColor = true;
            // 
            // uiNextPageButton
            // 
            this.uiNextPageButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.uiNextPageButton.Location = new System.Drawing.Point(425, 8);
            this.uiNextPageButton.Name = "uiNextPageButton";
            this.uiNextPageButton.Size = new System.Drawing.Size(75, 23);
            this.uiNextPageButton.TabIndex = 2;
            this.uiNextPageButton.Text = ">";
            this.uiNextPageButton.UseVisualStyleBackColor = true;
            // 
            // uiLastPageButton
            // 
            this.uiLastPageButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.uiLastPageButton.Location = new System.Drawing.Point(506, 8);
            this.uiLastPageButton.Name = "uiLastPageButton";
            this.uiLastPageButton.Size = new System.Drawing.Size(75, 23);
            this.uiLastPageButton.TabIndex = 3;
            this.uiLastPageButton.Text = ">>";
            this.uiLastPageButton.UseVisualStyleBackColor = true;
            // 
            // AuditTabControlPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uiAuditTabsPanel);
            this.Name = "AuditTabControlPanel";
            this.Size = new System.Drawing.Size(811, 606);
            this.uiAuditTabsPanel.ResumeLayout(false);
            this.uiGridViewPanel.ResumeLayout(false);
            this.uiSearchPanel.ResumeLayout(false);
            this.uiSearchPanel.PerformLayout();
            this.uiPaginationPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel uiAuditTabsPanel;
        private System.Windows.Forms.Panel uiGridViewPanel;
        private System.Windows.Forms.Panel uiSearchPanel;
        private System.Windows.Forms.Button uiSearchButton;
        private System.Windows.Forms.TextBox uiSearchTextBox;
        private System.Windows.Forms.Panel uiPaginationPanel;
        private System.Windows.Forms.Button uiLastPageButton;
        private System.Windows.Forms.Button uiNextPageButton;
        private System.Windows.Forms.Button uiPreviousPageButton;
        private System.Windows.Forms.Button uiFirstPageButton;
    }
}
