# LAB 07: HỆ THỐNG QUẢN LÝ ĐA CỬA SỔ (MDI, PHÂN QUYỀN & INTERFACE-DRIVEN ARCHITECTURE)

## 📌 Giới thiệu tổng quan
**LAB 07** là dự án xây dựng hệ thống quản lý ứng dụng đa tài liệu (**MDI - Multiple Document Interface**) trên nền tảng **.NET Framework 4.7.2**. Dự án minh họa kiến trúc ứng dụng doanh nghiệp thu nhỏ với cơ chế **Đăng nhập phân quyền (RBAC)**, kiến trúc điều khiển tập trung thông qua **Interface (`IQuanLy`)**, và quản lý luân chuyển các Form con (`FrmCustomer`, `FrmProduct`) bên trong Form cha (`FrmMain`).

---

## 🎯 Mục tiêu bài thực hành
- Thiết kế ứng dụng Windows Forms theo mô hình **MDI Parent - MDI Child**.
- Hiện thực cơ chế đăng nhập và phân quyền người dùng: Quản trị viên (**Admin**) và Người dùng thông thường (**User**).
- Áp dụng nguyên lý lập trình hướng đối tượng (OOP) với **Interface**: chuẩn hóa các hành vi quản lý dữ liệu (`Them`, `Sua`, `Xoa`, `TimKiem`, `LamMoi`) dùng chung cho nhiều module khác nhau.
- Xây dựng thanh công cụ tập trung trên Form cha để điều khiển Form con đang hoạt động (`ActiveMdiChild`).
- Quản lý vòng đời cửa sổ con: đảm bảo chỉ mở một form tại một thời điểm, loại bỏ viền (`FormBorderStyle.None`) và tự động co dãn vừa vặn (`Dock.Fill`).

---

## 🛠️ Công nghệ & Môi trường phát triển
- **Ngôn ngữ:** C# (.NET Framework 4.7.2)
- **Giao diện:** Windows Forms (MDI Container)
- **Mô hình lập trình:** Interface-Driven Architecture & Role-Based Access Control
- **IDE khuyến nghị:** Visual Studio 2019 / Visual Studio 2022

---

## 📁 Cấu trúc thư mục
```text
LAB07/
├── LAB07.slnx                 # Solution file
└── LAB07/
    ├── LAB07.csproj           # Cấu hình dự án
    ├── App.config             # Cấu hình ứng dụng
    ├── Program.cs             # Điểm khởi chạy ứng dụng (Mở FrmLogin đầu tiên)
    ├── IQuanLy.cs             # Interface định nghĩa các phương thức quản lý dữ liệu
    ├── Customer.cs            # Lớp Model Khách hàng
    ├── Product.cs             # Lớp Model Sản phẩm
    ├── FrmLogin.cs            # Form Đăng nhập & Xác thực quyền
    ├── FrmMain.cs             # Form MDI cha (Container) chứa Menu & Toolbar điều khiển
    ├── FrmCustomer.cs         # Form con quản lý Khách hàng (kế thừa IQuanLy)
    ├── FrmProduct.cs          # Form con quản lý Sản phẩm (kế thừa IQuanLy)
    └── Properties/
        ├── AssemblyInfo.cs
        ├── Resources.resx
        └── Settings.settings
```

---

## 🔑 Tài khoản đăng nhập hệ thống
Chương trình thiết lập sẵn 2 tài khoản mẫu tại `FrmLogin.cs`:

| Tên đăng nhập | Mật khẩu | Quyền hạn | Mô tả quyền |
|---|---|---|---|
| `admin` | `123` | **Administrator** | Toàn quyền sử dụng hệ thống (Thêm, Sửa, Xóa, Tìm kiếm, Làm mới). |
| `user` | `123` | **Standard User** | Chỉ được xem dữ liệu, tìm kiếm và làm mới; các nút **Thêm**, **Sửa**, **Xóa** trên thanh công cụ bị vô hiệu hóa (`Enabled = false`). |

---

## 🏛️ Kiến trúc & Điểm nhấn kỹ thuật

### 1. Chuẩn hóa giao tiếp qua Interface `IQuanLy`
Giao diện `IQuanLy.cs` quy định hợp đồng chung cho tất cả các Form quản lý nghiệp vụ:
```csharp
public interface IQuanLy
{
    void Them();
    void Sua();
    void Xoa();
    void TimKiem();
    void LamMoi();
}
```
Nhờ vậy, Form cha `FrmMain` không cần phụ thuộc trực tiếp vào từng kiểu form con cụ thể mà chỉ cần kích hoạt phương thức qua con trỏ `ActiveMdiChild`:
```csharp
private void btnThem_Click(object sender, EventArgs e)
{
    if (this.ActiveMdiChild is IQuanLy frm) 
        frm.Them();
}
```

### 2. Quản lý cửa sổ con MDI (`MoFormCon`)
- Kiểm tra danh sách `this.MdiChildren`: Nếu form cùng loại đã tồn tại thì kích hoạt (`Activate()`), các form khác sẽ tự động đóng lại.
- Tự động gắn thuộc tính hiển thị toàn màn hình không viền (`FormBorderStyle = FormBorderStyle.None`, `Dock = DockStyle.Fill`), mang lại trải nghiệm tương tự ứng dụng Single-Page Application (SPA) trên desktop.

### 3. Phân hệ chức năng
- **Quản lý Khách hàng (`FrmCustomer`):**
  - Quản lý danh sách khách hàng gồm: Mã KH, Họ tên, SĐT, Loại khách hàng (VIP, Thành viên, Khách thường).
  - Tự động định dạng và căng chỉnh độ rộng các cột trên `DataGridView`.
- **Quản lý Sản phẩm (`FrmProduct`):**
  - Quản lý thông tin: Mã SP, Tên SP, Loại SP, Đơn giá, Số lượng.
  - Tích hợp bộ sinh dữ liệu mẫu ngẫu nhiên (20 sản phẩm đa dạng danh mục) khi khởi động.
  - Định dạng cột tiền tệ chuẩn (`N0`).

---

## 🚀 Hướng dẫn cài đặt và chạy ứng dụng
1. Mở file `LAB07.slnx` hoặc `LAB07.csproj` trong **Visual Studio**.
2. Nhấn **F5** để khởi chạy form đăng nhập `FrmLogin`.
3. Đăng nhập với tài khoản `admin` / `123` hoặc `user` / `123` để trải nghiệm sự khác biệt về quyền hạn thao tác.
