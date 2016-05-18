using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSIRT
{
    public interface IPageable
    {

        int NumberOfPages { get; }
        int TotalRows { get; }
        string PagesLeftDescription();
        bool CanGoToNextPage();
        bool CanGoToPreviousPage();
        void NextPage();
        void PreviousPage();
        void FirstPage();
        void LastPage();
        //void GoToPage(int page);
     
    }
}
