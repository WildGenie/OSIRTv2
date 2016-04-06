using System;
using System.Data;

namespace OSIRT.UI.AuditLog
{
    public class SearchCompletedEventArgs : EventArgs
    {

        public DataTable SearchTable { get; private set; }

        public SearchCompletedEventArgs(DataTable table)
        {
            SearchTable = table;
        }



    }
}
