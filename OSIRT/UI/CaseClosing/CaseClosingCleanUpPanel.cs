using System;
using System.ComponentModel;
using System.Windows.Forms;
using OSIRT.Loggers;
using Ionic.Zip;
using System.Diagnostics;
using System.IO;
using OSIRT.Helpers;
using OSIRT.Resources;

namespace OSIRT.UI.CaseClosing
{
    public partial class CaseClosingCleanUpPanel : UserControl
    {

        public CaseClosingCleanUpPanel(string password, bool isInAuditViewMode) 
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            uiInfoLabel.Text = strings.CaseClosingCleanUpPanel_Cleaning_up____Please_Wait;
            CaseCleanUpLogic cleanUp = new CaseCleanUpLogic(password, isInAuditViewMode);
            cleanUp.ReportProgress += CleanUp_ReportProgress;
            cleanUp.Start();
        }


        private void CleanUp_CaseArchived(object sender, EventArgs e)
        {
          
        }

        private void CleanUp_ReportProgress(object sender, EventArgs e)
        {
            uiInfoLabel.Text = ((ProgressChangedEventArgs)e).UserState.ToString();
        }

        public CaseClosingCleanUpPanel(string password) : this(password, false) { }
    

        private void uiInfoLabel_SizeChanged(object sender, EventArgs e)
        {
            uiInfoLabel.Left = (groupBox.Width - uiInfoLabel.Size.Width) / 2;
        }
    }
}
