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
    public partial class payrol_report : Form
    {
        payrol_dbconnection payrol_db = new payrol_dbconnection();

        public payrol_report()
        {
            InitializeComponent();
        }

        private void payrol_report_Load(object sender, EventArgs e)
        {
            CenterPanel();
            this.Resize += (s, ev) => CenterPanel();
            LoadGrid();
        }

        private void CenterPanel()
        {
            panelMain.Left = (this.ClientSize.Width - panelMain.Width) / 2;
            panelMain.Top = (this.ClientSize.Height - panelMain.Height) / 2;
        }

        private void LoadGrid(string whereClause = "")
        {
            try
            {
                payrol_db.payrol_connString();

                string sql = "SELECT " +
                    "pos_empRegTb1.emp_id, " +
                    "pos_empRegTb1.emp_fname, " +
                    "pos_empRegTb1.emp_surname, " +
                    "payrolTb1.pay_date, " +
                    "payrolTb1.gross_income, " +
                    "payrolTb1.total_deductions, " +
                    "payrolTb1.net_income " + 
                    "FROM pos_empRegTb1 " +
                    "INNER JOIN payrolTb1 ON pos_empRegTb1.emp_id = payrolTb1.emp_id ";

                if (whereClause != "")
                {
                    sql += whereClause;
                }

                payrol_db.payrol_sql = sql;
                payrol_db.payrol_cmd();
                payrol_db.payrol_sqladapterSelect();
                payrol_db.payrol_sqldatasetSELECT();

                if (payrol_db.payrol_sql_dataset.Tables.Count > 0)
                {
                    dataGridView1.DataSource = payrol_db.payrol_sql_dataset.Tables[0];
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }

                if (payrol_db.payrol_sql_connection.State == ConnectionState.Open)
                    payrol_db.payrol_sql_connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Loading Report: " + ex.Message);
            }
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            string search = optionInputTxtbox.Text;
            string condition = "";

            if (optionCombo.Text == "employee_number")
            {
                condition = "WHERE payrolTb1.emp_id LIKE '%" + search + "%'";
            }
            else if (optionCombo.Text == "gross_income")
            {
                condition = "WHERE payrolTb1.gross_income LIKE '%" + search + "%'";
            }
            else if (optionCombo.Text == "net_income")
            {
                condition = "WHERE payrolTb1.net_income LIKE '%" + search + "%'";
            }
            else if (optionCombo.Text == "pay_date")
            {
                condition = "WHERE payrolTb1.pay_date LIKE '%" + search + "%'";
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
            LoadGrid(); // Reload all
        }
    }
}
