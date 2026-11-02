# LAB 11: QUẢN LÝ LỚP HỌC VỚI ADO.NET & SQL SERVER (DATABASE INTEGRATION)

## 📌 Giới thiệu tổng quan
**LAB 11** là ứng dụng Windows Forms phát triển trên nền tảng **.NET Framework 4.8**, tập trung vào việc tích hợp ứng dụng desktop với hệ quản trị cơ sở dữ liệu quan hệ **Microsoft SQL Server** thông qua thư viện kết nối hiện đại **`Microsoft.Data.SqlClient`**. Ứng dụng thực hiện bài toán quản lý danh mục Lớp học, xử lý các thao tác CRUD dữ liệu an toàn chống tấn công SQL Injection và kiểm soát toàn vẹn dữ liệu khóa ngoại.

---

## 🎯 Mục tiêu bài thực hành
- Thiết lập chuỗi kết nối an toàn với SQL Server (`ConnectionString`, `Integrated Security`, `TrustServerCertificate`).
- Thành thạo các đối tượng cốt lõi trong kiến trúc **ADO.NET**:
  - `SqlConnection`: Khởi tạo và quản lý phiên kết nối tới CSDL.
  - `SqlCommand`: Thiết lập và thực thi các câu lệnh SQL với tham số (`SqlParameter`).
  - `SqlDataAdapter` & `DataTable`: Mô hình ngắt kết nối (Disconnected Architecture) để nạp và đổ dữ liệu lên `DataGridView` và `ComboBox`.
  - `ExecuteNonQuery()` và `ExecuteScalar()`: Thực thi lệnh cập nhật dữ liệu và truy vấn giá trị đơn lẻ.
- Truy vấn kết hợp nhiều bảng (`LEFT JOIN`), gom nhóm dữ liệu (`GROUP BY`) và đếm số lượng bản ghi liên kết (`COUNT()`).
- Kiểm tra ràng buộc toàn vẹn dữ liệu (Referential Integrity): ngăn chặn hành vi xóa lớp học khi đang có sinh viên trực thuộc.

---

## 🛠️ Công nghệ & Môi trường phát triển
- **Ngôn ngữ:** C# (.NET Framework 4.8)
- **Cơ sở dữ liệu:** Microsoft SQL Server (khuyến nghị SQL Server Express)
- **Thư viện kết nối:** `Microsoft.Data.SqlClient` (v7.1.1)
- **IDE khuyến nghị:** Visual Studio 2019 / Visual Studio 2022
- **Công cụ quản trị CSDL:** SQL Server Management Studio (SSMS)

---

## 📁 Cấu trúc thư mục
```text
LAB11/
├── LAB11.slnx                 # Solution file
└── LAB11/
    ├── LAB11.csproj           # Cấu hình dự án & nạp packages NuGet
    ├── packages.config        # Danh sách thư viện NuGet (Microsoft.Data.SqlClient)
    ├── App.config             # Cấu hình runtime
    ├── Program.cs             # Điểm khởi động ứng dụng
    ├── FrmLop.cs              # Code-behind xử lý kết nối CSDL và các sự kiện CRUD
    ├── FrmLop.Designer.cs     # Khởi tạo giao diện Form Quản lý lớp
    └── Properties/
        ├── AssemblyInfo.cs
        ├── Resources.resx
        └── Settings.settings
```

---

## 🗄️ Thiết kế Cơ sở dữ liệu (`EduManagerDB`)

### 1. Sơ đồ các bảng liên quan
- **Bảng `KHOA`:**
  - `MaKhoa` (`VARCHAR(20)`, Primary Key): Mã khoa.
  - `TenKhoa` (`NVARCHAR(100)`): Tên khoa.
- **Bảng `LOP`:**
  - `MaLop` (`VARCHAR(20)`, Primary Key): Mã lớp.
  - `TenLop` (`NVARCHAR(100)`): Tên lớp.
  - `MaKhoa` (`VARCHAR(20)`, Foreign Key tham chiếu `KHOA.MaKhoa`): Mã khoa quản lý lớp.
- **Bảng `SINHVIEN`:**
  - `MaSV` (`VARCHAR(20)`, Primary Key): Mã sinh viên.
  - `HoTen` (`NVARCHAR(100)`): Họ tên sinh viên.
  - `MaLop` (`VARCHAR(20)`, Foreign Key tham chiếu `LOP.MaLop`): Lớp mà sinh viên đang theo học.

