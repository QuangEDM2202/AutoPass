namespace QuanLyThietBiNhaBep
{
    partial class XemDonNhapHang
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.lblHDN = new System.Windows.Forms.Label();
            this.lblnv = new System.Windows.Forms.Label();
            this.lblNgay = new System.Windows.Forms.Label();
            this.btnSua = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(1, 46);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(682, 295);
            this.dataGridView1.TabIndex = 0;
            // 
            // lblHDN
            // 
            this.lblHDN.AutoSize = true;
            this.lblHDN.Location = new System.Drawing.Point(23, 20);
            this.lblHDN.Name = "lblHDN";
            this.lblHDN.Size = new System.Drawing.Size(35, 13);
            this.lblHDN.TabIndex = 1;
            this.lblHDN.Text = "label1";
            // 
            // lblnv
            // 
            this.lblnv.AutoSize = true;
            this.lblnv.Location = new System.Drawing.Point(266, 20);
            this.lblnv.Name = "lblnv";
            this.lblnv.Size = new System.Drawing.Size(35, 13);
            this.lblnv.TabIndex = 2;
            this.lblnv.Text = "label2";
            // 
            // lblNgay
            // 
            this.lblNgay.AutoSize = true;
            this.lblNgay.Location = new System.Drawing.Point(517, 20);
            this.lblNgay.Name = "lblNgay";
            this.lblNgay.Size = new System.Drawing.Size(35, 13);
            this.lblNgay.TabIndex = 3;
            this.lblNgay.Text = "label3";
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(269, 374);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(119, 23);
            this.btnSua.TabIndex = 4;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // XemDonNhapHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 409);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.lblNgay);
            this.Controls.Add(this.lblnv);
            this.Controls.Add(this.lblHDN);
            this.Controls.Add(this.dataGridView1);
            this.Name = "XemDonNhapHang";
            this.Text = "XemDonNhapHang";
            this.Load += new System.EventHandler(this.XemDonNhapHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label lblHDN;
        private System.Windows.Forms.Label lblnv;
        private System.Windows.Forms.Label lblNgay;
        private System.Windows.Forms.Button btnSua;
    }
}