using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB07
{
    public partial class FrmMain : Form
    {
        // Biến lưu quyền đăng nhập (nhận từ FrmLogin)
        public bool isAdmin = false;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            danhSáchKháchHàngToolStripMenuItem_Click(sender, e);

            // Phân quyền: Nếu không phải Admin thì khóa các nút thao tác dữ liệu
            if (!isAdmin)
            {
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
            }
        }

        // Hàm hỗ trợ mở 1 form con duy nhất và tự động đóng các form khác
        private void MoFormCon(Form frmMoi)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == frmMoi.GetType())
                {
                    f.Activate();
                    return;
                }
                f.Close();
            }

            frmMoi.MdiParent = this;
            frmMoi.Show(); // GỌI SHOW() TRƯỚC

            // GÁN XÓA VIỀN VÀ FILL SAU KHI SHOW
            frmMoi.FormBorderStyle = FormBorderStyle.None;
            frmMoi.Dock = DockStyle.Fill;
        }
        private void ResetHieuUngMenu()
        {
            // Đặt lại màu nền trong suốt (mặc định)
            danhSáchSảnPhẩmToolStripMenuItem.BackColor = Color.Transparent;
            danhSáchKháchHàngToolStripMenuItem.BackColor = Color.Transparent;

            // Đặt lại chữ in thường
            danhSáchSảnPhẩmToolStripMenuItem.Font = new Font(danhSáchSảnPhẩmToolStripMenuItem.Font, FontStyle.Regular);
            danhSáchKháchHàngToolStripMenuItem.Font = new Font(danhSáchKháchHàngToolStripMenuItem.Font, FontStyle.Regular);
        }

        // --- CÁC SỰ KIỆN MENU ---
        private void danhSáchSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 1. Reset các menu khác
            ResetHieuUngMenu();

            // 2. Làm nổi bật menu đang chọn
            danhSáchSảnPhẩmToolStripMenuItem.BackColor = Color.LightSkyBlue;
            danhSáchSảnPhẩmToolStripMenuItem.Font = new Font(danhSáchSảnPhẩmToolStripMenuItem.Font, FontStyle.Bold);

            // 3. Mở Form
            MoFormCon(new FrmProduct());
        }

        private void danhSáchKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 1. Reset các menu khác
            ResetHieuUngMenu();

            // 2. Làm nổi bật menu đang chọn
            danhSáchKháchHàngToolStripMenuItem.BackColor = Color.LightSkyBlue;
            danhSáchKháchHàngToolStripMenuItem.Font = new Font(danhSáchKháchHàngToolStripMenuItem.Font, FontStyle.Bold);

            // 3. Mở Form
            MoFormCon(new FrmCustomer());
        }

        // --- CÁC NÚT CHỨC NĂNG TẬP TRUNG (Sử dụng Interface IQuanLy) ---
        // Lưu ý: Đảm bảo bạn đã kéo 5 nút này vào FrmMain và đặt tên đúng như dưới đây

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is IQuanLy frm) frm.Them();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is IQuanLy frm) frm.Sua();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is IQuanLy frm) frm.Xoa();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is IQuanLy frm) frm.TimKiem();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is IQuanLy frm) frm.LamMoi();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show(
            "Bạn có chắc chắn muốn thoát chương trình?",
            "Xác nhận",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                e.Cancel = true; // Hủy lệnh thoát nếu chọn No
            }
            else
            {
                Application.ExitThread(); // Đóng hoàn toàn ứng dụng
            }
        }
    }
}