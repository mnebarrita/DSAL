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