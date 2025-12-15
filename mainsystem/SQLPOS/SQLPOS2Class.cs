using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using mainsystem.L14_Classes;
using mainsystem.Properties;

namespace mainsystem
{
    public partial class SQLPOS2Class : Form
    {
        // 1. CLASS VARIABLES (Matches the Book's setup)
        posdb_connect pos_db = new posdb_connect();
        POS2_Functions pos2 = new POS2_Functions();

        // Variables for Totals (Essential for the math to work!)
        private double total_amount = 0;
        private int total_qty = 0;
        public SQLPOS2Class()
        {
            InitializeComponent();
        }

        private void SQLPOS2Class_Load(object sender, EventArgs e)
        {
            try
            {
                this.BackgroundImage = Properties.Resources.background11;
                this.BackgroundImageLayout = ImageLayout.Stretch;
                this.DisplayPictureBox.Image = Resources.clear1;
                this.DisplayPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

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

                pos_db.pos_connString();
                pos_db.posdb_open();

                pos_db.pos_sql = "SELECT * FROM pos_nameTb1 " +
                                     "INNER JOIN pos_picTb1 ON pos_nameTb1.pos_id = pos_picTb1.pos_id " +
                                     "INNER JOIN pos_priceTb1 ON pos_picTb1.pos_id = pos_priceTb1.pos_id " +
                                     "WHERE pos_nameTb1.pos_id = 3";

                pos_db.pos_cmd();
                pos_db.pos_sqladapterSelect();
                pos_db.pos_sql_dataset = new DataSet();
                pos_db.pos_sql_dataadapter.Fill(pos_db.pos_sql_dataset, "MenuTable");

                // D. MANUALLY ASSIGN TEXT TO CHECKBOXES (Like Page 377)    
                if (pos_db.pos_sql_dataset.Tables["MenuTable"].Rows.Count > 0)
                {
                    DataRow row = pos_db.pos_sql_dataset.Tables["MenuTable"].Rows[0];

                    // --- PIZZA NAMES (1-20) ---
                    checkBox1.Text = row["name1"].ToString();
                    checkBox2.Text = row["name2"].ToString();
                    checkBox3.Text = row["name3"].ToString();
                    checkBox4.Text = row["name4"].ToString();
                    checkBox5.Text = row["name5"].ToString();
                    checkBox6.Text = row["name6"].ToString();
                    checkBox7.Text = row["name7"].ToString();
                    checkBox8.Text = row["name8"].ToString();
                    checkBox9.Text = row["name9"].ToString();
                    checkBox10.Text = row["name10"].ToString();
                    checkBox11.Text = row["name11"].ToString();
                    checkBox12.Text = row["name12"].ToString();
                    checkBox13.Text = row["name13"].ToString();
                    checkBox14.Text = row["name14"].ToString();
                    checkBox15.Text = row["name15"].ToString();
                    checkBox16.Text = row["name16"].ToString();
                    checkBox17.Text = row["name17"].ToString();
                    checkBox18.Text = row["name18"].ToString();
                    checkBox19.Text = row["name19"].ToString();
                    checkBox20.Text = row["name20"].ToString();

                    // B. LOAD PRICES INTO LABELS (Your new controls!)
                    pricelbl1.Text = row["price1"].ToString();
                    pricelbl2.Text = row["price2"].ToString();
                    pricelbl3.Text = row["price3"].ToString();
                    pricelbl4.Text = row["price4"].ToString();
                    pricelbl5.Text = row["price5"].ToString();
                    pricelbl10.Text = row["price6"].ToString();
                    pricelbl9.Text = row["price7"].ToString();
                    pricelbl8.Text = row["price8"].ToString();
                    pricelbl7.Text = row["price9"].ToString();
                    pricelbl6.Text = row["price10"].ToString();
                    pricelbl15.Text = row["price11"].ToString();
                    pricelbl14.Text = row["price12"].ToString();
                    pricelbl13.Text = row["price13"].ToString();
                    pricelbl12.Text = row["price14"].ToString();
                    pricelbl11.Text = row["price15"].ToString();
                    pricelbl20.Text = row["price16"].ToString();
                    pricelbl19.Text = row["price17"].ToString();
                    pricelbl18.Text = row["price18"].ToString();
                    pricelbl17.Text = row["price19"].ToString();
                    pricelbl16.Text = row["price20"].ToString();

                    // --- STORE PRICES IN TAGS (Crucial for Math) ---
                    // The book might use a separate method, but this is the safest way to keep the price with the box.
                    checkBox1.Tag = row["price1"].ToString();
                    checkBox2.Tag = row["price2"].ToString();
                    checkBox3.Tag = row["price3"].ToString();
                    checkBox4.Tag = row["price4"].ToString();
                    checkBox5.Tag = row["price5"].ToString();
                    checkBox6.Tag = row["price6"].ToString();
                    checkBox7.Tag = row["price7"].ToString();
                    checkBox8.Tag = row["price8"].ToString();
                    checkBox9.Tag = row["price9"].ToString();
                    checkBox10.Tag = row["price10"].ToString();
                    checkBox11.Tag = row["price11"].ToString();
                    checkBox12.Tag = row["price12"].ToString();
                    checkBox13.Tag = row["price13"].ToString();
                    checkBox14.Tag = row["price14"].ToString();
                    checkBox15.Tag = row["price15"].ToString();
                    checkBox16.Tag = row["price16"].ToString();
                    checkBox17.Tag = row["price17"].ToString();
                    checkBox18.Tag = row["price18"].ToString();
                    checkBox19.Tag = row["price19"].ToString();
                    checkBox20.Tag = row["price20"].ToString();

                    // 1. pic1 -> pictureBox2
                    string path1 = row["pic1"].ToString();
                    if (System.IO.File.Exists(path1)) pictureBox2.Image = Image.FromFile(path1);

                    // 2. pic2 -> pictureBox3
                    string path2 = row["pic2"].ToString();
                    if (System.IO.File.Exists(path2)) pictureBox3.Image = Image.FromFile(path2);

                    // 3. pic3 -> pictureBox4
                    string path3 = row["pic3"].ToString();
                    if (System.IO.File.Exists(path3)) pictureBox4.Image = Image.FromFile(path3);

                    // 4. pic4 -> pictureBox5
                    string path4 = row["pic4"].ToString();
                    if (System.IO.File.Exists(path4)) pictureBox5.Image = Image.FromFile(path4);

                    // 5. pic5 -> pictureBox6
                    string path5 = row["pic5"].ToString();
                    if (System.IO.File.Exists(path5)) pictureBox6.Image = Image.FromFile(path5);

                    // 6. pic6 -> pictureBox7
                    string path6 = row["pic6"].ToString();
                    if (System.IO.File.Exists(path6)) pictureBox7.Image = Image.FromFile(path6);

                    // 7. pic7 -> pictureBox8
                    string path7 = row["pic7"].ToString();
                    if (System.IO.File.Exists(path7)) pictureBox8.Image = Image.FromFile(path7);

                    // 8. pic8 -> pictureBox9
                    string path8 = row["pic8"].ToString();
                    if (System.IO.File.Exists(path8)) pictureBox9.Image = Image.FromFile(path8);

                    // 9. pic9 -> pictureBox10
                    string path9 = row["pic9"].ToString();
                    if (System.IO.File.Exists(path9)) pictureBox10.Image = Image.FromFile(path9);

                    // 10. pic10 -> pictureBox11
                    string path10 = row["pic10"].ToString();
                    if (System.IO.File.Exists(path10)) pictureBox11.Image = Image.FromFile(path10);

                    // 11. pic11 -> pictureBox12
                    string path11 = row["pic11"].ToString();
                    if (System.IO.File.Exists(path11)) pictureBox12.Image = Image.FromFile(path11);

                    // 12. pic12 -> pictureBox13
                    string path12 = row["pic12"].ToString();
                    if (System.IO.File.Exists(path12)) pictureBox13.Image = Image.FromFile(path12);

                    // 13. pic13 -> pictureBox14
                    string path13 = row["pic13"].ToString();
                    if (System.IO.File.Exists(path13)) pictureBox14.Image = Image.FromFile(path13);

                    // 14. pic14 -> pictureBox15
                    string path14 = row["pic14"].ToString();
                    if (System.IO.File.Exists(path14)) pictureBox15.Image = Image.FromFile(path14);

                    // 15. pic15 -> pictureBox16
                    string path15 = row["pic15"].ToString();
                    if (System.IO.File.Exists(path15)) pictureBox16.Image = Image.FromFile(path15);

                    // 16. pic16 -> pictureBox17
                    string path16 = row["pic16"].ToString();
                    if (System.IO.File.Exists(path16)) pictureBox17.Image = Image.FromFile(path16);

                    // 17. pic17 -> pictureBox18
                    string path17 = row["pic17"].ToString();
                    if (System.IO.File.Exists(path17)) pictureBox18.Image = Image.FromFile(path17);

                    // 18. pic18 -> pictureBox19
                    string path18 = row["pic18"].ToString();
                    if (System.IO.File.Exists(path18)) pictureBox19.Image = Image.FromFile(path18);

                    // 19. pic19 -> pictureBox20
                    string path19 = row["pic19"].ToString();
                    if (System.IO.File.Exists(path19)) pictureBox20.Image = Image.FromFile(path19);

                    // 20. pic20 -> pictureBox21 (Make sure you have a pictureBox21!)
                    string path20 = row["pic20"].ToString();
                    if (System.IO.File.Exists(path20)) pictureBox21.Image = Image.FromFile(path20);
                }
                pos_db.posdb_close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading menu: " + ex.Message);
            }
        }


