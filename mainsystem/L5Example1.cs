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
    public partial class L5Example1 : Form
    {
        public L5Example1()
        {
            InitializeComponent();
        }

        private void L5Example1_Load(object sender, EventArgs e)
        {
            usernameTxtbox.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Admin, AdminPass,
                Cashier1, Cashier1Pass,
                Cashier2, Cashier2Pass,
                Accounting, AccountingPass;

            Admin = "Admin";
            AdminPass = "Admin";

            Cashier1 = "Cashier1";
            Cashier1Pass = "Cashier1";

            Cashier2 = "Cashier2";
            Cashier2Pass = "Cashier2";

            Accounting = "Accounting";
            AccountingPass = "AccountingPass";

            if (usernameTxtbox.Text == Admin && passwordTxtbox.Text == AdminPass)
            {
                L6MainForm newMDIChild = new L6MainForm();
                newMDIChild.Show();
            }
            else if (usernameTxtbox.Text == Cashier1 && passwordTxtbox.Text == Cashier1Pass)
            {
                Activity1 newMDIChild = new Activity1();
                newMDIChild.Show();
            }
            else if (usernameTxtbox.Text == Cashier2 && passwordTxtbox.Text == Cashier2Pass)
            {
                Activity2 newMDIChild = new Activity2();
                newMDIChild.Show();
            }
            else if (usernameTxtbox.Text == Accounting && passwordTxtbox.Text == AccountingPass)
            {
                EXAM newMDIChild = new EXAM();
                newMDIChild.Show();
            }
            else
            {
                MessageBox.Show("Wrong password or Username, try again",
                        "Login Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
