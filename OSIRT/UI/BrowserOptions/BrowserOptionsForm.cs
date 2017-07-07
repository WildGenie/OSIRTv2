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

        public bool IsUsingTor { get; private set; }
        public string UserAgent{ get; private set; }

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
            IsUsingTor = uiConnectToTorCheckBox.Checked;
            UserAgent = uiUserAgentTextBox.Text;

            CheckProxySettings();
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
                { "torPort", string.IsNullOrWhiteSpace(torPort) ? "9051" : torPort }
            };

            string[] lines = proxySettings.Select(kvp => kvp.Key + "=" + kvp.Value).ToArray();
            File.WriteAllLines(Constants.ProxySettingsFile, lines);
        }

        private void BrowserOptionsForm_Load(object sender, EventArgs e)
        {
            if(!File.Exists(@"Tor\Tor\tor.exe"))
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
            }
        }

    
    }
}
