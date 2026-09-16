using System;
using System.Collections.Generic;

namespace QuanLyNhanVien
{
    // ================== LỚP CHA ==================
    public class NhanVien
    {
        private string maNV;
        private string hoTen;
        private double luongCoBan;

        public string MaNV
        {
            get => maNV;
            set => maNV = value;
        }

        public string HoTen
        {
            get => hoTen;
            set => hoTen = value;
        }

        public double LuongCoBan
        {
            get => luongCoBan;
            set
            {
                if (value > 0)
                    luongCoBan = value;
                else
                    throw new ArgumentException("Lương cơ bản phải lớn hơn 0.");
            }
        }

        public NhanVien(string maNV, string hoTen, double luongCoBan)
        {
            MaNV = maNV;
            HoTen = hoTen;
            LuongCoBan = luongCoBan;
        }

        public virtual double TinhLuong()
        {
            return LuongCoBan;
        }

        public virtual void HienThiThongTin()
        {
            Console.WriteLine($"Mã NV: {MaNV} | Họ tên: {HoTen} | Lương CB: {LuongCoBan:N0} VNĐ | Lương thực nhận: {TinhLuong():N0} VNĐ");
        }
    }

    // ================== LỚP NHÂN VIÊN VĂN PHÒNG ==================
    public class NhanVienVanPhong : NhanVien
    {
        private int soNgayLamViec;

        public int SoNgayLamViec
        {
            get => soNgayLamViec;
            set
            {
                if (value >= 0 && value <= 31)
                    soNgayLamViec = value;
                else
                    throw new ArgumentException("Số ngày làm việc phải từ 0 đến 31.");
            }
        }

        public NhanVienVanPhong(string maNV, string hoTen, double luongCoBan, int soNgayLamViec)
            : base(maNV, hoTen, luongCoBan)
        {
            SoNgayLamViec = soNgayLamViec;
        }

        public override double TinhLuong()
        {
            return LuongCoBan + (SoNgayLamViec * 200000.0);
        }

        public override void HienThiThongTin()
        {
            Console.WriteLine($"[Văn Phòng] Mã NV: {MaNV} | Họ tên: {HoTen} | Lương CB: {LuongCoBan:N0} | Ngày làm: {SoNgayLamViec} | Lương thực nhận: {TinhLuong():N0} VNĐ");
        }
    }

    // ================== LỚP NHÂN VIÊN KINH DOANH ==================
    public class NhanVienKinhDoanh : NhanVien
    {
        private double doanhSo;

        public double DoanhSo
        {
            get => doanhSo;
            set
            {
                if (value >= 0)
                    doanhSo = value;
                else
                    throw new ArgumentException("Doanh số phải lớn hơn hoặc bằng 0.");
            }
        }

        public NhanVienKinhDoanh(string maNV, string hoTen, double luongCoBan, double doanhSo)
            : base(maNV, hoTen, luongCoBan)
        {
            DoanhSo = doanhSo;
        }

        public override double TinhLuong()
        {
            return LuongCoBan + (0.05 * DoanhSo);
        }

        public override void HienThiThongTin()
        {
            Console.WriteLine($"[Kinh Doanh] Mã NV: {MaNV} | Họ tên: {HoTen} | Lương CB: {LuongCoBan:N0} | Doanh số: {DoanhSo:N0} | Lương thực nhận: {TinhLuong():N0} VNĐ");
        }
    }

    // ================== BONUS: LỚP NHÂN VIÊN THỜI VỤ ==================
    public class NhanVienThoiVu : NhanVien
    {
        private double soGioLam;
        private double luongTheoGio;

        public double SoGioLam
        {
            get => soGioLam;
            set
            {
                if (value >= 0) soGioLam = value;
                else throw new ArgumentException("Số giờ làm phải lớn hơn hoặc bằng 0.");
            }
        }

        public double LuongTheoGio
        {
            get => luongTheoGio;
            set
            {
                if (value >= 0) luongTheoGio = value;
                else throw new ArgumentException("Lương theo giờ phải lớn hơn hoặc bằng 0.");
            }
        }

        // Với nhân viên thời vụ, truyền lương cơ bản giả định = 1 (do lớp cha yêu cầu > 0)
        public NhanVienThoiVu(string maNV, string hoTen, double soGioLam, double luongTheoGio)
            : base(maNV, hoTen, 1)
        {
            SoGioLam = soGioLam;
            LuongTheoGio = luongTheoGio;
        }

        public override double TinhLuong()
        {
            return SoGioLam * LuongTheoGio;
        }

