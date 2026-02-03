using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using mainsystem.L14_Classes;
using mainsystem.Prelim;

namespace mainsystem
{
    public partial class LoginFrm_Database : Form
    {
        loginDb_dbconnections login_db = new loginDb_dbconnections();
        public LoginFrm_Database()
        {
            InitializeComponent();
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

        private void LoginFrm_Database_Load(object sender, EventArgs e)
        {
            //Center panel (UI logic) ---
            CenterPanel();
            this.Resize += (s, ev) => CenterPanel();
            this.BackgroundImage = Properties.Resources.login;
            this.BackgroundImageLayout = ImageLayout.Stretch;

            usernameTxtBox.Focus();

            passwordTxtBox.UseSystemPasswordChar = true;
        }

        private void CenterPanel()
        {
            panelMain.Left = (this.ClientSize.Width - panelMain.Width) / 2;
            panelMain.Top = (this.ClientSize.Height - panelMain.Height) / 2;
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(usernameTxtBox.Text) || string.IsNullOrWhiteSpace(passwordTxtBox.Text))
                {
                    MessageBox.Show("Please enter both Username and Password.");
                    return;
                }

                login_db.login_connString();

                // Check Username, Password AND if Active
                string sql = "SELECT * FROM useraccountTb1 WHERE username = '" + usernameTxtBox.Text + "' " +
                             "AND password = '" + passwordTxtBox.Text + "' " +
                             "AND user_status = 'Active'";

                login_db.login_sql = sql;
                login_db.login_cmd();
                login_db.login_sqladapterSelect();
                login_db.login_sqldatasetSELECT();

                // CHECK IF USER EXISTS
                if (login_db.login_sql_dataset.Tables[0].Rows.Count > 0)
                {

                    // GET THE ACCOUNT TYPE FROM DATABASE
                    DataRow row = login_db.login_sql_dataset.Tables[0].Rows[0];
                    string accountType = row["account_type"].ToString();
                    Program.CurrentEmpID = usernameTxtBox.Text;
                    MessageBox.Show("Login Successful! Welcome, " + accountType);
                    this.Hide();

                    switch (accountType)
                    {
                        case "Administrator":
                            L6MainForm_Admin adminForm = new L6MainForm_Admin();

                            adminForm.FormClosed += (s, args) => this.Show();

                            adminForm.Show();
                            this.Hide();
                            break;

                        case "Cashier 1":
                            SQLPOS1Class cashier1Form = new SQLPOS1Class();

                            cashier1Form.FormClosed += (s, args) => this.Show();

                            cashier1Form.Show();
                            this.Hide();
                            break;

                        case "Cashier 2":
                            SQLPOS2Class cashier2Form = new SQLPOS2Class();

                            cashier2Form.FormClosed += (s, args) => this.Show();

                            cashier2Form.Show();
                            this.Hide();
                            break;

                        case "Accounting Staff":
                            employee_payrol accountingForm = new employee_payrol();

                            accountingForm.FormClosed += (s, args) => this.Show();

                            accountingForm.Show();
                            this.Hide();
                            break;

                        case "HR Staff":
                            employee_registration hrForm = new employee_registration();

                            hrForm.FormClosed += (s, args) => this.Show();

                            hrForm.Show();
                            this.Hide();
                            break;

                        case "IT Staff":
                            user_account itForm = new user_account();

                            itForm.FormClosed += (s, args) => this.Show();

                            itForm.Show();
                            this.Hide();
                            break;

                        default:
                            MessageBox.Show("Role recognized but no form assigned yet.");
                            break;
                    }


                }
                else
                {
                    MessageBox.Show("Invalid Username, Password, or Account is Inactive.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (login_db.login_sql_connection.State == ConnectionState.Open)
                    login_db.login_sql_connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Login Error: " + ex.Message);
            }
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void passwordTxtBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loginBtn_Click(sender, e);
            }
        }
    }
}
