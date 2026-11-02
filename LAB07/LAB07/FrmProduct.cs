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
    public partial class FrmProduct : Form, IQuanLy
    {
        // 1. Sử dụng BindingList chứa Class Model để quản lý dữ liệu trong bộ nhớ
        private BindingList<Product> danhSachSP = new BindingList<Product>();

        public FrmProduct()
        {
            InitializeComponent();
        }

        private void FrmProduct_Load(object sender, EventArgs e)
        {
            // Liên kết danh sách với DataGridView
            dgvProduct.DataSource = danhSachSP;

            // Đổi tên cột cho rõ ràng (Tiêu chí: Giao diện rõ ràng)
            dgvProduct.Columns["MaSP"].HeaderText = "Mã SP";
            dgvProduct.Columns["TenSP"].HeaderText = "Tên SP";
            dgvProduct.Columns["LoaiSP"].HeaderText = "Loại SP";
            dgvProduct.Columns["DonGia"].HeaderText = "Đơn giá";
            dgvProduct.Columns["SoLuong"].HeaderText = "Số lượng";
            dgvProduct.Columns["DonGia"].DefaultCellStyle.Format = "N0";

            Random rand = new Random();
            string[] dsLoai = { "Laptop", "Phụ kiện", "Màn hình", "Linh kiện" };
            string[] dsTen = { "Dell XPS", "Chuột Logitech", "Màn hình LG", "Bàn phím cơ", "Tai nghe Sony", "Ổ cứng SSD", "RAM Corsair", "Card đồ họa", "Cáp HDMI", "Loa Bluetooth" };

            for (int i = 1; i <= 20; i++)
            {
                // Random dữ liệu
                string loaiNgauNhien = dsLoai[rand.Next(dsLoai.Length)];
                string tenNgauNhien = dsTen[rand.Next(dsTen.Length)] + " Gen " + rand.Next(1, 10);
                decimal giaNgauNhien = (decimal)(rand.Next(5, 500) * 100000); // Giá ngẫu nhiên từ 500k đến 50 triệu
                int slNgauNhien = rand.Next(5, 100); // Số lượng ngẫu nhiên từ 5 đến 100

                // Format mã SP có số 0 ở đầu (SP01, SP02... SP20)
                string maSP = "SP" + i.ToString("D2");

                danhSachSP.Add(new Product
                {
                    MaSP = maSP,
                    TenSP = tenNgauNhien,
                    LoaiSP = loaiNgauNhien,
                    DonGia = giaNgauNhien,
                    SoLuong = slNgauNhien
                });
            }
        }

        // 2. Chức năng THÊM và CÁC ĐIỀU KIỆN VALIDATION
        private void btnThem_Click(object sender, EventArgs e)
        {
            // Validation: Kiểm tra rỗng
            if (string.IsNullOrWhiteSpace(txtMaSP.Text) || string.IsNullOrWhiteSpace(txtTenSP.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ Mã và Tên sản phẩm!");
                return;
            }

            // Validation: Kiểm tra trùng mã (Mục 7.3)
            if (danhSachSP.Any(sp => sp.MaSP == txtMaSP.Text.Trim()))
            {
                MessageBox.Show("Mã sản phẩm đã tồn tại! Vui lòng nhập mã khác.");
                return;
            }

            // Validation: Kiểm tra đơn giá và số lượng âm (Mục 7.3)
            if (!decimal.TryParse(txtDonGia.Text, out decimal donGia) || donGia < 0)
            {
                MessageBox.Show("Đơn giá phải là số và không được âm!");
                return;
            }

            int soLuong = (int)numericUpDown2.Value;
            if (soLuong < 0)
            {
                MessageBox.Show("Số lượng không được âm!");
                return;
            }
            // Thêm Model vào List
            Product spMoi = new Product
            {
                MaSP = txtMaSP.Text.Trim(),
                TenSP = txtTenSP.Text.Trim(),
                LoaiSP = cboLoaiSP.Text,
                DonGia = donGia,
                SoLuong = soLuong
            };
            danhSachSP.Add(spMoi);

            MessageBox.Show("Thêm thành công!");
            btnLamMoi_Click(null, null);
        }

        // 3. Chức năng XÓA CÓ XÁC NHẬN (Mục 7.3)
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvProduct.CurrentRow != null)
            {
                // Hỏi xác nhận trước khi xóa
                if (MessageBox.Show("Bạn có chắc muốn xóa sản phẩm này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Product spCanXoa = (Product)dgvProduct.CurrentRow.DataBoundItem;
                    danhSachSP.Remove(spCanXoa);
                }
            }
        }

        // 4. Chức năng SỬA
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvProduct.CurrentRow != null)
            {
                Product sp = (Product)dgvProduct.CurrentRow.DataBoundItem;

                // Cập nhật lại giá trị (Chỉ sửa các trường khác Mã)
                sp.TenSP = txtTenSP.Text.Trim();
                sp.LoaiSP = cboLoaiSP.Text;
                sp.SoLuong = (int)numericUpDown2.Value;
                if (decimal.TryParse(txtDonGia.Text, out decimal dg) && dg >= 0) sp.DonGia = dg;

                dgvProduct.Refresh(); // Làm mới DataGridView
                MessageBox.Show("Sửa thành công!");
            }
        }

        // 5. Chức năng LÀM MỚI
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaSP.Clear();
            txtTenSP.Clear();
            txtDonGia.Clear();
            numericUpDown2.Value = 0; 
            txtMaSP.Focus();
        }


        public void Them()
        {
            // Kiểm tra rỗng
            if (string.IsNullOrWhiteSpace(txtMaSP.Text) || string.IsNullOrWhiteSpace(txtTenSP.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ Mã và Tên sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra trùng mã
            if (danhSachSP.Any(sp => sp.MaSP.Equals(txtMaSP.Text.Trim(), StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Mã sản phẩm đã tồn tại! Vui lòng nhập mã khác.", "Trùng mã", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra đơn giá
            if (!decimal.TryParse(txtDonGia.Text, out decimal donGia) || donGia < 0)
            {
                MessageBox.Show("Đơn giá phải là số và không được âm!", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra số lượng
            int soLuong = (int)numericUpDown2.Value;
            if (soLuong < 0)
            {
                MessageBox.Show("Số lượng không được âm!");
                return;
            }

            // Thêm vào danh sách gốc
            Product spMoi = new Product
            {
                MaSP = txtMaSP.Text.Trim(),
                TenSP = txtTenSP.Text.Trim(),
                LoaiSP = cboLoaiSP.Text,
                DonGia = donGia,
                SoLuong = soLuong
            };
            danhSachSP.Add(spMoi);

            MessageBox.Show("Thêm sản phẩm thành công!");
            LamMoi(); // Gọi làm mới để reset ô nhập và hiển thị lại toàn bộ bảng
        }

        // 2. HÀM SỬA
        public void Sua()
        {
            if (dgvProduct.CurrentRow != null)
            {
                // Lấy đối tượng đang được chọn trên lưới
                Product sp = (Product)dgvProduct.CurrentRow.DataBoundItem;

                // Cập nhật giá trị
                sp.TenSP = txtTenSP.Text.Trim();
                sp.LoaiSP = cboLoaiSP.Text;
                sp.SoLuong = (int)numericUpDown2.Value;

                if (decimal.TryParse(txtDonGia.Text, out decimal dg) && dg >= 0)
                {
                    sp.DonGia = dg;
                }

                dgvProduct.Refresh(); // Làm mới giao diện bảng
                MessageBox.Show("Cập nhật sản phẩm thành công!");

                // Khôi phục lại hiển thị toàn bộ danh sách (nếu đang ở chế độ tìm kiếm)
                dgvProduct.DataSource = danhSachSP;
            }
        }

        // 3. HÀM XÓA
        public void Xoa()
        {
            if (dgvProduct.CurrentRow != null)
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Product spCanXoa = (Product)dgvProduct.CurrentRow.DataBoundItem;

                    // Xóa khỏi danh sách gốc
                    danhSachSP.Remove(spCanXoa);

                    // Cập nhật lại DataSource để hiển thị đúng
                    dgvProduct.DataSource = danhSachSP;
                    LamMoi();
                }
            }
        }

        // 4. HÀM LÀM MỚI
        public void LamMoi()
        {
            txtMaSP.Clear();
            txtTenSP.Clear();
            txtDonGia.Clear();
            numericUpDown2.Value = 0;
            if (cboLoaiSP.Items.Count > 0) cboLoaiSP.SelectedIndex = 0;

            txtMaSP.Focus();

            // Hủy chế độ tìm kiếm, gán lại danh sách gốc cho bảng
            dgvProduct.DataSource = danhSachSP;
        }

        // 5. HÀM TÌM KIẾM 
        public void TimKiem()
        {
            string maCanTim = txtMaSP.Text.Trim().ToLower();
            string tenCanTim = txtTenSP.Text.Trim().ToLower();

            // Dùng LINQ tìm các sản phẩm chứa Mã HOẶC chứa Tên
            var ketQua = danhSachSP.Where(sp =>
                (string.IsNullOrEmpty(maCanTim) || sp.MaSP.ToLower().Contains(maCanTim)) &&
                (string.IsNullOrEmpty(tenCanTim) || sp.TenSP.ToLower().Contains(tenCanTim))
            ).ToList();

            if (ketQua.Count == 0)
            {
                MessageBox.Show("Không tìm thấy sản phẩm nào khớp với thông tin!", "Kết quả tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Hiển thị danh sách kết quả lên lưới (Tạo BindingList tạm thời)
            dgvProduct.DataSource = new BindingList<Product>(ketQua);
        }
    }
}