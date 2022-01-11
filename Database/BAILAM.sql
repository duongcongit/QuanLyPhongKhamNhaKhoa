

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


/* 3. Thủ tục thống kê lịch sử sử dụng dịch vụ của một khách hàng nào đó.
Với tùy chọn sắp xếp theo ngày làm mới nhất hoặc cũ nhất
Và tùy chọn thống kê theo 1 dịch vụ nào đó hoặc thống kê tất cả các dịch vụ
*/

CREATE PROC pr_ThongKe_DVKH
@makh CHAR(10),
@madv char(10),
@sapxep nvarchar(30)
As Begin
   	If (@madv = 'tat ca')
   	Begin
         	If(@sapxep = 'moi nhat')
                	Select HD.MaHD as 'Mã hóa đơn', DV.MaDV as 'Mã dịch vụ', DV.TenDV as 'Tên dịch vụ',
					HD.NgayLam as 'Ngày làm', CTHD.SoLuong as 'Số lượng', 
					DV.DonGia as 'Đơn giá', CTHD.ThanhTien as 'Thành tiền'
                	From KhachHang KH, DichVu DV, HoaDon HD, CT_HoaDon CTHD
                	Where KH.MaKH = @makh and KH.MaKH = HD.MaKH and CTHD.MaHD = HD.MaHD
                	and DV.MaDV = CTHD.MaDV
                	Order by HD.NgayLam desc;
         	Else if(@sapxep = 'cu nhat')
                	Select HD.MaHD as 'Mã hóa đơn', DV.MaDV as 'Mã dịch vụ', DV.TenDV as 'Tên dịch vụ',
					HD.NgayLam as 'Ngày làm', CTHD.SoLuong as 'Số lượng', 
					DV.DonGia as 'Đơn giá', CTHD.ThanhTien as 'Thành tiền'
                	From KhachHang KH, DichVu DV, HoaDon HD, CT_HoaDon CTHD
                	Where KH.MaKH = @makh and KH.MaKH = HD.MaKH and CTHD.MaHD = HD.MaHD
                	and DV.MaDV = CTHD.MaDV
                	Order by HD.NgayLam asc;
   	End
   	Else
   	Begin
         	If(@sapxep = 'moi nhat')
                	Select HD.MaHD as 'Mã hóa đơn', DV.MaDV as 'Mã dịch vụ', DV.TenDV as 'Tên dịch vụ',
					HD.NgayLam as 'Ngày làm', CTHD.SoLuong as 'Số lượng', 
					DV.DonGia as 'Đơn giá', CTHD.ThanhTien as 'Thành tiền'
                	From KhachHang KH, DichVu DV, HoaDon HD, CT_HoaDon CTHD
                	Where KH.MaKH = @makh and CTHD.MaDV = @madv and KH.MaKH = HD.MaKH and CTHD.MaHD = HD.MaHD
                	and DV.MaDV = CTHD.MaDV
                	Order by HD.NgayLam desc;
         	Else if(@sapxep = 'cu nhat')
                	Select HD.MaHD as 'Mã hóa đơn', DV.MaDV as 'Mã dịch vụ', DV.TenDV as 'Tên dịch vụ',
					HD.NgayLam as 'Ngày làm', CTHD.SoLuong as 'Số lượng', 
					DV.DonGia as 'Đơn giá', CTHD.ThanhTien as 'Thành tiền'
                	From KhachHang KH, DichVu DV, HoaDon HD, CT_HoaDon CTHD
                	Where KH.MaKH = @makh and CTHD.MaDV = @madv and KH.MaKH = HD.MaKH and CTHD.MaHD = HD.MaHD
                	and DV.MaDV = CTHD.MaDV
                	Order by HD.NgayLam asc;
   	End
         	
End

-- Chạy thử
exec pr_ThongKe_DVKH 'KH02', 'tat ca', 'cu nhat';



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


Select * from KhachHang


SELECT HoaDon.MaHD, DichVu.MaDV, TenDV, HoaDon.NgayLam, SoLuong, DonGia, ThanhTien, DichVu.MoTa
From CT_HoaDon, HoaDon, DichVu Where CT_HoaDon.MaHD=HoaDon.MaHD and CT_HoaDon.MaDV = DichVu.MaDV and MaKH ='KH02'

Select MaHD, BacSi.MaBS, TenBS, NgayLam, NgayHenKhamLai, NgayXuatHoaDon, TongTien, MoTa
From HoaDon, KhachHang, BacSi
Where HoaDon.MaKH = KhachHang.MaKH and HoaDon.MaBS = BacSi.MaBS and KhachHang.MaKH = 'KH02'

Delete from CT_HoaDon Where MaHD in (Select MaHD from HoaDon Where MaKH = '{0}')

select * from KhachHang Where SDT = '0365789451'


select * from BacSi

Select MaHD, KhachHang.MaKH, TenKH, NgayLam, NgayHenKhamLai, NgayXuatHoaDon, TongTien, MoTa From HoaDon, KhachHang, BacSi 
Where HoaDon.MaKH = KhachHang.MaKH and HoaDon.MaBS = BacSi.MaBS and BacSi.MaBS = 'BS02'


select * from DichVu, ThietBiVatLieu
Where DichVu.MaTB = ThietBiVatLieu.MaTB and MaDV =''

Select *
From HoaDon inner join CT_HoaDon on HoaDon.MaHD = CT_HoaDon.MaHD inner join DichVu on CT_HoaDon.MaDV = DichVu.MaDV
Where DichVu.MaDV = 'DV01'