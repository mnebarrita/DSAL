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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace mainsystem
{
    public partial class POS2_FunctionForm : Form
    {
        private double total_amount = 0;
        private int total_qty = 0;

        // new helpers to prevent double-counting
        private int currentItemLastQuantity = 0;
        private double currentItemLastAmount = 0.0;
        private bool updatingQuantity = false;
        public POS2_FunctionForm()
        {
            InitializeComponent();
        }
        private void HandleCheckBoxClick(System.Windows.Forms.CheckBox chk, double price)
        {
            // If checkbox is checked, add item to total; if unchecked, subtract it
            if (chk.Checked)
            {
                priceTxtBox.Text = price.ToString("N2");
                discountTxtbox.Text = "0.00";
                displayListbox.Items.Add(chk.Text + " " + price.ToString("N2"));

                total_amount += price;
                total_qty += 1;
            }
            else
            {
                // If unchecked, remove from total
                total_amount -= price;
                total_qty -= 1;

                // Optionally, remove item from listbox
                for (int i = displayListbox.Items.Count - 1; i >= 0; i--)
                {
                    if (displayListbox.Items[i].ToString().StartsWith(chk.Text))
                    {
                        displayListbox.Items.RemoveAt(i);
                        break;
                    }
                }
            }

            // Update totals
            totalBillsTxtbox.Text = total_amount.ToString("N2");
            totalQtyTxtbox.Text = total_qty.ToString();
        }

        private void EXAM_Load(object sender, EventArgs e)
        {
            CenterPanel();
            this.Resize += (s, ev) => CenterPanel();

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

            this.BackgroundImage = Properties.Resources.POS2wallpaper;
            this.BackgroundImageLayout = ImageLayout.Stretch;

        }

        private void CenterPanel()
        {
            panelMain.Left = (this.ClientSize.Width - panelMain.Width) / 2;
            panelMain.Top = (this.ClientSize.Height - panelMain.Height) / 2;
        }
        private void foodARdbt_CheckedChanged(object sender, EventArgs e)
        {
            if (foodARdbt.Checked)
            {
                displayListbox.Items.Clear();
                double price = 1000.00;   // given bundle price
                double discount = 200.00; // given discount

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
                priceTxtBox.Enabled = false;      // Price
                discountedTxtbox.Enabled = false;  // Discounted Amount
                discountTxtbox.Enabled = false;  // Discount Amount

                priceTxtBox.Text = price.ToString("N2");         // Price textbox
                discountTxtbox.Text = discount.ToString("N2");  // Discount Amount

                // Add to ListBox
                displayListbox.Items.Add(foodARdbt.Text + " " + priceTxtBox.Text);
                displayListbox.Items.Add("         Discount Amount: " + discountTxtbox.Text);

                // Reset quantity
                qtyTxtbox.Text = "1";
                qtyTxtbox.Focus();
            }
        }

        private void foodBRdbt_CheckedChanged(object sender, EventArgs e)
        {
            if (foodBRdbt.Checked)
            {
                displayListbox.Items.Clear();
                double price = 1299.00;                  // given bundle price
                double discount = price * 0.15;          // 15% discount

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

                // Disable textboxes 1–5
                priceTxtBox.Enabled = false;      // Price
                discountedTxtbox.Enabled = false;  // Discounted Amount
                discountTxtbox.Enabled = false;  // Discount Amount

                // Fill values
                priceTxtBox.Text = price.ToString("N2");        // Price textbox
                discountTxtbox.Text = discount.ToString("N2"); // Discount Amount

                // Add to ListBox
                displayListbox.Items.Add(foodBRdbt.Text + " " + priceTxtBox.Text);
                displayListbox.Items.Add("         Discount Amount: " + discountTxtbox.Text);

                // Reset quantity
                qtyTxtbox.Text = "1";
                qtyTxtbox.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Convert inputs to double
            double cashGiven = Convert.ToDouble(cashTxtbox.Text);
            double totalAmountPaid = Convert.ToDouble(totalBillsTxtbox.Text);

            // Calculate change
            double change = cashGiven - totalAmountPaid;

            // Display change
            changeTxtbox.Text = change.ToString("N2");

            // Add summary to ListBox
            displayListbox.Items.Add("Total Bills: " + totalBillsTxtbox.Text);
            displayListbox.Items.Add("Cash Given: " + cashTxtbox.Text);
            displayListbox.Items.Add("Change: " + changeTxtbox.Text);
            displayListbox.Items.Add("Total No. of Items: " + totalQtyTxtbox.Text);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Activity_4_PrintFrm print = new Activity_4_PrintFrm();
            print.printdisplayListbox.Items.AddRange(displayListbox.Items);
            print.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Reset totals and current-item trackers
            total_amount = 0;
            total_qty = 0;
            currentItemLastAmount = 0;
            currentItemLastQuantity = 0;

            discountedTxtbox.Text = "0.00";
            totalBillsTxtbox.Text = "0.00";
            totalQtyTxtbox.Text = "0";
            displayListbox.Items.Clear();
        }
        private void button4_Click(object sender, EventArgs e)
        {

            total_amount = 0;
            total_qty = 0;
            currentItemLastAmount = 0.0;
            currentItemLastQuantity = 0;
            totalBillsTxtbox.Text = "0.00";
            totalQtyTxtbox.Text = "0";

            foodARdbt.Checked = false;
            foodBRdbt.Checked = false;

            foodARdbt.Enabled = true;
            foodBRdbt.Enabled = true;

            DisplayPictureBox.Image = null;
            this.BackColor = SystemColors.Control;

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

            priceTxtBox.Text = "";
            qtyTxtbox.Text = "0";
            discountTxtbox.Text = "";
            discountedTxtbox.Text = "";
            totalBillsTxtbox.Text = "";
            totalQtyTxtbox.Text = "";
            cashTxtbox.Text = "";
            changeTxtbox.Text = "";

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void totalBillsTxtbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            HandleCheckBoxClick(checkBox1, 275.50);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            HandleCheckBoxClick(checkBox2, 199.75);
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            HandleCheckBoxClick(checkBox3, 145.90);
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            HandleCheckBoxClick(checkBox4, 199.75);
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            HandleCheckBoxClick(checkBox5, 199.75);
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            HandleCheckBoxClick(checkBox10, 420.60);
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            HandleCheckBoxClick(checkBox9, 500.99);
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            HandleCheckBoxClick(checkBox8, 380.60);
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            HandleCheckBoxClick(checkBox7, 225.35);
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            HandleCheckBoxClick(checkBox6, 145.90);
        }

        private void checkBox15_CheckedChanged(object sender, EventArgs e)
        {
            HandleCheckBoxClick(checkBox15, 150.80);
        }

        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {
            HandleCheckBoxClick(checkBox14, 295.25);
        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            HandleCheckBoxClick(checkBox13, 190.60);
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            HandleCheckBoxClick(checkBox12, 150.80);
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            HandleCheckBoxClick(checkBox11, 225.35);
        }

        private void checkBox20_CheckedChanged(object sender, EventArgs e)
        {
            HandleCheckBoxClick(checkBox20, 145.90);
        }

        private void checkBox19_CheckedChanged(object sender, EventArgs e)
        {
            HandleCheckBoxClick(checkBox19, 199.75);
        }

        private void checkBox18_CheckedChanged(object sender, EventArgs e)
        {
            HandleCheckBoxClick(checkBox18, 199.75);
        }

        private void checkBox17_CheckedChanged(object sender, EventArgs e)
        {
            HandleCheckBoxClick(checkBox17, 199.75);
        }

        private void checkBox16_CheckedChanged(object sender, EventArgs e)
        {
            HandleCheckBoxClick(checkBox16, 225.35);
        }

        private void totalQtyTxtbox_TextChanged(object sender, EventArgs e)
        {
            // You can add logic here if you want to handle changes to the totalQtyTxtbox.
            // For now, this is just a placeholder to resolve the event handler error.
        }

        private void qtyTxtbox_TextChanged_1(object sender, EventArgs e)
        {
            // If we are setting text programmatically, ignore
            if (updatingQuantity) return;

            // Parse with TryParse to avoid exceptions
            if (!double.TryParse(priceTxtBox.Text, out double price))
            {
                // no valid price -> nothing to do
                discountedTxtbox.Text = "0.00";
                return;
            }

            if (!int.TryParse(qtyTxtbox.Text, out int quantity))
            {
                // invalid quantity -> treat as 0
                quantity = 0;
            }

            if (!double.TryParse(discountTxtbox.Text, out double discountAmt))
            {
                discountAmt = 0.0;
            }

            // Compute amount for current item
            double currentItemAmount = (price * quantity) - discountAmt;

            // Compute deltas from previously recorded values (prevents double counting)
            double amountDelta = currentItemAmount - currentItemLastAmount;
            int qtyDelta = quantity - currentItemLastQuantity;

            // Update running totals by deltas
            total_amount += amountDelta;
            total_qty += qtyDelta;

            // Save current item state for future delta computations
            currentItemLastAmount = currentItemAmount;
            currentItemLastQuantity = quantity;

            // Display the current item calculations and totals
            discountedTxtbox.Text = currentItemAmount.ToString("N2");   // Discounted Amount for this item
            totalBillsTxtbox.Text = total_amount.ToString("N2");          // Total Bills
            totalQtyTxtbox.Text = total_qty.ToString();                 // Total Quantity
        }

        private void discountTxtbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}
