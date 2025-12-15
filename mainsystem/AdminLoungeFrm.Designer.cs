namespace mainsystem
{
    partial class AdminLoungeFrm
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
            this.components = new System.ComponentModel.Container();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.gridSearchResults = new System.Windows.Forms.DataGridView();
            this.rtbSearch = new System.Windows.Forms.RichTextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.pnlSearchContainer = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.panelMain.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSearchResults)).BeginInit();
            this.pnlSearchContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.BackColor = System.Drawing.Color.Transparent;
            this.lblWelcome.Font = new System.Drawing.Font("Vineta BT", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblWelcome.Location = new System.Drawing.Point(529, 37);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(984, 68);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Welcome Administrator!";
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.Transparent;
            this.panelMain.Controls.Add(this.gridSearchResults);
            this.panelMain.Controls.Add(this.panel1);
            this.panelMain.Controls.Add(this.lblWelcome);
            this.panelMain.Controls.Add(this.pnlSearchContainer);
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1920, 1080);
            this.panelMain.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.richTextBox2);
            this.panel1.Controls.Add(this.richTextBox1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(12, 656);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 412);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 30F);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(111, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(375, 57);
            this.label1.TabIndex = 0;
            this.label1.Text = "Command Center";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 30F);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(106, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(380, 57);
            this.label2.TabIndex = 0;
            this.label2.Text = "Total Sales Today";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 30F);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(100, 243);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(391, 57);
            this.label3.TabIndex = 0;
            this.label3.Text = "Total Transactions";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(98, 167);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(393, 73);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(98, 303);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(393, 73);
            this.richTextBox2.TabIndex = 2;
            this.richTextBox2.Text = "";
            // 
            // gridSearchResults
            // 
            this.gridSearchResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridSearchResults.Location = new System.Drawing.Point(618, 656);
            this.gridSearchResults.Name = "gridSearchResults";
            this.gridSearchResults.RowHeadersWidth = 51;
            this.gridSearchResults.RowTemplate.Height = 24;
            this.gridSearchResults.Size = new System.Drawing.Size(1290, 412);
            this.gridSearchResults.TabIndex = 2;
            this.gridSearchResults.Visible = false;
            // 
            // rtbSearch
            // 
            this.rtbSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbSearch.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbSearch.Location = new System.Drawing.Point(10, 10);
            this.rtbSearch.Multiline = false;
            this.rtbSearch.Name = "rtbSearch";
            this.rtbSearch.Size = new System.Drawing.Size(950, 29);
            this.rtbSearch.TabIndex = 3;
            this.rtbSearch.Text = "";
            this.rtbSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rtbSearch_KeyDown);
            // 
            // btnSearch
            // 
            this.btnSearch.BackgroundImage = global::mainsystem.Properties.Resources.Screenshot__973_;
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearch.Location = new System.Drawing.Point(917, 9);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(43, 32);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // pnlSearchContainer
            // 
            this.pnlSearchContainer.BackColor = System.Drawing.Color.White;
            this.pnlSearchContainer.Controls.Add(this.btnSearch);
            this.pnlSearchContainer.Controls.Add(this.rtbSearch);
            this.pnlSearchContainer.Location = new System.Drawing.Point(534, 108);
            this.pnlSearchContainer.Name = "pnlSearchContainer";
            this.pnlSearchContainer.Padding = new System.Windows.Forms.Padding(10);
            this.pnlSearchContainer.Size = new System.Drawing.Size(970, 49);
            this.pnlSearchContainer.TabIndex = 5;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "label4";
            // 
            // AdminLoungeFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdminLoungeFrm";
            this.Text = "AdminLoungeFrm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AdminLoungeFrm_Load);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSearchResults)).EndInit();
            this.pnlSearchContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.DataGridView gridSearchResults;
        private System.Windows.Forms.RichTextBox rtbSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel pnlSearchContainer;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label4;
    }
}