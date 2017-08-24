namespace OSIRT.UI.HistoryViewer
{
    partial class HistoryViewForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HistoryViewForm));
            this.uiHistoryDataGridView = new System.Windows.Forms.DataGridView();
            this.uiSearchTextBox = new System.Windows.Forms.TextBox();
            this.uiSearchButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.uiHistoryDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // uiHistoryDataGridView
            // 
            this.uiHistoryDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiHistoryDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.uiHistoryDataGridView.Location = new System.Drawing.Point(3, 38);
            this.uiHistoryDataGridView.Name = "uiHistoryDataGridView";
            this.uiHistoryDataGridView.Size = new System.Drawing.Size(540, 444);
            this.uiHistoryDataGridView.TabIndex = 0;
            this.uiHistoryDataGridView.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.uiHistoryDataGridView_CellMouseEnter);
            // 
            // uiSearchTextBox
            // 
            this.uiSearchTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiSearchTextBox.Location = new System.Drawing.Point(277, 10);
            this.uiSearchTextBox.Name = "uiSearchTextBox";
            this.uiSearchTextBox.Size = new System.Drawing.Size(183, 20);
            this.uiSearchTextBox.TabIndex = 1;
            this.uiSearchTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.uiSearchTextBox_KeyUp);
            // 
            // uiSearchButton
            // 
            this.uiSearchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiSearchButton.Location = new System.Drawing.Point(463, 9);
            this.uiSearchButton.Name = "uiSearchButton";
            this.uiSearchButton.Size = new System.Drawing.Size(75, 23);
            this.uiSearchButton.TabIndex = 2;
            this.uiSearchButton.Text = "Search";
            this.uiSearchButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 26);
            this.label1.TabIndex = 3;
            this.label1.Text = "History is stored in memory only, and is deleted \r\nonce OSIRT closes.";
            // 
            // HistoryViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 486);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.uiSearchButton);
            this.Controls.Add(this.uiSearchTextBox);
            this.Controls.Add(this.uiHistoryDataGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HistoryViewForm";
            this.Text = "History";
            this.Load += new System.EventHandler(this.HistoryViewForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uiHistoryDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView uiHistoryDataGridView;
        private System.Windows.Forms.TextBox uiSearchTextBox;
        private System.Windows.Forms.Button uiSearchButton;
        private System.Windows.Forms.Label label1;
    }
}