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
    public partial class L3Activity3 : Form
    {
        private double qty_total = 0;
        private double discount_totalgiven = 0;
        private double discounted_total = 0;
        private double discount_amt = 0;
        private double discounted_amt = 0;
        public L3Activity3()
        {
            InitializeComponent();
        }

        private void L3Activity3_Load(object sender, EventArgs e)
        {
            // codes for disabling textboxes
            itemnameTxtbox.Enabled = false;
            priceTxtbox.Enabled = false;
            discountedTxtbox.Enabled = false;
            qtyTotalTxtbox.Enabled = false;
            discountTotalTxtbox.Enabled = false;
            discountedTotalTxtbox.Enabled = false;
            changeTxtbox.Enabled = false;
            discountTxtbox.Enabled = false;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            itemnameTxtbox.Text = "Prelude to Chaos";
            priceTxtbox.Text = "8700";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            itemnameTxtbox.Text = "EX.O Bundle";
            priceTxtbox.Text = "9500";
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            itemnameTxtbox.Text = "Gaia Bundle";
            priceTxtbox.Text = "10500";
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            itemnameTxtbox.Text = "Glitchpop Bundle";
            priceTxtbox.Text = "8700";
        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            itemnameTxtbox.Text = "Ion Bundle";
            priceTxtbox.Text = "8700";
        }

        private void pictureBox6_Click_1(object sender, EventArgs e)
        {
            itemnameTxtbox.Text = "Protocol 781-A";
            priceTxtbox.Text = "9900";
        }

        private void pictureBox7_Click_1(object sender, EventArgs e)
        {
            itemnameTxtbox.Text = "Mystbloom Bundle";
            priceTxtbox.Text = "8700";
        }

        private void pictureBox8_Click_1(object sender, EventArgs e)
        {
            itemnameTxtbox.Text = "Prime Bundle";
            priceTxtbox.Text = "7100";
        }

        private void pictureBox9_Click_1(object sender, EventArgs e)
        {
            itemnameTxtbox.Text = "Radiant Entertainment System";
            priceTxtbox.Text = "11900";
        }

        private void pictureBox10_Click_1(object sender, EventArgs e)
        {
            itemnameTxtbox.Text = "Radiant Crisis Bundle";
            priceTxtbox.Text = "7100";
        }

        private void pictureBox11_Click_1(object sender, EventArgs e)
        {
            itemnameTxtbox.Text = "Sentinels of Light Bundle";
            priceTxtbox.Text = "8700";
        }

        private void pictureBox12_Click_1(object sender, EventArgs e)
        {
            itemnameTxtbox.Text = "SplashX";
            priceTxtbox.Text = "6700";
        }

        private void pictureBox13_Click_1(object sender, EventArgs e)
        {
            itemnameTxtbox.Text = "RGX 11z Pro";
            priceTxtbox.Text = "6700";
        }

        private void pictureBox14_Click_1(object sender, EventArgs e)
        {
            itemnameTxtbox.Text = "Doombringer";
            priceTxtbox.Text = "8700";
        }

        private void pictureBox15_Click_1(object sender, EventArgs e)
        {
            itemnameTxtbox.Text = "Kuronami Bundle";
            priceTxtbox.Text = "9500";
        }

        private void pictureBox16_Click_1(object sender, EventArgs e)
        {
            itemnameTxtbox.Text = "Zedd X Valorant SPECTRUM";
            priceTxtbox.Text = "10700";
        }

        private void pictureBox17_Click_1(object sender, EventArgs e)
        {
            itemnameTxtbox.Text = "Elderflame";
            priceTxtbox.Text = "9900";
        }

        private void pictureBox18_Click_1(object sender, EventArgs e)
        {
            itemnameTxtbox.Text = "Evori Dreamwings";
            priceTxtbox.Text = "9900";
        }

        private void pictureBox19_Click_1(object sender, EventArgs e)
        {
            itemnameTxtbox.Text = "Nocturnum";
            priceTxtbox.Text = "8700";
        }

        private void pictureBox20_Click_1(object sender, EventArgs e)
        {
            itemnameTxtbox.Text = "Primordium";
            priceTxtbox.Text = "8700";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            itemnameTxtbox.Clear();
            priceTxtbox.Clear();
            discountedTxtbox.Clear();
            qtyTotalTxtbox.Clear();
            discountTotalTxtbox.Clear();
            discountedTotalTxtbox.Clear();
            changeTxtbox.Clear();
            discountTxtbox.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int qty;
            double cash_rendered, change;

            // validate qty input
            if (!int.TryParse(qtyTxtbox.Text, out qty))
            {
                MessageBox.Show("Please enter a valid number for Quantity.");
                return;
            }

            // validate cash_rendered input
            if (!double.TryParse(cash_renderedtxtbox.Text, out cash_rendered))
            {
                MessageBox.Show("Please enter a valid number for Cash Rendered.");
                return;
            }

            // accumulate totals
            qty_total += qty;
            discount_totalgiven += discount_amt;
            discounted_total += discounted_amt;
            change = cash_rendered - discounted_amt;

            // display results in textboxes
            qtyTotalTxtbox.Text = qty_total.ToString();
            discountTotalTxtbox.Text = discount_totalgiven.ToString("n");
            discountedTotalTxtbox.Text = discounted_total.ToString("n");
            changeTxtbox.Text = change.ToString("n");
            cash_renderedtxtbox.Text = cash_rendered.ToString("n");
        }

        private void senrRdbtn_CheckedChanged(object sender, EventArgs e)
        {
            int qty;
            double price;

            if (!int.TryParse(qtyTxtbox.Text, out qty) || !double.TryParse(priceTxtbox.Text, out price))
            {
                MessageBox.Show("Enter valid Quantity and Price first.");
                return;
            }

            // Senior discount = 30%
            discount_amt = (qty * price) * 0.30;
            discounted_amt = (qty * price) - discount_amt;

            discountTxtbox.Text = discount_amt.ToString("n");
            discountedTxtbox.Text = discounted_amt.ToString("n");

            regularRdbtn.Checked = false;
            EmployeeRdbtn.Checked = false;
            noTaxRdbtn.Checked = false;
        }

        private void regularRdbtn_CheckedChanged(object sender, EventArgs e)
        {
            int qty;
            double price;

            if (!int.TryParse(qtyTxtbox.Text, out qty) || !double.TryParse(priceTxtbox.Text, out price))
            {
                MessageBox.Show("Enter valid Quantity and Price first.");
                return;
            }

            // Regular discount = 10%
            discount_amt = (qty * price) * 0.10;
            discounted_amt = (qty * price) - discount_amt;

            discountTxtbox.Text = discount_amt.ToString("n");
            discountedTxtbox.Text = discounted_amt.ToString("n");

            senrRdbtn.Checked = false;
            EmployeeRdbtn.Checked = false;
            noTaxRdbtn.Checked = false;
        }

        private void EmployeeRdbtn_CheckedChanged(object sender, EventArgs e)
        {
            int qty;
            double price;

            if (!int.TryParse(qtyTxtbox.Text, out qty) || !double.TryParse(priceTxtbox.Text, out price))
            {
                MessageBox.Show("Enter valid Quantity and Price first.");
                return;
            }

            // Employee discount = 15%
            discount_amt = (qty * price) * 0.15;
            discounted_amt = (qty * price) - discount_amt;

            discountTxtbox.Text = discount_amt.ToString("n");
            discountedTxtbox.Text = discounted_amt.ToString("n");

            regularRdbtn.Checked = false;
            senrRdbtn.Checked = false;
            noTaxRdbtn.Checked = false;
        }

        private void noTaxRdbtn_CheckedChanged(object sender, EventArgs e)
        {
            int qty;
            double price;

            if (!int.TryParse(qtyTxtbox.Text, out qty) || !double.TryParse(priceTxtbox.Text, out price))
            {
                MessageBox.Show("Enter valid Quantity and Price first.");
                return;
            }

            // No tax = no discount
            discount_amt = 0;
            discounted_amt = (qty * price);

            discountTxtbox.Text = discount_amt.ToString("n");
            discountedTxtbox.Text = discounted_amt.ToString("n");

            regularRdbtn.Checked = false;
            EmployeeRdbtn.Checked = false;
            senrRdbtn.Checked = false;
        }
    }
}
