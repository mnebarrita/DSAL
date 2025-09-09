namespace Lesson2
{
    partial class Activity_4_PrintFrm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.printdisplayListbox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(681, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bakla ako";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Niagara Engraved", 30F);
            this.label2.Location = new System.Drawing.Point(113, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(429, 54);
            this.label2.TabIndex = 1;
            this.label2.Text = "MIFLO FOOD ORDERING APPLICATION";
            // 
            // printdisplayListbox
            // 
            this.printdisplayListbox.FormattingEnabled = true;
            this.printdisplayListbox.ItemHeight = 16;
            this.printdisplayListbox.Location = new System.Drawing.Point(25, 66);
            this.printdisplayListbox.Name = "printdisplayListbox";
            this.printdisplayListbox.Size = new System.Drawing.Size(627, 580);
            this.printdisplayListbox.TabIndex = 2;
            // 
            // Activity_4_PrintFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 654);
            this.Controls.Add(this.printdisplayListbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Activity_4_PrintFrm";
            this.Text = "Activity_4_PrintFrm";
            this.Load += new System.EventHandler(this.Activity_4_PrintFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ListBox printdisplayListbox;
    }
}