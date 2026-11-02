using System;
using System.Collections.Generic;
using System.Linq;

namespace LAB03
{
    /// <summary>
    /// Service quản lý danh sách sinh viên, đóng gói toàn bộ logic nghiệp vụ (CRUD, tìm kiếm, sắp xếp).
    /// </summary>
    public class QuanLySinhVien
    {
        private readonly List<SinhVien> _danhSach = new List<SinhVien>();

        public QuanLySinhVien()
        {
        }

        /// <summary>
        /// Nạp sẵn một số sinh viên mẫu giúp kiểm thử nhanh các chức năng.
        /// </summary>
        public void NapDuLieuMau()
        {
            if (_danhSach.Count == 0)
            {
                _danhSach.Add(new SinhVien("SV001", "Nguyễn Văn An", new DateTime(2005, 2, 10), "CNTT01", 8.2));
                _danhSach.Add(new SinhVien("SV002", "Trần Thị Bình", new DateTime(2005, 8, 21), "CNTT01", 9.1));
                _danhSach.Add(new SinhVien("SV003", "Lê Minh Chi", new DateTime(2004, 12, 2), "CNTT02", 4.5));
                _danhSach.Add(new SinhVien("SV004", "Phạm Quốc Dung", new DateTime(2005, 4, 16), "CNTT02", 7.0));
                _danhSach.Add(new SinhVien("SV005", "Hoàng Gia Hân", new DateTime(2005, 10, 30), "SPTIN01", 8.5));
                _danhSach.Add(new SinhVien("SV006", "Võ Thành Khang", new DateTime(2004, 9, 9), "SPTIN01", 3.8));
            }
        }

        /// <summary>
        /// Thêm sinh viên mới. Trả về false nếu mã sinh viên đã tồn tại.
        /// </summary>
        public bool Them(SinhVien sv)
        {
            if (sv == null) return false;

            if (KiemTraTonTai(sv.MaSinhVien))
            {
                return false;
            }

            _danhSach.Add(sv);
            return true;
        }

        /// <summary>
        /// Lấy toàn bộ danh sách sinh viên hiện có.
        /// </summary>
        public List<SinhVien> LayDanhSach()
        {
            return new List<SinhVien>(_danhSach);
        }

        /// <summary>
        /// Tìm kiếm sinh viên theo mã sinh viên chính xác.
        /// </summary>
        public SinhVien? TimTheoMa(string maSV)
        {
            if (string.IsNullOrWhiteSpace(maSV)) return null;

            return _danhSach.FirstOrDefault(s => s.MaSinhVien.Equals(maSV.Trim(), StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Tìm kiếm danh sách sinh viên theo từ khóa họ tên (không phân biệt hoa thường) sử dụng LINQ.
        /// </summary>
        public List<SinhVien> TimTheoTen(string tuKhoa)
        {
            if (string.IsNullOrWhiteSpace(tuKhoa)) return new List<SinhVien>();

            return _danhSach
                .Where(s => s.HoTen.IndexOf(tuKhoa.Trim(), StringComparison.OrdinalIgnoreCase) >= 0)
                .OrderBy(s => s.HoTen)
                .ToList();
        }

        /// <summary>
        /// Sửa điểm trung bình của sinh viên theo mã sinh viên.
        /// </summary>
        public bool SuaDiem(string maSV, double diemMoi)
        {
            var sv = TimTheoMa(maSV);
            if (sv == null) return false;

            sv.DiemTrungBinh = diemMoi; // Tự động kích hoạt validation trong setter
            return true;
        }

        /// <summary>
        /// Xóa sinh viên khỏi danh sách theo mã sinh viên.
        /// </summary>
        public bool Xoa(string maSV)
        {
            var sv = TimTheoMa(maSV);
            if (sv == null) return false;

            return _danhSach.Remove(sv);
        }

        /// <summary>
        /// Sắp xếp danh sách sinh viên theo điểm trung bình giảm dần sử dụng LINQ.
        /// </summary>
        public List<SinhVien> SapXepTheoDiemGiamDan()
        {
            return _danhSach
                .OrderByDescending(s => s.DiemTrungBinh)
                .ThenBy(s => s.HoTen)
                .ToList();
        }

        /// <summary>
        /// Lọc danh sách sinh viên đạt chuẩn (Điểm trung bình >= 5.0) sử dụng LINQ.
        /// </summary>
        public List<SinhVien> LocSinhVienDat()
        {
            return _danhSach
                .Where(s => s.DiemTrungBinh >= 5.0)
                .OrderByDescending(s => s.DiemTrungBinh)
                .ToList();
        }

        /// <summary>
        /// Kiểm tra xem mã sinh viên đã tồn tại trong hệ thống chưa.
        /// </summary>
        public bool KiemTraTonTai(string maSV)
        {
            if (string.IsNullOrWhiteSpace(maSV)) return false;

            return _danhSach.Any(s => s.MaSinhVien.Equals(maSV.Trim(), StringComparison.OrdinalIgnoreCase));
        }
    }
}
