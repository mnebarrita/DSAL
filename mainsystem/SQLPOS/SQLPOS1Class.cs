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
    public partial class SQLPOS1Class : Form
    {
        #region Fields (Private variables and Class dependencies)

        // Class dependency/Helper class instance (using a private field naming convention)
        private POS1_Functions _posFunctions = new POS1_Functions();

        // Control Flags
        private bool _isLoading = true;

        // Running totals (If these are just for display, they may not need to be fields here 
        // if POS1_Functions handles the running totals. Otherwise, keep them private.)
        private double _qtyTotal = 0;
        private double _discountTotalGiven = 0;
        private double _discountedTotal = 0;

        #endregion

        public SQLPOS1Class()
        {
            InitializeComponent();
        }

        private void SQLPOS1Class_Load(object sender, EventArgs e)
        {
            // 1. Initial Setup
            _isLoading = true;
            CenterPanel();
            this.Resize += (s, ev) => CenterPanel(); // Re-center on resize

            // 2. Control Initialization
            InitializeTextBoxes();
            noTaxRdbtn.Checked = true; // Default radio button (no discount)
            this.AcceptButton = enter; // Set default Enter button

            /* 3. UI/Background
            this.BackgroundImage = Properties.Resources.POS1wallpaper;
            this.BackgroundImageLayout = ImageLayout.Stretch; */

            // 4. Final Focus and Cleanup
            qtyTxtbox.Focus();
            _isLoading = false;
        }
        private void InitializeTextBoxes()
        {
            // Codes for disabling textboxes (Display-only fields)
            itemnameTxtbox.ReadOnly = true;
            priceTxtbox.ReadOnly = true;
            discountedTxtbox.ReadOnly = true;
            qtyTotalTxtbox.ReadOnly = true;
            discountTotalTxtbox.ReadOnly = true;
            discountedTotalTxtbox.ReadOnly = true;
            changeTxtbox.ReadOnly = true;
            discountTxtbox.ReadOnly = true;
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

            // Reset discount
            noTaxRdbtn.Checked = true;
            _posFunctions.discountRate = 0.00;

            _posFunctions.Compute(qtyTxtbox, priceTxtbox, discountTxtbox, discountedTxtbox);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {

        }

        // --- Transaction Processing ---

        private void CALCULATE_Click(object sender, EventArgs e)
        {
            if (!_posFunctions.ConvertQuantityPrice(qtyTxtbox, priceTxtbox))
            {
                MessageBox.Show("Invalid quantity or price.");
                return;
            }

            // 1. Compute current discount + discounted amount
            _posFunctions.Compute(qtyTxtbox, priceTxtbox, discountTxtbox, discountedTxtbox);

            // 2. Cash Validation
            string cashText = cash_renderedtxtbox.Text.Replace(",", "");
            if (!double.TryParse(cashText, out double cash))
            {
                MessageBox.Show("Please enter a valid cash amount.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 3. Change Calculation
            double change = cash - _posFunctions.discounted_amt;
            if (change < 0)
            {
                MessageBox.Show("Insufficient cash!", "Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                changeTxtbox.Text = "0.00";
                return;
            }

            changeTxtbox.Text = change.ToString("N2");

            // 4. Update totals (This assumes UpdateTotals updates the total textboxes)
            _posFunctions.UpdateTotals(qtyTotalTxtbox, discountTotalTxtbox, discountedTotalTxtbox);
        }

        // --- Clear/Cancel Buttons ---

        private void ClearItemInputs()
        {
            itemnameTxtbox.Text = "";
            qtyTxtbox.Text = "";
            priceTxtbox.Text = "";
            discountTxtbox.Text = "";
            discountedTxtbox.Text = "";
            cash_renderedtxtbox.Text = "";
            changeTxtbox.Text = "";

            // Uncheck all discounts
            seniorRdbtn.Checked = false;
            regularRdbtn.Checked = false;
            employeeRdbtn.Checked = false;
            noTaxRdbtn.Checked = false;

            qtyTxtbox.Focus();
        }

        private void CANCEL_Click(object sender, EventArgs e)
        {
            ClearItemInputs();
        }

        private void NEW_Click(object sender, EventArgs e)
        {
            ClearItemInputs();
        }

        private void seniorRdbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (_isLoading || !seniorRdbtn.Checked) return;
            _posFunctions.discountRate = 0.30; // Senior = 30%
            _posFunctions.Compute(qtyTxtbox, priceTxtbox, discountTxtbox, discountedTxtbox);
        }

        private void regularRdbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (_isLoading || !regularRdbtn.Checked) return;
            _posFunctions.discountRate = 0.10;
            _posFunctions.Compute(qtyTxtbox, priceTxtbox, discountTxtbox, discountedTxtbox);
        }

        private void employeeRdbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (_isLoading || !employeeRdbtn.Checked) return;
            _posFunctions.discountRate = 0.15;
            _posFunctions.Compute(qtyTxtbox, priceTxtbox, discountTxtbox, discountedTxtbox);
        }

        private void noTaxRdbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (_isLoading || !noTaxRdbtn.Checked) return;
            _posFunctions.discountRate = 0.00;
            _posFunctions.Compute(qtyTxtbox, priceTxtbox, discountTxtbox, discountedTxtbox);
        }

        private void changeTxtbox_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(changeTxtbox.Text.Replace(",", ""), out double val))
                changeTxtbox.Text = val.ToString("N2");
        }

        private void cash_renderedtxtbox_TextChanged(object sender, EventArgs e)
        {
            changeTxtbox.Text = "";
        }

        private void Keypad_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                // Append the button's text (digit or decimal) to the cash field
                cash_renderedtxtbox.Text += btn.Text;
            }
        }

        private void EXIT_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}