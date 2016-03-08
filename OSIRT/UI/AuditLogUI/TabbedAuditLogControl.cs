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

namespace OSIRT.UI
{
    public partial class TabbedAuditLogControl : UserControl
    {
        public TabbedAuditLogControl()
        {
            InitializeComponent();
            uiAuditLogTabControl.SelectedIndexChanged += UiAuditLogTabControl_SelectedIndexChanged;
        }

        private void UiAuditLogTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            AuditTab current = (sender as AuditTab);

            DatabaseHandler db = new DatabaseHandler();

           
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
