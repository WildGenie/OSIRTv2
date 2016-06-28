using System;
using System.Drawing;
using System.Windows.Forms;
using OSIRT.Extensions;
using System.Diagnostics;
using OSIRT.Helpers;
using System.Threading.Tasks;
using OSIRT.VideoCapture;

namespace OSIRT.UI.Options
{
    public partial class OptionsForm : Form
    {

        private UserSettings settings = UserSettings.Load();

        public OptionsForm()
        {
            InitializeComponent();
        }

        private void uiShowMouseTrailCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            settings.ShowMouseTrail = uiShowMouseTrailCheckBox.Checked;
            settings.Save();
        }

        private void uiShowMouseClicksCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            settings.ShowMouseClick = uiShowMouseClicksCheckBox.Checked;
            settings.Save();
        }

        private void OptionsForm_Load(object sender, EventArgs e)
        {
            uiShowMouseTrailCheckBox.Checked = settings.ShowMouseTrail;
            uiShowMouseClicksCheckBox.Checked = settings.ShowMouseClick;
            uiDeleteCacheOnCloseCheckBox.Checked = settings.ClearCacheOnClose;
            uiExportHashOnCloseCheckBox.Checked = settings.ExportHashOnClose;
            uiBrowseLocationButton.Enabled = settings.ExportHashOnClose;
            uiHashFileLocationTextBox.Text = settings.HashExportLocation;
            uiFPSTrackBar.Value = settings.FramesPerSecond;
            uiEnterCreatesNewLineCheckBox.Checked = settings.EnterInCaseNotesNewLine;

            uiConstabularyIconPictureBox.Image = settings.ConstabIcon.Base64ToImage();

            if (OsirtVideoCapture.HasStereoMix())
            {
                uiSteroMixStatusLabel.ForeColor = Color.Green;
                uiSteroMixStatusLabel.Text = "Stereo Mix found";
            }
            else
            {
                uiSteroMixStatusLabel.ForeColor = Color.Red;
                uiSteroMixStatusLabel.Text = "Stereo Mix not found";
            }
        }

        private void uiDeleteCacheOnCloseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            settings.ClearCacheOnClose = uiDeleteCacheOnCloseCheckBox.Checked;
            settings.Save();
        }

        private async void uiBrowseIconButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png, *gif) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png; *.gif";
            dialog.Title = "Constabulary Icon";
            DialogResult dr = dialog.ShowDialog();

            if (dr != DialogResult.OK)
                return;

            string path = dialog.FileName;
            try
            {
                string base64 = await Task.Run(() => OsirtHelper.ResizeConstabLogo(path));
                uiConstabularyIconPictureBox.Image = base64.Base64ToImage();
                settings.ConstabIcon = base64;
                settings.Save();
            }
            catch
            {
                MessageBox.Show("Unable to save icon", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void uiBrowseLocationButton_Click(object sender, EventArgs e)
        {

            using (FolderBrowserDialog folderBrowser = new FolderBrowserDialog())
            {
                if (folderBrowser.ShowDialog() != DialogResult.OK)
                    return;

                string path = folderBrowser.SelectedPath;
                uiHashFileLocationTextBox.Text = path;

                settings.HashExportLocation = path;
                settings.Save();

            }
        }

        private void uiFPSTrackBar_Scroll(object sender, EventArgs e)
        {

        }

        private void uiFPSTrackBar_ValueChanged(object sender, EventArgs e)
        {
            int value = uiFPSTrackBar.Value;
            uiFPSLabel.Text = $"{value} FPS";
            settings.FramesPerSecond = value;
        }

        private void uiCloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void uiExportHashOnCloseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool hashOnClose = uiExportHashOnCloseCheckBox.Checked;
            uiBrowseLocationButton.Enabled = hashOnClose;
            settings.ExportHashOnClose = hashOnClose;
            settings.Save();
        }

        private void uiEnterCreatesNewLineCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            settings.EnterInCaseNotesNewLine = uiEnterCreatesNewLineCheckBox.Checked;
            settings.Save();
        }
    }
}
