using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LESSON5
{
    public partial class PayslipForm : Form
    {
        private double grossEarnings;
        private double totalDeductions;
        private double netPay;
        private double earnings;
        private double deductions;
        private double overtime;

        // Constructor that accepts values
        public PayslipForm(double grossEarnings, double totalDeductions, double netPay,
                           double earnings, double deductions, double overtime)
        {
            InitializeComponent();

            // Store the values in the private fields
            this.grossEarnings = grossEarnings;
            this.totalDeductions = totalDeductions;
            this.netPay = netPay;
            this.earnings = earnings;
            this.deductions = deductions;
            this.overtime = overtime;

            // Update labels
            lblGrossEarnings.Text = grossEarnings.ToString("F2");
            lbltotaldeductions.Text = totalDeductions.ToString("F2");
            lblnetpay.Text = netPay.ToString("F2");

            lblEarnings.Text = earnings.ToString("F2");
            lblDeductions.Text = deductions.ToString("F2");
            lblOvertime_bs.Text = overtime.ToString("F2");
        }

        public PayslipForm()
        {
            InitializeComponent();
        }


        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox22_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox23_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox24_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
