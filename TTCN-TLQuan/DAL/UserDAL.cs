using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Web;
using TTCN_TLQuan.Models;

namespace TTCN_TLQuan.DAL
{
    public class UserDAL
    {
        private DatabaseConnection _dB;

        public UserDAL()
        {
            _dB = new DatabaseConnection();
        }

        public int Add(User user)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>()
            {
                {"@FullName", user.FullName },
                {"@UserName", user.UserName },
                {"@Password", user.Password},
                {"@RoleID", user.RoleID },
                {"@Email", user.Email},
                {"@Phone", user.Phone }
            };
            return _dB.ExecuteNonQuery("User_Insert", parameter);
        }

        public int Update(User user)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>()
            {
                {"@UserID", user.UserID },
                {"@FullName", user.FullName },
                {"@UserName", user.UserName },
                {"@Password", user.Password},
                {"@RoleID", user.RoleID },
                {"@Email", user.Email},
                {"@Phone", user.Phone }
            };
            return _dB.ExecuteNonQuery("User_Update", parameter);
        }

        public int Delete(int UserID)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>()
            {
                {"@UserID",UserID }
            };
            return _dB.ExecuteNonQuery("User_Delete", parameter);
        }

        public SqlDataReader GetAll()
        {
            return _dB.ExecuteReader("User_Select", null);
        }
    }
}