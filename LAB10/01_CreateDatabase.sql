-- ====================================================================================
-- HỌC PHẦN: COMP1019 - LẬP TRÌNH TRÊN WINDOWS
-- BUỔI 10 - BÀI LAB: THIẾT KẾ VÀ CÀI ĐẶT CƠ SỞ DỮ LIỆU EduManagerDB BẰNG SQL SERVER
-- TẬP TIN: 01_CreateDatabase.sql
-- MỤC ĐÍCH: Tạo database EduManagerDB và định nghĩa 6 bảng bắt buộc
--           cùng các khóa chính, khóa ngoại, ràng buộc toàn vẹn (CHECK, DEFAULT).
-- ====================================================================================

USE master;
GO

-- 1. XÓA CSDL CŨ NẾU ĐÃ TỒN TẠI ĐỂ ĐẢM BẢO MÔI TRƯỜNG CHẠY SẠCH (IDEMPOTENT)
IF EXISTS (SELECT 1 FROM sys.databases WHERE name = N'EduManagerDB')
BEGIN
    ALTER DATABASE EduManagerDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE EduManagerDB;
END;
GO

-- 2. KHỞI TẠO CƠ SỞ DỮ LIỆU MỚI
CREATE DATABASE EduManagerDB;
GO

USE EduManagerDB;
GO

-- ====================================================================================
-- 3. TẠO CÁC BẢNG THEO ĐÚNG THỨ TỰ QUAN HỆ (BẢNG ĐỘC LẬP TRƯỚC, BẢNG PHỤ THUỘC SAU)
-- ====================================================================================

-- ------------------------------------------------------------------------------------
-- BẢNG 1: KHOA
-- Mục đích: Quản lý danh mục các khoa trong trường học.
-- ------------------------------------------------------------------------------------
CREATE TABLE KHOA (
    MaKhoa VARCHAR(20) NOT NULL,
    TenKhoa NVARCHAR(100) NOT NULL,
    DienThoai VARCHAR(15) NULL,
    CONSTRAINT PK_KHOA PRIMARY KEY (MaKhoa)
);
GO

-- ------------------------------------------------------------------------------------
-- BẢNG 2: LOP
-- Mục đích: Quản lý danh sách lớp học trực thuộc từng khoa.
-- Khóa ngoại: MaKhoa tham chiếu tới KHOA(MaKhoa).
-- ------------------------------------------------------------------------------------
CREATE TABLE LOP (
    MaLop VARCHAR(20) NOT NULL,
    TenLop NVARCHAR(100) NOT NULL,
    MaKhoa VARCHAR(20) NOT NULL,
    CONSTRAINT PK_LOP PRIMARY KEY (MaLop),
    CONSTRAINT FK_LOP_KHOA 
        FOREIGN KEY (MaKhoa) REFERENCES KHOA(MaKhoa)
        ON UPDATE CASCADE 
        ON DELETE NO ACTION
);
GO

-- ------------------------------------------------------------------------------------
-- BẢNG 3: SINHVIEN
-- Mục đích: Quản lý hồ sơ lý lịch sinh viên theo từng lớp.
-- Ràng buộc: GioiTinh chỉ nhận giá trị N'Nam' hoặc N'Nữ'.
-- Khóa ngoại: MaLop tham chiếu tới LOP(MaLop).
-- ------------------------------------------------------------------------------------
CREATE TABLE SINHVIEN (
    MaSV VARCHAR(20) NOT NULL,
    HoTen NVARCHAR(100) NOT NULL,
    NgaySinh DATE NULL,
    GioiTinh NVARCHAR(10) NOT NULL,
    MaLop VARCHAR(20) NOT NULL,
    CONSTRAINT PK_SINHVIEN PRIMARY KEY (MaSV),
    CONSTRAINT CK_SINHVIEN_GioiTinh 
        CHECK (GioiTinh IN (N'Nam', N'Nữ')),
    CONSTRAINT FK_SINHVIEN_LOP 
        FOREIGN KEY (MaLop) REFERENCES LOP(MaLop)
        ON UPDATE CASCADE 
        ON DELETE NO ACTION
);
GO

-- ------------------------------------------------------------------------------------
-- BẢNG 4: MONHOC
-- Mục đích: Quản lý thông tin môn học và khối lượng kiến thức.
-- Ràng buộc: SoTinChi bắt buộc phải lớn hơn 0.
-- ------------------------------------------------------------------------------------
CREATE TABLE MONHOC (
    MaMH VARCHAR(20) NOT NULL,
    TenMH NVARCHAR(100) NOT NULL,
    SoTinChi INT NOT NULL,
    CONSTRAINT PK_MONHOC PRIMARY KEY (MaMH),
    CONSTRAINT CK_MONHOC_SoTinChi 
        CHECK (SoTinChi > 0)
);
GO

-- ------------------------------------------------------------------------------------
-- BẢNG 5: KETQUA
-- Mục đích: Lưu kết quả học tập (điểm thi) của từng sinh viên theo từng môn học.
-- Khóa chính hỗn hợp: (MaSV, MaMH) chống trùng lặp điểm của cùng 1 SV cho 1 môn.
-- Ràng buộc: Diem phải nằm trong khoảng từ 0 đến 10.
-- Khóa ngoại: MaSV tham chiếu SINHVIEN(MaSV), MaMH tham chiếu MONHOC(MaMH).
-- ------------------------------------------------------------------------------------
CREATE TABLE KETQUA (
    MaSV VARCHAR(20) NOT NULL,
    MaMH VARCHAR(20) NOT NULL,
    Diem DECIMAL(4, 2) NOT NULL,
    CONSTRAINT PK_KETQUA PRIMARY KEY (MaSV, MaMH),
    CONSTRAINT CK_KETQUA_Diem 
        CHECK (Diem >= 0.0 AND Diem <= 10.0),
    CONSTRAINT FK_KETQUA_SINHVIEN 
        FOREIGN KEY (MaSV) REFERENCES SINHVIEN(MaSV)
        ON UPDATE CASCADE 
        ON DELETE CASCADE,
    CONSTRAINT FK_KETQUA_MONHOC 
        FOREIGN KEY (MaMH) REFERENCES MONHOC(MaMH)
        ON UPDATE CASCADE 
        ON DELETE CASCADE
);
GO

-- ------------------------------------------------------------------------------------
-- BẢNG 6: TAIKHOAN
-- Mục đích: Lưu trữ thông tin tài khoản đăng nhập cho ứng dụng.
-- Giá trị mặc định: VaiTro là 'User', TrangThai là 1 (Hoạt động).
-- ------------------------------------------------------------------------------------
CREATE TABLE TAIKHOAN (
    TenDangNhap VARCHAR(50) NOT NULL,
    MatKhau VARCHAR(100) NOT NULL,
    HoTen NVARCHAR(100) NOT NULL,
    VaiTro VARCHAR(20) NOT NULL CONSTRAINT DF_TAIKHOAN_VaiTro DEFAULT 'User',
    TrangThai BIT NOT NULL CONSTRAINT DF_TAIKHOAN_TrangThai DEFAULT 1,
    CONSTRAINT PK_TAIKHOAN PRIMARY KEY (TenDangNhap)
);
GO

PRINT N'==> Đã khởi tạo thành công CSDL EduManagerDB và 6 bảng bắt buộc với đầy đủ khóa chính, khóa ngoại, ràng buộc!';
GO
