using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace DemoWindowApplication.DataAccess
{
    class ConnectData
    {
        private SqlConnection conn;
        private SqlDataAdapter dataAp;
        private DataTable dataTable;
        // Tạo constructor goi kết nối khi new lớp ConnectData
        public ConnectData()
        {
            Connect();
        }
        // Ket noi
        public void Connect()
        {
            string strConn = @"Data Source=CONGTHUONGIT\SQL2005;Initial Catalog=SinhVienDB;User ID=sa;Password=sa";
            try
            {
                conn = new SqlConnection(strConn);
                conn.Open();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: "+ex.Message);
            }
        }
        // Hàm lấy dữ liệu DataTable từ câu truy vấn truyền vào
        public DataTable GetDataTable(string sql)
        {
            // Tạo dataApdapter, thực hiện câu lệnh query
            dataAp = new SqlDataAdapter(sql, conn);
            // Đổ dữ liệu vào DataTable
            dataTable = new DataTable();
            dataAp.Fill(dataTable);
            return dataTable;
        }

        // Hàm thực hiện câu truy vấn INSERT, UPDATE, DELETE trả về thực hiện thành công hay ko
        public bool ExecuteQuery(string sql)
        {
            int numRecordsEffect = 0;
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                SqlCommand cmd = new SqlCommand(sql,conn);
                numRecordsEffect = cmd.ExecuteNonQuery();
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi: "+ex.Message);
            }
            if (numRecordsEffect > 0)
                return true;
            return false;
        }
        // Lấy mã cuối cùng
        public string GetLastID(string nameTable, string nameFiled)
        {
            string sql = "SELECT TOP 1 "+nameFiled+" FROM "+nameTable+" ORDER BY "+nameFiled+" DESC";
            // thực hiện câu truy vấn trên
            GetDataTable(sql);
            return dataTable.Rows[0][nameFiled].ToString();
        }
        public bool CheckExistValue(string nameTable, string nameFiled, string value)
        {
            string sql = "SELECT * FROM "+nameTable+" WHERE "+nameFiled+" = '"+value+"'";
            GetDataTable(sql);
            // Đếm số dòng trả về, nếu > 0  tức tồn tại value
            if (dataTable.Rows.Count > 0)
                return true;
           return false;
        }
    }
}
