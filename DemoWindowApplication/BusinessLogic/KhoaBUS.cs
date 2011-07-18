using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DemoWindowApplication.DataAccess;

namespace DemoWindowApplication.BusinessLogic
{
    class KhoaBUS
    {
        ConnectData connData = new ConnectData();
        // Lấy danh sách khoa
        public DataTable LayDSKhoa()
        {
            string sql = "SELECT MaKhoa, TenKhoa FROM Khoa";
            return connData.GetDataTable(sql);
        }
    }
}
