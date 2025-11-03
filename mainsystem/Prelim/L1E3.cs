using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace mainsystem
{
    public partial class Activity3 : Form
    {
        public Activity3()
        {
            InitializeComponent();
        }

        private void Activity3_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.LightGoldenrodYellow;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            // change form background
            this.BackColor = Color.LightCyan;

            // unselect Food Bundle B
            foodBRdbt.Checked = false;

            // insert image in PictureBox
            DisplayPictureBox.Image = System.Drawing.Image.FromFile(@"C:\Users\Mica\source\repos\DSAL\mainsystem\Images\FoodBundleA.jpeg");

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
            discountTxtbox.Text = "(20% of the Price) P200.00";

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void foodBRdbt_CheckedChanged(object sender, EventArgs e)
        {
            // change form background
            this.BackColor = Color.LightBlue;

            // unselect Food Bundle A
            foodARdbt.Checked = false;

            // insert image in PictureBox
            DisplayPictureBox.Image = System.Drawing.Image.FromFile(@"C:\Users\Mica\source\repos\DSAL\mainsystem\Images\FoodBundleB.jpg");

            // uncheck bundle A checkboxes
            A_CokeCheckBox.Checked = false;
            A_FriedChickencheckBox.Checked = false;
            A_FriescheckBox.Checked = false;
            A_sideDishCheckbox.Checked = false;
            A_SpecialPizaCheckbox.Checked = false;

            // check bundle B checkboxes
            B_carbonaracheckBox.Checked = true;
            B_ChickencheckBox.Checked = true;
            B_FriescheckBox.Checked = true;
            B_halohalocheckBox.Checked = true;
            B_HawaiiancheckBox.Checked = true;

            // display data in textboxes
            priceTxtBox.Text = "P1,299.00";
            discountTxtbox.Text = "(15% of the Price) P194.85";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // unselect radiobuttons
            foodARdbt.Checked = false;
            foodBRdbt.Checked = false;

            // insert default image
            DisplayPictureBox.Image = System.Drawing.Image.FromFile(@"C:\Users\Mica\Downloads\dsal\clear.png");

            // uncheck all checkboxes
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

            // clear textboxes
            priceTxtBox.Clear();
            discountTxtbox.Clear();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}
