create database quanLyNhapThietBiVeSinh


create table tblNhanVien (
iMaNhanVien int identity(1,1) primary key not null,
stenNV Nvarchar(30),	
sSoDienThoai nvarchar(20),
bTrangThai int default 1,
iQuyen int,
sDiachi Nvarchar(30),
sUserName NVARCHAR(20),
sPass VARCHAR(100)
);

select * from tblNhanVien
alter table tblNhanVien add bTrangThai bit default 1

create table tblSanPham (
iMaSanPham int identity(1,1) primary key not null,
sTenSanPham Nvarchar(40),	
sXuatXu nvarchar(30),
iMaNhomHang int not null,
iGia int,
sKichThuoc Nvarchar(50),
sMoTa NVARCHAR(300),
sHinhAnh Nvarchar(100)

);

Alter Table tblSanPham alter column sHinhAnh Nvarchar(200);

Alter Table tblSanPham add iBaoHanh int

select * from tblSanPham

Alter Table tblSanPham add Foreign Key (iMaNhomHang) References tblNhomHang (iMaNhomHang);

create table tblDonNhapHang (
iMaDonNhapHang int identity(1,1) primary key not null,
iMaNhanVien int,
dThoiGian datetime
);

Alter Table tblDonNhapHang add Foreign Key (iMaNhanVien) References tblNhanVien (iMaNhanVien);

create table tblChiTietDonNhapHang (
iMaDonNhapHang int not null,
iMaSanPham int  not null,
iSoLuong int
);

ALTER TABLE tblChiTietDonNhapHang ADD CONSTRAINT PK_HNHH PRIMARY KEY(iMaDonNhapHang, iMaSanPham),
CONSTRAINT FK_1 FOREIGN KEY (iMaDonNhapHang) REFERENCES tblDonNhapHang(iMaDonNhapHang),
CONSTRAINT FK_2 FOREIGN KEY (iMaSanPham) REFERENCES tblSanPham(iMaSanPham)

Create Table tblNhomHang
( 
iMaNhomHang int identity(1,1) primary key not null,
sTenNhomHang Nvarchar(40) null,
);

alter proc sp_kiemTraDangNhap
@tenTK nvarchar(50),
@mk varchar(100)
as
select  iMaNhanVien, iQuyen from tblNhanVien where sUserName = @tenTK and sPass = @mk and bTrangThai = 1

alter proc sp_themNhanVien
@tenNV Nvarchar(30),	
@tenTK nvarchar(50),
@mk varchar(100),
@sdt nvarchar(20),
@diachi nvarchar(50),
@quyen int
as
insert into tblNhanVien(stenNV,sUserName, sPass,sDiachi,sSoDienThoai, iQuyen) values (@tenNV, @tenTK, @mk,@diachi,@sdt,@quyen);

select * from tblNhanVien

alter proc sp_danhSachNhanVien
as
select stenNV as N'Tên Nhân Viên', sUserName as N'Tên Đăng Nhập', sSoDienThoai as N'SĐT', sDiachi as 'Địa Chỉ', IIF(iQuyen = 1, N'Nhân Viên', N'Quản Lý') as N'Quyền',
 IIF(bTrangThai = 1, N'Hoạt Động', N'Không Hoạt Động') as N'Trạng Thái', imanhanvien as iMaNV  
  from tblNhanVien


alter proc sp_ktraTen
@username nvarchar(20)
as
select count(*) from tblNhanVien where sUserName = @username

create proc sp_kiemTraMK
@id int,
@mk varchar(100)
as
select * from tblNhanVien where iMaNhanVien = @id and sPass = @mk

create proc sp_DoiMatKhau
@id int,
@mk varchar(100)
as
update tblNhanVien set Spass = @mk where iManhanvien = @id

alter proc sp_thayDoiTrangThaiNhanVien
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

create proc sp_themNhomHang
@tenNhomHang Nvarchar(40)
as
insert into tblNhomHang(sTenNhomHang) values (@tenNhomHang);

alter proc sp_xemNhomHang
as
select ROW_NUMBER() OVER (ORDER BY sTenNhomHang)  as STT,iMaNhomHang, sTenNhomHang as N'Tên Nhóm Hàng' from tblNhomHang

