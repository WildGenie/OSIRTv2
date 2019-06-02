using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OSIRT.Helpers;
using OSIRT.Extensions;
using System.IO;
using System.Text.RegularExpressions;
using Jacksonsoft;
using OSIRT.Database;

namespace OSIRT.UI
{
    public partial class CaseDetailsPanel2 : UserControl
    {
        public event EventHandler NextClick;
        private ErrorProvider errorProvider;


        public CaseDetailsPanel2()
        {
            InitializeComponent();
        }

        private void uiFirstPasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            //string password = uiFirstPasswordTextBox.Text;
            //OsirtHelper.PasswordScore strength = OsirtHelper.CheckStrength(password);
            //uiPasswordStrengthProgressBar.Value = (int)strength;
        }


        private bool ValidCaseDetails()
        {
            var allTextBoxes = uiCaseDetailsGroupBox.GetChildControls<TextBox>();
            bool isValid = true;
            foreach (TextBox textbox in allTextBoxes)
            {
                if (string.IsNullOrWhiteSpace(textbox.Text))
                {
                    errorProvider.SetError(textbox, Resources.strings.field_is_required);
                    isValid = false;
                }
                else if (textbox.Name == "uiCaseReferenceTextBox")
                {
                    if (!IsValidContainerName(textbox.Text))
                    {

                        errorProvider.SetError(textbox, Resources.strings.field_can_only_contain_valid_directory_char);
                        isValid = false;
                    }
                }
                else
                {
                    errorProvider.SetError(textbox, string.Empty);
                }

            }
            return isValid;
        }

        private bool ValidCaseOptions()
        {
            string casePath = uiCasePathTextBox.Text;
            string note = uiNotesTextBox.Text;
            bool isValid = true; ;
        
            if (ContainerFileAlreadyExists() || string.IsNullOrWhiteSpace(casePath))
            {
                errorProvider.SetError(uiCaseReferenceTextBox, Resources.strings.case_with_that_name_exists_already);
                isValid = false;
            }
            if(string.IsNullOrWhiteSpace(note))
            {
                errorProvider.SetError(uiNotesTextBox, Resources.strings.field_is_required);
                isValid = false;
            }
            return isValid;
        }

        private bool ValidPasswords()
        {
            if (!uiRequiresPasswordCheckbox.Checked)
                return true;


            string first = uiFirstPasswordTextBox.Text;
            string second = uiConfirmPasswordTextBox.Text;
            bool isValid = true;

            if(string.IsNullOrWhiteSpace(first) || string.IsNullOrWhiteSpace(second))
            {
                errorProvider.SetError(uiFirstPasswordTextBox, "Password field cannot be left blank.");
                isValid = false;
            }
            else if(first != second)
            {
                errorProvider.SetError(uiFirstPasswordTextBox, "Passwords do not match.");
                isValid = false;
            }
            else
            {
                errorProvider.SetError(uiFirstPasswordTextBox, string.Empty);
            }
            return isValid;
        }

        private bool AreValidEntries()
        {
            return ValidCaseDetails() & ValidPasswords() & ValidCaseOptions();
        }

        private bool IsValidContainerName(string dirName)
        {
            Regex regex = new Regex(@"^[A-Za-z\d_-]+$");
            return regex.Match(dirName).Success;
        }

        private bool ContainerFileAlreadyExists()
        {
            string caseRef = uiCaseReferenceTextBox.Text;
            string caseLocation = uiCasePathTextBox.Text;
            string combined = Path.Combine(caseLocation, caseRef);
            return Directory.Exists(combined);
        }



        public Dictionary<string, string> GetCaseDetails()
        {

            var allControls = splitContainer1.GetChildControls<Control>();
            Dictionary<string, string> details = new Dictionary<string, string>();

            //password not required, put an empty string in the password field for the case
            //then we can check if casePassword == "" then don't use password
            if (!uiRequiresPasswordCheckbox.Checked)
                details.Add("hashed_password", "");

            foreach (Control control in allControls)
            {
                if (control.Name == "uiConfirmPasswordTextBox" || control.Name == "uiCasePathTextBox" || control.Name == "uiRequiresPasswordCheckbox")
                {
                    continue;
                }
                else if (control is ComboBox || control is TextBox || control is SpellBox)
                {

                    if (control.Name == "uiFirstPasswordTextBox" && uiRequiresPasswordCheckbox.Checked)
                    {
                        string password = control.Text;
                        string hash = SecurePasswordHasher.Hash(password);
                        details.Add("hashed_password", hash);
                        continue;
                    }
                    else if(control.Name == "uiFirstPasswordTextBox" && !uiRequiresPasswordCheckbox.Checked)
                    {
                        continue;
                    }
                    else
                    {
                        details.Add(control.Tag.ToString(), control.Text);
                    } 
                }
            }
            return details;
        }

        private void CaseDetailsPanel2_Load(object sender, EventArgs e)
        {
            Dock = DockStyle.Fill;
            errorProvider = new ErrorProvider();
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            uiHashFunctionComboBox.SelectedIndex = 0;
            uiInvestigatingOfficer.Focus();
            uiConfirmPasswordTextBox.UseSystemPasswordChar = true;
            uiFirstPasswordTextBox.UseSystemPasswordChar = true;
            uiHashFunctionComboBox.SelectedIndex = uiHashFunctionComboBox.FindStringExact("sha256");
        }

        private void uiNextButton_Click(object sender, EventArgs e)
        {

            bool isValid = AreValidEntries();

            if (!isValid)
                return;


            Dictionary<string, string> caseDetails = GetCaseDetails();
            WaitWindow.Show(CreateCase, Resources.strings.creating_case_wait, caseDetails);
            NextClick?.Invoke(this, e);
        }


        private void CreateCase(object sender, WaitWindowEventArgs e)
        {
            new CaseCreator((Dictionary<string, string>)e.Arguments[0], new DatabaseTableHelper());
        }

        private void uiCaseReferenceTextBox_Enter(object sender, EventArgs e)
        {
            ToolTip tooltip = new ToolTip {IsBalloon = true};
            tooltip.Show(Resources.strings.field_can_only_contain_valid_directory_char, sender as TextBox, 150, -50, 7000);
        }

        private void uiBrowsButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowNewFolderButton = true;
            fbd.Description = Resources.strings.case_location_desc;
            DialogResult result = fbd.ShowDialog();

            if (result != DialogResult.OK)
                return;

            Constants.CasePath = fbd.SelectedPath;
            uiCasePathTextBox.Text = Constants.CasePath;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void uiRequiresPasswordCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = uiRequiresPasswordCheckbox.Checked;
            uiFirstPasswordTextBox.Enabled = isChecked;
            uiConfirmPasswordTextBox.Enabled = isChecked;


            //UserSettings settings = UserSettings.Load();
            //settings.CaseHasPassword = isChecked;
            //settings.Save();

        }

        private void uiHashHelpLabel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("A hash function provides a way of verifying that a file hasn't changed or been modified. If you're unsure what a hash function is, leave it as SHA256.", "What is a Hash Function?", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void uiCaserefDetailsLabel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The entered text here will become the name of your case.", "Case Reference", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
