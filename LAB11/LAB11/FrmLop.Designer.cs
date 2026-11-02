namespace LAB11
{
    partial class FrmLop
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
            lblTitle = new System.Windows.Forms.Label();
            grpThongTin = new System.Windows.Forms.GroupBox();
            cboKhoa = new System.Windows.Forms.ComboBox();
            lblKhoa = new System.Windows.Forms.Label();
            btnLamMoi = new System.Windows.Forms.Button();
            btnXoa = new System.Windows.Forms.Button();
            btnSua = new System.Windows.Forms.Button();
            btnThem = new System.Windows.Forms.Button();
            txtTenLop = new System.Windows.Forms.TextBox();
            lblTenLop = new System.Windows.Forms.Label();
            txtMaLop = new System.Windows.Forms.TextBox();
            lblMaLop = new System.Windows.Forms.Label();
            grpDanhSach = new System.Windows.Forms.GroupBox();
            dgvLop = new System.Windows.Forms.DataGridView();
            btnTimKiem = new System.Windows.Forms.Button();
            txtTimKiem = new System.Windows.Forms.TextBox();
            lblTimKiem = new System.Windows.Forms.Label();
            grpThongTin.SuspendLayout();
            grpDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLop).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblTitle.ForeColor = System.Drawing.Color.Blue;
            lblTitle.Location = new System.Drawing.Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(784, 45);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "QUẢN LÝ THÔNG TIN LỚP HỌC";
            lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpThongTin
            // 
            grpThongTin.Controls.Add(cboKhoa);
            grpThongTin.Controls.Add(lblKhoa);
            grpThongTin.Controls.Add(btnLamMoi);
            grpThongTin.Controls.Add(btnXoa);
            grpThongTin.Controls.Add(btnSua);
            grpThongTin.Controls.Add(btnThem);
            grpThongTin.Controls.Add(txtTenLop);
            grpThongTin.Controls.Add(lblTenLop);
            grpThongTin.Controls.Add(txtMaLop);
            grpThongTin.Controls.Add(lblMaLop);
            grpThongTin.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            grpThongTin.Location = new System.Drawing.Point(12, 48);
            grpThongTin.Name = "grpThongTin";
            grpThongTin.Size = new System.Drawing.Size(760, 150);
            grpThongTin.TabIndex = 1;
            grpThongTin.TabStop = false;
            grpThongTin.Text = "Thông tin lớp học";
            // 
            // cboKhoa
            // 
            cboKhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboKhoa.FormattingEnabled = true;
            cboKhoa.Location = new System.Drawing.Point(115, 68);
            cboKhoa.Name = "cboKhoa";
            cboKhoa.Size = new System.Drawing.Size(220, 25);
            cboKhoa.TabIndex = 5;
            // 
            // lblKhoa
            // 
            lblKhoa.AutoSize = true;
            lblKhoa.Location = new System.Drawing.Point(45, 71);
            lblKhoa.Name = "lblKhoa";
            lblKhoa.Size = new System.Drawing.Size(43, 19);
            lblKhoa.TabIndex = 4;
            lblKhoa.Text = "Khoa:";
            // 
            // btnLamMoi
            // 
            btnLamMoi.Location = new System.Drawing.Point(525, 108);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new System.Drawing.Size(90, 32);
            btnLamMoi.TabIndex = 9;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new System.Drawing.Point(415, 108);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new System.Drawing.Size(90, 32);
            btnXoa.TabIndex = 8;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new System.Drawing.Point(305, 108);
            btnSua.Name = "btnSua";
            btnSua.Size = new System.Drawing.Size(90, 32);
            btnSua.TabIndex = 7;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnThem
            // 
            btnThem.Location = new System.Drawing.Point(195, 108);
            btnThem.Name = "btnThem";
            btnThem.Size = new System.Drawing.Size(90, 32);
            btnThem.TabIndex = 6;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // txtTenLop
            // 
            txtTenLop.Location = new System.Drawing.Point(465, 28);
            txtTenLop.Name = "txtTenLop";
            txtTenLop.Size = new System.Drawing.Size(250, 25);
            txtTenLop.TabIndex = 3;
            // 
            // lblTenLop
            // 
            lblTenLop.AutoSize = true;
            lblTenLop.Location = new System.Drawing.Point(395, 31);
            lblTenLop.Name = "lblTenLop";
            lblTenLop.Size = new System.Drawing.Size(60, 19);
            lblTenLop.TabIndex = 2;
            lblTenLop.Text = "Tên lớp:";
            // 
            // txtMaLop
            // 
            txtMaLop.Location = new System.Drawing.Point(115, 28);
            txtMaLop.Name = "txtMaLop";
            txtMaLop.Size = new System.Drawing.Size(220, 25);
            txtMaLop.TabIndex = 1;
            // 
            // lblMaLop
            // 
            lblMaLop.AutoSize = true;
            lblMaLop.Location = new System.Drawing.Point(45, 31);
            lblMaLop.Name = "lblMaLop";
            lblMaLop.Size = new System.Drawing.Size(55, 19);
            lblMaLop.TabIndex = 0;
            lblMaLop.Text = "Mã lớp:";
            // 
            // grpDanhSach
            // 
            grpDanhSach.Controls.Add(dgvLop);
            grpDanhSach.Controls.Add(btnTimKiem);
            grpDanhSach.Controls.Add(txtTimKiem);
            grpDanhSach.Controls.Add(lblTimKiem);
            grpDanhSach.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            grpDanhSach.Location = new System.Drawing.Point(12, 204);
            grpDanhSach.Name = "grpDanhSach";
            grpDanhSach.Size = new System.Drawing.Size(760, 245);
            grpDanhSach.TabIndex = 2;
            grpDanhSach.TabStop = false;
            grpDanhSach.Text = "Danh sách lớp học";
            // 
            // dgvLop
            // 
            dgvLop.AllowUserToAddRows = false;
            dgvLop.AllowUserToDeleteRows = false;
            dgvLop.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvLop.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLop.Location = new System.Drawing.Point(15, 60);
            dgvLop.MultiSelect = false;
            dgvLop.Name = "dgvLop";
            dgvLop.ReadOnly = true;
            dgvLop.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvLop.Size = new System.Drawing.Size(730, 170);
            dgvLop.TabIndex = 3;
            dgvLop.CellClick += dgvLop_CellClick;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Location = new System.Drawing.Point(485, 22);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new System.Drawing.Size(90, 30);
            btnTimKiem.TabIndex = 2;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new System.Drawing.Point(235, 25);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new System.Drawing.Size(235, 25);
            txtTimKiem.TabIndex = 1;
            // 
            // lblTimKiem
            // 
            lblTimKiem.AutoSize = true;
            lblTimKiem.Location = new System.Drawing.Point(160, 28);
            lblTimKiem.Name = "lblTimKiem";
            lblTimKiem.Size = new System.Drawing.Size(67, 19);
            lblTimKiem.TabIndex = 0;
            lblTimKiem.Text = "Tìm kiếm:";
            // 
            // FrmLop
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(784, 461);
            Controls.Add(grpDanhSach);
            Controls.Add(grpThongTin);
            Controls.Add(lblTitle);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmLop";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Quản Lý Lớp Học";
            Load += FrmLop_Load;
            grpThongTin.ResumeLayout(false);
            grpThongTin.PerformLayout();
            grpDanhSach.ResumeLayout(false);
            grpDanhSach.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLop).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpThongTin;
        private System.Windows.Forms.Label lblMaLop;
        private System.Windows.Forms.TextBox txtMaLop;
        private System.Windows.Forms.Label lblTenLop;
        private System.Windows.Forms.TextBox txtTenLop;
        private System.Windows.Forms.Label lblKhoa;
        private System.Windows.Forms.ComboBox cboKhoa;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.GroupBox grpDanhSach;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.DataGridView dgvLop;
    }
}