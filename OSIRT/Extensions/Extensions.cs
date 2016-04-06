using System.Collections.Generic;
using System.Linq;
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

        
    }
}
