using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DemoWindowApplication.BusinessLogic;
using Microsoft.Reporting.WinForms;

namespace DemoWindowApplication.reports
{
    public partial class frmReportSinhVien : Form
    {
        SinhVienReportBUS svReportBUS = new SinhVienReportBUS();
        KhoaBUS khoaBUS = new KhoaBUS();
        public frmReportSinhVien()
        {
            InitializeComponent();
        }

        private void frmReportSinhVien_Load(object sender, EventArgs e)
        {
            // Gán datasource cho combobox khoa
            DataTable tbKhoa = khoaBUS.LayDSKhoa();
            cboKhoa.DataSource = tbKhoa;
            // Tạo 1 row tất cả cho combobox khoa
            DataRow dr = tbKhoa.NewRow();
            dr["MaKhoa"] = "all"; // gán thuộc tính value
            dr["TenKhoa"] = "Tất cả"; // hiển thị
            tbKhoa.Rows.InsertAt(dr, 0); // insert datarow vào dòng đầu tiên của tbKhoa
            // Hiển thị lên combobox
            cboKhoa.ValueMember = "MaKhoa"; // value trả về
            cboKhoa.DisplayMember = "TenKhoa"; // value hiển thị lên combobox

             // Gắn datasource cho report
            SinhVienBindingSource.DataSource = svReportBUS.LayDSSinhVien();
            this.reportViewerSinhVien.RefreshReport();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            // Lấy mã khoa từ combobox
            string MaKhoa = cboKhoa.SelectedValue.ToString();
            // Lấy tên người lập danh sách
            string NguoiLap = txtNguoiLap.Text;
            // Lấy tên khoa từ combobox
            // Tên khoa nếu là tất cả thì sẽ trả về biến TenKhoa rỗng, ngược lại trả về tên khoa
            string TenKhoa = (cboKhoa.SelectedValue.ToString() == "all") ? "" : cboKhoa.Text;
            // Tạo parameter để add vào report
            IList<ReportParameter> param = new List<ReportParameter>();
            // Thêm parameter TenKhoa vào IList report
            param.Add(new ReportParameter("TenKhoa", TenKhoa));
            // Thêm tên người lập danh sách
            param.Add(new ReportParameter("NguoiLap",NguoiLap));
            // Set parameter cho report
            reportViewerSinhVien.LocalReport.SetParameters(param);
            // Gắn datasource theo khoa cho report
            SinhVienBindingSource.DataSource = svReportBUS.LayDSSinhVienTheoKhoa(MaKhoa);
            // refresh lại report
            reportViewerSinhVien.RefreshReport();
        }
    }
}
