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

        private void CloseOsirt(string password)
        {
            if (caseOpened)
            {
                bool closeSuccessful = (bool) WaitWindow.Show(ClosingOperations, "Running OSIRT closing operations... Please wait", password);
                if(closeSuccessful)
                {
                    OsirtLogWriter.Write(Constants.ContainerLocation, true);
                    Environment.Exit(0);
                }
            }
        }

        private void ClosingOperations(object sender, WaitWindowEventArgs e)
        {
            ////TODO: clear IE cache if required

            ////TODO:  Export hash.
            ////Need this log here, as  database entry.
            //Logger.Log(new OsirtActionsLog(Enums.Actions.CaseClosed, $"[Case Closed - Hash exported as {Constants.CaseContainerName}_hash.txt", Constants.CaseContainerName));
            //Thread.Sleep(500); //just to see the window
            ////zip container
            //e.Window.Message = "Encrypting container... Please Wait";
            //using (ZipFile zip = new ZipFile())
            //{
            //    zip.Password = e.Arguments[0].ToString(); 
            //    zip.Encryption = EncryptionAlgorithm.WinZipAes256;
            //    zip.AddDirectory(Constants.ContainerLocation, Constants.CaseContainerName);
            //    zip.Save(Path.Combine(Constants.CasePath, Constants.CaseContainerName + Constants.ContainerExtension));
            //}

            //e.Window.Message = "Hashing case container... Please Wait";
            ////now we can hash and export it, case zipped.
            //string hash = OsirtHelper.GetFileHash(Path.Combine(Constants.CasePath, Constants.CaseContainerName + Constants.ContainerExtension));
            //File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + $"\\{Constants.CaseContainerName}_hash.txt", hash);
            ////TODO: have hash save location as an option

            //e.Window.Message = "Performing clean up operations... Please Wait";

            ////TODO: A handle is being left on the directory... What to do?
            ////Or is it? Could be the WaitWindow, you know... Use background worker to test!
            ////Idea: Have a timer, let it run for, say, 10 seconds and auto shut down app

            //while(true)
            //{
            //    int attempts = 0;
            //    try
            //    {
            //        Debug.WriteLine($"Attempts: {attempts}.");
            //        string directory = Path.Combine(Constants.CasePath, Constants.CaseContainerName);
            //        OsirtHelper.DeleteDirectory(directory);
            //        if (!Directory.Exists(directory) || attempts == 5) break;
            //    }
            //    catch (Exception ex)
            //    {
            //        Debug.WriteLine($"Attempts: {attempts}. Exception: {ex.InnerException.ToString()}");
            //        attempts++;
            //    }
      
            //}
            //e.Result = true; 
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
