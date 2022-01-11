-- Tạo DATABASE
Create Database PhongKhamNhaKhoa;
Use PhongKhamNhaKhoa;

-- Bảng Nhân viên
Create table NhanVien(
MaNV char(10) not null primary key,
TenNV nvarchar(200),
GioiTinh nvarchar(20),
NgaySinh date,
SDT char(20),
Email nvarchar(100),
DiaChi nvarchar(300)
);

-- Bảng Bác sĩ
Create table BacSi(
MaBS char(10) not null primary key,
TenBS nvarchar(200),
GioiTinh nvarchar(20),
NgaySinh date,
SDT char(20),
Email nvarchar(100),
DiaChi nvarchar(300),
ChucDanh nvarchar(300),
NamKinhNghiem float
);

-- Bảng Khách hàng
create table KhachHang(
MaKH char(10) not null primary key,
TenKH nvarchar(200),
GioiTinh nvarchar(20),
SDT char(20),
NgaySinh Date,
NgheNghiep nvarchar(200),
DiaChi nvarchar(300)
);

-- Bảng nhà cung cấp
Create table NhaCungCap(
MaNCC char(10) not null primary key,
TenNCC nvarchar(300),
SDT char(20),
DiaChi nvarchar(300)
);

-- Bảng thiết bị vật liệu
Create table ThietBiVatLieu(
MaTB char(10) not null primary key,
MaNCC char(10) not null,
TenTB nvarchar(200),
MoTa nvarchar(300),
Foreign Key(MaNCC) References NhaCungCap(MaNCC)
);

-- Bảng dịch vụ
Create table DichVu(
MaDV char(10) not null primary key,
TenDV nvarchar(100),
DonGia bigint,
MoTa nvarchar(300),
MaTB char(10),
Foreign Key(MaTB) References ThietBiVatLieu(MaTB) 
);


-- Bảng Hóa đơn
create table HoaDon(
MaHD char(10) not null Primary Key,
MaKH char(10) not null,
MaBS char(10),
NgayLam date,
NgayXuatHoaDon date,
TongTien bigint,
NgayHenKhamLai date,
MoTa nvarchar(300),
foreign Key (MaKH) References KhachHang(MaKH),
foreign Key (MaBS) References BacSi(MaBS)
);

-- Bảng Chi tiết hóa đơn
create table CT_HoaDon(
MaHD char(10) not null,
MaDV char(10) not null,
SoLuong int,
ThanhTien bigint,
Primary Key (MaHD, MaDV),
foreign Key (MaHD) References HoaDon(MaHD),
foreign Key (MaDV) References DichVu(MaDV)
);

/* Trigger tự động tính và cập nhật trường Thành tiền trong bảng Chi tiết hóa đơn
và tự động cập nhật trường Tổng tiền trong bảng Hóa đơn khi insert vào bảng Chi tiết hóa đơn */
-----------------------------------------------------------------------------------
CREATE TRIGGER tinhtienHD
ON CT_HoaDon FOR INSERT
AS
BEGIN
	Declare @mahd char(10);
	Declare @madv char(10);
	Declare @soluong int;
	Declare @dongia bigint;
	Select @mahd = MaHD, @madv = MaDV, @soluong = SoLuong From inserted;
	Select @dongia = DonGia From DichVu Where MaDV = @madv;
	Update CT_HoaDon Set ThanhTien = (@soluong * @dongia) Where MaHD = @mahd and MaDV = @madv;
	Update HoaDon
	Set TongTien = (Select SUM(ThanhTien)
					From CT_HoaDon
					Where MaHD = @mahd)
	Where MaHD = @mahd;
END

----------------------------------------------------------------------------------

-- Thêm dữ liệu mẫu vào bảng Nhân viên
INSERT INTO NhanVien
VALUES('NV01', N'Dương Văn Công', N'Nam', '2001/12/04', '0373785045', 'duongcong0412hc@gmmail.com', N'Hương Câu, Hương Lâm, Hiệp Hòa, Bắc Giang')

