using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSIRT.UI.AuditLog
{
    public class SearchGridView : OsirtGridView, IPageable
    {




        public int NumberOfPages
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int TotalRows
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool CanGoToNextPage()
        {
            throw new NotImplementedException();
        }

        public bool CanGoToPreviousPage()
        {
            throw new NotImplementedException();
        }

        public void FirstPage()
        {
            throw new NotImplementedException();
        }

        public void LastPage()
        {
            throw new NotImplementedException();
        }

        public void NextPage()
        {
            throw new NotImplementedException();
        }

        public string PagesLeftDescription()
        {
            throw new NotImplementedException();
        }

        public void PreviousPage()
        {
            throw new NotImplementedException();
        }
    }
}
