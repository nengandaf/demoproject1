using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
// Tầng này chỉ giao tiếp với BusinessLogic
using DemoWindowApplication.BusinessLogic;
using DemoWindowApplication.BusinessObject;

namespace DemoWindowApplication
{
    public partial class frmSinhVien : Form
    {
        private SinhVienBUS svBUS = new SinhVienBUS();
        private KhoaBUS khoaBUS = new KhoaBUS();

        public frmSinhVien()
        {
            InitializeComponent();
        }

        private void frmSinhVien_Load(object sender, EventArgs e)
        {
           
            // Load combobox Khoa
            cboKhoa.DataSource = khoaBUS.LayDSKhoa();
            cboKhoa.DisplayMember = "TenKhoa";
            cboKhoa.ValueMember = "MaKhoa";
            // Load combobox GioiTinh
            cboGioiTinh.DataSource = svBUS.LayDSGioiTinh();
            cboGioiTinh.DisplayMember = "NameGT";
            cboGioiTinh.ValueMember = "GioiTinh";
            // Load combobox colum datagrid 
            colGioiTinh.DataSource = svBUS.LayDSGioiTinh();
            colGioiTinh.DisplayMember = "NameGT";
            colGioiTinh.ValueMember = "GioiTinh";

            colMaKhoa.DataSource = khoaBUS.LayDSKhoa();
            colMaKhoa.DisplayMember = "TenKhoa";
            colMaKhoa.ValueMember = "MaKhoa";
           
            // Chắc chắn rằng dataGridview phải được load sau cùng

            // Load dataGridView
            dataGridViewSinhVien.DataSource = svBUS.LayDanhSachSinhVien();
            EnableEditing(false);
        }

        private void dataGridViewSinhVien_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            // dòng hiện tại
            int dong = e.RowIndex;
            // thực hiện binding data lên control, khi click vào row dataGridview
            txtMaSV.Text = dataGridViewSinhVien.Rows[dong].Cells["MaSV"].Value.ToString();
            txtHoTen.Text = dataGridViewSinhVien.Rows[dong].Cells["TenSV"].Value.ToString();
            txtTinh.Text = dataGridViewSinhVien.Rows[dong].Cells["Tinh"].Value.ToString();
            dtPickerNgaySinh.Text = dataGridViewSinhVien.Rows[dong].Cells["NgaySinh"].Value.ToString();
            txtDiaChi.Text = dataGridViewSinhVien.Rows[dong].Cells["DiaChi"].Value.ToString();
            cboGioiTinh.SelectedValue = dataGridViewSinhVien.Rows[dong].Cells["colGioiTinh"].Value.ToString();
            cboKhoa.SelectedValue = dataGridViewSinhVien.Rows[dong].Cells["colMaKhoa"].Value.ToString();
        }

        private void EnableEditing(bool editing)
        {
            // button
            // Khi đang thêm thì nút thêm cũng sẽ ẩn đi
            btnThem.Enabled = !editing;
            btnSua.Enabled = !editing;
            btnXoa.Enabled = !editing;
            btnLuu.Enabled = editing;
            btnKhongLuu.Enabled = editing;
            // textbox, combobox
            txtHoTen.Enabled = editing;
            txtDiaChi.Enabled = editing;
            txtTinh.Enabled = editing;
            dtPickerNgaySinh.Enabled = editing;
            cboGioiTinh.Enabled = editing;
            cboKhoa.Enabled = editing;
            // Data gridview
            dataGridViewSinhVien.Enabled = !editing;
        }
        private void ResetTextValue()
        {
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            txtTinh.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            EnableEditing(true);
            ResetTextValue();
            // Load NextID len textbox MaSV
            txtMaSV.Text = svBUS.NextID();

        }

        private void btnKhongLuu_Click(object sender, EventArgs e)
        {
            EnableEditing(false);
        }
        private SinhVien LayTTSV()
        {
            SinhVien sv = new SinhVien();
            sv.MaSV = txtMaSV.Text;
            sv.TenSV = txtHoTen.Text;
            // Chuyển đổi sang kiểu dữ liệu DateTime
            sv.NgaySinh = Convert.ToDateTime(dtPickerNgaySinh.Value.ToShortDateString());
            sv.GioiTinh = (cboGioiTinh.SelectedValue.ToString() == "True") ? 1 : 0;
            sv.DiaChi = txtDiaChi.Text;
            sv.Tinh = txtTinh.Text;
            sv.MaKhoa = cboKhoa.SelectedValue.ToString();
            return sv;
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {

            SinhVien sv = LayTTSV();
            // Nếu tồn tại mã sv => Sửa
            if (svBUS.CheckExists(sv.MaSV))
            {
                if(svBUS.SuaSV(sv))
                    frmSinhVien_Load(sender, e);
            }
            else // Thêm
            {
                if (svBUS.ThemSV(sv))
                    frmSinhVien_Load(sender, e);
            }
           
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            EnableEditing(true);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa sinh viên: " + txtHoTen.Text + " không?", "Hỏi",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (svBUS.XoaSV(txtMaSV.Text))
                    // load lại form
                    frmSinhVien_Load(sender, e);

            }
        }
    }
}
