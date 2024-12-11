using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TTCN_TLQuan.Models;

namespace TTCN_TLQuan.DAL
{
    public class RoleDAL
    {
        private DatabaseConnection _dB;

        public RoleDAL()
        {
            _dB = new DatabaseConnection();
        }

        public int Add(string RoleName)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>()
            {
                {"@Name", RoleName},
            };
            return _dB.ExecuteNonQuery("Role_Insert", parameter);
        }

        public int Update(Role role)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>()
            {
                {"@OrderID", role.RoleID },
                {"@TableID", role.Name }
            };
            return _dB.ExecuteNonQuery("Role_Update", parameter);
        }

        public int Delete(int RoleID)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>()
            {
                {"@RoleID",RoleID }
            };
            return _dB.ExecuteNonQuery("Role_Delete", parameter);
        }

        public SqlDataReader GetAll()
        {
            return _dB.ExecuteReader("Role_Select", null);
        }
    }
}