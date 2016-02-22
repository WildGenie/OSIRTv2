using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSIRT.UI
{
    public class ScreenshotCompletedArgs : EventArgs
    {

        public ScreenshotCompletedArgs(ScreenshotDetails details)
        {
            ScreenshotDetails = details;
        } 

        public ScreenshotDetails ScreenshotDetails { get; private set; }

    }
}