        public override void HienThiThongTin()
        {
            Console.WriteLine($"[Thời Vụ]    Mã NV: {MaNV} | Họ tên: {HoTen} | Giờ làm: {SoGioLam} | Lương/giờ: {LuongTheoGio:N0} | Lương thực nhận: {TinhLuong():N0} VNĐ");
        }
    }

    // ================== CHƯƠNG TRÌNH CHÍNH ==================
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            List<NhanVien> danhSach = new List<NhanVien>();

            // Khởi tạo ngau nhiên 5 nhân viên 
            danhSach.Add(new NhanVienVanPhong("VP01", "Nguyễn Văn An", 5000000, 22));
            danhSach.Add(new NhanVienVanPhong("VP02", "Trần Thị Bình", 6000000, 26));
            danhSach.Add(new NhanVienKinhDoanh("KD01", "Lê Hoàng Long", 4500000, 150000000));
            danhSach.Add(new NhanVienKinhDoanh("KD02", "Phạm Quỳnh Chi", 4500000, 80000000));
            danhSach.Add(new NhanVienThoiVu("TV01", "Đỗ Minh Tuấn", 120, 50000));

            int luaChon;
            do
            {
                Console.WriteLine("\n========== MENU ==========");
                Console.WriteLine("1. Xuất danh sách nhân viên");
                Console.WriteLine("2. Tìm nhân viên theo mã");
                Console.WriteLine("3. Tìm nhân viên có lương cao nhất");
                Console.WriteLine("4. Tính tổng lương công ty phải trả");
                Console.WriteLine("0. Thoát");
                Console.Write("Chọn chức năng: ");

                if (!int.TryParse(Console.ReadLine(), out luaChon))
                {
                    Console.WriteLine("Lựa chọn không hợp lệ!");
                    continue;
                }

                switch (luaChon)
                {
                    case 1:
                        XuatDanhSach(danhSach);
                        break;
                    case 2:
                        TimTheoMa(danhSach);
                        break;
                    case 3:
                        TimLuongCaoNhat(danhSach);
                        break;
                    case 4:
                        TinhTongLuong(danhSach);
                        break;
                    case 0:
                        Console.WriteLine("Kết thúc chương trình!");
                        break;
                    default:
                        Console.WriteLine("Chức năng không tồn tại. Vui lòng chọn lại!");
                        break;
                }
            } while (luaChon != 0);
        }

        // ================== CÁC HÀM XỬ LÝ ĐA HÌNH ==================

        // 1. Xuất danh sách
        static void XuatDanhSach(List<NhanVien> danhSach)
        {
            Console.WriteLine("\n--- DANH SÁCH NHÂN VIÊN ---");
            foreach (NhanVien nv in danhSach)
            {
                nv.HienThiThongTin();
            }
        }

        // 2. Tìm nhân viên theo mã
        static void TimTheoMa(List<NhanVien> danhSach)
        {
            Console.Write("\nNhập mã nhân viên cần tìm: ");
            string ma = Console.ReadLine()?.Trim();
            bool timThay = false;

            foreach (NhanVien nv in danhSach)
            {
                if (string.Equals(nv.MaNV, ma, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("-> Thông tin tìm thấy:");
                    nv.HienThiThongTin();
                    timThay = true;
                    break;
                }
            }

            if (!timThay)
            {
                Console.WriteLine($"-> Không tìm thấy nhân viên có mã '{ma}'.");
            }
        }

        // 3. Tìm nhân viên lương cao nhất: Dùng đa hình nv.TinhLuong(), không phụ thuộc vào loại nhân viên
        static void TimLuongCaoNhat(List<NhanVien> danhSach)
        {
            if (danhSach.Count == 0) return;

            NhanVien maxNV = danhSach[0];
            for (int i = 1; i < danhSach.Count; i++)
            {
                if (danhSach[i].TinhLuong() > maxNV.TinhLuong())
                {
                    maxNV = danhSach[i];
                }
            }

            Console.WriteLine("\n--- NHÂN VIÊN CÓ LƯƠNG CAO NHẤT ---");
            maxNV.HienThiThongTin();
        }

        // 4. Tính tổng lương: Dùng đa hình nv.TinhLuong()
        static void TinhTongLuong(List<NhanVien> danhSach)
        {
            double tongLuong = 0;
            foreach (NhanVien nv in danhSach)
            {
                tongLuong += nv.TinhLuong();
            }

            Console.WriteLine($"\n-> Tổng lương công ty phải trả: {tongLuong:N0} VNĐ");
        }
    }
}