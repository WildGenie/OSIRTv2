using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Ionic.Zip;
using Jacksonsoft;
using OSIRT.Helpers;
using OSIRT.Resources;
using OSIRT.UI.CaseClosing;
using OSIRT.Loggers;
using System.Drawing;

namespace OSIRT.UI
{
    public partial class MainForm : Form
    {
        private bool caseOpened;
        private bool caseClosed;

        //http://stackoverflow.com/questions/2612487/how-to-fix-the-flickering-in-user-controls
        //TODO@ need to look at this for hosted controls
        protected override CreateParams CreateParams
        {
            get
            {
                var parms = base.CreateParams;
                parms.Style &= ~0x02000000;  // Turn off WS_CLIPCHILDREN
                return parms;
            }
        }


       
        public MainForm()
        {
            InitializeComponent();
            FormClosing += MainForm_FormClosing;

        }

        void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!caseOpened || caseClosed)
            {
                e.Cancel = false;
                return;
            }

            e.Cancel = true;
            DialogResult result = MessageBox.Show(strings.In_order_to_safely_close_a_case__you_are_required_to_enter_the_case_password__Would_you_like_to_enter_the_case_password_now_, "Close Current Case?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (result != DialogResult.Cancel || result != DialogResult.No)
            {
                caseClosed = true;
                ClosingOsirt();
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            FirstLoadPanel firstLoadPanel = new FirstLoadPanel();
            firstLoadPanel.NewCaseClick += firstLoadPanel_NewCase_Click;
            firstLoadPanel.LoadOldCaseClick += FirstLoadPanel_LoadOldCase_Click;
            Controls.Add(firstLoadPanel);
    }

        private void FirstLoadPanel_LoadOldCase_Click(object sender, EventArgs e)
        {
            string filenameWithPath;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "OSR Files|*.osr";
                DialogResult result = openFileDialog.ShowDialog();
                if (result != DialogResult.OK)
                    return;

                filenameWithPath = openFileDialog.FileName;
            }

            Controls.Clear();
            LoadExistingCasePanel exisitingCasePanel = new LoadExistingCasePanel(new FileInfo(filenameWithPath));
            Controls.Add(exisitingCasePanel);
            exisitingCasePanel.PasswordCheckClick += ExisitingCasePanel_PasswordCheckClick;

        }

        private void ExisitingCasePanel_PasswordCheckClick(object sender, EventArgs e)
        {
            ShowBrowserPanelAndLogOpening();
        }


        void firstLoadPanel_NewCase_Click(object sender, EventArgs e)
        {
            Controls.Clear();
            CaseDetailsPanel2 caseDetailsPanel = new CaseDetailsPanel2();
            Controls.Add(caseDetailsPanel);
            caseDetailsPanel.NextClick += new EventHandler(caseDetailsPanel_NextClick);
        }

        protected void caseDetailsPanel_NextClick(object sender, EventArgs e)
        {
            ShowBrowserPanelAndLogOpening();
        }

        private void ShowBrowserPanelAndLogOpening()
        {
            ShowBrowserPanel();
            caseOpened = true;
            OsirtLogWriter.Write(Constants.ContainerLocation, false);
        }

        private void ShowBrowserPanel()
        {
            Controls.Clear();
            BrowserPanel browserPanel = new BrowserPanel();
            Controls.Add(browserPanel);
            WindowState = FormWindowState.Maximized;
            browserPanel.CaseClosing += BrowserPanel_CaseClosing;
        }

        //event from menu item
        private void BrowserPanel_CaseClosing(object sender, EventArgs e)
        {
            caseClosed = true;
            ClosingOsirt();
        }

        private void ClosingOsirt()
        {
            Controls.Clear();

            //UserSettings.Load().CaseHasPassword
            bool caseHasPassword = new Database.DatabaseHandler().CaseHasPassword();
            if (caseHasPassword)
            {
                CloseCasePanel closePanel = new CloseCasePanel();
                Controls.Add(closePanel);
                closePanel.PasswordCorrect += ClosePanel_PasswordCorrect;
            }
            else
            {
                CaseClosingCleanUpPanel cleanUpPanel = new CaseClosingCleanUpPanel("");
                Controls.Add(cleanUpPanel);
            }
        }

        private void ClosePanel_PasswordCorrect(object sender, CaseClosingEventArgs e)
        {
            Controls.Clear();
            //add new closing panel
            CaseClosingCleanUpPanel cleanUpPanel = new CaseClosingCleanUpPanel(e.Password);
            Controls.Add(cleanUpPanel);

            //CloseOsirt(e.Password);
            //Close();
        }
    }
}
