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
using System.Web;
using System.IO;

namespace QuanLyThietBiNhaBep
{
    public partial class ChonSanPham : Form
    {
        public ChonSanPham()
        {
            InitializeComponent();
        }


        String constr = ConfigurationManager.ConnectionStrings["db_qltbnb"].ConnectionString;

        private void ChonSanPham_Load(object sender, EventArgs e)
        {
            loadSanPham();
        }

        private void loadSanPham()
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cnn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_xemSanPham";
                    SqlDataAdapter dap = new SqlDataAdapter(cmd);
                    DataTable dataSanPham = new DataTable();
                    dap.Fill(dataSanPham);
                    dataGridView1.DataSource = dataSanPham;





                }
            }
            dataGridView1.Columns["iMaSanPham"].Visible = false;
            dataGridView1.Columns["shinhanh"].Visible = false;
        }

        private void txtTenSP_KeyPress(object sender, KeyPressEventArgs e)
        {
            timKiemTheoTen();
        }

        void timKiemTheoTen()
        {

            string filter = "select ROW_NUMBER() OVER(ORDER BY imasanpham) AS  STT, iMaSanPham,'SP' + CONVERT(varchar(10), iMaSanPham)  as N'Mã Sản Phẩm', sTenSanPham as N'Tên Sản Phẩm', sXuatXu as N'Xuất Xứ', stennhomhang as N'Nhóm Hàng', sMoTa as N'Mô Tả' from tblSanPham, tblNhomHang where tblNhomHang.iMaNhomHang = tblSanPham.iMaNhomHang";

           
                filter += string.Format(" AND sTenSanPham LIKE '%{0}%'", txtTenSP.Text);
          

            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cnn.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = filter;
                    SqlDataAdapter dap = new SqlDataAdapter(cmd);
                    DataTable data = new DataTable();
                    dap.Fill(data);

                    dataGridView1.DataSource = data;
                }
            }
            dataGridView1.Columns["iMaSanPham"].Visible = false;
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            try
            {
                TaoDonNhapHang f1 = (TaoDonNhapHang)Application.OpenForms["TaoDonNhapHang"];
                ComboBox cbb = (ComboBox)f1.Controls["cbbSanPham"];
                using (SqlConnection cnn = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = cnn.CreateCommand())
                    {
                        cnn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "sp_xemSanPhamChoCCB";
                        SqlDataAdapter dap = new SqlDataAdapter(cmd);
                        DataTable data = new DataTable();
                        dap.Fill(data);
                        cbb.DataSource = data;
                        cbb.ValueMember = "iMaSanPham";
                        cbb.DisplayMember = "sTenSanPham";
                    }
                }
               
                cbb.SelectedValue = dataGridView1.CurrentRow.Cells["iMaSanPham"].Value.ToString();
                this.Hide();
            }
            catch(Exception ex)
            {

            }
        }

        private void txtMa_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
        }

        private void txtMa_KeyUp(object sender, KeyEventArgs e)
        {
            
            string filter = "select ROW_NUMBER() OVER(ORDER BY imasanpham) AS  STT, iMaSanPham,'SP' + CONVERT(varchar(10), iMaSanPham)  as N'Mã Sản Phẩm', sTenSanPham as N'Tên Sản Phẩm', sXuatXu as N'Xuất Xứ', stennhomhang as N'Nhóm Hàng', sMoTa as N'Mô Tả' from tblSanPham, tblNhomHang where tblNhomHang.iMaNhomHang = tblSanPham.iMaNhomHang";

            if (txtMa.Text.Length != 0)
            {
                filter += " AND imasanpham = " + txtMa.Text;
            }


            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cnn.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = filter;
                    SqlDataAdapter dap = new SqlDataAdapter(cmd);
                    DataTable data = new DataTable();
                    dap.Fill(data);

                    dataGridView1.DataSource = data;
                }
            }
            dataGridView1.Columns["iMaSanPham"].Visible = false;
        }

        private void txtMa_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
