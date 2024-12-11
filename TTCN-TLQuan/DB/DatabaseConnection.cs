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
    public class DatabaseConnection
    {
        private string strConn;
        private SqlConnection conn;

        public DatabaseConnection()
        {
            strConn = ConfigurationManager.ConnectionStrings["strConn_Local"].ConnectionString;
            conn = new SqlConnection(strConn);
            conn.Open();
        }

        public SqlConnection closeConn()
        {
            if (conn != null && conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }
            return conn;
        }

        public int ExecuteNonQuery(string procedureName, Dictionary<string, object> parameters)
        {
            if (conn.State == ConnectionState.Closed) conn.Open();
            using (SqlCommand cmd = new SqlCommand(procedureName, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

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
        public SqlDataReader ExecuteReader(string procedureName, Dictionary<string, object> parameters)
        {
            if (conn.State == ConnectionState.Closed) conn.Open();
            using (SqlCommand cmd = new SqlCommand(procedureName, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

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

    }
}