using FastColoredTextBoxNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSIRT.UI.ViewSource
{
    public class ViewPageSource : Form
    {
        private FastColoredTextBox fctb;


        public ViewPageSource(string source, string title)
        {
            fctb = new FastColoredTextBox();
            fctb.ReadOnly = true;
            Controls.Add(fctb);
            fctb.Dock = DockStyle.Fill;
            fctb.Language = Language.HTML;
            fctb.WordWrap = true;
            fctb.Text = source;
            Text = $"{title}";
            Size = new System.Drawing.Size(800, 600);
            Icon = Properties.Resources.source_code1;
        }


        private void ViewPageSource_Load(object sender, EventArgs e)
        {
        
  
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewPageSource));
            this.SuspendLayout();
            // 
            // ViewPageSource
            // 
            this.ClientSize = new System.Drawing.Size(947, 559);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ViewPageSource";
            this.Load += new System.EventHandler(this.ViewPageSource_Load);
            this.ResumeLayout(false);

        }
    }
}
