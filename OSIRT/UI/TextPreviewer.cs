using System;
using FastColoredTextBoxNS;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OSIRT.Helpers;
using System.IO;
using OSIRT.Loggers;

namespace OSIRT.UI
{
    public partial class TextPreviewer : Previewer
    {
        private string url;
        private bool successful;


        public TextPreviewer(Enums.Actions action, string url) : base(action, Constants.TempTextFile)
        {
            this.url = url;
            InitializeComponent();
        }

        private void TextPreviewer_Load(object sender, EventArgs e)
        {
            FastColoredTextBox fctb = new FastColoredTextBox();
            fctb.ReadOnly = true;
            fctb.Dock = DockStyle.Fill;
            fctb.Language = Language.HTML;
            fctb.WordWrap = true;
            fctb.Text = File.ReadAllText(Constants.TempTextFile);
            uiURLTextBox.Text = url;
            uiPreviewerSplitContainer.Panel2.Controls.Add(fctb);

            uiFileExtensionComboBox.Visible = false;

        }

        private void uiOKButton_Click(object sender, EventArgs e)
        {
            string ext = FileExtension;
            if (string.IsNullOrWhiteSpace(ext))
            {
                ext = ".txt";
            }
            

            try
            {
                File.Copy(Constants.TempTextFile, Path.Combine(Constants.ContainerLocation, Constants.Directories.GetSpecifiedCaseDirectory(action), FileName + ext));
                GC.Collect();
                GC.WaitForPendingFinalizers();
                File.Delete(Constants.TempTextFile);
                successful = true;
            }
            catch (UnauthorizedAccessException uex)
            {
                MessageBox.Show("Unauthorized Access Exception: " + uex.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to save the text. Enter a different file name and try again", "Unable to save text", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (successful)
            {
                

                Logger.Log(new WebpageActionsLog(url, action, Hash, FileName + ext, Note));
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void uiCancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
