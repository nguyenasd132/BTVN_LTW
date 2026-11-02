using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Lab06ver2
{
    public partial class Form1 : Form
    {
        private BindingList<Product> _productList = new BindingList<Product>();
        private BindingSource _bindingSource = new BindingSource();
        private string _selectedImagePath = string.Empty;

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
            tsbThem.Click += tsbThem_Click;
            tsbSua.Click += tsbSua_Click;
            tsbXoa.Click += tsbXoa_Click;
            tsbLamMoi.Click += tsbLamMoi_Click;
            btnChonAnh.Click += btnChonAnh_Click;
            dgvProducts.CellClick += dgvProducts_CellClick;
        }

        #region 1. Form Load & Cấu hình khởi tạo

        private void Form1_Load(object sender, EventArgs e) 
        {
            this.Text = "Quản lý sản phẩm";

            InitComboBoxLoaiSP();

            InitDataGridView();

            LoadSampleData();

            ClearInput();
            UpdateStatus("Sẵn sàng");
        }

        private void InitComboBoxLoaiSP()
        {
            cboLoaiSP.Items.Clear();
            cboLoaiSP.Items.AddRange(new object[] {
                "Điện tử",
                "Văn phòng",
                "Gia dụng"
                "Thời trang"
            });

            cboLoaiSP.DropDownStyle = ComboBoxStyle.DropDownList;
            if (cboLoaiSP.Items.Count > 0)
                cboLoaiSP.SelectedIndex = 0;
        }

        private void InitDataGridView()
        {
            dgvProducts.ReadOnly = true;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.MultiSelect = false;
            dgvProducts.AutoGenerateColumns = true;
            dgvProducts.AllowUserToAddRows = false;

            _bindingSource.DataSource = _productList;
            dgvProducts.DataSource = _bindingSource;
        }

        private void LoadSampleData()
        {
            _productList.Add(new Product("SP01", "Chuột không dây Logitech", "Điện tử", 450000m, 25, DateTime.Today.AddDays(-15), true));
            _productList.Add(new Product("SP02", "Bút ký cao cấp Picasso", "Văn phòng", 280000m, 50, DateTime.Today.AddDays(-10), true));
            _productList.Add(new Product("SP03", "Nồi chiên không dầu Philips", "Gia dụng", 1890000m, 12, DateTime.Today.AddDays(-5), true));
            _productList.Add(new Product("SP04", "Bàn phím cơ DareU EK87", "Điện tử", 650000m, 30, DateTime.Today.AddDays(-20), true));
            _productList.Add(new Product("SP05", "Máy xay sinh tố Sunhouse", "Gia dụng", 550000m, 0, DateTime.Today.AddDays(-2), false));
        }

        #endregion

        #region Các phương thức hỗ trợ (Validation, Clear, Load, Image, Status)

        // Kiểm tra hợp lệ dữ liệu bằng ErrorProvider
        private bool ValidateInput(bool isEditing)
        {
            bool isValid = true;
            errorProvider1.Clear();

            // 1. Kiểm tra Mã sản phẩm: không rỗng, không được trùng khi thêm mới
            if (string.IsNullOrWhiteSpace(txtMaSP.Text))
            {
                errorProvider1.SetError(txtMaSP, "Mã sản phẩm không được để trống!");
                isValid = false;
            }
            else if (!isEditing)
            {
                bool isDuplicate = _productList.Any(p => p.MaSP.Trim().Equals(txtMaSP.Text.Trim(), StringComparison.OrdinalIgnoreCase));
                if (isDuplicate)
                {
                    errorProvider1.SetError(txtMaSP, "Mã sản phẩm đã tồn tại trong danh sách!");
                    isValid = false;
                }
            }

            // 2. Kiểm tra Tên sản phẩm: không rỗng
            if (string.IsNullOrWhiteSpace(txtTenSP.Text))
            {
                errorProvider1.SetError(txtTenSP, "Tên sản phẩm không được để trống!");
                isValid = false;
            }

            // 3. Kiểm tra Loại sản phẩm: bắt buộc phải chọn
            if (cboLoaiSP.SelectedIndex < 0)
            {
                errorProvider1.SetError(cboLoaiSP, "Vui lòng chọn loại sản phẩm!");
                isValid = false;
            }

            // 4. Kiểm tra Đơn giá: lớn hơn 0
            if (numDonGia.Value <= 0)
            {
                errorProvider1.SetError(numDonGia, "Đơn giá phải lớn hơn 0!");
                isValid = false;
            }

            // 5. Kiểm tra Số lượng: lớn hơn hoặc bằng 0
            if (numSoLuong.Value < 0)
            {
                errorProvider1.SetError(numSoLuong, "Số lượng không được âm!");
                isValid = false;
            }

            // 6. Kiểm tra Ngày nhập: không được vượt quá ngày hiện tại
            if (dtpNgayNhap.Value.Date > DateTime.Today)
            {
                errorProvider1.SetError(dtpNgayNhap, "Ngày nhập không được lớn hơn ngày hiện tại!");
                isValid = false;
            }

            return isValid;
        }

        private void ClearInput()
        {
            txtMaSP.Clear();
            txtTenSP.Clear();
            if (cboLoaiSP.Items.Count > 0)
                cboLoaiSP.SelectedIndex = 0;
            numDonGia.Value = 0;
            numSoLuong.Value = 0;
            dtpNgayNhap.Value = DateTime.Today;
            chkConKinhDoanh.Checked = true;

            _selectedImagePath = string.Empty;
            if (picHinhAnh.Image != null)
            {
                picHinhAnh.Image.Dispose();
                picHinhAnh.Image = null;
            }

            txtMaSP.Enabled = true;
            errorProvider1.Clear();
            txtMaSP.Focus();
        }

        // Đổ dữ liệu từ một đối tượng Product lên các control trong GroupBox
        private void LoadProductToForm(Product p)
        {
            if (p == null) return;

            txtMaSP.Text = p.MaSP;
            txtTenSP.Text = p.TenSP;
            cboLoaiSP.SelectedItem = p.LoaiSP;
            numDonGia.Value = p.DonGia;
            numSoLuong.Value = p.SoLuong;
            dtpNgayNhap.Value = p.NgayNhap;
            chkConKinhDoanh.Checked = p.ConKinhDoanh;

            _selectedImagePath = p.DuongDanAnh;
            DisplayImage(_selectedImagePath);

            txtMaSP.Enabled = false; // Khóa mã sản phẩm khi đang chỉnh sửa
            errorProvider1.Clear();
        }

        // Đọc ảnh qua Stream để giải phóng tài nguyên, tránh khóa file
        private void DisplayImage(string path)
        {
            if (picHinhAnh.Image != null)
            {
                picHinhAnh.Image.Dispose();
                picHinhAnh.Image = null;
            }

            if (!string.IsNullOrEmpty(path) && File.Exists(path))
            {
                try
                {
                    using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                    {
                        picHinhAnh.Image = Image.FromStream(fs);
                    }
                }
                catch
                {
                    picHinhAnh.Image = null;
                }
            }
        }

        // Cập nhật trạng thái và tổng số lượng sản phẩm lên StatusStrip
        private void UpdateStatus(string message)
        {
            lblStatus.Text = $"Trạng thái: {message}";
            lblCount.Text = $"Tổng số sản phẩm: {_productList.Count}";
        }

        // Lấy sản phẩm đang chọn trên dòng hiện tại của DataGridView
        private Product GetCurrentSelectedProduct()
        {
            if (dgvProducts.CurrentRow != null && dgvProducts.CurrentRow.DataBoundItem is Product p)
            {
                return p;
            }
            return null;
        }

        #endregion

        #region Các thao tác CRUD & Nút chức năng

        // Thêm sản phẩm (ToolStrip / Menu)
        private void tsbThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput(isEditing: false)) return;

            var newProduct = new Product(
                txtMaSP.Text.Trim(),
                txtTenSP.Text.Trim(),
                cboLoaiSP.SelectedItem.ToString(),
                numDonGia.Value,
                (int)numSoLuong.Value,
                dtpNgayNhap.Value.Date,
                chkConKinhDoanh.Checked,
                _selectedImagePath
            );

            _productList.Add(newProduct);
            ClearInput();
            UpdateStatus($"Thêm thành công sản phẩm [{newProduct.MaSP}]");
        }

        // Sửa sản phẩm (ToolStrip / ContextMenuStrip)
        private void tsbSua_Click(object sender, EventArgs e)
        {
            var currentProduct = GetCurrentSelectedProduct();
            if (currentProduct == null)
            {
                MessageBox.Show("Vui lòng chọn một dòng sản phẩm từ bảng để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInput(isEditing: true)) return;

            currentProduct.TenSP = txtTenSP.Text.Trim();
            currentProduct.LoaiSP = cboLoaiSP.SelectedItem.ToString();
            currentProduct.DonGia = numDonGia.Value;
            currentProduct.SoLuong = (int)numSoLuong.Value;
            currentProduct.NgayNhap = dtpNgayNhap.Value.Date;
            currentProduct.ConKinhDoanh = chkConKinhDoanh.Checked;
            currentProduct.DuongDanAnh = _selectedImagePath;

            _bindingSource.ResetBindings(false);
            ClearInput();
            UpdateStatus($"Cập nhật thành công sản phẩm [{currentProduct.MaSP}]");
        }

        // Xóa sản phẩm (ToolStrip / ContextMenuStrip)
        private void tsbXoa_Click(object sender, EventArgs e)
        {
            var currentProduct = GetCurrentSelectedProduct();
            if (currentProduct == null)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa từ bảng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var dialog = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa sản phẩm [{currentProduct.MaSP} - {currentProduct.TenSP}] không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (dialog == DialogResult.Yes)
            {
                string id = currentProduct.MaSP;
                _productList.Remove(currentProduct);
                ClearInput();
                UpdateStatus($"Đã xóa sản phẩm [{id}]");
            }
        }

        // Làm mới (ToolStrip / Menu)
        private void tsbLamMoi_Click(object sender, EventArgs e)
        {
            ClearInput();
            tstxtTimKiem.Clear();

            _bindingSource.DataSource = _productList;
            _bindingSource.ResetBindings(false);
            UpdateStatus("Đã làm mới danh sách");
        }

        // Chọn ảnh sản phẩm bằng OpenFileDialog (trong GroupBox)
        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Chọn ảnh sản phẩm";
            openFileDialog1.Filter = "File ảnh (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                _selectedImagePath = openFileDialog1.FileName;
                DisplayImage(_selectedImagePath);
                UpdateStatus("Đã chọn ảnh sản phẩm");
            }
        }

        // Chọn dòng trên DataGridView
        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedProduct = GetCurrentSelectedProduct();
                if (selectedProduct != null)
                {
                    LoadProductToForm(selectedProduct);
                    UpdateStatus($"Đang xem sản phẩm [{selectedProduct.MaSP}]");
                }
            }
        }

        // Tìm kiếm theo Mã hoặc Tên sản phẩm trên ToolStrip
        private void tsbTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = tstxtTimKiem.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                _bindingSource.DataSource = _productList;
                UpdateStatus("Hiển thị toàn bộ sản phẩm");
                return;
            }

            var results = _productList
                .Where(p => p.MaSP.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0 ||
                            p.TenSP.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();

            _bindingSource.DataSource = new BindingList<Product>(results);
            lblStatus.Text = $"Trạng thái: Tìm thấy {results.Count} kết quả";
            lblCount.Text = $"Tổng số sản phẩm: {_productList.Count}";
        }

        #endregion

        #region ContextMenuStrip & MenuStrip

        // Xem chi tiết qua chuột phải trên DataGridView
        private void ctxMenuXemChiTiet_Click(object sender, EventArgs e)
        {
            var p = GetCurrentSelectedProduct();
            if (p != null)
            {
                string info = $"Mã sản phẩm: {p.MaSP}\n" +
                              $"Tên sản phẩm: {p.TenSP}\n" +
                              $"Loại sản phẩm: {p.LoaiSP}\n" +
                              $"Đơn giá: {p.DonGia:N0} VNĐ\n" +
                              $"Số lượng tồn: {p.SoLuong}\n" +
                              $"Ngày nhập kho: {p.NgayNhap:dd/MM/yyyy}\n" +
                              $"Trạng thái: {(p.ConKinhDoanh ? "Đang kinh doanh" : "Ngừng kinh doanh")}";

                MessageBox.Show(info, "Chi tiết sản phẩm", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng sản phẩm để xem chi tiết!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Thoát từ MenuStrip
        private void thoatasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát chương trình?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
        }

        #endregion

        #region Các sự kiện trống từ Designer tránh lỗi build

        private void toolStripStatusLabel1_Click(object sender, EventArgs e) { }
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e) { }
        private void groupBox1_Enter(object sender, EventArgs e) { }

        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            tsbThem_Click(sender, e);
        }
    }
}