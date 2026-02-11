using mainsystem.Prelim;
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
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on Double Buffering at the OS level
                return cp;
            }
        }

        private void payrolApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            employee_payrol newMDIChild = new employee_payrol();
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
            AdminLoungeFrm lounge = new AdminLoungeFrm();
            lounge.MdiParent = this;
            lounge.Dock = DockStyle.Fill;
            lounge.Show();
        }


        private void logoutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void sQLPOS1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SQLPOS1Class newMDIChild = new SQLPOS1Class();
            newMDIChild.MdiParent = this;
            newMDIChild.WindowState = FormWindowState.Maximized;
            newMDIChild.Show();
        }

        private void sQLPOS2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SQLPOS2Class newMDIChild = new SQLPOS2Class();
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

        private void emplToolStripMenuItem_Click(object sender, EventArgs e)
        {
            employee_registration newMDIChild = new employee_registration();
            newMDIChild.MdiParent = this;
            newMDIChild.WindowState = FormWindowState.Maximized;
            newMDIChild.Show();
        }

        private void userAccountToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            user_account newMDIChild = new user_account();
            newMDIChild.MdiParent = this;
            newMDIChild.WindowState = FormWindowState.Maximized;
            newMDIChild.Show();
        }

        private void employeeReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            employee_reports newMDIChild = new employee_reports();
            newMDIChild.MdiParent = this;
            newMDIChild.WindowState = FormWindowState.Maximized;
            newMDIChild.Show();
        }

        private void payrolReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            payrol_report newMDIChild = new payrol_report();
            newMDIChild.MdiParent = this;
            newMDIChild.WindowState = FormWindowState.Maximized;
            newMDIChild.Show();
        }

        private void salesReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sales_reports newMDIChild = new sales_reports();
            newMDIChild.MdiParent = this;
            newMDIChild.WindowState = FormWindowState.Maximized;
            newMDIChild.Show();
        }

        private void userAccountReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            useraccount_report newMDIChild = new useraccount_report();
            newMDIChild.MdiParent = this;
            newMDIChild.WindowState = FormWindowState.Maximized;
            newMDIChild.Show();
        }

        private void payrollClassFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Payroll_ClassForm newMDIChild = new Payroll_ClassForm();
            newMDIChild.MdiParent = this;
            newMDIChild.WindowState = FormWindowState.Maximized;
            newMDIChild.Show();
        }

        private void payrollFunctionFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Payroll_FunctionForm newMDIChild = new Payroll_FunctionForm();
            newMDIChild.MdiParent = this;
            newMDIChild.WindowState = FormWindowState.Maximized;
            newMDIChild.Show();
        }

        private void pOS1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            POS1_ClassForm newMDIChild = new POS1_ClassForm();
            newMDIChild.MdiParent = this;
            newMDIChild.WindowState = FormWindowState.Maximized;
            newMDIChild.Show();
        }

        private void pOS1ToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            POS1_FunctionForm newMDIChild = new POS1_FunctionForm();
            newMDIChild.MdiParent = this;
            newMDIChild.WindowState = FormWindowState.Maximized;
            newMDIChild.Show();
        }

        private void pOS2ClassFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            POS2_ClassForm newMDIChild = new POS2_ClassForm();
            newMDIChild.MdiParent = this;
            newMDIChild.WindowState = FormWindowState.Maximized;
            newMDIChild.Show();
        }

        private void pOS2FunctionFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            POS2_FunctionForm newMDIChild = new POS2_FunctionForm();
            newMDIChild.MdiParent = this;
            newMDIChild.WindowState = FormWindowState.Maximized;
            newMDIChild.Show();
        }

        private void l1E1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Activity1 newMDIChild = new Activity1();
            newMDIChild.MdiParent = this;
            newMDIChild.WindowState = FormWindowState.Maximized;
            newMDIChild.Show();
        }

        private void l1E2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Activity2 newMDIChild = new Activity2();
            newMDIChild.MdiParent = this;
            newMDIChild.WindowState = FormWindowState.Maximized;
            newMDIChild.Show();
        }

        private void l1E3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Activity3 newMDIChild = new Activity3();
            newMDIChild.MdiParent = this;
            newMDIChild.WindowState = FormWindowState.Maximized;
            newMDIChild.Show();
        }

        private void l2A2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            L2Activity2_Cashier newMDIChild = new L2Activity2_Cashier();
            newMDIChild.MdiParent = this;
            newMDIChild.WindowState = FormWindowState.Maximized;
            newMDIChild.Show();
        }

        private void l2A3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            L3Activity3 newMDIChild = new L3Activity3();
            newMDIChild.MdiParent = this;
            newMDIChild.WindowState = FormWindowState.Maximized;
            newMDIChild.Show();
        }

        private void l3QuizToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Quiz1 newMDIChild = new Quiz1();
            newMDIChild.MdiParent = this;
            newMDIChild.WindowState = FormWindowState.Maximized;
            newMDIChild.Show();
        }

        private void l5A5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Activity5 newMDIChild = new Activity5();
            newMDIChild.MdiParent = this;
            newMDIChild.WindowState = FormWindowState.Maximized;
            newMDIChild.Show();
        }

        private void payslipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SampleLongMethod newMDIChild = new SampleLongMethod();
            newMDIChild.MdiParent = this;
            newMDIChild.WindowState = FormWindowState.Maximized;
            newMDIChild.Show();
        }

        private void adminLoungeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdminLoungeFrm lounge = new AdminLoungeFrm();
            lounge.MdiParent = this; 
            lounge.Dock = DockStyle.Fill; 
            lounge.Show();
        }

    }
}
