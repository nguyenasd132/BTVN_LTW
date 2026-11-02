# LAB 09: QUẢN LÝ VÀ IN THẺ SINH VIÊN (STUDENT CARD DESIGN & PRINTING SYSTEM)

## 📌 Giới thiệu tổng quan
**LAB 09** (tên dự án: `StudentCardPrinter`) là ứng dụng Windows Forms phát triển trên nền tảng **.NET Framework 4.8**, kết hợp giữa kỹ thuật xây dựng giao diện động hoàn toàn bằng mã nguồn (Dynamic UI Layout), thiết kế đồ họa thẻ sinh viên chuẩn hóa bằng **GDI+** và tích hợp hệ thống in ấn chuyên nghiệp thông qua không gian tên `System.Drawing.Printing`.

---

## 🎯 Mục tiêu bài thực hành
- Lập trình giao diện động (Dynamic Controls Creation) mà không phụ thuộc vào kéo thả Designer: tự tạo và căn lề tọa độ các `GroupBox`, `TextBox`, `ComboBox`, `DateTimePicker`, `PictureBox`, `Button`, `Panel`.
- Áp dụng kỹ thuật đồ họa vector GDI+ (`System.Drawing`, `Graphics`) để thiết kế bố cục thẻ sinh viên đẹp mắt: khung viền bo góc, dải màu tiêu đề, logo/ảnh chân dung, thông tin chi tiết và căn lề chữ chuẩn xác.
- Tạo cơ chế xem trước thời gian thực (**Real-time Preview**): bất kỳ thay đổi nào trong dữ liệu nhập liệu đều lập tức kích hoạt vẽ lại thẻ sinh viên trên khung xem trước (`pnlCardPreview.Invalidate()`).
- Tích hợp pipeline in ấn chuẩn trong .NET: sử dụng bộ ba thành phần `PrintDocument`, `PrintPreviewDialog` và `PrintDialog` để xem trước bản in và gửi lệnh in ra máy in vật lý hoặc máy in ảo (Microsoft Print to PDF).

---

## 🛠️ Công nghệ & Môi trường phát triển
- **Ngôn ngữ:** C# (.NET Framework 4.8)
- **Đồ họa:** GDI+ (`System.Drawing`, `System.Drawing.Drawing2D`)
- **In ấn:** `System.Drawing.Printing` (`PrintDocument`, `PrintPreviewDialog`, `PrintDialog`)
- **Giao diện:** Dynamic Windows Forms Layout
- **IDE khuyến nghị:** Visual Studio 2019 / Visual Studio 2022

---

## 📁 Cấu trúc thư mục
```text
LAB09/
├── LAB09.slnx                     # Solution file
└── LAB09/
    ├── StudentCardPrinter.csproj  # File cấu hình dự án (.NET Framework 4.8)
    ├── App.config                 # Cấu hình ứng dụng
    ├── Program.cs                 # Điểm khởi động ứng dụng
    ├── StudentCardInfo.cs         # Lớp Model lưu trữ thông tin sinh viên in trên thẻ
    ├── FrmStudentCard.cs          # Mã nguồn khởi tạo giao diện động, vẽ thẻ và in ấn
    ├── FrmStudentCard.Designer.cs # File Designer phụ trợ
    └── Properties/
        ├── AssemblyInfo.cs
        ├── Resources.resx
        └── Settings.settings
```

---

## 📋 Mô hình dữ liệu (`StudentCardInfo.cs`)
Lớp `StudentCardInfo` đại diện cho dữ liệu sinh viên được đưa lên thẻ:
```csharp
public class StudentCardInfo 
{ 
    public string StudentId { get; set; } = string.Empty; 
    public string FullName { get; set; } = string.Empty; 
    public string ClassName { get; set; } = string.Empty; 
    public string Faculty { get; set; } = string.Empty; 
    public string Course { get; set; } = string.Empty; 
    public DateTime BirthDate { get; set; } 
    public string Gender { get; set; } = string.Empty; 
    public System.Drawing.Image? Photo { get; set; }
}
```

---

## ✨ Tính năng chi tiết

### 1. Khởi tạo giao diện bằng Code (`InitDynamicControls`)
- Giao diện được chia thành hai phần đối xứng trực quan:
  - **Khung nhập liệu bên trái (`grpInput`):** Mã sinh viên, Họ và tên, Lớp học, Khoa, Khóa học, Giới tính, Ngày sinh, Nút chọn ảnh chân dung, Nút xem trước bản in, Nút in thẻ và Nút làm mới.
  - **Khung hiển thị thẻ bên phải (`pnlCardPreview`):** Panel chuyên dụng được gán sự kiện vẽ `Paint` để hiển thị bản thiết kế đồ họa của thẻ sinh viên.

### 2. Thiết kế thẻ sinh viên bằng GDI+ (`DrawStudentCard`)
Hàm vẽ đồ họa dùng chung cho cả màn hình xem trước và trang in vật lý:
- Sử dụng `SmoothingMode.AntiAlias` để khử răng cưa toàn diện.
- Khung thẻ hình chữ nhật với màu nền dịu mắt (`Color.FromArgb(238, 247, 247)`) và viền xanh navy sang trọng.
- Tiêu đề thẻ: Hiển thị tên trường/cơ quan đào tạo và dòng chữ tiêu đề nổi bật: **"THẺ SINH VIÊN"** kèm phụ đề tiếng Anh **"STUDENT CARD"**.
- Khung ảnh chân dung: Cắt và vẽ ảnh chân dung tỷ lệ $ 3 \times 4 $ có đường viền bo quanh.
- Khối thông tin chi tiết: Trình bày dạng bảng key-value gọn gàng gồm Mã số sinh viên, Họ tên (in đậm), Lớp, Khoa, Khóa và Ngày sinh.

### 3. Xem trước và In ấn chuyên nghiệp
- **Xem trước bản in (`btnPreviewPrint`):**
  - Mở cửa sổ `PrintPreviewDialog` với đầy đủ các công cụ thu phóng (Zoom), chuyển trang và xem trước bố cục thực tế trên khổ giấy A4/Letter trước khi in.
- **In trực tiếp (`btnPrint`):**
  - Mở `PrintDialog` cho phép lựa chọn máy in trong hệ thống, cấu hình số lượng bản in (Copies), chọn khoảng trang cần in.
  - Kết nối trực tiếp sự kiện `printDocument1_PrintPage` để truyền dữ liệu đồ họa ra máy in.
- **Làm mới dữ liệu (`btnClear`):**
  - Xóa trắng form nhập liệu, giải phóng ảnh trong bộ nhớ và cập nhật lại khung xem trước.

---

## 🚀 Hướng dẫn cài đặt và chạy ứng dụng
1. Mở file `LAB09.slnx` hoặc `StudentCardPrinter.csproj` trong **Visual Studio**.
2. Nhấn **F5** để khởi chạy ứng dụng.
3. Điền thông tin sinh viên, chọn ảnh đại diện từ máy tính để thấy thẻ sinh viên được cập nhật trực quan trên khung Preview.
4. Bấm **"Xem trước bản in"** hoặc **"In thẻ..."** để xuất bản in.
