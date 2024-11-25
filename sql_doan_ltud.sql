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