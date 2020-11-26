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
    public partial class QuanLySanPham : Form
    {
        public QuanLySanPham()
        {
            InitializeComponent();
        }

        String constr = ConfigurationManager.ConnectionStrings["db_qltbnb"].ConnectionString;
        string tenHinhSP = "";
        public int ktra = 0;


        private void btnThem_Click(object sender, EventArgs e)
        {

            if (txtTenSanPham.Text.Length != 0 && txtXuatXu.Text.Length != 0 && txtKichThuoc.Text.Length != 0 && txtGiaBan.Text.Length != 0)
            {
                if (int.Parse(txtGiaBan.Text) <= 0)
                {
                    MessageBox.Show("Giá bán không được nhỏ hơn 0");

                    return;
                }

                if (int.Parse(txtKichThuoc.Text) <= 0)
                {
                    MessageBox.Show("Kích thước không được phép nhỏ hơn 0");

                    return;
                }

                string filter = "select sTenSanPham as N'Tên Sản Phẩm' from tblSanPham, tblNhomHang where tblNhomHang.iMaNhomHang = tblSanPham.iMaNhomHang and sTenSanPham = '" + txtTenSanPham.Text + "'";

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

                        if (data.Rows.Count > 0)
                        {
                            MessageBox.Show("Tên sản phẩm đã tồn tại");

                            return;
                        }
                    }
                }


                using (SqlConnection cnn = new SqlConnection(constr))
                {


                    using (SqlCommand cmd = cnn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "sp_themSanPham";
                        cmd.Parameters.AddWithValue("@sTenSanPham", txtTenSanPham.Text);
                        cmd.Parameters.AddWithValue("@sXuatXu", txtXuatXu.Text);
                        cmd.Parameters.AddWithValue("@iMaNhomHang", ccbNhomSanPham.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@sKichThuoc", txtKichThuoc.Text);
                        cmd.Parameters.AddWithValue("@sMoTa", txtMota.Text);
                        //cmd.Parameters.AddWithValue("@gia", txtGia.Text);
                        cmd.Parameters.AddWithValue("@giaban", txtGiaBan.Text);
                        cmd.Parameters.AddWithValue("@baohanh", txtBaoHanh.Text);
                        if (tenHinhSP.Length == 0)
                        {
                            cmd.Parameters.AddWithValue("@hinhanh", "sp.jpg");
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@hinhanh", tenHinhSP);
                        }
                        cnn.Open();
                        int i_ = cmd.ExecuteNonQuery();
                        if (i_ > 0)
                        {
                            MessageBox.Show("Thêm Sản Phẩm Thành Công", "Thông Báo");
                            loadSanPham();
                            xoaTrang();
                            tenHinhSP = "";
                            pictureBox1.Image = null;
                            capNhapCbbSanPham(1);
                        }

                    }
                }
            }
            else
            {
                MessageBox.Show("Phải Điền Đủ Dữ Liệu", "Thông Báo");
            }
        }

        private void QuanLySanPham_Load(object sender, EventArgs e)
        {
            loadNhomHang();
            loadSanPham();
        }

        private void xoaTrang()
        {
            //  txtGia.Text = "";
            txtKichThuoc.Text = "";
            txtMota.Text = "";
            txtTenSanPham.Text = "";
            txtXuatXu.Text = "";
            txtBaoHanh.Text = "";
            txtGiaBan.Text = "";
            pictureBox1.Image = null;
        }

        private void loadNhomHang()
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cnn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_xemNhomHang";
                    SqlDataAdapter dap = new SqlDataAdapter(cmd);
                    DataTable data = new DataTable();
                    dap.Fill(data);

                    ccbNhomSanPham.DataSource = data;
                    ccbNhomSanPham.ValueMember = "iMaNhomHang";
                    ccbNhomSanPham.DisplayMember = "Tên Nhóm Hàng";
                }
            }
            //  dataGridView1.Columns["iMaNhomHang"].Visible = false;
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




        private void btnXoaTrang_Click(object sender, EventArgs e)
        {
            xoaTrang();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtTenSanPham.Text = dataGridView1.CurrentRow.Cells["Tên Sản Phẩm"].Value.ToString();
            txtXuatXu.Text = dataGridView1.CurrentRow.Cells["Xuất Xứ"].Value.ToString();
            txtMota.Text = dataGridView1.CurrentRow.Cells["Mô Tả"].Value.ToString();
            txtKichThuoc.Text = dataGridView1.CurrentRow.Cells["Kích Thước"].Value.ToString();
            //txtGia.Text = dataGridView1.CurrentRow.Cells["Giá Bán"].Value.ToString();
            ccbNhomSanPham.Text = dataGridView1.CurrentRow.Cells["Nhóm Hàng"].Value.ToString();
            txtGiaBan.Text = dataGridView1.CurrentRow.Cells["Giá Bán"].Value.ToString();
            txtBaoHanh.Text = dataGridView1.CurrentRow.Cells["Bảo Hành(tháng)"].Value.ToString();

            string appPath = Path.GetDirectoryName(Application.ExecutablePath) + @"\HinhSanPham\";
            pictureBox1.Image = Image.FromFile(@appPath + dataGridView1.CurrentRow.Cells["shinhanh"].Value.ToString());
            Debug.WriteLine("hinh " + dataGridView1.CurrentRow.Cells["shinhanh"].Value.ToString());
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_suaSanPham";
                    cmd.Parameters.AddWithValue("@sTenSanPham", txtTenSanPham.Text);
                    cmd.Parameters.AddWithValue("@sXuatXu", txtXuatXu.Text);
                    cmd.Parameters.AddWithValue("@iMaNhomHang", ccbNhomSanPham.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@sKichThuoc", txtKichThuoc.Text);
                    cmd.Parameters.AddWithValue("@sMoTa", txtMota.Text);
                    // cmd.Parameters.AddWithValue("@gia", txtGia.Text);
                    cmd.Parameters.AddWithValue("@giaban", txtGiaBan.Text);
                    cmd.Parameters.AddWithValue("@baohanh", txtBaoHanh.Text);
                    cmd.Parameters.AddWithValue("@imaSanPham", dataGridView1.CurrentRow.Cells["iMaSanPham"].Value.ToString());
                    if (tenHinhSP.Length == 0)
                    {
                        cmd.Parameters.AddWithValue("@hinhanh", "sp.jpg");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@hinhanh", tenHinhSP);
                    }
                    cnn.Open();
                    int i_ = cmd.ExecuteNonQuery();
                    if (i_ > 0)
                    {
                        MessageBox.Show("Sửa Sản Phẩm Thành Công", "Thông Báo");
                        loadSanPham();
                        xoaTrang();
                    }

                }
            }
        }



        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có Muốn Xoá Sản Phẩm :  " + dataGridView1.CurrentRow.Cells["Tên Sản Phẩm"].Value.ToString(), "Thông Báo",
     MessageBoxButtons.YesNo, MessageBoxIcon.Question,
     MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection cnn = new SqlConnection(constr))
                    {
                        using (SqlCommand cmd = cnn.CreateCommand())
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "sp_xoaSanPham";
                            cmd.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells["iMaSanPham"].Value.ToString());

                            cnn.Open();
                            int i_ = cmd.ExecuteNonQuery();
                            if (i_ > 0)
                            {
                                MessageBox.Show("Xoá Sản Phẩm Thành Công", "Thông Báo");
                                loadSanPham();
                                // txtNhomHang.Text = "";
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xoá Sản Phẩm Không Thành Công", "Thông Báo");
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {

            string filter = "select iMaSanPham, sTenSanPham as N'Tên Sản Phẩm', sKichThuoc as N'Kích Thước', sXuatXu as N'Xuất Xứ',stennhomhang as N'Nhóm Hàng', sMoTa as N'Mô Tả' from tblSanPham, tblNhomHang where tblNhomHang.iMaNhomHang = tblSanPham.iMaNhomHang ";

            if (txtTenSanPham.Text != string.Empty)
            {
                filter += string.Format(" AND sTenSanPham LIKE '%{0}%'", txtTenSanPham.Text);
            }
            if (txtXuatXu.Text != string.Empty)
            {
                filter += string.Format(" AND sXuatXu LIKE '%{0}%'", txtXuatXu.Text);
            }
            if (txtMota.Text != string.Empty)
            {
                filter += string.Format(" AND sMoTa LIKE '%{0}%'", txtMota.Text);
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

        private void label7_Click(object sender, EventArgs e)
        {

        }



        private void txtGiaBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
        }

        private void txtBaoHanh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
        }


        private void btnChonHinh_Click(object sender, EventArgs e)
        {
            OpenFileDialog opFile = new OpenFileDialog();
            opFile.Title = "Select a Image";
            opFile.Filter = "jpg files (*.jpg)|*.jpg|All files (*.*)|*.*";

            string appPath = Path.GetDirectoryName(Application.ExecutablePath) + @"\HinhSanPham\";
            if (Directory.Exists(appPath) == false)
            {
                Directory.CreateDirectory(appPath);
            }

            if (opFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    tenHinhSP = opFile.SafeFileName;   // <---
                    string filepath = opFile.FileName;    // <---
                    File.Copy(filepath, appPath + tenHinhSP); // <---
                    pictureBox1.Image = new Bitmap(opFile.OpenFile());

                    Debug.WriteLine("link : " + appPath + tenHinhSP);
                    //C:\Users\Admin\documents\visual studio 2015\Projects\QuanLyThietBiNhaBep\QuanLyThietBiNhaBep\bin\Debug\ProImages\78cb90ece846d05ec66c9ff6f2023cb7.jpg
                }
                catch (Exception exp)
                {
                    //   MessageBox.Show("Không  Mở  Được: "
                    Debug.WriteLine("loi : " + exp.Message);
                }
            }
            else
            {
                opFile.Dispose();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        void capNhapCbbSanPham(int i)
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
                        if (ktra == 1)
                        {
                            this.Hide();
                        }
                        //   cbb.SelectedValue = i;
                    }
                }

                // cbb.SelectedValue = dataGridView1.CurrentRow.Cells["iMaSanPham"].Value.ToString();
                //
            }
            catch (Exception ex)
            {

            }
        }

        private void btnTimTheoKhoangGia_Click(object sender, EventArgs e)
        {
            string filter = "select iMaSanPham, sTenSanPham as N'Tên Sản Phẩm', sKichThuoc as N'Kích Thước', sXuatXu as N'Xuất Xứ',stennhomhang as N'Nhóm Hàng', sMoTa as N'Mô Tả' from tblSanPham, tblNhomHang where tblNhomHang.iMaNhomHang = tblSanPham.iMaNhomHang ";

            filter = filter + "and iGiaBan >= " + txtTuGia.Text + "AND iGiaBan <= " + txtToiGia.Text;

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
    }
}
