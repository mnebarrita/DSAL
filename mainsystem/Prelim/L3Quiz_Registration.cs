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
        // Existing variables...
        private int totalUnits = 0;
        private double totalTuition = 0;
        private double totalMisc = 0;
        private double totalAllFees = 0;

        // --- ADD THESE NEW VARIABLES BELOW ---
        private double totalCompLab = 0;
        private double totalCiscoLab = 0;
        private double totalExamBooklet = 0;

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
            CenterPanel();
            this.Resize += (s, ev) => CenterPanel();
        }
        private void CenterPanel()
        {
            panelMain.Left = (this.ClientSize.Width - panelMain.Width) / 2;
            panelMain.Top = (this.ClientSize.Height - panelMain.Height) / 2;
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

            
            // Parse Main Fees
            int currentUnits = int.Parse(txtCreditUnits.Text);
            double currentTuition = double.Parse(txtTuitionFee.Text);
            double currentMisc = double.Parse(txtMiscFee.Text);
            double currentTotal = double.Parse(txtTotalTuitionandFee1.Text);

            // Parse Specific Lab Fees
            double currentCompLab = string.IsNullOrWhiteSpace(txtCompLab1.Text) ? 0 : double.Parse(txtCompLab1.Text);
            double currentCiscoLab = string.IsNullOrWhiteSpace(txtCiscoLab1.Text) ? 0 : double.Parse(txtCiscoLab1.Text);
            double currentExamBooklet = string.IsNullOrWhiteSpace(txtExamBooklet1.Text) ? 0 : double.Parse(txtExamBooklet1.Text);

            
            // 1. Add Main Totals
            totalUnits += currentUnits;
            totalTuition += currentTuition;
            totalMisc += currentMisc;
            totalAllFees += currentTotal;

            // 2. Add Specific Lab Totals
            totalCompLab += currentCompLab;
            totalCiscoLab += currentCiscoLab;
            totalExamBooklet += currentExamBooklet;

            
            // Update Main Summaries
            txtTotalNumUnits.Text = totalUnits.ToString();
            txtTotalTuitionFee.Text = totalTuition.ToString("n");
            txtTotalMiscFee.Text = totalMisc.ToString("n");
            txtTotalTuitionandFee2.Text = totalAllFees.ToString("n");

            // Update Specific Lab Summaries
            txtCompLab2.Text = totalCompLab.ToString("n");
            txtCiscoLab2.Text = totalCiscoLab.ToString("n");
            txtExamBooklet2.Text = totalExamBooklet.ToString("n");

            // Update "Total Other School Fees" (Usually same as Total Misc)
            txtTotalOtherFee.Text = totalMisc.ToString("n");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // --- 1. CLEAR THE INPUT TEXTBOXES ONLY ---
            // These textboxes are used for the data of the new subject
            txtCourseNumber.Clear();
            txtCourseCode.Clear();
            txtCourseDesc.Clear();
            txtUnitLec.Clear();
            txtUnitLab.Clear();
            txtTime.Clear();
            txtDay.Clear();

            // Clear the calculated fields for this subject
            txtCreditUnits.Clear();
            txtTuitionFee.Clear();
            txtMiscFee.Clear();
            txtTotalTuitionandFee1.Clear();

            // Clear the miscellaneous fee inputs for the next subject
            txtCompLab1.Clear();
            txtCiscoLab1.Clear();
            txtExamBooklet1.Clear();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //try
            {
                // 1. Calculate Credit Units
                int lecUnits = int.Parse(txtUnitLec.Text);
                int labUnits = int.Parse(txtUnitLab.Text);
                int creditUnits = lecUnits + labUnits;
                txtCreditUnits.Text = creditUnits.ToString(); // Display it only

                // 2. Calculate Tuition
                double tuitionFee = creditUnits * 1500;
                txtTuitionFee.Text = tuitionFee.ToString("n");

                // 3. Calculate Misc
                double compLab = string.IsNullOrWhiteSpace(txtCompLab1.Text) ? 0 : double.Parse(txtCompLab1.Text);
                double ciscoLab = string.IsNullOrWhiteSpace(txtCiscoLab1.Text) ? 0 : double.Parse(txtCiscoLab1.Text);
                double examBooklet = string.IsNullOrWhiteSpace(txtExamBooklet1.Text) ? 0 : double.Parse(txtExamBooklet1.Text);

                double miscFee = compLab + ciscoLab + examBooklet;
                txtMiscFee.Text = miscFee.ToString("n");

                // 4. Total for THIS subject only
                double totalForThisSubject = tuitionFee + miscFee;
                txtTotalTuitionandFee1.Text = totalForThisSubject.ToString("n");

                // DELETE THE ACCUMULATION CODE FROM HERE (totalUnits += ...)
                // We will move it to Button 2
            }
            
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Check your inputs!");
            //}
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}


