namespace OSIRT.UI.BrowserOptions
{
    partial class BrowserOptionsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BrowserOptionsForm));
            this.uiBrowserOptionsGroupBox = new System.Windows.Forms.GroupBox();
            this.uiTorDisabledLabel = new System.Windows.Forms.Label();
            this.uiConnectToTorCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.uiUserAgentsComboBox = new System.Windows.Forms.ComboBox();
            this.uiUserAgentListLinkLabel = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.uiOKButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.uiTorControlPortTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.uiTorProxyTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.uiBrowserProxyTextBox = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.uiDisablePluginsCheckBox = new System.Windows.Forms.CheckBox();
            this.uiDisableImagesCheckBox = new System.Windows.Forms.CheckBox();
            this.uiDisableJSCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.uiWebDownloadModeCheckBox = new System.Windows.Forms.CheckBox();
            this.uiBrowserOptionsGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiBrowserOptionsGroupBox
            // 
            this.uiBrowserOptionsGroupBox.Controls.Add(this.uiTorDisabledLabel);
            this.uiBrowserOptionsGroupBox.Controls.Add(this.uiConnectToTorCheckBox);
            this.uiBrowserOptionsGroupBox.Location = new System.Drawing.Point(8, 35);
            this.uiBrowserOptionsGroupBox.Name = "uiBrowserOptionsGroupBox";
            this.uiBrowserOptionsGroupBox.Size = new System.Drawing.Size(489, 47);
            this.uiBrowserOptionsGroupBox.TabIndex = 0;
            this.uiBrowserOptionsGroupBox.TabStop = false;
            this.uiBrowserOptionsGroupBox.Text = "Tor Network";
            // 
            // uiTorDisabledLabel
            // 
            this.uiTorDisabledLabel.AutoSize = true;
            this.uiTorDisabledLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiTorDisabledLabel.ForeColor = System.Drawing.Color.Red;
            this.uiTorDisabledLabel.Location = new System.Drawing.Point(6, 18);
            this.uiTorDisabledLabel.Name = "uiTorDisabledLabel";
            this.uiTorDisabledLabel.Size = new System.Drawing.Size(224, 16);
            this.uiTorDisabledLabel.TabIndex = 1;
            this.uiTorDisabledLabel.Text = "Tor is disabled on this machine";
            this.uiTorDisabledLabel.Visible = false;
            // 
            // uiConnectToTorCheckBox
            // 
            this.uiConnectToTorCheckBox.AutoSize = true;
            this.uiConnectToTorCheckBox.Location = new System.Drawing.Point(6, 19);
            this.uiConnectToTorCheckBox.Name = "uiConnectToTorCheckBox";
            this.uiConnectToTorCheckBox.Size = new System.Drawing.Size(161, 17);
            this.uiConnectToTorCheckBox.TabIndex = 0;
            this.uiConnectToTorCheckBox.Text = "Connect via the Tor network";
            this.uiConnectToTorCheckBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(5, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(361, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "These options are for advanced users who have received relevant training.\r\n ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.uiUserAgentsComboBox);
            this.groupBox1.Controls.Add(this.uiUserAgentListLinkLabel);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(8, 88);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(489, 68);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Spoof User Agent";
            // 
            // uiUserAgentsComboBox
            // 
            this.uiUserAgentsComboBox.FormattingEnabled = true;
            this.uiUserAgentsComboBox.Location = new System.Drawing.Point(9, 18);
            this.uiUserAgentsComboBox.Name = "uiUserAgentsComboBox";
            this.uiUserAgentsComboBox.Size = new System.Drawing.Size(474, 21);
            this.uiUserAgentsComboBox.TabIndex = 4;
            // 
            // uiUserAgentListLinkLabel
            // 
            this.uiUserAgentListLinkLabel.AutoSize = true;
            this.uiUserAgentListLinkLabel.Location = new System.Drawing.Point(240, 42);
            this.uiUserAgentListLinkLabel.Name = "uiUserAgentListLinkLabel";
            this.uiUserAgentListLinkLabel.Size = new System.Drawing.Size(231, 13);
            this.uiUserAgentListLinkLabel.TabIndex = 2;
            this.uiUserAgentListLinkLabel.TabStop = true;
            this.uiUserAgentListLinkLabel.Text = "Click here for a list of user agents (no affiliation).";
            this.uiUserAgentListLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.uiUserAgentListLinkLabel_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(238, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Select or enter a user agent from the box above. ";
            // 
            // uiOKButton
            // 
            this.uiOKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.uiOKButton.Location = new System.Drawing.Point(421, 400);
            this.uiOKButton.Name = "uiOKButton";
            this.uiOKButton.Size = new System.Drawing.Size(75, 23);
            this.uiOKButton.TabIndex = 2;
            this.uiOKButton.Text = "OK";
            this.uiOKButton.UseVisualStyleBackColor = true;
            this.uiOKButton.Click += new System.EventHandler(this.uiOKButton_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(343, 400);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.uiTorControlPortTextBox);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.uiTorProxyTextBox);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.uiBrowserProxyTextBox);
            this.groupBox2.Location = new System.Drawing.Point(8, 162);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(489, 61);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Proxy Settings";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(203, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Tor Control Port (default 9050 if left blank)";
            this.label6.Visible = false;
            // 
            // uiTorControlPortTextBox
            // 
            this.uiTorControlPortTextBox.Location = new System.Drawing.Point(4, 119);
            this.uiTorControlPortTextBox.Name = "uiTorControlPortTextBox";
            this.uiTorControlPortTextBox.Size = new System.Drawing.Size(479, 20);
            this.uiTorControlPortTextBox.TabIndex = 4;
            this.uiTorControlPortTextBox.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(205, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Tor Proxy (default is 127.0.0.1 if left blank)";
            this.label5.Visible = false;
            // 
            // uiTorProxyTextBox
            // 
            this.uiTorProxyTextBox.Location = new System.Drawing.Point(4, 75);
            this.uiTorProxyTextBox.Name = "uiTorProxyTextBox";
            this.uiTorProxyTextBox.Size = new System.Drawing.Size(479, 20);
            this.uiTorProxyTextBox.TabIndex = 2;
            this.uiTorProxyTextBox.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(191, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Browser Proxy  (leave blank for default)";
            // 
            // uiBrowserProxyTextBox
            // 
            this.uiBrowserProxyTextBox.Location = new System.Drawing.Point(4, 32);
            this.uiBrowserProxyTextBox.Name = "uiBrowserProxyTextBox";
            this.uiBrowserProxyTextBox.Size = new System.Drawing.Size(479, 20);
            this.uiBrowserProxyTextBox.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.uiDisablePluginsCheckBox);
            this.groupBox3.Controls.Add(this.uiDisableImagesCheckBox);
            this.groupBox3.Controls.Add(this.uiDisableJSCheckBox);
            this.groupBox3.Location = new System.Drawing.Point(10, 229);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(487, 72);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Browser Settings ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(224, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "These settings work reset after OSIRT closes.";
            // 
            // uiDisablePluginsCheckBox
            // 
            this.uiDisablePluginsCheckBox.AutoSize = true;
            this.uiDisablePluginsCheckBox.Location = new System.Drawing.Point(243, 19);
            this.uiDisablePluginsCheckBox.Name = "uiDisablePluginsCheckBox";
            this.uiDisablePluginsCheckBox.Size = new System.Drawing.Size(112, 17);
            this.uiDisablePluginsCheckBox.TabIndex = 2;
            this.uiDisablePluginsCheckBox.Text = "Disable All Plugins";
            this.uiDisablePluginsCheckBox.UseVisualStyleBackColor = true;
            this.uiDisablePluginsCheckBox.CheckedChanged += new System.EventHandler(this.uiDisablePluginsCheckBox_CheckedChanged);
            // 
            // uiDisableImagesCheckBox
            // 
            this.uiDisableImagesCheckBox.AutoSize = true;
            this.uiDisableImagesCheckBox.Location = new System.Drawing.Point(129, 19);
            this.uiDisableImagesCheckBox.Name = "uiDisableImagesCheckBox";
            this.uiDisableImagesCheckBox.Size = new System.Drawing.Size(98, 17);
            this.uiDisableImagesCheckBox.TabIndex = 1;
            this.uiDisableImagesCheckBox.Text = "Disable Images";
            this.uiDisableImagesCheckBox.UseVisualStyleBackColor = true;
            this.uiDisableImagesCheckBox.CheckedChanged += new System.EventHandler(this.uiDisableImagesCheckBox_CheckedChanged);
            // 
            // uiDisableJSCheckBox
            // 
            this.uiDisableJSCheckBox.AutoSize = true;
            this.uiDisableJSCheckBox.Location = new System.Drawing.Point(6, 19);
            this.uiDisableJSCheckBox.Name = "uiDisableJSCheckBox";
            this.uiDisableJSCheckBox.Size = new System.Drawing.Size(114, 17);
            this.uiDisableJSCheckBox.TabIndex = 0;
            this.uiDisableJSCheckBox.Text = "Disable JavaScript";
            this.uiDisableJSCheckBox.UseVisualStyleBackColor = true;
            this.uiDisableJSCheckBox.CheckedChanged += new System.EventHandler(this.uiDisableJSCheckBox_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.uiWebDownloadModeCheckBox);
            this.groupBox4.Location = new System.Drawing.Point(8, 307);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(487, 87);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Website Download";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(442, 39);
            this.label3.TabIndex = 1;
            this.label3.Text = resources.GetString("label3.Text");
            // 
            // uiWebDownloadModeCheckBox
            // 
            this.uiWebDownloadModeCheckBox.AutoSize = true;
            this.uiWebDownloadModeCheckBox.Checked = true;
            this.uiWebDownloadModeCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.uiWebDownloadModeCheckBox.Location = new System.Drawing.Point(6, 19);
            this.uiWebDownloadModeCheckBox.Name = "uiWebDownloadModeCheckBox";
            this.uiWebDownloadModeCheckBox.Size = new System.Drawing.Size(166, 17);
            this.uiWebDownloadModeCheckBox.TabIndex = 0;
            this.uiWebDownloadModeCheckBox.Text = "Enable Web Download Mode";
            this.uiWebDownloadModeCheckBox.UseVisualStyleBackColor = true;
            this.uiWebDownloadModeCheckBox.CheckedChanged += new System.EventHandler(this.uiDownloadModeCheckBox_CheckedChanged);
            // 
            // BrowserOptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 432);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.uiOKButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.uiBrowserOptionsGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BrowserOptionsForm";
            this.Text = "Advanced Browser Options";
            this.Load += new System.EventHandler(this.BrowserOptionsForm_Load);
            this.uiBrowserOptionsGroupBox.ResumeLayout(false);
            this.uiBrowserOptionsGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox uiBrowserOptionsGroupBox;
        private System.Windows.Forms.CheckBox uiConnectToTorCheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.LinkLabel uiUserAgentListLinkLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button uiOKButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox uiBrowserProxyTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox uiTorProxyTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox uiTorControlPortTextBox;
        private System.Windows.Forms.Label uiTorDisabledLabel;
        private System.Windows.Forms.ComboBox uiUserAgentsComboBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox uiDisablePluginsCheckBox;
        private System.Windows.Forms.CheckBox uiDisableImagesCheckBox;
        private System.Windows.Forms.CheckBox uiDisableJSCheckBox;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox uiWebDownloadModeCheckBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
    }
}