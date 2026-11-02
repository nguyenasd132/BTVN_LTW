namespace StudentReportDemo.Forms
{
    partial class FrmBaoCaoSinhVien
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
            this.lblLop = new System.Windows.Forms.Label();
            this.cboLop = new System.Windows.Forms.ComboBox();
            this.lblKetQua = new System.Windows.Forms.Label();
            this.cboKetQua = new System.Windows.Forms.ComboBox();
            this.lblTuKhoa = new System.Windows.Forms.Label();
            this.txtTuKhoa = new System.Windows.Forms.TextBox();
            this.btnXemBaoCao = new System.Windows.Forms.Button();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.btnXuatFile = new System.Windows.Forms.Button();
            this.dgvBaoCao = new System.Windows.Forms.DataGridView();
            this.lblThongKe = new System.Windows.Forms.Label();
            this.grpChucNang = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCao)).BeginInit();
            this.grpChucNang.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpChucNang
            // 
            this.grpChucNang.Controls.Add(this.lblLop);
            this.grpChucNang.Controls.Add(this.cboLop);
            this.grpChucNang.Controls.Add(this.lblKetQua);
            this.grpChucNang.Controls.Add(this.cboKetQua);
            this.grpChucNang.Controls.Add(this.lblTuKhoa);
            this.grpChucNang.Controls.Add(this.txtTuKhoa);
            this.grpChucNang.Controls.Add(this.btnXemBaoCao);
            this.grpChucNang.Controls.Add(this.btnThongKe);
            this.grpChucNang.Controls.Add(this.btnXuatFile);
            this.grpChucNang.Location = new System.Drawing.Point(12, 12);
            this.grpChucNang.Name = "grpChucNang";
            this.grpChucNang.Size = new System.Drawing.Size(760, 100);
            this.grpChucNang.TabIndex = 0;
            this.grpChucNang.TabStop = false;
            this.grpChucNang.Text = "Bộ lọc và Thao tác";
            // 
            // lblLop
            // 
            this.lblLop.AutoSize = true;
            this.lblLop.Location = new System.Drawing.Point(15, 28);
            this.lblLop.Name = "lblLop";
            this.lblLop.Size = new System.Drawing.Size(56, 15);
            this.lblLop.TabIndex = 0;
            this.lblLop.Text = "Chọn lớp:";
            // 
            // cboLop
            // 
            this.cboLop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLop.FormattingEnabled = true;
            this.cboLop.Location = new System.Drawing.Point(75, 25);
            this.cboLop.Name = "cboLop";
            this.cboLop.Size = new System.Drawing.Size(150, 23);
            this.cboLop.TabIndex = 1;
            this.cboLop.SelectedIndexChanged += new System.EventHandler(this.cboLop_SelectedIndexChanged);
            // 
            // lblKetQua
            // 
            this.lblKetQua.AutoSize = true;
            this.lblKetQua.Location = new System.Drawing.Point(245, 28);
            this.lblKetQua.Name = "lblKetQua";
            this.lblKetQua.Size = new System.Drawing.Size(50, 15);
            this.lblKetQua.TabIndex = 2;
            this.lblKetQua.Text = "Kết quả:";
            // 
            // cboKetQua
            // 
            this.cboKetQua.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKetQua.FormattingEnabled = true;
            this.cboKetQua.Location = new System.Drawing.Point(300, 25);
            this.cboKetQua.Name = "cboKetQua";
            this.cboKetQua.Size = new System.Drawing.Size(130, 23);
            this.cboKetQua.TabIndex = 3;
            this.cboKetQua.SelectedIndexChanged += new System.EventHandler(this.cboKetQua_SelectedIndexChanged);
            // 
            // lblTuKhoa
            // 
            this.lblTuKhoa.AutoSize = true;
            this.lblTuKhoa.Location = new System.Drawing.Point(445, 28);
            this.lblTuKhoa.Name = "lblTuKhoa";
            this.lblTuKhoa.Size = new System.Drawing.Size(53, 15);
            this.lblTuKhoa.TabIndex = 4;
            this.lblTuKhoa.Text = "Từ khóa:";
            // 
            // txtTuKhoa
            // 
            this.txtTuKhoa.Location = new System.Drawing.Point(503, 25);
            this.txtTuKhoa.Name = "txtTuKhoa";
            this.txtTuKhoa.Size = new System.Drawing.Size(240, 23);
            this.txtTuKhoa.TabIndex = 5;
            this.txtTuKhoa.TextChanged += new System.EventHandler(this.txtTuKhoa_TextChanged);
            // 
            // btnXemBaoCao
            // 
            this.btnXemBaoCao.Location = new System.Drawing.Point(75, 60);
            this.btnXemBaoCao.Name = "btnXemBaoCao";
            this.btnXemBaoCao.Size = new System.Drawing.Size(120, 30);
            this.btnXemBaoCao.TabIndex = 6;
            this.btnXemBaoCao.Text = "Xem báo cáo";
            this.btnXemBaoCao.UseVisualStyleBackColor = true;
            this.btnXemBaoCao.Click += new System.EventHandler(this.btnXemBaoCao_Click);
            // 
            // btnThongKe
            // 
            this.btnThongKe.Location = new System.Drawing.Point(210, 60);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(140, 30);
            this.btnThongKe.TabIndex = 7;
            this.btnThongKe.Text = "Thống kê theo lớp";
            this.btnThongKe.UseVisualStyleBackColor = true;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // btnXuatFile
            // 
            this.btnXuatFile.Location = new System.Drawing.Point(360, 60);
            this.btnXuatFile.Name = "btnXuatFile";
            this.btnXuatFile.Size = new System.Drawing.Size(120, 30);
            this.btnXuatFile.TabIndex = 8;
            this.btnXuatFile.Text = "Xuất file CSV";
            this.btnXuatFile.UseVisualStyleBackColor = true;
            this.btnXuatFile.Click += new System.EventHandler(this.btnXuatFile_Click);
            // 
            // dgvBaoCao
            // 
            this.dgvBaoCao.AllowUserToAddRows = false;
            this.dgvBaoCao.AllowUserToDeleteRows = false;
            this.dgvBaoCao.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBaoCao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBaoCao.Location = new System.Drawing.Point(12, 120);
            this.dgvBaoCao.Name = "dgvBaoCao";
            this.dgvBaoCao.ReadOnly = true;
            this.dgvBaoCao.RowHeadersWidth = 51;
            this.dgvBaoCao.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBaoCao.Size = new System.Drawing.Size(760, 300);
            this.dgvBaoCao.TabIndex = 1;
            // 
            // lblThongKe
            // 
            this.lblThongKe.AutoSize = true;
            this.lblThongKe.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblThongKe.Location = new System.Drawing.Point(12, 430);
            this.lblThongKe.Name = "lblThongKe";
            this.lblThongKe.Size = new System.Drawing.Size(64, 17);
            this.lblThongKe.TabIndex = 2;
            this.lblThongKe.Text = "Thống kê";
            // 
            // FrmBaoCaoSinhVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.lblThongKe);
            this.Controls.Add(this.dgvBaoCao);
            this.Controls.Add(this.grpChucNang);
            this.Name = "FrmBaoCaoSinhVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo sinh viên bằng LINQ";
            this.Load += new System.EventHandler(this.FrmBaoCaoSinhVien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCao)).EndInit();
            this.grpChucNang.ResumeLayout(false);
            this.grpChucNang.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpChucNang;
        private System.Windows.Forms.Label lblLop;
        private System.Windows.Forms.ComboBox cboLop;
        private System.Windows.Forms.Label lblKetQua;
        private System.Windows.Forms.ComboBox cboKetQua;
        private System.Windows.Forms.Label lblTuKhoa;
        private System.Windows.Forms.TextBox txtTuKhoa;
        private System.Windows.Forms.Button btnXemBaoCao;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.Button btnXuatFile;
        private System.Windows.Forms.DataGridView dgvBaoCao;
        private System.Windows.Forms.Label lblThongKe;
    }
}