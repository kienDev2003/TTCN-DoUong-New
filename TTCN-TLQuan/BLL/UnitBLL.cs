using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TTCN_TLQuan.DAL;
using TTCN_TLQuan.Models;

namespace TTCN_TLQuan.BLL
{
    public class UnitBLL
    {
        private UnitDAL _unitDAL;

        public UnitBLL()
        {
            _unitDAL = new UnitDAL();
        }

        public bool Add(string UnitName)
        {
            if (_unitDAL.Add(UnitName) > 0) return true;
            return false;
        }

        public bool Update(Unit unit)
        {
            if (_unitDAL.Update(unit) > 0) return true;
            return false;
        }

        public bool Delete(int UnitID)
        {
            if (_unitDAL.Delete(UnitID) > 0) return true;
            return false;
        }

        public List<Unit> GetAll()
        {
            return _unitDAL.GetAll();
        }
    }
}