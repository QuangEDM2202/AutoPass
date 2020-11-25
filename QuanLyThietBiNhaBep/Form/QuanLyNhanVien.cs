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
    public partial class QuanLyNhanVien : Form
    {
        public QuanLyNhanVien()
        {
            InitializeComponent();
        }
        String constr = ConfigurationManager.ConnectionStrings["db_qltbnb"].ConnectionString;
        MaHoa maHoa = new MaHoa();

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void QuanLyNhanVien_Load(object sender, EventArgs e)
        {
            load_grid();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtDiaChi.Text.Length != 0 && txtMK.Text.Length != 0 && txtUserNam.Text.Length != 0 && txtTenNV.Text.Length != 0 && txtSDT.Text.Length != 0)
            {
                using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd1 = cnn.CreateCommand())
                {
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.CommandText = "sp_ktraTen";
                    cmd1.Parameters.AddWithValue("@userName", txtUserNam.Text);
                    cnn.Open();
                    int i = (int)cmd1.ExecuteScalar();
                    Debug.WriteLine("constructor fired " + i);
                    if (i == 0)
                    {
                        using (SqlCommand cmd = cnn.CreateCommand())
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "sp_themNhanVien";
                            cmd.Parameters.AddWithValue("@tenTK", txtUserNam.Text);
                            cmd.Parameters.AddWithValue("@mk", maHoa.GetMD5(txtMK.Text));
                            cmd.Parameters.AddWithValue("@tenNV", txtTenNV.Text);
                            cmd.Parameters.AddWithValue("@sdt", txtSDT.Text);
                            cmd.Parameters.AddWithValue("@diachi", txtDiaChi.Text);
                            if (rdNhanVien.Checked == true)
                            {
                                cmd.Parameters.AddWithValue("@quyen", 1);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@quyen", 2);
                            }
                            // cnn.Open();
                            int i_ = cmd.ExecuteNonQuery();
                            if (i_ > 0)
                            {
                                load_grid();
                                xoaTrang();
                                MessageBox.Show("Thêm Nhân Viên Thành Công", "Thông Báo");
                                
                            }

                        }
                    }
                    else
                    {
                        MessageBox.Show("Tên Đăng Nhập Đã Trùng", "Thông Báo");
                    }
                }
            }
            }
            else
            {
                MessageBox.Show("Phải Điền Đủ Dữ Liệu", "Thông Báo");
            }


        }


        private void load_grid()
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_danhSachNhanVien";
                    SqlDataAdapter dap = new SqlDataAdapter(cmd);
                    DataTable data = new DataTable();
                    dap.Fill(data);
                    dataGridView1.DataSource = data;///
                }
            }
            dataGridView1.Columns["iMaNV"].Visible = false;
        }
        private void xoaTrang()
        {
            txtDiaChi.Text = "";
            txtMK.Text = "";
            txtSDT.Text = "";
            txtTenNV.Text = "";
            txtUserNam.Text = "";
        }

        private void btn_Click(object sender, EventArgs e)
        {

            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cnn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_thayDoiTrangThaiNhanVien";
                    cmd.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells["iMaNV"].Value.ToString());
                    cmd.ExecuteNonQuery();
                    load_grid();
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtDiaChi.Text = dataGridView1.CurrentRow.Cells["Địa Chỉ"].Value.ToString();
            txtSDT.Text = dataGridView1.CurrentRow.Cells["SĐT"].Value.ToString();
            txtTenNV.Text = dataGridView1.CurrentRow.Cells["Tên Nhân Viên"].Value.ToString();
            if (String.Compare(dataGridView1.CurrentRow.Cells["Quyền"].Value.ToString(), "Nhân Viên") == 0)
            {
                rdNhanVien.Checked = true;
            }
            {
                rdQuanLy.Checked = true;
            }
            //dataGridView1.CurrentRow.Cells["iMaNV"].Value.ToString();
            //dataGridView1.CurrentRow.Cells["iMaNV"].Value.ToString();

            // dataGridView1.CurrentRow.Cells["iMaNV"].Value.ToString();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Sửa_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            btnThem.Visible = false;
            btnKichHoat.Visible = false;
            Sửa.Visible = false;
            btnCapNhat.Visible = true;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cnn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_capNhatNhanVien_";
                    //cmd.Parameters.AddWithValue("@tenTK", txtUserNam.Text);
                    // cmd.Parameters.AddWithValue("@mk", maHoa.GetMD5(txtMK.Text));
                    cmd.Parameters.AddWithValue("@tenNV", txtTenNV.Text);
                    cmd.Parameters.AddWithValue("@sdt", txtSDT.Text);
                    cmd.Parameters.AddWithValue("@diachi", txtDiaChi.Text);
                    cmd.Parameters.AddWithValue("@manv", dataGridView1.CurrentRow.Cells["iMaNV"].Value.ToString());
                    if (rdNhanVien.Checked == true)
                    {
                        cmd.Parameters.AddWithValue("@quyen", 1);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@quyen", 2);
                    }
                    // cnn.Open();
                    load_grid();
                    int i_ = cmd.ExecuteNonQuery();
                    if (i_ > 0)
                    {
                       
                        load_grid();
                        xoaTrang();
                        panel2.Visible = true;
                        btnThem.Visible = true;
                        btnKichHoat.Visible = true;
                        Sửa.Visible = true;
                        btnCapNhat.Visible = false;
                        xoaTrang();
                        MessageBox.Show("Cập Nhật Nhân Viên Thành Công", "Thông Báo");
                    }
                }

            }
        }
    }
}
