-- ====================================================================================
-- HỌC PHẦN: COMP1019 - LẬP TRÌNH TRÊN WINDOWS
-- BUỔI 10 - BÀI LAB: THIẾT KẾ VÀ CÀI ĐẶT CƠ SỞ DỮ LIỆU EduManagerDB BẰNG SQL SERVER
-- TẬP TIN: 03_Queries.sql
-- MỤC ĐÍCH: Hiện thực đầy đủ 12 câu truy vấn theo yêu cầu bài lab bao gồm:
--           CRUD, JOIN, LIKE, GROUP BY, HAVING, AVG/COUNT và các ca kiểm thử ràng buộc.
-- ====================================================================================

USE EduManagerDB;
GO

-- ====================================================================================
-- PHẦN I: CÁC TRUY VẤN XEM, TÌM KIẾM VÀ CẬP NHẬT DỮ LIỆU (CÂU 1 -> 6)
-- ====================================================================================

-- ------------------------------------------------------------------------------------
-- CÂU 1: Liệt kê toàn bộ sinh viên trong hệ thống
-- ------------------------------------------------------------------------------------
PRINT N'--- CÂU 1: Danh sách toàn bộ sinh viên ---';
SELECT 
    MaSV, 
    HoTen, 
    CONVERT(VARCHAR(10), NgaySinh, 103) AS NgaySinhFormatted, 
    GioiTinh, 
    MaLop
FROM SINHVIEN
ORDER BY MaSV ASC;
GO

-- ------------------------------------------------------------------------------------
-- CÂU 2: Liệt kê sinh viên kèm tên lớp và tên khoa chủ quản (JOIN 3 bảng)
-- ------------------------------------------------------------------------------------
PRINT N'--- CÂU 2: Sinh viên kèm tên lớp và tên khoa ---';
SELECT 
    sv.MaSV, 
    sv.HoTen, 
    l.TenLop, 
    k.TenKhoa
FROM SINHVIEN sv
INNER JOIN LOP l ON sv.MaLop = l.MaLop
INNER JOIN KHOA k ON l.MaKhoa = k.MaKhoa
ORDER BY k.TenKhoa, l.TenLop, sv.MaSV;
GO

-- ------------------------------------------------------------------------------------
-- CÂU 3: Tìm sinh viên theo một phần họ tên bằng toán tử LIKE
-- (Ví dụ: Tìm sinh viên có chứa chữ "An" trong họ tên)
-- ------------------------------------------------------------------------------------
PRINT N'--- CÂU 3: Tìm sinh viên có chứa chữ "An" trong họ tên ---';
SELECT 
    MaSV, 
    HoTen, 
    GioiTinh, 
    MaLop
FROM SINHVIEN
WHERE HoTen LIKE N'%An%'
ORDER BY HoTen ASC;
GO

-- ------------------------------------------------------------------------------------
-- CÂU 4: Liệt kê danh sách sinh viên theo mã lớp cụ thể
-- (Ví dụ: Lớp CNTT01)
-- ------------------------------------------------------------------------------------
PRINT N'--- CÂU 4: Danh sách sinh viên thuộc lớp CNTT01 ---';
SELECT 
    MaSV, 
    HoTen, 
    NgaySinh, 
    GioiTinh
FROM SINHVIEN
WHERE MaLop = 'CNTT01'
ORDER BY MaSV ASC;
GO

-- ------------------------------------------------------------------------------------
-- CÂU 5: Cập nhật họ tên hoặc lớp của một sinh viên
-- (Ví dụ: Cập nhật tên của SV001 thành "Nguyễn Văn An (Đã cập nhật)")
-- ------------------------------------------------------------------------------------
PRINT N'--- CÂU 5: Cập nhật họ tên của SV001 ---';
UPDATE SINHVIEN
SET HoTen = N'Nguyễn Văn An (Đã cập nhật)'
WHERE MaSV = 'SV001';

-- Kiểm tra lại thông tin sau khi cập nhật:
SELECT MaSV, HoTen, MaLop FROM SINHVIEN WHERE MaSV = 'SV001';
GO

-- ------------------------------------------------------------------------------------
-- CÂU 6: Xóa một sinh viên chưa có dữ liệu điểm
-- (Ví dụ: Xóa SV003 - đảm bảo an toàn bằng điều kiện NOT EXISTS)
-- ------------------------------------------------------------------------------------
PRINT N'--- CÂU 6: Xóa sinh viên SV003 chưa có dữ liệu điểm ---';
DELETE FROM SINHVIEN
WHERE MaSV = 'SV003' 
  AND NOT EXISTS (SELECT 1 FROM KETQUA WHERE MaSV = 'SV003');

