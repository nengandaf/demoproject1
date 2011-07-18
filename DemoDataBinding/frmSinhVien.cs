using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
// Sử dụng tầng BusInessLogic
using DemoDataBinding.BusinessLogic;

namespace DemoDataBinding
{
    public partial class frmSinhVien : Form
    {
        // properties 
        SinhVienBUS svBUS = new SinhVienBUS();
        KhoaBUS khoaBUS = new KhoaBUS();
        // Ta lấy danh sách SV dùng chung
        DataTable tbSV;

        public frmSinhVien()
        {
            InitializeComponent();
        }

        private void frmSinhVien_Load(object sender, EventArgs e)
        {
            // Load comboxbox Khoa và giới tính
            cboGioiTinh.DataSource = svBUS.LayDSGioiTinh();
            cboGioiTinh.ValueMember = "GioiTinh"; // trả về giá trị của combobox
            cboGioiTinh.DisplayMember = "NameGT"; // hiển thị giá trị lên combobox

            cboKhoa.DataSource = khoaBUS.LayDS();
            cboKhoa.ValueMember = "MaKhoa";
            cboKhoa.DisplayMember = "TenKhoa";

            // Load combobox khoa và giới tính lên DataGridView trước khi load DataGridView
            colGioiTinh.DataSource = svBUS.LayDSGioiTinh();
            colGioiTinh.ValueMember = "GioiTinh"; // trả về giá trị của combobox
            colGioiTinh.DisplayMember = "NameGT"; // hiển thị giá trị lên combobox

            colKhoa.DataSource = khoaBUS.LayDS();
            colKhoa.ValueMember = "MaKhoa";
            colKhoa.DisplayMember = "TenKhoa";

            // Cuối cùng ta thực hiện binding lên control
            // ta tạo đối tượng binding source để quản lý DataGridView và các control
            // Đối tượng này rất quan trọng, nó sẽ thay đổi trực tiếp đến DataSource bởi các
            // thao tác của người dùng
            BindingSource bdSource = new BindingSource();
            tbSV = svBUS.LayDS();
            bdSource.DataSource = tbSV;
            // Tiếp theo ta sẽ binding Data lên các control
            txtMaSV.DataBindings.Add("Text", bdSource, "MaSV");
            txtTenSV.DataBindings.Add("Text", bdSource, "TenSV");
            dateTimePickerNgaySinh.DataBindings.Add("Value", bdSource, "NgaySinh");
            cboGioiTinh.DataBindings.Add("SelectedValue", bdSource, "GioiTinh");
            txtDiaChi.DataBindings.Add("Text", bdSource, "DiaChi");
            txtTinh.DataBindings.Add("Text", bdSource, "Tinh");
            cboKhoa.DataBindings.Add("SelectedValue", bdSource, "MaKhoa");
            // Gắn bindingNavigator
            bindingNavigatorSV.BindingSource = bdSource;
            // Và cuối cùng ta binding dataGridView
            dataGridViewSV.DataSource = bdSource;
        }

        private void bindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            // ta sẽ xử lý sự kiện Click cho nút save
            if (MessageBox.Show("Bạn có muốn lưu những thay đổi?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    == DialogResult.Yes)
            { 
                // Ta thực hiện Update
                int numRecords = svBUS.SaveAll();
                if (numRecords > 0)
                    MessageBox.Show("Lưu thành công " + numRecords + " record(s)!");
                else
                    MessageBox.Show("Không có dữ liệu thay đổi!");
            
            }
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            // ta sẽ xử lý sự kiện click cho nút thêm mới
            // Ta sẽ tạo 1 DataRow mới có kiểu dữ liệu là Datatable Sinhvien hiện tại
            // ta sửa lại 1 chút ở phương thức load form
            DataRow dr = tbSV.NewRow();
            // thêm nextID (MaSV) cho dataRow
            dr["MaSV"] = svBUS.NextID();
            // Ngoài ra nếu bạn muốn thêm những giá trị mặc định cho dòng mới này, thì bạn thêm
            // tại đây
            dr["TenSV"] = "";
            dr["NgaySinh"] = DateTime.Today;
            dr["GioiTinh"] = false;
            dr["DiaChi"] = "";
            dr["Tinh"] = "";
            dr["MaKhoa"] = "";
            tbSV.Rows.Add(dr);
            // Di chuyển xuống cuối danh sách
            bindingNavigatorSV.BindingSource.MoveLast();
        }
     
    }
}
