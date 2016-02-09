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
    public partial class FirstLoadPanel : UserControl
    {
        private ToolTip tooltip;

        public FirstLoadPanel()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            AddBallonTipsToButtons();
        }

        private void AddBallonTipsToButtons()
        {
            tooltip = new ToolTip();
            tooltip.IsBalloon = true;
            tooltip.SetToolTip(uiNewCaseButton, "Creates a brand new OSIRT case.");

        }

        private void uiFirstLoadPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void uiNewCaseButton_Click(object sender, EventArgs e)
        {

        }
    }
}
