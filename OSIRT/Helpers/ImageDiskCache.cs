using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

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

                try
                {
                    if(File.Exists(path))
                    {
                        Debug.WriteLine("IN DELETE");
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                        File.Delete(path);
                    }
                    Debug.WriteLine("---------PATH---------" + path);
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

        public void RemoveImagesInCache()
        {
            try
            {
                Directory.Delete(Constants.CacheLocation, true);
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
