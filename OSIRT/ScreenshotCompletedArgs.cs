using System;

namespace OSIRT
{
    public class ScreenshotCompletedEventArgs : EventArgs
    {

        public bool Successful  { get; private set; }

        public ScreenshotCompletedEventArgs(bool successful)
        {
            Successful = successful;
        } 

    }
}
