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
    public partial class BaoCaoSanPhamNhapTheoNgaycs : Form
    {
        public BaoCaoSanPhamNhapTheoNgaycs()
        {
            //Alo 123
            //Cai nay thay doi
            //kjjkjoj
            ///123123
            ///////12312312
            //////1231231//
            ///1232131313
            InitializeComponent();
            //Test thu luc 11h48p
        }

        String constr = ConfigurationManager.ConnectionStrings["db_qltbnb"].ConnectionString;

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            try {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cnn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_thongKeSanPhamNhapTHeoNgay";
                        //cmd.Parameters.AddWithValue("@ngayBatDau", DateTime.Parse(txtNgayBatDau.Text));
                        //cmd.Parameters.AddWithValue("@ngayKetThuc", DateTime.Parse(txtNgayKetThuc.Text));
                        cmd.Parameters.AddWithValue("@ngayBatDau", DateTime.ParseExact(txtNgayBatDau.Text, "dd/MM/yyyy", null));
                        cmd.Parameters.AddWithValue("@ngayKetThuc", DateTime.ParseExact(txtNgayKetThuc.Text, "dd/MM/yyyy", null));
                        SqlDataAdapter dap = new SqlDataAdapter(cmd);
                    DataTable data = new DataTable();
                    dap.Fill(data);
                    BaoCaoSanPhamNhap report = new BaoCaoSanPhamNhap();
                    report.SetDataSource(data);
                    crystalReportViewer1.ReportSource = report;
                   
                }
            }


            }
            catch (Exception ex)
            {

            }


        }

        private void BaoCaoSanPhamNhapTheoNgaycs_Load(object sender, EventArgs e)
        {
            txtNgayBatDau.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtNgayKetThuc.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void btnTest_Click(object sender, EventArgs e)
        {

            try
            {
                using (SqlConnection cnn = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = cnn.CreateCommand())
                    {
                        cnn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "sp_baoCaoSanPhamChuaBan";
                        SqlDataAdapter dap = new SqlDataAdapter(cmd);
                        DataTable data = new DataTable();
                        dap.Fill(data);
                        BaoCaoSanPhamChuaDuocBan report = new BaoCaoSanPhamChuaDuocBan();
                        report.SetDataSource(data);
                        crystalReportViewer1.ReportSource = report;

                    }
                }


            }
            catch (Exception ex)
            {

            }

        }
    }
}
