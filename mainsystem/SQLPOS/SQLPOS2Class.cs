using mainsystem.L14_Classes;
using mainsystem.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mainsystem
{
    public partial class SQLPOS2Class : Form
    {
        posdb_connect pos_db = new posdb_connect();
        POS2_Functions pos2 = new POS2_Functions();

        private double total_amount = 0;
        private int total_qty = 0;
        public SQLPOS2Class()
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
        private void SQLPOS2Class_Load(object sender, EventArgs e)
        {
            try
            {
                // --- VISUAL SETUP ---
                this.BackgroundImage = Properties.Resources.background11;
                this.BackgroundImageLayout = ImageLayout.Stretch;
                this.DisplayPictureBox.Image = Resources.clear1;
                this.DisplayPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

                CenterPanel();
                this.Resize += (s, ev) => CenterPanel();

                LoadHeaderInformation();

                // --- DISABLE CONTROLS ---
                priceTxtBox.Enabled = false;
                changeTxtbox.Enabled = false;
                totalBillsTxtbox.Enabled = false;
                discountTxtbox.Enabled = false;
                totalQtyTxtbox.Enabled = false;
                discountedTxtbox.Enabled = false;

                ResetCheckboxes();

                // --- LOAD CATEGORIES (The Dropdown) ---
                LoadCategoryIDs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading POS 2: " + ex.Message);
            }
        }

        private void LoadHeaderInformation()
        {
            try
            {
                // 1. DATE & TERMINAL
                if (lblHeaderDate != null)
                    lblHeaderDate.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy");

                if (lblHeaderTerminal != null)
                    lblHeaderTerminal.Text = "PC Terminal 2"; // Unique to this form

                // 2. GET USERNAME
                string currentUsername = Program.CurrentEmpID;
                if (string.IsNullOrEmpty(currentUsername)) currentUsername = "0000-DEV";

                // 3. FETCH REAL ID & NAME
                pos_db.pos_connString();
                pos_db.posdb_open();

                string sql = "SELECT pos_empRegTb1.emp_id, pos_empRegTb1.emp_fname, pos_empRegTb1.emp_surname " +
                             "FROM useraccountTb1 " +
                             "INNER JOIN pos_empRegTb1 ON useraccountTb1.emp_id = pos_empRegTb1.emp_id " +
                             "WHERE useraccountTb1.username = '" + currentUsername + "'";

                pos_db.pos_sql = sql;
                pos_db.pos_cmd();
                SqlDataReader dr = pos_db.pos_sql_command.ExecuteReader();

                if (dr.Read())
                {
                    string realEmpID = dr["emp_id"].ToString();
                    string fname = dr["emp_fname"].ToString();
                    string lname = dr["emp_surname"].ToString();

                    if (lblHeaderEmpID != null) lblHeaderEmpID.Text = realEmpID;
                    if (lblHeaderName != null) lblHeaderName.Text = fname + " " + lname;
                }
                else
                {
                    // Fallback
                    if (lblHeaderEmpID != null) lblHeaderEmpID.Text = currentUsername;
                    if (lblHeaderName != null) lblHeaderName.Text = "Unknown User";
                }
                pos_db.posdb_close();
            }
            catch (Exception) { /* Safe fail */ }
        }

        private void LoadCategoryIDs()
        {
            try
            {
                pos_db.pos_connString();
                pos_db.posdb_open();

                comboBox1.Items.Clear(); // Make sure you added comboBox1 in Designer!

                string query = "SELECT DISTINCT pos_id FROM pos_nameTb1 ORDER BY pos_id ASC";
                using (SqlCommand cmd = new SqlCommand(query, pos_db.pos_sql_connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboBox1.Items.Add(reader["pos_id"].ToString());
                        }
                    }
                }

                // Default to ID 3 (Fast Food) if available, otherwise pick the first one
                if (comboBox1.Items.Contains("3"))
                    comboBox1.SelectedItem = "3";
                else if (comboBox1.Items.Count > 0)
                    comboBox1.SelectedIndex = 0;

                pos_db.posdb_close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading categories: " + ex.Message);
            }
        }

        private void LoadMenuButtons(string categoryID)
        {
            try
            {
                pos_db.pos_connString();
                pos_db.posdb_open();

                pos_db.pos_sql = "SELECT * FROM pos_nameTb1 " +
                                 "INNER JOIN pos_picTb1 ON pos_nameTb1.pos_id = pos_picTb1.pos_id " +
                                 "INNER JOIN pos_priceTb1 ON pos_picTb1.pos_id = pos_priceTb1.pos_id " +
                                 "WHERE pos_nameTb1.pos_id = " + categoryID;

                pos_db.pos_cmd();
                pos_db.pos_sqladapterSelect();
                pos_db.pos_sql_dataset = new DataSet();
                pos_db.pos_sql_dataadapter.Fill(pos_db.pos_sql_dataset, "MenuTable");

                if (pos_db.pos_sql_dataset.Tables["MenuTable"].Rows.Count > 0)
                {
                    DataRow row = pos_db.pos_sql_dataset.Tables["MenuTable"].Rows[0];

                    // Loop through 1 to 20 to set text/prices dynamically
                    for (int i = 1; i <= 20; i++)
                    {
                        // FIND THE CONTROLS AUTOMATICALLY
                        Control[] chk = this.Controls.Find("checkBox" + i, true);
                        Control[] lbl = this.Controls.Find("pricelbl" + i, true);

                        // NOTE: Your pictures in POS2 seem to map differently (checkBox1 might map to pictureBox2?)
                        // If your naming is consistent (checkBox1 -> pictureBox1), change +1 to +0 below.
                        Control[] pic = this.Controls.Find("pictureBox" + (i + 1), true);

                        // SET CHECKBOX TEXT & TAG
                        if (chk.Length > 0 && chk[0] is CheckBox checkBox)
                        {
                            string name = row["name" + i].ToString();
                            string price = row["price" + i].ToString();

                            checkBox.Text = string.IsNullOrEmpty(name) ? "Item " + i : name;
                            checkBox.Tag = price; // Important for calculations!

                            // Hide checkbox if no item exists? Optional.
                            // checkBox.Visible = !string.IsNullOrEmpty(name); 
                        }

                        // SET PRICE LABEL
                        if (lbl.Length > 0)
                            lbl[0].Text = row["price" + i].ToString();

                        // SET IMAGE
                        if (pic.Length > 0 && pic[0] is PictureBox pictureBox)
                        {
                            string path = row["pic" + i].ToString();
                            if (System.IO.File.Exists(path))
                                pictureBox.Image = Image.FromFile(path);
                            else
                                pictureBox.Image = null; // Clear if no image
                        }
                    }
                }
                pos_db.posdb_close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Menu Load Error: " + ex.Message);
            }
        }

        private void ResetCheckboxes()
        {
            // Clear Bundle Checks
            A_CokeCheckBox.Checked = false; A_FriedChickencheckBox.Checked = false; A_FriescheckBox.Checked = false;
            A_sideDishCheckbox.Checked = false; A_SpecialPizaCheckbox.Checked = false;
            B_carbonaracheckBox.Checked = false; B_ChickencheckBox.Checked = false; B_FriescheckBox.Checked = false;
            B_halohalocheckBox.Checked = false; B_HawaiiancheckBox.Checked = false;

            // Clear Menu Checks (1-20)
            for (int i = 1; i <= 20; i++)
            {
                Control[] c = this.Controls.Find("checkBox" + i, true);
                if (c.Length > 0 && c[0] is CheckBox chk) chk.Checked = false;
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

            foodARdbt.Checked = false;
            foodBRdbt.Checked = false;
            ResetCheckboxes();

            total_amount = 0;
            total_qty = 0;

            foodARdbt.Enabled = true;
            foodBRdbt.Enabled = true;

            displayListbox.Items.Clear();

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
            double bundlePrice = 1000.00;
            double bundleDiscount = 200.00;
            double netAmount = 800.00;

            if (foodARdbt.Checked)
            {
                this.BackgroundImage = null;
                this.BackColor = Color.LightCyan;
                DisplayPictureBox.Image = Properties.Resources.FoodBundleA;

                total_amount += netAmount;
                total_qty += 1;

                priceTxtBox.Text = bundlePrice.ToString("N2");
                discountTxtbox.Text = bundleDiscount.ToString("N2");
                qtyTxtbox.Text = "1";

                discountedTxtbox.Text = netAmount.ToString("N2");

                A_CokeCheckBox.Checked = true;
                A_FriedChickencheckBox.Checked = true;
                A_FriescheckBox.Checked = true;
                A_sideDishCheckbox.Checked = true;
                A_SpecialPizaCheckbox.Checked = true;

                B_carbonaracheckBox.Checked = false;
                B_ChickencheckBox.Checked = false;
                B_FriescheckBox.Checked = false;
                B_halohalocheckBox.Checked = false;
                B_HawaiiancheckBox.Checked = false;

                displayListbox.Items.Add("Bundle A (Discounted): " + netAmount.ToString("N2"));
            }
            else
            {
                total_amount -= netAmount;
                total_qty -= 1;

                this.BackgroundImage = Properties.Resources.POS2wallpaper;
                this.BackgroundImageLayout = ImageLayout.Stretch;

                for (int i = displayListbox.Items.Count - 1; i >= 0; i--)
                {
                    if (displayListbox.Items[i].ToString().Contains("Bundle A"))
                    {
                        displayListbox.Items.RemoveAt(i);
                    }
                }
            }

            totalBillsTxtbox.Text = total_amount.ToString("N2");
            totalQtyTxtbox.Text = total_qty.ToString();
        }

        private void foodBRdbt_CheckedChanged(object sender, EventArgs e)
        {
            double priceRaw = 1299.00;
            double discountRaw = priceRaw * 0.15;
            double netPrice = priceRaw - discountRaw;

            if (foodBRdbt.Checked)
            {
                this.BackgroundImage = null;
                this.BackColor = Color.LightBlue;

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
                total_amount -= netPrice;
                total_qty -= 1;

                for (int i = displayListbox.Items.Count - 1; i >= 0; i--)
                {
                    if (displayListbox.Items[i].ToString().Contains("Bundle B"))
                    {
                        displayListbox.Items.RemoveAt(i);
                    }
                }
            }

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
                string itemText = displayListbox.SelectedItem.ToString();

                string[] parts = itemText.Split(' ');
                if (parts.Length > 0)
                {
                    string priceString = parts[parts.Length - 1];
                    if (double.TryParse(priceString, out double priceToRemove))
                    {
                        total_amount -= priceToRemove;
                        total_qty -= 1;
                    }
                }

                displayListbox.Items.RemoveAt(displayListbox.SelectedIndex);

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
                if (chk.Tag == null) return;

                double price = Convert.ToDouble(chk.Tag);

                if (chk.Checked)
                {
                    priceTxtBox.Text = price.ToString("N2");
                    qtyTxtbox.Text = "1";

                    total_amount += price;
                    total_qty += 1;

                    displayListbox.Items.Add(chk.Text + " " + price.ToString("N2"));
                }
                else
                {
                    priceTxtBox.Text = "0.00";
                    qtyTxtbox.Text = "0";

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
                if (string.IsNullOrEmpty(myEmpID)) myEmpID = "0000-DEV";

                pos_db.pos_connString();
                pos_db.posdb_open();

                // 1. Check if it's a Bundle Sale
                if (foodARdbt.Checked || foodBRdbt.Checked)
                {
                    string prodName = foodARdbt.Checked ? "Food Bundle A" : "Food Bundle B";
                    string discOption = "Bundle Discount";

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
                    // 2. Or Individual Items from Listbox
                    foreach (var item in displayListbox.Items)
                    {
                        // Clean up string to get Name and Price
                        string fullText = item.ToString();
                        int lastSpaceIndex = fullText.LastIndexOf(' ');

                        string pName = fullText;
                        string pPrice = "0.00";

                        if (lastSpaceIndex > 0)
                        {
                            pName = fullText.Substring(0, lastSpaceIndex);
                            pPrice = fullText.Substring(lastSpaceIndex + 1);
                        }

                        string sql = "INSERT INTO salesTb1 (" +
                            "terminal_no, product_name, product_price, product_quantity_per_transaction, " +
                            "discount_option, discount_amount_per_transaction, discounted_amount_per_transaction, " +
                            "summary_total_quantity, summary_total_disc_given, summary_total_discounted_amount, " +
                            "time_date, emp_id) VALUES (" +
                            "'" + myTerminal + "', " +
                            "'" + pName + "', " +
                            "'" + pPrice + "', " +
                            "'1', " +
                            "'Regular Price', " +
                            "'0.00', " +
                            "'" + pPrice + "', " +
                            "'1', " +
                            "'0.00', " +
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(comboBox1.Text))
            {
                button4.PerformClick();
                LoadMenuButtons(comboBox1.Text);
            }
        }
    }
}
