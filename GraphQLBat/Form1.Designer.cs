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
            this.btn_JSONtoCSV.Location = new System.Drawing.Point(642, 253);
            this.btn_JSONtoCSV.Name = "btn_JSONtoCSV";
            this.btn_JSONtoCSV.Size = new System.Drawing.Size(116, 23);
            this.btn_JSONtoCSV.TabIndex = 10;
            this.btn_JSONtoCSV.Text = "JSON to CSV";
            this.btn_JSONtoCSV.UseVisualStyleBackColor = true;
            this.btn_JSONtoCSV.Click += new System.EventHandler(this.Btn_JSONtoCSV_Click);
            // 
            // lbl_totalrec
            // 
            this.lbl_totalrec.AutoSize = true;
            this.lbl_totalrec.Location = new System.Drawing.Point(624, 76);
            this.lbl_totalrec.Name = "lbl_totalrec";
            this.lbl_totalrec.Size = new System.Drawing.Size(80, 13);
            this.lbl_totalrec.TabIndex = 11;
            this.lbl_totalrec.Text = "Total Records :";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
    }
}