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
    public partial class useraccount_report : Form
    {
        useraccount_db_connection user_db = new useraccount_db_connection();
        public useraccount_report()
        {
            InitializeComponent();
        }

        private void OpenConnection()
        {
            user_db.useraccount_connString();
            if (user_db.useraccount_sql_connection.State == ConnectionState.Closed)
            {
                user_db.useraccount_sql_connection.ConnectionString = user_db.useraccount_connectionString;
                user_db.useraccount_sql_connection.Open();
            }
        }

        private void CloseConnection()
        {
            if (user_db.useraccount_sql_connection.State == ConnectionState.Open)
                user_db.useraccount_sql_connection.Close();
        }

        private void LoadGrid(string whereClause = "")
        {
            try
            {
                OpenConnection();

                // SQL Query: Joins User Table with Employee Table to show names
                // It selects everything (*) from both, which is what the book example does
                string sql = "SELECT pos_empRegTb1.emp_id, emp_fname, emp_mname, emp_surname, " +
                             "user_id, username, password, user_status, account_type " +
                             "FROM pos_empRegTb1 " +
                             "INNER JOIN useraccountTb1 ON pos_empRegTb1.emp_id = useraccountTb1.emp_id ";

                if (whereClause != "")
                {
                    sql += whereClause;
                }

                user_db.useraccount_sql = sql;
                user_db.useraccount_cmd();
                user_db.useraccount_sqldataadapterSelect();

                // Clear old data to prevent errors
                user_db.useraccount_sql_dataset = new DataSet();
                user_db.useraccount_sql_dataadapter.Fill(user_db.useraccount_sql_dataset, "ReportTable");

                if (user_db.useraccount_sql_dataset.Tables["ReportTable"].Rows.Count > 0)
                {
                    dataGridView1.DataSource = user_db.useraccount_sql_dataset.Tables["ReportTable"];
                }
                else
                {
                    dataGridView1.DataSource = null; // Clear grid if no results
                }

                CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Loading Report: " + ex.Message);
                CloseConnection();
            }
        }

        private void useraccount_report_Load(object sender, EventArgs e)
        {
            //Center panel (UI logic) ---
            CenterPanel();
            this.Resize += (s, ev) => CenterPanel();

            LoadGrid();
        }

        private void CenterPanel()
        {
            panelMain.Left = (this.ClientSize.Width - panelMain.Width) / 2;
            panelMain.Top = (this.ClientSize.Height - panelMain.Height) / 2;
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            string search = optionInputTxtbox.Text;
            string condition = "";

            if (optionCombo.Text == "user_id")
            {
                condition = "WHERE useraccountTb1.user_id LIKE '%" + search + "%'";
            }
            else if (optionCombo.Text == "employee_number")
            {
                condition = "WHERE useraccountTb1.emp_id LIKE '%" + search + "%'";
            }
            else if (optionCombo.Text == "surname")
            {
                condition = "WHERE pos_empRegTb1.emp_surname LIKE '%" + search + "%'";
            }
            else if (optionCombo.Text == "firstname")
            {
                condition = "WHERE pos_empRegTb1.emp_fname LIKE '%" + search + "%'";
            }
            // Special Cases: Search by Status (ignores textbox input usually)
            else if (optionCombo.Text == "active")
            {
                condition = "WHERE useraccountTb1.user_status = 'Active'";
            }
            else if (optionCombo.Text == "deactivate") // Book uses "deactivate" for "Inactive"
            {
                condition = "WHERE useraccountTb1.user_status = 'Inactive'";
            }
            else
            {
                MessageBox.Show("Please select a valid search option.");
                return;
            }

            LoadGrid(condition);
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            optionInputTxtbox.Clear();
            optionCombo.SelectedIndex = -1;
            LoadGrid(); // Show all
        }
    }
}
