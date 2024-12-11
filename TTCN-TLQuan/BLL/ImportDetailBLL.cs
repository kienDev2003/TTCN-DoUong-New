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
            List<ImportDetail> listImportDetail = new List<ImportDetail>();
            using (SqlDataReader reader = _importDetailDAL.GetAll())
            {
                while (reader.Read())
                {
                    ImportDetail importDetail = new ImportDetail();

                    importDetail.ImportDetailID = Convert.ToInt32(reader["ImportDetailID"]);
                    importDetail.IngredientID = Convert.ToInt32(reader["IngredientID"]);
                    importDetail.IngredientName = Convert.ToString(reader["Name"]);
                    importDetail.Quantity = Convert.ToInt32(reader["Quantity"]);
                    importDetail.TotalMoney = Convert.ToSingle(reader["TotalMoney"]);
                    importDetail.ImportID = Convert.ToInt32(reader["ImportID"]);

                    listImportDetail.Add(importDetail);
                }
            }
            return listImportDetail;
        }
    }
}