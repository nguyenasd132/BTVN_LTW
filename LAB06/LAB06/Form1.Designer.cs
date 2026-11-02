namespace Lab06ver2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mởFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lưuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thoatasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thêmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xóaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sửaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.làmMớiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trợGiúpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbThem = new System.Windows.Forms.ToolStripButton();
            this.tsbXoa = new System.Windows.Forms.ToolStripButton();
            this.tsbSua = new System.Windows.Forms.ToolStripButton();
            this.tsbLamMoi = new System.Windows.Forms.ToolStripButton();
            this.tstxtTimKiem = new System.Windows.Forms.ToolStripTextBox();
            this.tsbTimKiem = new System.Windows.Forms.ToolStripButton();
            this.grpThongTin = new System.Windows.Forms.GroupBox();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.btnChonAnh = new System.Windows.Forms.Button();
            this.picHinhAnh = new System.Windows.Forms.PictureBox();
            this.chkConKinhDoanh = new System.Windows.Forms.CheckBox();
            this.dtpNgayNhap = new System.Windows.Forms.DateTimePicker();
            this.numSoLuong = new System.Windows.Forms.NumericUpDown();
            this.numDonGia = new System.Windows.Forms.NumericUpDown();
            this.lblConKinhDoanh = new System.Windows.Forms.Label();
            this.lblNgayNhap = new System.Windows.Forms.Label();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.lblDonGia = new System.Windows.Forms.Label();
            this.lblLoaiSP = new System.Windows.Forms.Label();
            this.cboLoaiSP = new System.Windows.Forms.ComboBox();
            this.lblTenSP = new System.Windows.Forms.Label();
            this.lblMaSP = new System.Windows.Forms.Label();
            this.txtTenSP = new System.Windows.Forms.TextBox();
            this.txtMaSP = new System.Windows.Forms.TextBox();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.thêmToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.xóaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.sửaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.grpThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHinhAnh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDonGia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.quảnLýToolStripMenuItem,
            this.trợGiúpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(781, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mởFileToolStripMenuItem,
            this.lưuToolStripMenuItem,
            this.thoatasToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // mởFileToolStripMenuItem
            // 
            this.mởFileToolStripMenuItem.Name = "mởFileToolStripMenuItem";
            this.mởFileToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.mởFileToolStripMenuItem.Text = "Mở file ";
            // 
            // lưuToolStripMenuItem
            // 
            this.lưuToolStripMenuItem.Name = "lưuToolStripMenuItem";
            this.lưuToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.lưuToolStripMenuItem.Text = "Lưu";
            // 
            // thoatasToolStripMenuItem
            // 
            this.thoatasToolStripMenuItem.Name = "thoatasToolStripMenuItem";
            this.thoatasToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.thoatasToolStripMenuItem.Text = "Thoát";
            this.thoatasToolStripMenuItem.Click += new System.EventHandler(this.thoatasToolStripMenuItem_Click);
            // 
            // quảnLýToolStripMenuItem
            // 
            this.quảnLýToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thêmToolStripMenuItem,
            this.xóaToolStripMenuItem,
            this.sửaToolStripMenuItem,
            this.làmMớiToolStripMenuItem});
            this.quảnLýToolStripMenuItem.Name = "quảnLýToolStripMenuItem";
            this.quảnLýToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.quảnLýToolStripMenuItem.Text = "Quản lý";
            // 
            // thêmToolStripMenuItem
            // 
            this.thêmToolStripMenuItem.Name = "thêmToolStripMenuItem";
            this.thêmToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.thêmToolStripMenuItem.Text = "Thêm";
            // 
            // xóaToolStripMenuItem
            // 
            this.xóaToolStripMenuItem.Name = "xóaToolStripMenuItem";
            this.xóaToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.xóaToolStripMenuItem.Text = "Xóa";
            // 
            // sửaToolStripMenuItem
            // 
            this.sửaToolStripMenuItem.Name = "sửaToolStripMenuItem";
            this.sửaToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.sửaToolStripMenuItem.Text = "Sửa";
            // 
            // làmMớiToolStripMenuItem
            // 
            this.làmMớiToolStripMenuItem.Name = "làmMớiToolStripMenuItem";
            this.làmMớiToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.làmMớiToolStripMenuItem.Text = "Làm mới";
            // 
            // trợGiúpToolStripMenuItem
            // 
            this.trợGiúpToolStripMenuItem.Name = "trợGiúpToolStripMenuItem";
            this.trợGiúpToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.trợGiúpToolStripMenuItem.Text = "Trợ giúp";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbThem,
            this.tsbXoa,
            this.tsbSua,
            this.tsbLamMoi,
            this.tstxtTimKiem,
            this.tsbTimKiem});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(781, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbThem
            // 
            this.tsbThem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbThem.Image = ((System.Drawing.Image)(resources.GetObject("tsbThem.Image")));
            this.tsbThem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbThem.Name = "tsbThem";
            this.tsbThem.Size = new System.Drawing.Size(23, 22);
            this.tsbThem.Text = "toolStripButton1";
            this.tsbThem.Click += new System.EventHandler(this.tsbThem_Click);
            // 
            // tsbXoa
            // 
            this.tsbXoa.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbXoa.Image = ((System.Drawing.Image)(resources.GetObject("tsbXoa.Image")));
            this.tsbXoa.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbXoa.Name = "tsbXoa";
            this.tsbXoa.Size = new System.Drawing.Size(23, 22);
            this.tsbXoa.Text = "toolStripButton2";
            this.tsbXoa.Click += new System.EventHandler(this.tsbXoa_Click);
            // 
            // tsbSua
            // 
            this.tsbSua.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSua.Image = ((System.Drawing.Image)(resources.GetObject("tsbSua.Image")));
            this.tsbSua.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSua.Name = "tsbSua";
            this.tsbSua.Size = new System.Drawing.Size(23, 22);
            this.tsbSua.Text = "toolStripButton3";
            this.tsbSua.Click += new System.EventHandler(this.tsbSua_Click);
            // 
            // tsbLamMoi
            // 
            this.tsbLamMoi.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbLamMoi.Image = ((System.Drawing.Image)(resources.GetObject("tsbLamMoi.Image")));
            this.tsbLamMoi.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLamMoi.Name = "tsbLamMoi";
            this.tsbLamMoi.Size = new System.Drawing.Size(23, 22);
            this.tsbLamMoi.Text = "toolStripButton4";
            // 
            // tstxtTimKiem
            // 
            this.tstxtTimKiem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tstxtTimKiem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tstxtTimKiem.Name = "tstxtTimKiem";
            this.tstxtTimKiem.Size = new System.Drawing.Size(100, 25);
            // 
            // tsbTimKiem
            // 
            this.tsbTimKiem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbTimKiem.Image = ((System.Drawing.Image)(resources.GetObject("tsbTimKiem.Image")));
            this.tsbTimKiem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbTimKiem.Name = "tsbTimKiem";
            this.tsbTimKiem.Size = new System.Drawing.Size(23, 22);
            this.tsbTimKiem.Text = "toolStripButton5";
            this.tsbTimKiem.Click += new System.EventHandler(this.tsbTimKiem_Click);
            // 
            // grpThongTin
            // 
            this.grpThongTin.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.grpThongTin.Controls.Add(this.btnXacNhan);
            this.grpThongTin.Controls.Add(this.btnChonAnh);
            this.grpThongTin.Controls.Add(this.picHinhAnh);
            this.grpThongTin.Controls.Add(this.chkConKinhDoanh);
            this.grpThongTin.Controls.Add(this.dtpNgayNhap);
            this.grpThongTin.Controls.Add(this.numSoLuong);
            this.grpThongTin.Controls.Add(this.numDonGia);
            this.grpThongTin.Controls.Add(this.lblConKinhDoanh);
            this.grpThongTin.Controls.Add(this.lblNgayNhap);
            this.grpThongTin.Controls.Add(this.lblSoLuong);
            this.grpThongTin.Controls.Add(this.lblDonGia);
            this.grpThongTin.Controls.Add(this.lblLoaiSP);
            this.grpThongTin.Controls.Add(this.cboLoaiSP);
            this.grpThongTin.Controls.Add(this.lblTenSP);
            this.grpThongTin.Controls.Add(this.lblMaSP);
            this.grpThongTin.Controls.Add(this.txtTenSP);
            this.grpThongTin.Controls.Add(this.txtMaSP);
            this.grpThongTin.Location = new System.Drawing.Point(0, 52);
            this.grpThongTin.Name = "grpThongTin";
            this.grpThongTin.Size = new System.Drawing.Size(781, 116);
            this.grpThongTin.TabIndex = 2;
            this.grpThongTin.TabStop = false;
            this.grpThongTin.Text = "Nhập thông tin sản phẩm";
            this.grpThongTin.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Location = new System.Drawing.Point(682, 18);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(75, 60);
            this.btnXacNhan.TabIndex = 15;
            this.btnXacNhan.Text = "Xác nhận";
            this.btnXacNhan.UseVisualStyleBackColor = true;
            this.btnXacNhan.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnChonAnh
            // 
            this.btnChonAnh.Location = new System.Drawing.Point(542, 62);
            this.btnChonAnh.Name = "btnChonAnh";
            this.btnChonAnh.Size = new System.Drawing.Size(75, 23);
            this.btnChonAnh.TabIndex = 15;
            this.btnChonAnh.Text = "Chọn ảnh";
            this.btnChonAnh.UseVisualStyleBackColor = true;
            // 
            // picHinhAnh
            // 
            this.picHinhAnh.Location = new System.Drawing.Point(542, 10);
            this.picHinhAnh.Name = "picHinhAnh";
            this.picHinhAnh.Size = new System.Drawing.Size(75, 46);
            this.picHinhAnh.TabIndex = 14;
            this.picHinhAnh.TabStop = false;
            // 
            // chkConKinhDoanh
            // 
            this.chkConKinhDoanh.AutoSize = true;
            this.chkConKinhDoanh.Location = new System.Drawing.Point(82, 91);
            this.chkConKinhDoanh.Name = "chkConKinhDoanh";
            this.chkConKinhDoanh.Size = new System.Drawing.Size(15, 14);
            this.chkConKinhDoanh.TabIndex = 13;
            this.chkConKinhDoanh.UseVisualStyleBackColor = true;
            // 
            // dtpNgayNhap
            // 
            this.dtpNgayNhap.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayNhap.Location = new System.Drawing.Point(421, 65);
            this.dtpNgayNhap.Name = "dtpNgayNhap";
            this.dtpNgayNhap.Size = new System.Drawing.Size(99, 20);
            this.dtpNgayNhap.TabIndex = 12;
            // 
            // numSoLuong
            // 
            this.numSoLuong.Location = new System.Drawing.Point(421, 18);
            this.numSoLuong.Name = "numSoLuong";
            this.numSoLuong.Size = new System.Drawing.Size(99, 20);
            this.numSoLuong.TabIndex = 11;
            // 
            // numDonGia
            // 
            this.numDonGia.Location = new System.Drawing.Point(231, 65);
            this.numDonGia.Name = "numDonGia";
            this.numDonGia.Size = new System.Drawing.Size(120, 20);
            this.numDonGia.TabIndex = 10;
            // 
            // lblConKinhDoanh
            // 
            this.lblConKinhDoanh.AutoSize = true;
            this.lblConKinhDoanh.Location = new System.Drawing.Point(23, 91);
            this.lblConKinhDoanh.Name = "lblConKinhDoanh";
            this.lblConKinhDoanh.Size = new System.Drawing.Size(53, 13);
            this.lblConKinhDoanh.TabIndex = 8;
            this.lblConKinhDoanh.Text = "Còn hàng";
            // 
            // lblNgayNhap
            // 
            this.lblNgayNhap.AutoSize = true;
            this.lblNgayNhap.Location = new System.Drawing.Point(356, 68);
            this.lblNgayNhap.Name = "lblNgayNhap";
            this.lblNgayNhap.Size = new System.Drawing.Size(59, 13);
            this.lblNgayNhap.TabIndex = 7;
            this.lblNgayNhap.Text = "Ngày nhập";
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.Location = new System.Drawing.Point(365, 22);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(49, 13);
            this.lblSoLuong.TabIndex = 6;
            this.lblSoLuong.Text = "Số lượng";
            // 
            // lblDonGia
            // 
            this.lblDonGia.AutoSize = true;
            this.lblDonGia.Location = new System.Drawing.Point(182, 68);
            this.lblDonGia.Name = "lblDonGia";
            this.lblDonGia.Size = new System.Drawing.Size(44, 13);
            this.lblDonGia.TabIndex = 5;
            this.lblDonGia.Text = "Đơn giá";
            // 
            // lblLoaiSP
            // 
            this.lblLoaiSP.AutoSize = true;
            this.lblLoaiSP.Location = new System.Drawing.Point(182, 25);
            this.lblLoaiSP.Name = "lblLoaiSP";
            this.lblLoaiSP.Size = new System.Drawing.Size(44, 13);
            this.lblLoaiSP.TabIndex = 4;
            this.lblLoaiSP.Text = "Loại SP";
            // 
            // cboLoaiSP
            // 
            this.cboLoaiSP.FormattingEnabled = true;
            this.cboLoaiSP.Location = new System.Drawing.Point(231, 18);
            this.cboLoaiSP.Name = "cboLoaiSP";
            this.cboLoaiSP.Size = new System.Drawing.Size(121, 21);
            this.cboLoaiSP.TabIndex = 3;
            // 
            // lblTenSP
            // 
            this.lblTenSP.AutoSize = true;
            this.lblTenSP.Location = new System.Drawing.Point(22, 68);
            this.lblTenSP.Name = "lblTenSP";
            this.lblTenSP.Size = new System.Drawing.Size(43, 13);
            this.lblTenSP.TabIndex = 2;
            this.lblTenSP.Text = "Tên SP";
            // 
            // lblMaSP
            // 
            this.lblMaSP.AutoSize = true;
            this.lblMaSP.Location = new System.Drawing.Point(22, 22);
            this.lblMaSP.Name = "lblMaSP";
            this.lblMaSP.Size = new System.Drawing.Size(39, 13);
            this.lblMaSP.TabIndex = 1;
            this.lblMaSP.Text = "Mã SP";
            // 
            // txtTenSP
            // 
            this.txtTenSP.Location = new System.Drawing.Point(63, 65);
            this.txtTenSP.Name = "txtTenSP";
            this.txtTenSP.Size = new System.Drawing.Size(100, 20);
            this.txtTenSP.TabIndex = 0;
            // 
            // txtMaSP
            // 
            this.txtMaSP.Location = new System.Drawing.Point(63, 19);
            this.txtMaSP.Name = "txtMaSP";
            this.txtMaSP.Size = new System.Drawing.Size(100, 20);
            this.txtMaSP.TabIndex = 0;
            // 
            // dgvProducts
            // 
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AllowUserToDeleteRows = false;
            this.dgvProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvProducts.Location = new System.Drawing.Point(0, 163);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.Size = new System.Drawing.Size(782, 262);
            this.dgvProducts.TabIndex = 3;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thêmToolStripMenuItem1,
            this.xóaToolStripMenuItem1,
            this.sửaToolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(106, 70);
            // 
            // thêmToolStripMenuItem1
            // 
            this.thêmToolStripMenuItem1.Name = "thêmToolStripMenuItem1";
            this.thêmToolStripMenuItem1.Size = new System.Drawing.Size(105, 22);
            this.thêmToolStripMenuItem1.Text = "Thêm";
            // 
            // xóaToolStripMenuItem1
            // 
            this.xóaToolStripMenuItem1.Name = "xóaToolStripMenuItem1";
            this.xóaToolStripMenuItem1.Size = new System.Drawing.Size(105, 22);
            this.xóaToolStripMenuItem1.Text = "Xóa";
            // 
            // sửaToolStripMenuItem1
            // 
            this.sửaToolStripMenuItem1.Name = "sửaToolStripMenuItem1";
            this.sửaToolStripMenuItem1.Size = new System.Drawing.Size(105, 22);
            this.sửaToolStripMenuItem1.Text = "Sửa";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.lblCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(781, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(118, 17);
            this.lblStatus.Text = "toolStripStatusLabel1";
            this.lblStatus.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            // 
            // lblCount
            // 
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(118, 17);
            this.lblCount.Text = "toolStripStatusLabel2";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 450);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.dgvProducts);
            this.Controls.Add(this.grpThongTin);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.grpThongTin.ResumeLayout(false);
            this.grpThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHinhAnh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDonGia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mởFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lưuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thoatasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thêmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xóaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sửaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem làmMớiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trợGiúpToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbThem;
        private System.Windows.Forms.ToolStripButton tsbXoa;
        private System.Windows.Forms.ToolStripButton tsbSua;
        private System.Windows.Forms.ToolStripButton tsbLamMoi;
        private System.Windows.Forms.ToolStripTextBox tstxtTimKiem;
        private System.Windows.Forms.ToolStripButton tsbTimKiem;
        private System.Windows.Forms.GroupBox grpThongTin;
        private System.Windows.Forms.Label lblTenSP;
        private System.Windows.Forms.Label lblMaSP;
        private System.Windows.Forms.TextBox txtTenSP;
        private System.Windows.Forms.TextBox txtMaSP;
        private System.Windows.Forms.DateTimePicker dtpNgayNhap;
        private System.Windows.Forms.NumericUpDown numSoLuong;
        private System.Windows.Forms.NumericUpDown numDonGia;
        private System.Windows.Forms.Label lblConKinhDoanh;
        private System.Windows.Forms.Label lblNgayNhap;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.Label lblDonGia;
        private System.Windows.Forms.Label lblLoaiSP;
        private System.Windows.Forms.ComboBox cboLoaiSP;
        private System.Windows.Forms.CheckBox chkConKinhDoanh;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.Button btnChonAnh;
        private System.Windows.Forms.PictureBox picHinhAnh;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem thêmToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem xóaToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem sửaToolStripMenuItem1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripStatusLabel lblCount;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

