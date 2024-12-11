using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TTCN_TLQuan.DAL;
using TTCN_TLQuan.Models;

namespace TTCN_TLQuan.BLL
{
    public class RoleBLL
    {
        private RoleDAL _roleDAL;

        public RoleBLL()
        {
            _roleDAL = new RoleDAL();
        }

        public bool Add(string RoleName)
        {
            if (_roleDAL.Add(RoleName) > 0) return true;
            return false;
        }

        public bool Update(Role role)
        {
            if (_roleDAL.Update(role) > 0) return true;
            return false;
        }

        public bool Delete(int RoleID)
        {
            if (_roleDAL.Delete(RoleID) > 0) return true;
            return false;
        }

        public List<Role> GetAll()
        {
            return _roleDAL.GetAll();
        }
    }
}