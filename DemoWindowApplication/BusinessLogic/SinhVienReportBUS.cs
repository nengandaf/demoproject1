using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DemoWindowApplication.DataAccess;
using System.Data;

namespace DemoWindowApplication.BusinessLogic
{
    class SinhVienReportBUS
    {
        ConnectData connData = new ConnectData();
        public DataTable LayDSSinhVien()
        {
            string sql = "SELECT MaSV, TenSV, NgaySinh, GioiTinh, Tinh FROM SinhVien";
            return connData.GetDataTable(sql);
        }
        public DataTable LayDSSinhVienTheoKhoa(string MaKhoa)
        {
            string sql = "SELECT MaSV, TenSV, NgaySinh, GioiTinh, Tinh FROM SinhVien";
            // ta sẽ thêm 1 row Tất cả vào combobox với giá trị trả về là all
            if (MaKhoa != "all")
                sql += ", Khoa WHERE SinhVien.MaKhoa = Khoa.MaKhoa AND Khoa.MaKhoa = '"+MaKhoa+"'";
            return connData.GetDataTable(sql);
        }
    }
}
