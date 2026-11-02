using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB07
{
    // 1. THÊM ", IQuanLy" VÀO ĐÂY ĐỂ FRMMAIN NHẬN DIỆN ĐƯỢC
    public partial class FrmCustomer : Form, IQuanLy
    {
        private BindingList<Customer> danhSachKH = new BindingList<Customer>();

        public FrmCustomer()
        {
            InitializeComponent();
        }

        private void FrmCustomer_Load(object sender, EventArgs e)
        {
            // 1. ÉP XÓA CÁC CỘT CŨ BỊ LỖI (NẾU CÓ) VÀ TỰ ĐỘNG SINH CỘT MỚI
            dgvCustomer.Columns.Clear();
            dgvCustomer.AutoGenerateColumns = true;

            // 2. NẠP DỮ LIỆU VÀO DANH SÁCH TRƯỚC
            if (danhSachKH.Count == 0) // Tránh nạp trùng nếu Load lại
            {
                danhSachKH.Add(new Customer { MaKH = "KH01", HoTen = "Nguyễn Văn An", SDT = "0901234567", LoaiKH = "VIP" });
                danhSachKH.Add(new Customer { MaKH = "KH02", HoTen = "Trần Thị Bình", SDT = "0912345678", LoaiKH = "Thành viên" });
                danhSachKH.Add(new Customer { MaKH = "KH03", HoTen = "Lê Hoàng Cường", SDT = "0987654321", LoaiKH = "Khách thường" });
                danhSachKH.Add(new Customer { MaKH = "KH04", HoTen = "Phạm Thị Dung", SDT = "0933445566", LoaiKH = "VIP" });
                danhSachKH.Add(new Customer { MaKH = "KH05", HoTen = "Hoàng Minh Tuấn", SDT = "0977889900", LoaiKH = "Thành viên" });
            }

            // 3. GẮN DANH SÁCH VÀO BẢNG SAU CÙNG
            dgvCustomer.DataSource = danhSachKH;

            // 4. ĐỔI LẠI TÊN TIÊU ĐỀ CHO ĐẸP
            if (dgvCustomer.Columns.Contains("MaKH")) dgvCustomer.Columns["MaKH"].HeaderText = "Mã KH";
            if (dgvCustomer.Columns.Contains("HoTen")) dgvCustomer.Columns["HoTen"].HeaderText = "Họ tên";
            if (dgvCustomer.Columns.Contains("SDT")) dgvCustomer.Columns["SDT"].HeaderText = "Số điện thoại";
            if (dgvCustomer.Columns.Contains("LoaiKH")) dgvCustomer.Columns["LoaiKH"].HeaderText = "Loại khách hàng";

            // Ép bảng giãn đều màn hình cho đẹp
            dgvCustomer.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // 2. ĐỔI THÀNH "public void Them()"
        public void Them()
        {
            if (string.IsNullOrWhiteSpace(txtMaKH.Text) || string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ Mã và Họ tên khách hàng!");
                return;
            }

            if (danhSachKH.Any(kh => kh.MaKH == txtMaKH.Text.Trim()))
            {
                MessageBox.Show("Mã khách hàng đã tồn tại!");
                return;
            }

            Customer khMoi = new Customer
            {
                MaKH = txtMaKH.Text.Trim(),
                HoTen = txtHoTen.Text.Trim(),
                SDT = txtSDT.Text.Trim(),
                LoaiKH = cboLoaiKH.Text
            };
            danhSachKH.Add(khMoi);

            MessageBox.Show("Thêm thành công!");
            LamMoi();
        }

        // 3. ĐỔI THÀNH "public void Xoa()"
        public void Xoa()
        {
            if (dgvCustomer.CurrentRow != null)
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa khách hàng này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Customer khCanXoa = (Customer)dgvCustomer.CurrentRow.DataBoundItem;
                    danhSachKH.Remove(khCanXoa);

                    // Gắn lại DataSource đề phòng đang ở chế độ tìm kiếm
                    dgvCustomer.DataSource = danhSachKH;
                    LamMoi();
                }
            }
        }

        // 4. ĐỔI THÀNH "public void Sua()"
        public void Sua()
        {
            if (dgvCustomer.CurrentRow != null)
            {
                Customer kh = (Customer)dgvCustomer.CurrentRow.DataBoundItem;

                kh.HoTen = txtHoTen.Text.Trim();
                kh.SDT = txtSDT.Text.Trim();
                kh.LoaiKH = cboLoaiKH.Text;

                dgvCustomer.Refresh();
                MessageBox.Show("Sửa thành công!");

                // Trả lại bảng full
                dgvCustomer.DataSource = danhSachKH;
            }
        }

        // 5. ĐỔI THÀNH "public void LamMoi()"
        public void LamMoi()
        {
            txtMaKH.Clear();
            txtHoTen.Clear();
            txtSDT.Clear();
            cboLoaiKH.SelectedIndex = -1;
            txtMaKH.Focus();

            // Xóa bộ lọc tìm kiếm, hiển thị lại toàn bộ
            dgvCustomer.DataSource = danhSachKH;
        }

        // 6. BỔ SUNG HÀM TÌM KIẾM CÒN THIẾU
        public void TimKiem()
        {
            string maCanTim = txtMaKH.Text.Trim().ToLower();
            string tenCanTim = txtHoTen.Text.Trim().ToLower();
            string sdtCanTim = txtSDT.Text.Trim().ToLower();

            // Tìm kiếm theo Mã, Tên hoặc SĐT
            var ketQua = danhSachKH.Where(kh =>
                (string.IsNullOrEmpty(maCanTim) || kh.MaKH.ToLower().Contains(maCanTim)) &&
                (string.IsNullOrEmpty(tenCanTim) || kh.HoTen.ToLower().Contains(tenCanTim)) &&
                (string.IsNullOrEmpty(sdtCanTim) || kh.SDT.ToLower().Contains(sdtCanTim))
            ).ToList();

            if (ketQua.Count == 0)
            {
                MessageBox.Show("Không tìm thấy khách hàng nào khớp với thông tin!");
            }

            // Hiển thị kết quả tìm kiếm lên DataGridView
            dgvCustomer.DataSource = new BindingList<Customer>(ketQua);
        }

        // 7. SỰ KIỆN CLICK BẢNG (Giữ nguyên)
        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCustomer.CurrentRow != null)
            {
                Customer kh = (Customer)dgvCustomer.CurrentRow.DataBoundItem;
                txtMaKH.Text = kh.MaKH;
                txtHoTen.Text = kh.HoTen;
                txtSDT.Text = kh.SDT;
                cboLoaiKH.Text = kh.LoaiKH;
            }
        }
    }
}