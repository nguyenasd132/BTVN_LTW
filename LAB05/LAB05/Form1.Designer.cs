namespace LAB05
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            grbThongTin = new GroupBox();
            lblKiTu = new Label();
            ckbMail = new CheckBox();
            dtpNgaySinh = new DateTimePicker();
            txtSDT = new TextBox();
            txtHoTen = new TextBox();
            lblSDT = new Label();
            lblNgaySinh = new Label();
            lblHoTen = new Label();
            grbKhoaHoc = new GroupBox();
            lblTinhTien = new Label();
            lblTongTien = new Label();
            numericUpDown1 = new NumericUpDown();
            cbKhoaHoc = new ComboBox();
            lblKhoaHoc = new Label();
            lblSoThang = new Label();
            lblHinhThuc = new Label();
            rbOnl = new RadioButton();
            rbOffl = new RadioButton();
            btnXoa = new Button();
            btnDangKy = new Button();
            btnThoat = new Button();
            label1 = new Label();
            groupBox1 = new GroupBox();
            grbThongTin.SuspendLayout();
            grbKhoaHoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // grbThongTin
            // 
            grbThongTin.BackColor = Color.PaleGoldenrod;
            grbThongTin.Controls.Add(lblKiTu);
            grbThongTin.Controls.Add(ckbMail);
            grbThongTin.Controls.Add(dtpNgaySinh);
            grbThongTin.Controls.Add(txtSDT);
            grbThongTin.Controls.Add(txtHoTen);
            grbThongTin.Controls.Add(lblSDT);
            grbThongTin.Controls.Add(lblNgaySinh);
            grbThongTin.Controls.Add(lblHoTen);
            grbThongTin.Location = new Point(12, 54);
            grbThongTin.Name = "grbThongTin";
            grbThongTin.Size = new Size(305, 240);
            grbThongTin.TabIndex = 0;
            grbThongTin.TabStop = false;
            grbThongTin.Text = "Thông tin học viện";
            // 
            // lblKiTu
            // 
            lblKiTu.AutoSize = true;
            lblKiTu.Location = new Point(236, 22);
            lblKiTu.Name = "lblKiTu";
            lblKiTu.Size = new Size(30, 15);
            lblKiTu.TabIndex = 6;
            lblKiTu.Text = "0/50";
            lblKiTu.Click += label2_Click;
            // 
            // ckbMail
            // 
            ckbMail.AutoSize = true;
            ckbMail.Location = new Point(58, 137);
            ckbMail.Name = "ckbMail";
            ckbMail.Size = new Size(208, 19);
            ckbMail.TabIndex = 5;
            ckbMail.Text = "Nhận thông tin khóa học qua mail";
            ckbMail.UseVisualStyleBackColor = true;
            // 
            // dtpNgaySinh
            // 
            dtpNgaySinh.Location = new Point(72, 99);
            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.Size = new Size(194, 23);
            dtpNgaySinh.TabIndex = 4;
            // 
            // txtSDT
            // 
            txtSDT.Location = new Point(72, 69);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(194, 23);
            txtSDT.TabIndex = 3;
            txtSDT.TextChanged += txtSDT_TextChanged;
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(72, 40);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(194, 23);
            txtHoTen.TabIndex = 3;
            txtHoTen.TextChanged += txtHoTen_TextChanged;
            // 
            // lblSDT
            // 
            lblSDT.AutoSize = true;
            lblSDT.Location = new Point(38, 77);
            lblSDT.Name = "lblSDT";
            lblSDT.Size = new Size(28, 15);
            lblSDT.TabIndex = 0;
            lblSDT.Text = "SĐT";
            // 
            // lblNgaySinh
            // 
            lblNgaySinh.AutoSize = true;
            lblNgaySinh.Location = new Point(6, 105);
            lblNgaySinh.Name = "lblNgaySinh";
            lblNgaySinh.Size = new Size(60, 15);
            lblNgaySinh.TabIndex = 0;
            lblNgaySinh.Text = "Ngày sinh";
            // 
            // lblHoTen
            // 
            lblHoTen.AutoSize = true;
            lblHoTen.Location = new Point(23, 43);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new Size(43, 15);
            lblHoTen.TabIndex = 0;
            lblHoTen.Text = "Họ tên";
            // 
            // grbKhoaHoc
            // 
            grbKhoaHoc.BackColor = Color.PaleGoldenrod;
            grbKhoaHoc.Controls.Add(lblTinhTien);
            grbKhoaHoc.Controls.Add(lblTongTien);
            grbKhoaHoc.Controls.Add(numericUpDown1);
            grbKhoaHoc.Controls.Add(cbKhoaHoc);
            grbKhoaHoc.Controls.Add(lblKhoaHoc);
            grbKhoaHoc.Controls.Add(lblSoThang);
            grbKhoaHoc.Controls.Add(lblHinhThuc);
            grbKhoaHoc.Controls.Add(rbOnl);
            grbKhoaHoc.Controls.Add(rbOffl);
            grbKhoaHoc.Location = new Point(323, 54);
            grbKhoaHoc.Name = "grbKhoaHoc";
            grbKhoaHoc.Size = new Size(305, 240);
            grbKhoaHoc.TabIndex = 1;
            grbKhoaHoc.TabStop = false;
            grbKhoaHoc.Text = "Thông tin khóa học";
            grbKhoaHoc.Enter += grbKhoaHoc_Enter;
            // 
            // lblTinhTien
            // 
            lblTinhTien.AutoSize = true;
            lblTinhTien.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline);
            lblTinhTien.ForeColor = Color.PaleGreen;
            lblTinhTien.Location = new Point(75, 144);
            lblTinhTien.Name = "lblTinhTien";
            lblTinhTien.Size = new Size(55, 21);
            lblTinhTien.TabIndex = 6;
            lblTinhTien.Text = "label2";
            lblTinhTien.Click += label2_Click;
            // 
            // lblTongTien
            // 
            lblTongTien.AutoSize = true;
            lblTongTien.Location = new Point(8, 149);
            lblTongTien.Name = "lblTongTien";
            lblTongTien.Size = new Size(61, 15);
            lblTongTien.TabIndex = 5;
            lblTongTien.Text = "Tổng tiền:";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(113, 110);
            numericUpDown1.Maximum = new decimal(new int[] { 12, 0, 0, 0 });
            numericUpDown1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(41, 23);
            numericUpDown1.TabIndex = 4;
            numericUpDown1.TextAlign = HorizontalAlignment.Center;
            numericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // cbKhoaHoc
            // 
            cbKhoaHoc.FormattingEnabled = true;
            cbKhoaHoc.Items.AddRange(new object[] { "C# WinForms cơ bản", "Lập trình Python cơ bản", "SQL Server cơ bản", "Web Frontend cơ bản" });
            cbKhoaHoc.Location = new Point(75, 40);
            cbKhoaHoc.Name = "cbKhoaHoc";
            cbKhoaHoc.Size = new Size(189, 23);
            cbKhoaHoc.Sorted = true;
            cbKhoaHoc.TabIndex = 3;
            cbKhoaHoc.SelectedIndexChanged += cbKhoaHoc_SelectedIndexChanged;
            // 
            // lblKhoaHoc
            // 
            lblKhoaHoc.AutoSize = true;
            lblKhoaHoc.Location = new Point(6, 43);
            lblKhoaHoc.Name = "lblKhoaHoc";
            lblKhoaHoc.Size = new Size(57, 15);
            lblKhoaHoc.TabIndex = 0;
            lblKhoaHoc.Text = "Khóa học";
            lblKhoaHoc.Click += lblHinhThuc_Click;
            // 
            // lblSoThang
            // 
            lblSoThang.AutoSize = true;
            lblSoThang.Location = new Point(6, 113);
            lblSoThang.Name = "lblSoThang";
            lblSoThang.Size = new Size(99, 15);
            lblSoThang.TabIndex = 0;
            lblSoThang.Text = "Số tháng đăng ký";
            lblSoThang.Click += lblHinhThuc_Click;
            // 
            // lblHinhThuc
            // 
            lblHinhThuc.AutoSize = true;
            lblHinhThuc.Location = new Point(6, 77);
            lblHinhThuc.Name = "lblHinhThuc";
            lblHinhThuc.Size = new Size(63, 15);
            lblHinhThuc.TabIndex = 0;
            lblHinhThuc.Text = "Hình thức:";
            lblHinhThuc.Click += lblHinhThuc_Click;
            // 
            // rbOnl
            // 
            rbOnl.AutoSize = true;
            rbOnl.Location = new Point(75, 75);
            rbOnl.Name = "rbOnl";
            rbOnl.Size = new Size(60, 19);
            rbOnl.TabIndex = 1;
            rbOnl.TabStop = true;
            rbOnl.Text = "Online";
            rbOnl.UseVisualStyleBackColor = true;
            // 
            // rbOffl
            // 
            rbOffl.AutoSize = true;
            rbOffl.Location = new Point(193, 77);
            rbOffl.Name = "rbOffl";
            rbOffl.Size = new Size(71, 19);
            rbOffl.TabIndex = 2;
            rbOffl.TabStop = true;
            rbOffl.Text = "Trực tiếp";
            rbOffl.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.Khaki;
            btnXoa.Location = new Point(17, 99);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(87, 39);
            btnXoa.TabIndex = 2;
            btnXoa.Text = "Xóa dữ liệu";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click_1;
            // 
            // btnDangKy
            // 
            btnDangKy.BackColor = Color.LightGreen;
            btnDangKy.Location = new Point(17, 40);
            btnDangKy.Name = "btnDangKy";
            btnDangKy.Size = new Size(87, 39);
            btnDangKy.TabIndex = 2;
            btnDangKy.Text = "Đăng ký";
            btnDangKy.UseVisualStyleBackColor = false;
            btnDangKy.Click += btnDangKy_Click_1;
            // 
            // btnThoat
            // 
            btnThoat.BackColor = Color.PaleVioletRed;
            btnThoat.Location = new Point(17, 164);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(87, 39);
            btnThoat.TabIndex = 2;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = false;
            btnThoat.Click += btnThoat_Click_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Bold | FontStyle.Underline);
            label1.ForeColor = SystemColors.HotTrack;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(213, 28);
            label1.TabIndex = 3;
            label1.Text = "ĐĂNG KÝ KHÓA HỌC";
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.PaleGoldenrod;
            groupBox1.Controls.Add(btnThoat);
            groupBox1.Controls.Add(btnDangKy);
            groupBox1.Controls.Add(btnXoa);
            groupBox1.Location = new Point(647, 54);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(125, 240);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Goldenrod;
            ClientSize = new Size(800, 337);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Controls.Add(grbKhoaHoc);
            Controls.Add(grbThongTin);
            Name = "Form1";
            Text = "Phần mềm đăng ký khóa học";
            Load += Form1_Load;
            grbThongTin.ResumeLayout(false);
            grbThongTin.PerformLayout();
            grbKhoaHoc.ResumeLayout(false);
            grbKhoaHoc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox grbThongTin;
        private Label lblHinhThuc;
        private Label lblNgaySinh;
        private Label lblHoTen;
        private GroupBox grbKhoaHoc;
        private TextBox txtHoTen;
        private RadioButton rbOffl;
        private RadioButton rbOnl;
        private DateTimePicker dtpNgaySinh;
        private TextBox txtSDT;
        private Label lblSDT;
        private CheckBox ckbMail;
        private ComboBox cbKhoaHoc;
        private Label lblTongTien;
        private NumericUpDown numericUpDown1;
        private Label lblKhoaHoc;
        private Label lblSoThang;
        private Button btnXoa;
        private Button btnDangKy;
        private Button btnThoat;
        private Label label1;
        private GroupBox groupBox1;
        private Label lblTinhTien;
        private Label lblKiTu;
    }
}
