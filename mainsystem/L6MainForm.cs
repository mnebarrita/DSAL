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
    public partial class L6MainForm : Form
    {
        public L6MainForm()
        {
            InitializeComponent();
        }

        private void cashier1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            L3Activity3 newMDIChild = new L3Activity3();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void cashier2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Activity2 newMDIChild = new Activity2();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void simplePOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Activity1 newMDIChild = new Activity1();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void userAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void userAccountPageToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void payrolApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Activity5 newMDIChild = new Activity5();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void quizToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Quiz1 newMDIChild = new Quiz1();
            newMDIChild.MdiParent = this;
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

        private void activity1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Activity1 newMDIChild = new Activity1();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void activity2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Activity2 newMDIChild = new Activity2();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void activity3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Activity3 newMDIChild = new Activity3();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void activity4ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void activity5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Activity5 newMDIChild = new Activity5();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void l2Example3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            L2E3 newMDIChild = new L2E3();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void l1Example1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            L2E3 newMDIChild = new L2E3();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void payrollToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
