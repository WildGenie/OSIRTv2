namespace OSIRT.UI
{
    partial class FirstLoadPanel
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
            this.uiFirstLoadPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.uiFixCaseButton = new System.Windows.Forms.Button();
            this.uiHelpLabelLabel = new System.Windows.Forms.Label();
            this.uiImagePanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.uiNewCaseButton = new System.Windows.Forms.Button();
            this.uiLoadExistingCaseButton = new System.Windows.Forms.Button();
            this.uiLoadReportButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.uiFirstLoadPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiFirstLoadPanel
            // 
            this.uiFirstLoadPanel.Controls.Add(this.panel1);
            this.uiFirstLoadPanel.Controls.Add(this.uiImagePanel);
            this.uiFirstLoadPanel.Controls.Add(this.tableLayoutPanel1);
            this.uiFirstLoadPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiFirstLoadPanel.Location = new System.Drawing.Point(0, 0);
            this.uiFirstLoadPanel.Name = "uiFirstLoadPanel";
            this.uiFirstLoadPanel.Size = new System.Drawing.Size(995, 691);
            this.uiFirstLoadPanel.TabIndex = 0;
            this.uiFirstLoadPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.uiFirstLoadPanel_Paint);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.panel1.Controls.Add(this.uiFixCaseButton);
            this.panel1.Controls.Add(this.uiHelpLabelLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 582);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(995, 109);
            this.panel1.TabIndex = 2;
            // 
            // uiFixCaseButton
            // 
            this.uiFixCaseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.uiFixCaseButton.BackColor = System.Drawing.Color.Transparent;
            this.uiFixCaseButton.BackgroundImage = global::OSIRT.Properties.Resources.fix_case;
            this.uiFixCaseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.uiFixCaseButton.FlatAppearance.BorderSize = 0;
            this.uiFixCaseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uiFixCaseButton.Location = new System.Drawing.Point(3, 67);
            this.uiFixCaseButton.Name = "uiFixCaseButton";
            this.uiFixCaseButton.Size = new System.Drawing.Size(39, 39);
            this.uiFixCaseButton.TabIndex = 4;
            this.uiFixCaseButton.UseVisualStyleBackColor = false;
            this.uiFixCaseButton.Click += new System.EventHandler(this.uiFixCaseButton_Click);
            this.uiFixCaseButton.MouseHover += new System.EventHandler(this.uiFixCaseButton_MouseHover);
            // 
            // uiHelpLabelLabel
            // 
            this.uiHelpLabelLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiHelpLabelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiHelpLabelLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.uiHelpLabelLabel.Location = new System.Drawing.Point(0, 0);
            this.uiHelpLabelLabel.Name = "uiHelpLabelLabel";
            this.uiHelpLabelLabel.Size = new System.Drawing.Size(995, 109);
            this.uiHelpLabelLabel.TabIndex = 0;
            this.uiHelpLabelLabel.Text = "Welcome to OSIRT. Select an option to begin.";
            this.uiHelpLabelLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiImagePanel
            // 
            this.uiImagePanel.BackColor = System.Drawing.SystemColors.Highlight;
            this.uiImagePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiImagePanel.Location = new System.Drawing.Point(0, 0);
            this.uiImagePanel.Name = "uiImagePanel";
            this.uiImagePanel.Size = new System.Drawing.Size(995, 97);
            this.uiImagePanel.TabIndex = 1;
            this.uiImagePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.uiImagePanel_Paint);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 179F));
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.uiNewCaseButton, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.uiLoadExistingCaseButton, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.uiLoadReportButton, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(224, 236);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 157F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(545, 194);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(369, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(173, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "View Case Audit Log";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(186, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Load Case";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiNewCaseButton
            // 
            this.uiNewCaseButton.BackColor = System.Drawing.Color.White;
            this.uiNewCaseButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiNewCaseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uiNewCaseButton.Image = global::OSIRT.Properties.Resources.add_folder_128;
            this.uiNewCaseButton.Location = new System.Drawing.Point(3, 3);
            this.uiNewCaseButton.Name = "uiNewCaseButton";
            this.uiNewCaseButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.uiNewCaseButton.Size = new System.Drawing.Size(177, 144);
            this.uiNewCaseButton.TabIndex = 0;
            this.uiNewCaseButton.UseVisualStyleBackColor = false;
            this.uiNewCaseButton.Click += new System.EventHandler(this.uiNewCaseButton_Click);
            this.uiNewCaseButton.MouseHover += new System.EventHandler(this.uiNewCaseButton_MouseHover);
            // 
            // uiLoadExistingCaseButton
            // 
            this.uiLoadExistingCaseButton.BackColor = System.Drawing.Color.White;
            this.uiLoadExistingCaseButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLoadExistingCaseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uiLoadExistingCaseButton.Image = global::OSIRT.Properties.Resources.documents_128;
            this.uiLoadExistingCaseButton.Location = new System.Drawing.Point(186, 3);
            this.uiLoadExistingCaseButton.Name = "uiLoadExistingCaseButton";
            this.uiLoadExistingCaseButton.Size = new System.Drawing.Size(177, 144);
            this.uiLoadExistingCaseButton.TabIndex = 1;
            this.uiLoadExistingCaseButton.UseVisualStyleBackColor = false;
            this.uiLoadExistingCaseButton.Click += new System.EventHandler(this.uiLoadExistingCaseButton_Click);
            this.uiLoadExistingCaseButton.MouseHover += new System.EventHandler(this.uiLoadExistingCaseButton_MouseHover);
            // 
            // uiLoadReportButton
            // 
            this.uiLoadReportButton.BackColor = System.Drawing.Color.White;
            this.uiLoadReportButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLoadReportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uiLoadReportButton.Image = global::OSIRT.Properties.Resources.view_details_128;
            this.uiLoadReportButton.Location = new System.Drawing.Point(369, 3);
            this.uiLoadReportButton.Name = "uiLoadReportButton";
            this.uiLoadReportButton.Size = new System.Drawing.Size(173, 144);
            this.uiLoadReportButton.TabIndex = 2;
            this.uiLoadReportButton.UseVisualStyleBackColor = false;
            this.uiLoadReportButton.Click += new System.EventHandler(this.uiLoadReportButton_Click);
            this.uiLoadReportButton.MouseHover += new System.EventHandler(this.uiLoadReportButton_MouseHover);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 163);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Create New Case";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FirstLoadPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uiFirstLoadPanel);
            this.Name = "FirstLoadPanel";
            this.Size = new System.Drawing.Size(995, 691);
            this.uiFirstLoadPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel uiFirstLoadPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button uiNewCaseButton;
        private System.Windows.Forms.Button uiLoadExistingCaseButton;
        private System.Windows.Forms.Button uiLoadReportButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel uiImagePanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label uiHelpLabelLabel;
        private System.Windows.Forms.Button uiFixCaseButton;
    }
}
