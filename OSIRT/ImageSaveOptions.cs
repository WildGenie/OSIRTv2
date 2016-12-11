using ImageMagick;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSIRT
{
    public class ImageSaveOptions
    {
        public string FileName { get; set; }
        public MagickFormat ImageFormat { get; set; }
        public string FileType { get; set; }

        public ImageSaveOptions(string fileName, MagickFormat format, string fileType)
        {
            FileName = fileName;
            ImageFormat = format;
            FileType = fileType;
        }

    }
}
