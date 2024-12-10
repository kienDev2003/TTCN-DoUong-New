using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace TTCN_TLQuan
{
    public class DatabaseConnection
    {
        private string _connectionString;

        public DatabaseConnection()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["strConn_Local"].ConnectionString;
        }

        public DatabaseConnection(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int ExecuteNonQuery(string ProcName, Dictionary<string, object> parameter)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(ProcName, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    foreach (var param in parameter)
                    {
                        cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                    }

                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public SqlDataReader ExecuteReader(string ProcName, Dictionary<string, object> parameter)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(ProcName, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    foreach (var param in parameter)
                    {
                        cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                    }

                    return cmd.ExecuteReader();
                }
            }
        }

        public object ExecuteScalar(string ProcName, Dictionary<string, object> parameter)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(ProcName, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    foreach (var param in parameter)
                    {
                        cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                    }

                    return cmd.ExecuteScalar();
                }
            }
        }

    }
}