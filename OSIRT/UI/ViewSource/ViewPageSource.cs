using FastColoredTextBoxNS;
using OSIRT.Helpers;
using OSIRT.Loggers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSIRT.UI.ViewSource
{
    public class ViewPageSource : Form
    {
        private ToolStrip toolStrip1;
        private ToolStripButton uiSaveSourceToolStripButton;
        private FastColoredTextBox fctb;
        private Panel uiSourcePanel;
        private Enums.Actions action;

        //private Panel SourcePanel;
        private Tuple<string, string, string> domainUrlAndTitle;

        public ViewPageSource(string source, Enums.Actions action, Tuple<string, string, string> domainUrlAndTitle)
        {
            InitializeComponent();
            this.domainUrlAndTitle = domainUrlAndTitle;
            this.action = action;
            fctb = new FastColoredTextBox();
            fctb.ReadOnly = true;
            fctb.Dock = DockStyle.Fill;
            fctb.Language = Language.HTML;
            fctb.WordWrap = true;
            fctb.Text = source;
            Size = new System.Drawing.Size(800, 600);
            Icon = Properties.Resources.source_code1;
            Text = $"Viewing {action.ToString()} for {domainUrlAndTitle.Item1}";
            uiSourcePanel.Controls.Add(fctb);
            //toolStrip1.ImageScalingSize = new Size(40, 40);
        }

        private void uiSaveSourceToolStripButton_Click(object sender, EventArgs e)
        {
            string filename = Constants.PageSourceFileName.Replace("%%dt%%", DateTime.Now.ToString("yyyy-MM-dd_hh_mm_ss")).Replace("%%name%%", domainUrlAndTitle.Item1).Replace("%%action%%", action.ToString());
            string path = Path.Combine(Constants.ContainerLocation, Constants.Directories.GetSpecifiedCaseDirectory(action), filename);
            using (FileStream fileStream = new FileStream(path, FileMode.Create))
            {
                using (StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.UTF8))
                {
                    streamWriter.WriteLine(fctb.Text);
                }
            }

            Logger.Log(new WebpageActionsLog(domainUrlAndTitle.Item2, action, OsirtHelper.GetFileHash(path), filename, $"[{action.ToString()} downloaded]"));
            MessageBox.Show("Save successful", $"Saved - {action.ToString()}", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void ViewPageSource_Load(object sender, EventArgs e)
        {
        
  
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewPageSource));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.uiSaveSourceToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.uiSourcePanel = new System.Windows.Forms.Panel();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uiSaveSourceToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(947, 37);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // uiSaveSourceToolStripButton
            // 
            this.uiSaveSourceToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.uiSaveSourceToolStripButton.Image = global::OSIRT.Properties.Resources.save_close;
            this.uiSaveSourceToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uiSaveSourceToolStripButton.Name = "uiSaveSourceToolStripButton";
            this.uiSaveSourceToolStripButton.Size = new System.Drawing.Size(36, 34);
            this.uiSaveSourceToolStripButton.ToolTipText = "Save";
            this.uiSaveSourceToolStripButton.Click += new System.EventHandler(this.uiSaveSourceToolStripButton_Click);
            // 
            // uiSourcePanel
            // 
            this.uiSourcePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiSourcePanel.Location = new System.Drawing.Point(0, 37);
            this.uiSourcePanel.Name = "uiSourcePanel";
            this.uiSourcePanel.Size = new System.Drawing.Size(947, 522);
            this.uiSourcePanel.TabIndex = 1;
            // 
            // ViewPageSource
            // 
            this.ClientSize = new System.Drawing.Size(947, 559);
            this.Controls.Add(this.uiSourcePanel);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ViewPageSource";
            this.Load += new System.EventHandler(this.ViewPageSource_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }


    }
}
