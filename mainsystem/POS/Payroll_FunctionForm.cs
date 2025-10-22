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

namespace mainsystem
{
    public partial class Payroll_FunctionForm : Form
    {
        // ---- Contribution Tables ----
        private readonly double[] philRanges = {
            10000, 11000, 12000, 13000, 14000, 15000, 16000, 17000, 18000, 19000, 20000,
            21000, 22000, 23000, 24000, 25000, 26000, 27000, 28000, 29000, 30000,
            31000, 32000, 33000, 34000, 35000, 36000, 37000, 38000, 39000
        };
        private readonly double[] philAmounts = {
            137.50, 151.25, 165.00, 178.75, 192.50, 206.25, 220.00, 233.75, 247.50, 261.25,
            275.25, 288.75, 302.50, 316.25, 330.00, 343.75, 357.50, 371.25, 385.00, 398.75,
            412.50, 426.25, 440.00, 453.75, 467.50, 481.25, 495.00, 508.75, 522.50, 536.25
        };

        private readonly double[] sssRanges = {
            1000, 1249.99, 1749.99, 2249.99, 2749.99, 3249.99, 3749.99, 4249.99,
            4749.99, 5249.99, 5749.99, 6249.99, 6749.99, 7249.99, 7749.99, 8249.99,
            8749.99, 9249.99, 9749.99, 10249.99, 10749.99, 11249.99, 11749.99, 12249.99,
            12749.99, 13249.99, 13749.99, 14249.99, 14749.99, 15249.99, 15749.99, 16249.99
        };
        private readonly double[] sssAmounts = {
            0.00, 36.30, 54.50, 72.70, 90.80, 109.00, 127.20, 145.30,
            163.50, 181.70, 199.80, 218.00, 236.20, 254.30, 272.50, 290.70,
            308.80, 327.00, 345.20, 363.30, 381.50, 399.70, 417.80, 436.00,
            454.20, 472.30, 490.50, 508.70, 526.80, 545.00, 563.20, 581.30
        };

        public Payroll_FunctionForm()
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
            CenterPanel();
            this.Resize += (s, ev) => CenterPanel(); // recenter when form resizes
            FN.Focus();

            // disable computed fields
            incomepercutoff_bi.Enabled = false;
            incomepercutoff_hi.Enabled = false;
            incomepercutoff_oi.Enabled = false;
            grossincome.Enabled = false;
            totaldeductions.Enabled = false;
            netincome.Enabled = false;
        }

        private void CenterPanel()
        {
            panelMain.Left = (this.ClientSize.Width - panelMain.Width) / 2;
            panelMain.Top = (this.ClientSize.Height - panelMain.Height) / 2;
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
                double.TryParse(rph_bi.Text, out basicRate);
                double.TryParse(numhrspercutoff_bi.Text, out basicHours);
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
        // ================================
        // HELPER FUNCTIONS (SSS, PHILHEALTH, TAX)
        // ================================

        // ------------------------
        // SSS Computation
        // ------------------------
        private double GetSSSContribution(double income)
        {
            for (int i = 0; i < sssRanges.Length; i++)
            {
                if (income <= sssRanges[i])
                    return sssAmounts[i];
            }
            return sssAmounts[sssAmounts.Length - 1];
        }

        // ------------------------
        // PhilHealth Computation
        // ------------------------
        private double GetPhilHealth(double income)
        {
            for (int i = 0; i < philRanges.Length; i++)
            {
                if (income <= philRanges[i])
                    return philAmounts[i];
            }
            return philAmounts[philAmounts.Length - 1];
        }

        // ------------------------
        // Withholding Tax (Simplified)
        // ------------------------
        private double GetWithholdingTax(double income)
        {
            if (income <= 20832)
                return 0;
            else if (income <= 33333)
                return (income - 20833) * 0.20;
            else if (income <= 66667)
                return 2500 + (income - 33333) * 0.25;
            else if (income <= 166667)
                return 10833 + (income - 66667) * 0.30;
            else if (income <= 666667)
                return 40833 + (income - 166667) * 0.32;
            else
                return 200833 + (income - 666667) * 0.35;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(ofd.FileName);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
    }
}