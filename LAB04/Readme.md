# LAB 04: EXCEPTION, DELEGATE/EVENT, FUNC/ACTION VÀ GENERIC TRONG C# (PRODUCT MANAGER)

## 📌 Giới thiệu tổng quan
**LAB 04** là chương trình Console phát triển trên nền tảng **C# / .NET 10.0**, tập trung vào các kỹ thuật nâng cao trong C#:
- Định nghĩa và bắt các lớp ngoại lệ tự tạo (**Custom Exceptions**).
- Mô hình kiến trúc kho lưu trữ dùng chung (**Generic Repository Pattern**) với ràng buộc `where T : class, IEntity`.
- Cơ chế phát và đăng ký lắng nghe sự kiện (**Delegate / Event / Action Event**) để thông báo khi trạng thái dữ liệu thay đổi.
- Sử dụng ủy quyền hàm tổng quát **`Func<Product, bool>`** để lọc và tìm kiếm dữ liệu linh hoạt.

---

## 🎯 Mục tiêu bài thực hành
- Xây dựng interface `IEntity` làm ràng buộc generic type (`where T : class, IEntity`).
- Thiết kế lớp `Product` kế thừa `IEntity`, kiểm soát ràng buộc đơn giá và số lượng không âm.
- Tự định nghĩa ít nhất 2 lớp Exception: `DuplicateProductException` (khi trùng mã) và `ProductNotFoundException` (khi không tìm thấy).
- Xây dựng lớp kho lưu trữ dùng chung `Repository<T>` hỗ trợ các thao tác CRUD cơ bản và tìm kiếm theo delegate `Func<T, bool>`.
- Xây dựng tầng dịch vụ `ProductService` tích hợp các sự kiện `Action<Product>` và `Action<string>` phát tín hiệu khi thêm/xóa thành công.
- Tách biệt rõ ràng luồng xử lý: `Program` đóng vai trò giao diện Console, tiếp nhận input, bắt và hiển thị thông báo lỗi thân thiện.

---

## 🛠️ Công nghệ & Môi trường phát triển
- **Ngôn ngữ:** C# (.NET 10.0 Console Application)
- **Kỹ thuật trọng tâm:** Generic Repository, Custom Exceptions, Delegate/Event, `Func<T, bool>`, `Action<T>`
- **IDE khuyến nghị:** Visual Studio 2022 / Visual Studio Code / .NET CLI

---

## 📁 Cấu trúc thư mục
```text
LAB04/
├── LAB04.slnx                 # Solution file (Visual Studio 2022)
└── LAB04/
    ├── LAB04.csproj           # Cấu hình dự án Console (.NET 10)
    ├── IEntity.cs             # Interface định nghĩa thuộc tính Id { get; }
    ├── Product.cs             # Lớp Model sản phẩm thực thi IEntity
    ├── Exceptions.cs          # Các Exception tự tạo (DuplicateProductException, ProductNotFoundException)
    ├── Repository.cs          # Generic Repository<T> có ràng buộc where T : class, IEntity
    ├── ProductService.cs      # Service nghiệp vụ sản phẩm, phát Action events và lọc bằng Func
    └── Program.cs             # Menu Console, đăng ký lắng nghe sự kiện và bắt Exception
```

---

## 🏛️ Kiến trúc & Thiết kế kỹ thuật

### 1. Interface & Generic Constraint
```csharp
public interface IEntity
{
    string Id { get; }
}

public class Repository<T> where T : class, IEntity
{
    // Quản lý bất kỳ đối tượng nào có thuộc tính Id
}
```

### 2. Các Ngoại lệ tự tạo (Custom Exceptions)
- **`DuplicateProductException`:** Bắn ra (`throw`) khi mã sản phẩm cần thêm đã tồn tại trong repository.
- **`ProductNotFoundException`:** Bắn ra (`throw`) khi tìm kiếm hoặc xóa một sản phẩm không có trong kho.

### 3. Cơ chế Action Event (`ProductService.cs`)
```csharp
public event Action<Product>? OnProductAdded;
public event Action<string>? OnProductRemoved;

// Khi thêm thành công:
OnProductAdded?.Invoke(p);

// Khi xóa thành công:
OnProductRemoved?.Invoke(id);
```
Tại `Program.cs`, console đăng ký lắng nghe và in thông báo màu trực quan khi sự kiện kích hoạt mà không làm phụ thuộc chặt giữa các tầng.

### 4. Tìm kiếm & Lọc bằng `Func<Product, bool>`
```csharp
// Tìm theo tên
Func<Product, bool> predicate = p => p.TenSP.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0;
return _repo.Find(predicate);

// Lọc theo khoảng giá [minPrice, maxPrice]
Func<Product, bool> priceFilter = p => p.Price >= minPrice && p.Price <= maxPrice;
return _repo.Find(priceFilter);
```

---

## ✨ Mẫu Menu & Các chức năng thực thi
```text
========================================
      ===== PRODUCT MANAGER =====
========================================
1. Them san pham
2. Xuat danh sach
3. Tim theo ma
4. Tim theo ten
5. Loc theo khoang gia
6. Xoa san pham
7. Tinh tong gia tri kho
0. Thoat
----------------------------------------
Chon: 
```

### Bảng kịch bản kiểm thử (Test Cases)
| STT | Chức năng | Dữ liệu kiểm thử | Kết quả kỳ vọng |
|---|---|---|---|
| 1 | Thêm sản phẩm hợp lệ | `SP06`, `Webcam Logitech`, `1200000`, `10` | Kích hoạt sự kiện `OnProductAdded`, thông báo thêm thành công. |
| 2 | Thêm trùng mã sản phẩm | `SP01` | Ném `DuplicateProductException`, bắt lỗi tại `Program` và in thông báo lỗi đỏ. |
| 3 | Nhập đơn giá / số lượng âm | Đơn giá `-50000` | Ném `ArgumentException`, yêu cầu nhập số dương. |
| 4 | Lọc theo khoảng giá | Min: `500000`, Max: `2000000` | Sử dụng `Func<Product, bool>`, hiển thị danh sách sản phẩm trong tầm giá. |
| 5 | Xóa mã không tồn tại | `SP999` | Ném `ProductNotFoundException`, bắt lỗi và in thông báo không tìm thấy. |
| 6 | Xóa sản phẩm hợp lệ | `SP02` | Kích hoạt sự kiện `OnProductRemoved`, xóa khỏi kho và in thông báo màu tím. |
| 7 | Tính tổng giá trị kho hàng | Chọn mục 7 | Tính $\sum (\text{Đơn giá} \times \text{Số lượng})$, in tổng tiền định dạng tiền tệ `N0`. |

---

## 🚀 Hướng dẫn biên dịch và chạy chương trình
1. Mở terminal tại thư mục `D:\NamBa\LTW\LAB04\LAB04`:
   ```powershell
   dotnet build
   dotnet run
   ```
2. Hoặc mở file solution `LAB04.slnx` bằng **Visual Studio 2022** và nhấn **F5**.
