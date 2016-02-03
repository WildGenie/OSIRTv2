using ImageMagick;
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
        public static string CombineScreenshot(FileSystemInfo[] files)
        {
            string imageLocation = @"D:\\FinalImage.png";

            using (MagickImageCollection images = new MagickImageCollection())
            {
                // Add the first image
                var orderedFiles = files.OrderBy(f => f.CreationTime);
                foreach (FileSystemInfo file in orderedFiles)
                {
                    MagickImage first = new MagickImage(file.FullName);
                    images.Add(first);
                }


                using (MagickImage result = images.AppendVertically())
                {
                    result.Write(imageLocation);
                    return imageLocation;
                }
            }
        }
    }
}
