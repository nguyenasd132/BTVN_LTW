## 1. Giới thiệu đề tài
Ứng dụng Console C# quản lý thông tin và tính lương nhân viên theo mô hình hướng đối tượng (OOP). Chương trình minh họa 4 tính chất cốt lõi của OOP: **Đóng gói (Encapsulation)**, **Kế thừa (Inheritance)**, **Đa hình (Polymorphism)** và **Trừu tượng hóa (Abstraction)**.

---

## 2. Kiến trúc các lớp (Class Hierarchy)

### 2.1 Lớp cha: `NhanVien`
- **Thuộc tính:** `MaNV`, `HoTen`, `LuongCoBan` (> 0).
- **Phương thức:**
  - `virtual double TinhLuong()`: Tính và trả về lương cơ bản.
  - `virtual void HienThiThongTin()`: Xuất thông tin nhân viên ra màn hình.

### 2.2 Các lớp kế thừa
- **`NhanVienVanPhong`**:
  - Bổ sung: `SoNgayLamViec` (0 đến 31 ngày).
  - Công thức lương: $\text{Lương} = \text{Lương cơ bản} + \text{Số ngày làm việc} \times 200.000$.
  - Override `TinhLuong()` và `HienThiThongTin()`.
- **`NhanVienKinhDoanh`**:
  - Bổ sung: `DoanhSo` ($\ge 0$).
  - Công thức lương: $\text{Lương} = \text{Lương cơ bản} + 5\% \times \text{Doanh số}$.
  - Override `TinhLuong()` và `HienThiThongTin()`.
- **`NhanVienThoiVu` (Bonus)**:
  - Bổ sung: `SoGioLam`, `LuongTheoGio`.
  - Công thức lương: $\text{Lương} = \text{Số giờ làm} \times \text{Lương theo giờ}$.
  - Override `TinhLuong()` và `HienThiThongTin()`.

---

## 3. Tính Đa hình (Polymorphism) trong chương trình
- Chương trình lưu trữ danh sách đối tượng bằng kiểu dữ liệu lớp cha: `List<NhanVien>`.
- **Không sử dụng kiểm tra kiểu (`if`/`switch` hay `is`/`as`):** Các chức năng xuất danh sách, tìm nhân viên lương cao nhất và tính tổng lương hoàn toàn gọi trực tiếp phương thức `nv.HienThiThongTin()` và `nv.TinhLuong()`.
- **Khả năng mở rộng (Extensibility):** Khi bổ sung thêm lớp `NhanVienThoiVu`, logic của các thuật toán tính tổng lương và tìm lương cao nhất không cần thay đổi hay viết lại bất kỳ dòng code nào.

---

## 4. Chức năng Menu
- **1. Xuất danh sách nhân viên:** In đầy đủ danh sách gồm nhân viên văn phòng, nhân viên kinh doanh và nhân viên thời vụ.
- **2. Tìm nhân viên theo mã:** Tìm kiếm chính xác mã nhân viên (không phân biệt hoa/thường).
- **3. Tìm nhân viên có lương cao nhất:** Duyệt tìm giá trị lương lớn nhất thông qua phương thức đa hình.
- **4. Tính tổng lương công ty phải trả:** Cộng dồn chi phí lương toàn bộ nhân sự.
- **0. Thoát:** Đóng ứng dụng.

---

## 5. Hinh anh



