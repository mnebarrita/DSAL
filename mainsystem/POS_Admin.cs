using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Image = System.Drawing.Image;

namespace mainsystem
{
    public partial class POS_Admin : Form
    {
        posdb_connect posdb_connect = new posdb_connect();
        private OpenFileDialog openFileDialog1 = new OpenFileDialog();

        private string picpath;
        private Image pic;
        public POS_Admin()
        {
            posdb_connect.pos_connString();
            InitializeComponent();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on Double Buffering at the OS level
                return cp;
            }
        }

        private void cleartextboxes()
        {
            try
            {
                
                string defaultImagePath = @"C:\Users\Mica\Downloads\download (8).jpg";
                if (File.Exists(defaultImagePath))
                {
                    pic = Image.FromFile(defaultImagePath);
                }
                else
                {
                    pic = null;
                }

                
                picpathTxtbox1.Clear(); picpathTxtbox2.Clear(); picpathTxtbox3.Clear();
                picpathTxtbox4.Clear(); picpathTxtbox5.Clear(); picpathTxtbox6.Clear();
                picpathTxtbox7.Clear(); picpathTxtbox8.Clear(); picpathTxtbox9.Clear();
                picpathTxtbox10.Clear(); picpathTxtbox11.Clear(); picpathTxtbox12.Clear();
                picpathTxtbox13.Clear(); picpathTxtbox14.Clear(); picpathTxtbox15.Clear();
                picpathTxtbox16.Clear(); picpathTxtbox17.Clear(); picpathTxtbox18.Clear();
                picpathTxtbox19.Clear(); picpathTxtbox20.Clear();

                priceTxtbox1.Clear(); priceTxtbox2.Clear(); priceTxtbox3.Clear();
                priceTxtbox4.Clear(); priceTxtbox5.Clear(); priceTxtbox6.Clear();
                priceTxtbox7.Clear(); priceTxtbox8.Clear(); priceTxtbox9.Clear();
                priceTxtbox10.Clear(); priceTxtbox11.Clear(); priceTxtbox12.Clear();
                priceTxtbox13.Clear(); priceTxtbox14.Clear(); priceTxtbox15.Clear();
                priceTxtbox16.Clear(); priceTxtbox17.Clear(); priceTxtbox18.Clear();
                priceTxtbox19.Clear(); priceTxtbox20.Clear();

                nameTxtbox1.Clear(); nameTxtbox2.Clear(); nameTxtbox3.Clear();
                nameTxtbox4.Clear(); nameTxtbox5.Clear(); nameTxtbox6.Clear();
                nameTxtbox7.Clear(); nameTxtbox8.Clear(); nameTxtbox9.Clear();
                nameTxtbox10.Clear(); nameTxtbox11.Clear(); nameTxtbox12.Clear();
                nameTxtbox13.Clear(); nameTxtbox14.Clear(); nameTxtbox15.Clear();
                nameTxtbox16.Clear(); nameTxtbox17.Clear(); nameTxtbox18.Clear();
                nameTxtbox19.Clear(); nameTxtbox20.Clear();

                if (pic != null)
                {
                    pictureBox1.Image = pic; pictureBox2.Image = pic; pictureBox3.Image = pic; pictureBox4.Image = pic;
                    pictureBox5.Image = pic; pictureBox6.Image = pic; pictureBox7.Image = pic; pictureBox8.Image = pic;
                    pictureBox9.Image = pic; pictureBox10.Image = pic; pictureBox11.Image = pic; pictureBox12.Image = pic;
                    pictureBox13.Image = pic; pictureBox14.Image = pic; pictureBox15.Image = pic; pictureBox16.Image = pic;
                    pictureBox17.Image = pic; pictureBox18.Image = pic; pictureBox19.Image = pic; pictureBox20.Image = pic;
                }
                else
                {
                    pictureBox1.Image = null; pictureBox2.Image = null; pictureBox3.Image = null; pictureBox4.Image = null;
                    pictureBox5.Image = null; pictureBox6.Image = null; pictureBox7.Image = null; pictureBox8.Image = null;
                    pictureBox9.Image = null; pictureBox10.Image = null; pictureBox11.Image = null; pictureBox12.Image = null;
                    pictureBox13.Image = null; pictureBox14.Image = null; pictureBox15.Image = null; pictureBox16.Image = null;
                    pictureBox17.Image = null; pictureBox18.Image = null; pictureBox19.Image = null; pictureBox20.Image = null;
                }
            }
            catch (Exception ex)
            {
               MessageBox.Show("Error occurs in this area. Please contact your administrator!\n\n" + ex.Message);
            }
        }
        private void SelectImage(System.Windows.Forms.PictureBox pictureBox, System.Windows.Forms.TextBox textBox)
        {
            openFileDialog1.Filter = "Image Files|*.gif;*.jpg;*.jpeg;*.png;*.bmp";
            openFileDialog1.Title = "Select an Image";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox.Image = Image.FromFile(openFileDialog1.FileName);
                textBox.Text = openFileDialog1.FileName;
            }
        }

        private DataTable TransposeDataTable(DataTable dt)
        {
            DataTable transposed = new DataTable();

            transposed.Columns.Add("Column");
            foreach (DataRow row in dt.Rows)
                transposed.Columns.Add(row[0].ToString());

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                DataRow newRow = transposed.NewRow();
                newRow[0] = dt.Columns[i].ColumnName;

                for (int j = 0; j < dt.Rows.Count; j++)
                    newRow[j + 1] = dt.Rows[j][i].ToString();

                transposed.Rows.Add(newRow);
            }

            return transposed;
        }

        private void LoadComboBoxIDs()
        {
            try
            {
                posdb_connect.pos_connString();
                posdb_connect.posdb_open(); 

                comboBox1.Items.Clear();

                string query = "SELECT pos_id FROM pos_nameTb1 ORDER BY pos_id ASC";

                using (SqlCommand cmd = new SqlCommand(query, posdb_connect.pos_sql_connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                comboBox1.Items.Add(reader["pos_id"].ToString());
                            }
                        }
                        else
                        {
                            MessageBox.Show("No POS IDs found in the database.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading IDs: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                posdb_connect.posdb_close(); // Always close
            }
        }




        private void CenterPanel()
        {
            panelMain.Left = (this.ClientSize.Width - panelMain.Width) / 2;
            panelMain.Top = (this.ClientSize.Height - panelMain.Height) / 2;
        }


        private void POS_Admin_Load(object sender, EventArgs e)
        {
            try
            { 
                posdb_connect.pos_connString();
                posdb_connect.posdb_open();

                string sql = "SELECT * FROM pos_nameTb1";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, posdb_connect.pos_sql_connection);
                DataSet dset = new DataSet();
                adapter.Fill(dset, "pos_nameTb1");

                DataTable original = dset.Tables[0]; 
                DataTable transposed = TransposeDataTable(original);
                dataGridView1.DataSource = transposed;



                //Center panel (UI logic) ---
                CenterPanel();
                this.Resize += (s, ev) => CenterPanel();

                picpathTxtbox1.Hide(); picpathTxtbox2.Hide(); picpathTxtbox3.Hide(); picpathTxtbox4.Hide();
                picpathTxtbox5.Hide(); picpathTxtbox6.Hide(); picpathTxtbox7.Hide(); picpathTxtbox8.Hide();
                picpathTxtbox9.Hide(); picpathTxtbox10.Hide(); picpathTxtbox11.Hide(); picpathTxtbox12.Hide();
                picpathTxtbox13.Hide(); picpathTxtbox14.Hide(); picpathTxtbox15.Hide(); picpathTxtbox16.Hide();
                picpathTxtbox17.Hide(); picpathTxtbox18.Hide(); picpathTxtbox19.Hide(); picpathTxtbox20.Hide();

                LoadComboBoxIDs();


                if (posdb_connect.pos_sql_dataset != null && posdb_connect.pos_sql_dataset.Tables.Count > 0)
                {
                    dataGridView1.DataSource = posdb_connect.pos_sql_dataset.Tables[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurs while loading the form.\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                posdb_connect.posdb_close();
            }
        }

        private void SEARCH_Click(object sender, EventArgs e)
        {
            try
            {
                posdb_connect.pos_connString();
                posdb_connect.posdb_open();
                {
                    // 1. Get the Data
                    posdb_connect.pos_sql = "SELECT * FROM pos_nameTb1 " +
                        "INNER JOIN pos_picTb1 ON pos_nameTb1.pos_id = pos_picTb1.pos_id " +
                        "INNER JOIN pos_priceTb1 ON pos_picTb1.pos_id = pos_priceTb1.pos_id " +
                        "WHERE pos_nameTb1.pos_id = '" + comboBox1.Text + "'";

                    posdb_connect.pos_cmd();
                    posdb_connect.pos_sqladapterSelect();
                    posdb_connect.pos_sqldatasetSELECT();

                    // 2. Load the Grid (Visuals)
                    DataTable original = posdb_connect.pos_sql_dataset.Tables[0];
                    DataTable transposed = TransposeDataTable(original);
                    dataGridView1.DataSource = transposed;

                    // 3. FILL TEXTBOXES (The Corrected Mapping!)
                    DataRow row = posdb_connect.pos_sql_dataset.Tables[0].Rows[0];

                    // --- NAMES (Indices 1 to 20) ---
                    nameTxtbox1.Text = row[1].ToString();
                    nameTxtbox2.Text = row[2].ToString();
                    nameTxtbox3.Text = row[3].ToString();
                    nameTxtbox4.Text = row[4].ToString();
                    nameTxtbox5.Text = row[5].ToString();
                    nameTxtbox6.Text = row[6].ToString();
                    nameTxtbox7.Text = row[7].ToString();
                    nameTxtbox8.Text = row[8].ToString();
                    nameTxtbox9.Text = row[9].ToString();
                    nameTxtbox10.Text = row[10].ToString();
                    nameTxtbox11.Text = row[11].ToString();
                    nameTxtbox12.Text = row[12].ToString();
                    nameTxtbox13.Text = row[13].ToString();
                    nameTxtbox14.Text = row[14].ToString();
                    nameTxtbox15.Text = row[15].ToString();
                    nameTxtbox16.Text = row[16].ToString();
                    nameTxtbox17.Text = row[17].ToString();
                    nameTxtbox18.Text = row[18].ToString();
                    nameTxtbox19.Text = row[19].ToString();
                    nameTxtbox20.Text = row[20].ToString();

                    // --- PICTURE PATHS (Indices 22 to 41) ---
                    // Note: Index 21 is the duplicate 'pos_id' from the second table, so we skip it.
                    picpathTxtbox1.Text = row[22].ToString();
                    picpathTxtbox2.Text = row[23].ToString();
                    picpathTxtbox3.Text = row[24].ToString();
                    picpathTxtbox4.Text = row[25].ToString();
                    picpathTxtbox5.Text = row[26].ToString();
                    picpathTxtbox6.Text = row[27].ToString();
                    picpathTxtbox7.Text = row[28].ToString();
                    picpathTxtbox8.Text = row[29].ToString();
                    picpathTxtbox9.Text = row[30].ToString();
                    picpathTxtbox10.Text = row[31].ToString();
                    picpathTxtbox11.Text = row[32].ToString();
                    picpathTxtbox12.Text = row[33].ToString();
                    picpathTxtbox13.Text = row[34].ToString();
                    picpathTxtbox14.Text = row[35].ToString();
                    picpathTxtbox15.Text = row[36].ToString();
                    picpathTxtbox16.Text = row[37].ToString();
                    picpathTxtbox17.Text = row[38].ToString();
                    picpathTxtbox18.Text = row[39].ToString();
                    picpathTxtbox19.Text = row[40].ToString();
                    picpathTxtbox20.Text = row[41].ToString();

                    // Load the actual images into PictureBoxes
                    if (File.Exists(picpathTxtbox1.Text)) pictureBox1.Image = Image.FromFile(picpathTxtbox1.Text); else pictureBox1.Image = null;
                    if (File.Exists(picpathTxtbox2.Text)) pictureBox2.Image = Image.FromFile(picpathTxtbox2.Text); else pictureBox2.Image = null;
                    if (File.Exists(picpathTxtbox3.Text)) pictureBox3.Image = Image.FromFile(picpathTxtbox3.Text); else pictureBox3.Image = null;
                    if (File.Exists(picpathTxtbox4.Text)) pictureBox4.Image = Image.FromFile(picpathTxtbox4.Text); else pictureBox4.Image = null;
                    if (File.Exists(picpathTxtbox5.Text)) pictureBox5.Image = Image.FromFile(picpathTxtbox5.Text); else pictureBox5.Image = null;
                    if (File.Exists(picpathTxtbox6.Text)) pictureBox6.Image = Image.FromFile(picpathTxtbox6.Text); else pictureBox6.Image = null;
                    if (File.Exists(picpathTxtbox7.Text)) pictureBox7.Image = Image.FromFile(picpathTxtbox7.Text); else pictureBox7.Image = null;
                    if (File.Exists(picpathTxtbox8.Text)) pictureBox8.Image = Image.FromFile(picpathTxtbox8.Text); else pictureBox8.Image = null;
                    if (File.Exists(picpathTxtbox9.Text)) pictureBox9.Image = Image.FromFile(picpathTxtbox9.Text); else pictureBox9.Image = null;
                    if (File.Exists(picpathTxtbox10.Text)) pictureBox10.Image = Image.FromFile(picpathTxtbox10.Text); else pictureBox10.Image = null;
                    if (File.Exists(picpathTxtbox11.Text)) pictureBox11.Image = Image.FromFile(picpathTxtbox11.Text); else pictureBox11.Image = null;
                    if (File.Exists(picpathTxtbox12.Text)) pictureBox12.Image = Image.FromFile(picpathTxtbox12.Text); else pictureBox12.Image = null;
                    if (File.Exists(picpathTxtbox13.Text)) pictureBox13.Image = Image.FromFile(picpathTxtbox13.Text); else pictureBox13.Image = null;
                    if (File.Exists(picpathTxtbox14.Text)) pictureBox14.Image = Image.FromFile(picpathTxtbox14.Text); else pictureBox14.Image = null;
                    if (File.Exists(picpathTxtbox15.Text)) pictureBox15.Image = Image.FromFile(picpathTxtbox15.Text); else pictureBox15.Image = null;
                    if (File.Exists(picpathTxtbox16.Text)) pictureBox16.Image = Image.FromFile(picpathTxtbox16.Text); else pictureBox16.Image = null;
                    if (File.Exists(picpathTxtbox17.Text)) pictureBox17.Image = Image.FromFile(picpathTxtbox17.Text); else pictureBox17.Image = null;
                    if (File.Exists(picpathTxtbox18.Text)) pictureBox18.Image = Image.FromFile(picpathTxtbox18.Text); else pictureBox18.Image = null;
                    if (File.Exists(picpathTxtbox19.Text)) pictureBox19.Image = Image.FromFile(picpathTxtbox19.Text); else pictureBox19.Image = null;
                    if (File.Exists(picpathTxtbox20.Text)) pictureBox20.Image = Image.FromFile(picpathTxtbox20.Text); else pictureBox20.Image = null;

                    // --- PRICES (Indices 43 to 62) ---
                    // Note: Index 42 is the duplicate 'pos_id' from the third table, so we skip it.
                    priceTxtbox1.Text = row[43].ToString();
                    priceTxtbox2.Text = row[44].ToString();
                    priceTxtbox3.Text = row[45].ToString();
                    priceTxtbox4.Text = row[46].ToString();
                    priceTxtbox5.Text = row[47].ToString();
                    priceTxtbox6.Text = row[48].ToString();
                    priceTxtbox7.Text = row[49].ToString();
                    priceTxtbox8.Text = row[50].ToString();
                    priceTxtbox9.Text = row[51].ToString();
                    priceTxtbox10.Text = row[52].ToString();
                    priceTxtbox11.Text = row[53].ToString();
                    priceTxtbox12.Text = row[54].ToString();
                    priceTxtbox13.Text = row[55].ToString();
                    priceTxtbox14.Text = row[56].ToString();
                    priceTxtbox15.Text = row[57].ToString();
                    priceTxtbox16.Text = row[58].ToString();
                    priceTxtbox17.Text = row[59].ToString();
                    priceTxtbox18.Text = row[60].ToString();
                    priceTxtbox19.Text = row[61].ToString();
                    priceTxtbox20.Text = row[62].ToString(); // This is the final column!

                    MessageBox.Show("Record successfully updated!", "Update Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                posdb_connect.posdb_close();
            }
        }

        private void SAVE_Click(object sender, EventArgs e)
        {
            try
            {
                posdb_connect.pos_connString();
                posdb_connect.posdb_open();


                posdb_connect.pos_sql = "INSERT INTO pos_nameTb1 (pos_id, name1, name2, name3, name4, name5, name6, name7, name8, name9, name10, name11, name12, name13, name14, name15, name16, name17, name18, name19, name20) " +
                    "VALUES ('" + comboBox1.Text + "', '" +
                    nameTxtbox1.Text + "', '" + nameTxtbox2.Text + "', '" + nameTxtbox3.Text + "', '" + nameTxtbox4.Text + "', '" + nameTxtbox5.Text + "', '" +
                    nameTxtbox6.Text + "', '" + nameTxtbox7.Text + "', '" + nameTxtbox8.Text + "', '" + nameTxtbox9.Text + "', '" + nameTxtbox10.Text + "', '" + nameTxtbox11.Text + "', '" +
                    nameTxtbox12.Text + "', '" + nameTxtbox13.Text + "', '" + nameTxtbox14.Text + "', '" + nameTxtbox15.Text + "', '" + nameTxtbox16.Text + "', '" + nameTxtbox17.Text + "', '" +
                    nameTxtbox18.Text + "', '" + nameTxtbox19.Text + "', '" + nameTxtbox20.Text + "')";
                posdb_connect.pos_cmd();
                posdb_connect.pos_sqladapterInsert();

                posdb_connect.pos_sql = "INSERT INTO pos_priceTb1 (pos_id, price1, price2, price3, price4, price5, price6, price7, price8, price9, price10, price11, price12, price13, price14, price15, price16, price17, price18, price19, price20) " +
                    "VALUES ('" + comboBox1.Text + "', '" +
                    priceTxtbox1.Text + "', '" + priceTxtbox2.Text + "', '" + priceTxtbox3.Text + "', '" + priceTxtbox4.Text + "', '" + priceTxtbox5.Text + "', '" +
                    priceTxtbox6.Text + "', '" + priceTxtbox7.Text + "', '" + priceTxtbox8.Text + "', '" + priceTxtbox9.Text + "', '" + priceTxtbox10.Text + "', '" + priceTxtbox11.Text + "', '" +
                    priceTxtbox12.Text + "', '" + priceTxtbox13.Text + "', '" + priceTxtbox14.Text + "', '" + priceTxtbox15.Text + "', '" + priceTxtbox16.Text + "', '" + priceTxtbox17.Text + "', '" + priceTxtbox18.Text + "', '" +
                    priceTxtbox19.Text + "', '" + priceTxtbox20.Text + "')";
                posdb_connect.pos_cmd();
                posdb_connect.pos_sqladapterInsert();

                posdb_connect.pos_sql = "INSERT INTO pos_picTb1 (pos_id, pic1, pic2, pic3, pic4, pic5, pic6, pic7, pic8, pic9, pic10, pic11, pic12, pic13, pic14, pic15, pic16, pic17, pic18, pic19, pic20) " +
                    "VALUES ('" + comboBox1.Text + "', '" +
                    picpathTxtbox1.Text + "', '" + picpathTxtbox2.Text + "', '" + picpathTxtbox3.Text + "', '" + picpathTxtbox4.Text + "', '" + picpathTxtbox5.Text + "', '" +
                    picpathTxtbox6.Text + "', '" + picpathTxtbox7.Text + "', '" + picpathTxtbox8.Text + "', '" + picpathTxtbox9.Text + "', '" + picpathTxtbox10.Text + "', '" + picpathTxtbox11.Text + "', '" +
                    picpathTxtbox12.Text + "', '" + picpathTxtbox13.Text + "', '" + picpathTxtbox14.Text + "', '" + picpathTxtbox15.Text + "', '" + picpathTxtbox16.Text + "', '" + picpathTxtbox17.Text + "', '" +
                    picpathTxtbox18.Text + "', '" + picpathTxtbox19.Text + "', '" + picpathTxtbox20.Text + "')";
                posdb_connect.pos_cmd();
                posdb_connect.pos_sqladapterInsert();

                posdb_connect.pos_select();
                posdb_connect.pos_cmd();
                posdb_connect.pos_sqladapterSelect();
                posdb_connect.pos_sqldatasetSELECT();
                if (posdb_connect.pos_sql_dataset != null && posdb_connect.pos_sql_dataset.Tables.Count > 0)
                {
                    DataTable original = posdb_connect.pos_sql_dataset.Tables[0];  
                    DataTable transposed = TransposeDataTable(original);            
                    dataGridView1.DataSource = transposed;                          

                }

                // Let the user know it saved
                MessageBox.Show("Data saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear input fields
                cleartextboxes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while saving: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                posdb_connect.posdb_close();
            }
        }

        private void UPDATE_Click(object sender, EventArgs e)
        {
            try
            {
                posdb_connect.pos_connString();
                posdb_connect.posdb_open();
                {
                    // Update name table
                    posdb_connect.pos_sql = "UPDATE pos_nameTb1 SET " +
                        "name1 = '" + nameTxtbox1.Text + "', " +
                        "name2 = '" + nameTxtbox2.Text + "', " +
                        "name3 = '" + nameTxtbox3.Text + "', " +
                        "name4 = '" + nameTxtbox4.Text + "', " +
                        "name5 = '" + nameTxtbox5.Text + "', " +
                        "name6 = '" + nameTxtbox6.Text + "', " +
                        "name7 = '" + nameTxtbox7.Text + "', " +
                        "name8 = '" + nameTxtbox8.Text + "', " +
                        "name9 = '" + nameTxtbox9.Text + "', " +
                        "name10 = '" + nameTxtbox10.Text + "', " +
                        "name11 = '" + nameTxtbox11.Text + "', " +
                        "name12 = '" + nameTxtbox12.Text + "', " +
                        "name13 = '" + nameTxtbox13.Text + "', " +
                        "name14 = '" + nameTxtbox14.Text + "', " +
                        "name15 = '" + nameTxtbox15.Text + "', " +
                        "name16 = '" + nameTxtbox16.Text + "', " +
                        "name17 = '" + nameTxtbox17.Text + "', " +
                        "name18 = '" + nameTxtbox18.Text + "', " +
                        "name19 = '" + nameTxtbox19.Text + "', " +
                        "name20 = '" + nameTxtbox20.Text + "' " +
                        "WHERE pos_id = '" + comboBox1.Text + "'";
                    posdb_connect.pos_cmd();
                    posdb_connect.pos_sqladapterUpdate();

                    // Update pic table
                    posdb_connect.pos_sql = "UPDATE pos_picTb1 SET " +
                        "pic1 = '" + picpathTxtbox1.Text + "', pic2 = '" + picpathTxtbox2.Text + "', pic3 = '" + picpathTxtbox3.Text + "', pic4 = '" + picpathTxtbox4.Text + "', " +
                        "pic5 = '" + picpathTxtbox5.Text + "', pic6 = '" + picpathTxtbox6.Text + "', pic7 = '" + picpathTxtbox7.Text + "', pic8 = '" + picpathTxtbox8.Text + "', " +
                        "pic9 = '" + picpathTxtbox9.Text + "', pic10 = '" + picpathTxtbox10.Text + "', pic11 = '" + picpathTxtbox11.Text + "', pic12 = '" + picpathTxtbox12.Text + "', " +
                        "pic13 = '" + picpathTxtbox13.Text + "', pic14 = '" + picpathTxtbox14.Text + "', pic15 = '" + picpathTxtbox15.Text + "', pic16 = '" + picpathTxtbox16.Text + "', " +
                        "pic17 = '" + picpathTxtbox17.Text + "', pic18 = '" + picpathTxtbox18.Text + "', pic19 = '" + picpathTxtbox19.Text + "', pic20 = '" + picpathTxtbox20.Text + "' " +
                        "WHERE pos_id = '" + comboBox1.Text + "'";
                    posdb_connect.pos_cmd();
                    posdb_connect.pos_sqladapterUpdate();

                    // Update price table
                    posdb_connect.pos_sql = "UPDATE pos_priceTb1 SET " +
                        "price1 = '" + priceTxtbox1.Text + "', price2 = '" + priceTxtbox2.Text + "', price3 = '" + priceTxtbox3.Text + "', price4 = '" + priceTxtbox4.Text + "', " +
                        "price5 = '" + priceTxtbox5.Text + "', price6 = '" + priceTxtbox6.Text + "', price7 = '" + priceTxtbox7.Text + "', price8 = '" + priceTxtbox8.Text + "', " +
                        "price9 = '" + priceTxtbox9.Text + "', price10 = '" + priceTxtbox10.Text + "', price11 = '" + priceTxtbox11.Text + "', price12 = '" + priceTxtbox12.Text + "', " +
                        "price13 = '" + priceTxtbox13.Text + "', price14 = '" + priceTxtbox14.Text + "', price15 = '" + priceTxtbox15.Text + "', price16 = '" + priceTxtbox16.Text + "', " +
                        "price17 = '" + priceTxtbox17.Text + "', price18 = '" + priceTxtbox18.Text + "', price19 = '" + priceTxtbox19.Text + "', price20 = '" + priceTxtbox20.Text + "' " +
                        "WHERE pos_id = '" + comboBox1.Text + "'";
                    posdb_connect.pos_cmd();
                    posdb_connect.pos_sqladapterUpdate();

                    // Refresh dataset & grid
                    posdb_connect.pos_select();
                    posdb_connect.pos_cmd();
                    posdb_connect.pos_sqladapterSelect();
                    posdb_connect.pos_sqldatasetSELECT();
                    if (posdb_connect.pos_sql_dataset != null && posdb_connect.pos_sql_dataset.Tables.Count > 0)
                    {
                        DataTable original = posdb_connect.pos_sql_dataset.Tables[0];  
                        DataTable transposed = TransposeDataTable(original);            
                        dataGridView1.DataSource = transposed;                          

                    }
                    MessageBox.Show("Record successfully updated!", "Update Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    cleartextboxes();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                posdb_connect.posdb_close();
            }
        }

        private void DELETE_Click(object sender, EventArgs e)
        {
            try
            {
                posdb_connect.pos_connString();
                posdb_connect.posdb_open();

                DialogResult confirm = MessageBox.Show(
                    "Are you sure you want to delete this record?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirm == DialogResult.Yes)

                {
                    // Delete price row
                    posdb_connect.pos_sql = "DELETE FROM pos_priceTb1 WHERE pos_id = '" + comboBox1.Text + "'";
                    posdb_connect.pos_cmd();
                    posdb_connect.pos_sqladapterDelete();

                    // Delete pic row
                    posdb_connect.pos_sql = "DELETE FROM pos_picTb1 WHERE pos_id = '" + comboBox1.Text + "'";
                    posdb_connect.pos_cmd();
                    posdb_connect.pos_sqladapterDelete();

                    // Delete name row
                    posdb_connect.pos_sql = "DELETE FROM pos_nameTb1 WHERE pos_id = '" + comboBox1.Text + "'";
                    posdb_connect.pos_cmd();
                    posdb_connect.pos_sqladapterDelete();

                    // Refresh dataset & grid
                    posdb_connect.pos_select();
                    posdb_connect.pos_cmd();
                    posdb_connect.pos_sqladapterSelect();
                    posdb_connect.pos_sqldatasetSELECT();
                    if (posdb_connect.pos_sql_dataset != null && posdb_connect.pos_sql_dataset.Tables.Count > 0)
                    {
                        DataTable original = posdb_connect.pos_sql_dataset.Tables[0];  
                        DataTable transposed = TransposeDataTable(original);            
                        dataGridView1.DataSource = transposed;                          

                    }

                    cleartextboxes();

                    //Refresh ComboBox and DataGridView after delete
                    comboBox1.Items.Clear();
                    LoadComboBoxIDs(); // reload available pos_ids

                    dataGridView1.DataSource = null;
                    string sql = "SELECT * FROM pos_nameTb1";
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, posdb_connect.pos_sql_connection);
                    DataSet dset = new DataSet();
                    adapter.Fill(dset, "pos_nameTb1");
                    dataGridView1.DataSource = dset.Tables[0];

                    MessageBox.Show("Record successfully deleted.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurs in this area. Please contact your administrator!\n\n" + ex.Message);
            }
            finally
            {
                posdb_connect.posdb_close();
            }
        }

        private void NEWCANCEL_Click(object sender, EventArgs e)
        {
            cleartextboxes();

        }

        private void EXIT_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SelectImage(pictureBox1, picpathTxtbox1);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SelectImage(pictureBox2, picpathTxtbox2);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            SelectImage(pictureBox3, picpathTxtbox3);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            SelectImage(pictureBox4, picpathTxtbox4);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            SelectImage(pictureBox5, picpathTxtbox5);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            SelectImage(pictureBox6, picpathTxtbox6);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            SelectImage(pictureBox7, picpathTxtbox7);
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            SelectImage(pictureBox8, picpathTxtbox8);
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            SelectImage(pictureBox9, picpathTxtbox9);
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            SelectImage(pictureBox10, picpathTxtbox10);
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            SelectImage(pictureBox11, picpathTxtbox11);
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            SelectImage(pictureBox12, picpathTxtbox12);
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            SelectImage(pictureBox13, picpathTxtbox13);
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            SelectImage(pictureBox14, picpathTxtbox14);
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            SelectImage(pictureBox15, picpathTxtbox15);
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            SelectImage(pictureBox16, picpathTxtbox16);
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            SelectImage(pictureBox17, picpathTxtbox17);
        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            SelectImage(pictureBox18, picpathTxtbox18);
        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {
            SelectImage(pictureBox19, picpathTxtbox19);
        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {
            SelectImage(pictureBox20, picpathTxtbox20);
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
