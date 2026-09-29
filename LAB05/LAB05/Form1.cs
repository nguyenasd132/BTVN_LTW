namespace LAB05
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtHoTen.MaxLength = 50;
            lblKiTu.Text = "0/50";
            txtSDT.MaxLength = 10;

            cbKhoaHoc.Items.Clear();
            cbKhoaHoc.Items.Add("C# WinForms cơ bản");
            cbKhoaHoc.Items.Add("Lập trình Python cơ bản");
            cbKhoaHoc.Items.Add("SQL Server cơ bản");
            cbKhoaHoc.Items.Add("Web Frontend cơ bản");

            if (cbKhoaHoc.Items.Count > 0)
            {
                cbKhoaHoc.SelectedIndex = 0;
            }

            rbOnl.Checked = true;

            numericUpDown1.Minimum = 1;
            numericUpDown1.Maximum = 12;
            numericUpDown1.Value = 1;

            CapNhatTongHocPhi();
        }

        private decimal LayHocPhiMotThang()
        {
            string khoaHoc = cbKhoaHoc.SelectedItem?.ToString() ?? "";
            switch (khoaHoc)
            {
                case "C# WinForms cơ bản":
                    return 800000;
                case "Lập trình Python cơ bản":
                    return 650000;
                case "SQL Server cơ bản":
                    return 700000;
                case "Web Frontend cơ bản":
                    return 750000;
                default:
                    return 0;
            }
        }

        // Hàm tính tiền
        private void CapNhatTongHocPhi()
        {
            decimal tongTien = LayHocPhiMotThang() * numericUpDown1.Value;
            lblTinhTien.Text = tongTien.ToString("N0") + " VNĐ";
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            CapNhatTongHocPhi();
        }

        private void cbKhoaHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            CapNhatTongHocPhi();
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void grbKhoaHoc_Enter(object sender, EventArgs e) { }
        private void lblHinhThuc_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }

        private void txtHoTen_TextChanged(object sender, EventArgs e)
        {
            lblKiTu.Text = $"{txtHoTen.Text.Length}/50";
        }

        // Chặn nhập số vào ô Họ tên
        private void txtHoTen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Chặn không cho nhập số
            }
        }

        // Chặn nhập chữ vào ô SĐT 
        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSDT_TextChanged(object sender, EventArgs e) { }

        private void btnDangKy_Click_1(object sender, EventArgs e)
        {
            // 1. Kiểm tra họ tên
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập họ và tên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return;
            }

            if (txtHoTen.Text.Any(char.IsDigit))
            {
                MessageBox.Show("Họ và tên không được chứa số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return;
            }

            // 2. Kiểm tra số điện thoại không được rỗng
            if (string.IsNullOrWhiteSpace(txtSDT.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDT.Focus();
                return;
            }

            string sdt = txtSDT.Text.Trim();
            if (sdt.Length != 10 || !sdt.All(char.IsDigit))
            {
                MessageBox.Show("Số điện thoại không được chứa chữ và phải có đúng 10 chữ số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDT.Focus();
                return;
            }

            // 3. Kiểm tra khóa học
            if (cbKhoaHoc.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn khóa học!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbKhoaHoc.Focus();
                return;
            }

            // 4. Tính tổng học phí
            int soThang = (int)numericUpDown1.Value;
            decimal tongHocPhi = LayHocPhiMotThang() * soThang;

            string hoTen = txtHoTen.Text.Trim();
            string ngaySinh = dtpNgaySinh.Value.ToString("dd/MM/yyyy");
            string khoaHoc = cbKhoaHoc.SelectedItem?.ToString() ?? "";
            string hinhThuc = rbOnl.Checked ? "Online" : "Trực tiếp";
            string nhanEmail = ckbMail.Checked ? "Có" : "Không";

            // 5. Phiếu đăng ký
            string thongBao = "--- PHIẾU ĐĂNG KÝ KHÓA HỌC ---\n\n"
                            + $"• Họ tên: {hoTen}\n"
                            + $"• Số điện thoại: {sdt}\n"
                            + $"• Ngày sinh: {ngaySinh}\n"
                            + $"• Khóa học: {khoaHoc}\n"
                            + $"• Hình thức học: {hinhThuc}\n"
                            + $"• Số tháng đăng ký: {soThang}\n"
                            + $"• Tổng tiền: {tongHocPhi:N0} VNĐ\n"
                            + $"• Nhận thông tin qua email: {nhanEmail}";

            MessageBox.Show(thongBao, "Thông tin đăng ký thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            // Xóa trắng thông tin học viên
            txtHoTen.Clear();
            lblKiTu.Text = "0/50";
            txtSDT.Clear();
            dtpNgaySinh.Value = DateTime.Now;
            ckbMail.Checked = false;

            // Reset thông tin khóa học về mặc định
            if (cbKhoaHoc.Items.Count > 0)
            {
                cbKhoaHoc.SelectedIndex = 0;
            }
            rbOnl.Checked = true;
            numericUpDown1.Value = 1;

            // Cập nhật lại tổng tiền về mức ban đầu
            CapNhatTongHocPhi();

            // Đưa con trỏ soạn thảo về lại ô Họ tên
            txtHoTen.Focus();
        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            // Hỏi xác nhận trước khi đóng form
            DialogResult dr = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát chương trình không?",
                "Xác nhận thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (dr == DialogResult.Yes)
            {
                this.Close(); // hoặc Application.Exit();
            }
        }


    }
}