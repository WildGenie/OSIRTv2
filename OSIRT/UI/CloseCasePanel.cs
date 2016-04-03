using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSIRT.UI
{
    public partial class CloseCasePanel : UserControl
    {
        public event EventHandler PasswordCorrect;


        public CloseCasePanel()
        {
            InitializeComponent();
        }

        private void CloseCasePanel_Load(object sender, EventArgs e)
        {
            Dock = DockStyle.Fill;
        }

        private void uiOKButton_Click(object sender, EventArgs e)
        {
            //get password
            //compare it to the hash using verify
            //if it's fine, invoke PasswordCorrect
            //otherwise, tell the user it's incorrect.
            

            PasswordCorrect?.Invoke(this, e);
        }
    }
}
