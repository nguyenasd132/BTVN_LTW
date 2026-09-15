namespace LTW_LAB01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            string hoTen = txtHoTen.Text.Trim();
            string namSinh = txtNamSinh.Text.Trim();
            string diaChiMail = txtEmail.Text.Trim();
            string gioiTinh = "";
            if (radNam.Checked)
            {
                gioiTinh = "Nam";
            }
            else if (radNu.Checked)
            {
                gioiTinh = "Nữ";
            }
            string khoa = cboKhoa.SelectedItem != null ? cboKhoa.SelectedItem.ToString() : "";

            // Kiểm tra rằng buộc thông tin
            if (string.IsNullOrEmpty(hoTen))
            {
                MessageBox.Show("Bạn chưa nhập họ và tên, vui lòng nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return;
            }
            if (string.IsNullOrEmpty(namSinh))
            {
                MessageBox.Show("Bạn chưa nhập năm sinh, vui lòng nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return;
            }
            int namHienTai = DateTime.Now.Year;
            if (!int.TryParse(namSinh, out int NS) || NS < 1900 || NS > namHienTai)
            {
                MessageBox.Show($"Năm sinh phải nằm trong khoảng từ 1900 đến {namHienTai}!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNamSinh.Focus();
                txtNamSinh.SelectAll();
                return;
            }
            if (string.IsNullOrEmpty(diaChiMail))
            {
                MessageBox.Show("Bạn chưa nhập địa chỉ email, vui lòng nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return;
            }
            if (string.IsNullOrEmpty(gioiTinh))
            {
                MessageBox.Show("Vui lòng chọn giới tính!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cboKhoa.SelectedIndex == -1 || cboKhoa.Text.Trim() == "Chọn khoa")
            {
                MessageBox.Show("Vui lòng chọn khoa hoặc lớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboKhoa.Focus();
                return;
            }

            string thongTin = $"Họ và tên: {hoTen}\n" +
                     $"Tuổi: {namHienTai - NS}\n" +
                     $"Email: {diaChiMail}\n" +
                     $"Giới tính: {gioiTinh}\n" +
                     $"Khoa: {khoa}";

            MessageBox.Show(thongTin, "Thông tin sinh viên", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            txtHoTen.Clear();
            txtNamSinh.Clear();
            txtEmail.Clear();

            radNam.Checked = false;
            radNu.Checked = false;

            cboKhoa.SelectedIndex = -1;

        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
