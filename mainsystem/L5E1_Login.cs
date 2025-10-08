using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace mainsystem
{
    public partial class L5E1_Login : Form
    {
        public L5E1_Login()
        {
            InitializeComponent();
        }

        private void L5Example1_Load(object sender, EventArgs e)
        {

            CenterPanel();
            this.Resize += (s, ev) => CenterPanel();

            this.AcceptButton = button1;
            button1.Focus();

            passwordTxtbox.UseSystemPasswordChar = true;
            passwordTxtbox.PasswordChar = '●';

            this.BackgroundImage = Properties.Resources.background1;
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void CenterPanel()
        {
            panelMain.Left = (this.ClientSize.Width - panelMain.Width) / 2;
            panelMain.Top = (this.ClientSize.Height - panelMain.Height) / 2;
            pictureBox1.Left = (this.ClientSize.Width - pictureBox1.Width) / 2 + 25;
            pictureBox1.Top = (this.ClientSize.Height - pictureBox1.Height) / 2 - 125;
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
            AccountingPass = "Accounting";

            if (usernameTxtbox.Text == Admin && passwordTxtbox.Text == AdminPass)
            {
                L6MainForm_Admin newMDIChild = new L6MainForm_Admin();
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
                EXAM_Cashier newMDIChild = new EXAM_Cashier();
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void usernameTxtbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void passwordTxtbox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
