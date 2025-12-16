using mainsystem.L14_Classes;
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
    public partial class user_account : Form
    {
        useraccount_db_connection user_db = new useraccount_db_connection();
        employee_dbconnection emp_db = new employee_dbconnection();
        public user_account()
        {
            InitializeComponent();
        }

        private void OpenUserConnection()
        {
            user_db.useraccount_connString();
            if (user_db.useraccount_sql_connection.State == ConnectionState.Closed)
            {
                user_db.useraccount_sql_connection.ConnectionString = user_db.useraccount_connectionString;
                user_db.useraccount_sql_connection.Open();
            }
        }

        private void CloseUserConnection()
        {
            if (user_db.useraccount_sql_connection.State == ConnectionState.Open)
                user_db.useraccount_sql_connection.Close();
        }

        private void user_account_Load(object sender, EventArgs e)
        {
            //Center panel (UI logic) ---
            CenterPanel();
            this.Resize += (s, ev) => CenterPanel();

            LoadGrid(); // Show existing accounts

            // --- Names Placeholders ---
            fnameTxtBox.Text = "First Name";
            fnameTxtBox.ForeColor = Color.Silver;

            mnameTxtBox.Text = "Middle Name";
            mnameTxtBox.ForeColor = Color.Silver;

            surnameTxtBox.Text = "Surname";
            surnameTxtBox.ForeColor = Color.Silver;

            // --- Password Placeholders ---
            passwordTxtBox.UseSystemPasswordChar = false;
            passwordTxtBox.Text = "Password";
            passwordTxtBox.ForeColor = Color.Silver;

            confirmPassTxtBox.UseSystemPasswordChar = false;
            confirmPassTxtBox.Text = "Confirm Password";
            confirmPassTxtBox.ForeColor = Color.Silver;

            fnameTxtBox.Enabled = false;
            mnameTxtBox.Enabled = false;
            surnameTxtBox.Enabled = false;
            designationTxtBox.Enabled = false;

            ApplySecurityRestrictions();
        }
        private void ApplySecurityRestrictions()
        {
            // 1. Get the Role
            string role = GetCurrentRole();

            // 2. IT STAFF RESTRICTIONS
            if (role == "IT Staff")
            {
                // DISABLE UPDATE
                if (updateBtn != null) updateBtn.Enabled = false;

                // DISABLE DELETE
                if (deleteBtn != null) deleteBtn.Enabled = false;

                // DISABLE SEARCH FOR UPDATE
                if (searchUpdateBtn != null) searchUpdateBtn.Enabled = false;
            }
        }

        private string GetCurrentRole()
        {
            string role = "";
            try
            {
                posdb_connect db = new posdb_connect();
                db.pos_connString();
                db.posdb_open();

                // Get account_type based on the Global ID
                string sql = "SELECT account_type FROM useraccountTb1 WHERE username = '" + Program.CurrentEmpID + "'";

                db.pos_sql = sql;
                db.pos_cmd();

                object result = db.pos_sql_command.ExecuteScalar();
                if (result != null)
                {
                    role = result.ToString();
                }

                db.posdb_close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Security Check Error: " + ex.Message);
            }
            return role;
        }
        private void CenterPanel()
        {
            panelMain.Left = (this.ClientSize.Width - panelMain.Width) / 2;
            panelMain.Top = (this.ClientSize.Height - panelMain.Height) / 2;
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            try
            {
                emp_db.employee_connString();
                emp_db.employee_sql = "SELECT * FROM pos_empRegTb1 WHERE emp_id = '" + empIdTxtBox.Text + "'";

                emp_db.employee_cmd();
                emp_db.employee_sqladapterSelect();
                emp_db.employee_sqldatasetSELECT();

                if (emp_db.employee_sql_dataset.Tables[0].Rows.Count > 0)
                {
                    DataRow row = emp_db.employee_sql_dataset.Tables[0].Rows[0];

                    fnameTxtBox.Text = row["emp_fname"].ToString();
                    fnameTxtBox.ForeColor = Color.Black; // Reset color to black

                    mnameTxtBox.Text = row["emp_mname"].ToString();
                    mnameTxtBox.ForeColor = Color.Black;

                    surnameTxtBox.Text = row["emp_surname"].ToString();
                    surnameTxtBox.ForeColor = Color.Black;

                    designationTxtBox.Text = row["position"].ToString();

                    string imgPath = row["picpath"].ToString();

                    // Check if file exists to prevent crashing
                    if (System.IO.File.Exists(imgPath))
                    {
                        pictureBox1.Image = Image.FromFile(imgPath);
                    }
                    else
                    {
                        pictureBox1.Image = null; // Clear if no image found
                    }
                }
                else
                {
                    MessageBox.Show("Employee ID not found.");
                }

                // Close emp connection
                if (emp_db.employee_sql_connection.State == ConnectionState.Open)
                    emp_db.employee_sql_connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Search Error: " + ex.Message);
            }
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (passwordTxtBox.Text != confirmPassTxtBox.Text)
                {
                    MessageBox.Show("Passwords do not match!");
                    return;
                }

                OpenUserConnection();

                string sql = "INSERT INTO useraccountTb1 (" +
                    "user_id, emp_id, account_type, username, password, confirm_password, user_status, pos_terminal_no) " +
                    "VALUES ('" +
                    userIdTxtBox.Text + "', '" +
                    empIdTxtBox.Text + "', '" +
                    accountTypeComboBox.Text + "', '" +
                    usernameTxtBox.Text + "', '" +
                    passwordTxtBox.Text + "', '" +
                    confirmPassTxtBox.Text + "', '" +
                    statusComboBox.Text + "', '1')";

                user_db.useraccount_sql = sql;
                user_db.useraccount_cmd();
                user_db.useraccount_sqldataadapterInsert();

                CloseUserConnection();

                MessageBox.Show("User Account Created Successfully!");
                LoadGrid();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Creating Account: " + ex.Message);
                CloseUserConnection();
            }
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (passwordTxtBox.Text != confirmPassTxtBox.Text)
                {
                    MessageBox.Show("Passwords do not match!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                OpenUserConnection();

                string sql = "UPDATE useraccountTb1 SET " +
                             "username = '" + usernameTxtBox.Text + "', " +
                             "password = '" + passwordTxtBox.Text + "', " +
                             "confirm_password = '" + confirmPassTxtBox.Text + "', " +
                             "user_status = '" + statusComboBox.Text + "', " +
                             "account_type = '" + accountTypeComboBox.Text + "' " +
                             "WHERE user_id = '" + userIdTxtBox.Text + "'";

                user_db.useraccount_sql = sql;
                user_db.useraccount_cmd();
                user_db.useraccount_sqldataadapterUpdate();

                CloseUserConnection();

                MessageBox.Show("Account Updated Successfully!");
                LoadGrid();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update Error: " + ex.Message);
                CloseUserConnection();
            }
        }

        private void searchUpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                OpenUserConnection();

                // INNER JOIN to get Account Info + Employee Names
                string sql = "SELECT * FROM pos_empRegTb1 " +
                             "INNER JOIN useraccountTb1 ON pos_empRegTb1.emp_id = useraccountTb1.emp_id " +
                             "WHERE useraccountTb1.user_id = '" + userIdTxtBox.Text + "'";

                user_db.useraccount_sql = sql;
                user_db.useraccount_cmd();
                user_db.useraccount_sqldataadapterSelect();

                user_db.useraccount_sql_dataset = new DataSet();

                user_db.useraccount_sql_dataadapter.Fill(user_db.useraccount_sql_dataset);

                if (user_db.useraccount_sql_dataset.Tables[0].Rows.Count > 0)
                {
                    DataRow row = user_db.useraccount_sql_dataset.Tables[0].Rows[0];

                    empIdTxtBox.Text = row["emp_id"].ToString();

                    fnameTxtBox.Text = row["emp_fname"].ToString();
                    fnameTxtBox.ForeColor = Color.Black;

                    mnameTxtBox.Text = row["emp_mname"].ToString();
                    mnameTxtBox.ForeColor = Color.Black;

                    surnameTxtBox.Text = row["emp_surname"].ToString();
                    surnameTxtBox.ForeColor = Color.Black;

                    designationTxtBox.Text = row["position"].ToString();

                    usernameTxtBox.Text = row["username"].ToString();

                    // Show actual password
                    passwordTxtBox.Text = row["password"].ToString();
                    passwordTxtBox.ForeColor = Color.Black;
                    passwordTxtBox.UseSystemPasswordChar = true;

                    confirmPassTxtBox.Text = row["confirm_password"].ToString();
                    confirmPassTxtBox.ForeColor = Color.Black;
                    confirmPassTxtBox.UseSystemPasswordChar = true;

                    statusComboBox.Text = row["user_status"].ToString();
                    accountTypeComboBox.Text = row["account_type"].ToString();

                    string imgPath = row["picpath"].ToString();

                    if (System.IO.File.Exists(imgPath))
                    {

                        pictureBox1.Image = Image.FromFile(imgPath);
                    }
                    else
                    {
                        pictureBox1.Image = null; // Clear if no image found
                    }
                }
                else
                {
                    MessageBox.Show("User ID not found.");
                }
                CloseUserConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Search Error: " + ex.Message);
                CloseUserConnection();
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Delete this user account?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    OpenUserConnection();
                    string sql = "DELETE FROM useraccountTb1 WHERE user_id = '" + userIdTxtBox.Text + "'";

                    user_db.useraccount_sql = sql;
                    user_db.useraccount_cmd();
                    user_db.useraccount_sqldataadapterDelete();

                    CloseUserConnection();

                    MessageBox.Show("Account Deleted.");
                    LoadGrid();
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Delete Error: " + ex.Message);
                CloseUserConnection();
            }
        }

            private void LoadGrid()
        {
            OpenUserConnection();
            user_db.useraccount_sql = "SELECT * FROM useraccountTb1";
            user_db.useraccount_cmd();
            user_db.useraccount_sqldataadapterSelect();
            user_db.useraccount_sqldatasetSELECT_Account();

            if (user_db.useraccount_sql_dataset.Tables["useraccountTb1"].Rows.Count > 0)
            {
                dataGridView1.DataSource = user_db.useraccount_sql_dataset.Tables["useraccountTb1"];
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            CloseUserConnection();
        }

        private void ClearFields()
        {
            empIdTxtBox.Clear(); userIdTxtBox.Clear();
            fnameTxtBox.Text = "First Name"; fnameTxtBox.ForeColor = Color.Silver;
            mnameTxtBox.Text = "Middle Name"; mnameTxtBox.ForeColor = Color.Silver;
            surnameTxtBox.Text = "Surname"; surnameTxtBox.ForeColor = Color.Silver;
            designationTxtBox.Clear();

            usernameTxtBox.Clear();

            passwordTxtBox.UseSystemPasswordChar = false;
            passwordTxtBox.Text = "Password";
            passwordTxtBox.ForeColor = Color.Silver;

            confirmPassTxtBox.UseSystemPasswordChar = false;
            confirmPassTxtBox.Text = "Confirm Password";
            confirmPassTxtBox.ForeColor = Color.Silver;

            statusComboBox.SelectedIndex = -1;
            accountTypeComboBox.SelectedIndex = -1;
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void passwordTxtBox_Leave(object sender, EventArgs e)
        {
            if (passwordTxtBox.Text == "")
            {
                passwordTxtBox.UseSystemPasswordChar = false;
                passwordTxtBox.Text = "Password";
                passwordTxtBox.ForeColor = Color.Silver;
            }
        }

        private void passwordTxtBox_Enter(object sender, EventArgs e)
        {
            if (passwordTxtBox.Text == "Password")
            {
                passwordTxtBox.Text = "";
                passwordTxtBox.ForeColor = Color.Black;
                passwordTxtBox.UseSystemPasswordChar = true;
            }
        }

        private void confirmPassTxtBox_Leave(object sender, EventArgs e)
        {
            if (confirmPassTxtBox.Text == "")
            {
                confirmPassTxtBox.UseSystemPasswordChar = false;
                confirmPassTxtBox.Text = "Confirm Password";
                confirmPassTxtBox.ForeColor = Color.Silver;
            }
        }

        private void confirmPassTxtBox_Enter(object sender, EventArgs e)
        {
            if (confirmPassTxtBox.Text == "Confirm Password")
            {
                confirmPassTxtBox.Text = "";
                confirmPassTxtBox.ForeColor = Color.Black;
                confirmPassTxtBox.UseSystemPasswordChar = true;
            }
        }
    }

}
