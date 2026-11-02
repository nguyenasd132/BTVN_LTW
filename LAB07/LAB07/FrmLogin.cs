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
    public partial class FrmLogin : Form
    {
        string admin = "admin";
        string user = "user";
        string password = "123";

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmMain frmMain = new FrmMain();

            if (textBox1.Text == admin && textBox2.Text == password)
            {
                // TRUYỀN QUYỀN ADMIN: Các nút Thêm/Sửa/Xóa sẽ sáng lên và bấm được
                frmMain.isAdmin = true;
            }
            else if (textBox1.Text == user && textBox2.Text == password)
            {
                // QUYỀN USER: Các nút sẽ bị xám (khóa lại)
                frmMain.isAdmin = false;
            }
            else
            {
                MessageBox.Show("Invalid username or password");
                return;
            }

            frmMain.Show();

            // Thêm dòng này để ẩn Form Đăng nhập đi cho gọn màn hình
            this.Hide();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            textBox1.Text = admin;
            textBox2.Text = password;
            textBox2.PasswordChar = '*';
        }
    }
}
    