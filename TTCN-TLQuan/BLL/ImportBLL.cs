using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using TTCN_TLQuan.DAL;
using TTCN_TLQuan.Models;

namespace TTCN_TLQuan.BLL
{
    public class ImportBLL
    {
        private ImportDAL _importDAL;

        public ImportBLL()
        {
            _importDAL = new ImportDAL();
        }

        public bool Add(Models.Import import)
        {
            if (_importDAL.Add(import) > 0) return true;
            return false;
        }

        public bool Update(Models.Import import)
        {
            if (_importDAL.Update(import) > 0) return true;
            return false;
        }

        public bool Delete(int ImportID)
        {
            if (_importDAL.Delete(ImportID) > 0) return true;
            return false;
        }

        public List<Models.Import> GetAll()
        {
            return _importDAL.GetAll();
        }
    }
}