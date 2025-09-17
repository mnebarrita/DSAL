using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LESSON5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        // ================================
        // GROSS INCOME BUTTON
        // ================================
        private void button1_Click(object sender, EventArgs e)
        {
            // --- BASIC INCOME ---
            double basicRate = 0, basicHours = 0, basicIncome = 0;
            if (rph_bi.Text != "" && numhrspercutoff_bi.Text != "")
            {
                basicRate = Convert.ToDouble(rph_bi.Text);
                basicHours = Convert.ToDouble(numhrspercutoff_bi.Text);
                basicIncome = basicRate * basicHours;
                incomepercutoff_bi.Text = basicIncome.ToString("F2");
            }

            // --- HONORARIUM INCOME ---
            double honorRate = 0, honorHours = 0, honorIncome = 0;
            if (rph_hi.Text != "" && numhrspercutoff_hi.Text != "")
            {
                honorRate = Convert.ToDouble(rph_hi.Text);
                honorHours = Convert.ToDouble(numhrspercutoff_hi.Text);
                honorIncome = honorRate * honorHours;
                incomepercutoff_hi.Text = honorIncome.ToString("F2");
            }

            // --- OTHER INCOME ---
            double otherRate = 0, otherHours = 0, otherIncome = 0;
            if (rph_oi.Text != "" && numhrspercutoff_oi.Text != "")
            {
                otherRate = Convert.ToDouble(rph_oi.Text);
                otherHours = Convert.ToDouble(numhrspercutoff_oi.Text);
                otherIncome = otherRate * otherHours;
                incomepercutoff_oi.Text = otherIncome.ToString("F2");
            }

            // --- GROSS INCOME ---
            double grossIncome = basicIncome + honorIncome + otherIncome;
            grossincome.Text = grossIncome.ToString("F2");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Clear all textboxes
            FN.Text = "";
            MN.Text = "";
            LN.Text = "";
            CS.Text = "";
            QDS.Text = "";
            dateTimePicker1.Text = "";
            EmpStat.Text = "";
            Desig.Text = "";
            EmpNum.Text = "";
            Dept.Text = "";

            rph_bi.Text = "";
            numhrspercutoff_bi.Text = "";
            incomepercutoff_bi.Text = "";

            SSSctrb.Text = "";
            phctrb.Text = "";
            pagibigctrb.Text = "";
            incometaxctrb.Text = "";

            rph_hi.Text = "";
            numhrspercutoff_hi.Text = "";
            incomepercutoff_hi.Text = "";

            rph_oi.Text = "";
            numhrspercutoff_oi.Text = "";
            incomepercutoff_oi.Text = "";

            sssloan.Text = "";
            pagibigloan.Text = "";
            FSD.Text = "";
            FSL.Text = "";
            salaryloan.Text = "";
            otherloans.Text = "";

            grossincome.Text = "";
            netincome.Text = "";
            totaldeductions.Text = "";
        }
        // ================================
        // NET INCOME BUTTON
        // ================================
        private void button2_Click(object sender, EventArgs e)
        {
            // --- REGULAR DEDUCTIONS ---
            double sss = 0, philhealth = 0, pagibig = 200, incomeTax = 0;

            if (SSSctrb.Text != "") sss = Convert.ToDouble(SSSctrb.Text);
            if (phctrb.Text != "") philhealth = Convert.ToDouble(phctrb.Text);
            if (incometaxctrb.Text != "") incomeTax = Convert.ToDouble(incometaxctrb.Text);

            // Pag-IBIG is always fixed at 200
            pagibigctrb.Text = pagibig.ToString("F2");

            // --- OTHER DEDUCTIONS ---
            double sssLoan = 0, pagibigLoanVal = 0, facSavingsDep = 0, facSavingsLoan = 0, salaryLoanVal = 0, otherLoansVal = 0;

            if (sssloan.Text != "") sssLoan = Convert.ToDouble(sssloan.Text);
            if (pagibigloan.Text != "") pagibigLoanVal = Convert.ToDouble(pagibigloan.Text);
            if (FSD.Text != "") facSavingsDep = Convert.ToDouble(FSD.Text);
            if (FSL.Text != "") facSavingsLoan = Convert.ToDouble(FSL.Text);
            if (salaryloan.Text != "") salaryLoanVal = Convert.ToDouble(salaryloan.Text);
            if (otherloans.Text != "") otherLoansVal = Convert.ToDouble(otherloans.Text);

            // --- TOTAL DEDUCTIONS ---
            double totalDeductions = sss + philhealth + pagibig + incomeTax +
                                     sssLoan + pagibigLoanVal + facSavingsDep +
                                     facSavingsLoan + salaryLoanVal + otherLoansVal;
            totaldeductions.Text = totalDeductions.ToString("F2");

            // --- NET INCOME ---
            double grossIncome = 0;
            if (grossincome.Text != "") grossIncome = Convert.ToDouble(grossincome.Text);

            double netIncome = grossIncome - totalDeductions;
            netincome.Text = netIncome.ToString("F2");
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Create new payslip window
            PayslipForm payslip = new PayslipForm();

            // Top Section
            payslip.lblCompany.Text = "Lyceum of the Philippines University Cavite";
            payslip.lblEmpCode.Text = EmpNum.Text;
            payslip.lblEmpName.Text = FN.Text + " " + MN.Text + " " + LN.Text;
            payslip.lblDept.Text = Dept.Text;
            payslip.lblCutoff.Text = dateTimePicker1.Text;
            payslip.lblPayPeriod.Text = dateTimePicker1.Text;

            // Earnings Section
            payslip.lblBasicPay.Text = incomepercutoff_bi.Text;
            payslip.lblOvertime.Text = incomepercutoff_oi.Text;
            payslip.lblHonorarium.Text = incomepercutoff_hi.Text;
            payslip.lblHonorariumAdj.Text = "0";
            payslip.lblSubstitution.Text = "0";
            payslip.lblTardy.Text = "0";

            // Deductions Section
            payslip.lblSSS.Text = SSSctrb.Text;
            payslip.lblPhilHealth.Text = phctrb.Text;
            payslip.lblWithholdingTax.Text = incometaxctrb.Text;
            payslip.lblHDMF.Text = "200";
            payslip.lblSSSWISP.Text = "750.00";

            // Totals Section (optional – depends on your form design)
            payslip.lblEarnings.Text = grossincome.Text;
            payslip.lblDeductions.Text = totaldeductions.Text;
            payslip.lblOvertime_bs.Text = netincome.Text;

            // Show the Payslip window
            payslip.Show();
        }
    }
}

