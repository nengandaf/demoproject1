using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DemoDataBinding.DataAccessLayer;

namespace DemoDataBinding.BusinessLogic
{
    class KhoaBUS
    {
        ConnectData connData = new ConnectData();
        // Lấy danh sách khoa
        public DataTable LayDS()
        {
            string sql = "SELECT MaKhoa, TenKhoa FROM KHOA";
            return connData.GetDataTable(sql);
        }
    }
}
