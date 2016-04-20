using System.Collections.Generic;
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
            return children.SelectMany(c => GetChildControls<TControl>(c)).Concat(children);
        }

        public static string SplitAtCapitalLetter(this string toSplit)
        {
            var r = new Regex(@"(?<=[A-Z])(?=[A-Z][a-z]) | (?<=[^A-Z])(?=[A-Z]) | (?<=[A-Za-z])(?=[^A-Za-z])", RegexOptions.IgnorePatternWhitespace);
            return r.Replace(toSplit, " ");
        }

        private static readonly string[] validExtensions = { ".jpg", ".jpeg", ".tiff", ".bmp", ".gif", ".png" };
        public static bool HasImageExtension(this string path)
        {
            string fileName = Path.GetExtension(path);
            return validExtensions.Contains(fileName.ToLower());
        }

        public static bool ContainsAnchor(this HtmlElement element)
        {
            if (element.TagName == "A")
                return true;

            return false;
        }

    }
}
