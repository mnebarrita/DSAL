// must accumulate the total number of units, total tuition fee, total misc fee, and total of all fees
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
    public partial class Quiz1 : Form
    {
        private int totalUnits = 0;
        private double totalTuition = 0;
        private double totalMisc = 0;
        private double totalAllFees = 0;

        public Quiz1()
        {
            InitializeComponent();
            
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

            // Disable computed textboxes
            txtCreditUnits.Enabled = false;
            txtTotalNumUnits.Enabled = false;
            txtTotalTuitionFee.Enabled = false;
            txtTotalMiscFee.Enabled = false;
            txtTotalOtherFee.Enabled = false;
            txtTotalTuitionandFee2.Enabled = false;
            txtCompLab2.Enabled = false;
            txtCiscoLab2.Enabled = false;
            txtExamBooklet2.Enabled = false;

            // Disable Textboxes in the User Input
            txtCreditUnits.ReadOnly = true;
            txtTotalTuitionandFee1.ReadOnly = true;
            txtTuitionFee.ReadOnly = true;
            txtMiscFee.ReadOnly = true;
            txtTotalUnits1.ReadOnly = true;


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
            txtTotalUnits1.Text = txtCreditUnits.Text;
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
                else if (c is ListBox)
                {
                    ((ListBox)c).Items.Clear();
                }
            }

            comboBox1.SelectedIndex = -1;
            pictureBox1.Image = null;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                // Get lecture + lab units
                int lecUnits = int.Parse(txtUnitLec.Text);
                int labUnits = int.Parse(txtUnitLab.Text);
                int creditUnits = lecUnits + labUnits;
                txtCreditUnits.Text = creditUnits.ToString();

                // Tuition fee = credit units × 1500
                double tuitionFee = creditUnits * 1500;
                txtTuitionFee.Text = tuitionFee.ToString("n");

                // Misc fee = comp lab + cisco lab + exam booklet
                double compLab = string.IsNullOrWhiteSpace(txtCompLab1.Text) ? 0 : double.Parse(txtCompLab1.Text);
                double ciscoLab = string.IsNullOrWhiteSpace(txtCiscoLab1.Text) ? 0 : double.Parse(txtCiscoLab1.Text);
                double examBooklet = string.IsNullOrWhiteSpace(txtExamBooklet1.Text) ? 0 : double.Parse(txtExamBooklet1.Text);
                double miscFee = compLab + ciscoLab + examBooklet;
                txtMiscFee.Text = miscFee.ToString("n");

                // Total tuition and fee for this entry
                double totalForThisSubject = tuitionFee + miscFee;
                txtTotalTuitionandFee1.Text = totalForThisSubject.ToString("n");

                // Accumulate totals
                totalUnits += creditUnits;
                totalTuition += tuitionFee;
                totalMisc += miscFee;
                totalAllFees += totalForThisSubject;

                // Update summary boxes
                txtTotalNumUnits.Text = totalUnits.ToString();
                txtTotalTuitionFee.Text = totalTuition.ToString("n");
                txtTotalMiscFee.Text = totalMisc.ToString("n");
                txtTotalOtherFee.Text = totalMisc.ToString("n");
                txtTotalTuitionandFee2.Text = totalAllFees.ToString("n");
                txtCompLab2.Text = txtCompLab1.Text;
                txtExamBooklet2.Text = txtExamBooklet1.Text;
                txtCiscoLab2.Text = txtCiscoLab1.Text;
                txtTotalTuitionandFee1.Text = txtTotalTuitionandFee2.Text;

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtCompLab2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTotalTuitionandFee1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtTotalTuitionandFee2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}


