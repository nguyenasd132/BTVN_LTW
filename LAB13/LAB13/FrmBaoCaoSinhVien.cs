using StudentReportDemo.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StudentReportDemo.Forms
{
    public partial class FrmBaoCaoSinhVien : Form
    {
        private List<SinhVien> danhSachSinhVien = new List<SinhVien>();
        private List<object> duLieuDangHienThi = new List<object>();

        public FrmBaoCaoSinhVien()
        {
            InitializeComponent();
        }

        private void FrmBaoCaoSinhVien_Load(object sender, EventArgs e)
        {
            TaoDuLieuMau();
            LoadComboBox();
            XemBaoCao();
        }

        private void TaoDuLieuMau()
        {
            danhSachSinhVien = new List<SinhVien>
            {
                new SinhVien { MaSV = "SV001", HoTen = "Nguyễn Văn An", MaLop = "CTK47A", TenLop = "CNTT K47A", Diem = 8.2 },
                new SinhVien { MaSV = "SV002", HoTen = "Trần Thị Bình", MaLop = "CTK47A", TenLop = "CNTT K47A", Diem = 6.5 },
                new SinhVien { MaSV = "SV003", HoTen = "Lê Minh Cường", MaLop = "CTK47A", TenLop = "CNTT K47A", Diem = 4.8 },
                new SinhVien { MaSV = "SV004", HoTen = "Phạm Thanh Dung", MaLop = "CTK47A", TenLop = "CNTT K47A", Diem = 9.1 },
                new SinhVien { MaSV = "SV005", HoTen = "Hoàng Quốc Huy", MaLop = "CTK47B", TenLop = "CNTT K47B", Diem = 7.4 },
                new SinhVien { MaSV = "SV006", HoTen = "Võ Gia Khang", MaLop = "CTK47B", TenLop = "CNTT K47B", Diem = 3.9 },
                new SinhVien { MaSV = "SV007", HoTen = "Đặng Minh Khôi", MaLop = "CTK47B", TenLop = "CNTT K47B", Diem = 5.5 },
                new SinhVien { MaSV = "SV008", HoTen = "Bùi Thảo Linh", MaLop = "CTK47B", TenLop = "CNTT K47B", Diem = 8.0 },
                new SinhVien { MaSV = "SV009", HoTen = "Ngô Tuấn Minh", MaLop = "CTK48A", TenLop = "CNTT K48A", Diem = 6.0 },
                new SinhVien { MaSV = "SV010", HoTen = "Đỗ Bảo Ngọc", MaLop = "CTK48A", TenLop = "CNTT K48A", Diem = 9.3 },
                new SinhVien { MaSV = "SV011", HoTen = "Huỳnh Gia Phúc", MaLop = "CTK48A", TenLop = "CNTT K48A", Diem = 4.2 },
                new SinhVien { MaSV = "SV012", HoTen = "Mai Anh Thư", MaLop = "CTK48A", TenLop = "CNTT K48A", Diem = 7.8 }
            };
        }

        private void LoadComboBox()
        {
            var dsLop = danhSachSinhVien
                .Select(sv => new { sv.MaLop, sv.TenLop })
                .Distinct()
                .OrderBy(lop => lop.MaLop)
                .ToList();

            cboLop.DisplayMember = "TenLop";
            cboLop.ValueMember = "MaLop";
            cboLop.DataSource = dsLop;

            cboKetQua.Items.Clear();
            cboKetQua.Items.Add("Tất cả");
            cboKetQua.Items.Add("Đạt");
            cboKetQua.Items.Add("Không đạt");
            cboKetQua.SelectedIndex = 0;
        }

        private void XemBaoCao()
        {
            if (cboLop.SelectedValue == null) return;

            string maLop = cboLop.SelectedValue.ToString();
            string ketQua = cboKetQua.SelectedItem?.ToString() ?? "Tất cả";
            string tuKhoa = txtTuKhoa.Text.Trim().ToLower();

            var query = danhSachSinhVien.Where(sv => sv.MaLop == maLop);

            if (ketQua == "Đạt")
            {
                query = query.Where(sv => sv.Diem >= 5);
            }
            else if (ketQua == "Không đạt")
            {
                query = query.Where(sv => sv.Diem < 5);
            }

            if (!string.IsNullOrWhiteSpace(tuKhoa))
            {
                query = query.Where(sv =>
                    sv.MaSV.ToLower().Contains(tuKhoa) ||
                    sv.HoTen.ToLower().Contains(tuKhoa));
            }

            var baoCao = query
                .OrderByDescending(sv => sv.Diem)
                .ThenBy(sv => sv.HoTen)
                .Select(sv => new
                {
                    sv.MaSV,
                    sv.HoTen,
                    sv.TenLop,
                    sv.Diem,
                    sv.KetQua
                })
                .ToList();

            dgvBaoCao.DataSource = baoCao;
            duLieuDangHienThi = baoCao.Cast<object>().ToList();

            CapNhatThongKe(baoCao.Count);

            if (baoCao.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu phù hợp.");
            }
        }

        private void CapNhatThongKe(int soDongHienThi)
        {
            string maLop = cboLop.SelectedValue?.ToString() ?? "";
            var dsLop = danhSachSinhVien
                .Where(sv => sv.MaLop == maLop)
                .ToList();

            int tongSo = dsLop.Count;
            int soDat = dsLop.Count(sv => sv.Diem >= 5);
            int soKhongDat = dsLop.Count(sv => sv.Diem < 5);
            double diemTB = tongSo > 0 ? dsLop.Average(sv => sv.Diem) : 0;

            lblThongKe.Text = $"Đang hiển thị: {soDongHienThi} | " +
                              $"Tổng lớp: {tongSo} | Đạt: {soDat} | " +
                              $"Không đạt: {soKhongDat} | ĐTB: {diemTB:0.00}";
        }

        private void btnXemBaoCao_Click(object sender, EventArgs e)
        {
            XemBaoCao();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            var thongKe = danhSachSinhVien
                .GroupBy(sv => new { sv.MaLop, sv.TenLop })
                .Select(g => new
                {
                    g.Key.MaLop,
                    g.Key.TenLop,
                    SoLuong = g.Count(),
                    SoDat = g.Count(sv => sv.Diem >= 5),
                    SoKhongDat = g.Count(sv => sv.Diem < 5),
                    DiemTrungBinh = Math.Round(g.Average(sv => sv.Diem), 2)
                })
                .OrderBy(x => x.MaLop)
                .ToList();

            dgvBaoCao.DataSource = thongKe;
            duLieuDangHienThi = thongKe.Cast<object>().ToList();
            lblThongKe.Text = "Thống kê theo lớp";
        }

        private void btnXuatFile_Click(object sender, EventArgs e)
        {
            if (dgvBaoCao.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất.");
                return;
            }

            using SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV file (*.csv)|*.csv|Text file (*.txt)|*.txt";
            sfd.FileName = "BaoCaoSinhVien.csv";

            if (sfd.ShowDialog() != DialogResult.OK) return;

            try
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < dgvBaoCao.Columns.Count; i++)
                {
                    sb.Append(dgvBaoCao.Columns[i].HeaderText);
                    if (i < dgvBaoCao.Columns.Count - 1) sb.Append(",");
                }
                sb.AppendLine();

                foreach (DataGridViewRow row in dgvBaoCao.Rows)
                {
                    if (row.IsNewRow) continue;
                    for (int i = 0; i < dgvBaoCao.Columns.Count; i++)
                    {
                        string value = row.Cells[i].Value?.ToString() ?? "";
                        value = value.Replace(",", " ");
                        sb.Append(value);
                        if (i < dgvBaoCao.Columns.Count - 1) sb.Append(",");
                    }
                    sb.AppendLine();
                }

                File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                MessageBox.Show("Xuất file thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất file: " + ex.Message);
            }
        }

        private void cboLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLop.SelectedValue != null)
            {
                XemBaoCao();
            }
        }

        private void cboKetQua_SelectedIndexChanged(object sender, EventArgs e)
        {
            XemBaoCao();
        }

        private void txtTuKhoa_TextChanged(object sender, EventArgs e)
        {
            XemBaoCao();
        }
    }
}