-- Thêm dữ liệu mẫu vào bảng Bác sĩ
INSERT INTO BacSi 
VALUES('BS01', N'Đỗ Doãn Lợi', N'Nam', '1960/06/21', '0564243269', 'doloi@gmail.com', N'3A Lê Quý Đôn, Phường 12, Quận Phú Nhuận, Tp.Hồ Chí Minh', N'Thạc sĩ, Bác sĩ', 38),
	('BS02', N'Võ Thành Nhân', N'Nam', '1975/12/16', '0924068910', 'vthanhnhan@@gmail.com', N'SỐ 129 Trần Quốc Hoàn, Cầu Giấy, Hà Nội', N'Giáo sư, Tiến sĩ, Bác sĩ', 15),
	('BS03', N'Nguyễn Thanh Liêm', N'Nam', '1980/01/19', '0564900954', 'ntliem19@gmail.com', N'Phường Cẩm Bình, Thành phố Cẩm Phả, Tỉnh Quảng Ninh', N'Phó Giáo sư , Tiến sĩ, Bác sĩ', 9),
	('BS04', N'Phan Quỳnh Lan', N'Nữ', '1979/09/04', '0374907340', 'phanqlan@outlook.com', N'Số 173 Lương Văn Thăng, Phố 9, P. Đông Thành, TP.Ninh Bình, T.Ninh Bình', N'Bác sĩ cao cấp', 10),
	('BS05', N'Selina M. Luger', N'Nữ', '1965/03/04', '0945784569', 'smluger@oscs.com', N'284 Đội Cấn, P. Cống Vị, Q. Ba Đình, TP. Hà Nội', N'hạc sĩ, Bác sĩ chuyên khoa II, Bác sĩ', 33),
	('BS06', N'Nguyễn Thị Tân Sinh', N'Nam', '1985/07/08', '0869265874', 'nttsinh@gmail.com', N'11A Thái Hà, P.Trung Liệt, Q.Đống Đa, Hà Nội', N'Bác sĩ chuyên khoa I', 6),
	('BS07', N'Trần Thanh Cảng', N'Nam', '1977/10/19', '07954230148', 'cangtth@gmail.com', N'Quốc Lộ 1A, P.Hai Bà Trưng, TP.Phủ Lý, Hà Nam', N'Thạc sĩ, Bác sĩ', 12),
	('BS08', N'Nguyễn Tuyết Mai', N'Nữ', '1981/11/28', '03795846034', 'tuyetmai@gmail.com', N'Số 262, thị trấn Yên Mỹ, huyện Yên Mỹ, tỉnh Hưng Yên', N'Bác sĩ', 8)

	select * from BacSi
-- Thêm dữ liệu mẫu vào bảng Khách hàng
INSERT INTO KhachHang
VALUES('KH01', N'Ngô Văn Đoan', N'Nam', '0365789451', '1989/10/23', N'Công nhân', N'166 Phạm Văn Đồng, Từ Liêm, HN'),
	('KH02', N'Nguyễn Tất Bình', N'Nam', '0987451236', '1998/08/08', N'Kinh doanh', N'Tầng 6, Số 1 Thái Hà, Đống Đa, Hà Nội'),
	('KH03', N'Nguyễn Văn Quyết', N'Nam', '0347841256', '1982/12/13', N'Làm ruộng', N'số 371/ 20 Hai Bà Trưng, Phường Võ Thị Sáu, Quận 3, TPHCM'),
	('KH04', N'Đoàn Thị Hồng Hạnh', N'Nữ', '0796421574', '1995/08/15', N'Giáo viên', N'408 Đại lộ Bình Dương, P. Phú Lợi, TP. Thủ Dầu Một, Tỉnh Bình Dương'),
	('KH05', N'Trần Liên Anh', N'Nữ', '0863124578', '1960/03/09', N'Kinh doanh', N'Số 2 Hoàng Hoa Thám, phường 12, Quận Tân Bình, TP.HCM'),
	('KH06', N'Bùi Tiến Đạt', N'Nam', '0942136547', '1995/10/12', N'Công nhân', N'Địa chỉ: Số 9-11 Nguyễn Thị Thập, Phường Tân Phú, Quận 7, TP.HCM'),
	('KH07', N'Nguyễn Thị Hoàn', N'Nữ', '0314578410', '1999/09/19', N'Kinh doanh', N'Lô 11 G2 Nguyễn Thái Học, Phường 7, TP Vũng Tàu, Tỉnh Bà Rịa - Vũng Tàu'),
	('KH08', N'Nguyễn Thái Trí', N'Nam', '0365412487', '2001/06/02', N'Sinh viên', N'218 Lê Duẩn, Thành Phố Vinh, Nghệ An'),
	('KH09', N'Nguyễn Quang Thắng', N'Nam', '0368741241', '1977/05/01', N'Làm ruộng', N'Số 10 Đại Lộ Lê Lợi, Điện Biên, Thanh Hóa'),
	('KH10', N'Phùng Tuyết Lan', N'Nữ', '0987412354', '2005/07/17', N'Học sinh', N'393 Lương Ngọc Quyến, TP. Thái Nguyên')


