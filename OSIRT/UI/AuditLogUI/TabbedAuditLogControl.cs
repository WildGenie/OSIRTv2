using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OSIRT.Database;
using System.Diagnostics;

namespace OSIRT.UI
{
    public partial class TabbedAuditLogControl : UserControl
    {
        private Dictionary<string, string> tabs = new Dictionary<string, string>()
        {
            {"Websites Loaded", "webpage_log"},
            {"Websites Actions", "webpage_actions"},
            {"OSIRT Actions", "osirt_actions" },
            {"Attachments", "attachments" },
        };


        public TabbedAuditLogControl()
        {
            InitializeComponent();
            uiAuditLogTabControl.SelectedIndexChanged += UiAuditLogTabControl_SelectedIndexChanged;
            CreateTabs();

        }

        private void CreateTabs()
        {
            foreach(KeyValuePair<string,string> tab in tabs)
            {
                AuditTab auditTab = new AuditTab(tab.Key, tab.Value);
                uiAuditLogTabControl.TabPages.Add(auditTab);

            }

        }

        private void UiAuditLogTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabPage current = (sender as TabControl).SelectedTab;

        }

        public AuditTab CurrentTab //active tab
        {

            get
            {
                AuditTab page = null;

                //BrowserTab page = null;
                if (uiAuditLogTabControl.SelectedTab != null)
                {
                    page = uiAuditLogTabControl.SelectedTab as AuditTab;
                }

                return page;

            }
        }

    }
}
