using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using mainsystem.L14_Classes;

namespace mainsystem.Prelim
{
    public partial class employee_payrol : Form
    {
        payrol_dbconnection payrol_db = new payrol_dbconnection();
        employee_dbconnection emp_db = new employee_dbconnection();
        public employee_payrol()
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
        private string GetCurrentRole()
        {
            string role = "";
            try
            {
                posdb_connect db = new posdb_connect();
                db.pos_connString();
                db.posdb_open();

                // Check CurrentEmpID against username column
                string sql = "SELECT account_type FROM useraccountTb1 WHERE username = '" + Program.CurrentEmpID + "'";

                db.pos_sql = sql;
                db.pos_cmd();
                object result = db.pos_sql_command.ExecuteScalar();
                if (result != null) role = result.ToString();

                db.posdb_close();
            }
            catch (Exception) { }
            return role;
        }

        private void ApplySecurityRestrictions()
        {
            string role = GetCurrentRole();

            // ACCOUNTING STAFF RESTRICTIONS
            if (role == "Accounting Staff")
            {
                // Disable Action Buttons
                if (editBtn != null) editBtn.Enabled = false;
                if (deleteBtn != null) deleteBtn.Enabled = false;

                firstnameTxtbox.ReadOnly = true;
                MNameTxtbox.ReadOnly = true;
                surnameTxtBox.ReadOnly = true;
                civilStatusTxtBox.ReadOnly = true;
                designationTxtBox.ReadOnly = true;
                departmentTxtBox.ReadOnly = true;
                emp_statusTxtBox.ReadOnly = true;

                basic_netincomeTxtbox.ReadOnly = true;
                hono_netincomeTxtbox.ReadOnly = true;
                other_netincomeTxtbox.ReadOnly = true;

                gross_incomeTxtbox.ReadOnly = true;
                total_deducTxtbox.ReadOnly = true;
                net_incomeTxtbox.ReadOnly = true;

                sss_contribTxtbox.ReadOnly = true;
                philhealth_contribTxtbox.ReadOnly = true;
                pagibig_contribTxtbox.ReadOnly = true;
                tax_contribTxtbox.ReadOnly = true;
                numDependentsTxtBox.ReadOnly = true;

                if (numDependentsTxtBox != null) numDependentsTxtBox.ReadOnly = true;
            }
        }
        private void employee_payrol_Load(object sender, EventArgs e)
        {
            CenterPanel();
            this.Resize += (s, ev) => CenterPanel();
            ApplySecurityRestrictions();
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
                emp_db.employee_sql = "SELECT * FROM pos_empRegTb1 WHERE emp_id = '" + empNumberTxtBox.Text + "'";

                emp_db.employee_cmd();
                emp_db.employee_sqladapterSelect();
                emp_db.employee_sqldatasetSELECT();

                if (emp_db.employee_sql_dataset.Tables[0].Rows.Count > 0)
                {
                    DataRow row = emp_db.employee_sql_dataset.Tables[0].Rows[0];

                    firstnameTxtbox.Text = row["emp_fname"].ToString();
                    MNameTxtbox.Text = row["emp_mname"].ToString();
                    surnameTxtBox.Text = row["emp_surname"].ToString();
                    civilStatusTxtBox.Text = row["emp_status"].ToString();
                    designationTxtBox.Text = row["position"].ToString();
                    departmentTxtBox.Text = row["emp_department"].ToString();
                    numDependentsTxtBox.Text = row["emp_no_of_dependents"].ToString();
                    emp_statusTxtBox.Text = row["emp_work_status"].ToString();

                    string imgPath = row["picpath"].ToString();

                    if (System.IO.File.Exists(imgPath))
                        pictureBox2.Image = Image.FromFile(imgPath);
                    else
                        pictureBox2.Image = null;
                }
                else
                {
                    MessageBox.Show("Employee ID not found.");
                }

                if (emp_db.employee_sql_connection.State == ConnectionState.Open)
                    emp_db.employee_sql_connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Search Error: " + ex.Message);
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                payrol_db.payrol_connString();
                string sql = "INSERT INTO payrolTb1 (" +
                    "basic_rate_hr, basic_no_of_hrs_cutOff, basic_income_per_cutOff, " +
                    "honorarium_rate_hr, honorarium_no_of_hrs_cutOff, honorarium_income_per_cutOff, " +
                    "other_rate_hr, other_no_of_hrs_cutOff, other_income_per_cutOff, " +
                    "sss_contrib, philhealth_contrib, pagibig_contrib, tax_contrib, " +
                    "sss_loan, pagibig_loan, fac_savings_deposit, fac_savings_loan, salary_loan, other_loans, " +
                    "total_deductions, gross_income, net_income, " +
                    "emp_id, pay_date) " +

                    "VALUES ('" +
                    basic_rateTxtbox.Text + "', '" + basic_numhrsTxtbox.Text + "', '" + basic_netincomeTxtbox.Text + "', '" +
                    hono_rateTxtbox.Text + "', '" + hono_numhrsTxtbox.Text + "', '" + hono_netincomeTxtbox.Text + "', '" +
                    other_rateTxtbox.Text + "', '" + other_numhrsTxtbox.Text + "', '" + other_netincomeTxtbox.Text + "', '" +
                    sss_contribTxtbox.Text + "', '" + philhealth_contribTxtbox.Text + "', '" + pagibig_contribTxtbox.Text + "', '" + tax_contribTxtbox.Text + "', '" +
                    sss_loanTxtbox.Text + "', '" + pagibig_loanTxtbox.Text + "', '" + FSD_depositTxtbox.Text + "', '" + FS_loanTxtbox.Text + "', '" + sal_loanTxtbox.Text + "', '" + others_loanTxtbox.Text + "', '" +
                    total_deducTxtbox.Text + "', '" + gross_incomeTxtbox.Text + "', '" + net_incomeTxtbox.Text + "', '" +
                    empNumberTxtBox.Text + "', '" + paydateDatePicker.Value.ToString("yyyy-MM-dd") + "')";

                payrol_db.payrol_sql = sql;
                payrol_db.payrol_cmd();
                payrol_db.payrol_sqladapterInsert();

                if (payrol_db.payrol_sql_connection.State == ConnectionState.Open)
                    payrol_db.payrol_sql_connection.Close();

                MessageBox.Show("Payroll Record Saved Successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Saving Record: " + ex.Message);
            }
        }

