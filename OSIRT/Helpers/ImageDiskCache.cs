using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using OSIRT.Enums;
using System.Linq;
using System.Diagnostics;

namespace OSIRT.Helpers
{
    class ImageDiskCache 
    {
        
        public ImageDiskCache()
        {
            try
            {
                DirectoryInfo dirInfo = Directory.CreateDirectory(Constants.CacheLocation);
                dirInfo.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
            }
            catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
            {
                MessageBox.Show($"Unable to create temporary image cache. Reason: {ex}");
            }

        }

        public void AddImage(string name, Image image)
        {
            using (image)
            {
                string path = Path.Combine(Constants.CacheLocation, name + SaveableFileTypes.Png);
                Console.WriteLine(Constants.CacheLocation, name + SaveableFileTypes.Png);
                try
                {
                    if(File.Exists(path))
                    {
                        //something may still have a handle on the previous "temp" image
                        //this forces it to be GC'd
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                        File.Delete(path);
                    }
                    image.Save(path, ImageFormat.Png);
                }
                catch (System.Runtime.InteropServices.ExternalException e)
                {
                    MessageBox.Show($"Unable to add image temporary image cache. Reason: {e}");
                }
                catch(IOException ioe)
                {
                    MessageBox.Show(ioe.ToString());
                }
            }
        }

        public void AddImage(int count, Image image)
        {
            AddImage(count.ToString(), image);
        }


        public static void RemoveSpecificItemFromCache(string file)
        {
            try
            {
                //something may still have a handle on the previous "temp" image
                //this forces it to be GC'd
                GC.Collect();
                GC.WaitForPendingFinalizers();

                File.Delete(file);
            }
            catch (IOException ioe)
            {
                MessageBox.Show($"Unable to delete cache. Error: {ioe}");
            }
            catch (UnauthorizedAccessException uae)
            {
                MessageBox.Show($"Unable to delete cache. Error: {uae}");
            }

        }



        public static void RemoveItemsInCache()
        {
            try
            {
                //something may still have a handle on the previous "temp" image
                //this forces it to be GC'd
                GC.Collect();
                GC.WaitForPendingFinalizers();

                DirectoryInfo di = new DirectoryInfo(Constants.CacheLocation);
                var images = di.GetFiles().Where(ext => ext.Extension != ".mp4"); //don't want to delete video from cache
                foreach (var img in images)
                    img.Delete();

            }
            catch (IOException ioe)
            {
                MessageBox.Show($"Unable to delete cache. Error: {ioe}");
            }
            catch (UnauthorizedAccessException uae)
            {
                MessageBox.Show($"Unable to delete cache. Error: {uae}");
            } 
        }


    }
}
