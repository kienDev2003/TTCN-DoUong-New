using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Web;
using QLBH_TTCN_DoUong;
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

        public List<User> GetAll()
        {
            List<User> listUser = new List<User>();
            using (SqlDataReader reader = _dB.ExecuteReader("User_Select", null))
            {
                while (reader.Read())
                {
                    User user = new User();

                    user.UserID = Convert.ToInt32(reader["UserID"]);
                    user.FullName = Convert.ToString(reader["FullName"]);
                    user.UserName = Convert.ToString(reader["UserName"]);
                    user.Password = Convert.ToString(reader["Password"]);
                    user.Email = Convert.ToString(reader["Email"]);
                    user.Phone = Convert.ToString(reader["Phone"]);
                    user.RoleID = Convert.ToInt32(reader["RoleID"]);
                    user.RoleName = Convert.ToString(reader["RoleName"]);

                    listUser.Add(user);
                }
            }
            return listUser;
        }

        public List<User> GetByFullName(string FullName)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>()
            {
                {"@FullName", FullName }
            };
            List<User> listUser = new List<User>();
            using (SqlDataReader reader = _dB.ExecuteReader("User_Select_By_FullName", parameter))
            {
                while (reader.Read())
                {
                    User user = new User();

                    user.UserID = Convert.ToInt32(reader["UserID"]);
                    user.FullName = Convert.ToString(reader["FullName"]);
                    user.UserName = Convert.ToString(reader["UserName"]);
                    user.Password = Convert.ToString(reader["Password"]);
                    user.Email = Convert.ToString(reader["Email"]);
                    user.Phone = Convert.ToString(reader["Phone"]);
                    user.RoleID = Convert.ToInt32(reader["RoleID"]);
                    user.RoleName = Convert.ToString(reader["RoleName"]);

                    listUser.Add(user);
                }
            }
            return listUser;
        }

        public User GetByID(int UserID)
        {
            User user = new User();

            Dictionary<string, object> parameter = new Dictionary<string, object>()
            {
                {"@UserID",UserID }
            };

            using(SqlDataReader reader = _dB.ExecuteReader("User_Select_By_ID", parameter))
            {
                if (reader.Read())
                {
                    user.UserID = Convert.ToInt32(reader["UserID"]);
                    user.FullName = Convert.ToString(reader["FullName"]);
                    user.UserName = Convert.ToString(reader["UserName"]);
                    user.Password = Convert.ToString(reader["Password"]);
                    user.Email = Convert.ToString(reader["Email"]);
                    user.Phone = Convert.ToString(reader["Phone"]);
                    user.RoleID = Convert.ToInt32(reader["RoleID"]);
                    user.RoleName = Convert.ToString(reader["RoleName"]);
                }
            }
            return user;
        }

        public User Login(string UserName, string Password)
        {
            User user = new User();

            Dictionary<string, object> parameter = new Dictionary<string, object>()
            {
                {"@UserName",UserName },
                {"@Password", Password }
            };

            using (SqlDataReader reader = _dB.ExecuteReader("User_Login", parameter))
            {
                if (reader.Read())
                {
                    user.UserID = Convert.ToInt32(reader["UserID"]);
                    user.FullName = Convert.ToString(reader["FullName"]);
                    user.UserName = Convert.ToString(reader["UserName"]);
                    user.Password = Convert.ToString(reader["Password"]);
                    user.Email = Convert.ToString(reader["Email"]);
                    user.Phone = Convert.ToString(reader["Phone"]);
                    user.RoleID = Convert.ToInt32(reader["RoleID"]);
                    user.RoleName = Convert.ToString(reader["RoleName"]);
                }
            }
            return user;
        }
    }
}