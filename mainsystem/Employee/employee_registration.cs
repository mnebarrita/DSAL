using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO; // <-- Add this using directive
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
            emp_db.employee_sql = "SELECT * FROM pos_empRegTb1";

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

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void ClearAllFields()
        {
            // --- Personal Information ---
            emp_id.Text = "";
            emp_fname.Text = "";
            emp_mname.Text = "";
            emp_surname.Text = "";

            // For ComboBoxes, clearing text is safe, or use SelectedIndex = -1
            emp_age.Text = "";
            emp_gender.Text = "";
            emp_status.Text = "";        // Civil Status

            // --- Government IDs ---
            emp_sss_no.Text = "";
            emp_tin_no.Text = "";
            emp_philhealth_no.Text = "";
            emp_pagibig_no.Text = "";

            // --- Physical Info ---
            emp_height.Text = "";
            emp_weight.Text = "";

            // --- Address Information ---
            add_yrs_stay.Text = "";
            add_house_no.Text = "";
            add_sub_name.Text = "";
            add_phase_no.Text = "";
            add_street.Text = "";
            add_barangay.Text = "";
            add_municipality.Text = "";
            add_city.Text = "";
            add_state_province.Text = "";
            add_country.Text = "";
            add_zipcode.Text = "";

            // --- Elementary ---
            elem_name.Text = "";
            elem_address.Text = "";
            elem_yr_grad.Value = DateTime.Now;
            elem_award.Text = "";

            // --- Junior High ---
            junior_high_name.Text = "";
            junior_high_address.Text = "";
            junior_high_yr_grad.Value = DateTime.Now;
            junior_high_award.Text = "";

            // --- Senior High & Track ---
            senior_high_name.Text = "";
            senior_high_address.Text = "";
            senior_high_yr_grad.Value = DateTime.Now;
            senior_high_award.Text = "";
            track.Text = "";

            // --- College ---
            college_school_name.Text = "";
            college_address.Text = "";
            college_yr_grad.Value = DateTime.Now;
            college_award.Text = "";
            college_course.Text = "";

            // --- Work & Other Info ---
            others.Text = "";
            position.Text = "";
            emp_work_status.Text = "";
            emp_date_hired.Value = DateTime.Now;
            emp_department.Text = "";
            emp_no_of_dependents.Text = "";

            // --- Image Section ---
            picpath.Text = "";
            pictureBox1.Image = Image.FromFile(@"C:\Users\Mica\Pictures\DSAL\pics\nopfp.jpg"); // Clears the actual image picture
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

        private void addBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Connect
                emp_db.employee_connString();

                // 2. SQL String
                // We skip 'name_id' because the database auto-generates it.
                string sql = "INSERT INTO pos_empRegTb1 (" +
                    "emp_id, emp_fname, emp_mname, emp_surname, emp_age, emp_gender, " +
                    "emp_sss_no, emp_tin_no, emp_philhealth_no, emp_pagibig_no, emp_status, " +
                    "emp_height, emp_weight, add_yrs_stay, add_house_no, add_sub_name, " +
                    "add_phase_no, add_street, add_barangay, add_municipality, add_city, " +
                    "add_state_province, add_country, add_zipcode, " +
                    "elem_name, elem_address, elem_yr_grad, elem_award, " +
                    "junior_high_name, junior_high_address, junior_high_yr_grad, junior_high_award, " +
                    "senior_high_name, senior_high_address, senior_high_yr_grad, senior_high_award, track, " +
                    "college_school_name, college_address, college_yr_grad, college_award, college_course, " +
                    "others, position, emp_work_status, emp_date_hired, emp_department, emp_no_of_dependents, picpath) " +
                    "VALUES ('" +
                    emp_id.Text + "', '" +                  
                    emp_fname.Text + "', '" +               
                    emp_mname.Text + "', '" +
                    emp_surname.Text + "', '" +
                    emp_age.Text + "', '" +                 
                    emp_gender.Text + "', '" +              
                                                            
                    emp_sss_no.Text + "', '" +
                    emp_tin_no.Text + "', '" +
                    emp_philhealth_no.Text + "', '" +
                    emp_pagibig_no.Text + "', '" +
                    emp_status.Text + "', '" +              // Civil Status
                                                            // Physical & Address
                    emp_height.Text + "', '" +
                    emp_weight.Text + "', '" +
                    add_yrs_stay.Text + "', '" +
                    add_house_no.Text + "', '" +
                    add_sub_name.Text + "', '" +
                    add_phase_no.Text + "', '" +
                    add_street.Text + "', '" +
                    add_barangay.Text + "', '" +
                    add_municipality.Text + "', '" +
                    add_city.Text + "', '" +
                    add_state_province.Text + "', '" +
                    add_country.Text + "', '" +
                    add_zipcode.Text + "', '" +
                    // Elementary
                    elem_name.Text + "', '" +
                    elem_address.Text + "', '" +
                    elem_yr_grad.Value.ToString("yyyy-MM-dd") + "', '" +
                    elem_award.Text + "', '" +
                    // Junior High
                    junior_high_name.Text + "', '" +        
                    junior_high_address.Text + "', '" +
                    junior_high_yr_grad.Value.ToString("yyyy-MM-dd") + "', '" +
                    junior_high_award.Text + "', '" +
                    // Senior High & Track
                    senior_high_name.Text + "', '" +
                    senior_high_address.Text + "', '" +
                    senior_high_yr_grad.Value.ToString("yyyy-MM-dd") + "', '" +
                    senior_high_award.Text + "', '" +
                    track.Text + "', '" +
                    // College
                    college_school_name.Text + "', '" +
                    college_address.Text + "', '" +
                    college_yr_grad.Value.ToString("yyyy-MM-dd") + "', '" +
                    college_award.Text + "', '" +
                    college_course.Text + "', '" +
                    // Work Info
                    others.Text + "', '" +
                    position.Text + "', '" +
                    emp_work_status.Text + "', '" +
                    emp_date_hired.Value.ToString("yyyy-MM-dd") + "', '" +
                    emp_department.Text + "', '" +
                    emp_no_of_dependents.Text + "', '" +
                    // Image Path
                    picpath.Text.Replace("\\", "\\\\") + "')";

                emp_db.employee_sql = sql;

                // 3. Create Command & Execute
                emp_db.employee_cmd();
                emp_db.employee_sqladapterInsert();

                // Close connection
                if (emp_db.employee_sql_connection.State == ConnectionState.Open)
                {
                    emp_db.employee_sql_connection.Close();
                }

                MessageBox.Show("Record Added Successfully!");
                RefreshGrid();
                ClearAllFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Adding Record: " + ex.Message);
            }
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Connect
                emp_db.employee_connString();

                // 2. Search Query (Using the 'emp_id' textbox to find the match)
                emp_db.employee_sql = "SELECT * FROM pos_empRegTb1 WHERE emp_id = '" + emp_id.Text + "'";

                // 3. Execute Search
                emp_db.employee_cmd();
                emp_db.employee_sqladapterSelect();
                emp_db.employee_sqldatasetSELECT();

                // 4. Check if we found a record
                if (emp_db.employee_sql_dataset.Tables[0].Rows.Count > 0)
                {
                    DataRow row = emp_db.employee_sql_dataset.Tables[0].Rows[0];

                    // --- Personal Info ---
                    // Note: We skip 'emp_id' since that's what we searched for
                    emp_fname.Text = row["emp_fname"].ToString();
                    emp_mname.Text = row["emp_mname"].ToString();
                    emp_surname.Text = row["emp_surname"].ToString();
                    emp_age.Text = row["emp_age"].ToString();
                    emp_gender.Text = row["emp_gender"].ToString();
                    emp_status.Text = row["emp_status"].ToString();

                    // --- Government IDs ---
                    emp_sss_no.Text = row["emp_sss_no"].ToString();
                    emp_tin_no.Text = row["emp_tin_no"].ToString();
                    emp_philhealth_no.Text = row["emp_philhealth_no"].ToString();
                    emp_pagibig_no.Text = row["emp_pagibig_no"].ToString();

                    // --- Physical ---
                    emp_height.Text = row["emp_height"].ToString();
                    emp_weight.Text = row["emp_weight"].ToString();

                    // --- Address ---
                    add_yrs_stay.Text = row["add_yrs_stay"].ToString();
                    add_house_no.Text = row["add_house_no"].ToString();
                    add_sub_name.Text = row["add_sub_name"].ToString();
                    add_phase_no.Text = row["add_phase_no"].ToString();
                    add_street.Text = row["add_street"].ToString();
                    add_barangay.Text = row["add_barangay"].ToString();
                    add_municipality.Text = row["add_municipality"].ToString();
                    add_city.Text = row["add_city"].ToString();
                    add_state_province.Text = row["add_state_province"].ToString();
                    add_country.Text = row["add_country"].ToString();
                    add_zipcode.Text = row["add_zipcode"].ToString();

                    // --- Elementary ---
                    elem_name.Text = row["elem_name"].ToString();
                    elem_address.Text = row["elem_address"].ToString();
                    if (row["elem_yr_grad"].ToString() != "")
                        elem_yr_grad.Value = Convert.ToDateTime(row["elem_yr_grad"]);
                    elem_award.Text = row["elem_award"].ToString();

                    // --- Junior High ---
                    junior_high_name.Text = row["junior_high_name"].ToString();
                    junior_high_address.Text = row["junior_high_address"].ToString();
                    if (row["junior_high_yr_grad"].ToString() != "")
                        junior_high_yr_grad.Value = Convert.ToDateTime(row["junior_high_yr_grad"]);
                    junior_high_award.Text = row["junior_high_award"].ToString();

                    // --- Senior High ---
                    senior_high_name.Text = row["senior_high_name"].ToString();
                    senior_high_address.Text = row["senior_high_address"].ToString();
                    if (row["senior_high_yr_grad"].ToString() != "")
                        senior_high_yr_grad.Value = Convert.ToDateTime(row["senior_high_yr_grad"]);
                    senior_high_award.Text = row["senior_high_award"].ToString();
                    track.Text = row["track"].ToString();

                    // --- College ---
                    college_school_name.Text = row["college_school_name"].ToString();
                    college_address.Text = row["college_address"].ToString();
                    if (row["college_yr_grad"].ToString() != "")
                        college_yr_grad.Value = Convert.ToDateTime(row["college_yr_grad"]);
                    college_award.Text = row["college_award"].ToString();
                    college_course.Text = row["college_course"].ToString();

                    // --- Work Info ---
                    others.Text = row["others"].ToString();
                    position.Text = row["position"].ToString();
                    emp_work_status.Text = row["emp_work_status"].ToString();
                    if (row["emp_date_hired"].ToString() != "")
                        emp_date_hired.Value = Convert.ToDateTime(row["emp_date_hired"]);
                    emp_department.Text = row["emp_department"].ToString();
                    emp_no_of_dependents.Text = row["emp_no_of_dependents"].ToString();

                    // --- Image Handling ---
                    string imgPath = row["picpath"].ToString();
                    picpath.Text = imgPath; // Put path string back in box

                    if (File.Exists(imgPath))
                    {
                        pictureBox1.Image = Image.FromFile(imgPath);
                    }
                    else
                    {
                        pictureBox1.Image = null; // Clear image if file is missing
                    }
                }
                else
                {
                    MessageBox.Show("Employee ID not found.");
                }

                // 5. Close Connection
                if (emp_db.employee_sql_connection.State == ConnectionState.Open)
                {
                    emp_db.employee_sql_connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Search Error: " + ex.Message);
            }
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Connect
                emp_db.employee_connString();

                // 2. The MASSIVE Update Query
                // This now includes Address, Education, Awards, EVERYTHING.
                string sql = "UPDATE pos_empRegTb1 SET " +
                    "emp_fname = '" + emp_fname.Text + "', " +
                    "emp_mname = '" + emp_mname.Text + "', " +
                    "emp_surname = '" + emp_surname.Text + "', " +
                    "emp_age = '" + emp_age.Text + "', " +
                    "emp_gender = '" + emp_gender.Text + "', " +
                    "emp_status = '" + emp_status.Text + "', " +

                    // Govt IDs
                    "emp_sss_no = '" + emp_sss_no.Text + "', " +
                    "emp_tin_no = '" + emp_tin_no.Text + "', " +
                    "emp_philhealth_no = '" + emp_philhealth_no.Text + "', " +
                    "emp_pagibig_no = '" + emp_pagibig_no.Text + "', " +

                    // Physical & Address
                    "emp_height = '" + emp_height.Text + "', " +
                    "emp_weight = '" + emp_weight.Text + "', " +
                    "add_yrs_stay = '" + add_yrs_stay.Text + "', " +
                    "add_house_no = '" + add_house_no.Text + "', " +
                    "add_sub_name = '" + add_sub_name.Text + "', " +
                    "add_phase_no = '" + add_phase_no.Text + "', " +
                    "add_street = '" + add_street.Text + "', " +
                    "add_barangay = '" + add_barangay.Text + "', " +
                    "add_municipality = '" + add_municipality.Text + "', " +
                    "add_city = '" + add_city.Text + "', " +
                    "add_state_province = '" + add_state_province.Text + "', " +
                    "add_country = '" + add_country.Text + "', " +
                    "add_zipcode = '" + add_zipcode.Text + "', " +

                    // Elementary
                    "elem_name = '" + elem_name.Text + "', " +
                    "elem_address = '" + elem_address.Text + "', " +
                    "elem_yr_grad = '" + elem_yr_grad.Value.ToString("yyyy-MM-dd") + "', " +
                    "elem_award = '" + elem_award.Text + "', " +

                    // Junior High
                    "junior_high_name = '" + junior_high_name.Text + "', " +
                    "junior_high_address = '" + junior_high_address.Text + "', " +
                    "junior_high_yr_grad = '" + junior_high_yr_grad.Value.ToString("yyyy-MM-dd") + "', " +
                    "junior_high_award = '" + junior_high_award.Text + "', " +

                    // Senior High & Track
                    "senior_high_name = '" + senior_high_name.Text + "', " +
                    "senior_high_address = '" + senior_high_address.Text + "', " +
                    "senior_high_yr_grad = '" + senior_high_yr_grad.Value.ToString("yyyy-MM-dd") + "', " +
                    "senior_high_award = '" + senior_high_award.Text + "', " +
                    "track = '" + track.Text + "', " +

                    // College
                    "college_school_name = '" + college_school_name.Text + "', " +
                    "college_address = '" + college_address.Text + "', " +
                    "college_yr_grad = '" + college_yr_grad.Value.ToString("yyyy-MM-dd") + "', " +
                    "college_award = '" + college_award.Text + "', " +
                    "college_course = '" + college_course.Text + "', " +

                    // Work Info
                    "others = '" + others.Text + "', " +
                    "position = '" + position.Text + "', " +
                    "emp_work_status = '" + emp_work_status.Text + "', " +
                    "emp_date_hired = '" + emp_date_hired.Value.ToString("yyyy-MM-dd") + "', " +
                    "emp_department = '" + emp_department.Text + "', " +
                    "emp_no_of_dependents = '" + emp_no_of_dependents.Text + "', " +

                    // Image
                    "picpath = '" + picpath.Text.Replace("\\", "\\\\") + "' " +

                    "WHERE emp_id = '" + emp_id.Text + "'";

                emp_db.employee_sql = sql;
                emp_db.employee_cmd();

                // Execute Update
                // Note: Using Insert/Update/Delete adapter usually works the same if they just run ExecuteNonQuery
                emp_db.employee_sqladapterInsert();

                if (emp_db.employee_sql_connection.State == ConnectionState.Open)
                    emp_db.employee_sql_connection.Close();

                MessageBox.Show("Record Updated Successfully!");
                RefreshGrid();
                ClearAllFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update Error: " + ex.Message);
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    emp_db.employee_connString();

                    // SQL Delete Command
                    string sql = "DELETE FROM pos_empRegTb1 WHERE emp_id = '" + emp_id.Text + "'";
                    emp_db.employee_sql = sql;

                    emp_db.employee_cmd();
                    emp_db.employee_sqladapterInsert(); // ExecuteNonQuery

                    if (emp_db.employee_sql_connection.State == ConnectionState.Open)
                        emp_db.employee_sql_connection.Close();

                    MessageBox.Show("Record Deleted Successfully.");
                    RefreshGrid();   // Update the table
                    ClearAllFields(); // Clear the textboxes
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Delete Error: " + ex.Message);
            }
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to close?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void newBtn_Click(object sender, EventArgs e)
        {
            ClearAllFields();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            ClearAllFields();
        }
    }

}
