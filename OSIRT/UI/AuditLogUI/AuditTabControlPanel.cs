using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSIRT.UI
{
    public partial class AuditTabControlPanel : UserControl
    {
        private TabbedAuditLogControl tabbedAuditLog;
        private ToolTip toolTip = new ToolTip();

        public AuditTabControlPanel()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Dock = DockStyle.Fill;
            tabbedAuditLog = new TabbedAuditLogControl();
            tabbedAuditLog.Dock = DockStyle.Fill;
            uiGridViewPanel.Controls.Add(tabbedAuditLog);
            InitialiseTooltips();

            //TODO: when tab changes, need to update pages left desc!
            uiPageNumberLabel.Text = tabbedAuditLog.CurrentTab.PagesLeftDescription(); 
            uiPreviousPageButton.Enabled = false;
        }

        private void InitialiseTooltips()
        {
            toolTip.SetToolTip(uiPreviousPageButton, "Go back one page");
            toolTip.SetToolTip(uiNextPageButton, "Go forward one page");
            toolTip.SetToolTip(uiFirstPageButton, "Go to first page");
            toolTip.SetToolTip(uiLastPageButton, "Go to last page");
        }

        public TabControl.TabPageCollection AuditTabs
        {
            get { return tabbedAuditLog.AuditTabs; }
        }

        private void uiSearchButton_Click(object sender, EventArgs e)
        {
            string searchText = uiSearchTextBox.Text;
            tabbedAuditLog.CurrentTab.Search(searchText);
        }


        private void uiNextPageButton_Click(object sender, EventArgs e)
        {

            if (tabbedAuditLog.CurrentTab.CanGoToNextPage())
            {
                tabbedAuditLog.CurrentTab.NextPage();
                uiPreviousPageButton.Enabled = true;
                if (tabbedAuditLog.CurrentTab.Page == tabbedAuditLog.CurrentTab.NumberOfPages)
                {
                    uiNextPageButton.Enabled = false;
                }
            }
            else
            {
                uiNextPageButton.Enabled = false;
            }

            uiPageNumberLabel.Text = tabbedAuditLog.CurrentTab.PagesLeftDescription();

        }

        //TODO: Disable buttons when user can't go back/forward anymore.
        //Works for next and previous, but first and last needs work.
        private void uiPreviousPageButton_Click(object sender, EventArgs e)
        {
            if (tabbedAuditLog.CurrentTab.CanGoToPreviousPage())
            {
                tabbedAuditLog.CurrentTab.PreviousPage();
                uiNextPageButton.Enabled = true;
                uiFirstPageButton.Enabled = true;

                if (tabbedAuditLog.CurrentTab.Page == 1)
                {
                    uiPreviousPageButton.Enabled = false;
                    uiFirstPageButton.Enabled = false;
                }

            }
            else
            {
                uiPreviousPageButton.Enabled = false;
                uiFirstPageButton.Enabled = false;
            }

            uiPageNumberLabel.Text = tabbedAuditLog.CurrentTab.PagesLeftDescription();

        }

        private void uiFirstPageButton_Click(object sender, EventArgs e)
        {
            tabbedAuditLog.CurrentTab.FirstPage();
            uiPageNumberLabel.Text = tabbedAuditLog.CurrentTab.PagesLeftDescription();
        }

        private void uiLastPageButton_Click(object sender, EventArgs e)
        {

            tabbedAuditLog.CurrentTab.LastPage();
            uiPageNumberLabel.Text = tabbedAuditLog.CurrentTab.PagesLeftDescription();
        }

        private void uiGridViewPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void uiSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            string searchText = uiSearchTextBox.Text;
            tabbedAuditLog.CurrentTab.Search(searchText);
        }
    }
}
