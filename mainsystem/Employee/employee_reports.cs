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
    public partial class employee_reports : Form
    {
        // Use the Employee Connection (since we are querying pos_empRegTb1)
        employee_dbconnection emp_db = new employee_dbconnection();
        public employee_reports()
        {
            InitializeComponent();
        }

        private void LoadGrid(string sqlQuery)
        {
            CenterPanel();
            this.Resize += (s, ev) => CenterPanel();

            try
            {
                emp_db.employee_connString();
                emp_db.employee_sql = sqlQuery;
                emp_db.employee_cmd();
                emp_db.employee_sqladapterSelect();
                emp_db.employee_sqldatasetSELECT();

                if (emp_db.employee_sql_dataset.Tables.Count > 0)
                {
                    dataGridView1.DataSource = emp_db.employee_sql_dataset.Tables[0];
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }

                // Close connection
                if (emp_db.employee_sql_connection.State == ConnectionState.Open)
                    emp_db.employee_sql_connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Loading Data: " + ex.Message);
            }
        }

        private void CenterPanel()
        {
            panelMain.Left = (this.ClientSize.Width - panelMain.Width) / 2;
            panelMain.Top = (this.ClientSize.Height - panelMain.Height) / 2;
        }

        private void employee_reports_Load(object sender, EventArgs e)
        {
            LoadGrid("SELECT * FROM pos_empRegTb1");
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            string searchInput = optionInputTxtbox.Text;
            string sql = "";


            if (optionCombo.Text == "employee_number")
            {
                sql = "SELECT * FROM pos_empRegTb1 WHERE emp_id = '" + searchInput + "'";
            }
            else if (optionCombo.Text == "surname")
            {
                sql = "SELECT * FROM pos_empRegTb1 WHERE emp_surname = '" + searchInput + "'";
            }
            else if (optionCombo.Text == "firstname")
            {
                sql = "SELECT * FROM pos_empRegTb1 WHERE emp_fname = '" + searchInput + "'";
            }
            else if (optionCombo.Text == "department")
            {
                sql = "SELECT * FROM pos_empRegTb1 WHERE emp_department = '" + searchInput + "'";
            }
            else if (optionCombo.Text == "designation") // 'position' in your DB
            {
                sql = "SELECT * FROM pos_empRegTb1 WHERE position = '" + searchInput + "'";
            }
            else if (optionCombo.Text == "zipcode") // 'add_zipcode' in your DB
            {
                sql = "SELECT * FROM pos_empRegTb1 WHERE add_zipcode = '" + searchInput + "'";
            }
            else if (optionCombo.Text == "province") // 'add_state_province' in your DB
            {
                sql = "SELECT * FROM pos_empRegTb1 WHERE add_state_province = '" + searchInput + "'";
            }
            else if (optionCombo.Text == "city") // 'add_city' in your DB
            {
                sql = "SELECT * FROM pos_empRegTb1 WHERE add_city = '" + searchInput + "'";
            }
            else
            {
                MessageBox.Show("Please select a valid search option.");
                return;
            }

            // Run the query
            LoadGrid(sql);
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            optionInputTxtbox.Clear();
            optionCombo.SelectedIndex = -1; // Reset dropdown
            LoadGrid("SELECT * FROM pos_empRegTb1");
        }
    }
}