        private void newBtn_Click(object sender, EventArgs e)
        {
            // Clear Employee Info
            empNumberTxtBox.Clear();
            firstnameTxtbox.Clear();
            MNameTxtbox.Clear();
            surnameTxtBox.Clear();
            civilStatusTxtBox.Clear();
            designationTxtBox.Clear();
            departmentTxtBox.Clear();
            numDependentsTxtBox.Clear();
            emp_statusTxtBox.Clear();

            // Clear Calculations (Set to empty string or "0")
            basic_rateTxtbox.Clear(); basic_numhrsTxtbox.Clear(); basic_netincomeTxtbox.Clear();
            hono_rateTxtbox.Clear(); hono_numhrsTxtbox.Clear(); hono_netincomeTxtbox.Clear();
            other_rateTxtbox.Clear(); other_numhrsTxtbox.Clear(); other_netincomeTxtbox.Clear();

            // Clear Deductions
            sss_contribTxtbox.Clear(); philhealth_contribTxtbox.Clear(); pagibig_contribTxtbox.Clear(); tax_contribTxtbox.Clear();
            sss_loanTxtbox.Clear(); pagibig_loanTxtbox.Clear(); FSD_depositTxtbox.Clear();
            FS_loanTxtbox.Clear(); sal_loanTxtbox.Clear(); others_loanTxtbox.Clear();

            // Clear Totals
            gross_incomeTxtbox.Clear();
            total_deducTxtbox.Clear();
            net_incomeTxtbox.Clear();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to close the Payroll System?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Preview Payslip feature coming soon!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Preview Payslip feature coming soon!");
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            try
            {
                payrol_db.payrol_connString();

                string sql = "UPDATE payrolTb1 SET " +
                    // 1. Basic Pay
                    "basic_rate_hr = '" + basic_rateTxtbox.Text + "', " +
                    "basic_no_of_hrs_cutOff = '" + basic_numhrsTxtbox.Text + "', " +
                    "basic_income_per_cutOff = '" + basic_netincomeTxtbox.Text + "', " +

                    // 2. Honorarium
                    "honorarium_rate_hr = '" + hono_rateTxtbox.Text + "', " +
                    "honorarium_no_of_hrs_cutOff = '" + hono_numhrsTxtbox.Text + "', " +
                    "honorarium_income_per_cutOff = '" + hono_netincomeTxtbox.Text + "', " +

                    // 3. Other Income
                    "other_rate_hr = '" + other_rateTxtbox.Text + "', " +
                    "other_no_of_hrs_cutOff = '" + other_numhrsTxtbox.Text + "', " +
                    "other_income_per_cutOff = '" + other_netincomeTxtbox.Text + "', " +

                    // 4. Regular Deductions
                    "sss_contrib = '" + sss_contribTxtbox.Text + "', " +
                    "philhealth_contrib = '" + philhealth_contribTxtbox.Text + "', " +
                    "pagibig_contrib = '" + pagibig_contribTxtbox.Text + "', " +
                    "tax_contrib = '" + tax_contribTxtbox.Text + "', " +

                    // 5. Loans
                    "sss_loan = '" + sss_loanTxtbox.Text + "', " +
                    "pagibig_loan = '" + pagibig_loanTxtbox.Text + "', " +
                    "fac_savings_deposit = '" + FSD_depositTxtbox.Text + "', " +
                    "fac_savings_loan = '" + FS_loanTxtbox.Text + "', " +
                    "salary_loan = '" + sal_loanTxtbox.Text + "', " +
                    "other_loans = '" + others_loanTxtbox.Text + "', " +

                    // 6. Summaries
                    "total_deductions = '" + total_deducTxtbox.Text + "', " +
                    "gross_income = '" + gross_incomeTxtbox.Text + "', " +
                    "net_income = '" + net_incomeTxtbox.Text + "', " +

                    // 7. Date
                    "pay_date = '" + paydateDatePicker.Value.ToString("yyyy-MM-dd") + "' " +

                    "WHERE emp_id = '" + empNumberTxtBox.Text + "'";

                payrol_db.payrol_sql = sql;
                payrol_db.payrol_cmd();

                payrol_db.payrol_sqladapterInsert();

                if (payrol_db.payrol_sql_connection.State == ConnectionState.Open)
                    payrol_db.payrol_sql_connection.Close();

                MessageBox.Show("Payroll Record Updated Successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Updating: " + ex.Message);
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to delete this payroll record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    payrol_db.payrol_connString();

                    string sql = "DELETE FROM payrolTb1 WHERE emp_id = '" + empNumberTxtBox.Text + "'";

                    payrol_db.payrol_sql = sql;
                    payrol_db.payrol_cmd();
                    payrol_db.payrol_sqladapterInsert(); // Executes the command

                    if (payrol_db.payrol_sql_connection.State == ConnectionState.Open)
                        payrol_db.payrol_sql_connection.Close();

                    MessageBox.Show("Record Deleted Successfully.");

                    newBtn_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Deleting: " + ex.Message);
            }
        }