-- Thêm dữ liệu mẫu vào bảng Nhà cung cấp
INSERT INTO NhaCungCap
VALUES('NCC1', N'Công ty vật liệu và thiết bị nha khoa Thiên Minh', '02462766857', N'131 Phương Mai, Đống Đa, Hà Nội'),
	('NCC2', N'Công ty thiết bị y tế GDENT', '02432216999', N'Số 15/322 Lê Trọng Tấn, Khương Mai, Thanh Xuân, Hà Nội'),
	('NCC3', N'Công ty CP trang thiết bị y tế Mạnh Cường', '02838606607', N'phòng 701, 702, tầng 7, tòa nhà 03, ngõ 115, Nguyễn Khang, Yên Hòa, Cầu Giấy, Hà Nội'),
	('NCC4', N'Công ty cung ứng y tế Nha Phong', '0961 566 688', N'Số 19 Ngõ 554 Trường Chinh, Đống Đa, Hà Nội')


-- Thêm dữ liệu mẫu vào bảng Thiết bị vật liệu
INSERT INTO ThietBiVatLieu
VALUES('TB01', 'NCC1', N'Tay khoan, mũi khoan', N'Dụng cụ dùng để khoan'),
	('TB02', 'NCC2', N'Máy cạo vôi răng', N'Máy dùng để cạo vôi răng'),
	('TB03', 'NCC3', N'Máy làm trắng răng White Light', N'Máy làm trắng răng'),
	('TB04', 'NCC4', N'Dụng cụ nhổ răng không sang chấn', N'Dụng cụ dùng nhổ răng'),
	('TB05', 'NCC2', N'Răng sứ', N'Răng sứ'),
	('TB06', 'NCC3', N'Bộ niềng răng', N'Bộ dụng cụ niềng răng'),
	('TB07', 'NCC1', N'Bộ dụng phẫu thuật', N'Dụng cụ dùng để mổ')

-- Thêm dữ liệu mẫu vào bảng Dịch vụ
INSERT INTO DichVu
VALUES('DV01', N'Lấy vôi răng', 400000, N'Cạo vôi răng, dánh bóng răng', 'TB02'),
	('DV02', N'Làm trắng răng', 1700000, N'Làm trắng răng', 'TB03'),
	('DV03', N'Xử lý răng khôn', 200000, N'Xử lý răng khôn, nhổ răng khôn', 'TB04'),
	('DV04', N'Xử lý răng sâu', 200000, N'Trám răng sâu, xử lý tủy răng', 'TB03'),
	('DV05', N'Niềng răng', 3500000, N'Niềng răng thưa, niềng răng móm, niềng răng hô', 'TB06'),
	('DV06', N'Điều trị nha chu', 2000000, N'Điều trị nha chu', 'TB07'),
	('DV07', N'Thay răng sứ', 1500000, N'Tẩy trắng răng, bọc răng sứ', 'TB05'),
	('DV08', N'Nhổ răng', 100000, N'Nhổ răng', 'TB04')


