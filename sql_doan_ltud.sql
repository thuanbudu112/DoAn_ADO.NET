create database quanly_cuahang_dienmay

use quanly_cuahang_dienmay

CREATE TABLE TaiKhoan (
    MaTaiKhoan INT IDENTITY(1,1) PRIMARY KEY, -- Mã tài khoản tự động tăng
    TenDangNhap NVARCHAR(50) NOT NULL UNIQUE, -- Tên đăng nhập duy nhất
    MatKhau NVARCHAR(100) NOT NULL,           -- Mật khẩu
    HoTen NVARCHAR(100),                      -- Họ tên người dùng
    Email NVARCHAR(100),                      -- Email liên hệ
    VaiTro NVARCHAR(50) DEFAULT 'User',       -- Vai trò (Admin/User...)
    NgayTao DATETIME DEFAULT GETDATE()        -- Ngày tạo tài khoản
);

INSERT INTO TaiKhoan (TenDangNhap, MatKhau, HoTen, Email, VaiTro)
VALUES
('admin', 'hashed_password_123', 'Quản Trị Viên', 'admin@domain.com', 'Admin'),
('user1', 'hashed_password_456', 'Người Dùng 1', 'user1@domain.com', 'User'),
('user2', 'hashed_password_789', 'Người Dùng 2', 'user2@domain.com', 'User');

select * from TaiKhoan

create proc dangnhap_taikhoan(@user nvarchar(50), @pass nvarchar(100))
as 
select count(*) from TaiKhoan
where TenDangNhap = @user and MatKhau = @pass

--Store Dang Ky
create proc tp_ThemTaiKhoan(@tenDangNhap nvarchar(50), @matKhau nvarchar(100),@hoTen nvarchar(100),@email nvarchar(100), @vaiTro nvarchar(50), @ngayTao datetime)
as 
insert into TaiKhoan values (@tenDangNhap, @matKhau ,@hoTen,@email,@vaiTro,@ngayTao)

exec tp_ThemTaiKhoan 'dongpham','123','Pham Dinh Dong','dong12062004@gmail.com','Tro vien','12/12/2020'

create proc tp_XoaTaiKhoan(@tenDangNhap nvarchar(50))
as
delete TaiKhoan
where TenDangNhap = @tenDangNhap

exec tp_XoaTaiKhoan 'dongpham'

create proc tp_SuaTaiKhoan(@tenDangNhap nvarchar(50), @matKhauNew nvarchar(100),@hoTenNew nvarchar(100),@emailNew nvarchar(100), @vaiTroNew nvarchar(50), @ngayTaoNew datetime)
as
update TaiKhoan
set MatKhau = @matKhauNew,
    HoTen = @hoTenNew,
	Email = @emailNew,
	VaiTro = @vaiTroNew,
	NgayTao = @ngayTaoNew
where TenDangNhap = @tenDangNhap

exec tp_SuaTaiKhoan 'dongpham','456','Pham Dinh Phuong','23211TT3228@mail.tdc.edu.vn','Giang vien','11/25/2024'

