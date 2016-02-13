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
using OSIRT.Database;
using System.Threading;
using Jacksonsoft;
using System.IO;

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


        private bool ContainerFileAlreadyExists()
        {
            string caseRef = uiCaseReferenceTextBox.Text;
            string caseLocation = uiCasePathTextBox.Text;
            string combined = Path.Combine(caseLocation, caseRef);
            return  Directory.Exists(combined);
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

            bool containerExists = ContainerFileAlreadyExists();
            if (containerExists)
            {
                errorProvider.SetError(uiCaseReferenceTextBox, "A case container already exists with this name. Please chose another.");
                isValid = false;
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
                if (control is TextBox && control.Name != "uiCasePathTextBox") 
                {
                    TextBox textbox = control as TextBox;
                    details.Add(textbox.Tag.ToString(), textbox.Text);
                }
                else if (control is ComboBox) //our hash function
                {
                    ComboBox comboBox = control as ComboBox;
                    details.Add(comboBox.Tag.ToString(), comboBox.SelectedItem.ToString());
                }
                else if (control is SpellBox) 
                {
                    SpellBox spellbox = control as SpellBox;
                    details.Add(spellbox.Tag.ToString(), spellbox.Text);
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

            //Create the case container
            //Thread out? Background worker?
            Dictionary<string,string> caseDetails = GetCaseDetails();
            WaitWindow.Show(this.CreateCase,"Creating New Case...", caseDetails);

            if (this.NextClick != null)
                this.NextClick(this, e);
           
        }

        private void CreateCase(object sender, WaitWindowEventArgs e)
        {
            new CaseCreator((Dictionary<string,string>) e.Arguments[0], new DatabaseTableCreator());
            Thread.Sleep(500);
        }

        private void uiBrowseButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowNewFolderButton = false;
            fbd.Description = "Select the location for the case container";
            DialogResult result = fbd.ShowDialog();

            if (result != DialogResult.OK)
                return;

            Constants.CasePath = fbd.SelectedPath;
            uiCasePathTextBox.Text = Constants.CasePath;
        }

        private void uiCaseDetailsPanel_Paint(object sender, PaintEventArgs e)
        {

        }

  

        private void uiHashHelpLabel_Click(object sender, EventArgs e)
        {
            //tooltip.IsBalloon = true;
            ToolTip tooltip = new ToolTip();
            tooltip.ToolTipIcon = ToolTipIcon.Info;
            tooltip.Show(@"Hash functions are listed in order of speed, with the fastest appearing first." + Environment.NewLine + "For verifying that a file has not changed when it was saved and hashed, MD5 is satisfactory.", this.uiHashHelpLabel, 30000);
        }


        private void uiCaseReferenceTextBox_Enter(object sender, EventArgs e)
        {
            TextBox caseReferenceTB = sender as TextBox;
            ToolTip tooltip = new ToolTip();
            tooltip.IsBalloon = true;

            tooltip.Show("Only contain a-z, A-Z, 0-9, hypthens ( - ) and underscores ( _ )", caseReferenceTB, 150, -50, 7000);
        }

      

    

       

    }
}
