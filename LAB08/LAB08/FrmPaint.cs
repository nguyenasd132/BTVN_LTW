using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB08
{
    public partial class FrmPaint : Form
    {
        private readonly DrawSurface canvas = new DrawSurface();
        private readonly ComboBox cboMode = new ComboBox();
        private readonly NumericUpDown nudWidth = new NumericUpDown();
        private readonly Button btnColor = new Button();
        private readonly Button btnUndo = new Button();
        private readonly Button btnClear = new Button();
        private readonly Label lblStatus = new Label();

        private readonly List<DrawItem> items = new List<DrawItem>();
        private DrawItem currentItem;
        private bool isDrawing = false;
        private Color currentColor = Color.Black;


        public FrmPaint()
        {
            Text = "Simple Paint";
            Width = 1000;
            Height = 650;
            StartPosition = FormStartPosition.CenterScreen;

            BuildUserInterface();
            RegisterEvents();
            InitializeComponent();
        }
        private void BuildUserInterface()
        {
            Panel topPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 48,
                BackColor = Color.FromArgb(238, 247, 247)
            };

            cboMode.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMode.Items.AddRange(new object[] { "Pen", "Line", "Rectangle", "Ellipse" });
            cboMode.SelectedIndex = 0;
            cboMode.Width = 120;
            cboMode.Left = 80;
            cboMode.Top = 11;

            nudWidth.Minimum = 1;
            nudWidth.Maximum = 20;
            nudWidth.Value = 3;
            nudWidth.Width = 60;
            nudWidth.Left = 250;
            nudWidth.Top = 12;

            btnColor.Text = "Color";
            btnColor.Left = 320;
            btnColor.Top = 10;
            btnColor.Width = 80;

            btnUndo.Text = "Undo";
            btnUndo.Left = 420;
            btnUndo.Top = 10;
            btnUndo.Width = 80;

            btnClear.Text = "Clear";
            btnClear.Left = 520;
            btnClear.Top = 10;
            btnClear.Width = 80;

            Label lblMode = new Label { Text = "Mode", Left = 15, Top = 16, AutoSize = true };
            Label lblWidth = new Label { Text = "Width", Left = 200, Top = 16, AutoSize = true };

            topPanel.Controls.Add(lblMode);
            topPanel.Controls.Add(cboMode);
            topPanel.Controls.Add(lblWidth);
            topPanel.Controls.Add(nudWidth);
            topPanel.Controls.Add(btnColor);
            topPanel.Controls.Add(btnUndo);
            topPanel.Controls.Add(btnClear);

            lblStatus.Dock = DockStyle.Bottom;
            lblStatus.Height = 26;
            lblStatus.Text = "Ready";
            lblStatus.TextAlign = ContentAlignment.MiddleLeft;

            Controls.Add(canvas);
            Controls.Add(lblStatus);
            Controls.Add(topPanel);
        }

        private void RegisterEvents()
        {
            canvas.Paint += Canvas_Paint;
            canvas.MouseDown += Canvas_MouseDown;
            canvas.MouseMove += Canvas_MouseMove;
            canvas.MouseUp += Canvas_MouseUp;

            btnColor.Click += BtnColor_Click;
            btnUndo.Click += BtnUndo_Click;
            btnClear.Click += BtnClear_Click;
        }

        private DrawMode CurrentMode
        {
            get
            {
                string mode = cboMode.SelectedItem.ToString();
                return (DrawMode)Enum.Parse(typeof(DrawMode), mode);
            }
        }

        private void BtnColor_Click(object sender, EventArgs e)
        {
            using ColorDialog dialog = new ColorDialog();
            dialog.Color = currentColor;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                currentColor = dialog.Color;
                btnColor.BackColor = currentColor;
            }
        }
        private void BtnUndo_Click(object sender, EventArgs e)
        {
            if (items.Count == 0) return;

            items.RemoveAt(items.Count - 1);
            canvas.Invalidate();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Xóa toàn bộ vùng vẽ?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                items.Clear();
                canvas.Invalidate();
            }
        }

        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            isDrawing = true;

            currentItem = new DrawItem
            {
                Mode = CurrentMode,
                Start = e.Location,
                End = e.Location,
                Color = currentColor,
                Width = (float)nudWidth.Value
            };

            if (currentItem.Mode == DrawMode.Pen)
                currentItem.Points.Add(e.Location);
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            lblStatus.Text = $"X = {e.X}, Y = {e.Y}, Items = {items.Count}";

            if (!isDrawing || currentItem == null) return;

            currentItem.End = e.Location;

            if (currentItem.Mode == DrawMode.Pen)
                currentItem.Points.Add(e.Location);

            canvas.Invalidate();
        }
        private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (!isDrawing || currentItem == null) return;

            currentItem.End = e.Location;
            items.Add(currentItem);

            currentItem = null;
            isDrawing = false;
            canvas.Invalidate();
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            foreach (DrawItem item in items)
                DrawOneItem(e.Graphics, item);

            if (currentItem != null)
                DrawOneItem(e.Graphics, currentItem);
        }
        private void DrawOneItem(Graphics g, DrawItem item)
        {
            using Pen pen = new Pen(item.Color, item.Width);
            pen.StartCap = LineCap.Round;
            pen.EndCap = LineCap.Round;
            pen.LineJoin = LineJoin.Round;

            Rectangle rect = GetRectangle(item.Start, item.End);

            switch (item.Mode)
            {
                case DrawMode.Pen:
                    DrawFreePen(g, pen, item.Points);
                    break;
                case DrawMode.Line:
                    g.DrawLine(pen, item.Start, item.End);
                    break;
                case DrawMode.Rectangle:
                    g.DrawRectangle(pen, rect);
                    break;
                case DrawMode.Ellipse:
                    g.DrawEllipse(pen, rect);
                    break;
            }
        }

        private void DrawFreePen(Graphics g, Pen pen, List<Point> points)
        {
            if (points.Count < 2) return;

            for (int i = 1; i < points.Count; i++)
            {
                g.DrawLine(pen, points[i - 1], points[i]);
            }
        }

        private Rectangle GetRectangle(Point start, Point end)
        {
            int x = Math.Min(start.X, end.X);
            int y = Math.Min(start.Y, end.Y);
            int width = Math.Abs(start.X - end.X);
            int height = Math.Abs(start.Y - end.Y);

            return new Rectangle(x, y, width, height);
        }
    }
}
