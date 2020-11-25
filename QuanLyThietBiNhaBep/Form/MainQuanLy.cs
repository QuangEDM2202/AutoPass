using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyThietBiNhaBep
{
    public partial class mainQuanLy : Form
    {
        public mainQuanLy()
        {
            InitializeComponent();
        }

        private void tàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            formDangNhap main = new formDangNhap();
            main.Show();
        }


        private void nhomHangnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyNhomHang quanLy = new QuanLyNhomHang();
            quanLy.MdiParent = this;
            quanLy.Show();
        }

        private void sảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLySanPham quanLy = new QuanLySanPham();
            quanLy.MdiParent = this;
            quanLy.Show();
        }

        private void tàiKhoảnToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            QuanLyNhanVien quanLyNhanVien = new QuanLyNhanVien();
            quanLyNhanVien.MdiParent = this;
            quanLyNhanVien.Show();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoiMatKhau f = new DoiMatKhau();
            f.MdiParent = this;
            f.Show();
        }
        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            formDangNhap main = new formDangNhap();
            main.Show();
        }

        private void đơnNhậpHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void xemĐơnNhậpHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            quanLyPhieuNhapHang qly = new quanLyPhieuNhapHang();
            qly.MdiParent = this;
            qly.Show();
        }

        private void tạoĐơnNhậpHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TaoDonNhapHang taoDon = new TaoDonNhapHang();
            taoDon.MdiParent = this;
            taoDon.Show();
        }

        private void mainQuanLy_Load(object sender, EventArgs e)
        {
            if (Session.SessionQuyen == 1)
            {
                nhanVienToolStripMenuItem1.Enabled = false;
            }
        }

        private void báoCáoSảnPhẩmTHeoNgàyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BaoCaoSanPhamNhapTheoNgaycs baoCao = new BaoCaoSanPhamNhapTheoNgaycs();
            baoCao.MdiParent = this;
            baoCao.Show();
        }

        private void báoCáoSốLượngNhậpTheoNhânViênVàThờiGianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BaoCaoSanPhamNhapTheoNgayVaNhanVien baoCao = new BaoCaoSanPhamNhapTheoNgayVaNhanVien();
            baoCao.MdiParent = this;
            baoCao.Show();
        }
    }
}
