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
        }

        private void L5Example1_Load(object sender, EventArgs e)
        {
            CenterPanel();
            this.Resize += (s, ev) => CenterPanel();

            SetPlaceholder(usernameTxtbox, "Username");
            SetPlaceholder(passwordTxtbox, "Password", true);
            this.AcceptButton = button1;
            button1.Focus();
            this.BackgroundImage = Properties.Resources.background1;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            StyleButton(button1);
            StyleButton(button2);


        }

        private void CenterPanel()
        {
            panelMain.Left = (this.ClientSize.Width - panelMain.Width) / 2;
            panelMain.Top = (this.ClientSize.Height - panelMain.Height) / 2;
            pictureBox1.Left = (this.ClientSize.Width - pictureBox1.Width) / 2 + 25;
            pictureBox1.Top = (this.ClientSize.Height - pictureBox1.Height) / 2 - 125;
        }

        private void SetPlaceholder(TextBox textBox, string placeholder, bool isPassword = false)
        {
            // Initial placeholder setup
            textBox.Text = placeholder;
            textBox.ForeColor = Color.FromArgb(180, 180, 180);
            if (isPassword)
                textBox.UseSystemPasswordChar = false; // show placeholder

            textBox.GotFocus += (s, e) =>
            {
                if (textBox.Text == placeholder)
                {
                    textBox.Text = "";
                    textBox.ForeColor = Color.Black;

                    // Enable password masking *after* clearing text
                    if (isPassword)
                    {
                        textBox.UseSystemPasswordChar = true;
                        textBox.PasswordChar = '●'; // optional: nicer bullet symbol
                    }
                }
            };

            textBox.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    // Disable password mask so placeholder shows
                    if (isPassword)
                        textBox.UseSystemPasswordChar = false;

                    textBox.Text = placeholder;
                    textBox.ForeColor = Color.Gray;
                }
            };
        }


        private void StyleButton(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = Color.FromArgb(100, 255, 255, 255); // translucent white
            btn.ForeColor = Color.Black;
            btn.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            btn.Cursor = Cursors.Hand;

            btn.Paint += (s, e) =>
            {
                int radius = 15;
                var rect = new Rectangle(0, 0, btn.Width, btn.Height);
                var path = new System.Drawing.Drawing2D.GraphicsPath();
                path.AddArc(0, 0, radius, radius, 180, 90);
                path.AddArc(btn.Width - radius, 0, radius, radius, 270, 90);
                path.AddArc(btn.Width - radius, btn.Height - radius, radius, radius, 0, 90);
                path.AddArc(0, btn.Height - radius, radius, radius, 90, 90);
                path.CloseAllFigures();

                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                e.Graphics.FillPath(new SolidBrush(btn.BackColor), path);
            };

            btn.MouseEnter += (s, e) => btn.BackColor = Color.FromArgb(180, 255, 255, 255);
            btn.MouseLeave += (s, e) => btn.BackColor = Color.FromArgb(100, 255, 255, 255);
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
