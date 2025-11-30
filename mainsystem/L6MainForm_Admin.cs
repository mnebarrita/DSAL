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
    public partial class L6MainForm_Admin : Form
    {
        public L6MainForm_Admin()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void cashier1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            L3Activity3 newMDIChild = new L3Activity3();
            newMDIChild.MdiParent = this;
            newMDIChild.WindowState = FormWindowState.Maximized;
            newMDIChild.Show();
        }

        private void cashier2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EXAM_Cashier newMDIChild = new EXAM_Cashier();
            newMDIChild.MdiParent = this;
            this.FormBorderStyle = FormBorderStyle.None;
            newMDIChild.WindowState = FormWindowState.Maximized;
            newMDIChild.Show();
        }

        private void simplePOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Activity1 newMDIChild = new Activity1();
            newMDIChild.MdiParent = this;
            newMDIChild.WindowState = FormWindowState.Maximized;
            newMDIChild.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void payrolApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Payroll_FunctionForm newMDIChild = new Payroll_FunctionForm();
            newMDIChild.MdiParent = this;
            newMDIChild.WindowState = FormWindowState.Maximized;
            newMDIChild.Show();
        }
        private void tileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void tileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void payrollToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void L6MainForm_Load(object sender, EventArgs e)
        {

        }

        private void studentRegistrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Quiz1 newMDIChild = new Quiz1();
            newMDIChild.MdiParent = this;
            newMDIChild.WindowState = FormWindowState.Maximized;
            newMDIChild.Show();
        }

        private void example1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Activity1 newMDIChild = new Activity1();
            newMDIChild.MdiParent = this;
            newMDIChild.WindowState = FormWindowState.Maximized;
            newMDIChild.Show();
        }

        private void example2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Activity2 newMDIChild = new Activity2();
            newMDIChild.MdiParent = this;
            newMDIChild.WindowState = FormWindowState.Maximized;
            newMDIChild.Show();
        }

        private void example3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Activity3 newMDIChild = new Activity3();
            newMDIChild.MdiParent = this;
            newMDIChild.WindowState = FormWindowState.Maximized;
            newMDIChild.Show();
        }

        private void example21ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            L2Activity2_Cashier newMDIChild = new L2Activity2_Cashier();
            newMDIChild.MdiParent = this;
            newMDIChild.WindowState = FormWindowState.Maximized;
            newMDIChild.Show();
        }

        private void example31ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            L3Activity3 newMDIChild = new L3Activity3();
            newMDIChild.MdiParent = this;
            newMDIChild.WindowState = FormWindowState.Maximized;
            newMDIChild.Show();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {

        }

        private void cashier1ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            POS1_FunctionForm newMDIChild = new POS1_FunctionForm();
            newMDIChild.MdiParent = this;
            newMDIChild.WindowState = FormWindowState.Maximized;
            newMDIChild.Show();
        }

        private void cashier2ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            POS2_FunctionForm newMDIChild = new POS2_FunctionForm();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void simplePOSToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Activity1 newMDIChild = new Activity1();
            newMDIChild.MdiParent = this;
            newMDIChild.WindowState = FormWindowState.Maximized;
            newMDIChild.Show();
        }

        private void payrollApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Payroll_FunctionForm newMDIChild = new Payroll_FunctionForm();
            newMDIChild.MdiParent = this;
            newMDIChild.WindowState = FormWindowState.Maximized;
            newMDIChild.Show();
        }

        private void studentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Quiz1 newMDIChild = new Quiz1();
            newMDIChild.MdiParent = this;
            newMDIChild.WindowState = FormWindowState.Maximized;
            newMDIChild.Show();
        }

        private void logoutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /*private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            statusStrip1.Items.Add("Welcome, Admin");
            statusStrip1.Items.Add(DateTime.Now.ToString("f"));
        }*/

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void pOS1ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            POS1_FunctionForm newMDIChild = new POS1_FunctionForm();
            newMDIChild.MdiParent = this;
            newMDIChild.WindowState = FormWindowState.Maximized;
            newMDIChild.Show();
        }

        private void pOS1ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            POS1_ClassForm newMDIChild = new POS1_ClassForm();
            newMDIChild.MdiParent = this;
            newMDIChild.WindowState = FormWindowState.Maximized;
            newMDIChild.Show();
        }

        private void pOS2ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            POS2_ClassForm newMDIChild = new POS2_ClassForm();
            newMDIChild.MdiParent = this;
            newMDIChild.WindowState = FormWindowState.Maximized;
            newMDIChild.Show();
        }
        private void pOS2ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            POS2_FunctionForm newMDIChild = new POS2_FunctionForm();
            newMDIChild.MdiParent = this;
            newMDIChild.WindowState = FormWindowState.Maximized;
            newMDIChild.Show();
        }

        private void payrolClassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Payroll_ClassForm newMDIChild = new Payroll_ClassForm();
            newMDIChild.MdiParent = this;
            newMDIChild.WindowState = FormWindowState.Maximized;
            newMDIChild.Show();
        }

        private void pOSAdminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            POS_Admin newMDIChild = new POS_Admin();
            newMDIChild.MdiParent = this;
            newMDIChild.WindowState = FormWindowState.Maximized;
            newMDIChild.Show();
        }

        private void sampleLongMethodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SampleLongMethod newMDIChild = new SampleLongMethod();
            newMDIChild.MdiParent = this;
            newMDIChild.WindowState = FormWindowState.Maximized;
            newMDIChild.Show();
        }
    }
}
