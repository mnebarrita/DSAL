namespace mainsystem
{
    partial class SampleLongMethod
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.departmentTxtBox = new System.Windows.Forms.TextBox();
            this.studentNameTxtBox = new System.Windows.Forms.TextBox();
            this.picturepathTxtBox = new System.Windows.Forms.TextBox();
            this.studentNumTxtBox = new System.Windows.Forms.TextBox();
            this.New = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.Edit = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.Search = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.griddisplay = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.griddisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Location = new System.Drawing.Point(16, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(614, 694);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::mainsystem.Properties.Resources.me_whwn_im_omw;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(8, 18);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(599, 664);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 30F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(702, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(629, 68);
            this.label1.TabIndex = 0;
            this.label1.Text = "MiFlo Database Management";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.departmentTxtBox);
            this.panel1.Controls.Add(this.studentNameTxtBox);
            this.panel1.Controls.Add(this.picturepathTxtBox);
            this.panel1.Controls.Add(this.studentNumTxtBox);
            this.panel1.Controls.Add(this.New);
            this.panel1.Controls.Add(this.Cancel);
            this.panel1.Controls.Add(this.Edit);
            this.panel1.Controls.Add(this.Delete);
            this.panel1.Controls.Add(this.Search);
            this.panel1.Controls.Add(this.Save);
            this.panel1.Controls.Add(this.griddisplay);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(15, 11);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1372, 724);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // departmentTxtBox
            // 
            this.departmentTxtBox.Location = new System.Drawing.Point(838, 200);
            this.departmentTxtBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.departmentTxtBox.Name = "departmentTxtBox";
            this.departmentTxtBox.Size = new System.Drawing.Size(515, 26);
            this.departmentTxtBox.TabIndex = 4;
            // 
            // studentNameTxtBox
            // 
            this.studentNameTxtBox.Location = new System.Drawing.Point(838, 162);
            this.studentNameTxtBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.studentNameTxtBox.Name = "studentNameTxtBox";
            this.studentNameTxtBox.Size = new System.Drawing.Size(515, 26);
            this.studentNameTxtBox.TabIndex = 4;
            // 
            // picturepathTxtBox
            // 
            this.picturepathTxtBox.Location = new System.Drawing.Point(838, 92);
            this.picturepathTxtBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.picturepathTxtBox.Name = "picturepathTxtBox";
            this.picturepathTxtBox.Size = new System.Drawing.Size(515, 26);
            this.picturepathTxtBox.TabIndex = 4;
            // 
            // studentNumTxtBox
            // 
            this.studentNumTxtBox.Location = new System.Drawing.Point(838, 128);
            this.studentNumTxtBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.studentNumTxtBox.Name = "studentNumTxtBox";
            this.studentNumTxtBox.Size = new System.Drawing.Size(515, 26);
            this.studentNumTxtBox.TabIndex = 4;
            // 
            // New
            // 
            this.New.Location = new System.Drawing.Point(1120, 615);
            this.New.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.New.Name = "New";
            this.New.Size = new System.Drawing.Size(232, 94);
            this.New.TabIndex = 3;
            this.New.Text = "New";
            this.New.UseVisualStyleBackColor = true;
            this.New.Click += new System.EventHandler(this.New_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(880, 615);
            this.Cancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(232, 94);
            this.Cancel.TabIndex = 3;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // Edit
            // 
            this.Edit.Location = new System.Drawing.Point(640, 615);
            this.Edit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Edit.Name = "Edit";
            this.Edit.Size = new System.Drawing.Size(232, 94);
            this.Edit.TabIndex = 3;
            this.Edit.Text = "Edit";
            this.Edit.UseVisualStyleBackColor = true;
            this.Edit.Click += new System.EventHandler(this.Edit_Click);
            // 
            // Delete
            // 
            this.Delete.Location = new System.Drawing.Point(1120, 514);
            this.Delete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(232, 94);
            this.Delete.TabIndex = 3;
            this.Delete.Text = "Delete";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // Search
            // 
            this.Search.Location = new System.Drawing.Point(880, 514);
            this.Search.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(232, 94);
            this.Search.TabIndex = 3;
            this.Search.Text = "Search";
            this.Search.UseVisualStyleBackColor = true;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(640, 514);
            this.Save.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(232, 94);
            this.Save.TabIndex = 3;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // griddisplay
            // 
            this.griddisplay.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.griddisplay.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.griddisplay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.griddisplay.Location = new System.Drawing.Point(640, 240);
            this.griddisplay.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.griddisplay.Name = "griddisplay";
            this.griddisplay.RowHeadersWidth = 51;
            this.griddisplay.RowTemplate.Height = 24;
            this.griddisplay.Size = new System.Drawing.Size(712, 266);
            this.griddisplay.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(638, 200);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Department:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(638, 162);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Student Name:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.Location = new System.Drawing.Point(638, 92);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "Picture Path:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(638, 128);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Student Number:";
            // 
            // SampleLongMethod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1402, 750);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "SampleLongMethod";
            this.Text = "SampleLongMethod";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.SampleLongMethod_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.griddisplay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView griddisplay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button New;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button Edit;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Button Search;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.TextBox departmentTxtBox;
        private System.Windows.Forms.TextBox studentNameTxtBox;
        private System.Windows.Forms.TextBox picturepathTxtBox;
        private System.Windows.Forms.TextBox studentNumTxtBox;
        private System.Windows.Forms.Label label5;
    }
}