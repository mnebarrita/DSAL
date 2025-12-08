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

namespace mainsystem
{
    public partial class LoginFrm_Database : Form
    {
        loginDb_dbconnections login_db = new loginDb_dbconnections();
        public LoginFrm_Database()
        {
            InitializeComponent();
        }

        private void LoginFrm_Database_Load(object sender, EventArgs e)
        {
            //Center panel (UI logic) ---
            CenterPanel();
            this.Resize += (s, ev) => CenterPanel();

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
                // 1. Basic Validation
                if (string.IsNullOrWhiteSpace(usernameTxtBox.Text) || string.IsNullOrWhiteSpace(passwordTxtBox.Text))
                {
                    MessageBox.Show("Please enter both Username and Password.");
                    return;
                }

                // 2. Open Connection
                // Your helper class creates a NEW connection and opens it here
                login_db.login_connString();

                // 3. SQL Query
                // We check: Username match + Password match + Status is Active
                string sql = "SELECT * FROM useraccountTb1 WHERE username = '" + usernameTxtBox.Text + "' " +
                             "AND password = '" + passwordTxtBox.Text + "' " +
                             "AND user_status = 'Active'";

                login_db.login_sql = sql;
                login_db.login_cmd();
                login_db.login_sqladapterSelect();
                login_db.login_sqldatasetSELECT(); // Fills the dataset

                // 4. Check results
                // We use Tables[0] because your helper class might name the table "pos_empRegTb1" 
                // inside the dataset, even though we queried useraccountTb1.
                if (login_db.login_sql_dataset.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Login Successful! Welcome.");

                    // 5. OPEN MAIN MENU
                    // REPLACE 'employee_registration' WITH THE NAME OF YOUR MAIN DASHBOARD FORM
                    // Example: L6MainForm_Admin dashboard = new L6MainForm_Admin();

                    employee_registration dashboard = new employee_registration();
                    dashboard.Show();

                    this.Hide(); // Hide the login screen
                }
                else
                {
                    MessageBox.Show("Invalid Username or Password, or Account is Inactive.");
                }

                // 6. Close Connection
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
