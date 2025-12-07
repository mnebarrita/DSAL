using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mainsystem.Prelim
{
    public partial class employee_payrol : Form
    {
        public employee_payrol()
        {
            InitializeComponent();
        }

        private void employee_payrol_Load(object sender, EventArgs e)
        {
            //Center panel (UI logic) ---
            CenterPanel();
            this.Resize += (s, ev) => CenterPanel();
        }

        private void CenterPanel()
        {
            panelMain.Left = (this.ClientSize.Width - panelMain.Width) / 2;
            panelMain.Top = (this.ClientSize.Height - panelMain.Height) / 2;
        }
    }
}