        private void CenterPanel()
        {
            panelMain.Left = (this.ClientSize.Width - panelMain.Width) / 2;
            panelMain.Top = (this.ClientSize.Height - panelMain.Height) / 2;
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            if (double.TryParse(cashTxtbox.Text, out double cash) &&
                 double.TryParse(totalBillsTxtbox.Text, out double total))
            {
                changeTxtbox.Text = (cash - total).ToString("N2");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            this.DisplayPictureBox.Image = Resources.clear1;
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
            //currentItemLastAmount = 0.0;
            //currentItemLastQuantity = 0;

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

        private void foodARdbt_CheckedChanged(object sender, EventArgs e)
        {
            // 1. Define the Math
            double bundlePrice = 1000.00;
            double bundleDiscount = 200.00;
            double netAmount = 800.00;

            if (foodARdbt.Checked)
            {
                // --- VISUALS ---
                this.BackgroundImage = null;
                this.BackColor = Color.LightCyan;
                DisplayPictureBox.Image = Properties.Resources.FoodBundleA;

                // --- MATH: ADD TO THE SHARED TOTAL ---
                // This puts 800 into the global bucket
                total_amount += netAmount;
                total_qty += 1;

                // --- UPDATE ORDER DETAILS BOXES ---
                priceTxtBox.Text = bundlePrice.ToString("N2");
                discountTxtbox.Text = bundleDiscount.ToString("N2");
                qtyTxtbox.Text = "1";

                discountedTxtbox.Text = netAmount.ToString("N2");

                // --- AUTO-CHECK THE BUNDLE ITEMS (Left Side) ---
                // Make sure these match your actual checkbox names!
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

                // Add to Listbox
                displayListbox.Items.Add("Bundle A (Discounted): " + netAmount.ToString("N2"));
            }
            else
            {
                // --- REMOVE FROM TOTAL IF UNCHECKED ---
                total_amount -= netAmount;
                total_qty -= 1;

                // Restore Background
                this.BackgroundImage = Properties.Resources.POS2wallpaper;
                this.BackgroundImageLayout = ImageLayout.Stretch;

                // Remove from list
                for (int i = displayListbox.Items.Count - 1; i >= 0; i--)
                {
                    if (displayListbox.Items[i].ToString().Contains("Bundle A"))
                    {
                        displayListbox.Items.RemoveAt(i);
                    }
                }
            }

            // --- FINAL STEP: UPDATE THE TOTAL BILLS BOX ---
            totalBillsTxtbox.Text = total_amount.ToString("N2");
            totalQtyTxtbox.Text = total_qty.ToString();
        }

        private void foodBRdbt_CheckedChanged(object sender, EventArgs e)
        {
            // Calculate the NET amount for Bundle B
            double priceRaw = 1299.00;
            double discountRaw = priceRaw * 0.15;
            double netPrice = priceRaw - discountRaw;

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

                discountedTxtbox.Text = netPrice.ToString("N2");

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
        private void ProcessCheckbox(CheckBox chk)
        {
            try
            {
                // 1. Safety Check
                if (chk.Tag == null) return;

                double price = Convert.ToDouble(chk.Tag);

                // 2. Add or Subtract
                if (chk.Checked)
                {
                    // --- NEW: Update the "Order Details" boxes for the user to see ---
                    priceTxtBox.Text = price.ToString("N2");
                    qtyTxtbox.Text = "1";
                    // ----------------------------------------------------------------

                    total_amount += price;
                    total_qty += 1;

                    displayListbox.Items.Add(chk.Text + " " + price.ToString("N2"));
                }
                else
                {
                    // Optional: Clear the price box if they uncheck it
                    priceTxtBox.Text = "0.00";
                    qtyTxtbox.Text = "0";

                    total_amount -= price;
                    total_qty -= 1;

                    // Remove from Listbox
                    for (int i = displayListbox.Items.Count - 1; i >= 0; i--)
                    {
                        if (displayListbox.Items[i].ToString().StartsWith(chk.Text))
                        {
                            displayListbox.Items.RemoveAt(i);
                            break;
                        }
                    }
                }

                // 3. Update the TOTALS
                totalBillsTxtbox.Text = total_amount.ToString("N2");
                totalQtyTxtbox.Text = total_qty.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            ProcessCheckbox(checkBox1);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            ProcessCheckbox(checkBox2);
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            ProcessCheckbox(checkBox3);
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            ProcessCheckbox(checkBox4);
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            ProcessCheckbox(checkBox5);
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            ProcessCheckbox(checkBox10);
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            ProcessCheckbox(checkBox9);
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            ProcessCheckbox(checkBox8);
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            ProcessCheckbox(checkBox7);
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            ProcessCheckbox(checkBox6);
        }

        private void checkBox15_CheckedChanged(object sender, EventArgs e)
        {
            ProcessCheckbox(checkBox15);
        }

        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {
            ProcessCheckbox(checkBox14);
        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            ProcessCheckbox(checkBox13);
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            ProcessCheckbox(checkBox12);
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            ProcessCheckbox(checkBox11);
        }

        private void checkBox20_CheckedChanged(object sender, EventArgs e)
        {
            ProcessCheckbox(checkBox20);
        }

        private void checkBox19_CheckedChanged(object sender, EventArgs e)
        {
            ProcessCheckbox(checkBox19);
        }

        private void checkBox18_CheckedChanged(object sender, EventArgs e)
        {
            ProcessCheckbox(checkBox18);
        }

        private void checkBox17_CheckedChanged(object sender, EventArgs e)
        {
            ProcessCheckbox(checkBox17);
        }

        private void checkBox16_CheckedChanged(object sender, EventArgs e)
        {
            ProcessCheckbox(checkBox16);
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(changeTxtbox.Text) || total_amount <= 0)
            {
                MessageBox.Show("Please calculate the payment/transaction first.");
                return;
            }

            try
            {
                string myTerminal = "Terminal-2";
                string myEmpID = Program.CurrentEmpID;
                
                if (string.IsNullOrEmpty(myEmpID))
                {
                    myTerminal = "Terminal-0";  // <--- YOUR REQUEST
                    myEmpID = "0000-DEV";       // A placeholder ID for testing
                }

                pos_db.pos_connString();
                pos_db.posdb_open();

                // 2. CHECK: IS IT A BUNDLE OR CUSTOM?
                if (foodARdbt.Checked || foodBRdbt.Checked)
                {
                    // ============================================
                    // LOGIC A: SAVE AS BUNDLE (Single ROW)
                    // ============================================
                    string prodName = foodARdbt.Checked ? "Food Bundle A" : "Food Bundle B";
                    string discOption = "Bundle Discount";

                    // We use the textboxes because the math is already there
                    string sql = "INSERT INTO salesTb1 (" +
                        "terminal_no, product_name, product_price, product_quantity_per_transaction, " +
                        "discount_option, discount_amount_per_transaction, discounted_amount_per_transaction, " +
                        "summary_total_quantity, summary_total_disc_given, summary_total_discounted_amount, " +
                        "time_date, emp_id) VALUES (" +
                        "'" + myTerminal + "', " +
                        "'" + prodName + "', " +
                        "'" + priceTxtBox.Text + "', " +
                        "'" + qtyTxtbox.Text + "', " +
                        "'" + discOption + "', " +
                        "'" + discountTxtbox.Text + "', " +
                        "'" + discountedTxtbox.Text + "', " +
                        "'" + totalQtyTxtbox.Text + "', " +
                        "'" + discountTxtbox.Text + "', " +
                        "'" + totalBillsTxtbox.Text + "', " +
                        "'" + DateTime.Now.ToString("yyyy-MM-dd") + "', " +
                        "'" + myEmpID + "'" +
                        ")";

                    pos_db.pos_sql = sql;
                    pos_db.pos_cmd();
                    pos_db.pos_sqladapterInsert();
                }
                else
                {
                    // ============================================
                    // LOGIC B: SAVE AS CUSTOM (Loop through Listbox)
                    // ============================================
                    // We iterate through every item in the "Cart" (ListBox)
                    foreach (var item in displayListbox.Items)
                    {
                        string fullText = item.ToString(); // e.g., "Hawaiian 199.75"

                        // PARSE THE NAME AND PRICE
                        // We assume the format is "Name Price" (split by last space)
                        int lastSpaceIndex = fullText.LastIndexOf(' ');
                        string pName = fullText.Substring(0, lastSpaceIndex); // "Hawaiian"
                        string pPrice = fullText.Substring(lastSpaceIndex + 1); // "199.75"

                        string sql = "INSERT INTO salesTb1 (" +
                            "terminal_no, product_name, product_price, product_quantity_per_transaction, " +
                            "discount_option, discount_amount_per_transaction, discounted_amount_per_transaction, " +
                            "summary_total_quantity, summary_total_disc_given, summary_total_discounted_amount, " +
                            "time_date, emp_id) VALUES (" +
                            "'" + myTerminal + "', " +
                            "'" + pName + "', " +        // Name from Listbox
                            "'" + pPrice + "', " +       // Price from Listbox
                            "'1', " +                    // Qty is always 1 per line item in custom
                            "'Regular Price', " +        // No discount for custom
                            "'0.00', " +                 // No discount amount
                            "'" + pPrice + "', " +       // Net price is same as original
                            "'1', " +              // Qty is just 1 for this specific row
                            "'0.00', " +           // Discount is 0
                            "'" + pPrice + "', " +
                            "'" + DateTime.Now.ToString("yyyy-MM-dd") + "', " +
                            "'" + myEmpID + "'" +         
                            ")";

                        pos_db.pos_sql = sql;
                        pos_db.pos_cmd();
                        pos_db.pos_sqladapterInsert();
                    }
                }

                pos_db.posdb_close();
                MessageBox.Show("Transaction Saved Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                button4.PerformClick(); // Clear Inputs
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving: " + ex.Message);
                if (pos_db.pos_sql_connection.State == ConnectionState.Open) pos_db.posdb_close();
            }
        }
    }
}
