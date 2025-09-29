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
    public partial class Activity2 : Form
    {
        public Activity2()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void Activity2_Load(object sender, EventArgs e)
        {
            // Codes for disabling the textboxes
            itemnametxtbox.Enabled = false;
            pricetxtbox.Enabled = false;
            quantitytxtbox.Enabled = false;
            discounttxtbox.Enabled = false;
            discountedtxtbox.Enabled = false;
            qty_totaltxtbox.Enabled = false;
            discountedtotaltxtbox.Enabled = false;
            discounttotaltxtbox.Enabled = false;

            // Codes for inserting pictures or image
            pictureBox16.Image = Image.FromFile(@"C:\Users\Mica\source\repos\DSAL\mainsystem\Images\RGX.jpg");
            pictureBox17.Image = Image.FromFile(@"C:\Users\Mica\source\repos\DSAL\mainsystem\Images\glitchpop.jpg");
            pictureBox18.Image = Image.FromFile(@"C:\Users\Mica\source\repos\DSAL\mainsystem\Images\EX-O-Valorant-skins-1024x576.jpg");
            pictureBox19.Image = Image.FromFile(@"C:\Users\Mica\source\repos\DSAL\mainsystem\Images\Mystbloom-Valorant-1024x576.jpg");
            pictureBox20.Image = Image.FromFile(@"C:\Users\Mica\source\repos\DSAL\mainsystem\Images\splashx-valorant-skins-1024x576.jpg");

            // codes for inserting name of the image inside the label tool
            // Row 1
            label3.Text = "Radiant Crisis";
            label13.Text = "Prime";
            label14.Text = "ION";
            label15.Text = "Gaia";

            // Row 2
            label16.Text = "Sentinels of Light";
            label17.Text = "Prelude to Chaos";
            label18.Text = "Protocol 781-A";
            label19.Text = "RES";

            // Row 3
            label20.Text = "Elderflame";
            label21.Text = "SPECTRUM";
            label22.Text = "Evori Dreamwings";
            label23.Text = "Primordium";

            // Row 4
            label25.Text = "Nocturnum";
            label26.Text = "Kuronami";
            label28.Text = "Doombringer";
            label29.Text = "RGX 11z Pro";

            // Row 5 
            label30.Text = "Glitchpop";
            label31.Text = "EX.O Collection";
            label32.Text = "Mystbloom";
            label33.Text = "SplashX";
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {

        }
    }
}
