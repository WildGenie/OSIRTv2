using OSIRT.Database;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace OSIRT.UI.AuditLog
{
    public class AuditTab : TabPage
    {

        public AuditGridView AuditLogGrid { get; private set; }

        //private readonly Dictionary<string, string> tabs = new Dictionary<string, string>()
        //{
        //    {"Websites Loaded", "webpage_log"},
        //    {"Websites Actions", "webpage_actions"},
        //    {"OSIRT Actions", "osirt_actions" },
        //    {"Attachments", "attachments" },
        //    {"Videos", "videos" },
        //};

        //private DataTable GetMergedDataTable()
        //{
        //    DatabaseHandler db = new DatabaseHandler();
        //    DataTable merged = new DataTable();
        //    foreach (string table in tabs.Values)
        //    {
        //        string columns = DatabaseTableHelper.GetTableColumns(table);
        //        DataTable data = db.GetRowsFromColumns(table: table, columns: columns);
        //        merged.Merge(data, true, MissingSchemaAction.Add);
        //    }

        //    DataTable dt = new DatabaseHandler().GetRowsFromColumns("case_notes", "", "date", "time", "note");
        //    merged.Merge(dt, true, MissingSchemaAction.Add);
 
        //    merged.TableName = "merged";
        //    DataView view = new DataView(merged);
        //    view.Sort = "date asc, time asc";
        //    DataTable sortedTable = view.ToTable();
        //    return sortedTable;
        //}


        public AuditTab(string title)
        {
            Text = title;
        }

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

        public sealed override string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        #region pagination methods
        public int NumberOfPages()
        {
            return AuditLogGrid.NumberOfPages;
        }

        public string PagesLeftDescription()
        {
            return AuditLogGrid?.PagesLeftDescription();
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
