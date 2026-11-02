namespace LAB12
{
    partial class FrmNhapDiemTheoLop
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox cboLop;
        private System.Windows.Forms.ComboBox cboMonHoc;
        private System.Windows.Forms.Button btnTaiDanhSach;
        private System.Windows.Forms.Button btnLuuTatCa;
        private System.Windows.Forms.DataGridView dgvKetQua;
        private System.Windows.Forms.Label lblLop;
        private System.Windows.Forms.Label lblMonHoc;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblTrangThai;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblLop = new System.Windows.Forms.Label();
            this.cboLop = new System.Windows.Forms.ComboBox();
            this.lblMonHoc = new System.Windows.Forms.Label();
            this.cboMonHoc = new System.Windows.Forms.ComboBox();
            this.btnTaiDanhSach = new System.Windows.Forms.Button();
            this.dgvKetQua = new System.Windows.Forms.DataGridView();
            this.btnLuuTatCa = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblTrangThai = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKetQua)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();

            // lblLop
            this.lblLop.AutoSize = true;
            this.lblLop.Location = new System.Drawing.Point(20, 20);
            this.lblLop.Name = "lblLop";
            this.lblLop.Size = new System.Drawing.Size(61, 16);
            this.lblLop.Text = "Chọn Lớp:";

            // cboLop
            this.cboLop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLop.FormattingEnabled = true;
            this.cboLop.Location = new System.Drawing.Point(85, 17);
            this.cboLop.Name = "cboLop";
            this.cboLop.Size = new System.Drawing.Size(180, 24);

            // lblMonHoc
            this.lblMonHoc.AutoSize = true;
            this.lblMonHoc.Location = new System.Drawing.Point(285, 20);
            this.lblMonHoc.Name = "lblMonHoc";
            this.lblMonHoc.Size = new System.Drawing.Size(95, 16);
            this.lblMonHoc.Text = "Chọn Môn Học:";

            // cboMonHoc
            this.cboMonHoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonHoc.FormattingEnabled = true;
            this.cboMonHoc.Location = new System.Drawing.Point(385, 17);
            this.cboMonHoc.Name = "cboMonHoc";
            this.cboMonHoc.Size = new System.Drawing.Size(200, 24);

            // btnTaiDanhSach
            this.btnTaiDanhSach.Location = new System.Drawing.Point(600, 14);
            this.btnTaiDanhSach.Name = "btnTaiDanhSach";
            this.btnTaiDanhSach.Size = new System.Drawing.Size(120, 30);
            this.btnTaiDanhSach.Text = "Tải Danh Sách";
            this.btnTaiDanhSach.UseVisualStyleBackColor = true;
            this.btnTaiDanhSach.Click += new System.EventHandler(this.btnTaiDanhSach_Click);

            // dgvKetQua
            this.dgvKetQua.AllowUserToAddRows = false;
            this.dgvKetQua.AllowUserToDeleteRows = false;
            this.dgvKetQua.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKetQua.Location = new System.Drawing.Point(20, 60);
            this.dgvKetQua.Name = "dgvKetQua";
            this.dgvKetQua.RowHeadersWidth = 51;
            this.dgvKetQua.Size = new System.Drawing.Size(700, 320);

            // btnLuuTatCa
            this.btnLuuTatCa.Location = new System.Drawing.Point(600, 390);
            this.btnLuuTatCa.Name = "btnLuuTatCa";
            this.btnLuuTatCa.Size = new System.Drawing.Size(120, 35);
            this.btnLuuTatCa.Text = "Lưu Tất Cả";
            this.btnLuuTatCa.UseVisualStyleBackColor = true;
            this.btnLuuTatCa.Click += new System.EventHandler(this.btnLuuTatCa_Click);

            // statusStrip1
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.lblTrangThai });
            this.statusStrip1.Location = new System.Drawing.Point(0, 435);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(740, 26);

            // lblTrangThai
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(70, 20);
            this.lblTrangThai.Text = "Sẵn sàng";

            // FrmNhapDiemTheoLop
            this.ClientSize = new System.Drawing.Size(740, 461);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnLuuTatCa);
            this.Controls.Add(this.dgvKetQua);
            this.Controls.Add(this.btnTaiDanhSach);
            this.Controls.Add(this.cboMonHoc);
            this.Controls.Add(this.lblMonHoc);
            this.Controls.Add(this.cboLop);
            this.Controls.Add(this.lblLop);
            this.Name = "FrmNhapDiemTheoLop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý Kết quả Học tập theo Lớp";
            this.Load += new System.EventHandler(this.FrmNhapDiemTheoLop_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKetQua)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}