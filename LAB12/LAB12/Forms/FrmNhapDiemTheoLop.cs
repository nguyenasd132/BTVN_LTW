using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LAB12.DAL;
namespace LAB12
{
    public partial class FrmNhapDiemTheoLop : Form
    {
        private readonly KetQuaDAL ketQuaDAL = new KetQuaDAL();
        private BindingSource bindingSource = new BindingSource();

        public FrmNhapDiemTheoLop()
        {
            InitializeComponent();
        }

        private void FrmNhapDiemTheoLop_Load(object sender, EventArgs e)
        {
            LoadComboBoxData();
            SetupDataGridView();
            UpdateStatus("Sẵn sàng.", false);
        }

        private void LoadComboBoxData()
        {
            try
            {
                // Binding ComboBox Lớp
                DataTable dtLop = ketQuaDAL.GetAllLop();
                cboLop.DataSource = dtLop;
                cboLop.DisplayMember = "TenLop";
                cboLop.ValueMember = "MaLop";

                // Binding ComboBox Môn học
                DataTable dtMon = ketQuaDAL.GetAllMonHoc();
                cboMonHoc.DataSource = dtMon;
                cboMonHoc.DisplayMember = "TenMon";
                cboMonHoc.ValueMember = "MaMon";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh mục: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupDataGridView()
        {
            dgvKetQua.AutoGenerateColumns = false;
            dgvKetQua.Columns.Clear();

            // Cột MaSV
            DataGridViewTextBoxColumn colMaSV = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MaSV",
                HeaderText = "Mã Sinh Viên",
                Name = "MaSV",
                ReadOnly = true,
                Width = 120
            };
            dgvKetQua.Columns.Add(colMaSV);

            // Cột HoTen
            DataGridViewTextBoxColumn colHoTen = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "HoTen",
                HeaderText = "Họ và Tên",
                Name = "HoTen",
                ReadOnly = true,
                Width = 200
            };
            dgvKetQua.Columns.Add(colHoTen);

            // Cột Diem (Cho phép sửa)
            DataGridViewTextBoxColumn colDiem = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Diem",
                HeaderText = "Điểm",
                Name = "Diem",
                ReadOnly = false,
                Width = 90
            };
            dgvKetQua.Columns.Add(colDiem);

            // Cột GhiChu (Cho phép sửa)
            DataGridViewTextBoxColumn colGhiChu = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "GhiChu",
                HeaderText = "Ghi Chú",
                Name = "GhiChu",
                ReadOnly = false,
                Width = 220
            };
            dgvKetQua.Columns.Add(colGhiChu);
        }

        private void btnTaiDanhSach_Click(object sender, EventArgs e)
        {
            if (cboLop.SelectedValue == null || cboMonHoc.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn lớp và môn học!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maLop = cboLop.SelectedValue.ToString();
            string maMon = cboMonHoc.SelectedValue.ToString();

            try
            {
                DataTable dt = ketQuaDAL.GetKetQuaByLopMon(maLop, maMon);
                bindingSource.DataSource = dt;
                dgvKetQua.DataSource = bindingSource;

                UpdateStatus($"Đã tải {dt.Rows.Count} sinh viên cho lớp '{cboLop.Text}' môn '{cboMonHoc.Text}'.", false);
            }
            catch (Exception ex)
            {
                UpdateStatus("Lỗi tải danh sách: " + ex.Message, true);
            }
        }

        private void btnLuuTatCa_Click(object sender, EventArgs e)
        {
            // Kết thúc chỉnh sửa cell hiện tại trên DataGridView
            dgvKetQua.EndEdit();
            bindingSource.EndEdit();

            DataTable dtKetQua = bindingSource.DataSource as DataTable;

            if (dtKetQua == null || dtKetQua.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để lưu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string maMon = cboMonHoc.SelectedValue.ToString();

            // Gọi DAL thực thi lưu kèm Transaction
            var result = ketQuaDAL.SaveAllKetQua(maMon, dtKetQua);

            if (result.IsSuccess)
            {
                UpdateStatus(result.Message, false);
                MessageBox.Show(result.Message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnTaiDanhSach.PerformClick(); // Load lại dữ liệu mới nhất
            }
            else
            {
                UpdateStatus(result.Message, true);
                MessageBox.Show(result.Message, "Thao tác thất bại (Rollback)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateStatus(string message, bool isError)
        {
            lblTrangThai.Text = message;
            lblTrangThai.ForeColor = isError ? Color.Red : Color.DarkGreen;
        }
    }
}
