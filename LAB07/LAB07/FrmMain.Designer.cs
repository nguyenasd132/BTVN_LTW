namespace LAB07
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.danhSáchSảnPhẩmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.danhSáchKháchHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnThem = new System.Windows.Forms.ToolStripButton();
            this.btnXoa = new System.Windows.Forms.ToolStripButton();
            this.btnSua = new System.Windows.Forms.ToolStripButton();
            this.btnLamMoi = new System.Windows.Forms.ToolStripButton();
            this.btnTimKiem = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.danhSáchSảnPhẩmToolStripMenuItem,
            this.danhSáchKháchHàngToolStripMenuItem,
            this.đăngXuấtToolStripMenuItem});
            this.menuStrip1.Name = "menuStrip1";
            // 
            // danhSáchSảnPhẩmToolStripMenuItem
            // 
            resources.ApplyResources(this.danhSáchSảnPhẩmToolStripMenuItem, "danhSáchSảnPhẩmToolStripMenuItem");
            this.danhSáchSảnPhẩmToolStripMenuItem.Name = "danhSáchSảnPhẩmToolStripMenuItem";
            this.danhSáchSảnPhẩmToolStripMenuItem.Click += new System.EventHandler(this.danhSáchSảnPhẩmToolStripMenuItem_Click);
            // 
            // danhSáchKháchHàngToolStripMenuItem
            // 
            resources.ApplyResources(this.danhSáchKháchHàngToolStripMenuItem, "danhSáchKháchHàngToolStripMenuItem");
            this.danhSáchKháchHàngToolStripMenuItem.Name = "danhSáchKháchHàngToolStripMenuItem";
            this.danhSáchKháchHàngToolStripMenuItem.Click += new System.EventHandler(this.danhSáchKháchHàngToolStripMenuItem_Click);
            // 
            // đăngXuấtToolStripMenuItem
            // 
            resources.ApplyResources(this.đăngXuấtToolStripMenuItem, "đăngXuấtToolStripMenuItem");
            this.đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            // 
            // toolStrip1
            // 
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnThem,
            this.btnXoa,
            this.btnSua,
            this.btnLamMoi,
            this.btnTimKiem});
            this.toolStrip1.Name = "toolStrip1";
            // 
            // btnThem
            // 
            resources.ApplyResources(this.btnThem, "btnThem");
            this.btnThem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnThem.Name = "btnThem";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXoa
            // 
            resources.ApplyResources(this.btnXoa, "btnXoa");
            this.btnXoa.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            resources.ApplyResources(this.btnSua, "btnSua");
            this.btnSua.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSua.Name = "btnSua";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnLamMoi
            // 
            resources.ApplyResources(this.btnLamMoi, "btnLamMoi");
            this.btnLamMoi.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnTimKiem
            // 
            resources.ApplyResources(this.btnTimKiem, "btnTimKiem");
            this.btnTimKiem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // FrmMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMain";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem danhSáchSảnPhẩmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem danhSáchKháchHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnThem;
        private System.Windows.Forms.ToolStripButton btnXoa;
        private System.Windows.Forms.ToolStripButton btnSua;
        private System.Windows.Forms.ToolStripButton btnLamMoi;
        private System.Windows.Forms.ToolStripButton btnTimKiem;
    }
}