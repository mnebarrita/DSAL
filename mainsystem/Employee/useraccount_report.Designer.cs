namespace mainsystem
{
    partial class useraccount_report
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
            this.panelMain = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.optionInputTxtbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.backBtn = new System.Windows.Forms.Button();
            this.optionCombo = new System.Windows.Forms.ComboBox();
            this.searchBtn = new System.Windows.Forms.Button();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.dataGridView1);
            this.panelMain.Controls.Add(this.optionInputTxtbox);
            this.panelMain.Controls.Add(this.label1);
            this.panelMain.Controls.Add(this.backBtn);
            this.panelMain.Controls.Add(this.optionCombo);
            this.panelMain.Controls.Add(this.searchBtn);
            this.panelMain.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelMain.Location = new System.Drawing.Point(17, 17);
            this.panelMain.Margin = new System.Windows.Forms.Padding(6);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1798, 943);
            this.panelMain.TabIndex = 7;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(22, 102);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(7);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1753, 821);
            this.dataGridView1.TabIndex = 12;
            // 
            // optionInputTxtbox
            // 
            this.optionInputTxtbox.Location = new System.Drawing.Point(795, 45);
            this.optionInputTxtbox.Margin = new System.Windows.Forms.Padding(6);
            this.optionInputTxtbox.Name = "optionInputTxtbox";
            this.optionInputTxtbox.Size = new System.Drawing.Size(381, 34);
            this.optionInputTxtbox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(195, 55);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select an option";
            // 
            // backBtn
            // 
            this.backBtn.Location = new System.Drawing.Point(1330, 44);
            this.backBtn.Margin = new System.Windows.Forms.Padding(6);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(132, 44);
            this.backBtn.TabIndex = 3;
            this.backBtn.Text = "Back";
            this.backBtn.UseVisualStyleBackColor = true;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // optionCombo
            // 
            this.optionCombo.FormattingEnabled = true;
            this.optionCombo.Items.AddRange(new object[] {
            "user_id",
            "employee_number",
            "surname",
            "firstname",
            "active",
            "deactivate"});
            this.optionCombo.Location = new System.Drawing.Point(400, 45);
            this.optionCombo.Margin = new System.Windows.Forms.Padding(6);
            this.optionCombo.Name = "optionCombo";
            this.optionCombo.Size = new System.Drawing.Size(381, 34);
            this.optionCombo.TabIndex = 0;
            // 
            // searchBtn
            // 
            this.searchBtn.Location = new System.Drawing.Point(1189, 42);
            this.searchBtn.Margin = new System.Windows.Forms.Padding(6);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(132, 44);
            this.searchBtn.TabIndex = 3;
            this.searchBtn.Text = "Search";
            this.searchBtn.UseVisualStyleBackColor = true;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // useraccount_report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1827, 974);
            this.Controls.Add(this.panelMain);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "useraccount_report";
            this.Text = "useraccount_report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.useraccount_report_Load);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox optionInputTxtbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.ComboBox optionCombo;
        private System.Windows.Forms.Button searchBtn;
    }
}