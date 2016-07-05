using OSIRT.UI.AuditLog;
using OSIRT.UI.CaseClosing;
using System;
using System.Windows.Forms;

namespace OSIRT.UI
{
    public partial class FirstLoadPanel : UserControl
    {

        public event EventHandler NewCaseClick;
        public event EventHandler LoadOldCaseClick;
        //public event EventHandler LoadReport_Click;

        public FirstLoadPanel()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
           
        }

   

        private void uiFirstLoadPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void uiNewCaseButton_Click(object sender, EventArgs e)
        {
            NewCaseClick?.Invoke(this, e);
        }

        private void uiNewCaseButton_MouseHover(object sender, EventArgs e)
        {
            uiHelpLabelLabel.Text = Resources.strings.NewCase;
        }

        private void uiLoadExistingCaseButton_MouseHover(object sender, EventArgs e)
        {
            uiHelpLabelLabel.Text = Resources.strings.ExisitingCase;
        }

        private void uiLoadReportButton_MouseHover(object sender, EventArgs e)
        {
            uiHelpLabelLabel.Text = Resources.strings.LoadReport;
        }

        private void uiImagePanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void uiLoadExistingCaseButton_Click(object sender, EventArgs e)
        {
            LoadOldCaseClick?.Invoke(this, e);
        }

        private void uiLoadReportButton_Click(object sender, EventArgs e)
        {

            //TODO: this logic is in the load exisiting case panel
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
            LoadExistingCasePanel exisitingCasePanel = new LoadExistingCasePanel(new System.IO.FileInfo(filenameWithPath), true);
            Controls.Add(exisitingCasePanel);
            exisitingCasePanel.PasswordCheckClick += ExisitingCasePanel_PasswordCheckClick;

        }

        private void ExisitingCasePanel_PasswordCheckClick(object sender, EventArgs e)
        {
            //TODO: logic also exists in load exisiting case panel/close case panels
            //this is a test of functionality

            //if password is fine, open audit log
            Controls.Clear();

            using (AuditLogForm audit = new AuditLogForm()) 
            {
                audit.ShowDialog();
            }


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

        private void ClosePanel_PasswordCorrect(object sender, CaseClosingEventArgs args)
        {
            Controls.Clear();
            //add new closing panel
            CaseClosingCleanUpPanel cleanUpPanel = new CaseClosingCleanUpPanel(args.Password);
            Controls.Add(cleanUpPanel);
        }

        private void uiFixCaseButton_MouseHover(object sender, EventArgs e)
        {
            uiHelpLabelLabel.Text = "Restore an extraced OSIRT case.";
        }

        private void uiFixCaseButton_Click(object sender, EventArgs e)
        {
            using(RestoreCaseForm restoreCase = new RestoreCaseForm())
            {
                restoreCase.ShowDialog();
            }
        }
    }
}
