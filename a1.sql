USE [master]
GO
/****** Object:  Database [quanLyNhapThietBiNHaBep]    Script Date: 03/11/2020 11:19:36 PM ******/
CREATE DATABASE [quanLyNhapThietBiNHaBep]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'quanLyNhapThietBiNHaBep', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\quanLyNhapThietBiNHaBep.mdf' , SIZE = 3136KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'quanLyNhapThietBiNHaBep_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\quanLyNhapThietBiNHaBep_log.ldf' , SIZE = 784KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [quanLyNhapThietBiNHaBep] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [quanLyNhapThietBiNHaBep].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [quanLyNhapThietBiNHaBep] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [quanLyNhapThietBiNHaBep] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [quanLyNhapThietBiNHaBep] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [quanLyNhapThietBiNHaBep] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [quanLyNhapThietBiNHaBep] SET ARITHABORT OFF 
GO
ALTER DATABASE [quanLyNhapThietBiNHaBep] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [quanLyNhapThietBiNHaBep] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [quanLyNhapThietBiNHaBep] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [quanLyNhapThietBiNHaBep] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [quanLyNhapThietBiNHaBep] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [quanLyNhapThietBiNHaBep] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [quanLyNhapThietBiNHaBep] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [quanLyNhapThietBiNHaBep] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [quanLyNhapThietBiNHaBep] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [quanLyNhapThietBiNHaBep] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [quanLyNhapThietBiNHaBep] SET  ENABLE_BROKER 
GO
ALTER DATABASE [quanLyNhapThietBiNHaBep] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [quanLyNhapThietBiNHaBep] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [quanLyNhapThietBiNHaBep] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [quanLyNhapThietBiNHaBep] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [quanLyNhapThietBiNHaBep] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [quanLyNhapThietBiNHaBep] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [quanLyNhapThietBiNHaBep] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [quanLyNhapThietBiNHaBep] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [quanLyNhapThietBiNHaBep] SET  MULTI_USER 
GO
ALTER DATABASE [quanLyNhapThietBiNHaBep] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [quanLyNhapThietBiNHaBep] SET DB_CHAINING OFF 
GO
ALTER DATABASE [quanLyNhapThietBiNHaBep] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [quanLyNhapThietBiNHaBep] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [quanLyNhapThietBiNHaBep]
GO
/****** Object:  StoredProcedure [dbo].[sp_capNhatchitietnhaphang]    Script Date: 03/11/2020 11:19:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create proc [dbo].[sp_capNhatchitietnhaphang]
 @idDon int,
 @iSoLuong int,
 @idSanPham int,
 @igianhap int
 as
 update tblChiTietDonNhapHang set iSoLuong = @iSoLuong , igianhap = @igianhap where
 iMaDonNhapHang =  @idDon and iMaSanPham = @idSanPham
GO
/****** Object:  StoredProcedure [dbo].[sp_capNhatNhanVien]    Script Date: 03/11/2020 11:19:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_capNhatNhanVien]
@tenNV Nvarchar(30),	
@sdt nvarchar(20),
@diachi nvarchar(50),
@quyen int,
@manv int
as
update tblNhanVien set stenNV = @tenNV,sDiachi = @diachi,sSoDienThoai = @sdt,  iQuyen = @quyen where imanhanvien = @manv
GO
/****** Object:  StoredProcedure [dbo].[sp_capNhatNhanVien_]    Script Date: 03/11/2020 11:19:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_capNhatNhanVien_]
@tenNV Nvarchar(30),	
@sdt nvarchar(20),
@diachi nvarchar(50),
@quyen int,
@manv int
as
update tblNhanVien set stenNV = @tenNV,sDiachi = @diachi,sSoDienThoai = @sdt,  iQuyen = @quyen where imanhanvien = @manv
GO
/****** Object:  StoredProcedure [dbo].[sp_capNhatSoLuong]    Script Date: 03/11/2020 11:19:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
 CREATE proc [dbo].[sp_capNhatSoLuong]
 @idDon int,
 @iSoLuong int,
 @idSanPham int
 as
 update tblChiTietDonNhapHang set iSoLuong = @iSoLuong where
 iMaDonNhapHang =  @idDon and iMaSanPham = @idSanPham
GO
/****** Object:  StoredProcedure [dbo].[sp_danhSachNhanVien]    Script Date: 03/11/2020 11:19:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_danhSachNhanVien]
as
select stenNV as N'Tên Nhân Viên', sUserName as N'Tên Đăng Nhập', sSoDienThoai as N'SĐT', sDiachi as 'Địa Chỉ', IIF(iQuyen = 1, N'Nhân Viên', N'Quản Lý') as N'Quyền',
 IIF(bTrangThai = 1, N'Hoạt Động', N'Không Hoạt Động') as N'Trạng Thái', imanhanvien as iMaNV  
  from tblNhanVien
GO
/****** Object:  StoredProcedure [dbo].[sp_DoiMatKhau]    Script Date: 03/11/2020 11:19:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_DoiMatKhau]
@id int,
@mk varchar(100)
as
update tblNhanVien set Spass = @mk where iManhanvien = @id
GO
/****** Object:  StoredProcedure [dbo].[sp_kiemTraDangNhap]    Script Date: 03/11/2020 11:19:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_kiemTraDangNhap]
@tenTK nvarchar(50),
@mk varchar(100)
as
select  iMaNhanVien, iQuyen from tblNhanVien where sUserName = @tenTK and sPass = @mk and bTrangThai = 1
GO
/****** Object:  StoredProcedure [dbo].[sp_kiemTraMK]    Script Date: 03/11/2020 11:19:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_kiemTraMK]
@id int,
@mk varchar(100)
as
select * from tblNhanVien where iMaNhanVien = @id and sPass = @mk
GO
/****** Object:  StoredProcedure [dbo].[sp_ktraSanPhamNhapDon]    Script Date: 03/11/2020 11:19:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_ktraSanPhamNhapDon]
 @idDon int,
 @idSanPham int
 as
select * from tblChiTietDonNhapHang where
 iMaDonNhapHang =  @idDon and iMaSanPham = @idSanPham
GO
/****** Object:  StoredProcedure [dbo].[sp_ktraTen]    Script Date: 03/11/2020 11:19:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_ktraTen]
@username nvarchar(20)
as
select count(*) from tblNhanVien where sUserName = @username
GO
/****** Object:  StoredProcedure [dbo].[sp_suaNhomHang]    Script Date: 03/11/2020 11:19:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_suaNhomHang]
@maNhomHang int,
@tenNhomHang nvarchar(30)
as
update tblNhomHang set sTenNhomHang = @tenNhomHang where iMaNhomHang =  @maNhomHang
GO
/****** Object:  StoredProcedure [dbo].[sp_suaSanPham]    Script Date: 03/11/2020 11:19:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_suaSanPham] 
@imaSanPham int,
@sTenSanPham Nvarchar(40),	
@sXuatXu nvarchar(30),
@iMaNhomHang int ,
@sKichThuoc Nvarchar(50),
@sMoTa NVARCHAR(300),
--@gia int,
@giaban int,
@baohanh int,
@hinhanh nvarchar(100)
as
update tblSanPham  set sTenSanPham = @sTenSanPham, sXuatXu = @sXuatXu, iMaNhomHang = @iMaNhomHang, sHinhAnh = @hinhanh,
sKichThuoc = @sKichThuoc , sMoTa =@sMoTa, --iGia = @gia,
 igiaban = @giaban, ibaohanh = @baohanh where iMaSanPham = @imaSanPham 


GO
/****** Object:  StoredProcedure [dbo].[sp_taodonnhaphang]    Script Date: 03/11/2020 11:19:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[sp_taodonnhaphang]
@iMaNhanVien int,
@thoigian datetime,
@imadonnhap int out
as
insert into tblDonNhapHang (iMaNhanVien, dThoiGian) OUTPUT INSERTED.iMaDonNhapHang as id values (@iMaNhanVien,@thoigian) 
 set @imadonnhap = SCOPE_IDENTITY()
return @imadonnhap;
GO
/****** Object:  StoredProcedure [dbo].[sp_thayDoiTrangThaiNhanVien]    Script Date: 03/11/2020 11:19:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_thayDoiTrangThaiNhanVien]
@id int
as
DECLARE @tt SMALLINT
set @tt = (select bTrangThai from tblNhanVien where bTrangThai = @id)
if(@tt = 1)
begin
update tblNhanVien set bTrangThai = 0 where iMaNhanVien = @id
end
else
begin
update tblNhanVien set bTrangThai = 1 where iMaNhanVien = @id
end

GO
/****** Object:  StoredProcedure [dbo].[sp_themChiTietDonNhap]    Script Date: 03/11/2020 11:19:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_themChiTietDonNhap]
 @iMaDon int,
 @iSoLuong int,
 @iMaSanPham int,
 @igianhap int
 as
 insert into tblChiTietDonNhapHang (iMaDonNhapHang, iMaSanPham, iSoLuong, igianhap)
 values (@iMaDon,@imasanpham,@isoLuong,@igianhap)
GO
/****** Object:  StoredProcedure [dbo].[sp_themNhanVien]    Script Date: 03/11/2020 11:19:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_themNhanVien]
@tenNV Nvarchar(30),	
@tenTK nvarchar(50),
@mk varchar(100),
@sdt nvarchar(20),
@diachi nvarchar(50),
@quyen int
as
insert into tblNhanVien(stenNV,sUserName, sPass,sDiachi,sSoDienThoai, iQuyen) values (@tenNV, @tenTK, @mk,@diachi,@sdt,@quyen);
GO
/****** Object:  StoredProcedure [dbo].[sp_themNhomHang]    Script Date: 03/11/2020 11:19:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_themNhomHang]
@tenNhomHang Nvarchar(40)
as
insert into tblNhomHang(sTenNhomHang) values (@tenNhomHang);
GO
/****** Object:  StoredProcedure [dbo].[sp_themSanPham]    Script Date: 03/11/2020 11:19:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_themSanPham] 
@sTenSanPham Nvarchar(40),	
@sXuatXu nvarchar(30),
@iMaNhomHang int ,
@sKichThuoc Nvarchar(50),
@sMoTa NVARCHAR(300),
--@gia int,
@giaban int,
@baohanh int,
@hinhanh Nvarchar(100)
as
insert into tblSanPham (sTenSanPham, sXuatXu, iMaNhomHang, sKichThuoc, sMoTa, igiaban, ibaohanh, shinhanh) 
Values (@sTenSanPham,@sXuatXu,@iMaNhomHang,@sKichThuoc,@sMoTa,@giaban, @baohanh,@hinhanh)
GO
/****** Object:  StoredProcedure [dbo].[sp_thongKeSanPhamNhapTHeoNgay]    Script Date: 03/11/2020 11:19:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_thongKeSanPhamNhapTHeoNgay]
@ngayBatDau datetime,
@ngayKetThuc datetime
as
select tblSanPham.sTenSanPham as N'Tên Sản Phẩm', ISNULL(sum(tblChiTietDonNhapHang.iSoLuong),0) as N'Số Lượng' from tblChiTietDonNhapHang, tblDonNhapHang, tblSanPham where tblChiTietDonNhapHang.iMaDonNhapHang = tblDonNhapHang.iMaDonNhapHang and
tblChiTietDonNhapHang.iMaSanPham = tblSanPham.iMaSanPham and tblDonNhapHang.dThoiGian <= @ngayKetThuc and tblDonNhapHang.dThoiGian >= @ngayBatDau
group by  tblSanPham.sTenSanPham
GO
/****** Object:  StoredProcedure [dbo].[sp_thongKeSanPhamNhapTHeoNgayVaNhanVien]    Script Date: 03/11/2020 11:19:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_thongKeSanPhamNhapTHeoNgayVaNhanVien]
@ngayBatDau datetime,
@ngayKetThuc datetime
as
select tblNhanVien.iMaNhanVien, tblNhanVien.stenNV, ISNULL(sum(tblChiTietDonNhapHang.iSoLuong),0) as soluong from tblChiTietDonNhapHang, tblDonNhapHang, tblSanPham, tblNhanVien where tblChiTietDonNhapHang.iMaDonNhapHang = tblDonNhapHang.iMaDonNhapHang and
tblChiTietDonNhapHang.iMaSanPham = tblSanPham.iMaSanPham and tblDonNhapHang.dThoiGian <= @ngayKetThuc and tblDonNhapHang.dThoiGian >= @ngayBatDau and tblDonNhapHang.iMaNhanVien = tblNhanVien.iMaNhanVien
group by tblNhanVien.iMaNhanVien, tblNhanVien.stenNV
GO
/****** Object:  StoredProcedure [dbo].[sp_xemDonNhapHang]    Script Date: 03/11/2020 11:19:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE proc [dbo].[sp_xemDonNhapHang]
 as  
 select ROW_NUMBER() OVER (ORDER BY tblDonNhapHang.iMaDonNhapHang) AS  STT,
  'DNH' + CONVERT(varchar(10), tblDonNhapHang.iMaDonNhapHang) as 'Đơn Nhập',tblDonNhapHang.iMaDonNhapHang,  tblDonNhapHang.dThoiGian as N'Thời Gian', tblNhanVien.stennv  as N'Tên Nhân Viên Lập Đơn' 
  from tblDonNhapHang, tblNhanVien where tblNhanVien.imanhanvien = tblDonNhapHang.iMaNhanVien
GO
/****** Object:  StoredProcedure [dbo].[sp_xemDonNhapHang_]    Script Date: 03/11/2020 11:19:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_xemDonNhapHang_]
@iMaDon int
as
select ROW_NUMBER() OVER (ORDER BY sTenSanPham) AS  STT,tblSanPham.iMaSanPham, tblSanPham.sTenSanPham as N'Tên Sản Phẩm',tblChiTietDonNhapHang.iGiaNhap as N'Giá Nhập', tblChiTietDonNhapHang.iSoLuong as N'Số Lượng' from tblChiTietDonNhapHang, tblSanPham
 where iMaDonNhapHang = @iMaDon and tblChiTietDonNhapHang.iMaSanPham = tblSanPham.iMaSanPham

GO
/****** Object:  StoredProcedure [dbo].[sp_xemDonNhapHangTheoMa]    Script Date: 03/11/2020 11:19:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_xemDonNhapHangTheoMa]
  @maDon int
  as
  select  ROW_NUMBER() OVER (ORDER BY tblSanPham.sTenSanPham) AS  STT , 
  tblSanPham.sTenSanPham as N'Tên Sản Phẩm', tblChiTietDonNhapHang.igianhap as N'Giá Nhập' , tblChiTietDonNhapHang.iSoLuong as N'Số Lượng' 
   from tblChiTietDonNhapHang, tblSanPham where iMaDonNhapHang = @maDon and tblChiTietDonNhapHang.iMaSanPham = tblSanPham.iMaSanPham
GO
/****** Object:  StoredProcedure [dbo].[sp_xemNhomHang]    Script Date: 03/11/2020 11:19:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_xemNhomHang]
as
select ROW_NUMBER() OVER (ORDER BY sTenNhomHang)  as STT,iMaNhomHang, sTenNhomHang as N'Tên Nhóm Hàng' from tblNhomHang

GO
/****** Object:  StoredProcedure [dbo].[sp_xemSanPham]    Script Date: 03/11/2020 11:19:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_xemSanPham]
as
select iMaSanPham, sTenSanPham as N'Tên Sản Phẩm',
sKichThuoc as N'Kích Thước', sXuatXu as N'Xuất Xứ',stennhomhang as N'Nhóm Hàng',shinhanh, igiaban  as N'Giá Bán', ibaohanh  as N'Bảo Hành(tháng)', sMoTa as N'Mô Tả' from tblSanPham, tblNhomHang
 where tblNhomHang.iMaNhomHang = tblSanPham.iMaNhomHang order by iMaSanPham desc
GO
/****** Object:  StoredProcedure [dbo].[sp_xemSanPhamChoCCB]    Script Date: 03/11/2020 11:19:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create proc [dbo].[sp_xemSanPhamChoCCB]
as
select iMaSanPham, sTenSanPham from tblSanPham
GO
/****** Object:  StoredProcedure [dbo].[sp_xoadonnhap]    Script Date: 03/11/2020 11:19:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create proc [dbo].[sp_xoadonnhap]
   @id int
   as
   delete from tblChiTietDonNhapHang where iMaDonNhapHang = @id
      delete from tblDonNhapHang where iMaDonNhapHang = @id
GO
/****** Object:  StoredProcedure [dbo].[sp_xoaNhomHang]    Script Date: 03/11/2020 11:19:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_xoaNhomHang]
@id int
as
delete from tblNhomHang where iMaNhomHang = @id
GO
/****** Object:  StoredProcedure [dbo].[sp_xoaSanPham]    Script Date: 03/11/2020 11:19:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_xoaSanPham]
@id int
as
delete from tblSanPham where iMaSanPham = @id
GO
/****** Object:  StoredProcedure [dbo].[sp_xoaSanPhamKhoiDon]    Script Date: 03/11/2020 11:19:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create proc [dbo].[sp_xoaSanPhamKhoiDon]
 @idDon int,
 @idSanPham int
 as
 delete from tblChiTietDonNhapHang where iMaDonNhapHang = @idDon and iMaSanPham = @idSanPham
GO
/****** Object:  Table [dbo].[tblChiTietDonNhapHang]    Script Date: 03/11/2020 11:19:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblChiTietDonNhapHang](
	[iMaDonNhapHang] [int] NOT NULL,
	[iMaSanPham] [int] NOT NULL,
	[iSoLuong] [int] NULL,
	[igiaNhap] [int] NULL,
 CONSTRAINT [PK_HNHH] PRIMARY KEY CLUSTERED 
(
	[iMaDonNhapHang] ASC,
	[iMaSanPham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblDonNhapHang]    Script Date: 03/11/2020 11:19:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblDonNhapHang](
	[iMaDonNhapHang] [int] IDENTITY(1,1) NOT NULL,
	[iMaNhanVien] [int] NULL,
	[dThoiGian] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[iMaDonNhapHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblNhanVien]    Script Date: 03/11/2020 11:19:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblNhanVien](
	[iMaNhanVien] [int] IDENTITY(1,1) NOT NULL,
	[stenNV] [nvarchar](30) NULL,
	[sSoDienThoai] [nvarchar](20) NULL,
	[iQuyen] [int] NULL,
	[sDiachi] [nvarchar](30) NULL,
	[sUserName] [nvarchar](20) NULL,
	[sPass] [varchar](100) NULL,
	[bTrangThai] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[iMaNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblNhomHang]    Script Date: 03/11/2020 11:19:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblNhomHang](
	[iMaNhomHang] [int] IDENTITY(1,1) NOT NULL,
	[sTenNhomHang] [nvarchar](40) NULL,
PRIMARY KEY CLUSTERED 
(
	[iMaNhomHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblSanPham]    Script Date: 03/11/2020 11:19:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblSanPham](
	[iMaSanPham] [int] IDENTITY(1,1) NOT NULL,
	[sTenSanPham] [nvarchar](40) NULL,
	[sXuatXu] [nvarchar](30) NULL,
	[iMaNhomHang] [int] NOT NULL,
	[sKichThuoc] [nvarchar](50) NULL,
	[sMoTa] [nvarchar](300) NULL,
	[iGiaBan] [int] NULL,
	[iBaoHanh] [int] NULL,
	[sHinhAnh] [nvarchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[iMaSanPham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[tblNhanVien] ADD  DEFAULT ((1)) FOR [bTrangThai]
GO
ALTER TABLE [dbo].[tblChiTietDonNhapHang]  WITH CHECK ADD  CONSTRAINT [FK_1] FOREIGN KEY([iMaDonNhapHang])
REFERENCES [dbo].[tblDonNhapHang] ([iMaDonNhapHang])
GO
ALTER TABLE [dbo].[tblChiTietDonNhapHang] CHECK CONSTRAINT [FK_1]
GO
ALTER TABLE [dbo].[tblChiTietDonNhapHang]  WITH CHECK ADD  CONSTRAINT [FK_2] FOREIGN KEY([iMaSanPham])
REFERENCES [dbo].[tblSanPham] ([iMaSanPham])
GO
ALTER TABLE [dbo].[tblChiTietDonNhapHang] CHECK CONSTRAINT [FK_2]
GO
ALTER TABLE [dbo].[tblDonNhapHang]  WITH CHECK ADD FOREIGN KEY([iMaNhanVien])
REFERENCES [dbo].[tblNhanVien] ([iMaNhanVien])
GO
ALTER TABLE [dbo].[tblSanPham]  WITH CHECK ADD FOREIGN KEY([iMaNhomHang])
REFERENCES [dbo].[tblNhomHang] ([iMaNhomHang])
GO
USE [master]
GO
ALTER DATABASE [quanLyNhapThietBiNHaBep] SET  READ_WRITE 
GO
