using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
