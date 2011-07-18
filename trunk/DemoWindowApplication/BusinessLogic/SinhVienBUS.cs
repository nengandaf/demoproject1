using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
// Tầng này chỉ giáo tiếp với DataAccessLayer
using DemoWindowApplication.DataAccess;
using DemoWindowApplication.BusinessObject;


namespace DemoWindowApplication.BusinessLogic
{
    class SinhVienBUS
    {
        ConnectData connData = new ConnectData();
        // Lấy danh sách sinh viên
        public DataTable LayDanhSachSinhVien()
        {
            string sql = "SELECT MaSV, TenSV, NgaySinh, GioiTinh, DiaChi, Tinh, MaKhoa FROM SINHVIEN";
            return connData.GetDataTable(sql);
        }
        // Lấy danh sách giới tính
        public DataTable LayDSGioiTinh()
        {
            string sql = "SELECT DISTINCT GioiTinh, "
                    + "NameGT = CASE GioiTinh WHEN 0 THEN N'NAM' "
                    + "WHEN 1 THEN N'Nữ' END FROM SINHVIEN";
            return connData.GetDataTable(sql);
        }
        // Thêm 1 sinh viên
        public bool ThemSV(SinhVien sv)
        {
            if (KiemTraTruocKhiLuu(sv))
            {
                string sql = string.Format("INSERT INTO SINHVIEN (MaSV, TenSV, NgaySinh, GioiTinh, DiaChi, Tinh, MaKhoa) "
                    + "VALUES ('{0}','{1}','{2}',{3},'{4}','{5}','{6}')", sv.MaSV, sv.TenSV, sv.NgaySinh.ToString("dd-MM-yyyy"), sv.GioiTinh, sv.DiaChi,
                            sv.Tinh, sv.MaKhoa);
                if (connData.ExecuteQuery(sql))
                {
                    MessageBox.Show("Thêm sinh viên thành công", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
            }
            return false;
       }
        public bool CheckExists(string masv)
        {
            if (connData.CheckExistValue("SINHVIEN", "MaSV", masv))
                return true;
            return false;
        }
        // Sửa 1 sinh viên
        public bool SuaSV(SinhVien sv)
        {
            if (KiemTraTruocKhiLuu(sv))
            {
                string sql = string.Format("UPDATE SINHVIEN SET TenSV = '{0}', NgaySinh = '{1}', "
                                    +"GioiTinh = {2}, DiaChi = '{3}', Tinh = '{4}', MaKhoa = '{5}' WHERE MaSV = '{6}' ",
                      sv.TenSV, sv.NgaySinh.ToString("dd-MM-yyyy"), sv.GioiTinh, sv.DiaChi,
                            sv.Tinh, sv.MaKhoa,sv.MaSV);
                if (connData.ExecuteQuery(sql))
                {
                    MessageBox.Show("Sửa sinh viên thành công", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
            }
            return false;
        }
        // Xóa 1 sinh viên
        public bool XoaSV(string masv)
        {
          // Xóa trong bảng Kết quả trước, sau đó đó xóa trong bảng sinhvien
            string sql = "DELETE FROM KETQUA WHERE MaSV in ('" + masv + "') "
                + "DELETE FROM SINHVIEN WHERE MaSV in ('" + masv + "')";
            if(connData.ExecuteQuery(sql))
            {
                MessageBox.Show("Xóa sinh viên thành công!", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            return false;

        }
        // Kiểm tra trước khi lưu
        public bool KiemTraTruocKhiLuu(SinhVien sv)
        {
            if (sv.TenSV.Equals(""))
            {
                MessageBox.Show("Họ tên không hợp lệ!");
                return false;
            }
            if (sv.DiaChi.Equals(""))
            {
                MessageBox.Show("Địa chỉ không hợp lệ!");
                return false;
            }
            if (sv.Tinh.Equals(""))
            {
                MessageBox.Show("Tỉnh không hợp lệ!");
                return false;
            }
            if (sv.NgaySinh.Year < 1985)
            {
                MessageBox.Show("Năm sinh không hợp lệ!");
                return false;
            }
            return true;
        }
        public string NextID()
        {
            return Utilities.NextID(connData.GetLastID("SINHVIEN", "MaSV"), "SV");
        }
    }
}
