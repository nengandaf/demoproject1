using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DemoWindowApplication.Components;
using DemoWindowApplication.BusinessLogic;
using DemoWindowApplication.BusinessObject;


namespace DemoWindowApplication
{
    public partial class frmMain : Form
    {
        // properties
        frmDangNhap fdn = null;
        frmChangePassword fcp = null;
        UserBUS userBus = new UserBUS();

        public frmMain()
        {
            InitializeComponent();
        }


    



        #region Các hàm xử lý login và phân quyền
        private void DisableMenuLogin(bool logged, string MaNhomNguoiDung = "N001")
        {
            // nếu đăng nhập thành công => tắt menu đăng nhập
            itemHeThongDangNhap.Enabled = !logged;
            // nếu đăng nhập thành công => bật menu đăng xuất
            itemHeThongDangXuat.Enabled = logged;
            // mặc định nếu ĐN thành công => bật hết menu còn lại
            itemHeThongDoimatKhau.Enabled = logged;
            itemHeThongQLNguoiDung.Enabled = logged;
            itemHeThongBackup.Enabled = logged;
            itemHeThongRestore.Enabled = logged;
            // menu nhập liệu
            itemNhapLieuQLSV.Enabled = logged;
            itemNhapLieuQLGiaoVien.Enabled = logged;
            itemNhapLieuDiem.Enabled = logged;
            itemNhapLieuQLKhoa.Enabled = logged;
            // menu Thống kê
            itemThongKeDSGiaoVien.Enabled = logged;
            itemThongKeDSSinhVien.Enabled = logged;
            // phân quyền theo nhóm
            switch (MaNhomNguoiDung)
            { 
                // Nhóm administrator => không làm ẩn menu
                case "N001" : break;
                // Nhóm giáo vụ => Ẩn 1 số menu không thuộc nhóm giáo vụ
                case "N002": HienThiGiaoVu(); break;
            }

        }

        // Tiếp theo ta xây dựng phương thức hiển thị menu tùy theo nhóm người dùng
        private void HienThiGiaoVu()
        { 
            // Tại đây ta sẽ viết các thuộc tính ẩn menu cho nhóm giáo vụ
            itemHeThongQLNguoiDung.Enabled = false; // ẩn QL người dùng
            itemHeThongBackup.Enabled = false; // ẩn backup
            itemHeThongRestore.Enabled = false; // ẩn restore
            itemNhapLieuQLGiaoVien.Enabled = false; // ẩn QL giáo viên
            itemNhapLieuQLKhoa.Enabled = false; // ẩn QL Khoa
            itemThongKeDSGiaoVien.Enabled = false; // ẩn Thống kê danh sách giáo viên
        }


        #endregion


        private void itemQLSV_Click(object sender, EventArgs e)
        {
            frmSinhVien fsv = new frmSinhVien();
            fsv.MdiParent = this;
            fsv.Show();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
          // mặc định khi load lên
            DisableMenuLogin(false); // disable all menu
        }

        private void itemHeThongDangNhap_Click(object sender, EventArgs e)
        {
            // Set lại trạng thái status menu
            statusDangNhap.Text = "Chưa đăng nhập";
            int numsErrorPassword = 0;
            // Tạo biến continues
            Cont:
            // Kiểm tra nếu frm đăng nhập được mở hay đóng, nếu đóng thì ta new
            if (fdn == null || fdn.IsDisposed)
                fdn = new frmDangNhap();
            // show dialog form đăng nhập
            if (fdn.ShowDialog() == DialogResult.OK)
            { 
                // Gọi hàm đăng nhập
                // Gán cho biến user dùng chung trong lớp Utilities
                string username = fdn.txtUsername.Text;
                string password = fdn.txtPassword.Text;
                // Trước tiên ta nên kiểm tra username và password có hợp lệ hay không?
                if (username.Equals(""))
                {
                    // Gán thông báo cho label Thông báo
                    fdn.lblTrangThaiLogin.Text = "Username không hợp lệ!";
                    // Quay ngược lên đăng nhập tiếp
                    goto Cont;
                }
                if (password.Equals(""))
                {
                    // Gán thông báo cho label Thông báo
                    fdn.lblTrangThaiLogin.Text = "Password không hợp lệ!";
                    // Quay ngược lên đăng nhập tiếp
                    goto Cont;
                }
                // Lúc này mới lấy thông tin user
                Utilities.user = userBus.LayThongTinUser(username);
                // Trường hợp user không tồn tại
                if (Utilities.user.Username.Equals(""))
                {
                    // Gán thông báo cho label Thông báo
                    fdn.lblTrangThaiLogin.Text = "User không tồn tại!";
                    // Quay ngược lên đăng nhập tiếp
                    goto Cont;
                }
                // trường hợp password sai
                if (Utilities.user.Password != Utilities.MaHoaMD5(password))
                {
                    // Gán thông báo cho label Thông báo
                    fdn.lblTrangThaiLogin.Text = "Password sai!";
                    numsErrorPassword++;
                    if (numsErrorPassword == 3)
                        this.Close();
                    // Quay ngược lên đăng nhập tiếp
                    goto Cont;
                }
                // trường hợp đăng nhập thành công
                // Set lại menu theo quyền của user
                DisableMenuLogin(true, Utilities.user.MaNhom);
                // Gán status cho menu
                statusDangNhap.Text = Utilities.user.TenNhom+":"+Utilities.user.HoTen;
            }

        }

        private void itemHeThongDangXuat_Click(object sender, EventArgs e)
        {
            // Khởi tạo lại biến user dùng chung
            User user = new User();
            Utilities.user = user;
            // Disable menu
            DisableMenuLogin(false);
            // Mở lại form đăng nhập
            itemHeThongDangNhap_Click(sender, e);
        }

        private void itemHeThongDoimatKhau_Click(object sender, EventArgs e)
        {
        // Tạo biến continues
        Cont:
            if (fcp == null || fcp.IsDisposed)
                fcp = new frmChangePassword();
            if (fcp.ShowDialog() == DialogResult.OK)
            {
                string oldPass = fcp.txtOldPass.Text;
                string newPass = fcp.txtNewPass.Text;
                string reNewPass = fcp.txtReNewPass.Text;
                if (oldPass.Equals("") || newPass.Equals("") || reNewPass.Equals(""))
                {
                    fcp.lblThongBao.Text = "Bạn chưa điền đủ thông tin!";
                    goto Cont;
                }
                if (newPass != reNewPass)
                {
                    fcp.lblThongBao.Text = "Mật khẩu không trùng khớp!";
                    goto Cont;
                }
                // Kiểm tra mật khẩu cũ có khớp hay không
                if (Utilities.MaHoaMD5(oldPass) != Utilities.user.Password)
                {
                    fcp.lblThongBao.Text = "Mật khẩu cũ không đúng!";
                    goto Cont;
                }
                // trường hợp thỏa tất cả, đổi mật khẩu
                if (userBus.DoiPassword(newPass))
                {
                    MessageBox.Show("Đổi password thành công");
                    // Cho đăng nhập lại
                    itemHeThongDangXuat_Click(sender, e);
                }
            }
        }

      
    }
}
