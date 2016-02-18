using ImageMagick;
using Jacksonsoft;
using OSIRT.Helpers;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;

namespace OSIRT.Database
{
    public class ScreenshotHelper
    {

        public static void SaveScreenshot(Image screenshot, string name)
        {
            using (screenshot)
            {
                screenshot.Save(Path.Combine(Constants.ContainerLocation, Constants.Directories.GetSpecifiedCaseDirectory("screenshots"), name), ImageFormat.Png);
            }

        }


        public static void CombineScreenshot(FileSystemInfo[] files, WaitWindowEventArgs e)
        {
            string screenshotLocation =  Path.Combine(Constants.ContainerLocation, Constants.Directories.GetSpecifiedCaseDirectory("screenshots"), "temp.png");

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
                    e.Window.Message = "Building Screenshot... Please Wait" + System.Environment.NewLine + "This can take a couple of minutes.";
                    try
                    {
                        result.Write(screenshotLocation);
                    } catch (MagickImageErrorException err)
                    {
                        Debug.WriteLine($"Error: {err}");
                    }
                   
                }
        
            }
        }
    }
}
