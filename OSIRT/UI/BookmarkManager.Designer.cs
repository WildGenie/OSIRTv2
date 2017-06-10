namespace OSIRT.UI
{
    partial class BookmarkManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BookmarkManager));
            this.uiBookmarksDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.uiBookmarksDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // uiBookmarksDataGridView
            // 
            this.uiBookmarksDataGridView.AllowUserToAddRows = false;
            this.uiBookmarksDataGridView.AllowUserToDeleteRows = false;
            this.uiBookmarksDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.uiBookmarksDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.uiBookmarksDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiBookmarksDataGridView.Location = new System.Drawing.Point(0, 0);
            this.uiBookmarksDataGridView.Name = "uiBookmarksDataGridView";
            this.uiBookmarksDataGridView.RowHeadersVisible = false;
            this.uiBookmarksDataGridView.Size = new System.Drawing.Size(529, 429);
            this.uiBookmarksDataGridView.TabIndex = 0;
            this.uiBookmarksDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.uiBookmarksDataGridView_CellClick);
            this.uiBookmarksDataGridView.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.uiBookmarksDataGridView_CellMouseEnter);
            // 
            // BookmarkManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 429);
            this.Controls.Add(this.uiBookmarksDataGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BookmarkManager";
            this.Text = "Bookmark Manager";
            this.Load += new System.EventHandler(this.BookmarkManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uiBookmarksDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView uiBookmarksDataGridView;
    }
}