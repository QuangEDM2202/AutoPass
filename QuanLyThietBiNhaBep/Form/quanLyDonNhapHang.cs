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
    public partial class quanLyPhieuNhapHang : Form
    {
        public quanLyPhieuNhapHang()
        {
            InitializeComponent();
        }

        String constr = ConfigurationManager.ConnectionStrings["db_qltbnb"].ConnectionString;

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void quanLyPhieuNhapHang_Load(object sender, EventArgs e)
        {
            loadGrid();
        }

        private void loadGrid()
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cnn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_xemDonNhapHang";
                    SqlDataAdapter dap = new SqlDataAdapter(cmd);
                    DataTable data = new DataTable();
                    dap.Fill(data);

                    dataGridView1.DataSource = data;
                }
            }
            dataGridView1.Columns["iMaDonNhapHang"].Visible = false;
        }

        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            XemDonNhapHang f = new XemDonNhapHang();
            f.nvNhap = dataGridView1.CurrentRow.Cells["Tên Nhân Viên Lập Đơn"].Value.ToString();
            f.maDonNhapHang = dataGridView1.CurrentRow.Cells["iMaDonNhapHang"].Value.ToString();
            f.ngayNhap = dataGridView1.CurrentRow.Cells["Thời Gian"].Value.ToString();
            f.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có Muốn Xoá KHông Đơn Mã DNH" + dataGridView1.CurrentRow.Cells["iMaDonNhapHang"].Value.ToString(), "Thông Báo",
      MessageBoxButtons.YesNo, MessageBoxIcon.Question,
      MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                using (SqlConnection cnn = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = cnn.CreateCommand())
                    {
                        cnn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "sp_xoadonnhap";
                        cmd.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells["iMaDonNhapHang"].Value.ToString());
                        int i = cmd.ExecuteNonQuery();
                        if (i > 0)
                        {
                            MessageBox.Show("Xoá Thành Công", "Thông Báo");
                            loadGrid();
                        }
                    }
                }
            }
        }
    }
}