-- Thêm dữ liệu mẫu vào bảng Hóa đơn
INSERT INTO HoaDon(MaHD, MaKH, MaBS, NgayLam, NgayXuatHoaDon, NgayHenKhamLai, MoTa)
VALUES('HD01', 'KH01', 'BS02', '2021/06/06', '2021/06/06', '2021/07/06', N'Hóa đơn làm trắng răng'),
	('HD02', 'KH02', 'BS01', '2021/07/21', '2021/07/21', '2021/08/21', N'Hóa đơn nhổ răng và thay răng sứ'),
	('HD03', 'KH03', 'BS08', '2021/07/09', '2021/07/09', '2021/09/24', N'Hóa đơn niềng răng'),
	('HD04', 'KH04', 'BS03', '2021/09/25', '2021/09/25', '2021/11/25', N'Hóa đơn xử lý răng khôn'),
	('HD05', 'KH05', 'BS04', '2021/09/29', '2021/09/29', '2021/10/29', N'Hóa đơn nhổ răng và thay răng sứ'),
	('HD06', 'KH06', 'BS08', '2021/10/06', '2021/10/06', '2021/11/06', N'Hóa đơn lấy vôi răng'),
	('HD07', 'KH07', 'BS01', '2021/10/24', '2021/10/24', '2021/11/24', N'Hóa đơn điều trịn nha chu'),
	('HD08', 'KH08', 'BS05', '2021/11/11', '2021/11/11', '2021/11/12', N'Hóa đơn nhổ răng và thay răng sứ'),
	('HD09', 'KH09', 'BS07', '2021/11/23', '2021/11/23', '2021/12/23', N'Hóa đơn niềng răng'),
	('HD10', 'KH10', 'BS06', '2021/12/06', '2021/12/06', '2022/01/06', N'Hóa đơn xử lý răng khôn'),
	('HD11', 'KH01', 'BS06', '2022/01/01', '2022/01/01', '2022/03/01', N'Hóa đơn nhổ răng và thay răng sứ, làm trắng răng'),
	('HD12', 'KH02', 'BS07', '2022/01/01', '2022/01/01', '2022/02/15', N'Hóa đơn xử lý răng khôn'),
	('HD13', 'KH03', 'BS02', '2022/01/02', '2022/01/02', '2022/03/02', N'Hóa đơn lấy vôi răng'),
	('HD14', 'KH04', 'BS01', '2022/01/02', '2022/01/02', '2022/03/02', N'Hóa đơn nhổ răng và thay răng sứ'),
	('HD15', 'KH05', 'BS02', '2022/01/02', '2022/01/02', '2022/05/02', N'Hóa đơn niềng răng'),
	('HD16', 'KH09', 'BS03', '2022/01/03', '2022/01/03', '2022/04/03', N'Hóa đơn niềng răng'),
	('HD17', 'KH10', 'BS01', '2022/01/04', '2022/01/04', '2022/02/04', N'Hóa đơn điều trịn nha chu, lằm trắng răng')


-- Thêm dữ liệu mẫu vào bảng Chi tiết hóa đơn
INSERT INTO CT_HoaDon(MaHD, MaDV, SoLuong)VALUES('HD01', 'DV01', 6);
INSERT INTO CT_HoaDon(MaHD, MaDV, SoLuong)VALUES('HD01', 'DV02', 3);
INSERT INTO CT_HoaDon(MaHD, MaDV, SoLuong)VALUES('HD02', 'DV07', 3);
INSERT INTO CT_HoaDon(MaHD, MaDV, SoLuong)VALUES('HD02', 'DV08', 2);
INSERT INTO CT_HoaDon(MaHD, MaDV, SoLuong)VALUES('HD03', 'DV05', 1);
INSERT INTO CT_HoaDon(MaHD, MaDV, SoLuong)VALUES('HD04', 'DV03', 6);
INSERT INTO CT_HoaDon(MaHD, MaDV, SoLuong)VALUES('HD05', 'DV07', 4);
INSERT INTO CT_HoaDon(MaHD, MaDV, SoLuong)VALUES('HD05', 'DV08', 3);
INSERT INTO CT_HoaDon(MaHD, MaDV, SoLuong)VALUES('HD06', 'DV01', 5);
INSERT INTO CT_HoaDon(MaHD, MaDV, SoLuong)VALUES('HD07', 'DV06', 7);
INSERT INTO CT_HoaDon(MaHD, MaDV, SoLuong)VALUES('HD08', 'DV07', 9);
INSERT INTO CT_HoaDon(MaHD, MaDV, SoLuong)VALUES('HD08', 'DV08', 5);
INSERT INTO CT_HoaDon(MaHD, MaDV, SoLuong)VALUES('HD09', 'DV05', 1);
INSERT INTO CT_HoaDon(MaHD, MaDV, SoLuong)VALUES('HD10', 'DV03', 3);
INSERT INTO CT_HoaDon(MaHD, MaDV, SoLuong)VALUES('HD11', 'DV02', 4);
INSERT INTO CT_HoaDon(MaHD, MaDV, SoLuong)VALUES('HD11', 'DV07', 4);
INSERT INTO CT_HoaDon(MaHD, MaDV, SoLuong)VALUES('HD11', 'DV08', 4);
INSERT INTO CT_HoaDon(MaHD, MaDV, SoLuong)VALUES('HD12', 'DV03', 3);
INSERT INTO CT_HoaDon(MaHD, MaDV, SoLuong)VALUES('HD13', 'DV01', 2);
INSERT INTO CT_HoaDon(MaHD, MaDV, SoLuong)VALUES('HD14', 'DV07', 2);
INSERT INTO CT_HoaDon(MaHD, MaDV, SoLuong)VALUES('HD14', 'DV08', 3);
INSERT INTO CT_HoaDon(MaHD, MaDV, SoLuong)VALUES('HD15', 'DV05', 1);
INSERT INTO CT_HoaDon(MaHD, MaDV, SoLuong)VALUES('HD16', 'DV05', 1);
INSERT INTO CT_HoaDon(MaHD, MaDV, SoLuong)VALUES('HD17', 'DV02', 7);
INSERT INTO CT_HoaDon(MaHD, MaDV, SoLuong)VALUES('HD17', 'DV06', 2);


