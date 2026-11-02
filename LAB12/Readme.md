# LAB 12: NHẬP ĐIỂM THEO LỚP & KIẾN TRÚC ĐA TẦNG (DATA ACCESS LAYER, STORED PROCEDURES & TRANSACTION)

## 📌 Giới thiệu tổng quan
**LAB 12** (tên dự án: `QLSinhVienLab12`) là ứng dụng Windows Forms phát triển trên nền tảng **.NET Framework 4.8**, áp dụng mô hình kiến trúc phân tầng (**Layered Architecture** / **Data Access Layer - DAL**), sử dụng các thủ tục lưu trữ trên cơ sở dữ liệu (**Stored Procedures**) và cơ chế kiểm soát giao dịch (**Database Transaction**) nhằm đảm bảo tính toàn vẹn (ACID) khi nhập điểm số cho sinh viên theo lớp học và môn học.

---

## 🎯 Mục tiêu bài thực hành
- Áp dụng nguyên tắc tách biệt mối quan tâm (Separation of Concerns): phân tách rõ ràng tầng hiển thị giao diện (**Forms / GUI**) và tầng truy cập dữ liệu (**DAL - Data Access Layer**).
- Đóng gói toàn bộ câu lệnh truy vấn và thao tác dữ liệu phía Server bằng **Stored Procedures** trong SQL Server.
- Xử lý bài toán cập nhật dữ liệu hàng loạt (Batch Processing) từ bảng `DataGridView` xuống cơ sở dữ liệu.
- Quản lý giao dịch an toàn với `SqlTransaction`: đảm bảo toàn bộ danh sách điểm phải được lưu thành công trọn vẹn (`Commit`), hoặc hủy bỏ hoàn toàn (`Rollback`) khi có bất kỳ dòng dữ liệu nào gặp lỗi.
- Kiểm tra tính hợp lệ của điểm số (Validation): không được để trống, phải là số thực hợp lệ và nằm trong thang điểm quy định từ **0 đến 10**.

---

## 🛠️ Công nghệ & Môi trường phát triển
- **Ngôn ngữ:** C# (.NET Framework 4.8)
- **Cơ sở dữ liệu:** Microsoft SQL Server
- **Thư viện kết nối:** `Microsoft.Data.SqlClient` (v7.1.1)
- **Kiến trúc ứng dụng:** Layered Architecture (DAL + Presentation GUI)
- **IDE khuyến nghị:** Visual Studio 2019 / Visual Studio 2022
- **Công cụ CSDL:** SQL Server Management Studio (SSMS)

---

## 📁 Cấu trúc thư mục
```text
LAB12/
├── QLSinhVienLab12.slnx               # Solution file
└── LAB12/
    ├── QLSinhVienLab12.csproj         # Cấu hình dự án & nạp packages
    ├── packages.config                # Danh sách thư viện NuGet
    ├── App.config                     # Cấu hình chuỗi kết nối
    ├── Program.cs                     # Điểm khởi chạy ứng dụng
    ├── DAL/                           # Tầng truy xuất dữ liệu (Data Access Layer)
    │   ├── Database.cs                # Lớp tĩnh cung cấp đối tượng SqlConnection
    │   └── KetQuaDAL.cs               # Lớp xử lý nghiệp vụ & gọi Stored Procedures
    ├── Forms/                         # Tầng giao diện người dùng (Presentation Layer)
    │   ├── FrmNhapDiemTheoLop.cs      # Xử lý nhập điểm, nạp dữ liệu và phản hồi
    │   └── FrmNhapDiemTheoLop.Designer.cs
    └── Properties/
        ├── AssemblyInfo.cs
        ├── Resources.resx
        └── Settings.settings
```

---

## 🗄️ Thiết kế Cơ sở dữ liệu (`QLSinhVienLab12`)

### 1. Cấu trúc bảng
- **`LOP`:** `MaLop` (PK), `TenLop`.
- **`MONHOC`:** `MaMon` (PK), `TenMon`, `SoTinChi`.
- **`SINHVIEN`:** `MaSV` (PK), `HoTen`, `NgaySinh`, `MaLop` (FK).
- **`KETQUA`:** `MaSV` (PK, FK), `MaMon` (PK, FK), `Diem` (FLOAT), `GhiChu` (NVARCHAR).

