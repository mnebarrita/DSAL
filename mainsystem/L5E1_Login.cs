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
    public partial class L5E1_Login : Form
    {
        public L5E1_Login()
        {
            InitializeComponent();
            this.Opacity = 0;
        }

        private void L5Example1_Load(object sender, EventArgs e)
        {
            usernameTxtbox.Focus();
            passwordTxtbox.UseSystemPasswordChar = true;
            this.AcceptButton = button1;
            this.CenterLoginElements(); // (your centering function)

            this.BackgroundImage = Properties.Resources.MyBackground;
            this.BackgroundImageLayout = ImageLayout.Stretch;



        }

        private void CenterLoginElements()
        {
            // Center the group box (login area)
            int x = (this.ClientSize.Width - groupBox1.Width) / 2;
            int y = (this.ClientSize.Height - groupBox1.Height) / 2;
            groupBox1.Location = new Point(x, y);

            // Center the cat picture above the group box
            pictureBox1.Location = new Point(
                groupBox1.Left + (groupBox1.Width - pictureBox1.Width) / 2,
                groupBox1.Top - pictureBox1.Height + 100 // Adjust 10 for overlap
            );
        }

        private void L5E1_Login_Resize(object sender, EventArgs e)
        {
            CenterLoginElements();
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
            this.Opacity = 0.95;
            this.BackColor = Color.Black;
            this.TransparencyKey = Color.Empty;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
