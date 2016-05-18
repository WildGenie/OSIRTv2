using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSIRT.UI
{
    public partial class UnhandledExceptionForm : Form
    {
        public UnhandledExceptionForm(string exceptionMessage)
        {
            InitializeComponent();
            uiExceptionMessageTextBox.Text = exceptionMessage;
        }

        private void UnhandledExceptionForm_Load(object sender, EventArgs e)
        {
        }
    }
}
