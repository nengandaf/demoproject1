namespace DemoWindowApplication
{
    partial class frmMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuHeThong = new System.Windows.Forms.ToolStripMenuItem();
            this.itemHeThongDangNhap = new System.Windows.Forms.ToolStripMenuItem();
            this.itemHeThongDangXuat = new System.Windows.Forms.ToolStripMenuItem();
            this.itemHeThongDoimatKhau = new System.Windows.Forms.ToolStripMenuItem();
            this.itemHeThongQLNguoiDung = new System.Windows.Forms.ToolStripMenuItem();
            this.itemHeThongBackup = new System.Windows.Forms.ToolStripMenuItem();
            this.itemHeThongRestore = new System.Windows.Forms.ToolStripMenuItem();
            this.itemHeThongThoat = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNhapLieu = new System.Windows.Forms.ToolStripMenuItem();
            this.itemNhapLieuQLSV = new System.Windows.Forms.ToolStripMenuItem();
            this.itemNhapLieuDiem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemNhapLieuQLGiaoVien = new System.Windows.Forms.ToolStripMenuItem();
            this.itemNhapLieuQLKhoa = new System.Windows.Forms.ToolStripMenuItem();
            this.menuThongKe = new System.Windows.Forms.ToolStripMenuItem();
            this.itemThongKeDSSinhVien = new System.Windows.Forms.ToolStripMenuItem();
            this.itemThongKeDSGiaoVien = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTroGiup = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusDangNhap = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuHeThong,
            this.menuNhapLieu,
            this.menuThongKe,
            this.menuTroGiup});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(697, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuHeThong
            // 
            this.menuHeThong.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemHeThongDangNhap,
            this.itemHeThongDangXuat,
            this.itemHeThongDoimatKhau,
            this.itemHeThongQLNguoiDung,
            this.itemHeThongBackup,
            this.itemHeThongRestore,
            this.itemHeThongThoat});
            this.menuHeThong.Name = "menuHeThong";
            this.menuHeThong.Size = new System.Drawing.Size(63, 20);
            this.menuHeThong.Text = "&Hệ thống";
            // 
            // itemHeThongDangNhap
            // 
            this.itemHeThongDangNhap.Name = "itemHeThongDangNhap";
            this.itemHeThongDangNhap.Size = new System.Drawing.Size(152, 22);
            this.itemHeThongDangNhap.Text = "Đăng &nhập";
            this.itemHeThongDangNhap.Click += new System.EventHandler(this.itemHeThongDangNhap_Click);
            // 
            // itemHeThongDangXuat
            // 
            this.itemHeThongDangXuat.Name = "itemHeThongDangXuat";
            this.itemHeThongDangXuat.Size = new System.Drawing.Size(152, 22);
            this.itemHeThongDangXuat.Text = "Đăng &xuất";
            this.itemHeThongDangXuat.Click += new System.EventHandler(this.itemHeThongDangXuat_Click);
            // 
            // itemHeThongDoimatKhau
            // 
            this.itemHeThongDoimatKhau.Name = "itemHeThongDoimatKhau";
            this.itemHeThongDoimatKhau.Size = new System.Drawing.Size(152, 22);
            this.itemHeThongDoimatKhau.Text = "Đổi &mật khẩu";
            this.itemHeThongDoimatKhau.Click += new System.EventHandler(this.itemHeThongDoimatKhau_Click);
            // 
            // itemHeThongQLNguoiDung
            // 
            this.itemHeThongQLNguoiDung.Name = "itemHeThongQLNguoiDung";
            this.itemHeThongQLNguoiDung.Size = new System.Drawing.Size(152, 22);
            this.itemHeThongQLNguoiDung.Text = "QL người &dùng";
            // 
            // itemHeThongBackup
            // 
            this.itemHeThongBackup.Name = "itemHeThongBackup";
            this.itemHeThongBackup.Size = new System.Drawing.Size(152, 22);
            this.itemHeThongBackup.Text = "&Backup CSDL";
            // 
            // itemHeThongRestore
            // 
            this.itemHeThongRestore.Name = "itemHeThongRestore";
            this.itemHeThongRestore.Size = new System.Drawing.Size(152, 22);
            this.itemHeThongRestore.Text = "&Restore CSDL";
            // 
            // itemHeThongThoat
            // 
            this.itemHeThongThoat.Name = "itemHeThongThoat";
            this.itemHeThongThoat.Size = new System.Drawing.Size(152, 22);
            this.itemHeThongThoat.Text = "&Thoát";
            // 
            // menuNhapLieu
            // 
            this.menuNhapLieu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemNhapLieuQLSV,
            this.itemNhapLieuDiem,
            this.itemNhapLieuQLGiaoVien,
            this.itemNhapLieuQLKhoa});
            this.menuNhapLieu.Name = "menuNhapLieu";
            this.menuNhapLieu.Size = new System.Drawing.Size(63, 20);
            this.menuNhapLieu.Text = "&Nhập liệu";
            // 
            // itemNhapLieuQLSV
            // 
            this.itemNhapLieuQLSV.Name = "itemNhapLieuQLSV";
            this.itemNhapLieuQLSV.Size = new System.Drawing.Size(134, 22);
            this.itemNhapLieuQLSV.Text = "QL &Sinh viên";
            this.itemNhapLieuQLSV.Click += new System.EventHandler(this.itemQLSV_Click);
            // 
            // itemNhapLieuDiem
            // 
            this.itemNhapLieuDiem.Name = "itemNhapLieuDiem";
            this.itemNhapLieuDiem.Size = new System.Drawing.Size(134, 22);
            this.itemNhapLieuDiem.Text = "QL &Điểm";
            // 
            // itemNhapLieuQLGiaoVien
            // 
            this.itemNhapLieuQLGiaoVien.Name = "itemNhapLieuQLGiaoVien";
            this.itemNhapLieuQLGiaoVien.Size = new System.Drawing.Size(134, 22);
            this.itemNhapLieuQLGiaoVien.Text = "QL &Giáo viên";
            // 
            // itemNhapLieuQLKhoa
            // 
            this.itemNhapLieuQLKhoa.Name = "itemNhapLieuQLKhoa";
            this.itemNhapLieuQLKhoa.Size = new System.Drawing.Size(134, 22);
            this.itemNhapLieuQLKhoa.Text = "QL &Khoa";
            // 
            // menuThongKe
            // 
            this.menuThongKe.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemThongKeDSSinhVien,
            this.itemThongKeDSGiaoVien});
            this.menuThongKe.Name = "menuThongKe";
            this.menuThongKe.Size = new System.Drawing.Size(63, 20);
            this.menuThongKe.Text = "&Thống kê";
            // 
            // itemThongKeDSSinhVien
            // 
            this.itemThongKeDSSinhVien.Name = "itemThongKeDSSinhVien";
            this.itemThongKeDSSinhVien.Size = new System.Drawing.Size(170, 22);
            this.itemThongKeDSSinhVien.Text = "Danh sách &sinh viên";
            // 
            // itemThongKeDSGiaoVien
            // 
            this.itemThongKeDSGiaoVien.Name = "itemThongKeDSGiaoVien";
            this.itemThongKeDSGiaoVien.Size = new System.Drawing.Size(170, 22);
            this.itemThongKeDSGiaoVien.Text = "Danh sách &giáo viên";
            // 
            // menuTroGiup
            // 
            this.menuTroGiup.Name = "menuTroGiup";
            this.menuTroGiup.Size = new System.Drawing.Size(58, 20);
            this.menuTroGiup.Text = "&Trợ giúp";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusDangNhap});
            this.statusStrip1.Location = new System.Drawing.Point(0, 268);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(697, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusDangNhap
            // 
            this.statusDangNhap.ForeColor = System.Drawing.Color.Red;
            this.statusDangNhap.Name = "statusDangNhap";
            this.statusDangNhap.Size = new System.Drawing.Size(87, 17);
            this.statusDangNhap.Text = "Chưa đăng nhập";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 290);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chương trình QLSV";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuHeThong;
        private System.Windows.Forms.ToolStripMenuItem menuNhapLieu;
        private System.Windows.Forms.ToolStripMenuItem itemNhapLieuQLSV;
        private System.Windows.Forms.ToolStripMenuItem menuThongKe;
        private System.Windows.Forms.ToolStripMenuItem menuTroGiup;
        private System.Windows.Forms.ToolStripMenuItem itemHeThongDangNhap;
        private System.Windows.Forms.ToolStripMenuItem itemHeThongDangXuat;
        private System.Windows.Forms.ToolStripMenuItem itemHeThongQLNguoiDung;
        private System.Windows.Forms.ToolStripMenuItem itemHeThongBackup;
        private System.Windows.Forms.ToolStripMenuItem itemHeThongRestore;
        private System.Windows.Forms.ToolStripMenuItem itemHeThongThoat;
        private System.Windows.Forms.ToolStripMenuItem itemNhapLieuDiem;
        private System.Windows.Forms.ToolStripMenuItem itemNhapLieuQLGiaoVien;
        private System.Windows.Forms.ToolStripMenuItem itemNhapLieuQLKhoa;
        private System.Windows.Forms.ToolStripMenuItem itemThongKeDSSinhVien;
        private System.Windows.Forms.ToolStripMenuItem itemThongKeDSGiaoVien;
        private System.Windows.Forms.ToolStripMenuItem itemHeThongDoimatKhau;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusDangNhap;
    }
}