select * from HoaDon

select * from BacSi

delete from CT_HoaDon

delete from HoaDon

delete from KhachHang where MaKH = 'KH093309DC'







/* ============== Trigger ================= */

/* 1. Trigger tự động tính và cập nhật trường Thành tiền trong bảng Chi tiết hóa đơn
và tự động cập nhật trường Tổng tiền trong bảng Hóa đơn khi insert vào bảng Chi tiết hóa đơn */

CREATE TRIGGER tinhtienHD
ON CT_HoaDon FOR INSERT
AS
BEGIN
	Declare @mahd char(10);
	Declare @madv char(10);
	Declare @soluong int;
	Declare @dongia bigint;
	Select @mahd = MaHD, @madv = MaDV, @soluong = SoLuong From inserted;
	Select @dongia = DonGia From DichVu Where MaDV = @madv;
	Update CT_HoaDon Set ThanhTien = (@soluongs * @dongia) Where MaHD = @mahd and MaDV = @madv;
	Update HoaDon
	Set TongTien = (Select SUM(ThanhTien)
					From CT_HoaDon
					Where MaHD = @mahd)
	Where MaHD = @mahd;
END


/* 2. Tạo Trigger để đảm bảo rằng khi thêm một loại mặt hàng vào bảng LoaiHang
thì tên loại mặt hàng thêm vào phải chưa có trong bảng. Nếu người dùng nhập một tên
loại mặt hàng đã có trong danh sách thì báo lỗi.
Thử thêm một loại mặt hàng vào trong bảng */

Create trigger trig_themdv
On DichVu for insert As 
Begin
	Declare @tendv nvarchar(100);
	Select @tendv = TenDV From inserted;
	If(@tendv in (Select TenDV from DichVu))
	Begin
		Print N'Dịch vụ có tên ' + @tendv + N' đã có trong cơ sở dữ liệu và không thể thêm mới. Vui lòng kiểm tra lại';
		rollback tran;
	End
	Else
		Print N'Đã thêm thành công dịch vụ ' + @tendv;
End

-----

INSERT INTO DichVu
VALUES('DV745', N'Lấy vôi răng', 400000, N'Cạo vôi răng, dánh bóng răng', 'TB02')

/* =============== Thủ tục ==================================================================================== */

/* 1. Thủ tục thống kê lịch sử sử dụng dịch vụ của một khách hàng nào đó.
Với tùy chọn sắp xếp theo ngày làm mới nhất hoặc cũ nhất
Và tùy chọn thống kê theo 1 dịch vụ nào đó hoặc thống kê tất cả các dịch vụ
*/

