using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using OSIRT.Extensions;
using OSIRT.Helpers;
using System.Threading;
using Jacksonsoft;
using System.IO;
using System.Diagnostics;

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
            return Directory.Exists(combined);
        }

        private bool AreValidEntries()
        {
            bool isValid = true;
            
            var allTextBoxes = uiCaseDetailsPanel.GetChildControls<TextBox>();
            foreach (TextBox tb in allTextBoxes)
            {
                
                if (String.IsNullOrWhiteSpace(tb.Text))
                {
                    errorProvider.SetError(tb, Resources.strings.field_is_required);
                    isValid = false;
                }
                else if (tb.Name == "uiCaseReferenceTextBox")
                {
                    if (!IsValidDirectoryName(tb.Text))
                    {

                        errorProvider.SetError(tb, Resources.strings.field_can_only_contain_valid_directory_char);
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
                errorProvider.SetError(uiCaseReferenceTextBox, Resources.strings.case_with_that_name_exists_already);
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
            details.Add("hashed_password", "");
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

        
            Dictionary<string,string> caseDetails = GetCaseDetails();
            WaitWindow.Show(CreateCase, Resources.strings.creating_case_wait, caseDetails);

            if (NextClick != null)
                NextClick(this, e);
           
        }

        private void CreateCase(object sender, WaitWindowEventArgs e)
        {
            Thread.Sleep(500);
            new CaseCreator((Dictionary<string,string>) e.Arguments[0], new DatabaseTableCreator());
            Thread.Sleep(500);
        }

        private void uiBrowseButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowNewFolderButton = false;
            fbd.Description = Resources.strings.case_location_desc;
            DialogResult result = fbd.ShowDialog();

            if (result != DialogResult.OK)
                return;

            Constants.CasePath = fbd.SelectedPath;
            uiCasePathTextBox.Text = Constants.CasePath;
        }

        private void uiHashHelpLabel_Click(object sender, EventArgs e)
        {
            ToolTip tooltip = new ToolTip();
            tooltip.ToolTipIcon = ToolTipIcon.Info;
            tooltip.Show(@"Hash functions are listed in order of speed, with the fastest appearing first." + Environment.NewLine + "For verifying that a file has not changed when it was saved and hashed, MD5 is satisfactory.", this.uiHashHelpLabel, 30000);
        }


        private void uiCaseReferenceTextBox_Enter(object sender, EventArgs e)
        {
            TextBox caseReferenceTB = sender as TextBox;
            ToolTip tooltip = new ToolTip();
            tooltip.IsBalloon = true;

            tooltip.Show(Resources.strings.field_can_only_contain_valid_directory_char, caseReferenceTB, 150, -50, 7000);
        }

        private void uiCaseDetailsPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
