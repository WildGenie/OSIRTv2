using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSIRT.Database
{
    public class ScreenCapturedEvent
    {

        public event EventHandler<EventArgs> Event = delegate { };

        public void FireEvent()
        {
            Event(this, EventArgs.Empty);
        }
    }
}
