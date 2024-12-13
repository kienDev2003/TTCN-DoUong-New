using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TTCN_TLQuan.DAL;
using TTCN_TLQuan.Models;

namespace TTCN_TLQuan.BLL
{
    public class ImportDetailBLL
    {
        private ImportDetailDAL _importDetailDAL;

        public ImportDetailBLL()
        {
            _importDetailDAL = new ImportDetailDAL();
        }

        public bool Add(ImportDetail importDetail)
        {
            if (_importDetailDAL.Add(importDetail) > 0) return true;
            return false;
        }

        public bool Update(ImportDetail importDetail)
        {
            if (_importDetailDAL.Update(importDetail) > 0) return true;
            return false;
        }

        public bool Delete(int ImportDetailID)
        {
            if (_importDetailDAL.Delete(ImportDetailID) > 0) return true;
            return false;
        }

        public List<ImportDetail> GetAll()
        {
            return _importDetailDAL.GetAll();
        }

        public List<ImportDetail> GetAllByImportID(string ImportID)
        {
            return _importDetailDAL.GetAllByImportID(ImportID);
        }
    }
}