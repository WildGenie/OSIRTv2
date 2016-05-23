using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace OSIRT.Extensions
{
    public static class Extensions
    {
        public static IEnumerable<TControl> GetChildControls<TControl>(this Control control) where TControl : Control
        {
            var children = control.Controls.OfType<TControl>();
            return children.SelectMany(c => GetChildControls<TControl>(c)).Concat(children).OrderBy(c => c.TabIndex); //Added this orderby on 06/05.
        }

        public static string SplitAtCapitalLetter(this string toSplit)
        {
            var r = new Regex(@"(?<=[A-Z])(?=[A-Z][a-z]) | (?<=[^A-Z])(?=[A-Z]) | (?<=[A-Za-z])(?=[^A-Za-z])", RegexOptions.IgnorePatternWhitespace);
            return r.Replace(toSplit, " ");
        }

        public static string ToTitleCase(this string toTitle)
        {
            if (toTitle.Contains("_")) //database tables joined by '_'
                toTitle = toTitle.Replace("_", " ");

            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(toTitle);
        }

        private static readonly string[] ValidExtensions = { ".jpg", ".jpeg", ".tiff", ".bmp", ".gif", ".png" };
        public static bool HasImageExtension(this string path)
        {
            string fileName = Path.GetExtension(path);
            return ValidExtensions.Contains(fileName.ToLower());
        }

        private static readonly string[] ValidVideoExtensions = { ".mp4" };
        public static bool HasVideoExtension(this string path)
        {
            string fileName = Path.GetExtension(path);
            return ValidVideoExtensions.Contains(fileName.ToLower());
        }


        public static string ToBase64Encoded(this Image image)
        {
            using (MemoryStream m = new MemoryStream())
            {
                image.Save(m, ImageFormat.Png);
                byte[] imageBytes = m.ToArray();

                // Convert byte[] to Base64 String
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }

        public static Image Base64ToImage(this string base64String)
        {
            // Convert base 64 string to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            // Convert byte[] to Image
            using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                Image image = Image.FromStream(ms, true);
                return image;
            }
        }

        public static bool ContainsAnchor(this HtmlElement element)
        {
            if (element.TagName == "A")
                return true;

            return false;
        }

    }
}
