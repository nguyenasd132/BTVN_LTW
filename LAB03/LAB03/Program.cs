using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace LAB03
{
    internal class Program
    {
        private static readonly QuanLySinhVien _quanLy = new QuanLySinhVien();

        private static void Main(string[] args)
        {
            // Thiết lập font chữ tiếng Việt cho Console
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            // Nạp dữ liệu mẫu ban đầu để tiện kiểm thử
            _quanLy.NapDuLieuMau();

            bool tiepTuc = true;
            while (tiepTuc)
            {
                HienThiMenu();
                Console.Write("Chon chuc nang: ");
                string? luaChon = Console.ReadLine()?.Trim();

                Console.WriteLine();
                switch (luaChon)
                {
                    case "1":
                        ThemSinhVien();
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
                        SuaDiem();
                        break;
                    case "6":
                        XoaSinhVien();
                        break;
                    case "7":
                        SapXepTheoDiemGiamDan();
                        break;
                    case "8":
                        LocSinhVienDat();
                        break;
                    case "0":
                        tiepTuc = false;
                        Console.WriteLine("Cảm ơn bạn đã sử dụng chương trình. Tạm biệt!");
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Lựa chọn không hợp lệ! Vui lòng chọn số từ 0 đến 8.");
                        Console.ResetColor();
                        break;
                }

                if (tiepTuc)
                {
                    Console.WriteLine();
                    Console.Write("Nhấn phím bất kỳ để quay lại menu...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        private static void HienThiMenu()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("========================================");
            Console.WriteLine("        ===== QUAN LY SINH VIEN =====");
            Console.WriteLine("========================================");
            Console.ResetColor();
            Console.WriteLine("1. Them sinh vien");
            Console.WriteLine("2. Xuat danh sach");
            Console.WriteLine("3. Tim sinh vien theo ma");
            Console.WriteLine("4. Tim sinh vien theo ten");
            Console.WriteLine("5. Sua diem trung binh");
            Console.WriteLine("6. Xoa sinh vien");
            Console.WriteLine("7. Sap xep theo diem giam dan");
            Console.WriteLine("8. Loc sinh vien dat");
            Console.WriteLine("0. Thoat");
            Console.WriteLine("----------------------------------------");
        }

        #region Chức năng nghiệp vụ

        private static void ThemSinhVien()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--- 1. THÊM SINH VIÊN MỚI ---");
            Console.ResetColor();

            string maSV;
            while (true)
            {
                maSV = NhapChuoiKhongRong("Nhập mã sinh viên: ");
                if (_quanLy.KiemTraTonTai(maSV))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Mã sinh viên '{maSV}' đã tồn tại trong hệ thống! Vui lòng nhập mã khác.");
                    Console.ResetColor();
                }
                else
                {
                    break;
                }
            }

            string hoTen = NhapChuoiKhongRong("Nhập họ và tên: ");
            DateTime ngaySinh = NhapNgaySinh("Nhập ngày sinh (dd/MM/yyyy): ");
            string maLop = NhapChuoiKhongRong("Nhập mã lớp: ");
            double diemTB = NhapDiemTrungBinh("Nhập điểm trung bình (0.0 - 10.0): ");

            try
            {
                SinhVien sv = new SinhVien(maSV, hoTen, ngaySinh, maLop, diemTB);
                bool ketQua = _quanLy.Them(sv);
                if (ketQua)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"==> Thêm thành công sinh viên [{sv.MaSinhVien}] - Xếp loại: {sv.XepLoai()}!");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("==> Thêm thất bại! Mã sinh viên đã tồn tại.");
                    Console.ResetColor();
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Lỗi khi tạo sinh viên: {ex.Message}");
                Console.ResetColor();
            }
        }

        private static void XuatDanhSach()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--- 2. DANH SÁCH TẤT CẢ SINH VIÊN ---");
            Console.ResetColor();

            var ds = _quanLy.LayDanhSach();
            InBangSinhVien(ds);
        }

        private static void TimTheoMa()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--- 3. TÌM SINH VIÊN THEO MÃ ---");
            Console.ResetColor();

            string maSV = NhapChuoiKhongRong("Nhập mã sinh viên cần tìm: ");
            var sv = _quanLy.TimTheoMa(maSV);

            if (sv != null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("==> Tìm thấy sinh viên:");
                Console.ResetColor();
                InBangSinhVien(new List<SinhVien> { sv });
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"==> Không tìm thấy sinh viên có mã '{maSV}'!");
                Console.ResetColor();
            }
        }

        private static void TimTheoTen()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--- 4. TÌM SINH VIÊN THEO TÊN ---");
            Console.ResetColor();

            string tuKhoa = NhapChuoiKhongRong("Nhập từ khóa họ tên cần tìm: ");
            var ketQua = _quanLy.TimTheoTen(tuKhoa);

            if (ketQua.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"==> Tìm thấy {ketQua.Count} sinh viên có họ tên chứa '{tuKhoa}':");
                Console.ResetColor();
                InBangSinhVien(ketQua);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"==> Không tìm thấy sinh viên nào chứa từ khóa '{tuKhoa}'!");
                Console.ResetColor();
            }
        }

        private static void SuaDiem()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--- 5. SỬA ĐIỂM TRUNG BÌNH ---");
            Console.ResetColor();

            string maSV = NhapChuoiKhongRong("Nhập mã sinh viên cần sửa điểm: ");
            var sv = _quanLy.TimTheoMa(maSV);

            if (sv == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"==> Không tìm thấy sinh viên có mã '{maSV}'!");
                Console.ResetColor();
                return;
            }

            Console.WriteLine($"Sinh viên: {sv.HoTen} | Điểm hiện tại: {sv.DiemTrungBinh:0.0} | Xếp loại cũ: {sv.XepLoai()}");
            double diemMoi = NhapDiemTrungBinh("Nhập điểm trung bình mới (0.0 - 10.0): ");

            if (_quanLy.SuaDiem(maSV, diemMoi))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"==> Cập nhật thành công! Điểm mới: {sv.DiemTrungBinh:0.0} | Xếp loại mới: {sv.XepLoai()}");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("==> Cập nhật điểm thất bại!");
                Console.ResetColor();
            }
        }

        private static void XoaSinhVien()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--- 6. XÓA SINH VIÊN ---");
            Console.ResetColor();

            string maSV = NhapChuoiKhongRong("Nhập mã sinh viên cần xóa: ");
            var sv = _quanLy.TimTheoMa(maSV);

            if (sv == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"==> Không tìm thấy sinh viên có mã '{maSV}' để xóa!");
                Console.ResetColor();
                return;
            }

            Console.Write($"Bạn có chắc chắn muốn xóa sinh viên [{sv.MaSinhVien} - {sv.HoTen}]? (y/n): ");
            string? xacNhan = Console.ReadLine()?.Trim().ToLower();

            if (xacNhan == "y" || xacNhan == "yes")
            {
                if (_quanLy.Xoa(maSV))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"==> Đã xóa thành công sinh viên [{maSV}]!");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("==> Xóa thất bại!");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.WriteLine("Đã hủy thao tác xóa.");
            }
        }

        private static void SapXepTheoDiemGiamDan()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--- 7. DANH SÁCH SẮP XẾP THEO ĐIỂM GIẢM DẦN ---");
            Console.ResetColor();

            var ds = _quanLy.SapXepTheoDiemGiamDan();
            InBangSinhVien(ds);
        }

        private static void LocSinhVienDat()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--- 8. DANH SÁCH SINH VIÊN ĐẠT (ĐIỂM >= 5.0) ---");
            Console.ResetColor();

            var dsDat = _quanLy.LocSinhVienDat();
            InBangSinhVien(dsDat);
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

        private static DateTime NhapNgaySinh(string thongBao)
        {
            string[] formats = { "dd/MM/yyyy", "d/M/yyyy", "yyyy-MM-dd" };
            while (true)
            {
                Console.Write(thongBao);
                string? input = Console.ReadLine()?.Trim();
                if (DateTime.TryParseExact(input, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dt))
                {
                    if (dt <= DateTime.Today)
                    {
                        return dt;
                    }
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ngày sinh không thể lớn hơn ngày hiện tại! Vui lòng nhập lại.");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Định dạng ngày không hợp lệ! Vui lòng nhập theo định dạng dd/MM/yyyy (ví dụ: 15/08/2005).");
                    Console.ResetColor();
                }
            }
        }

        private static double NhapDiemTrungBinh(string thongBao)
        {
            while (true)
            {
                Console.Write(thongBao);
                string? input = Console.ReadLine()?.Trim().Replace(',', '.');
                if (double.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out double diem))
                {
                    if (diem >= 0.0 && diem <= 10.0)
                    {
                        return diem;
                    }
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Điểm trung bình phải nằm trong khoảng từ 0.0 đến 10.0! Vui lòng nhập lại.");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Điểm không hợp lệ! Vui lòng nhập một số thực từ 0 đến 10.");
                    Console.ResetColor();
                }
            }
        }

        private static void InBangSinhVien(List<SinhVien> ds)
        {
            if (ds == null || ds.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Danh sách trống!");
                Console.ResetColor();
                return;
            }

            Console.WriteLine("+------------+----------------------+------------+------------+-------+------------+");
            Console.WriteLine("| {0,-10} | {1,-20} | {2,-10} | {3,-10} | {4,5} | {5,-10} |", "Mã SV", "Họ và tên", "Ngày sinh", "Lớp", "ĐTB", "Xếp loại");
            Console.WriteLine("+------------+----------------------+------------+------------+-------+------------+");

            foreach (var sv in ds)
            {
                Console.WriteLine("| {0,-10} | {1,-20} | {2,-10:dd/MM/yyyy} | {3,-10} | {4,5:0.0} | {5,-10} |",
                    sv.MaSinhVien,
                    sv.HoTen,
                    sv.NgaySinh,
                    sv.MaLop,
                    sv.DiemTrungBinh,
                    sv.XepLoai());
            }

            Console.WriteLine("+------------+----------------------+------------+------------+-------+------------+");
            Console.WriteLine($"Tổng số sinh viên: {ds.Count}");
        }

        #endregion
    }
}
