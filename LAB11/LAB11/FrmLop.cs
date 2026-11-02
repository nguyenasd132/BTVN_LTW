using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace LAB11
{
    public partial class FrmLop : Form
    {
        private readonly string connectionString =
            @"Data Source=.\SQLEXPRESS;Initial Catalog=EduManagerDB;Integrated Security=True;TrustServerCertificate=True";

        public FrmLop()
        {
            InitializeComponent();
        }

        private void FrmLop_Load(object sender, EventArgs e)
        {
            LoadComboBoxKhoa();
            LoadData();
        }

        private void LoadComboBoxKhoa()
        {
            try
            {
                string sql = "SELECT MaKhoa, TenKhoa FROM KHOA";

                using SqlConnection conn = new SqlConnection(connectionString);
                using SqlCommand cmd = new SqlCommand(sql, conn);
                using SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);

                cboKhoa.DataSource = dt;
                cboKhoa.DisplayMember = "TenKhoa"; // Hiển thị tên khoa trên ComboBox
                cboKhoa.ValueMember = "MaKhoa";     // Lấy giá trị ngầm là Mã khoa
                cboKhoa.SelectedIndex = -1;       // Chưa chọn mặc định
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách Khoa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadData()
        {
            try
            {
                string sql = @"SELECT l.MaLop, l.TenLop, l.MaKhoa, k.TenKhoa,
                                      COUNT(sv.MaSV) AS SoSinhVien 
                               FROM LOP l 
                               LEFT JOIN KHOA k ON l.MaKhoa = k.MaKhoa
                               LEFT JOIN SINHVIEN sv ON l.MaLop = sv.MaLop 
                               GROUP BY l.MaLop, l.TenLop, l.MaKhoa, k.TenKhoa 
                               ORDER BY l.MaLop";

                using SqlConnection conn = new SqlConnection(connectionString);
                using SqlCommand cmd = new SqlCommand(sql, conn);
                using SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvLop.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load dữ liệu: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtMaLop.Text))
            {
                MessageBox.Show("Vui lòng nhập mã lớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaLop.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTenLop.Text))
            {
                MessageBox.Show("Vui lòng nhập tên lớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenLop.Focus();
                return false;
            }

            if (cboKhoa.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn Khoa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboKhoa.Focus();
                return false;
            }

            return true;
        }

        private bool IsMaLopExists(string maLop)
        {
            string sql = "SELECT COUNT(*) FROM LOP WHERE MaLop = @ma";

            using SqlConnection conn = new SqlConnection(connectionString);
            using SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@ma", maLop);

            conn.Open();
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            return count > 0;
        }

        private int CountSinhVienByLop(string maLop)
        {
            string sql = "SELECT COUNT(*) FROM SINHVIEN WHERE MaLop = @ma";

            using SqlConnection conn = new SqlConnection(connectionString);
            using SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@ma", maLop);

            conn.Open();
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            string ma = txtMaLop.Text.Trim();
            string ten = txtTenLop.Text.Trim();
            string maKhoa = cboKhoa.SelectedValue.ToString();

            try
            {
                if (IsMaLopExists(ma))
                {
                    MessageBox.Show("Mã lớp đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string sql = "INSERT INTO LOP(MaLop, TenLop, MaKhoa) VALUES(@ma, @ten, @maKhoa)";

                using SqlConnection conn = new SqlConnection(connectionString);
                using SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ma", ma);
                cmd.Parameters.AddWithValue("@ten", ten);
                cmd.Parameters.AddWithValue("@maKhoa", maKhoa);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    MessageBox.Show("Thêm lớp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    ClearInput();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm lớp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            string ma = txtMaLop.Text.Trim();
            string ten = txtTenLop.Text.Trim();
            string maKhoa = cboKhoa.SelectedValue.ToString();

            try
            {
                string sql = "UPDATE LOP SET TenLop = @ten, MaKhoa = @maKhoa WHERE MaLop = @ma";

                using SqlConnection conn = new SqlConnection(connectionString);
                using SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ma", ma);
                cmd.Parameters.AddWithValue("@ten", ten);
                cmd.Parameters.AddWithValue("@maKhoa", maKhoa);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    MessageBox.Show("Cập nhật lớp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    ClearInput();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy lớp cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string ma = txtMaLop.Text.Trim();

            if (string.IsNullOrWhiteSpace(ma))
            {
                MessageBox.Show("Vui lòng chọn lớp cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int soSinhVien = CountSinhVienByLop(ma);
                if (soSinhVien > 0)
                {
                    MessageBox.Show("Không thể xóa lớp đang có sinh viên!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult result = MessageBox.Show(
                    "Bạn có chắc muốn xóa lớp này?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.No) return;

                string sql = "DELETE FROM LOP WHERE MaLop = @ma";

                using SqlConnection conn = new SqlConnection(connectionString);
                using SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ma", ma);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    MessageBox.Show("Xóa lớp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    ClearInput();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa lớp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtTimKiem.Text.Trim();
                string sql = @"SELECT l.MaLop, l.TenLop, l.MaKhoa, k.TenKhoa,
                                      COUNT(sv.MaSV) AS SoSinhVien 
                               FROM LOP l 
                               LEFT JOIN KHOA k ON l.MaKhoa = k.MaKhoa
                               LEFT JOIN SINHVIEN sv ON l.MaLop = sv.MaLop 
                               WHERE l.MaLop LIKE @kw OR l.TenLop LIKE @kw OR k.TenKhoa LIKE @kw
                               GROUP BY l.MaLop, l.TenLop, l.MaKhoa, k.TenKhoa 
                               ORDER BY l.MaLop";

                using SqlConnection conn = new SqlConnection(connectionString);
                using SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");
                using SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvLop.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearInput();
            LoadData();
        }

        private void dgvLop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvLop.Rows[e.RowIndex];

            if (row.Cells["MaLop"].Value != DBNull.Value && row.Cells["MaLop"].Value != null)
            {
                txtMaLop.Text = row.Cells["MaLop"].Value.ToString();
                txtTenLop.Text = row.Cells["TenLop"].Value?.ToString() ?? "";

                // Chọn Khoa tương ứng trong ComboBox
                if (row.Cells["MaKhoa"].Value != DBNull.Value && row.Cells["MaKhoa"].Value != null)
                {
                    cboKhoa.SelectedValue = row.Cells["MaKhoa"].Value.ToString();
                }

                txtMaLop.ReadOnly = true;
            }
        }

        private void ClearInput()
        {
            txtMaLop.Clear();
            txtTenLop.Clear();
            txtTimKiem.Clear();
            cboKhoa.SelectedIndex = -1; // Reset ComboBox

            txtMaLop.ReadOnly = false;
            txtMaLop.Focus();
        }
    }
}