# Phần Mềm Đăng Ký Khóa Học (Windows Forms)

Ứng dụng desktop xây dựng trên nền tảng **C# Windows Forms** phục vụ việc quản lý và đăng ký thông tin khóa học dành cho học viên, hỗ trợ tự động tính toán học phí theo thời gian thực và xác thực dữ liệu đầu vào.
![Giao diện](./Lab05/GiaoDien.png)
---

## 📸 Giao diện ứng dụng

Ứng dụng chia làm 3 khu vực chính:
1. **Thông tin học viên**: Nhập họ tên, số điện thoại, ngày sinh và tùy chọn nhận thông tin qua email.
2. **Thông tin khóa học**: Chọn môn học, hình thức học, số tháng đăng ký và xem tổng tiền.
3. **Cụm chức năng**: Nút thao tác Đăng ký, Xóa dữ liệu và Thoát.

---

## ✨ Tính năng nổi bật

### 1. Khởi tạo mặc định (`Form_Load`)
* Tự động nạp danh sách các khóa học vào `ComboBox`.
* Chọn mặc định khóa học đầu tiên trong danh sách.
* Chọn mặc định hình thức học là **Online**.
* Giới hạn số tháng đăng ký từ **1 đến 12 tháng** (mặc định ban đầu là 1 tháng).
* Tính và hiển thị tổng học phí ban đầu lên giao diện.

### 2. Nhãn hiển thị học phí động (Dynamic Label)
* Tự động cập nhật tổng tiền ngay khi:
  * Người dùng đổi khóa học khác.
  * Tăng hoặc giảm số tháng đăng ký.
* Công thức tính: `Tổng học phí = Học phí 1 tháng x Số tháng`.

### 3. Đếm & Giới hạn ký tự Họ tên
* Giới hạn tối đa **50 ký tự**.
* Nhãn đếm ký tự động hiển thị tỷ lệ thực tế dạng `X/50` khi người dùng đang nhập.
* Chặn hoàn toàn ký tự số trong ô Họ tên.

### 4. Kiểm tra dữ liệu đầu vào (Validation) khi Đăng ký
* Họ tên không được để trống và không chứa chữ số.
* Số điện thoại không được để trống, chỉ nhận ký tự số và bắt buộc có **đúng 10 chữ số**.
* Khóa học phải được lựa chọn hợp lệ.
* Khi đăng ký thành công, hệ thống xuất thông báo tóm tắt phiếu đăng ký chi tiết bằng `MessageBox`.

### 5. Thao tác tiện ích
* **Xóa dữ liệu**: Khôi phục toàn bộ các trường nhập liệu và nhãn tiền về trạng thái ban đầu.
* **Thoát**: Hiển thị hộp thoại xác nhận trước khi đóng ứng dụng.

---

## 🛠 Công nghệ sử dụng

* **Ngôn ngữ**: C# (.NET Framework)
* **Giao diện**: Windows Forms (WinForms)
* **IDE đề xuất**: Visual Studio 2019 / 2022 trở lên

---

## 🚀 Hướng dẫn cài đặt & Chạy ứng dụng

1. **Clone hoặc tải mã nguồn**:
   ```bash
   git clone <URL_REPO_CUA_BAN>
