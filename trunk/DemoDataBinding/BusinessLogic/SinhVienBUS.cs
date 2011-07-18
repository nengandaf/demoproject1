using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DemoDataBinding.DataAccessLayer;
using System.Data.SqlClient;
using System.Data;

namespace DemoDataBinding.BusinessLogic
{
    class SinhVienBUS
    {
        ConnectData connData = new ConnectData();
        // Lấy danh sách sinh viên
        public DataTable LayDS()
        {
            string sql = "SELECT MaSV, TenSV, NgaySinh, GioiTinh, DiaChi, Tinh, MaKhoa"
                +" FROM SINHVIEN";
            return connData.GetDataTable(sql,true);
        }
        // Lấy danh sách giới tính
        public DataTable LayDSGioiTinh()
        {
            string sql = "SELECT DISTINCT GioiTinh, NameGT = CASE GioiTinh WHEN 0 THEN N'Nam' "
                +"WHEN 1 THEN N'Nữ' END FROM SINHVIEN";
            return connData.GetDataTable(sql);
        }
        // Gọi hàm Update từ lớp DataAccess, trả về số records thực hiện được
        public int SaveAll()
        {
            return connData.SaveAll();
        }
        public string NextID()
        {
            string lastID = connData.GetLastID("SINHVIEN", "MaSV");
            return Utilities.NextID(lastID, "SV");
        }
    }
}
