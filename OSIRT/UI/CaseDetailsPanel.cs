using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text.RegularExpressions;
using OSIRT.Extensions;
using OSIRT.Helpers;

namespace OSIRT.UI
{
    public partial class CaseDetailsPanel : UserControl
    {

        public event EventHandler NextClick;
        public event EventHandler BackClick;
        private ErrorProvider errorProvider;
        

        public CaseDetailsPanel()
        {
            InitializeComponent();
        }

        private void CaseDetailsPanel_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            errorProvider = new ErrorProvider();
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            uiHashFunctionComboBox.SelectedIndex = 0;
          
            uiOfficerTextBox.Focus();
        }

    

      

        private bool AreValidEntries()
        {
            bool isValid = true;
            var allTextBoxes = uiCaseDetailsPanel.GetChildControls<TextBox>();
            foreach (TextBox tb in allTextBoxes)
            {
                
                if (String.IsNullOrWhiteSpace(tb.Text))
                {
                    errorProvider.SetError(tb, "This field is required");
                    isValid = false;
                }
                else if (tb.Name == "uiCaseReferenceTextBox")
                {
                    if (!IsValidDirectoryName(tb.Text))
                    {

                        errorProvider.SetError(tb, "This field can only contain letters, numbers, hyphens ('-') and underscores ('_')");
                        isValid = false;
                    }
                }
                else
                {
                    errorProvider.SetError(tb, String.Empty);
                }
            }
            return isValid;
        }

        private bool IsValidDirectoryName(string dirName)
        {
            Regex regex = new Regex(@"^[A-Za-z\d_-]+$");
            return regex.Match(dirName).Success;
        }

        public Dictionary<string, string> GetCaseDetails()
        {

            var allControls = uiCaseDetailsPanel.GetChildControls<Control>();
            Dictionary<string, string> details = new Dictionary<string, string>();

            foreach(Control control in allControls)
            {
                if(control is TextBox) 
                {
                    TextBox textbox = control as TextBox;
                    details.Add(textbox.Tag.ToString(), textbox.Text);
                }
                else if (control is ComboBox)
                {
                    ComboBox comboBox = control as ComboBox;
                    details.Add(comboBox.Tag.ToString(), comboBox.SelectedItem.ToString());
                }

            }
            return details;
    
        }


        private void uiBackButton_Click(object sender, EventArgs e)
        {
            if (this.BackClick != null)
                this.BackClick(this, e);
        }

        private void uiNextButton_Click(object sender, EventArgs e)
        {
            bool isValid = AreValidEntries();

            if (!isValid)
                return;

            //Place details in database

            if (this.NextClick != null)
                this.NextClick(this, e);
        }

        private void uiBrowseButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowNewFolderButton = false;
            fbd.Description = "Select the location for the case container";
            DialogResult result = fbd.ShowDialog();

            if (result != DialogResult.OK)
                return;

            Constants.Directories.CasePath = fbd.SelectedPath;
            uiCasePathTextBox.Text = Constants.Directories.CasePath;
        }

        private void uiCaseDetailsPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void uiEvidenceReferenceTextBox_Enter(object sender, EventArgs e)
        {
            TextBox caseReferenceTB = sender as TextBox;
            ToolTip tooltip = new ToolTip();
            tooltip.IsBalloon = true;
           
            tooltip.Show("Only contain a-z, A-Z, 0-9, hypthens ( - ) and underscores ( _ )", caseReferenceTB, 150, -50, 15000);
        }

        private void uiHashHelpLabel_Click(object sender, EventArgs e)
        {
            //tooltip.IsBalloon = true;
            ToolTip tooltip = new ToolTip();
            tooltip.ToolTipIcon = ToolTipIcon.Info;
            tooltip.Show(@"Hash functions are listed in order of speed, with the fastest appearing first. 
            For verifying that a file has not changed when it was saved and hashed, MD5 is satisfactory.", this.uiHashHelpLabel, 30000);
        }

      

    

       

    }
}
