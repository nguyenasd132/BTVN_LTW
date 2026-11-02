# LAB 08: ỨNG DỤNG VẼ HÌNH GDI+ (SIMPLE PAINT APPLICATION)

## 📌 Giới thiệu tổng quan
**LAB 08** là ứng dụng đồ họa 2D xây dựng trên nền tảng **.NET Framework 4.7.2** bằng công nghệ **GDI+** (`System.Drawing`). Chương trình cung cấp môi trường vẽ tranh và phác thảo hình học tương tự Microsoft Paint, hỗ trợ vẽ nét tự do, đường thẳng, hình chữ nhật, hình elip với khả năng tùy chỉnh màu sắc, độ dày nét vẽ, hoàn tác (Undo) và cơ chế chống nhấp nháy hình ảnh (Double Buffering).

---

## 🎯 Mục tiêu bài thực hành
- Nắm vững kiến thức đồ họa GDI+ trong Windows Forms: đối tượng `Graphics`, `Pen`, `Brush`, `Color`, tọa độ `Point`, `Rectangle`.
- Khử răng cưa cho đường nét vẽ mịn màng với thuộc tính `SmoothingMode.AntiAlias`.
- Xử lý kỹ thuật **Double Buffering** (Bộ đệm kép) thông qua việc kế thừa `Panel` (`DrawSurface`) để khắc phục triệt để hiện tượng nhấp nháy (flickering) khi vẽ thời gian thực.
- Bắt và xử lý chuỗi sự kiện chuột: `MouseDown` (bắt đầu vẽ), `MouseMove` (vẽ đường tạm thời preview khi kéo chuột), `MouseUp` (kết thúc và ghi nhận đối tượng vẽ vào danh sách).
- Thuật toán chuẩn hóa hình học: chuyển đổi cặp tọa độ điểm kéo tự do $ (x_1, y_1) $ và $ (x_2, y_2) $ thành hình chữ nhật bao quanh hợp lệ ($ x = \min, y = \min, w = |x_2 - x_1|, h = |y_2 - y_1| $).
- Quản lý danh sách các nét vẽ trong bộ nhớ và xây dựng tính năng Hoàn tác (**Undo**).

---

## 🛠️ Công nghệ & Môi trường phát triển
- **Ngôn ngữ:** C# (.NET Framework 4.7.2)
- **Đồ họa:** GDI+ (`System.Drawing`, `System.Drawing.Drawing2D`)
- **Giao diện:** Windows Forms (Dynamic UI kết hợp Custom Panel)
- **IDE khuyến nghị:** Visual Studio 2019 / Visual Studio 2022

---

## 📁 Cấu trúc thư mục
```text
LAB08/
├── LAB08.slnx                 # Solution file
└── LAB08/
    ├── LAB08.csproj           # Cấu hình dự án
    ├── App.config             # Cấu hình runtime
    ├── Program.cs             # Điểm khởi động ứng dụng
    ├── DrawMode.cs            # Enum định nghĩa các chế độ vẽ
    ├── DrawItem.cs            # Lớp Model lưu trữ trạng thái của từng hình vẽ
    ├── DrawSurface.cs         # Custom Panel bật DoubleBuffered để làm vùng vẽ
    ├── FrmPaint.cs            # Code-behind xây dựng giao diện, bắt sự kiện và render
    ├── FrmPaint.Designer.cs   # File định nghĩa designer
    └── Properties/
        ├── AssemblyInfo.cs
        ├── Resources.resx
        └── Settings.settings
```

---

## 🎨 Các thành phần & Đối tượng chính

### 1. Khung vẽ tùy biến `DrawSurface.cs`
Kế thừa từ `Panel` chuẩn của Windows Forms và kích hoạt cờ `DoubleBuffered = true` trong constructor:
```csharp
public class DrawSurface : Panel
{
    public DrawSurface()
    {
        DoubleBuffered = true;
        BackColor = Color.White;
        Dock = DockStyle.Fill;
    }
}
```
*Điều này giúp mọi thao tác vẽ đều diễn ra trong bộ nhớ trước khi hiển thị lên màn hình, loại bỏ 100% tình trạng giật lag hay nhấp nháy.*

### 2. Các chế độ vẽ (`DrawMode.cs`)
Hỗ trợ 4 chế độ vẽ:
- `Pen`: Bút chì vẽ tự do theo quỹ đạo chuột di chuyển (lưu trữ danh sách `List<Point>`).
- `Line`: Vẽ đoạn thẳng từ điểm bắt đầu đến điểm kết thúc.
- `Rectangle`: Vẽ hình chữ nhật.
- `Ellipse`: Vẽ hình bầu dục / hình tròn nội tiếp khung bao.

### 3. Đối tượng hình vẽ (`DrawItem.cs`)
Lưu trữ đầy đủ các thông tin hình học và thuộc tính đồ họa:
- `Mode`: Chế độ vẽ (`DrawMode`).
- `Start`, `End`: Tọa độ điểm bắt đầu và điểm kết thúc (`Point`).
- `Color`: Màu sắc nét vẽ (`Color`).
- `Width`: Độ rộng/độ dày nét vẽ (`float`).
- `Points`: Danh sách tọa độ các điểm dành cho chế độ vẽ tự do `Pen`.

---

## ✨ Tính năng chi tiết

### 1. Bảng điều khiển công cụ vẽ (Top Toolbar)
- **Chọn công cụ (`cboMode`):** Chuyển đổi linh hoạt giữa Pen, Line, Rectangle, Ellipse.
- **Độ dày nét vẽ (`nudWidth`):** Tùy chỉnh kích cỡ nét từ **1px** đến **20px** (mặc định 3px).
- **Chọn màu vẽ (`btnColor`):** Mở hộp thoại `ColorDialog` cho phép lựa chọn bảng màu chuẩn hoặc tự pha màu tùy biến.
- **Hoàn tác (`btnUndo`):** Xóa bỏ nét vẽ hoặc hình vẽ được tạo gần nhất trong danh sách `items`.
- **Làm mới bảng vẽ (`btnClear`):** Xóa toàn bộ nét vẽ và đưa canvas về trang giấy trắng ban đầu.
- **Thanh trạng thái (`lblStatus`):** Hiển thị trạng thái tương tác chuột và tọa độ con trỏ thời gian thực.

### 2. Kỹ thuật Render đồ họa (`Canvas_Paint`)
Toàn bộ quá trình vẽ được xử lý trong sự kiện `Paint` của `DrawSurface`:
1. Thiết lập `e.Graphics.SmoothingMode = SmoothingMode.AntiAlias` để đường nét luôn mịn màng.
2. Lặp qua danh sách `items` đã lưu để vẽ lại tất cả các đối tượng trước đó.
3. Nếu đang trong trạng thái nhấn kéo chuột (`isDrawing == true`), vẽ đối tượng tạm thời (`currentItem`) đè lên để người dùng xem trước (preview) kết quả theo vị trí chuột.

---

## 🚀 Hướng dẫn cài đặt và chạy ứng dụng
1. Mở file `LAB08.slnx` hoặc `LAB08.csproj` bằng **Visual Studio**.
2. Nhấn **F5** để khởi chạy chương trình `Simple Paint`.
3. Chọn chế độ vẽ, kích cỡ nét, màu sắc và bắt đầu sáng tạo trên khung vẽ màu trắng.
