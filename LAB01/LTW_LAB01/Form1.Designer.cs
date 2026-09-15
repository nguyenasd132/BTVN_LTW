namespace LTW_LAB01
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
            lblHoTen = new Label();
            txtHoTen = new TextBox();
            txtNamSinh = new TextBox();
            lblNamSinh = new Label();
            lblTitle = new Label();
            txtEmail = new TextBox();
            lblEmail = new Label();
            radNam = new RadioButton();
            radNu = new RadioButton();
            gBoxGioiTinh = new GroupBox();
            btnHienThi = new Button();
            cboKhoa = new ComboBox();
            btnXoa = new Button();
            btnExit = new Button();
            gBoxGioiTinh.SuspendLayout();
            SuspendLayout();
            // 
            // lblHoTen
            // 
            lblHoTen.AutoSize = true;
            lblHoTen.Location = new Point(43, 91);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new Size(58, 15);
            lblHoTen.TabIndex = 0;
            lblHoTen.Text = "Họ và tên";
            lblHoTen.Click += label1_Click;
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(43, 111);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(208, 23);
            txtHoTen.TabIndex = 1;
            txtHoTen.TextChanged += textBox1_TextChanged;
            // 
            // txtNamSinh
            // 
            txtNamSinh.Location = new Point(43, 155);
            txtNamSinh.Name = "txtNamSinh";
            txtNamSinh.Size = new Size(208, 23);
            txtNamSinh.TabIndex = 3;
            // 
            // lblNamSinh
            // 
            lblNamSinh.AutoSize = true;
            lblNamSinh.Location = new Point(43, 137);
            lblNamSinh.Name = "lblNamSinh";
            lblNamSinh.Size = new Size(58, 15);
            lblNamSinh.TabIndex = 2;
            lblNamSinh.Text = "Năm sinh";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(43, 42);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(208, 21);
            lblTitle.TabIndex = 4;
            lblTitle.Text = "NHẬP DỮ LIỆU SINH VIÊN";
            lblTitle.Click += label3_Click;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(43, 199);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(208, 23);
            txtEmail.TabIndex = 6;
            txtEmail.TextChanged += textBox3_TextChanged;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(43, 181);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(36, 15);
            lblEmail.TabIndex = 5;
            lblEmail.Text = "Email";
            // 
            // radNam
            // 
            radNam.AutoSize = true;
            radNam.Location = new Point(29, 22);
            radNam.Name = "radNam";
            radNam.Size = new Size(51, 19);
            radNam.TabIndex = 7;
            radNam.TabStop = true;
            radNam.Text = "Nam";
            radNam.UseVisualStyleBackColor = true;
            radNam.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // radNu
            // 
            radNu.AutoSize = true;
            radNu.Location = new Point(133, 22);
            radNu.Name = "radNu";
            radNu.Size = new Size(41, 19);
            radNu.TabIndex = 8;
            radNu.TabStop = true;
            radNu.Text = "Nữ";
            radNu.UseVisualStyleBackColor = true;
            // 
            // gBoxGioiTinh
            // 
            gBoxGioiTinh.Controls.Add(radNam);
            gBoxGioiTinh.Controls.Add(radNu);
            gBoxGioiTinh.Location = new Point(43, 228);
            gBoxGioiTinh.Name = "gBoxGioiTinh";
            gBoxGioiTinh.Size = new Size(208, 57);
            gBoxGioiTinh.TabIndex = 9;
            gBoxGioiTinh.TabStop = false;
            gBoxGioiTinh.Text = "Giới tính";
            gBoxGioiTinh.Enter += groupBox1_Enter;
            // 
            // btnHienThi
            // 
            btnHienThi.Location = new Point(43, 347);
            btnHienThi.Name = "btnHienThi";
            btnHienThi.Size = new Size(85, 33);
            btnHienThi.TabIndex = 10;
            btnHienThi.Text = "Hiển thị";
            btnHienThi.UseVisualStyleBackColor = true;
            btnHienThi.Click += btnHienThi_Click;
            // 
            // cboKhoa
            // 
            cboKhoa.ForeColor = SystemColors.WindowText;
            cboKhoa.FormattingEnabled = true;
            cboKhoa.Items.AddRange(new object[] { "Công nghệ thông tin", "Toán tin", "Ngữ văn", "Vật lý" });
            cboKhoa.Location = new Point(43, 300);
            cboKhoa.Name = "cboKhoa";
            cboKhoa.Size = new Size(208, 23);
            cboKhoa.TabIndex = 11;
            cboKhoa.Text = "Chọn khoa";
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(166, 347);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(85, 33);
            btnXoa.TabIndex = 12;
            btnXoa.Text = "Xóa dữ liệu";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(212, 453);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(85, 33);
            btnExit.TabIndex = 13;
            btnExit.Text = "Thoát";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(309, 498);
            Controls.Add(btnExit);
            Controls.Add(btnXoa);
            Controls.Add(cboKhoa);
            Controls.Add(btnHienThi);
            Controls.Add(gBoxGioiTinh);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            Controls.Add(lblTitle);
            Controls.Add(txtNamSinh);
            Controls.Add(lblNamSinh);
            Controls.Add(txtHoTen);
            Controls.Add(lblHoTen);
            Name = "Form1";
            Text = "Nhập dữ liệu sinh viên";
            Load += Form1_Load;
            gBoxGioiTinh.ResumeLayout(false);
            gBoxGioiTinh.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblHoTen;
        private TextBox txtHoTen;
        private TextBox txtNamSinh;
        private Label lblNamSinh;
        private Label lblTitle;
        private TextBox txtEmail;
        private Label lblEmail;
        private RadioButton radNam;
        private RadioButton radNu;
        private GroupBox gBoxGioiTinh;
        private Button btnHienThi;
        private ComboBox cboKhoa;
        private Button btnXoa;
        private Button btnExit;
    }
}