        private void calculateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Helper function to safely convert text to number
                double GetVal(string text)
                {
                    return string.IsNullOrWhiteSpace(text) ? 0 : Convert.ToDouble(text);
                }

                // --- 1. Basic Pay ---
                double basicRate = GetVal(basic_rateTxtbox.Text);
                double basicHrs = GetVal(basic_numhrsTxtbox.Text);
                double basicIncome = basicRate * basicHrs;
                basic_netincomeTxtbox.Text = basicIncome.ToString("0.00");

                // --- 2. Honorarium ---
                double honoRate = GetVal(hono_rateTxtbox.Text);
                double honoHrs = GetVal(hono_numhrsTxtbox.Text);
                double honoIncome = honoRate * honoHrs;
                hono_netincomeTxtbox.Text = honoIncome.ToString("0.00");

                // --- 3. Other Income ---
                double otherRate = GetVal(other_rateTxtbox.Text);
                double otherHrs = GetVal(other_numhrsTxtbox.Text);
                double otherIncome = otherRate * otherHrs;
                other_netincomeTxtbox.Text = otherIncome.ToString("0.00");

                // --- 4. Gross Income ---
                double gross = basicIncome + honoIncome + otherIncome;
                gross_incomeTxtbox.Text = gross.ToString("0.00");

