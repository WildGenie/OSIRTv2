using OSIRT.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSIRT.UI.BrowserOptions
{
    public partial class BrowserOptionsForm : Form
    {

        private GSettings settings = GSettings.Load();
        public string UserAgent{ get; private set; }
        private string webRtc;

        public BrowserOptionsForm()
        {
            InitializeComponent();
        }

        private void uiUserAgentListLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start("http://ua.theafh.net/");
            }
            catch
            {
                MessageBox.Show("Unable to open link. This may be due to there being no default application on this system to open web links with", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void uiOKButton_Click(object sender, EventArgs e)
        {
            RuntimeSettings.IsUsingTor = uiConnectToTorCheckBox.Checked;
            UserAgent =  uiUserAgentsComboBox.SelectedValue == null ?  "" : uiUserAgentsComboBox.SelectedValue.ToString();
            CheckProxySettings();

            uiHashFileLocationTextBox.Text = settings.SaveDirectory;
            uiSaveAllResponseHeadersCheckbox.Checked = settings.SaveHttpHeaders;
            uiOpenDirectoryCheckBox.Checked = settings.OpenDirectory;
        }

        private void PopulateUserAgents()
        {
            if (File.Exists(Constants.UserAgentsFile))
            {
                string[] lines = File.ReadAllLines(Constants.UserAgentsFile);
                var dict = lines.Select(l => l.Split('=')).ToDictionary(a => a[0], a => a[1]);
                dict.Add("Default User Agent", "");

                uiUserAgentsComboBox.DataSource = new BindingSource(dict, null);
                uiUserAgentsComboBox.DisplayMember = "Key";
                uiUserAgentsComboBox.ValueMember = "Value";
            }
            uiUserAgentsComboBox.Text = "Default User Agent";
        }

        private void CheckProxySettings()
        {
            string cefProxy = uiBrowserProxyTextBox.Text;
            string torProxy = uiTorProxyTextBox.Text;
            string torPort = uiTorControlPortTextBox.Text;

            var proxySettings = new Dictionary<string, string>
            {
                { "cefProxy", cefProxy },
                { "torProxy", string.IsNullOrWhiteSpace(torProxy) ? "127.0.0.1:8182" : torProxy },
                { "torPort", string.IsNullOrWhiteSpace(torPort) ? "9051" : torPort },
                { "disablewebrtc", webRtc }
            };

            string[] lines = proxySettings.Select(kvp => kvp.Key + "=" + kvp.Value).ToArray();
            File.WriteAllLines(Constants.ProxySettingsFile, lines);
        }

        private void BrowserOptionsForm_Load(object sender, EventArgs e)
        {
            uiHashFileLocationTextBox.Text = settings.SaveDirectory;
            uiSaveAllResponseHeadersCheckbox.Checked = settings.SaveHttpHeaders;
            uiOpenDirectoryCheckBox.Checked = settings.OpenDirectory;

            uiWebSaveGroupBox.Enabled = uiWebDownloadModeCheckBox.Checked;
            uiFolderLocationGroupBox.Enabled = uiWebDownloadModeCheckBox.Checked;

            if (!File.Exists(@"Tor\Tor\tor.exe"))
            {
                uiBrowserOptionsGroupBox.Enabled = false;
                uiConnectToTorCheckBox.Visible = false;
                uiTorDisabledLabel.Visible = true;
            }

            if (File.Exists(Constants.ProxySettingsFile))
            {
                string[] lines = File.ReadAllLines(Constants.ProxySettingsFile);
                var dict = lines.Select(l => l.Split('=')).ToDictionary(a => a[0], a => a[1]);

                uiBrowserProxyTextBox.Text = dict["cefProxy"];
                uiTorProxyTextBox.Text = dict["torProxy"];
                uiTorControlPortTextBox.Text = dict["torPort"];
                if(!dict.ContainsKey("disablewebrtc")) dict.Add("disablewebrtc", "false");
                webRtc = dict["disablewebrtc"];
            }
            PopulateUserAgents();
        }

        private void uiDisableJSCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            RuntimeSettings.JsDisabled = uiDisableJSCheckBox.Checked;
        }

        private void uiDisableImagesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            RuntimeSettings.ImagesDisabled = uiDisableImagesCheckBox.Checked;
        }

        private void uiDisablePluginsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            RuntimeSettings.PluginsDisabled = uiDisableImagesCheckBox.Checked;
        }

        private void uiDownloadModeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            RuntimeSettings.EnableWebDownloadMode = uiWebDownloadModeCheckBox.Checked;

            uiWebSaveGroupBox.Enabled = uiWebDownloadModeCheckBox.Checked;
            uiFolderLocationGroupBox.Enabled = uiWebDownloadModeCheckBox.Checked;

        }

        private void uiSaveAllResponseHeadersCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            settings.SaveHttpHeaders = uiSaveAllResponseHeadersCheckbox.Checked;
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
                settings.SaveDirectory = path;
                settings.Save();
            }
        }

        private void uiOpenDirectoryCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            settings.OpenDirectory = uiSaveAllResponseHeadersCheckbox.Checked;
            settings.Save();
        }
    }
}
