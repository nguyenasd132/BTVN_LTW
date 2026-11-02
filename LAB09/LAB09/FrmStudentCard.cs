using StudentCardPrinter;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace LAB09
{
    public partial class FrmStudentCard : Form
    {
        // Khai báo các Controls và Components
        private TextBox txtStudentId = null!;
        private TextBox txtFullName = null!;
        private TextBox txtCourse = null!;
        private ComboBox cboClass = null!;
        private ComboBox cboFaculty = null!;
        private ComboBox cboGender = null!;
        private DateTimePicker dtpBirthDate = null!;
        private PictureBox picAvatar = null!;

        private Button btnChoosePhoto = null!;
        private Button btnPreviewPrint = null!;
        private Button btnPrint = null!;
        private Button btnClear = null!;

        private Panel pnlCardPreview = null!;
        private PrintDocument printDocument1 = null!;
        private PrintDialog printDialog1 = null!;
        private PrintPreviewDialog printPreviewDialog1 = null!;

        public FrmStudentCard()
        {
            InitDynamicControls();

            InitializeData();
            RegisterEvents();
        }

        /// <summary>
        /// Tạo và sắp xếp vị trí tất cả các Control trên Form
        /// </summary>
        private void InitDynamicControls()
        {
            // 1. Cấu hình Form
            this.Text = "Quản Lý & In Thẻ Sinh Viên";
            this.Size = new Size(1020, 520);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // 2. GroupBox chứa thông tin nhập liệu 
            GroupBox grpInput = new GroupBox
            {
                Text = "Thông tin sinh viên",
                Location = new Point(15, 15),
                Size = new Size(390, 445),
                Font = new Font("Arial", 9.5F, FontStyle.Regular)
            };

            int lblX = 15, ctrlX = 120, startY = 30, rowSpacing = 38;

            // MSSV
            grpInput.Controls.Add(new Label { Text = "Mã sinh viên:", Location = new Point(lblX, startY), AutoSize = true });
            txtStudentId = new TextBox { Location = new Point(ctrlX, startY - 3), Width = 240 };
            grpInput.Controls.Add(txtStudentId);

            // Họ tên
            grpInput.Controls.Add(new Label { Text = "Họ và tên:", Location = new Point(lblX, startY + rowSpacing), AutoSize = true });
            txtFullName = new TextBox { Location = new Point(ctrlX, startY + rowSpacing - 3), Width = 240 };
            grpInput.Controls.Add(txtFullName);

            // Lớp
            grpInput.Controls.Add(new Label { Text = "Lớp:", Location = new Point(lblX, startY + rowSpacing * 2), AutoSize = true });
            cboClass = new ComboBox { Location = new Point(ctrlX, startY + rowSpacing * 2 - 3), Width = 240, DropDownStyle = ComboBoxStyle.DropDownList };
            grpInput.Controls.Add(cboClass);

            // Khoa
            grpInput.Controls.Add(new Label { Text = "Khoa:", Location = new Point(lblX, startY + rowSpacing * 3), AutoSize = true });
            cboFaculty = new ComboBox { Location = new Point(ctrlX, startY + rowSpacing * 3 - 3), Width = 240, DropDownStyle = ComboBoxStyle.DropDownList };
            grpInput.Controls.Add(cboFaculty);

            // Khóa
            grpInput.Controls.Add(new Label { Text = "Khóa học:", Location = new Point(lblX, startY + rowSpacing * 4), AutoSize = true });
            txtCourse = new TextBox { Location = new Point(ctrlX, startY + rowSpacing * 4 - 3), Width = 240, Text = "2023-2027" };
            grpInput.Controls.Add(txtCourse);

            // Giới tính
            grpInput.Controls.Add(new Label { Text = "Giới tính:", Location = new Point(lblX, startY + rowSpacing * 5), AutoSize = true });
            cboGender = new ComboBox { Location = new Point(ctrlX, startY + rowSpacing * 5 - 3), Width = 240, DropDownStyle = ComboBoxStyle.DropDownList };
            grpInput.Controls.Add(cboGender);

            // Ngày sinh
            grpInput.Controls.Add(new Label { Text = "Ngày sinh:", Location = new Point(lblX, startY + rowSpacing * 6), AutoSize = true });
            dtpBirthDate = new DateTimePicker { Location = new Point(ctrlX, startY + rowSpacing * 6 - 3), Width = 240, Format = DateTimePickerFormat.Custom, CustomFormat = "dd/MM/yyyy" };
            grpInput.Controls.Add(dtpBirthDate);

            // Chọn ảnh
            grpInput.Controls.Add(new Label { Text = "Ảnh chân dung:", Location = new Point(lblX, startY + rowSpacing * 7), AutoSize = true });
            btnChoosePhoto = new Button { Text = "Chọn ảnh...", Location = new Point(ctrlX, startY + rowSpacing * 7 - 5), Width = 110, Height = 30 };
            picAvatar = new PictureBox { Location = new Point(ctrlX + 120, startY + rowSpacing * 7 - 10), Size = new Size(40, 50), BorderStyle = BorderStyle.FixedSingle, SizeMode = PictureBoxSizeMode.Zoom };
            grpInput.Controls.Add(btnChoosePhoto);
            grpInput.Controls.Add(picAvatar);

            // Nút bấm chức năng (Xóa, Xem trước, In)
            btnClear = new Button { Text = "Nhập lại", Location = new Point(15, 385), Size = new Size(100, 35) };
            btnPreviewPrint = new Button { Text = "Xem trước in", Location = new Point(130, 385), Size = new Size(110, 35) };
            btnPrint = new Button { Text = "In thẻ", Location = new Point(255, 385), Size = new Size(115, 35), BackColor = Color.Navy, ForeColor = Color.White, FlatStyle = FlatStyle.Flat };

            grpInput.Controls.Add(btnClear);
            grpInput.Controls.Add(btnPreviewPrint);
            grpInput.Controls.Add(btnPrint);

            // 3. Panel xem trước Thẻ sinh viên (Bên phải)
            pnlCardPreview = new Panel
            {
                Location = new Point(420, 23),
                Size = new Size(560, 437),
                BackColor = Color.White,
                BorderStyle = BorderStyle.Fixed3D
            };

            // 4. Khởi tạo Component In ấn
            printDocument1 = new PrintDocument();
            printDialog1 = new PrintDialog();
            printPreviewDialog1 = new PrintPreviewDialog();

            // Thêm các Container chính vào Form
            this.Controls.Add(grpInput);
            this.Controls.Add(pnlCardPreview);
        }

        private void InitializeData()
        {
            cboClass.Items.AddRange(new object[] { "K49.CNTT.A", "K50.CNTT.A", "K51.CNTT.A" });
            cboFaculty.Items.AddRange(new object[] { "Công nghệ thông tin", "Toán - Tin học" });
            cboGender.Items.AddRange(new object[] { "Nam", "Nữ", "Khác" });

            cboClass.SelectedIndex = 0;
            cboFaculty.SelectedIndex = 0;
            cboGender.SelectedIndex = 0;
            picAvatar.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void RegisterEvents()
        {
            btnChoosePhoto.Click += btnChoosePhoto_Click;
            btnPreviewPrint.Click += btnPreviewPrint_Click;
            btnPrint.Click += btnPrint_Click;
            btnClear.Click += btnClear_Click;

            pnlCardPreview.Paint += pnlCardPreview_Paint;
            printDocument1.PrintPage += printDocument1_PrintPage;

            txtStudentId.TextChanged += InputChanged;
            txtFullName.TextChanged += InputChanged;
            txtCourse.TextChanged += InputChanged;
            cboClass.SelectedIndexChanged += InputChanged;
            cboFaculty.SelectedIndexChanged += InputChanged;
            cboGender.SelectedIndexChanged += InputChanged;
            dtpBirthDate.ValueChanged += InputChanged;
        }

        private void btnChoosePhoto_Click(object? sender, EventArgs e)
        {
            using OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Chọn ảnh sinh viên";
            dlg.Filter = "Image files|*.jpg;*.jpeg;*.png;*.bmp";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using Image temp = Image.FromFile(dlg.FileName);
                    Image copy = new Bitmap(temp);

                    picAvatar.Image?.Dispose();
                    picAvatar.Image = copy;
                    pnlCardPreview.Invalidate();
                }
                catch
                {
                    MessageBox.Show("File được chọn không phải ảnh hợp lệ.",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private StudentCardInfo GetStudentInfo()
        {
            return new StudentCardInfo
            {
                StudentId = txtStudentId.Text.Trim(),
                FullName = txtFullName.Text.Trim(),
                ClassName = cboClass.Text,
                Faculty = cboFaculty.Text,
                Course = txtCourse.Text.Trim(),
                BirthDate = dtpBirthDate.Value,
                Gender = cboGender.Text,
                Photo = picAvatar.Image
            };
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtStudentId.Text))
            {
                MessageBox.Show("Vui lòng nhập mã sinh viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStudentId.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFullName.Focus();
                return false;
            }

            if (picAvatar.Image == null)
            {
                MessageBox.Show("Vui lòng chọn ảnh sinh viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void InputChanged(object? sender, EventArgs e)
        {
            pnlCardPreview.Invalidate();
        }

        private void pnlCardPreview_Paint(object? sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle card = new Rectangle(20, 20,
                pnlCardPreview.Width - 40,
                pnlCardPreview.Height - 40);

            DrawStudentCard(e.Graphics, card, GetStudentInfo());
        }

        private void DrawStudentCard(Graphics g, Rectangle card, StudentCardInfo s)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;

            using Font schoolFont = new Font("Arial", 10, FontStyle.Bold);
            using Font titleFont = new Font("Arial", 16, FontStyle.Bold);
            using Font labelFont = new Font("Arial", 10, FontStyle.Bold);
            using Font normalFont = new Font("Arial", 10, FontStyle.Regular);

            using Pen borderPen = new Pen(Color.Navy, 2);
            using SolidBrush blueBrush = new SolidBrush(Color.Navy);
            using SolidBrush bgBrush = new SolidBrush(Color.FromArgb(238, 247, 247));

            g.FillRectangle(bgBrush, card);
            g.DrawRectangle(borderPen, card);

            int x = card.Left;
            int y = card.Top;

            g.DrawString("TRƯỜNG ĐẠI HỌC SƯ PHẠM TP. HỒ CHÍ MINH",
                schoolFont, blueBrush, x + 20, y + 15);
            g.DrawString("THẺ SINH VIÊN", titleFont, blueBrush, x + 20, y + 45);

            Rectangle photoBox = new Rectangle(x + 25, y + 90, 115, 150);
            g.FillRectangle(Brushes.White, photoBox);
            g.DrawRectangle(Pens.Gray, photoBox);

            if (s.Photo != null)
            {
                DrawImageZoom(g, s.Photo, photoBox);
            }
            else
            {
                g.DrawString("Ảnh", normalFont, Brushes.Gray, photoBox.Left + 35, photoBox.Top + 65);
            }

            int infoX = x + 165;
            int infoY = y + 95;

            DrawInfoLine(g, "MSSV:", s.StudentId, labelFont, normalFont, infoX, infoY);
            DrawInfoLine(g, "Họ tên:", s.FullName, labelFont, normalFont, infoX, infoY + 30);
            DrawInfoLine(g, "Lớp:", s.ClassName, labelFont, normalFont, infoX, infoY + 60);
            DrawInfoLine(g, "Khoa:", s.Faculty, labelFont, normalFont, infoX, infoY + 90);
            DrawInfoLine(g, "Khóa:", s.Course, labelFont, normalFont, infoX, infoY + 120);
            DrawInfoLine(g, "Ngày sinh:", s.BirthDate.ToString("dd/MM/yyyy"), labelFont, normalFont, infoX, infoY + 150);
        }

        private void DrawInfoLine(Graphics g, string label, string value,
            Font labelFont, Font normalFont, int x, int y)
        {
            g.DrawString(label, labelFont, Brushes.Black, x, y);
            g.DrawString(value, normalFont, Brushes.Black, x + 90, y);
        }

        private void DrawImageZoom(Graphics g, Image image, Rectangle box)
        {
            float ratio = Math.Min(
                (float)box.Width / image.Width,
                (float)box.Height / image.Height);

            int width = (int)(image.Width * ratio);
            int height = (int)(image.Height * ratio);
            int x = box.Left + (box.Width - width) / 2;
            int y = box.Top + (box.Height - height) / 2;

            g.DrawImage(image, new Rectangle(x, y, width, height));
        }

        private void btnPreviewPrint_Click(object? sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.Width = 900;
            printPreviewDialog1.Height = 700;
            printPreviewDialog1.ShowDialog();
        }

        private void btnPrint_Click(object? sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            printDialog1.Document = printDocument1;
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage(object? sender, PrintPageEventArgs e)
        {
            if (e.Graphics == null) return;

            StudentCardInfo info = GetStudentInfo();
            Rectangle card = new Rectangle(e.MarginBounds.Left, e.MarginBounds.Top, 520, 320);
            DrawStudentCard(e.Graphics, card, info);
            e.HasMorePages = false;
        }

        private void btnClear_Click(object? sender, EventArgs e)
        {
            txtStudentId.Clear();
            txtFullName.Clear();

            if (cboClass.Items.Count > 0) cboClass.SelectedIndex = 0;
            if (cboFaculty.Items.Count > 0) cboFaculty.SelectedIndex = 0;
            if (cboGender.Items.Count > 0) cboGender.SelectedIndex = 0;

            dtpBirthDate.Value = DateTime.Today;

            picAvatar.Image?.Dispose();
            picAvatar.Image = null;

            pnlCardPreview.Invalidate();
            txtStudentId.Focus();
        }
    }
}