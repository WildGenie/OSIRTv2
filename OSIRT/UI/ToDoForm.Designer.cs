namespace OSIRT.UI
{
    partial class ToDoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ToDoForm));
            this.uiToDoUrlDataGridView = new System.Windows.Forms.DataGridView();
            this.uiExportToDoButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.uiToDoUrlDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // uiToDoUrlDataGridView
            // 
            this.uiToDoUrlDataGridView.AllowUserToAddRows = false;
            this.uiToDoUrlDataGridView.AllowUserToDeleteRows = false;
            this.uiToDoUrlDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiToDoUrlDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.uiToDoUrlDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.uiToDoUrlDataGridView.Location = new System.Drawing.Point(2, 0);
            this.uiToDoUrlDataGridView.Name = "uiToDoUrlDataGridView";
            this.uiToDoUrlDataGridView.RowHeadersVisible = false;
            this.uiToDoUrlDataGridView.Size = new System.Drawing.Size(484, 424);
            this.uiToDoUrlDataGridView.TabIndex = 0;
            // 
            // uiExportToDoButton
            // 
            this.uiExportToDoButton.Location = new System.Drawing.Point(382, 428);
            this.uiExportToDoButton.Name = "uiExportToDoButton";
            this.uiExportToDoButton.Size = new System.Drawing.Size(104, 23);
            this.uiExportToDoButton.TabIndex = 1;
            this.uiExportToDoButton.Text = "Export To Do List";
            this.uiExportToDoButton.UseVisualStyleBackColor = true;
            this.uiExportToDoButton.Click += new System.EventHandler(this.uiExportToDoButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 428);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(332, 26);
            this.label1.TabIndex = 2;
            this.label1.Text = "To Do list is deleted after OSIRT closes. \r\nYou may export your links to a text f" +
    "ile by clicking \"Export To Do List\"";
            // 
            // ToDoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 463);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.uiExportToDoButton);
            this.Controls.Add(this.uiToDoUrlDataGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ToDoForm";
            this.Text = "To Do";
            this.Load += new System.EventHandler(this.ToDoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uiToDoUrlDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView uiToDoUrlDataGridView;
        private System.Windows.Forms.Button uiExportToDoButton;
        private System.Windows.Forms.Label label1;
    }
}