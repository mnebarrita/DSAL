using mainsystem.L14_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mainsystem
{
    public partial class SQLPOS1Class : Form
    {
        POS1_Functions posFunctions = new POS1_Functions();
        posdb_connect pos_db = new posdb_connect();

        private bool isLoading = true;

        public SQLPOS1Class()
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
        private void SQLPOS1Class_Load(object sender, EventArgs e)
        {
            Image img = Properties.Resources.download;
            img.RotateFlip(RotateFlipType.Rotate270FlipNone);

            this.BackgroundImage = img;
            this.BackgroundImageLayout = ImageLayout.Stretch;

            CenterPanel();
            this.Resize += (s, ev) => CenterPanel();

            isLoading = true;

            itemnameTxtbox.ReadOnly = true;
            priceTxtbox.ReadOnly = true;
            discountedTxtbox.ReadOnly = true;
            qtyTotalTxtbox.ReadOnly = true;
            discountTotalTxtbox.ReadOnly = true;
            discountedTotalTxtbox.ReadOnly = true;
            changeTxtbox.ReadOnly = true;
            discountTxtbox.ReadOnly = true;

            noTaxRdbtn.Checked = true;
            this.AcceptButton = enterBtn; 

            GenerateMenuFromHorizontalDB();
            LoadHeaderInformation();
            LoadCategoryIDs();

            isLoading = false;
            qtyTxtbox.Focus();
        }

        private void LoadHeaderInformation()
        {
            try
            {
                // 1. SET DATE & TERMINAL
                if (lblHeaderDate != null)
                    lblHeaderDate.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy");

                if (lblHeaderTerminal != null)
                    lblHeaderTerminal.Text = "PC Terminal 1";

                // 2. GET THE LOGGED-IN USERNAME
                string currentUsername = Program.CurrentEmpID;
                if (string.IsNullOrEmpty(currentUsername)) currentUsername = "0000-DEV";

                // 3. FETCH REAL ID & NAME FROM DATABASE
                pos_db.pos_connString();
                pos_db.posdb_open();

                // STEP A: We first look up the 'emp_id' using the username from the User Account Table
                // Then we JOIN it with the Employee Registration Table to get the Name.
                string sql = "SELECT pos_empRegTb1.emp_id, pos_empRegTb1.emp_fname, pos_empRegTb1.emp_surname " +
                             "FROM useraccountTb1 " +
                             "INNER JOIN pos_empRegTb1 ON useraccountTb1.emp_id = pos_empRegTb1.emp_id " +
                             "WHERE useraccountTb1.username = '" + currentUsername + "'";

                pos_db.pos_sql = sql;
                pos_db.pos_cmd();

                SqlDataReader dr = pos_db.pos_sql_command.ExecuteReader();

                if (dr.Read())
                {
                    // FOUND IT!
                    string realEmpID = dr["emp_id"].ToString();
                    string fname = dr["emp_fname"].ToString();
                    string lname = dr["emp_surname"].ToString();

                    // Update Labels with CORRECT Info
                    if (lblHeaderEmpID != null) lblHeaderEmpID.Text = realEmpID; // Shows "2023203112"
                    if (lblHeaderName != null) lblHeaderName.Text = fname + " " + lname; // Shows "Mica Barrita"
                }
                else
                {
                    // Fallback if not found
                    if (lblHeaderEmpID != null) lblHeaderEmpID.Text = currentUsername;
                    if (lblHeaderName != null) lblHeaderName.Text = "Unknown User";
                }

                pos_db.posdb_close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Header Error: " + ex.Message);
            }
        }

        private void CenterPanel()
        {
            panelMain.Left = (this.ClientSize.Width - panelMain.Width) / 2;
            panelMain.Top = (this.ClientSize.Height - panelMain.Height) / 2;
        }

        private void LoadCategoryIDs()
        {
            try
            {
                pos_db.pos_connString();
                pos_db.posdb_open();

                comboBox1.Items.Clear();

                // distinct ensures we don't get duplicates if you have multiple rows with same ID (unlikely but safe)
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

                // Default to the first item if available
                if (comboBox1.Items.Count > 0)
                {
                    comboBox1.SelectedIndex = 0;
                }

                pos_db.posdb_close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading categories: " + ex.Message);
            }
        }
        private void GenerateMenuFromHorizontalDB()
        {
            try
            {
                pos_db.pos_connString();
                pos_db.posdb_open();

                pos_db.pos_sql = "SELECT * FROM pos_nameTb1 " +
                         "INNER JOIN pos_picTb1 ON pos_nameTb1.pos_id = pos_picTb1.pos_id " +
                         "INNER JOIN pos_priceTb1 ON pos_picTb1.pos_id = pos_priceTb1.pos_id " +
                         "WHERE pos_nameTb1.pos_id = '" + comboBox1.Text + "'";

                pos_db.pos_cmd();
                pos_db.pos_sqladapterSelect();

                pos_db.pos_sql_dataset = new DataSet();
                pos_db.pos_sql_dataadapter.Fill(pos_db.pos_sql_dataset, "MenuTable");

                menuFlowPanel.Controls.Clear();

                if (pos_db.pos_sql_dataset.Tables["MenuTable"].Rows.Count > 0)
                {
                    DataRow row = pos_db.pos_sql_dataset.Tables["MenuTable"].Rows[0];
                    for (int i = 1; i <= 20; i++)
                    {
                        {
                            string nameCol = "name" + i;
                            string priceCol = "price" + i;
                            string picCol = "pic" + i;

                            if (row.Table.Columns.Contains(nameCol) && !string.IsNullOrEmpty(row[nameCol].ToString()))
                            {
                                string name = row[nameCol].ToString();
                                double price = 0;
                                double.TryParse(row[priceCol].ToString(), out price);
                                string imgPath = row[picCol].ToString();

                                System.Windows.Forms.Button prodBtn = new System.Windows.Forms.Button();

                                prodBtn.Width = 200;
                                prodBtn.Height = 200;
                                prodBtn.Font = new Font("MS UI Gothic", 11, FontStyle.Bold);

                                prodBtn.Text = name + "\n" + price.ToString("N0");
                                prodBtn.TextAlign = ContentAlignment.BottomCenter;
                                prodBtn.ForeColor = Color.Black;
                                prodBtn.Tag = price;

                                if (File.Exists(imgPath))
                                {
                                    prodBtn.BackgroundImage = Image.FromFile(imgPath);
                                    prodBtn.BackgroundImageLayout = ImageLayout.Zoom;
                                }
                                else
                                {
                                    prodBtn.BackColor = Color.LightGray;
                                }

                                prodBtn.Click += (s, args) => SelectItem(name, price);

                                menuFlowPanel.Controls.Add(prodBtn);
                            }
                        }
                    }
                    pos_db.posdb_close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading menu: " + ex.Message);
            }
        }

        private void SelectItem(string itemName, double price)
        {
            itemnameTxtbox.Text = itemName;
            priceTxtbox.Text = price.ToString("N0");
            qtyTxtbox.Text = "1";
            noTaxRdbtn.Checked = true;
            posFunctions.discountRate = 0.00;
            posFunctions.Compute(qtyTxtbox, priceTxtbox, discountTxtbox, discountedTxtbox);
        }

        private void calculateBtn_Click(object sender, EventArgs e)
        {
            if (posFunctions.ConvertQuantityPrice(qtyTxtbox, priceTxtbox))
            {
                posFunctions.Compute(qtyTxtbox, priceTxtbox, discountTxtbox, discountedTxtbox);

                string cashText = cash_renderedtxtbox.Text.Replace(",", "");
                if (!double.TryParse(cashText, out double cash))
                {
                    MessageBox.Show("Please enter a valid cash amount.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                double change = cash - posFunctions.discounted_amt;
                if (change < 0)
                {
                    MessageBox.Show("Insufficient cash!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    changeTxtbox.Text = "0.00";
                    return; 
                }

                changeTxtbox.Text = change.ToString("N2");
                posFunctions.UpdateTotals(qtyTotalTxtbox, discountTotalTxtbox, discountedTotalTxtbox);
            }
            else
            {
                MessageBox.Show("Invalid quantity or price.");
            }
        }

        private void enterBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(changeTxtbox.Text))
            {
                MessageBox.Show("Please calculate the transaction first.");
                return;
            }

            try
            {
                string myTerminal = "Terminal-1";
                string myEmpID = Program.CurrentEmpID;

                if (string.IsNullOrEmpty(myEmpID))
                {
                    myTerminal = "Terminal-0";
                    myEmpID = "0000-DEV";
                }

                pos_db.pos_connString();
                pos_db.posdb_open();

                string discOption = "No Discount";
                if (senrRdbtn.Checked) discOption = "Senior Citizen";
                else if (regularRdbtn.Checked) discOption = "Discount Card";
                else if (EmployeeRdbtn.Checked) discOption = "Employee Disc";

                // --- THE FIX: Clean the numbers by removing commas ---
                string cleanPrice = priceTxtbox.Text.Replace(",", "");
                string cleanQty = qtyTxtbox.Text.Replace(",", "");
                string cleanDiscountAmt = discountTxtbox.Text.Replace(",", "");
                string cleanDiscountedAmt = discountedTxtbox.Text.Replace(",", "");
                string cleanTotalQty = qtyTotalTxtbox.Text.Replace(",", "");
                string cleanTotalDisc = discountTotalTxtbox.Text.Replace(",", "");
                string cleanTotalAmount = discountedTotalTxtbox.Text.Replace(",", "");

                // Handle empty boxes just in case
                if (cleanDiscountAmt == "") cleanDiscountAmt = "0.00";
                if (cleanDiscountedAmt == "") cleanDiscountedAmt = "0.00";
                if (cleanTotalDisc == "") cleanTotalDisc = "0.00";
                if (cleanTotalAmount == "") cleanTotalAmount = "0.00";

                string sql = "INSERT INTO salesTb1 (" +
                    "terminal_no, " +
                    "product_name, " +
                    "product_price, " +
                    "product_quantity_per_transaction, " +
                    "discount_option, " +
                    "discount_amount_per_transaction, " +
                    "discounted_amount_per_transaction, " +
                    "summary_total_quantity, " +
                    "summary_total_disc_given, " +
                    "summary_total_discounted_amount, " +
                    "time_date, " +
                    "emp_id" +
                    ") VALUES (" +
                    "'" + myTerminal + "', " +
                    "'" + itemnameTxtbox.Text + "', " +
                    "'" + cleanPrice + "', " +              // Fixed
                    "'" + cleanQty + "', " +                // Fixed
                    "'" + discOption + "', " +
                    "'" + cleanDiscountAmt + "', " +        // Fixed
                    "'" + cleanDiscountedAmt + "', " +      // Fixed
                    "'" + cleanTotalQty + "', " +           // Fixed
                    "'" + cleanTotalDisc + "', " +          // Fixed
                    "'" + cleanTotalAmount + "', " +        // Fixed (This was the likely crasher!)
                    "'" + DateTime.Now.ToString("yyyy-MM-dd") + "', " +
                    "'" + myEmpID + "'" +
                    ")";

                pos_db.pos_sql = sql;
                pos_db.pos_cmd();
                pos_db.pos_sqladapterInsert();
                pos_db.posdb_close();

                MessageBox.Show("Transaction Saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearInputsOnly();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving: " + ex.Message);
            }
        }


        private void ClearInputsOnly()
        {
            // Clear inputs for the next customer/item
            itemnameTxtbox.Clear();
            qtyTxtbox.Clear();
            priceTxtbox.Clear();
            discountTxtbox.Clear();
            discountedTxtbox.Clear();

            cash_renderedtxtbox.Clear();
            changeTxtbox.Clear();

            // Reset Radio Buttons
            senrRdbtn.Checked = false;
            regularRdbtn.Checked = false;
            EmployeeRdbtn.Checked = false;
            noTaxRdbtn.Checked = true; 
            qtyTxtbox.Focus();
        }

        private void newBtn_Click(object sender, EventArgs e)
        {
            ClearInputsOnly();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            ClearInputsOnly();
        }

        private void senrRdbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading && senrRdbtn.Checked)
            {
                posFunctions.discountRate = 0.30;
                posFunctions.Compute(qtyTxtbox, priceTxtbox, discountTxtbox, discountedTxtbox);
            }
        }

        private void noTaxRdbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading && noTaxRdbtn.Checked)
            {
                posFunctions.discountRate = 0.00;
                posFunctions.Compute(qtyTxtbox, priceTxtbox, discountTxtbox, discountedTxtbox);
            }
        }

        private void EmployeeRdbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading && EmployeeRdbtn.Checked)
            {
                posFunctions.discountRate = 0.15;
                posFunctions.Compute(qtyTxtbox, priceTxtbox, discountTxtbox, discountedTxtbox);
            }
        }

        private void regularRdbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading && regularRdbtn.Checked)
            {
                posFunctions.discountRate = 0.10;
                posFunctions.Compute(qtyTxtbox, priceTxtbox, discountTxtbox, discountedTxtbox);
            }
        }

        private void button_Numpad_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                cash_renderedtxtbox.Text += btn.Text;
            }
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void qtyTxtbox_TextChanged(object sender, EventArgs e)
        {
            if (isLoading) return;

            if (posFunctions.ConvertQuantityPrice(qtyTxtbox, priceTxtbox))
            {
                posFunctions.Compute(qtyTxtbox, priceTxtbox, discountTxtbox, discountedTxtbox);

                changeTxtbox.Text = "";
                cash_renderedtxtbox.Text = "";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GenerateMenuFromHorizontalDB();
            ClearInputsOnly();
        }
    }
}