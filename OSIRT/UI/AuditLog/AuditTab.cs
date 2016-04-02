using OSIRT.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSIRT.UI
{
    public class AuditTab : TabPage
    {

        public AuditGridView AuditLogGrid { get; private set; }

        public AuditTab(string title, string table) 
        {
            AuditLogGrid = new AuditGridView(table);
            Text = title;

            if (AuditLogGrid.TotalRows > 0)
            {
                Controls.Add(AuditLogGrid);
            }
            else
            {
                NoRecordsToShowPanel noRecordsPanel = new NoRecordsToShowPanel();
                Controls.Add(noRecordsPanel);
            }
        }

        #region pagination methods
        public int NumberOfPages()
        {
            return AuditLogGrid.NumberOfPages;
        }

        public string PagesLeftDescription()
        {
            return AuditLogGrid.PagesLeftDescription();
        }


        public bool CanGoToNextPage()
        {
            return AuditLogGrid.CanGoToNextPage();
        }

        public bool CanGoToPreviousPage()
        {
            return AuditLogGrid.CanGoToPreviousPage();
        }

        public void NextPage()
        {
            AuditLogGrid.NextPage();
        }

        public void PreviousPage()
        {
            AuditLogGrid.PreviousPage();
        }

        public void FirstPage()
        {
            AuditLogGrid.FirstPage();
        }

        public void LastPage()
        {
            AuditLogGrid.LastPage();
        }

        public int Page()
        {
            return AuditLogGrid.Page;
        }

        #endregion

    }
}
