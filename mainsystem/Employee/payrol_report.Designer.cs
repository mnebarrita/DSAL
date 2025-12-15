namespace mainsystem
{
    partial class payrol_report
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.optionInputTxtbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.optionCombo = new System.Windows.Forms.ComboBox();
            this.panelMain = new System.Windows.Forms.Panel();
            this.backBtn = new System.Windows.Forms.Button();
            this.searchBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(23, 102);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1754, 821);
            this.dataGridView1.TabIndex = 12;
            // 
            // optionInputTxtbox
            // 
            this.optionInputTxtbox.Location = new System.Drawing.Point(794, 45);
            this.optionInputTxtbox.Margin = new System.Windows.Forms.Padding(5);
            this.optionInputTxtbox.Name = "optionInputTxtbox";
            this.optionInputTxtbox.Size = new System.Drawing.Size(381, 34);
            this.optionInputTxtbox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(195, 54);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select an option";
            // 
            // optionCombo
            // 
            this.optionCombo.FormattingEnabled = true;
            this.optionCombo.Items.AddRange(new object[] {
            "employee_number",
            "",
            "gross_income",
            "",
            "net_income",
            "",
            "pay_date"});
            this.optionCombo.Location = new System.Drawing.Point(401, 45);
            this.optionCombo.Margin = new System.Windows.Forms.Padding(5);
            this.optionCombo.Name = "optionCombo";
            this.optionCombo.Size = new System.Drawing.Size(381, 34);
            this.optionCombo.TabIndex = 0;
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
            this.panelMain.Location = new System.Drawing.Point(21, 21);
            this.panelMain.Margin = new System.Windows.Forms.Padding(5);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1797, 942);
            this.panelMain.TabIndex = 5;
            // 
            // backBtn
            // 
            this.backBtn.Location = new System.Drawing.Point(1330, 44);
            this.backBtn.Margin = new System.Windows.Forms.Padding(5);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(131, 44);
            this.backBtn.TabIndex = 3;
            this.backBtn.Text = "Back";
            this.backBtn.UseVisualStyleBackColor = true;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // searchBtn
            // 
            this.searchBtn.Location = new System.Drawing.Point(1189, 42);
            this.searchBtn.Margin = new System.Windows.Forms.Padding(5);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(131, 44);
            this.searchBtn.TabIndex = 3;
            this.searchBtn.Text = "Search";
            this.searchBtn.UseVisualStyleBackColor = true;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // payrol_report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1418, 805);
            this.Controls.Add(this.panelMain);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "payrol_report";
            this.Text = "payrol_report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.payrol_report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox optionInputTxtbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox optionCombo;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Button searchBtn;
    }
}