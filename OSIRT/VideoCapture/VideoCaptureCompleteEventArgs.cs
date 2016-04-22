using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSIRT.VideoCapture
{
    public class VideoCaptureCompleteEventArgs : EventArgs
    {


        public string Date { get; private set; }
        public string Time { get; private set; }
        public string DateAndTime { get { return Date + " " + Time; } }

        public VideoCaptureCompleteEventArgs()
        { 
            Date = DateTime.Now.ToString("yyyy-MM-dd");
            Time = DateTime.Now.ToString("HH:mm:ss");
        }

    }
}