### 2. Kịch bản SQL tạo Database & Bảng mẫu (Setup Script)
```sql
CREATE DATABASE EduManagerDB;
GO

USE EduManagerDB;
GO

CREATE TABLE KHOA (
    MaKhoa VARCHAR(20) PRIMARY KEY,
    TenKhoa NVARCHAR(100) NOT NULL
);

CREATE TABLE LOP (
    MaLop VARCHAR(20) PRIMARY KEY,
    TenLop NVARCHAR(100) NOT NULL,
    MaKhoa VARCHAR(20) REFERENCES KHOA(MaKhoa)
);

CREATE TABLE SINHVIEN (
    MaSV VARCHAR(20) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    MaLop VARCHAR(20) REFERENCES LOP(MaLop)
);

-- Chèn dữ liệu mẫu
INSERT INTO KHOA (MaKhoa, TenKhoa) VALUES 
('CNTT', N'Công nghệ thông tin'),
('KT', N'Kinh tế'),
('NN', N'Ngoại ngữ');

INSERT INTO LOP (MaLop, TenLop, MaKhoa) VALUES 
('CTK47A', N'Lớp CNTT K47A', 'CNTT'),
('CTK47B', N'Lớp CNTT K47B', 'CNTT'),
('KTK47A', N'Lớp Kinh tế K47A', 'KT');
```

---

## ✨ Tính năng chi tiết

### 1. Tải danh mục Khoa & Dữ liệu Lớp học
- **Đổ dữ liệu vào `cboKhoa`:** Truy vấn `SELECT MaKhoa, TenKhoa FROM KHOA`, gán `DisplayMember = "TenKhoa"` và `ValueMember = "MaKhoa"`.
- **Tải danh sách Lớp học lên `dgvLop`:** Thực hiện truy vấn kết hợp nhiều bảng kèm tổng hợp số lượng sinh viên:
  ```sql
  SELECT l.MaLop, l.TenLop, l.MaKhoa, k.TenKhoa,
         COUNT(sv.MaSV) AS SoSinhVien 
  FROM LOP l 
  LEFT JOIN KHOA k ON l.MaKhoa = k.MaKhoa
  LEFT JOIN SINHVIEN sv ON l.MaLop = sv.MaLop 
  GROUP BY l.MaLop, l.TenLop, l.MaKhoa, k.TenKhoa 
  ORDER BY l.MaLop
  ```

### 2. Thao tác Thêm mới (Create)
- Kiểm tra rỗng đối với Mã lớp, Tên lớp và Khoa.
- Kiểm tra tính duy nhất của Mã lớp trước khi thêm:
  ```csharp
  private bool IsMaLopExists(string maLop)
  {
      string sql = "SELECT COUNT(*) FROM LOP WHERE MaLop = @ma";
      // Thực thi ExecuteScalar trả về số lượng bản ghi
  }
  ```
- Sử dụng câu lệnh có tham số `cmd.Parameters.AddWithValue()` đảm bảo an toàn tuyệt đối trước tấn công SQL Injection.

### 3. Thao tác Cập nhật (Update)
- Cho phép chỉnh sửa Tên lớp hoặc chuyển đổi Khoa chủ quản dựa trên Mã lớp đã chọn.
- Thông báo kết quả cập nhật và tự động làm mới bảng dữ liệu.

### 4. Thao tác Xóa & Bảo vệ toàn vẹn dữ liệu (Delete)
- **Kiểm tra ràng buộc nghiệp vụ:** Truy vấn bảng `SINHVIEN` để kiểm tra lớp có chứa sinh viên hay không (`CountSinhVienByLop(ma)`).
- Nếu số sinh viên $> 0$, hiển thị cảnh báo: *"Không thể xóa lớp đang có sinh viên!"* và hủy thao tác.
- Nếu hợp lệ, yêu cầu người dùng xác nhận `Yes/No` trước khi tiến hành xóa vĩnh viễn khỏi CSDL.

### 5. Đồng bộ tương tác giao diện
- Nhấp chọn bất kỳ dòng nào trên `dgvLop`, thông tin Mã lớp, Tên lớp và Khoa sẽ tự động được gán ngược lại lên các ô nhập liệu tương ứng trên form.

---

## 🚀 Hướng dẫn cài đặt và chạy ứng dụng
1. Mở **SQL Server Management Studio (SSMS)** và chạy đoạn mã script tạo cơ sở dữ liệu `EduManagerDB` ở mục trên.
2. Kiểm tra chuỗi kết nối trong file `FrmLop.cs`:
   ```csharp
   private readonly string connectionString =
       @"Data Source=.\SQLEXPRESS;Initial Catalog=EduManagerDB;Integrated Security=True;TrustServerCertificate=True";
   ```
   *(Thay đổi `Data Source` cho phù hợp với cấu hình máy của bạn, ví dụ: `.` hoặc `localhost` hoặc `.\SQLEXPRESS`).*
3. Mở file `LAB11.slnx` hoặc `LAB11.csproj` trong **Visual Studio**.
4. Restore NuGet packages (nếu cần) và nhấn **F5** để khởi chạy ứng dụng.
