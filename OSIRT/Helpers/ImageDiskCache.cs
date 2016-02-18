using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace OSIRT.Helpers
{
    class ImageDiskCache 
    {
        public static readonly string CacheLocation = Path.Combine(Application.StartupPath, "cache");
        private int count = 0;
        public ImageDiskCache()
        {
            DirectoryInfo dirInfo = Directory.CreateDirectory(CacheLocation);
            dirInfo.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
        }

        public void AddImage(Image image)
        {
            count++;
            image.Save(Path.Combine(CacheLocation, count + ".png"), ImageFormat.Png);
            image.Dispose();
        }

        public void RemoveImagesInCache()
        {
            try {
                Directory.Delete(CacheLocation, true);
            } catch (IOException e)
            {
                MessageBox.Show("unable to delete cache!");
            }
        }


    }
}
