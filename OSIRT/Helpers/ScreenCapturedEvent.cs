using System;

namespace OSIRT.Helpers
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
