using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lesson2
{
    public partial class EXAM : Form
    {
        private double total_amount = 0;
        private int total_qty = 0;

        public EXAM()
        {
            InitializeComponent();
        }

                private bool TryParseDouble(string text, out double value)
        {
            return double.TryParse(
                text.Replace("P", "").Replace(",", "").Replace(" ", "").Trim(),
                out value
            );
        }

        private bool TryParseInt(string text, out int value)
        {
            return int.TryParse(text.Trim(), out value);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }

        private void EXAM_Load(object sender, EventArgs e)
        {
            // DISABLING TEXTBOXES
            priceTxtBox.Enabled = false;
            changeTxtbox.Enabled = false;
            totalBillsTxtbox.Enabled = false;
            discountTxtbox.Enabled = false;
            totalQtyTxtbox.Enabled = false;
            discountedTxtbox.Enabled = false;

            // DISABLING CHECKBOXES
            A_CokeCheckBox.Checked = false;
            A_FriedChickencheckBox.Checked = false;
            A_FriescheckBox.Checked = false;
            A_sideDishCheckbox.Checked = false;
            A_SpecialPizaCheckbox.Checked = false;
            B_carbonaracheckBox.Checked = false;
            B_ChickencheckBox.Checked = false;
            B_FriescheckBox.Checked = false;
            B_halohalocheckBox.Checked = false;
            B_HawaiiancheckBox.Checked = false;
        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            double price;
            // change form background
            this.BackColor = Color.LightCyan;

            // insert image in PictureBox
            DisplayPictureBox.Image = Properties.Resources.FoodBundleA;

            // check bundle A checkboxes
            A_CokeCheckBox.Checked = true;
            A_FriedChickencheckBox.Checked = true;
            A_FriescheckBox.Checked = true;
            A_sideDishCheckbox.Checked = true;
            A_SpecialPizaCheckbox.Checked = true;

            // uncheck bundle B checkboxes
            B_carbonaracheckBox.Checked = false;
            B_ChickencheckBox.Checked = false;
            B_FriescheckBox.Checked = false;
            B_halohalocheckBox.Checked = false;
            B_HawaiiancheckBox.Checked = false;

            // display data in textboxes
            priceTxtBox.Text = "P1, 000.00";
            discountTxtbox.Text = "200.00";

            if (!TryParseDouble(priceTxtBox.Text, out price))
            {
                MessageBox.Show("Invalid price format in Bundle A.");
                return;
            }

            //inserting data inside the listbox
            displayListbox.Items.Add(foodARdbt.Text);
            displayListbox.Items.Add("Discount Amount: " + discountTxtbox.Text);
            qtyTxtbox.Text = "0";
            qtyTxtbox.Focus();
        }

        private void foodBRdbt_CheckedChanged(object sender, EventArgs e)
        {
            // change form background
            this.BackColor = Color.LightBlue;

            // insert image in PictureBox
            DisplayPictureBox.Image = Properties.Resources.FoodBundleB;

            // check bundle A checkboxes
            A_CokeCheckBox.Checked = false;
            A_FriedChickencheckBox.Checked = false;
            A_FriescheckBox.Checked = false;
            A_sideDishCheckbox.Checked = false;
            A_SpecialPizaCheckbox.Checked = false;

            // uncheck bundle B checkboxes
            B_carbonaracheckBox.Checked = true;
            B_ChickencheckBox.Checked = true;
            B_FriescheckBox.Checked = true;
            B_halohalocheckBox.Checked = true;
            B_HawaiiancheckBox.Checked = true;

            // display data in textboxes
            priceTxtBox.Text = "P1, 299.00";
            discountTxtbox.Text = "P194.85";

            displayListbox.Items.Add(foodBRdbt.Text);
            displayListbox.Items.Add("Discount Amount: " + discountTxtbox.Text);
        }

        private void displayListbox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double cash_given, change, total_amountPaid;
            cash_given = Convert.ToDouble(cashTxtbox.Text);
            total_amountPaid = Convert.ToDouble(totalBillsTxtbox.Text);
            
            /*if (!TryParseDouble(cashTxtbox.Text, out cash_given) ||
                !TryParseDouble(totalBillsTxtbox.Text, out total_amountPaid))
            {
                MessageBox.Show("Please enter valid numeric values for cash and total bills.");
                return;
            }*/

            change = cash_given - total_amountPaid;
            changeTxtbox.Text = change.ToString("n");
            displayListbox.Items.Add("Total Bills: " + " " + totalBillsTxtbox.Text);
            displayListbox.Items.Add("Cash Given: " + " " + cashTxtbox.Text);
            displayListbox.Items.Add("Total No. Of Items: " + " " + totalQtyTxtbox.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Activity_4_PrintFrm print = new Activity_4_PrintFrm();
            print.printdisplayListbox.Items.AddRange(displayListbox.Items);
            print.Show();
        }

        private void DisplayPictureBox_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (displayListbox.SelectedIndex != -1)
            {
                displayListbox.Items.RemoveAt(displayListbox.SelectedIndex);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            foodARdbt.Checked = false;
            foodBRdbt.Checked = false;

            DisplayPictureBox.Image = Properties.Resources.clear;

            // reset all checkboxes
            A_CokeCheckBox.Checked = false;
            A_FriedChickencheckBox.Checked = false;
            A_FriescheckBox.Checked = false;
            A_sideDishCheckbox.Checked = false;
            A_SpecialPizaCheckbox.Checked = false;
            B_carbonaracheckBox.Checked = false;
            B_ChickencheckBox.Checked = false;
            B_FriescheckBox.Checked = false;
            B_halohalocheckBox.Checked = false;
            B_HawaiiancheckBox.Checked = false;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            checkBox7.Checked = false;
            checkBox8.Checked = false;
            checkBox9.Checked = false;
            checkBox10.Checked = false;
            checkBox11.Checked = false;
            checkBox12.Checked = false;
            checkBox13.Checked = false;
            checkBox14.Checked = false;
            checkBox15.Checked = false;
            checkBox16.Checked = false;
            checkBox17.Checked = false;
            checkBox18.Checked = false;
            checkBox19.Checked = false;
            checkBox20.Checked = false;
            displayListbox.Items.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void totalQtyTxtbox_TextChanged(object sender, EventArgs e)
        {
            double price, discounted_amount, discount_amount;
            int qty;

            if (!TryParseDouble(priceTxtBox.Text, out price) ||
                !TryParseInt(qtyTxtbox.Text, out qty) ||
                !TryParseDouble(discountTxtbox.Text, out discount_amount))
            {
                return; // invalid inputs → skip calculation
            }

            discounted_amount = (price * qty) - discount_amount;
            total_qty += qty;
            totalQtyTxtbox.Text = total_qty.ToString();
            total_amount += discounted_amount;
            totalBillsTxtbox.Text = total_amount.ToString("n");
            discountedTxtbox.Text = discounted_amount.ToString("n");
        }

        private void totalBillsTxtbox_TextChanged(object sender, EventArgs e)
        {

        }

        // all your checkBoxX_CheckedChanged remain as is...
        // (I didn’t modify them because they’re already consistent with TryParseDouble if needed)
    }
}