alter proc sp_xemSanPham
as
select iMaSanPham, sTenSanPham as N'Tên Sản Phẩm',
sKichThuoc as N'Kích Thước', sXuatXu as N'Xuất Xứ',stennhomhang as N'Nhóm Hàng',shinhanh, igiaban  as N'Giá Bán', ibaohanh  as N'Bảo Hành(tháng)', sMoTa as N'Mô Tả' from tblSanPham, tblNhomHang
 where tblNhomHang.iMaNhomHang = tblSanPham.iMaNhomHang order by iMaSanPham desc

 create proc sp_xemSanPhamChoCCB
as
select iMaSanPham, sTenSanPham from tblSanPham


select iMaSanPham, sTenSanPham as N'Tên Sản Phẩm', sKichThuoc as N'Kích Thước', sXuatXu as N'Xuất Xứ',stennhomhang as N'Nhóm Hàng', sMoTa as N'Mô Tả' from tblSanPham, tblNhomHang where tblNhomHang.iMaNhomHang = tblSanPham.iMaNhomHang 

alter proc sp_themSanPham 
@sTenSanPham Nvarchar(40),	
@sXuatXu nvarchar(30),
@iMaNhomHang int ,
@sKichThuoc Nvarchar(50),
@sMoTa NVARCHAR(300),
@gia int,
@giaban int,
@baohanh int,
@hinhanh Nvarchar(100)
as
insert into tblSanPham (sTenSanPham, sXuatXu, iMaNhomHang, sKichThuoc, sMoTa, iGia, igiaban, ibaohanh, shinhanh) 
Values (@sTenSanPham,@sXuatXu,@iMaNhomHang,@sKichThuoc,@sMoTa,@gia,@giaban, @baohanh,@hinhanh)

select * from tblSanPham


alter proc sp_suaSanPham 
@imaSanPham int,
@sTenSanPham Nvarchar(40),	
@sXuatXu nvarchar(30),
@iMaNhomHang int ,
@sKichThuoc Nvarchar(50),
@sMoTa NVARCHAR(300),
@gia int,
@giaban int,
@baohanh int,
@hinhanh nvarchar(100)
as
update tblSanPham  set sTenSanPham = @sTenSanPham, sXuatXu = @sXuatXu, iMaNhomHang = @iMaNhomHang, sHinhAnh = @hinhanh,
sKichThuoc = @sKichThuoc , sMoTa =@sMoTa, iGia = @gia, igiaban = @giaban, ibaohanh = @baohanh where iMaSanPham = @imaSanPham 


Create proc sp_taodonnhaphang
@iMaNhanVien int,
@thoigian datetime,
@imadonnhap int out
as
insert into tblDonNhapHang (iMaNhanVien, dThoiGian) OUTPUT INSERTED.iMaDonNhapHang as id values (@iMaNhanVien,@thoigian) 
 set @imadonnhap = SCOPE_IDENTITY()
return @imadonnhap;

create proc sp_xemDonNhapHang_
@iMaDon int
as
select ROW_NUMBER() OVER (ORDER BY sTenSanPham) AS  STT,tblSanPham.iMaSanPham, tblSanPham.sTenSanPham as N'Tên Sản Phẩm', tblChiTietDonNhapHang.iSoLuong as N'Số Lượng' from tblChiTietDonNhapHang, tblSanPham
 where iMaDonNhapHang = @iMaDon and tblChiTietDonNhapHang.iMaSanPham = tblSanPham.iMaSanPham

 create proc sp_themChiTietDonNhap
 @iMaDon int,
 @iSoLuong int,
 @iMaSanPham int
 as
 insert into tblChiTietDonNhapHang (iMaDonNhapHang, iMaSanPham, iSoLuong)
 values (@iMaDon,@imasanpham,@isoLuong)

 create proc sp_xoaSanPhamKhoiDon
 @idDon int,
 @idSanPham int
 as
 delete from tblChiTietDonNhapHang where iMaDonNhapHang = @idDon and iMaSanPham = @idSanPham

 
 alter proc sp_capNhatSoLuong
 @idDon int,
 @iSoLuong int,
 @idSanPham int
 as
 update tblChiTietDonNhapHang set iSoLuong = @iSoLuong where
 iMaDonNhapHang =  @idDon and iMaSanPham = @idSanPham

 create proc sp_ktraSanPhamNhapDon
 @idDon int,
 @idSanPham int
 as