CREATE PROC pr_ThongKe_KHDV
@makh CHAR(10),
@madv char(10),
@sapxep nvarchar(30)
As Begin
   	If (@madv = 'tat ca')
   	Begin
         	If(@sapxep = 'moi nhat')
                	Select HD.NgayLam as 'Ngày làm', KH.MaKH as 'Mã khách hàng',
                	KH.TenKH as 'Họ và tên', HD.MaHD as 'Mã hóa đơn', DV.MaDV as 'Mã dịch vụ',
                	DV.TenDV as 'Tên dịch vụ', CTHD.SoLuong as 'Số lượng', CTHD.ThanhTien as 'Thành tiền'
                	From KhachHang KH, DichVu DV, HoaDon HD, CT_HoaDon CTHD
                	Where KH.MaKH = @makh and KH.MaKH = HD.MaKH and CTHD.MaHD = HD.MaHD
                	and DV.MaDV = CTHD.MaDV
                	Order by HD.NgayLam desc;
         	Else if(@sapxep = 'cu nhat')
                	Select HD.NgayLam as 'Ngày làm', KH.MaKH as 'Mã khách hàng',
                	KH.TenKH as 'Họ và tên', HD.MaHD as 'Mã hóa đơn', DV.MaDV as 'Mã dịch vụ',
                	DV.TenDV as 'Tên dịch vụ', CTHD.SoLuong as 'Số lượng', CTHD.ThanhTien as 'Thành tiền'
                	From KhachHang KH, DichVu DV, HoaDon HD, CT_HoaDon CTHD
                	Where KH.MaKH = @makh and KH.MaKH = HD.MaKH and CTHD.MaHD = HD.MaHD
                	and DV.MaDV = CTHD.MaDV
                	Order by HD.NgayLam asc;
   	End
   	Else
   	Begin
         	If(@sapxep = 'moi nhat')
                	Select HD.NgayLam as 'Ngày làm', KH.MaKH as 'Mã khách hàng',
                	KH.TenKH as 'Họ và tên', HD.MaHD as 'Mã hóa đơn', DV.MaDV as 'Mã dịch vụ',
                	DV.TenDV as 'Tên dịch vụ', CTHD.SoLuong as 'Số lượng', CTHD.ThanhTien as 'Thành tiền'
                	From KhachHang KH, DichVu DV, HoaDon HD, CT_HoaDon CTHD
                	Where KH.MaKH = @makh and CTHD.MaDV = @madv and KH.MaKH = HD.MaKH and CTHD.MaHD = HD.MaHD
                	and DV.MaDV = CTHD.MaDV
                	Order by HD.NgayLam desc;
         	Else if(@sapxep = 'cu nhat')
                	Select HD.NgayLam as 'Ngày làm', KH.MaKH as 'Mã khách hàng',
                	KH.TenKH as 'Họ và tên', HD.MaHD as 'Mã hóa đơn', DV.MaDV as 'Mã dịch vụ',
                	DV.TenDV as 'Tên dịch vụ', CTHD.SoLuong as 'Số lượng', CTHD.ThanhTien as 'Thành tiền'
                	From KhachHang KH, DichVu DV, HoaDon HD, CT_HoaDon CTHD
                	Where KH.MaKH = @makh and CTHD.MaDV = @madv and KH.MaKH = HD.MaKH and CTHD.MaHD = HD.MaHD
                	and DV.MaDV = CTHD.MaDV
                	Order by HD.NgayLam asc;
   	End
         	
End

-- Chạy thử
exec pr_ThongKe_KHDV 'KH02', 'tat ca', 'cu nhat';

/* 2. Thủ tục thống kê lịch sử tất cả các khách hàng đã sử dụng của một dịch vụ nào đó
Với tùy chọn sắp xếp theo ngày làm mới nhất hoặc cũ nhất.
*/
Create Proc pr_ThongKeDichVu
@madv char(10),
@sapxep nvarchar(30)
As Begin
	If(@sapxep = 'moi nhat')
		Select HD.NgayLam as 'Ngày làm', DV.MaDV as 'Mã dịch vụ', DV.TenDV as 'Tên dịch vụ', 
		KH.MaKH as 'Mã khách hàng', KH.TenKH as 'Họ và tên', HD.MaHD as 'Mã hóa đơn', 
		CTHD.SoLuong as 'Số lượng', CTHD.ThanhTien as 'Thành tiền'
		From DichVu DV, HoaDon HD, CT_HoaDon CTHD, KhachHang KH
		Where CTHD.MaDV = @madv and CTHD.MaHD = HD.MaHD and DV.MaDV = CTHD.MaDV and KH.MaKH = HD.MaKH
		Order by HD.NgayLam desc;
	Else if(@sapxep = 'cu nhat')
		Select HD.NgayLam as 'Ngày làm', DV.MaDV as 'Mã dịch vụ', DV.TenDV as 'Tên dịch vụ', 
		KH.MaKH as 'Mã khách hàng', KH.TenKH as 'Họ và tên', HD.MaHD as 'Mã hóa đơn', 
		CTHD.SoLuong as 'Số lượng', CTHD.ThanhTien as 'Thành tiền'
		From DichVu DV, HoaDon HD, CT_HoaDon CTHD, KhachHang KH
		Where CTHD.MaDV = @madv and CTHD.MaHD = HD.MaHD and DV.MaDV = CTHD.MaDV and KH.MaKH = HD.MaKH
		Order by HD.NgayLam asc;
