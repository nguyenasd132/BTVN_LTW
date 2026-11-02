-- ====================================================================================
-- HỌC PHẦN: COMP1019 - LẬP TRÌNH TRÊN WINDOWS
-- BUỔI 10 - BÀI LAB: THIẾT KẾ VÀ CÀI ĐẶT CƠ SỞ DỮ LIỆU EduManagerDB BẰNG SQL SERVER
-- TẬP TIN: 02_InsertSampleData.sql
-- MỤC ĐÍCH: Nhập dữ liệu mẫu đầy đủ, chuẩn quan hệ và đáp ứng các tiêu chí bài lab:
--           >= 2 khoa, >= 3 lớp, >= 6 sinh viên, >= 4 môn học, >= 8 kết quả, >= 2 tài khoản.
-- ====================================================================================

USE EduManagerDB;
GO

-- 1. NHẬP DỮ LIỆU BẢNG KHOA (Tối thiểu 2 khoa)
INSERT INTO KHOA (MaKhoa, TenKhoa, DienThoai) VALUES
('FIT',  N'Khoa Công nghệ Thông tin', '0281234567'),
('MATH', N'Khoa Toán - Tin học',       '0287654321');
GO

-- 2. NHẬP DỮ LIỆU BẢNG LOP (Tối thiểu 3 lớp)
-- Phải nhập sau KHOA vì MaKhoa tham chiếu đến KHOA(MaKhoa)
INSERT INTO LOP (MaLop, TenLop, MaKhoa) VALUES
('CNTT01',  N'Công nghệ thông tin 01', 'FIT'),
('CNTT02',  N'Công nghệ thông tin 02', 'FIT'),
('SPTIN01', N'Sư phạm Tin học 01',     'MATH');
GO

-- 3. NHẬP DỮ LIỆU BẢNG SINHVIEN (Tối thiểu 6 sinh viên)
-- Phải nhập sau LOP vì MaLop tham chiếu đến LOP(MaLop)
-- Giới tính chỉ nhận N'Nam' hoặc N'Nữ' theo ràng buộc CK_SINHVIEN_GioiTinh
INSERT INTO SINHVIEN (MaSV, HoTen, NgaySinh, GioiTinh, MaLop) VALUES
('SV001', N'Nguyễn Văn An',  '2005-02-10', N'Nam', 'CNTT01'),
('SV002', N'Trần Thị Bình',  '2005-08-21', N'Nữ',  'CNTT01'),
('SV003', N'Lê Minh Chi',    '2004-12-02', N'Nữ',  'CNTT02'),
('SV004', N'Phạm Quốc Dung', '2005-04-16', N'Nam', 'CNTT02'),
('SV005', N'Hoàng Gia Hân',  '2005-10-30', N'Nữ',  'SPTIN01'),
('SV006', N'Võ Thành Khang', '2004-09-09', N'Nam', 'SPTIN01');
GO

-- 4. NHẬP DỮ LIỆU BẢNG MONHOC (Tối thiểu 4 môn học)
-- SoTinChi bắt buộc > 0 theo ràng buộc CK_MONHOC_SoTinChi
INSERT INTO MONHOC (MaMH, TenMH, SoTinChi) VALUES
('COMP1019', N'Lập trình trên Windows',      3),
('COMP1017', N'Lập trình cơ bản',            3),
('COMP1020', N'Cơ sở dữ liệu',               3),
('COMP1044', N'Nhập môn Công nghệ phần mềm', 3);
GO

-- 5. NHẬP DỮ LIỆU BẢNG KETQUA (Tối thiểu 8 kết quả điểm)
-- Điểm nằm trong khoảng [0, 10]
-- Ghi chú: SV003 tạm thời không có điểm để phục vụ kiểm thử câu xóa sinh viên chưa có điểm
INSERT INTO KETQUA (MaSV, MaMH, Diem) VALUES
('SV001', 'COMP1019', 8.50),
('SV001', 'COMP1020', 7.50),
('SV002', 'COMP1019', 9.00),
('SV002', 'COMP1020', 8.00),
('SV004', 'COMP1019', 7.00),
('SV004', 'COMP1020', 6.50),
('SV005', 'COMP1017', 8.00),
('SV006', 'COMP1044', 7.80);
GO

-- 6. NHẬP DỮ LIỆU BẢNG TAIKHOAN (Tối thiểu 2 tài khoản)
INSERT INTO TAIKHOAN (TenDangNhap, MatKhau, HoTen, VaiTro, TrangThai) VALUES
('admin', '123456', N'Quản trị viên', 'Admin', 1),
('gv01',  '123456', N'Giảng viên demo', 'User',  1);
GO

PRINT N'==> Đã nạp thành công dữ liệu mẫu cho toàn bộ 6 bảng trong EduManagerDB!';
GO
