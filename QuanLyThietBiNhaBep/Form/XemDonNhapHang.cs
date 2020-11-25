using System;
using System.Collections.Generic;
using QuanLyThietBiNhaBep.Function;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using QuanLyThietBiNhaBep;
using System.Diagnostics;



namespace QuanLyThietBiNhaBep
{
    public partial class XemDonNhapHang : Form
    {

        public String maDonNhapHang = "";
        public String ngayNhap = "";
        //public String hdNhap = "";
        public String nvNhap = "";
        String constr = ConfigurationManager.ConnectionStrings["db_qltbnb"].ConnectionString;

        public XemDonNhapHang()
        {
            InitializeComponent();
        }

        private void XemDonNhapHang_Load(object sender, EventArgs e)
        {
            loadDonNhapHang();
            lblNgay.Text = "Thời gian: " + ngayNhap;
            lblHDN.Text = "Đơn Nhập DNH" + maDonNhapHang;
            lblnv.Text = "Nhân Viên " + nvNhap;
        }

        private void loadDonNhapHang()
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cnn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_xemDonNhapHangTheoMa";
                    cmd.Parameters.AddWithValue("@madon", maDonNhapHang);
                    SqlDataAdapter dap = new SqlDataAdapter(cmd);
                    DataTable data = new DataTable();
                    dap.Fill(data);

                    dataGridView1.DataSource = data;
                }
            }

            Debug.WriteLine("Ma don nhan dc: " + maDonNhapHang);
            //dataGridView1.Columns[""].Visible = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SuaPhieuNhapHang f = new SuaPhieuNhapHang();
            f.iMaDonNhap = maDonNhapHang;
            f.Show();
        }
    } 
}
