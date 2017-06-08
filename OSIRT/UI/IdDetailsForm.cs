using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSIRT.UI
{
    public partial class IdDetailsForm : Form
    {
        public IdDetailsForm(string id, string formTitle)
        {
            InitializeComponent();
            if(string.IsNullOrEmpty(id))
            {
                id = "Not found...";
            }
            uiFacebookIdTextBox.Text = id;
            Text = formTitle + " ID";
        }

        private void FacebookDetailsForm_Load(object sender, EventArgs e)
        {
            //pass in page source as string
            //parse out number ",uid:"
            //that's the user id
        }
    }
}
