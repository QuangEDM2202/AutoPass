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
    public partial class TaoDonNhapHang : Form
    {
        public TaoDonNhapHang()
        {
            InitializeComponent();
        }


        String constr = ConfigurationManager.ConnectionStrings["db_qltbnb"].ConnectionString;
        String iMaDonNhap;

        private void TaoDonNhapHang_Load(object sender, EventArgs e)
        {
            loadSanPham();
            taoDonNhap();
            //btnThaySoLuong_.Visible = false;
            txtSoLuong.Text = "";
        }


        private void loadSanPham()
        {
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
                    cbbSanPham.DataSource = data;
                    cbbSanPham.ValueMember = "iMaSanPham";
                    cbbSanPham.DisplayMember = "sTenSanPham";
                }
            }
        }

        private void taoDonNhap()
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cnn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_taodonnhaphang";
                    cmd.Parameters.AddWithValue("@iMaNhanVien", Session.SessionMaNV);
                    cmd.Parameters.AddWithValue("@thoigian", DateTime.Now);
                    cmd.Parameters.AddWithValue("@imadonnhap", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    iMaDonNhap = cmd.Parameters["@imadonnhap"].Value.ToString();
                    loadGrid();
                    Debug.WriteLine("Ma don vua tao: " + iMaDonNhap);

                }

            }
        }

        private void cbbSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }


        private void loadGrid()
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cnn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_xemDonNhapHang_";
                    cmd.Parameters.AddWithValue("@iMaDon", iMaDonNhap);

                    SqlDataAdapter dap = new SqlDataAdapter(cmd);
                    DataTable data = new DataTable();
                    dap.Fill(data);
                    dataGridView1.DataSource = data;
                    dataGridView1.Columns["iMaSanPham"].Visible = false;



                }

            }
        }


        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {  ///them chi tiet don nhap
            if (ktraSanPhamNhapDon())
            {
                using (SqlConnection cnn = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = cnn.CreateCommand())
                    {
                        cnn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "sp_themChiTietDonNhap";
                        cmd.Parameters.AddWithValue("@imasanpham", cbbSanPham.SelectedValue);
                        cmd.Parameters.AddWithValue("@isoluong", txtSoLuong.Text);
                        cmd.Parameters.AddWithValue("@imadon", iMaDonNhap);
                        cmd.Parameters.AddWithValue("@igianhap", txtGiaNhap.Text);
                        int i = cmd.ExecuteNonQuery();

                        if (i > 0)
                        {
                            loadGrid();
                            txtSoLuong.Text = "0";
                        }
                        //  Debug.WriteLine("Ma don vua tao: " + iMaDonNhap);

                    }

                }
            }
            else
            {
                MessageBox.Show("Sản Phẩm Đã CÓ.", "Thông Báo");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cnn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_xoaSanPhamKhoiDon";
                    cmd.Parameters.AddWithValue("@idDon", iMaDonNhap);
                    cmd.Parameters.AddWithValue("@idSanPham", dataGridView1.CurrentRow.Cells["iMaSanPham"].Value.ToString());
                    // cmd.Parameters.AddWithValue("@imadon", iMaDonNhap);
                    int i = cmd.ExecuteNonQuery();

                    if (i > 0)
                    {
                        loadGrid();
                        txtSoLuong.Text = "0";
                    }
                    //  Debug.WriteLine("Ma don vua tao: " + iMaDonNhap);

                }
            }
        }

        private void btnThayDoiSoLuonf_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = cnn.CreateCommand())
                    {
                        cnn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "sp_capNhatchitietnhaphang";
                        cmd.Parameters.AddWithValue("@idDon", iMaDonNhap);
                        cmd.Parameters.AddWithValue("@idSanPham", dataGridView1.CurrentRow.Cells["iMaSanPham"].Value.ToString());
                        cmd.Parameters.AddWithValue("@isoluong", txtSoLuong.Text);
                        cmd.Parameters.AddWithValue("@igianhap", txtGiaNhap.Text);
                        int i = cmd.ExecuteNonQuery();

                        if (i > 0)
                        {
                            loadGrid();
                            txtSoLuong.Text = "";
                            txtGiaNhap.Text = "";
                            //label1.Visible = true;
                            //cbbSanPham.Visible = true;
                            //btnHuySanPham.Visible = true;
                            //btnThemSanPham.Visible = true;
                            //btnThaySoLuong_.Visible = false;
                            //txtSoLuong.Text = "0";
                        }
                        //  Debug.WriteLine("Ma don vua tao: " + iMaDonNhap);

                    }
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtSoLuong.Text = dataGridView1.CurrentRow.Cells["Số Lượng"].Value.ToString();
           txtGiaNhap.Text = dataGridView1.CurrentRow.Cells["Giá Nhập"].Value.ToString();
        }

        private void btnThaySoLuong__Click(object sender, EventArgs e)
        {
           
        }

        private bool ktraSanPhamNhapDon()
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cnn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_ktraSanPhamNhapDon";
                    cmd.Parameters.AddWithValue("@idDon", iMaDonNhap);
                    cmd.Parameters.AddWithValue("@idSanPham", cbbSanPham.SelectedValue);
                    SqlDataAdapter dap = new SqlDataAdapter(cmd);
                    DataTable data = new DataTable();
                    dap.Fill(data);
                    if (data.Rows.Count > 0)
                    {
                        return false;

                    }
                    else
                        return true;


                }
            }
        }


        private void txtGiaNhap_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            ChonSanPham f = new ChonSanPham();
            f.MdiParent = this.MdiParent;
            f.Show();
        }

        private void TaoDonNhapHang_FormClosed(object sender, FormClosedEventArgs e)
        {
            xoaDonBan();
           
            this.Hide();
        }

        void xoaDonBan()
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cnn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_xoadonnhap";
                    cmd.Parameters.AddWithValue("@id", iMaDonNhap);
                    int i = cmd.ExecuteNonQuery();
                }
            }
        }

        private void btnHoanThanh_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnThemMoiSanPham_Click(object sender, EventArgs e)
        {
            QuanLySanPham qly = new QuanLySanPham();
            qly.ktra = 1;
            qly.MdiParent = this.MdiParent;
            qly.Show();
        }
    }
}
