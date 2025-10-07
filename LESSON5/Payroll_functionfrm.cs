using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LESSON1_1
{
    public partial class Payroll_functionfrm : Form
    {
        // ---- Contribution Tables  ----
        private readonly double[] philRanges = { 10000, 11000, 12000, 13000, 14000, 15000, 16000, 17000, 18000, 19000, 20000,
                                21000, 22000, 23000, 24000, 25000, 26000, 27000, 28000, 29000, 30000,
                                31000, 32000, 33000, 34000, 35000, 36000, 37000, 38000, 39000 };
        private readonly double[] philAmounts = { 137.50, 151.25, 165.00, 178.75, 192.50, 206.25, 220.00, 233.75, 247.50, 261.25,
                                 275.25, 288.75, 302.50, 316.25, 330.00, 343.75, 357.50, 371.25, 385.00, 398.75,
                                 412.50, 426.25, 440.00, 453.75, 467.50, 481.25, 495.00, 508.75, 522.50, 536.25 };

        private readonly double[] sssRanges = { 1000, 1249.99, 1749.99, 2249.99, 2749.99, 3249.99, 3749.99, 4249.99,
                               4749.99, 5249.99, 5749.99, 6249.99, 6749.99, 7249.99, 7749.99, 8249.99,
                               8749.99, 9249.99, 9749.99, 10249.99, 10749.99, 11249.99, 11749.99, 12249.99,
                               12749.99, 13249.99, 13749.99, 14249.99, 14749.99, 15249.99, 15749.99, 16249.99 };
        private readonly double[] sssAmounts = { 0.00, 36.30, 54.50, 72.70, 90.80, 109.00, 127.20, 145.30,
                                163.50, 181.70, 199.80, 218.00, 236.20, 254.30, 272.50, 290.70,
                                308.80, 327.00, 345.20, 363.30, 381.50, 399.70, 417.80, 436.00,
                                454.20, 472.30, 490.50, 508.70, 526.80, 545.00, 563.20, 581.30 };

        public Payroll_functionfrm()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            textBox9.Enabled = false;
            textBox13.Enabled = false;
            textBox14.Enabled = false;
            textBox15.Enabled = true;
            textBox16.Enabled = true;
            textBox12.Enabled = true;
            textBox19.Enabled = false;
            textBox21.Enabled = false;
            textBox22.Enabled = false;
            textBox20.Enabled = false;
            textBox23.Enabled = false;
            textBox24.Enabled = false;
            textBox25.Enabled = false;
            textBox32.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // ---------- Inputs ----------
            double rateBasic = double.TryParse(textBox3.Text, out rateBasic) ? rateBasic : 0;
            double hoursBasic = double.TryParse(textBox4.Text, out hoursBasic) ? hoursBasic : 0;
            double rateHonor = double.TryParse(textBox7.Text, out rateHonor) ? rateHonor : 0;
            double hoursHonor = double.TryParse(textBox8.Text, out hoursHonor) ? hoursHonor : 0;
            double rateOther = double.TryParse(textBox10.Text, out rateOther) ? rateOther : 0;
            double hoursOther = double.TryParse(textBox11.Text, out hoursOther) ? hoursOther : 0;

            // ---------- Monthly Incomes ----------
            double basicIncome = rateBasic * hoursBasic;
            double honorariumIncome = rateHonor * hoursHonor;
            double otherIncome = rateOther * hoursOther;
            double grossIncome = basicIncome + honorariumIncome + otherIncome;

            // ---------- Cutoff (semi-monthly) ----------
            double basicCutoff = basicIncome / 2;
            double honorariumCutoff = honorariumIncome / 2;
            double otherCutoff = otherIncome / 2;
            double grossCutoff = grossIncome / 2;

            // ---------- SSS Contribution ----------
            double sss_contrib = sssAmounts.Last();
            for (int i = 0; i < sssRanges.Length; i++)
            {
                if (grossIncome <= sssRanges[i])
                {
                    sss_contrib = sssAmounts[i];
                    break;
                }
            }

            // ---------- PhilHealth ----------
            double philhealth_contrib = philAmounts.Last();
            for (int i = 0; i < philRanges.Length; i++)
            {
                if (grossIncome <= philRanges[i])
                {
                    philhealth_contrib = philAmounts[i];
                    break;
                }
            }

            // ---------- Pagibig ----------
            double pagibig_contrib = 100;

            // ---------- Withholding Tax ----------
            double annualGross = grossIncome * 24;
            double tax_contrib = 0;
            if (grossIncome <= 10416.67) tax_contrib = 0;
            else if (grossIncome <= 16666.67) tax_contrib = ((annualGross - 250000) * 0.2) / 24;
            else if (grossIncome <= 33333.33) tax_contrib = (((annualGross - 400000) * 0.25 + 30000) / 24);
            else if (grossIncome <= 83333.33) tax_contrib = (((annualGross - 800000) * 0.30 + 130000) / 24);
            else if (grossIncome <= 333333.33) tax_contrib = (((annualGross - 2000000) * 0.32 + 490000) / 24);
            else tax_contrib = (((annualGross - 8000000) * 0.35 + 2410000) / 24);

            // ---------- Display ----------
            textBox5.Text = basicCutoff.ToString("N2");
            textBox6.Text = honorariumCutoff.ToString("N2");
            textBox9.Text = otherCutoff.ToString("N2");
            textBox14.Text = grossCutoff.ToString("N2");

            textBox24.Text = sss_contrib.ToString("N2");
            textBox23.Text = philhealth_contrib.ToString("N2");
            textBox20.Text = pagibig_contrib.ToString("N2");
            textBox25.Text = tax_contrib.ToString("N2");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double sss = double.TryParse(textBox24.Text, out sss) ? sss : 0;
            double philhealth = double.TryParse(textBox23.Text, out philhealth) ? philhealth : 0;
            double pagibig = double.TryParse(textBox20.Text, out pagibig) ? pagibig : 0;
            double tax = double.TryParse(textBox25.Text, out tax) ? tax : 0;

            double sssLoan = double.TryParse(textBox29.Text, out sssLoan) ? sssLoan : 0;
            double pagibigLoan = double.TryParse(textBox28.Text, out pagibigLoan) ? pagibigLoan : 0;
            double facultySavingDeposit = double.TryParse(textBox27.Text, out facultySavingDeposit) ? facultySavingDeposit : 0;
            double facultySavingsLoan = double.TryParse(textBox26.Text, out facultySavingsLoan) ? facultySavingsLoan : 0;
            double salaryLoan = double.TryParse(textBox31.Text, out salaryLoan) ? salaryLoan : 0;
            double otherLoans = double.TryParse(textBox30.Text, out otherLoans) ? otherLoans : 0;

            double totalDeductions = sss + philhealth + pagibig + tax +
                                     sssLoan + pagibigLoan + facultySavingDeposit +
                                     facultySavingsLoan + salaryLoan + otherLoans;

            double grossCutoff = double.TryParse(textBox14.Text, out grossCutoff) ? grossCutoff : 0;
            double netIncome = grossCutoff - totalDeductions;
            if (netIncome < 0) netIncome = 0;

            textBox32.Text = totalDeductions.ToString("N2");
            textBox13.Text = netIncome.ToString("N2");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
                if (c is TextBox tb)
                    tb.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form6_Payslip_ payslip = new Form6_Payslip_(
                "Lyceum of the Philippines University Cavite",
                textBox2.Text,
                textBox1.Text,
                textBox16.Text + " " + textBox15.Text + " " + textBox12.Text,
                dateTimePicker1.Value.ToString("MMM dd"),
                dateTimePicker1.Value.ToString("MMM dd") + " to " + dateTimePicker1.Value.AddDays(15).ToString("MMM dd, yyyy"),
                textBox5.Text,
                textBox6.Text,
                textBox9.Text,
                textBox14.Text,
                textBox24.Text,
                textBox23.Text,
                textBox20.Text,
                textBox25.Text,
                textBox32.Text,
                textBox13.Text,
                textBox5.Text,
                textBox6.Text
            );

            payslip.Show();
        }
    }
}
