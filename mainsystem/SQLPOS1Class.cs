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
        SQLPOS1CClass dataAccess = new SQLPOS1CClass();

        //private POSCalculator calculator = new POSCalculator();
        private bool isLoading = true;

        // Running totals
        private double qty_total = 0;
        private double discount_totalgiven = 0;
        private double discounted_total = 0;
        public SQLPOS1Class()
        {
            InitializeComponent();
        }

        private void SQLPOS1Class_Load(object sender, EventArgs e)
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

            //this.AcceptButton = button1;

            isLoading = false;

            this.BackgroundImage = null;
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

            //posFunctions.discountRate = 0.00;

            //posFunctions.Compute(qtyTxtbox, priceTxtbox, discountTxtbox, discountedTxtbox);
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

        private void EXIT_Click(object sender, EventArgs e)
        {

        }

        private void CANCEL_Click(object sender, EventArgs e)
        {

        }

        private void NEW_Click(object sender, EventArgs e)
        {

        }

        private void CALCULATE_Click(object sender, EventArgs e)
        {

        }

        private void seniorRdbtn_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void regularRdbtn_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void employeeRdbtn_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void noTaxRdbtn_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