-- Kiểm tra lại để xác nhận SV003 đã được xóa thành công:
SELECT MaSV, HoTen, MaLop FROM SINHVIEN WHERE MaSV = 'SV003';
GO


-- ====================================================================================
-- PHẦN II: CÁC TRUY VẤN KẾT HỢP, TÍNH TOÁN & THỐNG KÊ (CÂU 7 -> 10)
-- ====================================================================================

-- ------------------------------------------------------------------------------------
-- CÂU 7: Liệt kê điểm của từng sinh viên theo từng môn học
-- ------------------------------------------------------------------------------------
PRINT N'--- CÂU 7: Điểm thi của sinh viên theo từng môn học ---';
SELECT 
    sv.MaSV, 
    sv.HoTen, 
    mh.TenMH, 
    mh.SoTinChi, 
    kq.Diem
FROM KETQUA kq
INNER JOIN SINHVIEN sv ON kq.MaSV = sv.MaSV
INNER JOIN MONHOC mh ON kq.MaMH = mh.MaMH
ORDER BY sv.MaSV ASC, mh.TenMH ASC;
GO

-- ------------------------------------------------------------------------------------
-- CÂU 8: Tính điểm trung bình của từng sinh viên (kèm làm tròn 2 chữ số thập phân)
-- ------------------------------------------------------------------------------------
PRINT N'--- CÂU 8: Điểm trung bình của từng sinh viên ---';
SELECT 
    sv.MaSV, 
    sv.HoTen, 
    ROUND(AVG(CAST(kq.Diem AS FLOAT)), 2) AS DiemTrungBinh,
    COUNT(kq.MaMH) AS SoMonDaHoc
FROM SINHVIEN sv
INNER JOIN KETQUA kq ON sv.MaSV = kq.MaSV
GROUP BY sv.MaSV, sv.HoTen
ORDER BY DiemTrungBinh DESC;
GO

-- ------------------------------------------------------------------------------------
-- CÂU 9: Thống kê số lượng sinh viên theo từng lớp (dùng LEFT JOIN để tính cả lớp trống)
-- ------------------------------------------------------------------------------------
PRINT N'--- CÂU 9: Thống kê số lượng sinh viên theo từng lớp ---';
SELECT 
    l.MaLop, 
    l.TenLop, 
    COUNT(sv.MaSV) AS SoSinhVien
FROM LOP l
LEFT JOIN SINHVIEN sv ON l.MaLop = sv.MaLop
GROUP BY l.MaLop, l.TenLop
ORDER BY SoSinhVien DESC, l.MaLop ASC;
GO

-- ------------------------------------------------------------------------------------
-- CÂU 10: Liệt kê các lớp có từ 2 sinh viên trở lên (sử dụng mệnh đề HAVING)
-- ------------------------------------------------------------------------------------
PRINT N'--- CÂU 10: Danh sách các lớp có từ 2 sinh viên trở lên ---';
SELECT 
    l.MaLop, 
    l.TenLop, 
    COUNT(sv.MaSV) AS SoSinhVien
FROM LOP l
LEFT JOIN SINHVIEN sv ON l.MaLop = sv.MaLop
GROUP BY l.MaLop, l.TenLop
HAVING COUNT(sv.MaSV) >= 2
ORDER BY SoSinhVien DESC;
GO


-- ====================================================================================
-- PHẦN III: KIỂM THỬ CÁC RÀNG BUỘC TOÀN VẸN (CONSTRAINT TESTING) (CÂU 11 -> 14)
-- Mỗi câu lệnh dưới đây đều được bọc trong khối TRY...CATCH để bắt lỗi và hiển thị
-- thông báo lỗi rõ ràng mà không làm gián đoạn kịch bản thực thi.
-- ====================================================================================

-- ------------------------------------------------------------------------------------
-- CÂU 11: Kiểm thử lỗi Khóa ngoại (Foreign Key) khi thêm sinh viên vào lớp không tồn tại
-- Kỳ vọng: Vi phạm ràng buộc FK_SINHVIEN_LOP (Foreign Key Violation).
-- ------------------------------------------------------------------------------------
PRINT N'--- CÂU 11: Kiểm thử lỗi FK khi thêm sinh viên vào lớp không tồn tại (CNTT99) ---';
BEGIN TRY
    INSERT INTO SINHVIEN (MaSV, HoTen, NgaySinh, GioiTinh, MaLop)
    VALUES ('SV999', N'Sinh viên lỗi', '2005-01-01', N'Nam', 'CNTT99');
    PRINT N'[THẤT BẠI]: Câu lệnh INSERT đã chạy được mà không bị chặn!';
