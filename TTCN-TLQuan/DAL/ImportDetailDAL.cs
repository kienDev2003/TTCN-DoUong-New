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
                {"@TotalMoney", importDetail.TotalMoney },
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

        public SqlDataReader GetAll()
        {
            return _dB.ExecuteReader("ImportDetail_Select", null);
        }
    }
}