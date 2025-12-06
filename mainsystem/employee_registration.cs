using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using mainsystem.L14_Classes;

namespace mainsystem
{
    public partial class employee_registration : Form
    {
        employee_dbconnection emp_db = new employee_dbconnection();
        public employee_registration()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Center panel (UI logic) ---
            CenterPanel();
            this.Resize += (s, ev) => CenterPanel();

            try
            {
                picpath.Visible = false;
                RefreshGrid(); // Load data into the table
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Loading System: " + ex.Message);
            }
        }

        private void CenterPanel()
        {
            panelMain.Left = (this.ClientSize.Width - panelMain.Width) / 2;
            panelMain.Top = (this.ClientSize.Height - panelMain.Height) / 2;
        }

        private void RefreshGrid()
        {
            // Connect (auto-opens)
            emp_db.employee_connString();

            // Set Query
            emp_db.employee_sql = "SELECT * FROM pos_empRegTbl";

            // Create Command
            emp_db.employee_cmd();

            // Execute Select
            emp_db.employee_sqladapterSelect();
            emp_db.employee_sqldatasetSELECT();

            // Bind to Grid
            if (emp_db.employee_sql_dataset.Tables.Count > 0)
            {
                dataGridView1.DataSource = emp_db.employee_sql_dataset.Tables[0];
            }

            // Close
            if (emp_db.employee_sql_connection.State == ConnectionState.Open)
                emp_db.employee_sql_connection.Close();
        }

        private void browseBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                picpath.Text = openFileDialog1.FileName;
            }
        }
    }
}
