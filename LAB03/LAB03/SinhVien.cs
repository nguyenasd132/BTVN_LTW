using System;

namespace LAB03
{
    /// <summary>
    /// Lớp SinhVien kế thừa từ lớp Nguoi, bổ sung các thông tin học tập và xếp loại.
    /// </summary>
    public class SinhVien : Nguoi
    {
        private double _diemTrungBinh;

        public string MaSinhVien { get; set; } = string.Empty;
        public string MaLop { get; set; } = string.Empty;

        /// <summary>
        /// Điểm trung bình có ràng buộc giá trị từ 0.0 đến 10.0.
        /// </summary>
        public double DiemTrungBinh
        {
            get => _diemTrungBinh;
            set
            {
                if (value < 0.0 || value > 10.0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Điểm trung bình phải nằm trong khoảng từ 0.0 đến 10.0!");
                }
                _diemTrungBinh = value;
            }
        }

        public SinhVien() : base()
        {
        }

        public SinhVien(string maSinhVien, string hoTen, DateTime ngaySinh, string maLop, double diemTrungBinh)
            : base(hoTen, ngaySinh)
        {
            MaSinhVien = maSinhVien;
            MaLop = maLop;
            DiemTrungBinh = diemTrungBinh;
        }

        /// <summary>
        /// Phân loại học lực sinh viên dựa trên điểm trung bình:
        /// >= 9.0: Xuất sắc
        /// >= 8.0: Giỏi
        /// >= 6.5: Khá
        /// >= 5.0: Trung bình
        /// < 5.0: Yếu
        /// </summary>
        public string XepLoai()
        {
            if (DiemTrungBinh >= 9.0) return "Xuất sắc";
            if (DiemTrungBinh >= 8.0) return "Giỏi";
            if (DiemTrungBinh >= 6.5) return "Khá";
            if (DiemTrungBinh >= 5.0) return "Trung bình";
            return "Yếu";
        }

        /// <summary>
        /// Ghi đè phương thức LayThongTin() từ lớp Nguoi để hiển thị đầy đủ thông tin sinh viên.
        /// </summary>
        public override string LayThongTin()
        {
            return $"Mã SV: {MaSinhVien} | Họ tên: {HoTen} | Ngày sinh: {NgaySinh:dd/MM/yyyy} | Lớp: {MaLop} | ĐTB: {DiemTrungBinh:0.0} | Xếp loại: {XepLoai()}";
        }

        public override string ToString()
        {
            return LayThongTin();
        }
    }
}
