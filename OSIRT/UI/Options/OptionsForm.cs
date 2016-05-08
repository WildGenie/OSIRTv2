using System.Windows.Forms;

namespace OSIRT.UI.Options
{
    public partial class OptionsForm : Form
    {
        public OptionsForm()
        {
            InitializeComponent();
        }

        private void uiShowMouseTrailCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            UserSettings settings = UserSettings.Load();
            settings.ShowMouseTrail = uiShowMouseTrailCheckBox.Checked;
            settings.Save();
        }

        private void OptionsForm_Load(object sender, System.EventArgs e)
        {
            uiShowMouseTrailCheckBox.Checked = UserSettings.Load().ShowMouseTrail;
        }
    }
}
