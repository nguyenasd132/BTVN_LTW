# LAB 13: BÁO CÁO THỐNG KÊ SINH VIÊN & XUẤT TỆP TIN (STUDENT REPORTING, LINQ & DATA EXPORT)

## 📌 Giới thiệu tổng quan
**LAB 13** (tên dự án: `StudentReportDemo`) là ứng dụng Windows Forms phát triển trên nền tảng **.NET Framework 4.8**, tập trung vào các kỹ thuật phân tích và tổng hợp dữ liệu nâng cao bằng **LINQ (Language Integrated Query)**, xây dựng báo cáo kết quả học tập của sinh viên với bộ lọc động đa tiêu chí và tính năng xuất dữ liệu báo cáo ra tệp tin chuẩn **CSV / TXT** hỗ trợ bảng mã tiếng Việt Unicode (UTF-8).

---

## 🎯 Mục tiêu bài thực hành
- Áp dụng các toán tử LINQ to Objects để truy vấn, lọc (`Where`), sắp xếp (`OrderByDescending`, `ThenBy`), biến đổi (`Select`) và gom nhóm (`GroupBy`) dữ liệu trong bộ nhớ.
- Xây dựng bộ lọc đa điều kiện thời gian thực (Real-time Filtering): lọc đồng thời theo Lớp học, Trạng thái đạt/không đạt và từ khóa tìm kiếm theo Họ tên hoặc Mã sinh viên.
- Tính toán các chỉ số thống kê tổng hợp: Tổng số lượng sinh viên, Số lượng đạt, Số lượng trượt, và Điểm trung bình ($ \text{ĐTB} $).
- Chuyển đổi linh hoạt giữa chế độ **Xem chi tiết từng sinh viên** và chế độ **Thống kê tổng hợp theo lớp học**.
- Sử dụng `SaveFileDialog`, `StringBuilder` và `System.IO.File` để xuất báo cáo ra định dạng CSV/TXT với mã hóa `UTF-8`.

---

## 🛠️ Công nghệ & Môi trường phát triển
- **Ngôn ngữ:** C# (.NET Framework 4.8)
- **Truy vấn dữ liệu:** LINQ to Objects (`System.Linq`)
- **Giao diện:** Windows Forms (Data Grid & Filtering Controls)
- **Xử lý tệp:** `System.IO` & `System.Text` (CSV/TXT UTF-8 Export)
- **IDE khuyến nghị:** Visual Studio 2019 / Visual Studio 2022

---

## 📁 Cấu trúc thư mục
```text
LAB13/
├── StudentReportDemo.slnx          # Solution file
└── LAB13/
    ├── StudentReportDemo.csproj    # File cấu hình dự án
    ├── App.config                  # Cấu hình runtime
    ├── Program.cs                  # Điểm khởi động ứng dụng
    ├── SinhVien.cs                 # Lớp Model sinh viên và thuộc tính tính toán KetQua
    ├── FrmBaoCaoSinhVien.cs        # Xử lý lọc LINQ, thống kê và xuất tệp
    ├── FrmBaoCaoSinhVien.Designer.cs
    └── Properties/
        ├── AssemblyInfo.cs
        ├── Resources.resx
        └── Settings.settings
```

---

## 📊 Mô hình dữ liệu (`SinhVien.cs`)
```csharp
namespace StudentReportDemo.Models
{
    public class SinhVien
    {
        public string MaSV { get; set; }
        public string HoTen { get; set; }
        public string MaLop { get; set; }
        public string TenLop { get; set; }
        public double Diem { get; set; }

        // Thuộc tính tính toán tự động dựa trên Điểm số
        public string KetQua => Diem >= 5.0 ? "Đạt" : "Không đạt";
    }
}
```

---

## ✨ Tính năng chi tiết

### 1. Bộ lọc báo cáo động đa tiêu chí
Phương thức `XemBaoCao()` kết hợp nhiều điều kiện lọc và tự động cập nhật lại khi người dùng thay đổi lựa chọn trên giao diện:
- **Lọc theo Lớp (`cboLop`):** Lọc theo mã lớp đã chọn.
- **Lọc theo Kết quả (`cboKetQua`):** Tùy chọn lọc:
  - *Tất cả*: Hiển thị đầy đủ sinh viên của lớp.
  - *Đạt*: Chỉ lấy sinh viên có điểm $\ge 5.0$.
  - *Không đạt*: Chỉ lấy sinh viên có điểm $< 5.0$.
- **Tìm kiếm theo từ khóa (`txtTuKhoa`):** Tìm kiếm tức thì theo Mã sinh viên hoặc Họ tên sinh viên (không phân biệt chữ hoa/thường).
- **Sắp xếp tự động:** Kết quả luôn được ưu tiên sắp xếp theo Điểm giảm dần, nếu cùng điểm thì sắp theo Họ tên sinh viên.

### 2. Bảng thống kê chỉ số học tập
- Thanh trạng thái `lblThongKe` tự động tính toán và hiển thị các chỉ số của lớp đang xem:
  ```text
  Đang hiển thị: 4 | Tổng lớp: 4 | Đạt: 3 | Không đạt: 1 | ĐTB: 7.15
  ```
- **Chế độ Thống kê theo từng Lớp (`btnThongKe`):** Sử dụng `GroupBy` để tổng hợp số liệu của tất cả các lớp trong trường:
  - Số lượng sinh viên từng lớp.
  - Số lượng sinh viên đạt và không đạt.
  - Điểm trung bình của từng lớp (làm tròn 2 chữ số thập phân).

### 3. Xuất báo cáo ra tệp tin CSV / TXT
Phương thức `btnXuatFile_Click` hỗ trợ xuất toàn bộ dữ liệu đang hiển thị trên `dgvBaoCao`:
- Mở hộp thoại `SaveFileDialog` với bộ lọc:
  - File CSV: `*.csv` (có thể mở trực tiếp bằng Microsoft Excel).
  - File Văn bản: `*.txt`.
- Định dạng dữ liệu dạng Comma-Separated Values (CSV), xử lý thay thế dấu phẩy trong văn bản để tránh sai lệch cột.
- Ghi tệp tin với chuẩn mã hóa `Encoding.UTF8` đảm bảo không bị lỗi font chữ tiếng Việt có dấu.

---

## 🚀 Hướng dẫn cài đặt và chạy ứng dụng
1. Mở file `StudentReportDemo.slnx` hoặc `StudentReportDemo.csproj` trong **Visual Studio**.
2. Nhấn **F5** để khởi chạy ứng dụng `Báo Cáo & Thống Kê Sinh Viên`.
3. Trải nghiệm các bộ lọc lớp, kết quả, ô tìm kiếm và kiểm tra kết quả xuất file CSV/TXT.
