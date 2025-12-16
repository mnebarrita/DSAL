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
        POS1_Functions posFunctions = new POS1_Functions();
        //private POSCalculator calculator = new POSCalculator();
        private bool isLoading = true;
        // Running totals
        private double qty_total = 0;
        private double discount_totalgiven = 0;
        private double discounted_total = 0;
        public POS1_ClassForm()
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
        private void SelectItem(string itemName, double price)
        {
            itemnameTxtbox.Text = itemName;
            priceTxtbox.Text = price.ToString("N0");
            qtyTxtbox.Text = "1";
            noTaxRdbtn.Checked = true;

            posFunctions.discountRate = 0.00;

            posFunctions.Compute(qtyTxtbox, priceTxtbox, discountTxtbox, discountedTxtbox);
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
            if (posFunctions.ConvertQuantityPrice(qtyTxtbox, priceTxtbox))
            {
                // --- Compute current discount + discounted amount ---
                posFunctions.Compute(qtyTxtbox, priceTxtbox, discountTxtbox, discountedTxtbox);

                // --- Cash Validation ---
                string cashText = cash_renderedtxtbox.Text.Replace(",", "");
                if (!double.TryParse(cashText, out double cash))
                {
                    MessageBox.Show("Please enter a valid cash amount.", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // --- Change Calculation ---
                double change = cash - posFunctions.discounted_amt;
                if (change < 0)
                {
                    MessageBox.Show("Insufficient cash!", "Warning",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    changeTxtbox.Text = "0.00";
                    return; // stop here — don’t update totals
                }

                changeTxtbox.Text = change.ToString("N2");

                // --- Update totals (including total discount given) ---
                posFunctions.UpdateTotals(qtyTotalTxtbox, discountTotalTxtbox, discountedTotalTxtbox);
            }
            else
            {
                MessageBox.Show("Invalid quantity or price.");
            }
        }

        private void senrRdbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (isLoading) return;

            if (senrRdbtn.Checked)
            {
                posFunctions.discountRate = 0.30; // Senior = 30%
                posFunctions.Compute(qtyTxtbox, priceTxtbox, discountTxtbox, discountedTxtbox);
            }
        }

        private void regularRdbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (isLoading) return;

            if (regularRdbtn.Checked)
            {
                posFunctions.discountRate = 0.10;
                posFunctions.Compute(qtyTxtbox, priceTxtbox, discountTxtbox, discountedTxtbox);
            }
        }

        private void EmployeeRdbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (isLoading) return;

            if (EmployeeRdbtn.Checked)
            {
                posFunctions.discountRate = 0.15;
                posFunctions.Compute(qtyTxtbox, priceTxtbox, discountTxtbox, discountedTxtbox);
            }
        }

        private void noTaxRdbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (isLoading) return;

            if (noTaxRdbtn.Checked)
            {
                posFunctions.discountRate = 0.00;
                posFunctions.Compute(qtyTxtbox, priceTxtbox, discountTxtbox, discountedTxtbox);
            }
        }

        private void changeTxtbox_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(changeTxtbox.Text.Replace(",", ""), out double val))
                changeTxtbox.Text = val.ToString("N2");
        }

        private void button1_Click(object sender, EventArgs e)
        {

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
