namespace GraphQLBat
{
    partial class Form1
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
        public void InitializeComponent()
        {
            this.gridViewTest = new System.Windows.Forms.DataGridView();
            this.dtp_StartDate = new System.Windows.Forms.DateTimePicker();
            this.dtp_EndDate = new System.Windows.Forms.DateTimePicker();
            this.Lbl_StartDate = new System.Windows.Forms.Label();
            this.Lbl_EndDate = new System.Windows.Forms.Label();
            this.btn_JSONtoCSV = new System.Windows.Forms.Button();
            this.lbl_totalrec = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_close = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_totalRec_nextday = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTest)).BeginInit();
            this.SuspendLayout();
            // 
            // gridViewTest
            // 
            this.gridViewTest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridViewTest.Location = new System.Drawing.Point(23, 97);
            this.gridViewTest.Name = "gridViewTest";
            this.gridViewTest.Size = new System.Drawing.Size(735, 150);
            this.gridViewTest.TabIndex = 0;
            // 
            // dtp_StartDate
            // 
            this.dtp_StartDate.CustomFormat = "";
            this.dtp_StartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_StartDate.Location = new System.Drawing.Point(114, 38);
            this.dtp_StartDate.Name = "dtp_StartDate";
            this.dtp_StartDate.Size = new System.Drawing.Size(200, 20);
            this.dtp_StartDate.TabIndex = 1;
            // 
            // dtp_EndDate
            // 
            this.dtp_EndDate.CustomFormat = "";
            this.dtp_EndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_EndDate.Location = new System.Drawing.Point(114, 70);
            this.dtp_EndDate.Name = "dtp_EndDate";
            this.dtp_EndDate.Size = new System.Drawing.Size(200, 20);
            this.dtp_EndDate.TabIndex = 2;
            // 
            // Lbl_StartDate
            // 
            this.Lbl_StartDate.AutoSize = true;
            this.Lbl_StartDate.Location = new System.Drawing.Point(35, 44);
            this.Lbl_StartDate.Name = "Lbl_StartDate";
            this.Lbl_StartDate.Size = new System.Drawing.Size(55, 13);
            this.Lbl_StartDate.TabIndex = 3;
            this.Lbl_StartDate.Text = "Start Date";
            // 
            // Lbl_EndDate
            // 
            this.Lbl_EndDate.AutoSize = true;
            this.Lbl_EndDate.Location = new System.Drawing.Point(35, 70);
            this.Lbl_EndDate.Name = "Lbl_EndDate";
            this.Lbl_EndDate.Size = new System.Drawing.Size(52, 13);
            this.Lbl_EndDate.TabIndex = 4;
            this.Lbl_EndDate.Text = "End Date";
            // 
            // btn_JSONtoCSV
            // 
            this.btn_JSONtoCSV.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btn_JSONtoCSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_JSONtoCSV.Location = new System.Drawing.Point(495, 259);
            this.btn_JSONtoCSV.Name = "btn_JSONtoCSV";
            this.btn_JSONtoCSV.Size = new System.Drawing.Size(144, 41);
            this.btn_JSONtoCSV.TabIndex = 10;
            this.btn_JSONtoCSV.Text = "Download CSV file";
            this.btn_JSONtoCSV.UseVisualStyleBackColor = false;
            this.btn_JSONtoCSV.Click += new System.EventHandler(this.Btn_JSONtoCSV_Click);
            // 
            // lbl_totalrec
            // 
            this.lbl_totalrec.AutoSize = true;
            this.lbl_totalrec.Location = new System.Drawing.Point(543, 58);
            this.lbl_totalrec.Name = "lbl_totalrec";
            this.lbl_totalrec.Size = new System.Drawing.Size(80, 13);
            this.lbl_totalrec.TabIndex = 11;
            this.lbl_totalrec.Text = "Total Records :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 25);
            this.label1.TabIndex = 12;
            this.label1.Text = "Delivery Orders";
            // 
            // btn_close
            // 
            this.btn_close.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btn_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_close.Location = new System.Drawing.Point(655, 259);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(103, 41);
            this.btn_close.TabIndex = 13;
            this.btn_close.Text = "Close";
            this.btn_close.UseVisualStyleBackColor = false;
            this.btn_close.Click += new System.EventHandler(this.Btn_close_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(492, 303);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "* \"Next Day Delivery\" only";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 250);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(324, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Above is raw JSON, please refer to processed result in CSV instead";
            // 
            // lbl_totalRec_nextday
            // 
            this.lbl_totalRec_nextday.AutoSize = true;
            this.lbl_totalRec_nextday.Location = new System.Drawing.Point(543, 77);
            this.lbl_totalRec_nextday.Name = "lbl_totalRec_nextday";
            this.lbl_totalRec_nextday.Size = new System.Drawing.Size(173, 13);
            this.lbl_totalRec_nextday.TabIndex = 16;
            this.lbl_totalRec_nextday.Text = "Filtered Records (Next Day Deliv.) :";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbl_totalRec_nextday);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_totalrec);
            this.Controls.Add(this.btn_JSONtoCSV);
            this.Controls.Add(this.Lbl_EndDate);
            this.Controls.Add(this.Lbl_StartDate);
            this.Controls.Add(this.dtp_EndDate);
            this.Controls.Add(this.dtp_StartDate);
            this.Controls.Add(this.gridViewTest);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTest)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridViewTest;
        private System.Windows.Forms.DateTimePicker dtp_StartDate;
        private System.Windows.Forms.DateTimePicker dtp_EndDate;
        private System.Windows.Forms.Label Lbl_StartDate;
        private System.Windows.Forms.Label Lbl_EndDate;
        private System.Windows.Forms.Button btn_JSONtoCSV;
        private System.Windows.Forms.Label lbl_totalrec;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_totalRec_nextday;
    }
}