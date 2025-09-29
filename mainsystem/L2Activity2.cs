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
    public partial class L2Activity2 : Form
    {
        public L2Activity2()
        {
            InitializeComponent();
            // This is the correct place to add items to the ComboBox.
            // It runs once when the form is created.
            comboBox1.Items.AddRange(new object[]
            {
            "Computer Engineering",
            "Mechanical Engineering",
            "Industrial Engineering",
            "Electronics Communications Engineering",
            "Civil Engineering"
            });

            // This makes the ComboBox appear empty at the start.
            comboBox1.SelectedIndex = -1;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(ofd.FileName);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(txtCourseNumber.Text);
            listBox2.Items.Add(txtCourseCode.Text);
            listBox3.Items.Add(txtCourseDesc.Text);
            listBox4.Items.Add(txtUnitLec.Text);
            listBox5.Items.Add(txtUnitLab.Text);
            listBox6.Items.Add(txtCreditUnits.Text);
            listBox7.Items.Add(txtTime.Text);
            listBox8.Items.Add(txtDay.Text);

            // Example: also update totals (if you have summary textboxes)
            txtTotalUnits.Text = txtCreditUnits.Text;
            txtTotalTuitionFee.Text = txtTuitionFee.Text;
            txtMiscFee.Text = txtTotalMiscFee.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Clear();
                }
            }
            comboBox1.SelectedIndex = -1; 
            pictureBox1.Image = null;          
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}


