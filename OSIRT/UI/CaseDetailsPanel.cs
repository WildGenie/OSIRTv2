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

namespace OSIRT.UI
{
    public partial class CaseDetailsPanel : UserControl
    {

        public event EventHandler ButtonClick;
        public event EventHandler BackClick;
        private string casePath = String.Empty;
        private ErrorProvider errorProvider;

        public CaseDetailsPanel()
        {
            InitializeComponent();
            errorProvider = new ErrorProvider();
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
           
        }

        private void CaseDetailsPanel_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            uiOfficerTextBox.Focus();
        }


        private bool AreValidEntries()
        {
            bool isValid = true;
            var allTextBoxes = uiCaseDetailsGroupBox.GetChildControls<TextBox>();
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
            string officer = uiOfficerTextBox.Text;
            string agency = uiAgencyTextBox.Text;
            string operation = uiOperationTextBox.Text;
            string caseReference = uiCaseReferenceTextBox.Text;
            string evidencereference = uiEvidenceReferenceTextBox.Text;
            string caseFolder = uiCasePathTextBox.Text;
            string notes = uiNotesTextBox.Text;

            Dictionary<string, string> details = new Dictionary<string, string>() { { "Investigating Officer", officer} , {"Investigating Agency", agency }, {"Operation Name",operation}, {"Case Reference",caseReference}, {"Evidence Reference", evidencereference}, {"Case Folder",caseFolder},{"Case Notes", notes} };
            return details;
            //List<string> details = new List<string>();
            //string[] details = new string[7];
            //int index = 0;
            //var allTextBoxes = groupBox1.GetChildControls<TextBox>();
            //foreach (TextBox tb in allTextBoxes)
            //{
            //    Debug.WriteLine(tb.Name + " V: " + tb.Text);
            //    details[index++] = tb.Text;
            //}
            //return details;
        }

        private void uiNextButton_Click(object sender, EventArgs e)
        {
            bool isValid = AreValidEntries();

            if (!isValid)
                return;

            if (this.ButtonClick != null)
                this.ButtonClick(this, e);
        }

        

        private void uiBrowsButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowNewFolderButton = false;
            fbd.Description = "Select the location for the case container";
            DialogResult result = fbd.ShowDialog();

            if (result != DialogResult.OK)
                return;

            casePath = fbd.SelectedPath;
            uiCasePathTextBox.Text = casePath;
        }

        public string GetCasePath()
        {
            return this.casePath;
        }

      

        private void uiBackButton_Click(object sender, EventArgs e)
        {
            if (this.BackClick != null)
                this.BackClick(this, e);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       

    }
}