                // --- 5. Total Deductions ---
                double ded1 = GetVal(sss_contribTxtbox.Text);
                double ded2 = GetVal(philhealth_contribTxtbox.Text);
                double ded3 = GetVal(pagibig_contribTxtbox.Text);
                double ded4 = GetVal(tax_contribTxtbox.Text);
                double ded5 = GetVal(sss_loanTxtbox.Text);
                double ded6 = GetVal(pagibig_loanTxtbox.Text);
                double ded7 = GetVal(FSD_depositTxtbox.Text);
                double ded8 = GetVal(FS_loanTxtbox.Text);
                double ded9 = GetVal(sal_loanTxtbox.Text);
                double ded10 = GetVal(others_loanTxtbox.Text);

                double totalDeductions = ded1 + ded2 + ded3 + ded4 + ded5 + ded6 + ded7 + ded8 + ded9 + ded10;
                total_deducTxtbox.Text = totalDeductions.ToString("0.00");

                // --- 6. Net Income ---
                double net = gross - totalDeductions;
                net_incomeTxtbox.Text = net.ToString("0.00");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Calculation Error: Please enter valid numbers.\n" + ex.Message);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string findID = empNumberTxtBox.Text.Trim();
            if (findID == "") return;

            try
            {
                posdb_connect db = new posdb_connect();
                db.pos_connString();
                db.posdb_open();

                string sql = "SELECT * FROM payrolTb1 WHERE emp_id = '" + findID + "'";

                db.pos_sql = sql;
                db.pos_cmd();

                SqlDataReader dr = db.pos_sql_command.ExecuteReader();

                if (dr.Read())
                {
                    // Basic Pay (Fixed Names)
                    basic_rateTxtbox.Text = dr["basic_rate_hr"].ToString();
                    basic_numhrsTxtbox.Text = dr["basic_no_of_hrs_cutOff"].ToString();
                    basic_netincomeTxtbox.Text = dr["basic_income_per_cutOff"].ToString();

                    // Honorarium (Fixed Names)
                    hono_rateTxtbox.Text = dr["honorarium_rate_hr"].ToString();
                    hono_numhrsTxtbox.Text = dr["honorarium_no_of_hrs_cutOff"].ToString();
                    hono_netincomeTxtbox.Text = dr["honorarium_income_per_cutOff"].ToString();

                    // Other Income (Fixed Names)
                    other_rateTxtbox.Text = dr["other_rate_hr"].ToString();
                    other_numhrsTxtbox.Text = dr["other_no_of_hrs_cutOff"].ToString();
                    other_netincomeTxtbox.Text = dr["other_income_per_cutOff"].ToString();

                    // Regular Deductions (Fixed Names)
                    sss_contribTxtbox.Text = dr["sss_contrib"].ToString();
                    philhealth_contribTxtbox.Text = dr["philhealth_contrib"].ToString();
                    pagibig_contribTxtbox.Text = dr["pagibig_contrib"].ToString();
                    tax_contribTxtbox.Text = dr["tax_contrib"].ToString();

                    // Loans (Fixed Names)
                    sss_loanTxtbox.Text = dr["sss_loan"].ToString();
                    pagibig_loanTxtbox.Text = dr["pagibig_loan"].ToString();
                    FSD_depositTxtbox.Text = dr["fac_savings_deposit"].ToString();
                    FS_loanTxtbox.Text = dr["fac_savings_loan"].ToString();
                    sal_loanTxtbox.Text = dr["salary_loan"].ToString();
                    others_loanTxtbox.Text = dr["other_loans"].ToString();

                    // Summaries
                    gross_incomeTxtbox.Text = dr["gross_income"].ToString();
                    total_deducTxtbox.Text = dr["total_deductions"].ToString();
                    net_incomeTxtbox.Text = dr["net_income"].ToString();

                    MessageBox.Show("Payroll Record Loaded.");
                }
                else
                {
                    MessageBox.Show("Employee Payroll Record not found.");
                }

                db.posdb_close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Search Error: " + ex.Message);
            }
        }
    }
}
