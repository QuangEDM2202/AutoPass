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
using static System.Collections.Specialized.BitVector32;

namespace QuanLyThietBiNhaBep
{
    public partial class formDangNhap : Form
    {
        ConnectSQL connectSql = new ConnectSQL();
        MaHoa maHoa = new MaHoa();
        public formDangNhap()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            String constr = ConfigurationManager.ConnectionStrings["db_qltbnb"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_kiemTraDangNhap";
                    cmd.Parameters.AddWithValue("@tenTK", txtTenDN.Text);
                    cmd.Parameters.AddWithValue("@mk", maHoa.GetMD5(txtMK.Text));
                    cnn.Open();
                    SqlDataAdapter dap = new SqlDataAdapter(cmd);
                    DataTable data = new DataTable();
                    dap.Fill(data);
                    //Debug.WriteLine("constructor fired " + i);
                    if (data.Rows.Count > 0)
                    {
                        cnn.Close();

                        Session.SessionMaNV= data.Rows[0]["iMaNhanVien"].ToString();
                        Session.SessionQuyen = Convert.ToInt32(data.Rows[0]["iQuyen"].ToString());
                        this.Hide();
                        mainQuanLy main = new mainQuanLy();

                        main.ShowDialog();
                        this.Show();
                        Debug.WriteLine("constructor fired sesion " + Session.SessionMaNV);
                    }
                    else
                    {
                        MessageBox.Show("TK Hoặc MK Không Chính Xác", "Thông Báo");
                    }
                }
            }
        }

        private void formDangNhap_Load(object sender, EventArgs e)
        {
            txtMK.Text = "admin";
            txtTenDN.Text = "admin";
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            System.Diagnostics.FileVersionInfo fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.ProductVersion;
           // Debug.WriteLine(OSInfo.Name);
            Debug.WriteLine("ver: " + typeof(string).Assembly.ImageRuntimeVersion);
        }
    }
}
