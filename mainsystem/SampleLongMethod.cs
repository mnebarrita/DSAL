using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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

        private void SampleLongMethod_Load(object sender, EventArgs e)
        {

        }

        private void Save_Click(object sender, EventArgs e)
        {
            connection.Open();
            sql = "INSERT INTO studentTb1 (student_id, student_name, department, picpath) " +
    "VALUES ('" + studentNumTxtBox.Text + "','" + studentNameTxtBox.Text + "','"
    + departmentTxtBox.Text + "','" + picturepathTxtBox.Text + "')";
            command = new SqlCommand(sql, connection);
            command.CommandType = CommandType.Text;

            adapter = new SqlDataAdapter(command);
            adapter.InsertCommand = command;
            command.ExecuteNonQuery();

            sql = "SELECT * FROM studentTb1";
            command = new SqlCommand(sql, connection);
            command.CommandType = CommandType.Text;

            adapter = new SqlDataAdapter(command);
            adapter.SelectCommand = command;
            command.ExecuteNonQuery();

            dset = new DataSet();
            adapter.Fill(dset, "studentTb1");

            griddisplay.DataSource = dset.Tables[0];
            pictureBox1.Image = Image.FromFile(@"C:\Users\Mica\Downloads\me whwn im omw.jpg");
            studentNameTxtBox.Clear();
            studentNumTxtBox.Clear();
            departmentTxtBox.Clear();
            picturepathTxtBox.Clear();

            connection.Close();
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
                sql = "SELECT * FROM studentTb1";
                adapter = new SqlDataAdapter(sql, connection);
                dset = new DataSet();
                adapter.Fill(dset, "studentTb1");
                griddisplay.DataSource = dset.Tables[0];

                connection.Close();
            }


        }

        private void Edit_Click(object sender, EventArgs e)
        {
            connection.Open();
            sql = "UPDATE studentTb1 SET student_name=@name, department=@dept, picpath=@path WHERE student_id=@id";
            command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@name", studentNameTxtBox.Text);
            command.Parameters.AddWithValue("@dept", departmentTxtBox.Text);
            command.Parameters.AddWithValue("@path", picturepathTxtBox.Text);
            command.Parameters.AddWithValue("@id", studentNumTxtBox.Text);
            command.ExecuteNonQuery();

            // Refresh grid
            sql = "SELECT * FROM studentTb1";
            adapter = new SqlDataAdapter(sql, connection);
            dset = new DataSet();
            adapter.Fill(dset, "studentTb1");
            griddisplay.DataSource = dset.Tables[0];

            connection.Close();
            MessageBox.Show("Updated successfully!");

        }

        private void New_Click(object sender, EventArgs e)
        {
            studentNameTxtBox.Clear();
            studentNumTxtBox.Clear();
            departmentTxtBox.Clear();
            picturepathTxtBox.Clear();
            pictureBox1.Image = null;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
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

        private void pictureBox3_Click(object sender, EventArgs e)
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

        private void pictureBox4_Click(object sender, EventArgs e)
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

        private void pictureBox5_Click(object sender, EventArgs e)
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

        private void pictureBox6_Click(object sender, EventArgs e)
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

        private void griddisplay_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            studentNameTxtBox.Clear();
            studentNumTxtBox.Clear();
            departmentTxtBox.Clear();
            picturepathTxtBox.Clear();
            pictureBox1.Image = null;
        }
    }
    }
