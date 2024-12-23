using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using TTCN_TLQuan.Models;

namespace TTCN_TLQuan.DAL
{
    public class InventoryDetailDAL
    {
        private DatabaseConnection _dB;

        public InventoryDetailDAL()
        {
            _dB = new DatabaseConnection();
        }

        public int Add(InventoryDetail inventoryDetail)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>()
            {
                {"@InventoryID", inventoryDetail.InventoryID },
                {"@IngredientID", inventoryDetail.IngredientID },
                {"@ActualQuantity",inventoryDetail.ActualQuantity },
                {"@NumberOfStock", inventoryDetail.NumberOfSystem }
            };
            return _dB.ExecuteNonQuery("InventoryDetail_Insert", parameter);
        }

        public int Update(InventoryDetail inventoryDetail)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>()
            {
                {"@InventoryDetailID", inventoryDetail.InventoryDetailID},
                {"@InventoryID", inventoryDetail.InventoryID },
                {"@IngredientID", inventoryDetail.IngredientID },
                {"@ActualQuantity",inventoryDetail.ActualQuantity },
                {"@NumberOfStock", inventoryDetail.NumberOfSystem }
            };
            return _dB.ExecuteNonQuery("InventoryDetail_Update", parameter);
        }

        public List<InventoryDetail> GetAllByInventoryID(string InventoryID)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>()
            {
                {"@InventoryID", InventoryID }
            };
            List<InventoryDetail> listInventoryDetail = new List<InventoryDetail>();
            using (SqlDataReader reader = _dB.ExecuteReader("InventoryDetail_Select_By_InventoryID", parameter))
            {
                while (reader.Read())
                {
                    InventoryDetail inventoryDetail = new InventoryDetail();

                    inventoryDetail.InventoryID = Convert.ToString(reader["InventoryID"]);
                    inventoryDetail.InventoryDetailID = Convert.ToInt32(reader["InventoryDetailID"]);
                    inventoryDetail.IngredientID = Convert.ToInt32(reader["IngredientID"]);
                    inventoryDetail.IngredientName = Convert.ToString(reader["Name"]);
                    inventoryDetail.NumberOfSystem = Convert.ToInt32(reader["NumberOfSystem"]);
                    inventoryDetail.ActualQuantity = Convert.ToInt32(reader["ActualQuantity"]);

                    listInventoryDetail.Add(inventoryDetail);
                }
            }
            return listInventoryDetail;
        }

        public int Delete(int InventoryDetailID)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>()
            {
                {"@InventoryDetailID", InventoryDetailID }
            };
            return _dB.ExecuteNonQuery("InventoryDetail_Delete", parameter);
        }
    }
}