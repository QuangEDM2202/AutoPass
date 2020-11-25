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
    public partial class QuanLyNhomHang : Form
    {
        public QuanLyNhomHang()
        {
            InitializeComponent();
        }
        String constr = ConfigurationManager.ConnectionStrings["db_qltbnb"].ConnectionString;
        private void loadGrid()
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_xemNhomHang";
                    SqlDataAdapter dap = new SqlDataAdapter(cmd);
                    DataTable data = new DataTable();
                    dap.Fill(data);

                    dataGridView1.DataSource = data;
                }
            }
            dataGridView1.Columns["iMaNhomHang"].Visible = false;
        }

        private void QuanLyNhomHang_Load(object sender, EventArgs e)
        {
            loadGrid();
        }


        private void Row_Added(object sender, DataGridViewRowsAddedEventArgs e)
        {
            foreach (DataGridViewRow dtr in dataGridView1.Rows)
            {
                dataGridView1.Rows[e.RowIndex - 1].Cells[0].Value = e.RowIndex;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_themNhomHang";
                    cmd.Parameters.AddWithValue("@tenNhomHang", txtNhomHang.Text);

                    cnn.Open();
                    int i_ = cmd.ExecuteNonQuery();
                    if (i_ > 0)
                    {
                        MessageBox.Show("Thêm Nhóm Hàng Thành Công", "Thông Báo");
                        loadGrid();
                        txtNhomHang.Text = "";
                    }
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có Muốn Xoá Nhóm Hàng :  " + dataGridView1.CurrentRow.Cells["Tên Nhóm Hàng"].Value.ToString(), "Thông Báo",
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
                            cmd.CommandText = "sp_xoaNhomHang";
                            cmd.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells["iMaNhomHang"].Value.ToString());

                            cnn.Open();
                            int i_ = cmd.ExecuteNonQuery();
                            if (i_ > 0)
                            {
                                MessageBox.Show("Xoá Nhóm Hàng Thành Công", "Thông Báo");
                                loadGrid();
                                txtNhomHang.Text = "";
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xoá Nhóm Hàng Không Thành Công", "Thông Báo");
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_suaNhomHang";
                    cmd.Parameters.AddWithValue("@tenNhomHang", txtNhomHang.Text);
                    cmd.Parameters.AddWithValue("@maNhomHang", Convert.ToInt32(dataGridView1.CurrentRow.Cells["iMaNhomHang"].Value.ToString()));

                    cnn.Open();
                    int i_ = cmd.ExecuteNonQuery();
                    if (i_ > 0)
                    {
                        MessageBox.Show("Sửa Nhóm Hàng Thành Công", "Thông Báo");
                        loadGrid();
                        txtNhomHang.Text = "";
                    }
                }
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            txtNhomHang.Text = dataGridView1.CurrentRow.Cells["Tên Nhóm Hàng"].Value.ToString();
        }
    }
}
