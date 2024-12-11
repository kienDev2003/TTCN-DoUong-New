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
                {"@RoleName", RoleName},
            };
            return _dB.ExecuteNonQuery("Role_Insert", parameter);
        }

        public int Update(Role role)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>()
            {
                {"@RoleID", role.RoleID },
                {"@RoleName", role.RoleName }
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

        public List<Role> GetAll()
        {
            List<Role> listRole = new List<Role>();
            using (SqlDataReader reader = _dB.ExecuteReader("Role_Select", null))
            {
                while (reader.Read())
                {
                    Role role = new Role();

                    role.RoleID = Convert.ToInt32(reader["RoleID"]);
                    role.RoleName = Convert.ToString(reader["RoleName"]);

                    listRole.Add(role);
                }
            }
            return listRole;
        }
    }
}