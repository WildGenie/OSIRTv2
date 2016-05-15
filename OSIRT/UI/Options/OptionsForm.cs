using System;
using System.Drawing;
using System.Windows.Forms;
using OSIRT.Extensions;

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
            UserSettings settings = UserSettings.Load();
            settings.ShowMouseTrail = uiShowMouseTrailCheckBox.Checked;
            settings.Save();
        }

        private void OptionsForm_Load(object sender, EventArgs e)
        {
            uiShowMouseTrailCheckBox.Checked = settings.ShowMouseTrail;
            uiDeleteCacheOnCloseCheckBox.Checked = settings.ClearCacheOnClose;
            uiHashFileLocationTextBox.Text = settings.HashExportLocation;

            if (settings.IconAsBase64 != "")
                uiConstabularyIconPictureBox.Image = settings.IconAsBase64.Base64ToImage();
        }

        private void uiDeleteCacheOnCloseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            UserSettings settings = UserSettings.Load();
            settings.ClearCacheOnClose = uiDeleteCacheOnCloseCheckBox.Checked;
            settings.Save();
        }

        private void uiBrowseIconButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png, *gif) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png; *.gif";
            dialog.Title = "Constabulary Icon";
            DialogResult dr = dialog.ShowDialog();

            if (dr != DialogResult.OK)
                return;

            string path = dialog.FileName;

            Image icon = Image.FromFile(path);
            uiConstabularyIconPictureBox.Image = icon;


            settings.IconAsBase64 = icon.ToBase64Encoded();
            settings.Save();
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
    }
}
