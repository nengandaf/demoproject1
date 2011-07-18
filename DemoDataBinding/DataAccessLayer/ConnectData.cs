using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DemoDataBinding.DataAccessLayer
{
    class ConnectData
    {
        private SqlConnection conn;
        private DataTable dTable;
        public DataTable DTable { get; set; }
        private SqlDataAdapter dAdapter;
        public SqlDataAdapter DAdapter { get; set; }
        // Tạo constructor
        public ConnectData()
        {
            Connect();
        }
        // Kết nối CSDL
        public void Connect()
        {
            string strConn = @"Data Source=CONGTHUONGIT\SQL2005;Initial Catalog=SinhVienDB;Persist Security Info=True;User ID=sa;Password=sa";
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

        // Tiếp theo ta tạo 1 phương thức lấy DataTable với câu truy vấn truyền vào, và 1 thuộc tính tham số
        // setDataProperties cho phép thay đổi properties DataTable và DataAdapter hay không
        public DataTable GetDataTable(string sql, bool setDataProperties = false)
        { 
            // trường hợp ta muốn thay đổi properties 
            if (setDataProperties)
            {
                // tạo dataAdapter thực hiện câu truy vấn
                dAdapter = new SqlDataAdapter(sql, conn);
                // Đỏ dữ liệu vào DataTable
                dTable = new DataTable();
                dAdapter.Fill(dTable);
                return dTable;
            }
            // trường hợp ta không muốn thay đổi properties
            else
            { 
                // Tạo mới DataAdapter
                SqlDataAdapter dataAdap = new SqlDataAdapter(sql, conn);
                DataTable dataTable = new DataTable();
                dataAdap.Fill(dataTable);
                return dataTable;
            }
        }

        //  Cập nhật dataSource xuống CSDL
        public int  SaveAll()
        { 
            // số lượng các records được thực thi
            int numRecords = 0;
            // Tạo đối tượng Transaction  để thực hiện rollback khi gặp lỗi trong quá trình save
            SqlTransaction sTran = null;
            try
            {
                // mở kết nối
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                // Mở Transaction
                sTran = conn.BeginTransaction();
                // Tạo transaction quản lý SelectCommand
                dAdapter.SelectCommand.Transaction = sTran;
                // tạo đối tượng SqlCommandBuilder quản lý quá trình thay đổi trên DataSource
                SqlCommandBuilder sBuider = new SqlCommandBuilder(dAdapter); // Ta truyền DataAdapter vào
                // Thực hthi cập nhật DataSource xuống CSDL
                numRecords = dAdapter.Update(dTable);
                // Commit data
                sTran.Commit();
            }
            catch (Exception ex)
            {
                // Nếu xảy ra lỗi trong quá trình thêm
                if (sTran != null)
                    sTran.Rollback();
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            // Đóng kết nối khi thực hiện xong
            if (conn.State == ConnectionState.Open)
                conn.Close();
            // Trả về số records thực hiện được
            return numRecords;
        }
        // tableName: Tên của table muốn tìm mã kế tiếp, fieldName tên field mã
        public string GetLastID(string tableName, string fieldName)
        {
            string sql = "SELECT TOP 1 "+fieldName+" FROM "+tableName+" ORDER BY "+fieldName+" DESC";
            DataTable tb = this.GetDataTable(sql);
            // Trả về cột đầu tiên có tên fieldName của dòng đầu tiên DataTable
            return tb.Rows[0][fieldName].ToString();
        }
    }
}
