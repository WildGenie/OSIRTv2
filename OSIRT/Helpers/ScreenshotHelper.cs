using ImageMagick;
using Jacksonsoft;
using OSIRT.Helpers;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace OSIRT.Helpers
{
    public class ScreenshotHelper
    {

        public static void SaveScreenshot(Image screenshot, string name)
        {
            using (screenshot)
            {
                string path = Path.Combine(Constants.ContainerLocation, Constants.Directories.GetSpecifiedCaseDirectory("screenshots"), name);
                screenshot.Save(path, ImageFormat.Png);
            }

        }

        /// <summary>
        /// Adds the specified image to the temporary disk cache
        /// </summary>
        /// <param name="screenshot">The Image to save to the cache</param>
        /// <returns>True if save did not throw an exception (it was successful), false otherwise.</returns>
        /// <remarks>This image will get removed from the cache once utilised.</remarks>
        public static bool SaveScreenshotToCache(Image screenshot)
        {
            bool saved = false;

            ImageDiskCache cache = new ImageDiskCache();
            cache.AddImage("temp", screenshot);
       
            return saved;
        }


        public static void CombineScreenshot(FileSystemInfo[] files, WaitWindowEventArgs e)
        {
            //string screenshotLocation =  Path.Combine(Constants.ContainerLocation, Constants.Directories.GetSpecifiedCaseDirectory("screenshots"), "temp.png");

            string screenshotLocation = Path.Combine(Constants.CacheLocation, "temp.png");

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
                    e.Window.Message = "Building Screenshot... Please Wait" + System.Environment.NewLine + "This can take a minute.";
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