End

-- Chạy thử
Exec pr_ThongKeDichVu 'DV07', 'moi nhat';




/* ====================== Hàm ==================== */

/* 1. Hàm trả về giá trị số lần làm một dịch vụ nào dó của một khách hàng nào đó */
Create function func_solanlamdichvu(@makh char(10), @madv char(10))
Returns int
As Begin
	Declare @tong int;
	Select @tong = COUNT(MaKH)
	From HoaDon, CT_HoaDon
	Where MaKH=@makh and MaDV = @madv and HoaDon.MaHD = CT_HoaDon.MaHD;
	Return @tong;
End
--
Select dbo.func_solanlamdichvu('KH01', 'DV02');

/* 2. Hàm tính số đơn hàng có sử một thiết bị nào đó */
Create function func_sodonhang_thietbi(@matb char(10))
Returns int
As
Begin
	Declare @soluong int;
	Select @soluong =  COUNT(ThietBiVatLieu.MaTB)
	From HoaDon inner join CT_HoaDon on HoaDon.MaHD = CT_HoaDon.MaHD
	inner join DichVu on CT_HoaDon.MaDV = DichVu.MaDV
	inner join ThietBiVatLieu on DichVu.MaTB = ThietBiVatLieu.MaTB
	Where ThietBiVatLieu.MaTB = @matb
	Return @soluong;
End
--
Select dbo.func_sodonhang_thietbi('TB02');




/* ====================== View ==================================================== */


/* 1.View hiển thị thông tin cơ bản của một nhà cung cấp thiết bị vật liệu với
số hóa đơn có sử dụng thiết bị của nhà cung cấp đó. */

Create view view_ncc(MaNhaCungCap, TenNhaCungCap, SDT, SoHoaDungThietBi, DiaChi)
As
	Select NhaCungCap.MaNCC, NhaCungCap.TenNCC, NhaCungCap.SDT, SUM(dbo.func_sodonhang_thietbi(MaTB)), NhaCungCap.DiaChi
	From NhaCungCap, ThietBiVatLieu
	Where NhaCungCap.MaNCC = ThietBiVatLieu.MaNCC
	Group by NhaCungCap.MaNCC, TenNCC, SDT, DiaChi

-----
Select * from view_ncc


/* 2. View hiển thị thông tin của các hóa đơn cùng với số dịch vụ trong hóa đơn đó. */
-- Create view view_hoadon(MaHoaDon)

Create view view_hoadon(MaHoaDon, MaKhachHang, TenKhachHang, SoDichVu, TenBacSi, Ngaylam, NgayXuatHoaDon, TongTien, NgayHenKhamLai)
As
	Select HoaDon.MaHD, KhachHang.MaKH, TenKH, COUNT(CT_HoaDon.MaDV), BacSi.TenBS, NgayLam, NgayXuatHoaDon, TongTien, NgayHenKhamLai
	From HoaDon inner join CT_HoaDon on HoaDon.MaHD = CT_HoaDon.MaHD
	inner join KhachHang on HoaDon.MaKH = KhachHang.MaKH
	inner join BacSi on HoaDon.MaBS = BacSi.MaBS
	group by HoaDon.MaHD, KhachHang.MaKH, TenKH, BacSi.TenBS, NgayLam, NgayXuatHoaDon, NgayHenKhamLai, TongTien, NgayHenKhamLai

--
Select * from view_hoadon




Select CT_HoaDon.MaDV, TenDV, SoLuong, DonGia, ThanhTien, MaTB, MoTa
from CT_HoaDon, DichVu Where CT_HoaDon.MaDV = DichVu.MaDV and MaHD = 'HD01';

select * from HoaDon

select * from CT_HoaDon