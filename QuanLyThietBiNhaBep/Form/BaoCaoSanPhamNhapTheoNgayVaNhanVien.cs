using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace QuanLyThietBiNhaBep
{
    public partial class BaoCaoSanPhamNhapTheoNgayVaNhanVien : Form
    {
        public BaoCaoSanPhamNhapTheoNgayVaNhanVien()
        {
            InitializeComponent();
        }

        String constr = ConfigurationManager.ConnectionStrings["db_qltbnb"].ConnectionString;

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = cnn.CreateCommand())
                    {
                        cnn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "sp_thongKeSanPhamNhapTHeoNgayVaNhanVien";
                        //cmd.Parameters.AddWithValue("@ngayBatDau", DateTime.Parse(txtNgayBatDau.Text));
                        //cmd.Parameters.AddWithValue("@ngayKetThuc", DateTime.Parse(txtNgayKetThuc.Text));
                        cmd.Parameters.AddWithValue("@ngayBatDau", DateTime.ParseExact(txtNgayBatDau.Text, "dd/MM/yyyy", null));
                        cmd.Parameters.AddWithValue("@ngayKetThuc", DateTime.ParseExact(txtNgayKetThuc.Text, "dd/MM/yyyy", null));
                        SqlDataAdapter dap = new SqlDataAdapter(cmd);
                        DataTable data = new DataTable();
                        dap.Fill(data);
                        BaoCaoNhapHangTheoNhanVienVaThoiGian report = new BaoCaoNhapHangTheoNhanVienVaThoiGian();
                        report.SetDataSource(data);
                        crystalReportViewer1.ReportSource = report;

                    }
                }
         }
            catch(Exception ex)
            {

            }
}

        private void BaoCaoSanPhamNhapTheoNgayVaNhanVien_Load(object sender, EventArgs e)
        {

            txtNgayBatDau.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtNgayKetThuc.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
    }
}




/*ReportDocument rd = new ReportDocument();
           rd.Load(@"C:\Users\Admin\documents\visual studio 2015\Projects\QuanLyThietBiNhaBep\QuanLyThietBiNhaBep\BaoCaoSanPhamNhap.rpt");
           rd.SetParameterValue("@ngayBatDau", txtNgayBatDau.Text);
           rd.SetParameterValue("@ngayKetThuc", txtNgayKetThuc.Text);
           crystalReportViewer1.ReportSource = rd;*/