### 2. Kịch bản Stored Procedures (Setup Script)
```sql
CREATE DATABASE QLSinhVienLab12;
GO

USE QLSinhVienLab12;
GO

-- 1. Thủ tục lấy danh sách tất cả các Lớp
CREATE PROCEDURE sp_Lop_GetAll
AS
BEGIN
    SELECT MaLop, TenLop FROM LOP ORDER BY MaLop;
END;
GO

-- 2. Thủ tục lấy danh sách tất cả các Môn học
CREATE PROCEDURE sp_MonHoc_GetAll
AS
BEGIN
    SELECT MaMon, TenMon FROM MONHOC ORDER BY MaMon;
END;
GO

-- 3. Thủ tục lấy danh sách sinh viên và điểm theo Lớp & Môn
CREATE PROCEDURE sp_KetQua_GetByLopMon
    @MaLop VARCHAR(20),
    @MaMon VARCHAR(20)
AS
BEGIN
    SELECT 
        sv.MaSV,
        sv.HoTen,
        kq.Diem,
        kq.GhiChu
    FROM SINHVIEN sv
    LEFT JOIN KETQUA kq ON sv.MaSV = kq.MaSV AND kq.MaMon = @MaMon
    WHERE sv.MaLop = @MaLop
    ORDER BY sv.MaSV;
END;
GO

-- 4. Thủ tục lưu hoặc cập nhật điểm (Upsert) cho một sinh viên
CREATE PROCEDURE sp_KetQua_Save
    @MaSV VARCHAR(20),
    @MaMon VARCHAR(20),
    @Diem FLOAT,
    @GhiChu NVARCHAR(200)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM KETQUA WHERE MaSV = @MaSV AND MaMon = @MaMon)
    BEGIN
        UPDATE KETQUA 
        SET Diem = @Diem, GhiChu = @GhiChu 
        WHERE MaSV = @MaSV AND MaMon = @MaMon;
    END
    ELSE
    BEGIN
        INSERT INTO KETQUA (MaSV, MaMon, Diem, GhiChu) 
        VALUES (@MaSV, @MaMon, @Diem, @GhiChu);
    END
END;
GO
```

---

## 🏛️ Kiến trúc & Tính năng nổi bật

### 1. Tầng Data Access Layer (`KetQuaDAL.cs`)
- Độc lập hoàn toàn với giao diện Windows Forms, chỉ trả về dữ liệu chuẩn (`DataTable`, `tuple`).
- `GetAllLop()` & `GetAllMonHoc()`: Gọi Stored Procedures `sp_Lop_GetAll` và `sp_MonHoc_GetAll`.
- `GetKetQuaByLopMon(maLop, maMon)`: Truy vấn danh sách sinh viên kèm điểm số đã có theo từng môn học.

### 2. Quản lý giao dịch an toàn (`SqlTransaction`)
Phương thức `SaveAllKetQua` tiến hành theo 2 bước:
1. **Kiểm tra hợp lệ trước khi mở giao dịch (Pre-validation):** Duyệt qua toàn bộ các dòng của bảng `DataTable`. Nếu phát hiện có dòng thiếu điểm, sai định dạng số hoặc điểm nằm ngoài thang $[0, 10]$, trả về mã lỗi và dừng ngay lập tức mà không tác động tới CSDL.
2. **Thực thi giao dịch:**
   ```csharp
   using (SqlTransaction transaction = conn.BeginTransaction())
   {
       try
       {
           foreach (DataRow row in dtKetQua.Rows)
           {
               using (SqlCommand cmd = new SqlCommand("sp_KetQua_Save", conn, transaction))
               {
                   cmd.CommandType = CommandType.StoredProcedure;
                   // Gán tham số và ExecuteNonQuery()
               }
           }
           transaction.Commit(); // Hoàn tất thành công
       }
       catch (Exception ex)
       {
           transaction.Rollback(); // Hủy bỏ và khôi phục trạng thái ban đầu khi có lỗi
       }
   }
   ```

### 3. Giao diện Nhập điểm trực quan (`FrmNhapDiemTheoLop`)
- Lựa chọn Lớp học và Môn học thông qua ComboBox.
- Bảng nhập điểm `dgvKetQua` hiển thị thông tin rõ ràng: Cột Mã SV và Họ tên ở chế độ chỉ đọc (`ReadOnly`), người dùng chỉ cần nhập trực tiếp Điểm và Ghi chú trên lưới.
- Nút **"Lưu điểm"** thực hiện xác thực và lưu trọn vẹn dữ liệu, đồng thời phản hồi kết quả chi tiết lên thanh trạng thái.

---

## 🚀 Hướng dẫn cài đặt và chạy ứng dụng
1. Thực thi đoạn mã script tạo cơ sở dữ liệu `QLSinhVienLab12` và các Stored Procedures trong **SQL Server**.
2. Kiểm tra chuỗi kết nối trong file `LAB12/DAL/Database.cs`.
3. Mở file `QLSinhVienLab12.slnx` hoặc `QLSinhVienLab12.csproj` trong **Visual Studio**.
4. Nhấn **F5** để khởi chạy chương trình.
