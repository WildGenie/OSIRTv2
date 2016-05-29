using OSIRT.Helpers;
using OSIRT.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSIRT.VideoCapture
{
    public  class OsirtVideoCapture
    {

        private static Capture captureThreadEntry;
        private static Thread captureThread;
        private static ToolStripButton button;
        public static event EventHandler VideoCaptureComplete;


        public static void StopCapture()
        {
            button.Image = Properties.Resources.start_rec;
            button.ToolTipText = "Start screen capture";

            if (captureThreadEntry == null || captureThread == null)
            {
                MessageBox.Show("No capture in progress");
                return;
            }
            captureThreadEntry.ThreadExitSignaled = true;

            while (captureThread.IsAlive) ;

            captureThread = null;
            captureThreadEntry = null;


            VideoCaptureComplete?.Invoke(null, new VideoCaptureCompleteEventArgs());
        }

        public static bool IsRecording()
        {
            if (captureThreadEntry == null || captureThread == null)
                return false;

            return captureThread.IsAlive;
        }



        public static void StartCapture(int width, int height, ToolStripButton button, uint handle)
        {
            OsirtVideoCapture.button = button;

            captureThreadEntry = new Capture();
            captureThreadEntry.WindowHandle = handle;
            captureThreadEntry.WholeWindow = 1;
            captureThreadEntry.X = 0;
            captureThreadEntry.Y = 0;
            captureThreadEntry.Width = (uint)width;
            captureThreadEntry.Height = (uint)height;
            captureThreadEntry.BitRate = 20000000;
            captureThreadEntry.FrameRate = (uint) UserSettings.Load().FramesPerSecond;
            captureThreadEntry.Audio = HasStereoMix() ? 0 : 0xFFFFFFFF; //TODO: Stereo mix may not always be at pos 0. Audio is screwed- does record, but sped up?
            captureThreadEntry.Filename = Constants.TempVideoFile;

            captureThread = new Thread(new ThreadStart(captureThreadEntry.Start));
            captureThread.Start();

            while (!captureThread.IsAlive) Thread.Sleep(100);
            while (!captureThreadEntry.VideoCaptureAttempted) Thread.Sleep(100);

            if (captureThreadEntry.VideoCaptureStarted)
            {

                button.Image = Properties.Resources.stop_rec;
                button.ToolTipText = "Stop screen capture";
            }
            else
            {
                while (captureThread.IsAlive) ;
                captureThread = null;
                captureThreadEntry = null;
            }

        }

        public static bool HasStereoMix()
        {
            VideoCapture.CallEnumerateAndSaveAudioCaptureDevices();
            string[] allLines = null;
            try
            {
                string loadFilename = "AudioCaptureDevices.txt";
                allLines = File.ReadAllLines(loadFilename);
                FileInfo loadedFileInfo = new FileInfo(loadFilename);
                loadedFileInfo.Delete();
            }
            catch { }
            foreach (string line in allLines)
            {
                Debug.WriteLine(line);
                if (line.Contains("Stereo Mix")) return true; 
            }
            return false;
        }



        public class Capture
        {
            public bool ThreadExitSignaled = false;
            public bool VideoCaptureAttempted = false;
            public bool VideoCaptureStarted = false;
            public string Filename;
            public uint WindowHandle, WholeWindow, X, Y, Width, Height, BitRate, FrameRate, Audio;
            public void Start()
            {
                ThreadExitSignaled = false;
                UInt32 Result = VideoCapture.CallBeginVideoCapture(WindowHandle, WholeWindow, X, Y, Width, Height, BitRate, FrameRate, Audio, Filename);
                if (Result == 0)
                {
                    VideoCaptureStarted = true;
                    VideoCaptureAttempted = true;
                }
                else
                {
                    VideoCaptureAttempted = true;
                    return;
                }
                while (!ThreadExitSignaled)
                {
                    VideoCapture.CallCaptureVideoFrame();
                }
                VideoCapture.CallStopVideoCapture();
            }
        }

        class VideoCapture
        {
            public static UInt32 CallBeginVideoCapture(UInt32 WindowHandle, UInt32 WholeWindow, UInt32 X, UInt32 Y, UInt32 Width, UInt32 Height, UInt32 BitRate, UInt32 FrameRate, UInt32 Audio, String Filename)
            {
                StringBuilder sBuffer = new StringBuilder(256);
                sBuffer.Append(Filename);
                UInt32 Result = BeginVideoCapture(WindowHandle, WholeWindow, X, Y, Width, Height, BitRate, FrameRate, Audio, sBuffer);
                Thread.Sleep(100);
                return Result;
            }
            public static void CallCaptureVideoFrame()
            {
                if (CaptureVideoFrame() != 0)
                {
                    MessageBox.Show("Failed to capture video frame");
                }
                Thread.Sleep(100);
            }
            public static void CallStopVideoCapture()
            {
                if (StopVideoCapture() != 0)
                {
                    MessageBox.Show("Failed to stop video capture");
                }
                Thread.Sleep(100);
            }
            public static void CallEnumerateAndSaveWindows()
            {
                try
                {
                    EnumerateAndSaveWindows();
                }
                catch
                {
                    MessageBox.Show("A required DLL was not found.  Most likely, this computer has an operating system prior to Windows 7 installed.");
                    Application.Exit();
                }
                Thread.Sleep(100);
            }
            public static void CallEnumerateAndSaveAudioCaptureDevices()
            {
                EnumerateAndSaveAudioCaptureDevices();
                Thread.Sleep(100);
            }
            public static void CallReSizeWindow(UInt32 WindowHandle, UInt32 NewWidth, UInt32 NewHeight)
            {
                ReSizeWindow(WindowHandle, NewWidth, NewHeight);
                Thread.Sleep(100);
            }

        }


        const string ScreenCaptureDLL = "VideoCapture.dll";
        [DllImport(ScreenCaptureDLL)]
        public static extern uint BeginVideoCapture(UInt32 WindowHandle, UInt32 WholeWindow, UInt32 X, UInt32 Y, UInt32 Width, UInt32 Height, UInt32 BitRate, UInt32 FrameRate, UInt32 Audio, StringBuilder Filename);

        [DllImport(ScreenCaptureDLL)]
        public static extern UInt32 CaptureVideoFrame();

        [DllImport(ScreenCaptureDLL)]
        public static extern UInt32 StopVideoCapture();

        [DllImport(ScreenCaptureDLL)]
        public static extern UInt32 EnumerateAndSaveWindows();

        [DllImport(ScreenCaptureDLL)]
        public static extern UInt32 EnumerateAndSaveAudioCaptureDevices();

        [DllImport(ScreenCaptureDLL)]
        public static extern UInt32 ReSizeWindow(UInt32 WindowHandle, UInt32 NewWidth, UInt32 NewHeight);

    }
}
