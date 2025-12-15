using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using mainsystem.L14_Classes;

namespace mainsystem
{
    public partial class AdminLoungeFrm : Form
    {
        public AdminLoungeFrm()
        {
            InitializeComponent();
        }

        
        private void AdminLoungeFrm_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.background1;
            string myID = Program.CurrentEmpID;
            if (string.IsNullOrEmpty(myID)) myID = "0000-Admin";

            lblWelcome.Text = "Welcome, Administrator Mica!";
            lblWelcome.Left = (panelMain.Width - lblWelcome.Width) / 2;
            lblWelcome.Top = 350;
            rtbSearch.Left = (panelMain.Width - rtbSearch.Width) / 2;
            rtbSearch.Top = 450;
            btnSearch.Left = 1390;
            btnSearch.Top = 455;
            pnlSearchContainer.Left = (panelMain.Width - rtbSearch.Width) / 2;
            pnlSearchContainer.Top = 450;
            panelMain.BackColor = Color.FromArgb(100, 0, 0, 0);
            timer1.Start();
            LoadLiveStats();
        }

        void LoadLiveStats()
        {
            try 
    {
        posdb_connect db = new posdb_connect();
        db.pos_connString();
        db.posdb_open();

        string today = DateTime.Now.ToString("yyyy-MM-dd");

                // --- 1. GET TOTAL SALES (The Money) ---
                string sqlSales = "SELECT SUM(CAST(summary_total_discounted_amount AS decimal(18,2))) FROM salesTb1 WHERE time_date = '" + today + "'";
                db.pos_sql = sqlSales;
        db.pos_cmd();
        object salesResult = db.pos_sql_command.ExecuteScalar();

        if (salesResult != DBNull.Value && salesResult != null)
        {
            double total = Convert.ToDouble(salesResult);
            lblTotalSales.Text = "₱ " + total.ToString("N2");
        }
        else
        {
            lblTotalSales.Text = "₱ 0.00";
        }

        // --- 2. GET TOTAL TRANSACTIONS (The Count) ---
        // We use COUNT(*) to count how many rows (sales) happened today
        string sqlCount = "SELECT COUNT(*) FROM salesTb1 WHERE time_date = '" + today + "'";
        db.pos_sql = sqlCount;
        db.pos_cmd();
        object countResult = db.pos_sql_command.ExecuteScalar();

        if (countResult != DBNull.Value && countResult != null)
        {
            lblTotalTransactions.Text = countResult.ToString();
        }
        else
        {
            lblTotalTransactions.Text = "0";
        }

        db.posdb_close();
    }
    catch (Exception ex)
    {
        // Helpful for debugging if something breaks
        MessageBox.Show("Stats Error: " + ex.Message);
    }
        }

        private void rtbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Stop the "Ding" and new line
                btnSearch.PerformClick();  // Click the button
            }
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = rtbSearch.Text.Trim();
            if (string.IsNullOrEmpty(keyword)) return;

            try
            {
                posdb_connect db = new posdb_connect();
                db.pos_connString();
                db.posdb_open();

                string sql = "";

                // 🧠 THE BRAIN: Check if it's a Number or Text
                int searchID;
                bool isNumber = int.TryParse(keyword, out searchID);

                if (isNumber)
                {
                    // CASE 1: It's a Number (e.g., "1005") -> Search SALES TRANSACTIONS
                    // We search for Transaction ID OR Employee ID in the sales logs
                    sql = "SELECT * FROM salesTb1 WHERE summary_total_discounted_amount > 0 AND " +
                          "(emp_id = '" + keyword + "' OR summary_total_quantity = '" + keyword + "')";

                    // Note: If you have a specific 'TRX_ID' column, use that instead! 
                    // Example: "SELECT * FROM salesTb1 WHERE transaction_id = " + searchID;
                }
                else
                {
                    // CASE 2: It's Text (e.g., "Jinx") -> Search EMPLOYEES
                    // We use LIKE '%...%' so "Jin" also finds "Jinx"
                    sql = "SELECT username, account_type, user_status FROM useraccountTb1 " +
                          "WHERE username LIKE '%" + keyword + "%' OR account_type LIKE '%" + keyword + "%'";
                }

                // Execute and Fill the Table
                db.pos_sql = sql;
                db.pos_cmd();
                db.pos_sqladapterSelect(); // Make sure your class has a way to fill a generic DataTable

                DataTable dt = new DataTable();
                db.pos_sql_dataadapter.Fill(dt);

                // Show results
                gridSearchResults.DataSource = dt;
                gridSearchResults.Visible = true; // Reveal the table!
                gridSearchResults.DataSource = dt;
                gridSearchResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                db.posdb_close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Search Error: " + ex.Message);
            }
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            lblClock.Text = DateTime.Now.ToString("hh:mm:ss tt");
            lblDate.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy");
        }

    }
}
