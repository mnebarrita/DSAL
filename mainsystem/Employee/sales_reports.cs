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
    public partial class sales_reports : Form
    {
        posdb_connect pos_db = new posdb_connect();
        public sales_reports()
        {
            InitializeComponent();
        }

        private void CenterPanel()
        {
            panelMain.Left = (this.ClientSize.Width - panelMain.Width) / 2;
            panelMain.Top = (this.ClientSize.Height - panelMain.Height) / 2;
        }
        private void LoadGrid(string sqlQuery)
        {
            try
            {
                pos_db.pos_connString(); 
                pos_db.posdb_open();   
                pos_db.pos_sql = sqlQuery;
                pos_db.pos_cmd();
                pos_db.pos_sqladapterSelect();
                pos_db.pos_sqldatasetSELECTSALES();


                if (pos_db.pos_sql_dataset.Tables.Count > 0)
                {
                    dataGridView1.DataSource = pos_db.pos_sql_dataset.Tables[0];
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }

                pos_db.posdb_close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Loading Sales: " + ex.Message);
            }
        }
        private void sales_reports_Load(object sender, EventArgs e)
        {
            CenterPanel();
            this.Resize += (s, ev) => CenterPanel();

            string customSql = "SELECT " +
                       "transaction_id AS [TRX ID], " +
                       "product_name AS [Product], " +
                       "product_price AS [Price], " +
                       "product_quantity_per_transaction AS [Qty], " +
                       "discount_option AS [Discount Type], " +
                       "discount_amount_per_transaction AS [Item Disc Amt], " +
                       "discounted_amount_per_transaction AS [Item Net Price], " +
                       "summary_total_quantity AS [Total Qty], " +
                       "summary_total_disc_given AS [Total Disc Given], " +
                       "summary_total_discounted_amount AS [Grand Total], " +
                       "terminal_no AS [Terminal], " +
                       "time_date AS [Date], " +
                       "emp_id AS [Employee ID] " +
                       "FROM salesTb1";

            LoadGrid(customSql);
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            string search = optionInputTxtbox.Text;
            string condition = "";

            if (optionCombo.Text == "transaction_id")
            {
                condition = "WHERE transaction_id LIKE '%" + search + "%'";
            }
            else if (optionCombo.Text == "terminal_number")
            {
                condition = "WHERE terminal_no LIKE '%" + search + "%'";
            }
            else if (optionCombo.Text == "date and time")
            {
                condition = "WHERE time_date LIKE '%" + search + "%'";
            }
            else if (optionCombo.Text == "product name")
            {
                condition = "WHERE product_name LIKE '%" + search + "%'";
            }
            else if (optionCombo.Text == "employee_number")
            {
                condition = "WHERE emp_id LIKE '%" + search + "%'";
            }
            else
            {
                MessageBox.Show("Please select a valid search option.");
                return;
            }

            // Run the search
            LoadGrid("SELECT * FROM salesTb1 " + condition);
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            optionInputTxtbox.Clear();
            optionCombo.SelectedIndex = -1;
            LoadGrid("SELECT * FROM salesTb1");
        }
    }
}
