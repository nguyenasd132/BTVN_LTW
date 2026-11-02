# LAB 03: C# VÀ LẬP TRÌNH HƯỚNG ĐỐI TƯỢNG (OOP) - QUẢN LÝ SINH VIÊN BẰNG CONSOLE

## 📌 Giới thiệu tổng quan
**LAB 03** là chương trình Console phát triển trên nền tảng **C# / .NET 10.0**, tập trung vào việc áp dụng các nguyên lý cốt lõi của **Lập trình hướng đối tượng (OOP)**: Đóng gói (Encapsulation), Kế thừa (Inheritance), Đa hình (Polymorphism - Method Overriding), kết hợp với cấu trúc dữ liệu `List<T>`, ngôn ngữ truy vấn tích hợp **LINQ**, và kỹ thuật xử lý nhập liệu an toàn trên giao diện dòng lệnh.

---

## 🎯 Mục tiêu bài thực hành
- Thiết kế mô hình kế thừa: Lớp con `SinhVien` kế thừa từ lớp cha `Nguoi`.
- Đóng gói (Encapsulation) dữ liệu và kiểm tra hợp lệ thông qua Properties (ví dụ: `DiemTrungBinh` bắt buộc trong khoảng từ $0.0$ đến $10.0$).
- Sử dụng phương thức ảo `virtual` và ghi đè `override` (`LayThongTin()`, `ToString()`).
- Tách biệt rõ ràng tầng nghiệp vụ (`QuanLySinhVien`) và tầng giao diện điều khiển (`Program`), không xử lý trực tiếp danh sách trong `Main`.
- Ứng dụng các toán tử LINQ to Objects (`Where`, `OrderByDescending`, `FirstOrDefault`, `Any`) để tìm kiếm, sắp xếp và lọc dữ liệu.
- Xử lý ngoại lệ và kiểm soát lỗi nhập liệu (Validation) giúp chương trình không bị dừng đột ngột (crash) khi người dùng nhập sai định dạng.

---

## 🛠️ Công nghệ & Môi trường phát triển
- **Ngôn ngữ:** C# (.NET 10.0 Console Application)
- **Kỹ thuật lập trình:** OOP, LINQ to Objects, Generic Collections (`List<T>`)
- **IDE khuyến nghị:** Visual Studio 2022 / Visual Studio Code / .NET CLI

---

## 📁 Cấu trúc thư mục
```text
LAB03/
├── LAB03.slnx                 # Solution file (Visual Studio 2022)
└── LAB03/
    ├── LAB03.csproj           # Cấu hình dự án Console (.NET 10)
    ├── Nguoi.cs               # Lớp cha chứa thông tin cơ bản: HoTen, NgaySinh
    ├── SinhVien.cs            # Lớp con kế thừa Nguoi, bổ sung MaSV, MaLop, ĐTB, Xếp loại
    ├── QuanLySinhVien.cs      # Lớp Service quản lý List<SinhVien> và nghiệp vụ
    └── Program.cs             # Điểm khởi chạy, menu điều khiển và validation nhập liệu
```

---

## 🏛️ Thiết kế Hướng đối tượng (Class Design)

### 1. Lớp cha `Nguoi.cs`
- **Thuộc tính:** `HoTen` (`string`), `NgaySinh` (`DateTime`).
- **Constructors:** Constructor mặc định và Constructor đầy đủ tham số.
- **Phương thức ảo:** `public virtual string LayThongTin()` trả về chuỗi thông tin cơ bản.

### 2. Lớp con `SinhVien.cs` (Kế thừa từ `Nguoi`)
- **Thuộc tính mở rộng:** `MaSinhVien` (`string`), `MaLop` (`string`).
- **Validation Property:**
  ```csharp
  public double DiemTrungBinh
  {
      get => _diemTrungBinh;
      set
      {
          if (value < 0.0 || value > 10.0)
              throw new ArgumentOutOfRangeException(nameof(value), "Điểm trung bình phải nằm trong khoảng từ 0.0 đến 10.0!");
          _diemTrungBinh = value;
      }
  }
  ```
- **Phương thức `XepLoai()`:**
  - $\ge 9.0$: **Xuất sắc**
  - $\ge 8.0$: **Giỏi**
  - $\ge 6.5$: **Khá**
  - $\ge 5.0$: **Trung bình**
  - $< 5.0$: **Yếu**
- **Ghi đè:** `override string LayThongTin()` và `override string ToString()`.

### 3. Lớp Dịch vụ `QuanLySinhVien.cs`
Đóng gói danh sách nội bộ `private readonly List<SinhVien> _danhSach`:
- `Them(SinhVien sv)`: Kiểm tra không cho trùng `MaSinhVien`.
- `LayDanhSach()`: Trả về danh sách sinh viên hiện có.
- `TimTheoMa(string maSV)`: Tìm chính xác theo mã sinh viên (`FirstOrDefault`).
- `TimTheoTen(string tuKhoa)`: Tìm kiếm theo họ tên có chứa từ khóa bằng LINQ (`Where`).
- `SuaDiem(string maSV, double diemMoi)`: Cập nhật điểm và kích hoạt lại logic xếp loại.
- `Xoa(string maSV)`: Xóa sinh viên khỏi hệ thống.
- `SapXepTheoDiemGiamDan()`: Sắp xếp giảm dần theo điểm trung bình bằng LINQ (`OrderByDescending`).
- `LocSinhVienDat()`: Lọc sinh viên đạt chuẩn có điểm $\ge 5.0$ bằng LINQ (`Where`).
- `NapDuLieuMau()`: Nạp sẵn 6 sinh viên mẫu thuộc nhiều lớp để tiện kiểm thử.

---

## ✨ Mẫu Menu & Các chức năng thực thi
```text
========================================
        ===== QUAN LY SINH VIEN =====
========================================
1. Them sinh vien
2. Xuat danh sach
3. Tim sinh vien theo ma
4. Tim sinh vien theo ten
5. Sua diem trung binh
6. Xoa sinh vien
7. Sap xep theo diem giam dan
8. Loc sinh vien dat
0. Thoat
----------------------------------------
Chon chuc nang: 
```

### Bảng dữ liệu mẫu kiểm thử
| STT | Tình huống kiểm thử | Dữ liệu đầu vào | Kết quả kỳ vọng |
|---|---|---|---|
| 1 | Thêm sinh viên hợp lệ | `SV007`, `Vũ Minh Đức`, `20/05/2005`, `CNTT01`, `8.2` | Thêm thành công, xếp loại **Giỏi**. |
| 2 | Thêm trùng mã sinh viên | `SV001` | Thông báo lỗi mã sinh viên đã tồn tại, yêu cầu nhập lại. |
| 3 | Nhập điểm sai khoảng | `-1` hoặc `11.5` | Bắt lỗi validation, yêu cầu nhập lại từ 0 đến 10. |
| 4 | Tìm theo tên | Từ khóa `"An"` | Trả về sinh viên chứa từ khóa (Nguyễn Văn An, Hoàng Gia Hân). |
| 5 | Xóa mã không tồn tại | `SV999` | Thông báo không tìm thấy sinh viên để xóa. |
| 6 | Lọc sinh viên đạt | Chức năng 8 | Chỉ in các sinh viên có điểm $\ge 5.0$. |

---

## 🚀 Hướng dẫn biên dịch và chạy chương trình
1. Mở terminal tại thư mục `D:\NamBa\LTW\LAB03\LAB03`:
   ```powershell
   dotnet build
   dotnet run
   ```
2. Hoặc mở file solution `LAB03.slnx` bằng **Visual Studio 2022** và nhấn **F5**.
