using System;

namespace LAB03
{
    /// <summary>
    /// Lớp cơ sở (Base Class) đại diện cho thông tin con người nói chung.
    /// </summary>
    public class Nguoi
    {
        public string HoTen { get; set; } = string.Empty;
        public DateTime NgaySinh { get; set; } = DateTime.MinValue;

        public Nguoi()
        {
        }

        public Nguoi(string hoTen, DateTime ngaySinh)
        {
            HoTen = hoTen;
            NgaySinh = ngaySinh;
        }

        /// <summary>
        /// Phương thức ảo có thể được các lớp con ghi đè (override) để bổ sung thông tin.
        /// </summary>
        public virtual string LayThongTin()
        {
            return $"Họ tên: {HoTen} | Ngày sinh: {NgaySinh:dd/MM/yyyy}";
        }
    }
}
