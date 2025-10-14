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

    public partial class POS1_ClassForm : Form
    {
        private bool isLoading = true;
        // Running totals
        private double qty_total = 0;
        private double discount_totalgiven = 0;
        private double discounted_total = 0;

        // Current item values
        private double discount_amt = 0;
        private double discounted_amt = 0;
        private double discountRate = 0;
        public POS1_ClassForm()
        {
            InitializeComponent();
        }
        private void POS1_FunctionForm_Load(object sender, EventArgs e)
        {
            CenterPanel();
            this.Resize += (s, ev) => CenterPanel();
            isLoading = true;

        // codes for disabling textboxes
            itemnameTxtbox.ReadOnly = true;
            priceTxtbox.ReadOnly = true;
            discountedTxtbox.ReadOnly = true;
            qtyTotalTxtbox.ReadOnly = true;
            discountTotalTxtbox.ReadOnly = true;
            discountedTotalTxtbox.ReadOnly = true;
            changeTxtbox.ReadOnly = true;
            discountTxtbox.ReadOnly = true;

            // Default radio button (no discount)
            noTaxRdbtn.Checked = true;

            this.AcceptButton = button1;

            isLoading = false;

            this.BackgroundImage = Properties.Resources.POS1wallpaper;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            qtyTxtbox.Focus();


        }

        private void CenterPanel()
        {
            panelMain.Left = (this.ClientSize.Width - panelMain.Width) / 2;
            panelMain.Top = (this.ClientSize.Height - panelMain.Height) / 2;
        }

        private void ComputeDiscounts()
        {
            if (!int.TryParse(qtyTxtbox.Text, out int qty) || qty <= 0)
            {
                MessageBox.Show("Please enter a valid quantity.");
                return;
            }

            if (!double.TryParse(priceTxtbox.Text, out double price) || price <= 0)
            {
                MessageBox.Show("Please select an item first.");
                return;
            }

            double subtotal = qty * price;
            discount_amt = subtotal * discountRate;
            discounted_amt = subtotal - discount_amt;

            discountTxtbox.Text = discount_amt.ToString("n");
            discountedTxtbox.Text = discounted_amt.ToString("n");
        }

        private void SelectItem(string itemName, double price)
        {
            itemnameTxtbox.Text = itemName;
            priceTxtbox.Text = price.ToString("N0");
            qtyTxtbox.Text = "1";
            noTaxRdbtn.Checked = true;
            discountRate = 0.00;
            ComputeDiscounts();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            SelectItem("Prelude to Chaos", 8700);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SelectItem("EX.O Bundle", 9500);
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            SelectItem("Gaia Bundle", 10500);
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            SelectItem("Glitchpop Bundle", 8700);
        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            SelectItem("Ion Bundle", 8700);
        }

        private void pictureBox6_Click_1(object sender, EventArgs e)
        {
            SelectItem("Protocol 781-A", 9900);
        }

        private void pictureBox7_Click_1(object sender, EventArgs e)
        {
            SelectItem("Mystbloom Bundle", 8700);
        }

        private void pictureBox8_Click_1(object sender, EventArgs e)
        {
            SelectItem("Prime Bundle", 7100); 
        }

        private void pictureBox9_Click_1(object sender, EventArgs e)
        {
            SelectItem("Radiant Entertainment System", 11900);
        }

        private void pictureBox10_Click_1(object sender, EventArgs e)
        {
            SelectItem("Radiant Crisis Bundle", 7100); 
        }

        private void pictureBox11_Click_1(object sender, EventArgs e)
        {
            SelectItem("Sentinels of Light Bundle", 8700);
        }

        private void pictureBox12_Click_1(object sender, EventArgs e)
        {
            SelectItem("SplashX", 6700);
        }

        private void pictureBox13_Click_1(object sender, EventArgs e)
        {
            SelectItem("RGX 11z Pro", 6700); 
            
        }

        private void pictureBox14_Click_1(object sender, EventArgs e)
        {
            SelectItem("Doombringer", 8700);
        }

        private void pictureBox15_Click_1(object sender, EventArgs e)
        {
            SelectItem("Prelude to Chaos", 8700); 
        }

        private void pictureBox16_Click_1(object sender, EventArgs e)
        {
            SelectItem("Zedd X Valorant SPECTRUM", 10700); 
        }

        private void pictureBox17_Click_1(object sender, EventArgs e)
        {
            SelectItem("Elderflame", 9900);
        }

        private void pictureBox18_Click_1(object sender, EventArgs e)
        {
            SelectItem("Evori Dreamwings", 9900);
        }

        private void pictureBox19_Click_1(object sender, EventArgs e)
        {
            SelectItem("Nocturnum", 8700);
        }

        private void pictureBox20_Click_1(object sender, EventArgs e)
        {
            SelectItem("Primordium", 8700);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            itemnameTxtbox.Text = "";
            qtyTxtbox.Text = "";
            priceTxtbox.Text = "";
            discountTxtbox.Text = "";
            discountedTxtbox.Text = "";
            cash_renderedtxtbox.Text = "";
            changeTxtbox.Text = "";


            // Uncheck all discounts
            senrRdbtn.Checked = false;
            regularRdbtn.Checked = false;
            EmployeeRdbtn.Checked = false;
            noTaxRdbtn.Checked = false;

            // Keep summary
            qtyTxtbox.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            itemnameTxtbox.Text = "";
            qtyTxtbox.Text = "";
            priceTxtbox.Text = "";
            discountTxtbox.Text = "";
            discountedTxtbox.Text = "";
            cash_renderedtxtbox.Text = "";
            changeTxtbox.Text = "";


            // Uncheck all discounts
            senrRdbtn.Checked = false;
            regularRdbtn.Checked = false;
            EmployeeRdbtn.Checked = false;
            noTaxRdbtn.Checked = false;

            // Keep summary
            qtyTxtbox.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Remove commas before parsing
                double price = double.Parse(priceTxtbox.Text.Replace(",", ""));
                int qty = int.Parse(qtyTxtbox.Text.Replace(",", ""));
                double discountRate = 0;

                // Determine which discount applies
                if (senrRdbtn.Checked)
                    discountRate = 0.30;   // 30%
                else if (regularRdbtn.Checked)
                    discountRate = 0.10;   // 10%
                else if (EmployeeRdbtn.Checked)
                    discountRate = 0.15;   // 15%
                else if (noTaxRdbtn.Checked)
                    discountRate = 0.00;   // No discount

                // Calculate
                double amount = price * qty;
                double discount = amount * discountRate;
                double discountedAmount = amount - discount;

                // Display results
                discountTxtbox.Text = discount.ToString("N2");
                discountedTxtbox.Text = discountedAmount.ToString("N2");

                // Update summary totals safely (remove commas)
                double totalQty = double.Parse(string.IsNullOrWhiteSpace(qtyTotalTxtbox.Text) ? "0" : qtyTotalTxtbox.Text.Replace(",", ""));
                double totalDiscount = double.Parse(string.IsNullOrWhiteSpace(discountTotalTxtbox.Text) ? "0" : discountTotalTxtbox.Text.Replace(",", ""));
                double totalDiscounted = double.Parse(string.IsNullOrWhiteSpace(discountedTotalTxtbox.Text) ? "0" : discountedTotalTxtbox.Text.Replace(",", ""));

                qtyTotalTxtbox.Text = (totalQty + qty).ToString();
                discountTotalTxtbox.Text = (totalDiscount + discount).ToString("N2");
                discountedTotalTxtbox.Text = (totalDiscounted + discountedAmount).ToString("N2");
            }
            catch
            {
                MessageBox.Show("Please check your input values.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void senrRdbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (isLoading) return; // 🚫 Skip during form load

            if (senrRdbtn.Checked)
            {
                discountRate = 0.30; // Senior = 30%
                ComputeDiscounts();
            }
        }

        private void regularRdbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (isLoading) return; // 🚫 Skip during form load

            if (regularRdbtn.Checked)
            {
                discountRate = 0.10; // Regular = 10%
                ComputeDiscounts();
            }
        }

        private void EmployeeRdbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (isLoading) return; // 🚫 Skip during form load

            if (EmployeeRdbtn.Checked)
            {
                discountRate = 0.15; // Employee = 15%
                ComputeDiscounts();
            }
        }

        private void noTaxRdbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (isLoading) return;

            if (noTaxRdbtn.Checked)
            {
                discountRate = 0.00; // None
                ComputeDiscounts();
            }
        }

        private void changeTxtbox_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(changeTxtbox.Text.Replace(",", ""), out double val))
                changeTxtbox.Text = val.ToString("N2");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string cashText = cash_renderedtxtbox.Text.Replace(",", "");
                string totalText = discountedTxtbox.Text.Replace(",", "");


                if (!double.TryParse(cashText, out double cash) || !double.TryParse(totalText, out double total))
                {
                    MessageBox.Show("Please enter a valid cash amount.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                double change = cash - total;

                if (change < 0)
                {
                    MessageBox.Show("Insufficient cash!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    changeTxtbox.Text = "0.00";
                }
                else
                {
                    changeTxtbox.Text = change.ToString("N2");
                }
            }
            catch
            {
                MessageBox.Show("Please enter a valid cash amount.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cash_renderedtxtbox_TextChanged(object sender, EventArgs e)
        {
            changeTxtbox.Text = ""; // Clear change while typing new cash
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                cash_renderedtxtbox.Text += btn.Text; // Append pressed button value
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                cash_renderedtxtbox.Text += btn.Text; // Append pressed button value
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                cash_renderedtxtbox.Text += btn.Text; // Append pressed button value
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                cash_renderedtxtbox.Text += btn.Text; // Append pressed button value
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                cash_renderedtxtbox.Text += btn.Text; // Append pressed button value
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                cash_renderedtxtbox.Text += btn.Text; // Append pressed button value
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                cash_renderedtxtbox.Text += btn.Text; // Append pressed button value
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                cash_renderedtxtbox.Text += btn.Text; // Append pressed button value
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                cash_renderedtxtbox.Text += btn.Text; // Append pressed button value
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                cash_renderedtxtbox.Text += btn.Text; // Append pressed button value
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                cash_renderedtxtbox.Text += btn.Text; // Append pressed button value
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                cash_renderedtxtbox.Text += btn.Text; // Append pressed button value
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                cash_renderedtxtbox.Text += btn.Text; // Append pressed button value
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                cash_renderedtxtbox.Text += btn.Text; // Append pressed button value
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                cash_renderedtxtbox.Text += btn.Text; // Append pressed button value
            }
        }

        private void qtyTxtbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
