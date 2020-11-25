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
    public partial class DoiMatKhau : Form
    {
        public DoiMatKhau()
        {
            InitializeComponent();
        }
        String constr = ConfigurationManager.ConnectionStrings["db_qltbnb"].ConnectionString;
        MaHoa maHoa = new MaHoa();
        //Session session = new Session();
        private void btnDoiMK_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("constructor firedsss " + Session.SessionMaNV);
            if (String.Compare(txtNhapLai.Text, txtMKmoi.Text) == 0)
            {
                using (SqlConnection cnn = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = cnn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "sp_kiemTraMK";
                        cmd.Parameters.AddWithValue("@id", Session.SessionMaNV);
                        cmd.Parameters.AddWithValue("@mk", maHoa.GetMD5(txtMKcu.Text));
                        cnn.Open();
                        SqlDataAdapter dap = new SqlDataAdapter(cmd);
                        DataTable data = new DataTable();
                        dap.Fill(data);
                       
                        if (data.Rows.Count > 0)
                        {

                            using (SqlCommand cmd1 = cnn.CreateCommand())
                            {
                                cmd1.CommandType = CommandType.StoredProcedure;
                                cmd1.CommandText = "sp_DoiMatKhau";
                                cmd1.Parameters.AddWithValue("@id", Session.SessionMaNV);
                                cmd1.Parameters.AddWithValue("@mk", maHoa.GetMD5(txtMKmoi.Text));
                                int i = cmd1.ExecuteNonQuery();
                                if (i > 0)
                                {
                                    MessageBox.Show("Đổi Thành Công.", "Thông Báo");
                                    this.Hide();
                                }
                                else
                                {
                                    MessageBox.Show("Đổi không Thành Công.", "Thông Báo");
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Mật Khẩu Cũ Không Đúng.", "Thông Báo");
                        }
                      }
                }
            }
            else
            {
                MessageBox.Show("Mật Khẩu Mới Không Giống Nhau.", "Thông Báo");
            }
        }
    }
}
