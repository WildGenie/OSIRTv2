using ImageMagick;
using Jacksonsoft;
using mshtml;
using OSIRT.Browser;
using OSIRT.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSIRT
{
    public partial class MainForm : Form
    {
      
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            FirstLoadPanel firstLoadPanel = new FirstLoadPanel();
            this.Controls.Add(firstLoadPanel);
            
            
            //CaseDetailsPanel caseDetailsPanel = new CaseDetailsPanel();
            //caseDetailsPanel.NextClick += new EventHandler(caseDetailsPanel_NextClick);

            //this.Controls.Add(caseDetailsPanel);
        
        }

        protected void caseDetailsPanel_NextClick(object sender, EventArgs e)
        {
            this.Controls.Clear();
            BrowserPanel browserPanel = new BrowserPanel();
            this.Controls.Add(browserPanel);
            this.WindowState = FormWindowState.Maximized;
        }

     }
}
