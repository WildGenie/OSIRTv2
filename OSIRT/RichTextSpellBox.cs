using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Forms.Integration;

namespace OSIRT
{
    [DesignerSerializer("System.Windows.Forms.Design.ControlCodeDomSerializer, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    public class RichTextSpellBox : ElementHost
     {

        private RichTextBox box;

        public RichTextSpellBox()
        {
            box = new RichTextBox();
            base.Child = box;
            box.TextChanged += (s, e) => OnTextChanged(EventArgs.Empty);
            box.SpellCheck.IsEnabled = true;
            box.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
            Size = new System.Drawing.Size(100, 20);
         }

        public override string Text
        {
            get
            {
                return new TextRange(box.Document.ContentStart, box.Document.ContentEnd).Text; ;
            }
            set
            {
                box.Document.Blocks.Clear();
                box.Document.Blocks.Add(new Paragraph(new Run(value)));
            }
        }

        [DefaultValue(false)]
        public bool Multiline
        {
            get { return box.AcceptsReturn; }
            set { box.AcceptsReturn = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new UIElement Child
        {
            get { return base.Child; }
            set { /* Do nothing to solve a problem with the serializer !! */ }
        }

        public new event System.Windows.Input.KeyEventHandler KeyDown
        {
            add { box.KeyDown += value; }
            remove { box.KeyDown -= value; }
        }

        public new event System.Windows.Input.KeyEventHandler KeyUp
        {
            add { box.KeyUp += value; }
            remove { box.KeyUp -= value; }
        }




        }

}