END TRY
BEGIN CATCH
    PRINT N'[THÀNH CÔNG - ĐÃ BỊ CHẶN BỞI RÀNG BUỘC]:';
    PRINT N'Mã lỗi: ' + CAST(ERROR_NUMBER() AS NVARCHAR(10)) + N' - ' + ERROR_MESSAGE();
END CATCH;
GO

-- ------------------------------------------------------------------------------------
-- CÂU 12: Kiểm thử lỗi CHECK điểm số ngoài khoảng cho phép [0, 10]
-- Kỳ vọng: Vi phạm ràng buộc CK_KETQUA_Diem (Check Constraint Violation).
-- ------------------------------------------------------------------------------------
PRINT N'--- CÂU 12: Kiểm thử lỗi CHECK khi nhập điểm ngoài khoảng (Diem = 12.5) ---';
BEGIN TRY
    INSERT INTO KETQUA (MaSV, MaMH, Diem)
    VALUES ('SV001', 'COMP1019', 12.5);
    PRINT N'[THẤT BẠI]: Câu lệnh INSERT điểm 12.5 đã chạy được!';
END TRY
BEGIN CATCH
    PRINT N'[THÀNH CÔNG - ĐÃ BỊ CHẶN BỞI RÀNG BUỘC]:';
    PRINT N'Mã lỗi: ' + CAST(ERROR_NUMBER() AS NVARCHAR(10)) + N' - ' + ERROR_MESSAGE();
END CATCH;
GO

-- ------------------------------------------------------------------------------------
-- CÂU 13 (Mở rộng): Kiểm thử lỗi CHECK giới tính không phải Nam hoặc Nữ
-- Kỳ vọng: Vi phạm ràng buộc CK_SINHVIEN_GioiTinh.
-- ------------------------------------------------------------------------------------
PRINT N'--- CÂU 13: Kiểm thử lỗi CHECK giới tính (GioiTinh = N''Khác'') ---';
BEGIN TRY
    INSERT INTO SINHVIEN (MaSV, HoTen, NgaySinh, GioiTinh, MaLop)
    VALUES ('SV998', N'Sinh viên sai giới tính', '2005-01-01', N'Khác', 'CNTT01');
    PRINT N'[THẤT BẠI]: Giới tính ''Khác'' đã lọt qua ràng buộc!';
END TRY
BEGIN CATCH
    PRINT N'[THÀNH CÔNG - ĐÃ BỊ CHẶN BỞI RÀNG BUỘC]:';
    PRINT N'Mã lỗi: ' + CAST(ERROR_NUMBER() AS NVARCHAR(10)) + N' - ' + ERROR_MESSAGE();
END CATCH;
GO

-- ------------------------------------------------------------------------------------
-- CÂU 14 (Mở rộng): Kiểm thử lỗi Trùng khóa chính (Primary Key)
-- Kỳ vọng: Vi phạm ràng buộc PK_SINHVIEN (Duplicate Key Violation).
-- ------------------------------------------------------------------------------------
PRINT N'--- CÂU 14: Kiểm thử lỗi trùng khóa chính (Thêm lại MaSV = ''SV001'') ---';
BEGIN TRY
    INSERT INTO SINHVIEN (MaSV, HoTen, NgaySinh, GioiTinh, MaLop)
    VALUES ('SV001', N'Nguyễn Văn Trùng Mã', '2005-01-01', N'Nam', 'CNTT01');
    PRINT N'[THẤT BẠI]: Thêm trùng MaSV thành công (lỗi thiết kế)!';
END TRY
BEGIN CATCH
    PRINT N'[THÀNH CÔNG - ĐÃ BỊ CHẶN BỞI RÀNG BUỘC]:';
    PRINT N'Mã lỗi: ' + CAST(ERROR_NUMBER() AS NVARCHAR(10)) + N' - ' + ERROR_MESSAGE();
END CATCH;
GO

PRINT N'==> Hoàn thành toàn bộ kịch bản kiểm tra và truy vấn cho EduManagerDB!';
GO
