using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TTCN_TLQuan.Models;

namespace TTCN_TLQuan.DAL
{
    public class ImportDetailDAL
    {
        private DatabaseConnection _dB;

        public ImportDetailDAL()
        {
            _dB = new DatabaseConnection();
        }

        public int Add(ImportDetail importDetail)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>()
            {
                {"@IngredientID", importDetail.IngredientID },
                {"@Quantity", importDetail.Quantity },
                {"@ImportID", importDetail.ImportID }
            };
            return _dB.ExecuteNonQuery("ImportDetail_Insert", parameter);
        }

        public int Update(ImportDetail importDetail)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>()
            {
                {"@ImportDetailID", importDetail.ImportDetailID },
                {"@IngredientID", importDetail.IngredientID },
                {"@Quantity", importDetail.Quantity },
                {"@TotalMoney", importDetail.TotalMoney },
                {"@ImportID", importDetail.ImportID }
            };
            return _dB.ExecuteNonQuery("ImportDetail_Update", parameter);
        }

        public int Delete(int ImportDetailID)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>()
            {
                {"@ImportDetailID",ImportDetailID }
            };
            return _dB.ExecuteNonQuery("ImportDetail_Delete", parameter);
        }

        public List<ImportDetail> GetAll()
        {
            List<ImportDetail> listImportDetail = new List<ImportDetail>();
            using (SqlDataReader reader = _dB.ExecuteReader("ImportDetail_Select", null))
            {
                while (reader.Read())
                {
                    ImportDetail importDetail = new ImportDetail();

                    importDetail.ImportDetailID = Convert.ToInt32(reader["ImportDetailID"]);
                    importDetail.IngredientID = Convert.ToInt32(reader["IngredientID"]);
                    importDetail.IngredientName = Convert.ToString(reader["Name"]);
                    importDetail.Quantity = Convert.ToInt32(reader["Quantity"]);
                    importDetail.TotalMoney = Convert.ToSingle(reader["TotalMoney"]);
                    importDetail.ImportID = Convert.ToString(reader["ImportID"]);

                    listImportDetail.Add(importDetail);
                }
            }
            return listImportDetail;
        }

        public List<ImportDetail> GetAllByImportID(string ImportID)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>()
            {
                {"@ImportID",ImportID }
            };

            List<ImportDetail> listImportDetail = new List<ImportDetail>();
            using (SqlDataReader reader = _dB.ExecuteReader("ImportDetail_Select_By_ImportID", parameter))
            {
                while (reader.Read())
                {
                    ImportDetail importDetail = new ImportDetail();

                    importDetail.ImportDetailID = Convert.ToInt32(reader["ImportDetailID"]);
                    importDetail.IngredientID = Convert.ToInt32(reader["IngredientID"]);
                    importDetail.IngredientName = Convert.ToString(reader["Name"]);
                    importDetail.Quantity = Convert.ToInt32(reader["Quantity"]);
                    importDetail.TotalMoney = Convert.ToSingle(reader["TotalMoney"]);
                    importDetail.ImportID = Convert.ToString(reader["ImportID"]);
                    importDetail.UnitName = Convert.ToString(reader["UnitName"]);

                    listImportDetail.Add(importDetail);
                }
            }
            return listImportDetail;
        }
    }
}