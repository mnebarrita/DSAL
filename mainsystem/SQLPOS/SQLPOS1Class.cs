using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using mainsystem.L14_Classes;

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

        private void SQLPOS1Class_Load(object sender, EventArgs e)
        {
            CenterPanel();
            this.Resize += (s, ev) => CenterPanel();
            isLoading = true;

            // Setup UI (Read-only textboxes)
            itemnameTxtbox.ReadOnly = true;
            priceTxtbox.ReadOnly = true;
            discountedTxtbox.ReadOnly = true;
            qtyTotalTxtbox.ReadOnly = true;
            discountTotalTxtbox.ReadOnly = true;
            discountedTotalTxtbox.ReadOnly = true;
            changeTxtbox.ReadOnly = true;
            discountTxtbox.ReadOnly = true;

            noTaxRdbtn.Checked = true;
            this.AcceptButton = enterBtn; // Ensures Enter key works if button1 is 'Compute'

            // GENERATE THE MENU DYNAMICALLY
            GenerateMenuFromHorizontalDB();

            isLoading = false;
            qtyTxtbox.Focus();
        }


        private void CenterPanel()
        {
            panelMain.Left = (this.ClientSize.Width - panelMain.Width) / 2;
            panelMain.Top = (this.ClientSize.Height - panelMain.Height) / 2;
        }

        private void GenerateMenuFromHorizontalDB()
        {
            try
            {
                pos_db.pos_connString();
                pos_db.posdb_open();

                // QUERY: Get the SINGLE ROW that contains all 20 items for POS ID 1
                pos_db.pos_sql = "SELECT * FROM pos_nameTb1 " +
                                 "INNER JOIN pos_picTb1 ON pos_nameTb1.pos_id = pos_picTb1.pos_id " +
                                 "INNER JOIN pos_priceTb1 ON pos_picTb1.pos_id = pos_priceTb1.pos_id " +
                                 "WHERE pos_nameTb1.pos_id = 2"; // CHANGE THIS TO '2' FOR CASHIER 2

                pos_db.pos_cmd();
                pos_db.pos_sqladapterSelect();

                pos_db.pos_sql_dataset = new DataSet();
                pos_db.pos_sql_dataadapter.Fill(pos_db.pos_sql_dataset, "MenuTable");

                // Clear the FlowLayoutPanel to avoid duplicates
                menuFlowPanel.Controls.Clear();

                if (pos_db.pos_sql_dataset.Tables["MenuTable"].Rows.Count > 0)
                {
                    DataRow row = pos_db.pos_sql_dataset.Tables["MenuTable"].Rows[0];

                    // Loop from 1 to 20 to read columns: name1, name2 ... name20
                    for (int i = 1; i <= 20; i++)
                    {
                        string nameCol = "name" + i;
                        string priceCol = "price" + i;
                        string picCol = "pic" + i;

                        // Check if the column exists and has data
                        if (row.Table.Columns.Contains(nameCol) && !string.IsNullOrEmpty(row[nameCol].ToString()))
                        {
                            string name = row[nameCol].ToString();
                            double price = 0;
                            double.TryParse(row[priceCol].ToString(), out price);
                            string imgPath = row[picCol].ToString();

                            // 1. Create Button
                            Button prodBtn = new Button();

                            // 2. SET SIZE & FONT (Big Mode!)
                            prodBtn.Width = 180;
                            prodBtn.Height = 180;
                            prodBtn.Font = new Font("MS UI Gothic", 10, FontStyle.Bold);

                            // 3. Set Text & Styling
                            prodBtn.Text = name + "\n" + price.ToString("N0");
                            prodBtn.TextAlign = ContentAlignment.BottomCenter;
                            prodBtn.ForeColor = Color.Black;
                            prodBtn.Tag = price;

                            // 4. Load Image
                            if (File.Exists(imgPath))
                            {
                                prodBtn.BackgroundImage = Image.FromFile(imgPath);
                                prodBtn.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                            else
                            {
                                prodBtn.BackColor = Color.LightGray;
                            }

                            // 5. Add Click Event
                            prodBtn.Click += (s, args) => SelectItem(name, price);

                            // 6. Add to the Panel
                            menuFlowPanel.Controls.Add(prodBtn);
                        }
                    }
                }
                pos_db.posdb_close();
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
            // 1. Check validity
            if (posFunctions.ConvertQuantityPrice(qtyTxtbox, priceTxtbox))
            {
                // 2. Compute the CURRENT item's discount/net price
                posFunctions.Compute(qtyTxtbox, priceTxtbox, discountTxtbox, discountedTxtbox);

                // 3. Cash Validation
                string cashText = cash_renderedtxtbox.Text.Replace(",", "");
                if (!double.TryParse(cashText, out double cash))
                {
                    MessageBox.Show("Please enter a valid cash amount.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 4. Calculate Change
                double change = cash - posFunctions.discounted_amt;
                if (change < 0)
                {
                    MessageBox.Show("Insufficient cash!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    changeTxtbox.Text = "0.00";
                    return; // Stop here so we don't add to totals if they can't pay!
                }

                changeTxtbox.Text = change.ToString("N2");

                // 5. UPDATE SUMMARY (Accumulate this sale into the Grand Totals)
                // This adds the current qty/discount to the running variables in your class
                posFunctions.UpdateTotals(qtyTotalTxtbox, discountTotalTxtbox, discountedTotalTxtbox);
            }
            else
            {
                MessageBox.Show("Invalid quantity or price.");
            }
        }

        private void enterBtn_Click(object sender, EventArgs e)
        {
            // 1. Validate: Ensure a valid calculation happened
            if (string.IsNullOrEmpty(changeTxtbox.Text))
            {
                MessageBox.Show("Please calculate the transaction first.");
                return;
            }

            try
            {
                pos_db.pos_connString();
                pos_db.posdb_open();

                // 2. Determine Discount Option String
                string discOption = "No Discount";
                if (senrRdbtn.Checked) discOption = "Senior Citizen";
                else if (regularRdbtn.Checked) discOption = "Discount Card";
                else if (EmployeeRdbtn.Checked) discOption = "Employee Disc";

                // 3. BUILD THE QUERY (Vertically Aligned for Safety)
                // I have lined up the Columns and Values 1-to-1 so you can see they match.
                string sql = "INSERT INTO salesTb1 (" +
                    "terminal_no, " +                        // 1
                    "product_name, " +                       // 2
                    "product_price, " +                      // 3
                    "product_quantity_per_transaction, " +   // 4
                    "discount_option, " +                    // 5
                    "discount_amount_per_transaction, " +    // 6
                    "discounted_amount_per_transaction, " +  // 7
                    "summary_total_quantity, " +             // 8
                    "summary_total_disc_given, " +           // 9
                    "summary_total_discounted_amount, " +    // 10
                    "time_date, " +                          // 11
                    "emp_id" +                               // 12
                    ") VALUES (" +
                    "'Terminal-1', " +                       // 1 (Value for terminal_no)
                    "'" + itemnameTxtbox.Text + "', " +      // 2 (Value for product_name)
                    "'" + priceTxtbox.Text + "', " +         // 3
                    "'" + qtyTxtbox.Text + "', " +           // 4
                    "'" + discOption + "', " +               // 5
                    "'" + discountTxtbox.Text + "', " +      // 6
                    "'" + discountedTxtbox.Text + "', " +    // 7
                    "'" + qtyTotalTxtbox.Text + "', " +      // 8
                    "'" + discountTotalTxtbox.Text + "', " + // 9
                    "'" + discountedTotalTxtbox.Text + "', " + // 10
                    "'" + DateTime.Now.ToString("yyyy-MM-dd") + "', " + // 11
                    "'1001'" +                               // 12
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
            noTaxRdbtn.Checked = true; // Default back to No Tax

            // NOTE: We do NOT clear qtyTotalTxtbox, discountTotalTxtbox, etc.
            // They will keep the running total of the session.

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
            // The 'isLoading' check prevents this event from firing when the form first opens.
            if (isLoading) return;

            // Check if the input is a valid number, and if an item is selected
            if (posFunctions.ConvertQuantityPrice(qtyTxtbox, priceTxtbox))
            {
                // Re-run the core computation using the existing discount rate (30%, 10%, or 0%)
                // The results update discountTxtbox and discountedTxtbox instantly.
                posFunctions.Compute(qtyTxtbox, priceTxtbox, discountTxtbox, discountedTxtbox);

                // Clear the cash/change boxes so the cashier knows to re-enter cash for the new total
                changeTxtbox.Text = "";
                cash_renderedtxtbox.Text = "";
            }
        }
    }
}