select * from tblChiTietDonNhapHang where
 iMaDonNhapHang =  @idDon and iMaSanPham = @idSanPham
 select * from tblNhanVien

 alter proc sp_xemDonNhapHang
 as  
 select ROW_NUMBER() OVER (ORDER BY tblDonNhapHang.iMaDonNhapHang) AS  STT,
  'DNH' + CONVERT(varchar(10), tblDonNhapHang.iMaDonNhapHang) as 'Đơn Nhập',tblDonNhapHang.iMaDonNhapHang,  tblDonNhapHang.dThoiGian as N'Thời Gian', tblNhanVien.stennv  as N'Tên Nhân Viên Lập Đơn' 
  from tblDonNhapHang, tblNhanVien where tblNhanVien.imanhanvien = tblDonNhapHang.iMaNhanVien


  create proc sp_xemDonNhapHangTheoMa
  @maDon int
  as
  select  ROW_NUMBER() OVER (ORDER BY tblSanPham.sTenSanPham) AS  STT , 
  tblSanPham.sTenSanPham as N'Tên Sản Phẩm', tblChiTietDonNhapHang.iSoLuong as N'Số Lượng' 
   from tblChiTietDonNhapHang, tblSanPham where iMaDonNhapHang = @maDon and tblChiTietDonNhapHang.iMaSanPham = tblSanPham.iMaSanPham

   create proc sp_xoadonnhap
   @id int
   as
   delete from tblChiTietDonNhapHang where iMaDonNhapHang = @id
      delete from tblDonNhapHang where iMaDonNhapHang = @id

	  

	  create proc sp_capNhatNhanVien_
@tenNV Nvarchar(30),	
@sdt nvarchar(20),
@diachi nvarchar(50),
@quyen int,
@manv int
as
update tblNhanVien set stenNV = @tenNV,sDiachi = @diachi,sSoDienThoai = @sdt,  iQuyen = @quyen where imanhanvien = @manv


alter proc sp_thongKeSanPhamNhapTHeoNgay
@ngayBatDau datetime,
@ngayKetThuc datetime
as
select tblSanPham.sTenSanPham as N'Tên Sản Phẩm', ISNULL(sum(tblChiTietDonNhapHang.iSoLuong),0) as N'Số Lượng' from tblChiTietDonNhapHang, tblDonNhapHang, tblSanPham where tblChiTietDonNhapHang.iMaDonNhapHang = tblDonNhapHang.iMaDonNhapHang and
tblChiTietDonNhapHang.iMaSanPham = tblSanPham.iMaSanPham and tblDonNhapHang.dThoiGian <= @ngayKetThuc and tblDonNhapHang.dThoiGian >= @ngayBatDau
group by  tblSanPham.sTenSanPham

exec  sp_thongKeSanPhamNhapTHeoNgay '05/05/2019','05/05/2021'


create proc sp_xoaNhomHang
@id int
as
delete from tblNhomHang where iMaNhomHang = @id

alter proc sp_suaNhomHang
@maNhomHang int,
@tenNhomHang nvarchar(30)
as
update tblNhomHang set sTenNhomHang = @tenNhomHang where iMaNhomHang =  @maNhomHang

create proc sp_xoaSanPham
@id int
as
delete from tblSanPham where iMaSanPham = @id


create proc sp_thongKeSanPhamNhapTHeoNgayVaNhanVien
@ngayBatDau datetime,
@ngayKetThuc datetime
as
select tblNhanVien.iMaNhanVien, tblNhanVien.stenNV, ISNULL(sum(tblChiTietDonNhapHang.iSoLuong),0) as soluong from tblChiTietDonNhapHang, tblDonNhapHang, tblSanPham, tblNhanVien where tblChiTietDonNhapHang.iMaDonNhapHang = tblDonNhapHang.iMaDonNhapHang and
tblChiTietDonNhapHang.iMaSanPham = tblSanPham.iMaSanPham and tblDonNhapHang.dThoiGian <= @ngayKetThuc and tblDonNhapHang.dThoiGian >= @ngayBatDau and tblDonNhapHang.iMaNhanVien = tblNhanVien.iMaNhanVien
group by tblNhanVien.iMaNhanVien, tblNhanVien.stenNV