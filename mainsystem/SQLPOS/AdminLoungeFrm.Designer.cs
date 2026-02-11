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
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblTotalTransactions = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rtbSearch = new System.Windows.Forms.TextBox();
            this.lblGrandTotalTransactions = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblGrandTotal = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTotalSales = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblClock = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlSearchContainer = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelMain.SuspendLayout();
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
            this.panelMain.Controls.Add(this.btnSearch);
            this.panelMain.Controls.Add(this.lblTotalTransactions);
            this.panelMain.Controls.Add(this.label2);
            this.panelMain.Controls.Add(this.rtbSearch);
            this.panelMain.Controls.Add(this.lblGrandTotalTransactions);
            this.panelMain.Controls.Add(this.label5);
            this.panelMain.Controls.Add(this.lblGrandTotal);
            this.panelMain.Controls.Add(this.label4);
            this.panelMain.Controls.Add(this.lblTotalSales);
            this.panelMain.Controls.Add(this.label1);
            this.panelMain.Controls.Add(this.lblDate);
            this.panelMain.Controls.Add(this.lblClock);
            this.panelMain.Controls.Add(this.label3);
            this.panelMain.Controls.Add(this.lblWelcome);
            this.panelMain.Controls.Add(this.pnlSearchContainer);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1920, 1080);
            this.panelMain.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.BackgroundImage = global::mainsystem.Properties.Resources.Screenshot__973_;
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearch.Location = new System.Drawing.Point(1461, 168);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(43, 32);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblTotalTransactions
            // 
            this.lblTotalTransactions.AutoSize = true;
            this.lblTotalTransactions.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalTransactions.Font = new System.Drawing.Font("Times New Roman", 30F);
            this.lblTotalTransactions.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblTotalTransactions.Location = new System.Drawing.Point(444, 825);
            this.lblTotalTransactions.Name = "lblTotalTransactions";
            this.lblTotalTransactions.Size = new System.Drawing.Size(391, 57);
            this.lblTotalTransactions.TabIndex = 0;
            this.lblTotalTransactions.Text = "Total Transactions";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 30F);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Location = new System.Drawing.Point(444, 762);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(391, 57);
            this.label2.TabIndex = 0;
            this.label2.Text = "Total Transactions";
            // 
            // rtbSearch
            // 
            this.rtbSearch.Location = new System.Drawing.Point(541, 173);
            this.rtbSearch.Name = "rtbSearch";
            this.rtbSearch.Size = new System.Drawing.Size(898, 22);
            this.rtbSearch.TabIndex = 12;
            this.rtbSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rtbSearch_KeyDown);
            // 
            // lblGrandTotalTransactions
            // 
            this.lblGrandTotalTransactions.AutoSize = true;
            this.lblGrandTotalTransactions.BackColor = System.Drawing.Color.Transparent;
            this.lblGrandTotalTransactions.Font = new System.Drawing.Font("Times New Roman", 30F);
            this.lblGrandTotalTransactions.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblGrandTotalTransactions.Location = new System.Drawing.Point(1124, 825);
            this.lblGrandTotalTransactions.Name = "lblGrandTotalTransactions";
            this.lblGrandTotalTransactions.Size = new System.Drawing.Size(380, 57);
            this.lblGrandTotalTransactions.TabIndex = 0;
            this.lblGrandTotalTransactions.Text = "Total Sales Today";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 30F);
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label5.Location = new System.Drawing.Point(1124, 762);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(527, 57);
            this.label5.TabIndex = 0;
            this.label5.Text = "Grand Total Transactions";
            // 
            // lblGrandTotal
            // 
            this.lblGrandTotal.AutoSize = true;
            this.lblGrandTotal.BackColor = System.Drawing.Color.Transparent;
            this.lblGrandTotal.Font = new System.Drawing.Font("Times New Roman", 30F);
            this.lblGrandTotal.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblGrandTotal.Location = new System.Drawing.Point(1124, 660);
            this.lblGrandTotal.Name = "lblGrandTotal";
            this.lblGrandTotal.Size = new System.Drawing.Size(380, 57);
            this.lblGrandTotal.TabIndex = 0;
            this.lblGrandTotal.Text = "Total Sales Today";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 30F);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label4.Location = new System.Drawing.Point(1124, 597);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(380, 57);
            this.label4.TabIndex = 0;
            this.label4.Text = "Grand Total Sales";
            // 
            // lblTotalSales
            // 
            this.lblTotalSales.AutoSize = true;
            this.lblTotalSales.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalSales.Font = new System.Drawing.Font("Times New Roman", 30F);
            this.lblTotalSales.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblTotalSales.Location = new System.Drawing.Point(444, 660);
            this.lblTotalSales.Name = "lblTotalSales";
            this.lblTotalSales.Size = new System.Drawing.Size(380, 57);
            this.lblTotalSales.TabIndex = 0;
            this.lblTotalSales.Text = "Total Sales Today";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 30F);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(444, 597);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(380, 57);
            this.label1.TabIndex = 0;
            this.label1.Text = "Total Sales Today";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.BackColor = System.Drawing.Color.Transparent;
            this.lblDate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblDate.Location = new System.Drawing.Point(1669, 985);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(55, 22);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "Label";
            // 
            // lblClock
            // 
            this.lblClock.AutoSize = true;
            this.lblClock.BackColor = System.Drawing.Color.Transparent;
            this.lblClock.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClock.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblClock.Location = new System.Drawing.Point(1669, 1013);
            this.lblClock.Name = "lblClock";
            this.lblClock.Size = new System.Drawing.Size(55, 22);
            this.lblClock.TabIndex = 0;
            this.lblClock.Text = "Label";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 30F);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(1345, 429);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 57);
            this.label3.TabIndex = 6;
            // 
            // pnlSearchContainer
            // 
            this.pnlSearchContainer.BackColor = System.Drawing.Color.Gainsboro;
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
            // AdminLoungeFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdminLoungeFrm";
            this.Text = "AdminLoungeFrm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AdminLoungeFrm_Load);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblClock;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox rtbSearch;
        private System.Windows.Forms.Panel pnlSearchContainer;
        private System.Windows.Forms.Label lblTotalSales;
        private System.Windows.Forms.Label lblTotalTransactions;
        private System.Windows.Forms.Label lblGrandTotal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblGrandTotalTransactions;
        private System.Windows.Forms.Label label5;
    }
}