using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mainsystem
{
    public partial class POS_Admin : Form
    {
        //Database connection helper(assumed to be defined elsewhere in project)
        //pos_dbconnection posdb_connect = new pos_dbconnection();
        private OpenFileDialog openFileDialog1 = new OpenFileDialog();

        // Local variables for image handling
        private string picpath;
        private Image pic;

        public POS_Admin()
        {
            InitializeComponent();
        }
        private void CenterPanel()
        {
            panelMain.Left = (this.ClientSize.Width - panelMain.Width) / 2;
            panelMain.Top = (this.ClientSize.Height - panelMain.Height) / 2;
        }

        private void POS_Admin_Load(object sender, EventArgs e)
        {
            CenterPanel();
            this.Resize += (s, ev) => CenterPanel();
        }
    }

}
