# LAB 06: QUẢN LÝ SẢN PHẨM (PRODUCT MANAGEMENT SYSTEM)

## 📌 Giới thiệu tổng quan
**LAB 06** là ứng dụng Windows Forms phát triển trên nền tảng **.NET Framework 4.7.2**, áp dụng mô hình liên kết dữ liệu hai chiều (Two-Way Data Binding), quản lý danh sách thực thể sản phẩm trong bộ nhớ, kiểm tra lỗi giao diện thời gian thực qua `ErrorProvider`, xử lý tải và hiển thị hình ảnh đa phương tiện, tích hợp hệ thống thanh công cụ (`ToolStrip`), thanh trạng thái (`StatusStrip`) và menu ngữ cảnh (`ContextMenuStrip`).

---

## 🎯 Mục tiêu bài thực hành
- Thiết kế lớp đối tượng thực thể Model (`Product`) với đầy đủ các thuộc tính nghiệp vụ.
- Sử dụng `BindingList<T>` và `BindingSource` để đồng bộ dữ liệu tự động giữa bộ nhớ và bảng `DataGridView`.
- Thực hiện đầy đủ các chức năng **CRUD**: Thêm (Create), Đọc/Xem (Read), Sửa (Update), Xóa (Delete), Làm mới (Reset).
- Bắt lỗi dữ liệu nhập với `ErrorProvider` trước khi thực thi thêm hoặc cập nhật.
- Xử lý nạp hình ảnh sản phẩm bằng `OpenFileDialog` và đọc file qua `FileStream` để giải phóng tài nguyên, tránh hiện tượng khóa tệp tin (File Lock) trên hệ điều hành.
- Xây dựng chức năng tìm kiếm sản phẩm theo Mã hoặc Tên bằng LINQ.
- Tích hợp các thành phần giao diện nâng cao: `ToolStrip`, `MenuStrip`, `ContextMenuStrip`, `StatusStrip`.

---

## 🛠️ Công nghệ & Môi trường phát triển
- **Ngôn ngữ:** C# (.NET Framework 4.7.2)
- **Giao diện:** Windows Forms (WinForms)
- **Kiến trúc dữ liệu:** Data Binding (`BindingList<Product>`, `BindingSource`)
- **IDE khuyến nghị:** Visual Studio 2019 / Visual Studio 2022

---

## 📁 Cấu trúc thư mục
```text
LAB06/
├── LAB06.slnx                 # Solution file
└── LAB06/
    ├── LAB06.csproj           # File cấu hình dự án (.NET Framework 4.7.2)
    ├── App.config             # Cấu hình runtime ứng dụng
    ├── Program.cs             # Khởi tạo Application Run
    ├── Product.cs             # Lớp Model lưu trữ thông tin sản phẩm
    ├── Form1.cs               # Xử lý sự kiện, CRUD, validation và tìm kiếm
    ├── Form1.Designer.cs      # Khai báo và cấu hình controls trên giao diện
    ├── Form1.resx             # Tài nguyên form
    └── Properties/
        ├── AssemblyInfo.cs
        ├── Resources.resx
        └── Settings.settings
```

---

## 📊 Mô hình dữ liệu (`Product.cs`)
Lớp `Product` biểu diễn đối tượng sản phẩm với các thuộc tính:
- `MaSP` (`string`): Mã sản phẩm (định danh duy nhất).
- `TenSP` (`string`): Tên sản phẩm.
- `LoaiSP` (`string`): Danh mục sản phẩm (Điện tử, Văn phòng, Gia dụng, Thời trang).
- `DonGia` (`decimal`): Đơn giá sản phẩm.
- `SoLuong` (`int`): Số lượng tồn kho.
- `NgayNhap` (`DateTime`): Ngày nhập hàng về kho.
- `ConKinhDoanh` (`bool`): Trạng thái còn kinh doanh hay ngừng kinh doanh.
- `DuongDanAnh` (`string`): Đường dẫn tuyệt đối tới tệp tin hình ảnh sản phẩm.

---

## ✨ Tính năng chi tiết

### 1. Quản lý Thêm, Sửa, Xóa (CRUD)
- **Thêm sản phẩm (`tsbThem`):**
  - Kiểm tra tính hợp lệ dữ liệu.
  - Ngăn chặn nhập trùng `MaSP` đối với thao tác tạo mới.
  - Thêm đối tượng vào `BindingList<Product>`, bảng hiển thị tự động cập nhật ngay lập tức.
- **Sửa sản phẩm (`tsbSua`):**
  - Khóa ô nhập `MaSP` để đảm bảo tính toàn vẹn định danh.
  - Cập nhật các thông tin: Tên, Loại, Đơn giá, Số lượng, Ngày nhập, Tình trạng và Ảnh.
  - Gọi `_bindingSource.ResetBindings(false)` để làm mới dữ liệu trên bảng.
- **Xóa sản phẩm (`tsbXoa`):**
  - Hiển thị hộp thoại xác nhận cảnh báo `Yes/No` trước khi xóa.
  - Xóa phần tử khỏi danh sách và cập nhật lại giao diện.
- **Làm mới (`tsbLamMoi`):**
  - Xóa trắng form nhập liệu, giải phóng hình ảnh cũ trong bộ nhớ, mở lại ô `MaSP` và phục hồi hiển thị toàn bộ danh sách.

### 2. Kiểm soát hợp lệ dữ liệu (`ErrorProvider`)
Hệ thống xác thực dữ liệu qua hàm `ValidateInput()`:
- `MaSP`: Không được để trống; không được trùng khi thêm mới.
- `TenSP`: Không được để trống.
- `LoaiSP`: Bắt buộc phải chọn một danh mục trong ComboBox.
- `DonGia`: Phải lớn hơn 0.
- `SoLuong`: Không được mang giá trị âm ($ \ge 0 $).
- `NgayNhap`: Không được lớn hơn ngày hiện tại (`DateTime.Today`).

### 3. Quản lý hình ảnh an toàn
- Sử dụng `OpenFileDialog` với bộ lọc file: `*.jpg; *.jpeg; *.png; *.bmp`.
- Nạp ảnh qua `FileStream` và giải phóng luồng ngay sau khi đọc:
  ```csharp
  using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
  {
      picHinhAnh.Image = Image.FromStream(fs);
  }
  ```
  *Kỹ thuật này giúp tránh lỗi tệp tin bị ứng dụng chiếm dụng/khóa khi người dùng chỉnh sửa hoặc xóa ảnh gốc từ bên ngoài.*

### 4. Tìm kiếm & Menu tiện ích
- **Tìm kiếm:** Nhập từ khóa tại ô tìm kiếm trên thanh `ToolStrip`, hệ thống lọc theo `MaSP` hoặc `TenSP` (không phân biệt chữ hoa/thường).
- **Xem chi tiết:** Nhấp chuột phải vào dòng sản phẩm trên `DataGridView` để mở `ContextMenuStrip` -> "Xem chi tiết", hiển thị đầy đủ thông số của sản phẩm trong hộp thoại thông báo.
- **Thanh trạng thái (`StatusStrip`):** Hiển thị trạng thái thao tác gần nhất (ví dụ: *"Thêm thành công sản phẩm [SP01]"*) và cập nhật tức thời tổng số sản phẩm trong danh sách.

---

## 🚀 Hướng dẫn cài đặt và chạy ứng dụng
1. Mở file `LAB06.slnx` hoặc `LAB06.csproj` bằng **Visual Studio**.
2. Chọn cấu hình **Debug | Any CPU**.
3. Nhấn **F5** để khởi chạy ứng dụng.
