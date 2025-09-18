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
        // ================================
        // SSS CONTRIBUTION (2025 Table)
        // ================================
        private double GetSSSContribution(double grossIncome)
        {
            if (grossIncome < 5250) return 250;
            else if (grossIncome <= 5749.99) return 275;
            else if (grossIncome <= 6249.99) return 300;
            else if (grossIncome <= 6749.99) return 325;
            else if (grossIncome <= 7249.99) return 350;
            else if (grossIncome <= 7749.99) return 375;
            else if (grossIncome <= 8249.99) return 400;
            else if (grossIncome <= 8749.99) return 425;
            else if (grossIncome <= 9249.99) return 450;
            else if (grossIncome <= 9749.99) return 475;
            else if (grossIncome <= 10249.99) return 500;
            else if (grossIncome <= 10749.99) return 525;
            else if (grossIncome <= 11249.99) return 550;
            else if (grossIncome <= 11749.99) return 575;
            else if (grossIncome <= 12249.99) return 600;
            else if (grossIncome <= 12749.99) return 625;
            else if (grossIncome <= 13249.99) return 650;
            else if (grossIncome <= 13749.99) return 675;
            else if (grossIncome <= 14249.99) return 700;
            else if (grossIncome <= 14749.99) return 725;
            else if (grossIncome <= 15249.99) return 750;
            else if (grossIncome <= 15749.99) return 775;
            else if (grossIncome <= 16249.99) return 800;
            else if (grossIncome <= 16749.99) return 825;
            else if (grossIncome <= 17249.99) return 850;
            else if (grossIncome <= 17749.99) return 875;
            else if (grossIncome <= 18249.99) return 900;
            else if (grossIncome <= 18749.99) return 925;
            else if (grossIncome <= 19249.99) return 950;
            else if (grossIncome <= 19749.99) return 975;
            else if (grossIncome <= 20249.99) return 1000;
            else if (grossIncome <= 20749.99) return 1025;
            else if (grossIncome <= 21249.99) return 1050;
            else if (grossIncome <= 21749.99) return 1075;
            else if (grossIncome <= 22249.99) return 1100;
            else if (grossIncome <= 22749.99) return 1125;
            else if (grossIncome <= 23249.99) return 1150;
            else if (grossIncome <= 23749.99) return 1175;
            else if (grossIncome <= 24249.99) return 1200;
            else if (grossIncome <= 24749.99) return 1225;
            else if (grossIncome <= 25249.99) return 1250;
            else if (grossIncome <= 25749.99) return 1275;
            else if (grossIncome <= 26249.99) return 1300;
            else if (grossIncome <= 26749.99) return 1325;
            else if (grossIncome <= 27249.99) return 1350;
            else if (grossIncome <= 27749.99) return 1375;
            else if (grossIncome <= 28249.99) return 1400;
            else if (grossIncome <= 28749.99) return 1425;
            else if (grossIncome <= 29249.99) return 1450;
            else if (grossIncome <= 29749.99) return 1475;
            else if (grossIncome <= 30249.99) return 1500;
            else if (grossIncome <= 30749.99) return 1525;
            else if (grossIncome <= 31249.99) return 1550;
            else if (grossIncome <= 31749.99) return 1575;
            else if (grossIncome <= 32249.99) return 1600;
            else if (grossIncome <= 32749.99) return 1625;
            else if (grossIncome <= 33249.99) return 1650;
            else if (grossIncome <= 33749.99) return 1675;
            else if (grossIncome <= 34249.99) return 1700;
            else return 1725; // for >= 34750


        }
        // ================================
        // PHILHEALTH CONTRIBUTION
        // ================================
        private double GetPhilHealth(double grossIncome)
        {
            double contrib = grossIncome * 0.05; // 5%
            if (contrib < 500) contrib = 500;
            if (contrib > 5000) contrib = 5000;
            return contrib;
        }

        // ================================
        // WITHHOLDING TAX (Semi-Monthly)
        // ================================
        private double GetWithholdingTax(double grossIncome)
        {
            // Simplified TRAIN law (semi-monthly version)
            if (grossIncome <= 10417) return 0;
            else if (grossIncome <= 16666) return (grossIncome - 10417) * 0.20;
            else if (grossIncome <= 33333) return 1250 + (grossIncome - 16666) * 0.25;
            else if (grossIncome <= 83333) return 5416.67 + (grossIncome - 33333) * 0.30;
            else if (grossIncome <= 333333) return 20416.67 + (grossIncome - 83333) * 0.32;
            else return 100416.67 + (grossIncome - 333333) * 0.35;
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

            // --- REGULAR DEDUCTIONS (auto-fill when pressing gross) ---
            double sss = GetSSSContribution(grossIncome);
            double philhealth = GetPhilHealth(grossIncome);
            double pagibig = 200; // semi-monthly fixed
            double incomeTax = GetWithholdingTax(grossIncome);

            // Display to textboxes
            SSSctrb.Text = sss.ToString("F2");
            phctrb.Text = philhealth.ToString("F2");
            pagibigctrb.Text = pagibig.ToString("F2");
            incometaxctrb.Text = incomeTax.ToString("F2");

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
            payslip.lblHDMF.Text = "200";   // Pag-IBIG
            payslip.lblSSSWISP.Text = "750.00";

            // Totals Section (middle part)
            payslip.lblEarnings.Text = grossincome.Text;         // total earnings
            payslip.lblDeductions.Text = totaldeductions.Text;   // total deductions
            payslip.lblOvertime_bs.Text = incomepercutoff_oi.Text; // overtime amount only

            // Bottom Section (summary)
            payslip.lblGrossEarnings.Text = grossincome.Text;
            payslip.lbltotaldeductions.Text = totaldeductions.Text;
            payslip.lblnetpay.Text = netincome.Text;

            // Show the Payslip window
            payslip.Show();
        }
    }
}