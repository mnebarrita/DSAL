using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mainsystem
{
    public partial class Activity_4_PrintFrm : Form
    {
        public Activity_4_PrintFrm()
        {
            InitializeComponent();
            printdisplayListbox.Items.AddRange(printdisplayListbox.Items);
        }

        private void Activity_4_PrintFrm_Load(object sender, EventArgs e)
        {

        }
    }
}
