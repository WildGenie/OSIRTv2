using ImageMagick;
using Jacksonsoft;
using mshtml;
using OSIRT.Browser;
using OSIRT.Helpers;
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
            firstLoadPanel.NewCase_Click += firstLoadPanel_NewCase_Click;
            this.Controls.Add(firstLoadPanel);
        }

        void firstLoadPanel_NewCase_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            CaseDetailsPanel caseDetailsPanel = new CaseDetailsPanel();
            this.Controls.Add(caseDetailsPanel);
            caseDetailsPanel.NextClick += new EventHandler(caseDetailsPanel_NextClick);
        }

        protected void caseDetailsPanel_NextClick(object sender, EventArgs e)
        {
            this.Controls.Clear();
            new CaseCreator();

            BrowserPanel browserPanel = new BrowserPanel();
            this.Controls.Add(browserPanel);
            this.WindowState = FormWindowState.Maximized;
        }

     }
}
