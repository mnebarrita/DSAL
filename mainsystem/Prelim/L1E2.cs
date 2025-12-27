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

namespace mainsystem
{

    public partial class Activity2 : Form
    {
        private bool isLoading = true;
        public Activity2()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void Activity2_Load(object sender, EventArgs e)
        {
            CenterPanel();
            this.Resize += (s, ev) => CenterPanel();

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
            pictureBox16.Image = Properties.Resources.RGX;
            pictureBox17.Image = Properties.Resources.glitchpop;
            pictureBox18.Image = Properties.Resources.EX_O_Valorant_skins_1024x576;
            pictureBox19.Image = Properties.Resources.Mystbloom_Valorant_1024x576;
            pictureBox20.Image = Properties.Resources.splashx_valorant_skins_1024x576;

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

        private void CenterPanel()
        {
            panel1.Left = (this.ClientSize.Width - panel1.Width) / 2;
            panel1.Top = (this.ClientSize.Height - panel1.Height) / 2;
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
