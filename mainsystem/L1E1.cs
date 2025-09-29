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
    public partial class Activity1 : Form
    {
        public Activity1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            itemnameTxtbox.Text = "Kuronami Bundle";
            priceTextbox.Text = "9,500 VP";
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            itemnameTxtbox.Text = "Prelude to Chaos";
            priceTextbox.Text = "8,700 VP";
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            itemnameTxtbox.Text = "Protocol 781-A";
            priceTextbox.Text = "9,900 VP";
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            itemnameTxtbox.Text = "Radiant Entertainment System";
            priceTextbox.Text = "11,900 VP";
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            itemnameTxtbox.Text = "Elderflame";
            priceTextbox.Text = "9,900 VP";
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            itemnameTxtbox.Text = "Zedd X Valorant SPECTRUM";
            priceTextbox.Text = "10,700 VP";
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            itemnameTxtbox.Text = "Evori Dreamwings";
            priceTextbox.Text = "9,900 VP";
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            itemnameTxtbox.Text = "Primordium";
            priceTextbox.Text = "8,700 VP";
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            itemnameTxtbox.Text = "Nocturnum";
            priceTextbox.Text = "8,700 VP";
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            itemnameTxtbox.Text = "Doombringer";
            priceTextbox.Text = "8,700 VP";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            itemnameTxtbox.Text = "RGX 11z Pro";
            priceTextbox.Text = "6,700 VP";
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            itemnameTxtbox.Text = "SplashX";
            priceTextbox.Text = "6,700 VP";
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            itemnameTxtbox.Text = "Mystbloom";
            priceTextbox.Text = "8,700 VP";
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            itemnameTxtbox.Text = "EX.O Collection";
            priceTextbox.Text = "9,500 VP";
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            itemnameTxtbox.Text = "Glitchpop";
            priceTextbox.Text = "8,700 VP";
        }

        private void newBtn_Click(object sender, EventArgs e)
        {
            itemnameTxtbox.Clear();
            priceTextbox.Clear();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Activity1_Load(object sender, EventArgs e)
        {

        }
    }
}