/*
// --- SSS CONTRIBUTION (matches the table starting at <5250) ---
private decimal ComputeSSSContribution(decimal grossIncome)
{
    // start at <5250 as in your image (employee share = 250)
    if (grossIncome < 5250m) return 250.00m;
    else if (grossIncome <= 5749.99m) return 275.00m;
    else if (grossIncome <= 6249.99m) return 300.00m;
    else if (grossIncome <= 6749.99m) return 325.00m;
    else if (grossIncome <= 7249.99m) return 350.00m;
    else if (grossIncome <= 7749.99m) return 375.00m;
    else if (grossIncome <= 8249.99m) return 400.00m;
    else if (grossIncome <= 8749.99m) return 425.00m;
    else if (grossIncome <= 9249.99m) return 450.00m;
    else if (grossIncome <= 9749.99m) return 475.00m;
    else if (grossIncome <= 10249.99m) return 500.00m;
    else if (grossIncome <= 10749.99m) return 525.00m;
    else if (grossIncome <= 11249.99m) return 550.00m;
    else if (grossIncome <= 11749.99m) return 575.00m;
    else if (grossIncome <= 12249.99m) return 600.00m;
    else if (grossIncome <= 12749.99m) return 625.00m;
    else if (grossIncome <= 13249.99m) return 650.00m;
    else if (grossIncome <= 13749.99m) return 675.00m;
    else if (grossIncome <= 14249.99m) return 700.00m;
    else if (grossIncome <= 14749.99m) return 725.00m;
    else if (grossIncome <= 15249.99m) return 750.00m;
    else if (grossIncome <= 15749.99m) return 775.00m;
    else if (grossIncome <= 16249.99m) return 800.00m;
    else if (grossIncome <= 16749.99m) return 825.00m;
    else if (grossIncome <= 17249.99m) return 850.00m;
    else if (grossIncome <= 17749.99m) return 875.00m;
    else if (grossIncome <= 18249.99m) return 900.00m;
    else if (grossIncome <= 18749.99m) return 925.00m;
    else if (grossIncome <= 19249.99m) return 950.00m;
    else if (grossIncome <= 19749.99m) return 975.00m;
    else if (grossIncome <= 20249.99m) return 1000.00m;
    else if (grossIncome <= 20749.99m) return 1025.00m;
    else if (grossIncome <= 21249.99m) return 1050.00m;
    else if (grossIncome <= 21749.99m) return 1075.00m;
    else if (grossIncome <= 22249.99m) return 1100.00m;
    else if (grossIncome <= 22749.99m) return 1125.00m;
    else if (grossIncome <= 23249.99m) return 1150.00m;
    else if (grossIncome <= 23749.99m) return 1175.00m;
    else if (grossIncome <= 24249.99m) return 1200.00m;
    else if (grossIncome <= 24749.99m) return 1225.00m;
    else if (grossIncome <= 25249.99m) return 1250.00m;
    else if (grossIncome <= 25749.99m) return 1275.00m;
    else if (grossIncome <= 26249.99m) return 1300.00m;
    else if (grossIncome <= 26749.99m) return 1325.00m;
    else if (grossIncome <= 27249.99m) return 1350.00m;
    else if (grossIncome <= 27749.99m) return 1375.00m;
    else if (grossIncome <= 28249.99m) return 1400.00m;
    else if (grossIncome <= 28749.99m) return 1425.00m;
    else if (grossIncome <= 29249.99m) return 1450.00m;
    else if (grossIncome <= 29749.99m) return 1475.00m;
    else if (grossIncome <= 30249.99m) return 1500.00m;
    else if (grossIncome <= 30749.99m) return 1525.00m;
    else if (grossIncome <= 31249.99m) return 1550.00m;
    else if (grossIncome <= 31749.99m) return 1575.00m;
    else if (grossIncome <= 32249.99m) return 1600.00m;
    else if (grossIncome <= 32749.99m) return 1625.00m;
    else if (grossIncome <= 33249.99m) return 1650.00m;
    else if (grossIncome <= 33749.99m) return 1675.00m;
    else if (grossIncome <= 34249.99m) return 1700.00m;
    else if (grossIncome <= 34749.99m) return 1725.00m;
    else return 1725.00m; // max cap
}

    /*