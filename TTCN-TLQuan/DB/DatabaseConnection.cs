using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace TTCN_TLQuan
{
    public class DatabaseConnection : IDisposable
    {
        private string strConn;
        private SqlConnection conn;
        private bool disposed = false; // Flag để kiểm tra đã dispose chưa.

        public DatabaseConnection()
        {
            strConn = ConfigurationManager.ConnectionStrings["strConn_Local"].ConnectionString;
            conn = new SqlConnection(strConn);
            conn.Open();
        }

        // Phương thức Dispose sẽ được gọi khi bạn muốn giải phóng tài nguyên.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this); // Ngừng gọi destructor
        }

        // Phương thức Dispose nội bộ, cho phép tùy chọn để giải phóng tài nguyên.
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // Nếu đối tượng được Dispose() thủ công, đóng kết nối
                    if (conn != null)
                    {
                        if (conn.State == ConnectionState.Open)
                        {
                            conn.Close();
                        }
                        conn.Dispose();
                        conn = null;
                    }
                }

                disposed = true;
            }
        }

        // Destructor để giải phóng tài nguyên khi đối tượng bị garbage collected
        ~DatabaseConnection()
        {
            Dispose(false); // Gọi Dispose để giải phóng tài nguyên khi đối tượng bị thu hồi
        }

        // Thực thi stored procedure với CommandType = StoredProcedure
        public int ExecuteNonQuery(string procedureName, Dictionary<string, object> parameters)
        {
            if (conn.State == ConnectionState.Closed) conn.Open();

            using (SqlCommand cmd = new SqlCommand(procedureName, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm tham số nếu có
                if (parameters != null)
                {
                    foreach (var param in parameters)
                    {
                        cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                    }
                }

                return cmd.ExecuteNonQuery();
            }
        }

        // Thực thi stored procedure và trả về SqlDataReader
        public SqlDataReader ExecuteReader(string procedureName, Dictionary<string, object> parameters)
        {
            if (conn.State == ConnectionState.Closed) conn.Open();

            using (SqlCommand cmd = new SqlCommand(procedureName, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm tham số nếu có
                if (parameters != null)
                {
                    foreach (var param in parameters)
                    {
                        cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                    }
                }

                return cmd.ExecuteReader();
            }
        }

        // Phương thức đóng kết nối nếu cần
        public void CloseConnection()
        {
            if (conn != null && conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
    }
}