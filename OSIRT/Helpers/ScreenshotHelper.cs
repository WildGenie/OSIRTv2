using ImageMagick;
using Jacksonsoft;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;


namespace OSIRT.Helpers
{
    public class ScreenshotHelper
    {

        public static void SaveScreenshot(Image screenshot, string name)
        {
            using (screenshot)
            {
                screenshot.Save(Path.Combine(Constants.ContainerLocation, Constants.Directories.GetDirectory("screenshots"), name), ImageFormat.Png);
            }

        }


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
