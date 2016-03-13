using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSIRT
{
    public class ExtendedRowEnterEventArgs : EventArgs
    {
        public ExtendedRowEnterEventArgs(DataGridViewCellEventArgs dgvCellEventArgs, Dictionary<string,string> rowDetails)
        {
            DataGridViewCellEventArgs = dgvCellEventArgs;
            RowDetails = rowDetails;
        }

        public DataGridViewCellEventArgs DataGridViewCellEventArgs { get; private set; }
        public Dictionary<string,string> RowDetails { get; private set; }


    }
}
