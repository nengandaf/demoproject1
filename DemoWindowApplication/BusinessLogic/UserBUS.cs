using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DemoWindowApplication.BusinessObject;
using DemoWindowApplication.DataAccess;
using System.Data;
namespace DemoWindowApplication.BusinessLogic
{
    class UserBUS
    {
        private ConnectData connData = new ConnectData();
        public User LayThongTinUser(string username)
        {
            string sql = "SELECT Username, Password, HoTen, a.MaNhom, TenNhom"
                    + " FROM Users a, NhomNguoiDung b WHERE a.MaNhom = b.MaNhom"
                    + " and Username = '"+username+"'";
            DataTable tbUser = connData.GetDataTable(sql);
            User user = new User();
            if (tbUser.Rows.Count > 0)
            {
                DataRow rowUser = tbUser.Rows[0];
                user.Username = rowUser["Username"].ToString();
                user.Password = rowUser["Password"].ToString();
                user.HoTen = rowUser["HoTen"].ToString();
                user.MaNhom = rowUser["MaNhom"].ToString();
                user.TenNhom = rowUser["TenNhom"].ToString();
            }
            else
            {
                user.Username = "";
                user.Password = "";
                user.HoTen = ""; 
                user.MaNhom = ""; 
                user.TenNhom = ""; 
            }
            return user;
        }
        public bool DoiPassword(string password)
        {
            // mã hóa password trước khi update
            password = Utilities.MaHoaMD5(password);
            string sql = "UPDATE Users SET Password = '"+password+"' WHERE Username = '"+Utilities.user.Username+"' ";
            if (connData.ExecuteQuery(sql))
                return true;
            return false;
        }
    }
}
