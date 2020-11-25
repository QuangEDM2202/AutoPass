namespace QuanLyThietBiNhaBep
{
    partial class SuaPhieuNhapHang
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbbSanPham = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.btnThemSanPham = new System.Windows.Forms.Button();
            this.btnHuySanPham = new System.Windows.Forms.Button();
            this.btnThayDoiSoLuonf = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtGiaNhap = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(675, 322);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 366);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Chọn Sản Phẩm:";
            // 
            // cbbSanPham
            // 
            this.cbbSanPham.FormattingEnabled = true;
            this.cbbSanPham.Location = new System.Drawing.Point(169, 363);
            this.cbbSanPham.Name = "cbbSanPham";
            this.cbbSanPham.Size = new System.Drawing.Size(341, 21);
            this.cbbSanPham.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(67, 406);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Số Lượng:";
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(169, 406);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(100, 20);
            this.txtSoLuong.TabIndex = 4;
            this.txtSoLuong.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoLuong_KeyPress);
            // 
            // btnThemSanPham
            // 
            this.btnThemSanPham.Location = new System.Drawing.Point(70, 493);
            this.btnThemSanPham.Name = "btnThemSanPham";
            this.btnThemSanPham.Size = new System.Drawing.Size(134, 23);
            this.btnThemSanPham.TabIndex = 5;
            this.btnThemSanPham.Text = "Thêm Vào Đơn Nhâp Hàng";
            this.btnThemSanPham.UseVisualStyleBackColor = true;
            this.btnThemSanPham.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnHuySanPham
            // 
            this.btnHuySanPham.Location = new System.Drawing.Point(412, 493);
            this.btnHuySanPham.Name = "btnHuySanPham";
            this.btnHuySanPham.Size = new System.Drawing.Size(134, 23);
            this.btnHuySanPham.TabIndex = 6;
            this.btnHuySanPham.Text = "Huỷ Bỏ Sản Phẩm";
            this.btnHuySanPham.UseVisualStyleBackColor = true;
            this.btnHuySanPham.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnThayDoiSoLuonf
            // 
            this.btnThayDoiSoLuonf.Location = new System.Drawing.Point(257, 493);
            this.btnThayDoiSoLuonf.Name = "btnThayDoiSoLuonf";
            this.btnThayDoiSoLuonf.Size = new System.Drawing.Size(134, 23);
            this.btnThayDoiSoLuonf.TabIndex = 7;
            this.btnThayDoiSoLuonf.Text = "Cập Nhật";
            this.btnThayDoiSoLuonf.UseVisualStyleBackColor = true;
            this.btnThayDoiSoLuonf.Click += new System.EventHandler(this.btnThayDoiSoLuonf_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(67, 447);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Giá Nhập:";
            // 
            // txtGiaNhap
            // 
            this.txtGiaNhap.Location = new System.Drawing.Point(169, 447);
            this.txtGiaNhap.Name = "txtGiaNhap";
            this.txtGiaNhap.Size = new System.Drawing.Size(100, 20);
            this.txtGiaNhap.TabIndex = 9;
            this.txtGiaNhap.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGiaNhap_KeyPress);
            // 
            // SuaPhieuNhapHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 528);
            this.Controls.Add(this.txtGiaNhap);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnThayDoiSoLuonf);
            this.Controls.Add(this.btnHuySanPham);
            this.Controls.Add(this.btnThemSanPham);
            this.Controls.Add(this.txtSoLuong);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbbSanPham);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "SuaPhieuNhapHang";
            this.Text = "Sửa Phiếu Nhập Hàng";
            this.Load += new System.EventHandler(this.SuaPhieuNhapHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbSanPham;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.Button btnThemSanPham;
        private System.Windows.Forms.Button btnHuySanPham;
        private System.Windows.Forms.Button btnThayDoiSoLuonf;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtGiaNhap;
    }
}