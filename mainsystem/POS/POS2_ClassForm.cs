using mainsystem.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace mainsystem
{
    public partial class POS2_ClassForm : Form
    {
        POS2_Functions pos2 = new POS2_Functions();
        private double total_amount = 0;
        private int total_qty = 0;

        // new helpers to prevent double-counting
        private int currentItemLastQuantity = 0;
        private double currentItemLastAmount = 0.0;
        private bool updatingQuantity = false;
        public POS2_ClassForm()
        {
            InitializeComponent();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on Double Buffering at the OS level
                return cp;
            }
        }

        private void HandleCheckBoxClick(System.Windows.Forms.CheckBox chk, double price)
        {
            if (chk.Checked)
            {
                priceTxtBox.Text = price.ToString("N2");
                displayListbox.Items.Add(chk.Text + " " + price.ToString("N2"));

                total_amount += price;
                total_qty += 1;
            }
            else
            {
                total_amount -= price;
                total_qty -= 1;

                for (int i = displayListbox.Items.Count - 1; i >= 0; i--)
                {
                    if (displayListbox.Items[i].ToString().StartsWith(chk.Text))
                    {
                        displayListbox.Items.RemoveAt(i);
                        break;
                    }
                }
            }

            // Only update totals here
            totalBillsTxtbox.Text = total_amount.ToString("N2");
            totalQtyTxtbox.Text = total_qty.ToString();
        }

        private void EXAM_Load(object sender, EventArgs e)
        {
            this.DisplayPictureBox.Image = Properties.Resources.clear;
            this.DisplayPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            this.BackgroundImage = Properties.Resources.POS2wallpaper;
            this.BackgroundImageLayout = ImageLayout.Stretch;

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
        }

        private void CenterPanel()
        {
            panelMain.Left = (this.ClientSize.Width - panelMain.Width) / 2;
            panelMain.Top = (this.ClientSize.Height - panelMain.Height) / 2;
        }
        private void foodARdbt_CheckedChanged(object sender, EventArgs e)
        {
            double netPrice = 800.00;

            if (foodARdbt.Checked)
            {
                this.BackgroundImage = null;
                this.BackColor = Color.LightCyan;

                double price = 1000.00;
                double discount = 200.00;

                DisplayPictureBox.Image = Properties.Resources.FoodBundleA;

                // Check Bundle A items
                A_CokeCheckBox.Checked = true;
                A_FriedChickencheckBox.Checked = true;
                A_FriescheckBox.Checked = true;
                A_sideDishCheckbox.Checked = true;
                A_SpecialPizaCheckbox.Checked = true;

                // Uncheck Bundle B items
                B_carbonaracheckBox.Checked = false;
                B_ChickencheckBox.Checked = false;
                B_FriescheckBox.Checked = false;
                B_halohalocheckBox.Checked = false;
                B_HawaiiancheckBox.Checked = false;

                // Display visuals
                priceTxtBox.Text = price.ToString("N2");
                discountTxtbox.Text = discount.ToString("N2");

                // --- 2. ADD TO THE RUNNING TOTAL ---
                total_amount += netPrice;
                total_qty += 1;

                displayListbox.Items.Add("Bundle A (Discounted): " + netPrice.ToString("N2"));

                qtyTxtbox.Text = "1";
                qtyTxtbox.Focus();
            }
            else
            {
                this.BackgroundImage = Properties.Resources.POS2wallpaper;
                this.BackgroundImageLayout = ImageLayout.Stretch;

                // --- 3. SUBTRACT IF UNCHECKED (Switching to Bundle B or Reset) ---
                total_amount -= netPrice;
                total_qty -= 1;

                // Remove Bundle A from the listbox
                for (int i = displayListbox.Items.Count - 1; i >= 0; i--)
                {
                    if (displayListbox.Items[i].ToString().Contains("Bundle A"))
                    {
                        displayListbox.Items.RemoveAt(i);
                    }
                }
            }

            // --- 4. UPDATE THE TOTAL BILL BOX ---
            totalBillsTxtbox.Text = total_amount.ToString("N2");
            totalQtyTxtbox.Text = total_qty.ToString();
        }

        private void foodBRdbt_CheckedChanged(object sender, EventArgs e)
        {
            // Calculate the NET amount for Bundle B
            double priceRaw = 1299.00;
            double discountRaw = priceRaw * 0.15; // 194.85
            double netPrice = priceRaw - discountRaw; // 1104.15

            if (foodBRdbt.Checked)
            {
                this.BackgroundImage = null;
                this.BackColor = Color.LightBlue;
                // --- 1. REMOVED 'displayListbox.Items.Clear();' ---

                DisplayPictureBox.Image = Properties.Resources.FoodBundleB;

                // Uncheck Bundle A items
                A_CokeCheckBox.Checked = false;
                A_FriedChickencheckBox.Checked = false;
                A_FriescheckBox.Checked = false;
                A_sideDishCheckbox.Checked = false;
                A_SpecialPizaCheckbox.Checked = false;

                // Check Bundle B items
                B_carbonaracheckBox.Checked = true;
                B_ChickencheckBox.Checked = true;
                B_FriescheckBox.Checked = true;
                B_halohalocheckBox.Checked = true;
                B_HawaiiancheckBox.Checked = true;

                // Display visuals
                priceTxtBox.Text = priceRaw.ToString("N2");
                discountTxtbox.Text = discountRaw.ToString("N2");

                // --- 2. ADD TO THE RUNNING TOTAL ---
                total_amount += netPrice;
                total_qty += 1;

                displayListbox.Items.Add("Bundle B (Discounted): " + netPrice.ToString("N2"));

                qtyTxtbox.Text = "1";
                qtyTxtbox.Focus();
            }
            else
            {
                this.BackgroundImage = Properties.Resources.POS2wallpaper;
                this.BackgroundImageLayout = ImageLayout.Stretch;
                // --- 3. SUBTRACT IF UNCHECKED ---
                total_amount -= netPrice;
                total_qty -= 1;

                // Remove Bundle B from the listbox
                for (int i = displayListbox.Items.Count - 1; i >= 0; i--)
                {
                    if (displayListbox.Items[i].ToString().Contains("Bundle B"))
                    {
                        displayListbox.Items.RemoveAt(i);
                    }
                }
            }

            // --- 4. UPDATE THE TOTAL BILL BOX ---
            totalBillsTxtbox.Text = total_amount.ToString("N2");
            totalQtyTxtbox.Text = total_qty.ToString();
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
            if (displayListbox.SelectedIndex != -1)
            {
                // 2. Get the text of the selected item (e.g., "Fries 145.90")
                string itemText = displayListbox.SelectedItem.ToString();

                // 3. Extract the Price from the string
                // We split the string by spaces and take the last part, assuming format is "Name Price"
                string[] parts = itemText.Split(' ');
                if (parts.Length > 0)
                {
                    string priceString = parts[parts.Length - 1]; // Get the last word (the price)
                    if (double.TryParse(priceString, out double priceToRemove))
                    {
                        // 4. Subtract from totals
                        total_amount -= priceToRemove;
                        total_qty -= 1;
                    }
                }

                // 5. Remove the item from the list
                displayListbox.Items.RemoveAt(displayListbox.SelectedIndex);

                // 6. Update the displays
                totalBillsTxtbox.Text = total_amount.ToString("N2");
                totalQtyTxtbox.Text = total_qty.ToString();
            }
            else
            {
                MessageBox.Show("Please select an item to remove.", "Remove Order", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.DisplayPictureBox.Image = Properties.Resources.clear;
            this.DisplayPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            // Uncheck Radio Buttons
            foodARdbt.Checked = false;
            foodBRdbt.Checked = false;

            // Uncheck Bundle Items
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

            // Uncheck Pizza/Extra CheckBoxes
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

            // ---------------------------------------------------------
            // STEP 2: FORCE RESET VARIABLES (Clean up any negatives)
            // ---------------------------------------------------------
            total_amount = 0;
            total_qty = 0;
            currentItemLastAmount = 0.0;
            currentItemLastQuantity = 0;

            // ---------------------------------------------------------
            // STEP 3: RESET UI ELEMENTS
            // ---------------------------------------------------------
            foodARdbt.Enabled = true;
            foodBRdbt.Enabled = true;

            displayListbox.Items.Clear();

            // Clear all textboxes
            priceTxtBox.Text = "";
            qtyTxtbox.Text = "0";
            discountTxtbox.Text = "";
            discountedTxtbox.Text = "";

            totalBillsTxtbox.Text = "0.00";
            totalQtyTxtbox.Text = "0";

            cashTxtbox.Text = "";
            changeTxtbox.Text = "";

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void qtyTxtbox_TextChanged_1(object sender, EventArgs e)
        {
            pos2.UpdateQuantity(qtyTxtbox, priceTxtBox, discountTxtbox, discountedTxtbox, totalBillsTxtbox, totalQtyTxtbox);
        }

    }
}
