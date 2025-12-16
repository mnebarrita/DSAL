using mainsystem.L14_Classes;
using mainsystem.Prelim;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mainsystem
{
    public partial class AdminLoungeFrm : Form
    {
        public AdminLoungeFrm()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
            panelMain.BackColor = Color.FromArgb(100, 0, 0, 0);
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
        private void AdminLoungeFrm_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.background1;
            string myID = Program.CurrentEmpID;
            if (string.IsNullOrEmpty(myID)) myID = "0000-Admin";

            lblWelcome.Text = "Welcome, Administrator Mica!";
            lblWelcome.Left = (panelMain.Width - lblWelcome.Width) / 2;
            lblWelcome.Top = 350;

            rtbSearch.Left = 520;
            rtbSearch.Top = 463;

            btnSearch.Left = 1425;
            btnSearch.Top = 455;

            pnlSearchContainer.Left = (panelMain.Width - rtbSearch.Width) / 2;
            pnlSearchContainer.Top = 450;
            
            timer1.Start();
            LoadLiveStats();

            rtbSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            rtbSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;

            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();

            // --- 1. MAIN APPLICATIONS ---
            collection.Add("Payroll Application");
            collection.Add("SQL POS Terminal 1");
            collection.Add("SQL POS Terminal 2");
            collection.Add("POS Admin Dashboard");
            collection.Add("Employee Registration");
            collection.Add("User Accounts");

            // --- 2. REPORTS ---
            collection.Add("Employee Reports");
            collection.Add("Payroll Reports");
            collection.Add("Sales Reports");
            collection.Add("User Account Reports");

            // --- 3. CLASS & FUNCTION FORMS (Dev Tools) ---
            collection.Add("Payroll Class Form");
            collection.Add("Payroll Function Form");
            collection.Add("POS 1 Class Form");
            collection.Add("POS 1 Function Form");
            collection.Add("POS 2 Class Form");
            collection.Add("POS 2 Function Form");

            // --- 4. ACTIVITIES & QUIZZES ---
            collection.Add("Activity 1");
            collection.Add("Activity 2");
            collection.Add("Activity 3");
            collection.Add("Cashier Activity (L2A2)");
            collection.Add("Activity 3 (L2A3)");
            collection.Add("Activity 5");
            collection.Add("Quiz 1");
            collection.Add("Payslip Sample Method");

            // Load the collection into your TextBox
            rtbSearch.AutoCompleteCustomSource = collection;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = rtbSearch.Text.Trim(); // Using 'rtbSearch' (Standard TextBox)
            if (string.IsNullOrEmpty(keyword)) return;

            Form formToOpen = null;

            // =========================================================
            // 🔀 THE UNIVERSAL SWITCH: Map Name -> Form
            // =========================================================
            switch (keyword)
            {
                // --- MAIN APPLICATIONS ---
                case "Payroll Application": formToOpen = new employee_payrol(); break;
                case "SQL POS Terminal 1": formToOpen = new SQLPOS1Class(); break;
                case "SQL POS Terminal 2": formToOpen = new SQLPOS2Class(); break;
                case "POS Admin Dashboard": formToOpen = new POS_Admin(); break;
                case "Employee Registration": formToOpen = new employee_registration(); break;
                case "User Accounts": formToOpen = new user_account(); break;

                // --- REPORTS ---
                case "Employee Reports": formToOpen = new employee_reports(); break;
                case "Payroll Reports": formToOpen = new payrol_report(); break;
                case "Sales Reports": formToOpen = new sales_reports(); break;
                case "User Account Reports": formToOpen = new useraccount_report(); break;

                // --- CLASS & FUNCTION FORMS ---
                case "Payroll Class Form": formToOpen = new Payroll_ClassForm(); break;
                case "Payroll Function Form": formToOpen = new Payroll_FunctionForm(); break;
                case "POS 1 Class Form": formToOpen = new POS1_ClassForm(); break;
                case "POS 1 Function Form": formToOpen = new POS1_FunctionForm(); break;
                case "POS 2 Class Form": formToOpen = new POS2_ClassForm(); break;
                case "POS 2 Function Form": formToOpen = new POS2_FunctionForm(); break;

                // --- ACTIVITIES & QUIZZES ---
                case "Activity 1": formToOpen = new Activity1(); break;
                case "Activity 2": formToOpen = new Activity2(); break;
                case "Activity 3": formToOpen = new Activity3(); break;
                case "Cashier Activity (L2A2)": formToOpen = new L2Activity2_Cashier(); break;
                case "Activity 3 (L2A3)": formToOpen = new L3Activity3(); break;
                case "Activity 5": formToOpen = new Activity5(); break;
                case "Quiz 1": formToOpen = new Quiz1(); break;
                case "Payslip Sample Method": formToOpen = new SampleLongMethod(); break;

                // --- SMART GUESSING (If they type partial words) ---
                default:
                    string lowerKey = keyword.ToLower();
                    if (lowerKey.Contains("sale")) formToOpen = new sales_reports();
                    else if (lowerKey.Contains("payrol app")) formToOpen = new employee_payrol();
                    else if (lowerKey.Contains("pos 1")) formToOpen = new SQLPOS1Class();
                    else if (lowerKey.Contains("pos 2")) formToOpen = new SQLPOS2Class();
                    else
                    {
                        MessageBox.Show("Module not found: " + keyword);
                        return;
                    }
                    break;
            }

            // --- OPEN THE FORM (MDI LOGIC) ---
            if (formToOpen != null)
            {
                // Check if we have a parent container (The Gray Background)
                if (this.MdiParent != null)
                {
                    formToOpen.MdiParent = this.MdiParent;
                    formToOpen.WindowState = FormWindowState.Maximized;
                    formToOpen.Show();
                }
                else
                {
                    // Fallback: Open as a normal window if not inside the main system
                    formToOpen.Show();
                }

                rtbSearch.Clear(); // Reset the search bar
            }
        }

        void LoadLiveStats()
        {
            try 
        {
            posdb_connect db = new posdb_connect();
            db.pos_connString();
            db.posdb_open();

            string today = DateTime.Now.ToString("yyyy-MM-dd");

                // ==========================================
                // 💰 SECTION 1: MONEY STATS
                // ==========================================

                // 1. DAILY SALES (Today)
                string sqlSalesToday = "SELECT SUM(CAST(REPLACE(REPLACE(summary_total_discounted_amount, ',', ''), '₱', '') AS decimal(18,2))) FROM salesTb1 WHERE time_date = '" + today + "'";
                db.pos_sql = sqlSalesToday;
                db.pos_cmd();
                object resultToday = db.pos_sql_command.ExecuteScalar();

                if (resultToday != DBNull.Value && resultToday != null)
                    lblTotalSales.Text = "₱ " + Convert.ToDouble(resultToday).ToString("N2");
                else
                    lblTotalSales.Text = "₱ 0.00";

                // 2. GRAND TOTAL SALES (Lifetime)
                string sqlGrandTotal = "SELECT SUM(CAST(REPLACE(REPLACE(summary_total_discounted_amount, ',', ''), '₱', '') AS decimal(18,2))) FROM salesTb1";
                db.pos_sql = sqlGrandTotal;
                db.pos_cmd();
                object resultGrand = db.pos_sql_command.ExecuteScalar();

                if (resultGrand != DBNull.Value && resultGrand != null)
                    lblGrandTotal.Text = "₱ " + Convert.ToDouble(resultGrand).ToString("N2");
                else
                    lblGrandTotal.Text = "₱ 0.00";

                // ==========================================
                // 🧾 SECTION 2: TRANSACTION COUNTS
                // ==========================================

                // 3. TRANSACTIONS TODAY
                string sqlCountToday = "SELECT COUNT(*) FROM salesTb1 WHERE time_date = '" + today + "'";
                db.pos_sql = sqlCountToday;
                db.pos_cmd();
                object countToday = db.pos_sql_command.ExecuteScalar();

                if (countToday != DBNull.Value && countToday != null)
                    lblTotalTransactions.Text = countToday.ToString();
                else
                    lblTotalTransactions.Text = "0";

                // 4. GRAND TOTAL TRANSACTIONS (Lifetime) -- NEW!
                string sqlCountLife = "SELECT COUNT(*) FROM salesTb1";
                db.pos_sql = sqlCountLife;
                db.pos_cmd();
                object countLife = db.pos_sql_command.ExecuteScalar();

                if (countLife != DBNull.Value && countLife != null)
                    lblGrandTotalTransactions.Text = countLife.ToString();
                else
                    lblGrandTotalTransactions.Text = "0";

                db.posdb_close();
            }
            catch (Exception ex)
            {
                // Silent fail or message box, up to you
                // MessageBox.Show("Stats Error: " + ex.Message);
            }
        }


        private void timer1_Tick_1(object sender, EventArgs e)
        {
            lblClock.Text = DateTime.Now.ToString("hh:mm:ss tt");
            lblDate.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy");
        }

        private void btnSearch_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void rtbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Stop the "Ding" sound
                btnSearch.PerformClick();  // Trigger the search
            }
        }
    }
}
