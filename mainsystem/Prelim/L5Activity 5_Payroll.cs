using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mainsystem
{
    public partial class Activity5 : Form
    {
        private readonly double[] sssRanges = {
    0, 5250, 5750, 6250, 6750, 7250, 7750, 8250, 8750, 9250,
    9750, 10250, 10750, 11250, 11750, 12250, 12750, 13250, 13750, 14250,
    14750, 15250, 15750, 16250, 16750, 17250, 17750, 18250, 18750, 19250,
    19750, 20250, 20750, 21250, 21750, 22250, 22750, 23250, 23750, 24250,
    24750, 25250, 25750, 26250, 26750, 27250, 27750, 28250, 28750, 29250,
    29750, 30250, 30750, 31250, 31750, 32250, 32750, 33250, 33750, 34250, 34750
};

        private readonly double[] sssAmounts = {
    250, 275, 300, 325, 350, 375, 400, 425, 450, 475,
    500, 525, 550, 575, 600, 625, 650, 675, 700, 725,
    750, 775, 800, 825, 850, 875, 900, 925, 950, 975,
    1000, 1025, 1050, 1075, 1100, 1125, 1150, 1175, 1200, 1225,
    1250, 1275, 1300, 1325, 1350, 1375, 1400, 1425, 1450, 1475,
    1500, 1525, 1550, 1575, 1600, 1625, 1650, 1675, 1700, 1725, 1750
};


        public Activity5()
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
            // disable computed fields
            incomepercutoff_bi.Enabled = false;
            incomepercutoff_hi.Enabled = false;
            incomepercutoff_oi.Enabled = false;
            grossincome.Enabled = false;
            totaldeductions.Enabled = false;
            netincome.Enabled = false;
        }
        // ================================
        // GROSS INCOME BUTTON
        // ================================
        private void button1_Click(object sender, EventArgs e)
        {
            // --- Inputs ---
            double rateBasic = double.TryParse(rph_bi.Text, out rateBasic) ? rateBasic : 0;
            double hrsBasic = double.TryParse(numhrspercutoff_bi.Text, out hrsBasic) ? hrsBasic : 0;
            double rateHonor = double.TryParse(rph_hi.Text, out rateHonor) ? rateHonor : 0;
            double hrsHonor = double.TryParse(numhrspercutoff_hi.Text, out hrsHonor) ? hrsHonor : 0;
            double rateOther = double.TryParse(rph_oi.Text, out rateOther) ? rateOther : 0;
            double hrsOther = double.TryParse(numhrspercutoff_oi.Text, out hrsOther) ? hrsOther : 0;

            // --- Monthly Income ---
            double basicIncome = rateBasic * hrsBasic;
            double honorIncome = rateHonor * hrsHonor;
            double otherIncome = rateOther * hrsOther;
            double grossIncome = basicIncome + honorIncome + otherIncome;

            // --- Display Income per Cutoff ---
            incomepercutoff_bi.Text = (basicIncome / 2).ToString("N2");
            incomepercutoff_hi.Text = (honorIncome / 2).ToString("N2");
            incomepercutoff_oi.Text = (otherIncome / 2).ToString("N2");
            grossincome.Text = (grossIncome / 2).ToString("N2"); // half-month gross

            // ---- SSS ----
            double sss = sssAmounts[0]; // default
            for (int i = 0; i < sssRanges.Length; i++)
            {
                if (grossIncome >= sssRanges[i])
                {
                    sss = sssAmounts[i];
                }
                else
                {
                    break; // found the correct range
                }
            }


            // ---- PhilHealth ----
            double philhealth = grossIncome * 0.05; // 5% of gross
            if (philhealth < 500) philhealth = 500;
            if (philhealth > 5000) philhealth = 5000;

            // ---- Pag-IBIG ----
            double pagibig = 100; // fixed monthly

            // ---- Withholding Tax ----
            double annualGross = grossIncome * 24;
            double tax = 0;
            if (grossIncome <= 10416.67) tax = 0;
            else if (grossIncome <= 16666.67) tax = ((annualGross - 250000) * 0.2) / 24;
            else if (grossIncome <= 33333.33) tax = (((annualGross - 400000) * 0.25 + 30000) / 24);
            else if (grossIncome <= 83333.33) tax = (((annualGross - 800000) * 0.30 + 130000) / 24);
            else if (grossIncome <= 333333.33) tax = (((annualGross - 2000000) * 0.32 + 490000) / 24);
            else tax = (((annualGross - 8000000) * 0.35 + 2410000) / 24);

            // --- Display Regular Deductions per Cutoff ---
            SSSctrb.Text = (sss / 2).ToString("N2");       // half-month
            phctrb.Text = (philhealth / 2).ToString("N2"); // half-month
            pagibigctrb.Text = (pagibig / 2).ToString("N2"); // half-month
            incometaxctrb.Text = (tax / 2).ToString("N2"); // half-month
        }

        private void button5_Click(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
            {
                if (c is TextBox tb) tb.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double sss = double.TryParse(SSSctrb.Text, out sss) ? sss : 0;
            double phil = double.TryParse(phctrb.Text, out phil) ? phil : 0;
            double pagibig = double.TryParse(pagibigctrb.Text, out pagibig) ? pagibig : 0;
            double tax = double.TryParse(incometaxctrb.Text, out tax) ? tax : 0;

            double sssLoan = double.TryParse(sssloan.Text, out sssLoan) ? sssLoan : 0;
            double pagibigLoan = double.TryParse(pagibigloan.Text, out pagibigLoan) ? pagibigLoan : 0;
            double fsd = double.TryParse(FSD.Text, out fsd) ? fsd : 0;
            double fsl = double.TryParse(FSL.Text, out fsl) ? fsl : 0;
            double salaryLoan = double.TryParse(salaryloan.Text, out salaryLoan) ? salaryLoan : 0;
            double others = double.TryParse(otherloans.Text, out others) ? others : 0;

            double totalDeduct = sss + phil + pagibig + tax + sssLoan + pagibigLoan + fsd + fsl + salaryLoan + others;
            totaldeductions.Text = totalDeduct.ToString("N2");

            double gross = double.TryParse(grossincome.Text, out gross) ? gross : 0;
            double net = gross - totalDeduct;
            if (net < 0) net = 0;

            netincome.Text = net.ToString("N2");
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            PayslipForm payslip = new PayslipForm();

            payslip.lblCompany.Text = "Lyceum of the Philippines University Cavite";
            payslip.lblEmpCode.Text = EmpNum.Text;
            payslip.lblEmpName.Text = FN.Text + " " + MN.Text + " " + LN.Text;
            payslip.lblDept.Text = Dept.Text;
            payslip.lblCutoff.Text = dateTimePicker1.Value.ToString("MMM dd");
            payslip.lblPayPeriod.Text = dateTimePicker1.Value.ToString("MMM dd") + " to " + dateTimePicker1.Value.AddDays(15).ToString("MMM dd, yyyy");

            payslip.lblBasicPay.Text = incomepercutoff_bi.Text;
            payslip.lblOvertime.Text = incomepercutoff_oi.Text;
            payslip.lblHonorarium.Text = incomepercutoff_hi.Text;

            payslip.lblSSS.Text = SSSctrb.Text;
            payslip.lblPhilHealth.Text = phctrb.Text;
            payslip.lblWithholdingTax.Text = incometaxctrb.Text;
            payslip.lblHDMF.Text = pagibigctrb.Text;

            payslip.lblEarnings.Text = grossincome.Text;
            payslip.lblDeductions.Text = totaldeductions.Text;
            payslip.lblnetpay.Text = netincome.Text;

            payslip.Show();
        }
    }
}