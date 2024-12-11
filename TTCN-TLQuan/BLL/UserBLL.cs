using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using QLBH_TTCN_DoUong;
using TTCN_TLQuan.DAL;
using TTCN_TLQuan.Models;

namespace TTCN_TLQuan.BLL
{
    public class UserBLL
    {
        private UserDAL _userDAL;

        public UserBLL()
        {
            _userDAL = new UserDAL();
        }

        public bool Add(User user)
        {
            user.Password = Common.MD5_Hash(user.Password + user.UserName);

            if (_userDAL.Add(user) > 0) return true;
            return false;
        }

        public bool Update(User user)
        {
            if (_userDAL.Update(user) > 0) return true;
            return false;
        }

        public bool Delete(int UserID)
        {
            if (_userDAL.Delete(UserID) > 0) return true;
            return false;
        }

        public List<User> GetAll()
        {
            return _userDAL.GetAll();
        }

        public List<User> GetByFullName(string FullName)
        {
            return _userDAL.GetByFullName(FullName);
        }

        public User GetByID(int UserID)
        {
            return _userDAL.GetByID(UserID);
        }

        public bool ChangePassword(int UserID, string newPassword)
        {
            User user = GetByID(UserID);
            user.Password = Common.MD5_Hash(newPassword+user.UserName);

            if(_userDAL.ChangPassword(user) > 0) return true;
            else return false;
        }

        public User Login(string UserName,string Password)
        {
            Password = Common.MD5_Hash(Password + UserName);
            return _userDAL.Login(UserName,Password);
        }
    }
}