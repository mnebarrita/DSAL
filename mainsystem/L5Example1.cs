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
            // store username -> password pairs
            var accounts = new Dictionary<string, string>()
    {
        { "Accounting", "AccountingPass123" },
        { "Admin", "AdminPass123" },
        { "Cashier1", "cash1pass" },
        { "Cashier2", "cash2pass" }
    };

            string enteredUser = usernameTxtbox.Text.Trim();
            string enteredPass = passwordTxtbox.Text;

            // verify credentials
            if (accounts.TryGetValue(enteredUser, out string correctPass) && enteredPass == correctPass)
            {
                MessageBox.Show("Welcome!!!");
                L5Example1 adminfrm = new L5Example1();
                adminfrm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Login Failed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                usernameTxtbox.Clear();
                passwordTxtbox.Clear();
                usernameTxtbox.Focus();
            }
        }
    }
}
