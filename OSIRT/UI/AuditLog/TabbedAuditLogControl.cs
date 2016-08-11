using OSIRT.Database;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OSIRT.UI.AuditLog
{
    public partial class TabbedAuditLogControl : UserControl
    {
        public event EventHandler TabChanged;


        private readonly Dictionary<string, string> tabs = new Dictionary<string, string>()
        {
            {"Websites Loaded", "webpage_log"},
            {"Websites Actions", "webpage_actions"},
            {"OSIRT Actions", "osirt_actions" },
            {"Attachments", "attachments" },
            {"Videos", "videos" },
        };


        public TabbedAuditLogControl()
        {
            InitializeComponent();
            uiAuditLogTabControl.SelectedIndexChanged += AuditLogTabControl_SelectedIndexChanged;
            CreateTabs();
        }

        public void AddGridToTab(OsirtGridView grid, string tabName)
        {
            var tab = new AuditTab(tabName);
            tab.Controls.Add(grid);

            uiAuditLogTabControl.TabPages.Add(tab);
        }

        private void CreateTabs()
        {
            foreach(KeyValuePair<string,string> tab in tabs)
            {
                AuditTab auditTab = new AuditTab(tab.Key, tab.Value);
                uiAuditLogTabControl.TabPages.Add(auditTab);
            }
            //Working on adding a complete audit log tab, including notes

        }

        public Dictionary<string, string> Tabs()
        {
            return tabs;
        }

        public bool SearchTabCreated()
        {
            return false;
        }

        public void AddSearchTab()
        {
            //if search tab already open, use that instead.
            //AuditTab tab = new AuditTab("Search", "");
            //TabPage tab = new TabPage("Search");
            //uiAuditLogTabControl.TabPages.Add(tab);
            //uiAuditLogTabControl.SelectedTab = tab;
        }

        private void AuditLogTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabChanged?.Invoke(CurrentTab, e);
        }

        public TabControl.TabPageCollection AuditTabs
        {
            get { return uiAuditLogTabControl.TabPages;}
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

        private void uiAuditLogTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
