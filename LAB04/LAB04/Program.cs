using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace LAB04
{
    internal class Program
    {
        private static readonly ProductService _service = new ProductService();

        private static void Main(string[] args)
        {
            // Thiết lập font chữ tiếng Việt cho Console
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            // Đăng ký nhận thông báo từ Event / Action Event của ProductService
            DangKySuKien();

            // Nạp dữ liệu mẫu ban đầu
            _service.SeedSampleData();

            bool tiepTuc = true;
            while (tiepTuc)
            {
                HienThiMenu();
                Console.Write("Chon: ");
                string? luaChon = Console.ReadLine()?.Trim();

                Console.WriteLine();
                switch (luaChon)
                {
                    case "1":
                        ThemSanPham();
                        break;
                    case "2":
                        XuatDanhSach();
                        break;
                    case "3":
                        TimTheoMa();
                        break;
                    case "4":
                        TimTheoTen();
                        break;
                    case "5":
                        LocTheoKhoangGia();
                        break;
                    case "6":
                        XoaSanPham();
                        break;
                    case "7":
                        TinhTongGiaTriKho();
                        break;
                    case "0":
                        tiepTuc = false;
                        Console.WriteLine("Cảm ơn bạn đã sử dụng chương trình Product Manager. Tạm biệt!");
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Lựa chọn không hợp lệ! Vui lòng chọn số từ 0 đến 7.");
                        Console.ResetColor();
                        break;
                }

                if (tiepTuc)
                {
                    Console.WriteLine();
                    Console.Write("Nhấn phím bất kỳ để tiếp tục...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        private static void DangKySuKien()
        {
            // Đăng ký xử lý sự kiện khi thêm sản phẩm thành công
            _service.OnProductAdded += product =>
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"[SỰ KIỆN - EVENT]: Đã thêm thành công sản phẩm: [{product.MaSP}] {product.TenSP} (SL: {product.Quantity})");
                Console.ResetColor();
            };

            // Đăng ký xử lý sự kiện khi xóa sản phẩm thành công
            _service.OnProductRemoved += id =>
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"[SỰ KIỆN - EVENT]: Đã xóa vĩnh viễn sản phẩm có mã [{id}] khỏi hệ thống kho!");
                Console.ResetColor();
            };
        }

        private static void HienThiMenu()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("========================================");
            Console.WriteLine("      ===== PRODUCT MANAGER =====");
            Console.WriteLine("========================================");
            Console.ResetColor();
            Console.WriteLine("1. Them san pham");
            Console.WriteLine("2. Xuat danh sach");
            Console.WriteLine("3. Tim theo ma");
            Console.WriteLine("4. Tim theo ten");
            Console.WriteLine("5. Loc theo khoang gia");
            Console.WriteLine("6. Xoa san pham");
            Console.WriteLine("7. Tinh tong gia tri kho");
            Console.WriteLine("0. Thoat");
            Console.WriteLine("----------------------------------------");
        }

        #region Các chức năng nghiệp vụ

        private static void ThemSanPham()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--- 1. THÊM SẢN PHẨM MỚI ---");
            Console.ResetColor();

            try
            {
                string maSP = NhapChuoiKhongRong("Nhập mã sản phẩm: ");
                string tenSP = NhapChuoiKhongRong("Nhập tên sản phẩm: ");
                decimal donGia = NhapSoThucDuong("Nhập đơn giá (VNĐ): ");
                int soLuong = NhapSoNguyenKhongAm("Nhập số lượng tồn kho: ");

                Product p = new Product(maSP, tenSP, donGia, soLuong);
                _service.AddProduct(p);
            }
            catch (DuplicateProductException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[LỖI TRÙNG MÃ]: {ex.Message}");
                Console.ResetColor();
            }
            catch (ArgumentException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[LỖI DỮ LIỆU ĐẦU VÀO]: {ex.Message}");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[LỖI HỆ THỐNG]: {ex.Message}");
                Console.ResetColor();
            }
        }

        private static void XuatDanhSach()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--- 2. DANH SÁCH TOÀN BỘ SẢN PHẨM ---");
            Console.ResetColor();

            var ds = _service.GetAllProducts();
            InBangSanPham(ds);
        }

        private static void TimTheoMa()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--- 3. TÌM SẢN PHẨM THEO MÃ ---");
            Console.ResetColor();

            string maSP = NhapChuoiKhongRong("Nhập mã sản phẩm cần tìm: ");
            var p = _service.FindById(maSP);

            if (p != null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("==> Tìm thấy thông tin sản phẩm:");
                Console.ResetColor();
                InBangSanPham(new List<Product> { p });
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"==> Không tìm thấy sản phẩm có mã '{maSP}'!");
                Console.ResetColor();
            }
        }

        private static void TimTheoTen()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--- 4. TÌM SẢN PHẨM THEO TÊN (DÙNG FUNC) ---");
            Console.ResetColor();

            string tuKhoa = NhapChuoiKhongRong("Nhập từ khóa tên sản phẩm: ");
            var ds = _service.SearchByName(tuKhoa);

            if (ds.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"==> Tìm thấy {ds.Count} sản phẩm có tên chứa '{tuKhoa}':");
                Console.ResetColor();
                InBangSanPham(ds);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"==> Không tìm thấy sản phẩm nào có tên chứa '{tuKhoa}'!");
                Console.ResetColor();
            }
        }

        private static void LocTheoKhoangGia()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--- 5. LỌC THEO KHOẢNG GIÁ (DÙNG FUNC<PRODUCT, BOOL>) ---");
            Console.ResetColor();

            try
            {
                decimal giaMin = NhapSoThucDuong("Nhập mức giá nhỏ nhất (Min Price): ");
                decimal giaMax = NhapSoThucDuong("Nhập mức giá lớn nhất (Max Price): ");

                var ds = _service.FilterByPriceRange(giaMin, giaMax);
                if (ds.Count > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"==> Tìm thấy {ds.Count} sản phẩm trong tầm giá {giaMin:N0} - {giaMax:N0} VNĐ:");
                    Console.ResetColor();
                    InBangSanPham(ds);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"==> Không có sản phẩm nào trong khoảng giá {giaMin:N0} - {giaMax:N0} VNĐ!");
                    Console.ResetColor();
                }
            }
            catch (ArgumentException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[LỖI]: {ex.Message}");
                Console.ResetColor();
            }
        }

        private static void XoaSanPham()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--- 6. XÓA SẢN PHẨM ---");
            Console.ResetColor();

            string maSP = NhapChuoiKhongRong("Nhập mã sản phẩm cần xóa: ");

            try
            {
                var p = _service.FindById(maSP);
                if (p == null)
                {
                    throw new ProductNotFoundException(maSP);
                }

                Console.Write($"Bạn có chắc chắn muốn xóa sản phẩm [{p.MaSP} - {p.TenSP}]? (y/n): ");
                string? xacNhan = Console.ReadLine()?.Trim().ToLower();

                if (xacNhan == "y" || xacNhan == "yes")
                {
                    _service.RemoveProduct(maSP);
                }
                else
                {
                    Console.WriteLine("Đã hủy thao tác xóa.");
                }
            }
            catch (ProductNotFoundException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[LỖI KHÔNG TÌM THẤY]: {ex.Message}");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[LỖI]: {ex.Message}");
                Console.ResetColor();
            }
        }

        private static void TinhTongGiaTriKho()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--- 7. TÍNH TỔNG GIÁ TRỊ TOÀN BỘ KHO HÀNG ---");
            Console.ResetColor();

            var ds = _service.GetAllProducts();
            InBangSanPham(ds);

            decimal tongTien = _service.GetTotalInventoryValue();
            int tongSL = 0;
            foreach (var p in ds) tongSL += p.Quantity;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"=========================================================================================");
            Console.WriteLine($"==> TỔNG SỐ LƯỢNG MẶT HÀNG TỒN: {tongSL,6} sản phẩm");
            Console.WriteLine($"==> TỔNG GIÁ TRỊ TÀI SẢN KHO HÀNG: {tongTien,14:N0} VNĐ");
            Console.WriteLine($"=========================================================================================");
            Console.ResetColor();
        }

        #endregion

        #region Hàm hỗ trợ nhập liệu và hiển thị bảng

        private static string NhapChuoiKhongRong(string thongBao)
        {
            while (true)
            {
                Console.Write(thongBao);
                string? input = Console.ReadLine()?.Trim();
                if (!string.IsNullOrWhiteSpace(input))
                {
                    return input;
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Giá trị không được để trống! Vui lòng nhập lại.");
                Console.ResetColor();
            }
        }

        private static decimal NhapSoThucDuong(string thongBao)
        {
            while (true)
            {
                Console.Write(thongBao);
                string? input = Console.ReadLine()?.Trim().Replace(',', '.');
                if (decimal.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal val))
                {
                    if (val >= 0)
                    {
                        return val;
                    }
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Giá trị không được là số âm (< 0)! Vui lòng nhập lại.");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Giá trị không hợp lệ! Vui lòng nhập một số hợp lệ.");
                    Console.ResetColor();
                }
            }
        }

        private static int NhapSoNguyenKhongAm(string thongBao)
        {
            while (true)
            {
                Console.Write(thongBao);
                string? input = Console.ReadLine()?.Trim();
                if (int.TryParse(input, out int val))
                {
                    if (val >= 0)
                    {
                        return val;
                    }
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Số lượng không được nhỏ hơn 0! Vui lòng nhập lại.");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Số lượng không hợp lệ! Vui lòng nhập số nguyên.");
                    Console.ResetColor();
                }
            }
        }

        private static void InBangSanPham(List<Product> ds)
        {
            if (ds == null || ds.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Danh sách sản phẩm đang trống!");
                Console.ResetColor();
                return;
            }

            Console.WriteLine("+----------+--------------------------+-------------------+----------+-------------------+");
            Console.WriteLine("| {0,-8} | {1,-24} | {2,17} | {3,8} | {4,17} |", "Mã SP", "Tên sản phẩm", "Đơn giá (VNĐ)", "Số lượng", "Thành tiền (VNĐ)");
            Console.WriteLine("+----------+--------------------------+-------------------+----------+-------------------+");

            foreach (var p in ds)
            {
                decimal thanhTien = p.Price * p.Quantity;
                Console.WriteLine("| {0,-8} | {1,-24} | {2,17:N0} | {3,8} | {4,17:N0} |",
                    p.MaSP,
                    p.TenSP,
                    p.Price,
                    p.Quantity,
                    thanhTien);
            }

            Console.WriteLine("+----------+--------------------------+-------------------+----------+-------------------+");
            Console.WriteLine($"Tổng số loại sản phẩm: {ds.Count}");
        }

        #endregion
    }
}
