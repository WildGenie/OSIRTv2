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
using System.IO.Compression;

namespace OSIRT
{
    public partial class MainForm : Form
    {

   
        public MainForm()
        {
            InitializeComponent();
            this.FormClosing += MainForm_FormClosing;

        }

        void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Check file exists before creating the zip
            //using a file extension that is not .zip seems fine, but not checked unzipping

            //ZipFile.CreateFromDirectory(Path.Combine(Constants.Directories.CasePath + "\\" + Constants.Directories.CaseContainerName), @"D:/joe.osirt", CompressionLevel.NoCompression, true);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FirstLoadPanel firstLoadPanel = new FirstLoadPanel();
            firstLoadPanel.NewCase_Click += firstLoadPanel_NewCase_Click;
            firstLoadPanel.LoadOldCase_Click += FirstLoadPanel_LoadOldCase_Click;
            this.Controls.Add(firstLoadPanel);
        }

        private void FirstLoadPanel_LoadOldCase_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();
                if (result != DialogResult.OK)
                    return;

                //TODO: Validate this is a valid case container
                string caseContainer = fbd.SelectedPath;
                DirectoryInfo parentDir = Directory.GetParent(caseContainer);
                Constants.CasePath = parentDir.FullName;
                Constants.CaseContainerName = Path.GetFileName(caseContainer);
                ShowBrowserPanel();

            }
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
            ShowBrowserPanel();
        }

        private void ShowBrowserPanel()
        {
            this.Controls.Clear();
            BrowserPanel browserPanel = new BrowserPanel();
            this.Controls.Add(browserPanel);
            this.WindowState = FormWindowState.Maximized;
        }

  

     }
}
