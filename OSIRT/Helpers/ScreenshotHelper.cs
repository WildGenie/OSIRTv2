using ImageMagick;
using Jacksonsoft;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSIRT.Helpers
{
    public class ScreenshotHelper
    {
        public static string CombineScreenshot(FileSystemInfo[] files, WaitWindowEventArgs e)
        {
            string imageLocation = @"D:\\FinalImage.png";

            using (MagickImageCollection images = new MagickImageCollection())
            {
                // Add the first image
                var orderedFiles = files.OrderBy(f => f.CreationTime);
                foreach (FileSystemInfo file in orderedFiles)
                {
                    MagickImage first = new MagickImage(file.FullName);
                    e.Window.Message = "Obtaining Snapshots... Please Wait";
                    images.Add(first);
                }


                using (MagickImage result = images.AppendVertically())
                {
                    e.Window.Message = "Building Screenshot... Please Wait (This can take a couple of minutes)";
                    result.Write(imageLocation);
                    return imageLocation;
                }
            }
        }
    }
}
