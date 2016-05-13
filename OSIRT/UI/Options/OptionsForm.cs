using System;
using System.Drawing;
using System.Windows.Forms;
using OSIRT.Extensions;

namespace OSIRT.UI.Options
{
    public partial class OptionsForm : Form
    {
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
            uiShowMouseTrailCheckBox.Checked = UserSettings.Load().ShowMouseTrail;
            uiDeleteCacheOnCloseCheckBox.Checked = UserSettings.Load().ClearCacheOnClose;

            if(UserSettings.Load().IconAsBase64 != "")
                uiConstabularyIconPictureBox.Image = UserSettings.Load().IconAsBase64.Base64ToImage();
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

            UserSettings settings = UserSettings.Load();
            settings.IconAsBase64 = icon.ToBase64Encoded();
            settings.Save();
        }
    }
}
