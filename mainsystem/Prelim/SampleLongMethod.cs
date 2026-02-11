using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mainsystem
{
    public partial class SampleLongMethod : Form
    {
        String picpath;
        SqlConnection connection;
        SqlCommand command;
        DataSet dset;
        SqlDataAdapter adapter;
        string sql = null;

        String connectionString = "Data Source=MICACHU\\SQLEXPRESS; Initial Catalog=SampleDatabaseDb; User ID=Micachu; Password=morats;";

        public SampleLongMethod()
        {
            InitializeComponent();
            connection = new SqlConnection(connectionString);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Select an Image";
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    PictureBox clickedBox = (PictureBox)sender; // Get the clicked picturebox
                    clickedBox.Image = Image.FromFile(ofd.FileName);
                    picturepathTxtBox.Text = ofd.FileName;
                }
            }
        }

        private void LoadDataGrid()
        {
            sql = "SELECT * FROM studentTb1";
            adapter = new SqlDataAdapter(sql, connection);
            dset = new DataSet();
            adapter.Fill(dset, "studentTb1");
            griddisplay.DataSource = dset.Tables[0];
        }

        private void ClearFields()
        {
            studentNameTxtBox.Clear();
            studentNumTxtBox.Clear();
            departmentTxtBox.Clear();
            picturepathTxtBox.Clear();
            pictureBox1.Image = null;
        }

        private void SampleLongMethod_Load(object sender, EventArgs e)
        {
            CenterPanel();
            this.Resize += (s, ev) => CenterPanel(); // recenter when form resizes
            LoadDataGrid();
        }

        private void CenterPanel()
        {
            panel1.Left = (this.ClientSize.Width - panel1.Width) / 2;
            panel1.Top = (this.ClientSize.Height - panel1.Height) / 2;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                sql = "INSERT INTO studentTb1 (student_id, student_name, department, picpath) VALUES (@id, @name, @dept, @path)";
                command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", studentNumTxtBox.Text);
                command.Parameters.AddWithValue("@name", studentNameTxtBox.Text);
                command.Parameters.AddWithValue("@dept", departmentTxtBox.Text);
                command.Parameters.AddWithValue("@path", picturepathTxtBox.Text);
                command.ExecuteNonQuery();

                LoadDataGrid();
                ClearFields();

                MessageBox.Show("Record saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving record: " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open) connection.Close();
            }
        }

        private void Search_Click(object sender, EventArgs e)
        {
            connection.Open();
            sql = "SELECT * FROM studentTb1 WHERE student_id = @id";
            command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@id", studentNumTxtBox.Text);

            adapter = new SqlDataAdapter(command);
            dset = new DataSet();
            adapter.Fill(dset, "studentTb1");

            if (dset.Tables[0].Rows.Count > 0)
            {
                griddisplay.DataSource = dset.Tables[0];
                studentNameTxtBox.Text = dset.Tables[0].Rows[0]["student_name"].ToString();
                departmentTxtBox.Text = dset.Tables[0].Rows[0]["department"].ToString();
                picturepathTxtBox.Text = dset.Tables[0].Rows[0]["picpath"].ToString();

                if (System.IO.File.Exists(picturepathTxtBox.Text))
                {
                    pictureBox1.Image = Image.FromFile(picturepathTxtBox.Text);
                }
            }
            else
            {
                MessageBox.Show("No student found.");
            }
            connection.Close();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Delete this student?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                connection.Open();
                sql = "DELETE FROM studentTb1 WHERE student_id = @id";
                command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", studentNumTxtBox.Text);
                command.ExecuteNonQuery();

                // Refresh grid
                LoadDataGrid();

                connection.Close();
                MessageBox.Show("Record deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(studentNumTxtBox.Text))
            {
                MessageBox.Show("Please enter the Student ID to edit.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                connection.Open();

                if (string.IsNullOrEmpty(picturepathTxtBox.Text))
                {
                    MessageBox.Show("Please select a valid picture path before continuing.");
                    return;
                }

                string path_to_update = picturepathTxtBox.Text;

                // Secure Parameterized SQL UPDATE statement: update all fields for a given student_id
                sql = "UPDATE studentTb1 SET student_name = @name, department = @dept, picpath = @path WHERE student_id = @id";
                command = new SqlCommand(sql, connection);
                command.CommandType = CommandType.Text;

                // Set parameters for the fields being updated
                command.Parameters.AddWithValue("@name", studentNameTxtBox.Text);
                command.Parameters.AddWithValue("@dept", departmentTxtBox.Text);
                command.Parameters.AddWithValue("@path", path_to_update);
                command.Parameters.AddWithValue("@id", studentNumTxtBox.Text);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Record updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataGrid();
                    ClearFields();
                    //SetDefaultImage();
                }
                else
                {
                    MessageBox.Show($"No record found with ID: {studentNumTxtBox.Text} to update.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating data: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open) connection.Close();
            }
        }

        private void New_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Select an Image";
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    PictureBox clickedBox = (PictureBox)sender;
                    clickedBox.Image = Image.FromFile(ofd.FileName);
                    picturepathTxtBox.Text = ofd.FileName;
                }
            }
        }


        private void Cancel_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    }
