using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TTCN_TLQuan.Models;

namespace TTCN_TLQuan.DAL
{
    public class InventoryDAL
    {
        private DatabaseConnection _dB;

        public InventoryDAL()
        {
            _dB = new DatabaseConnection();
        }

        public int Add(Inventory inventory)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>()
            {
                {"@InventoryID", inventory.InventoryID },
                {"@UserID", inventory.UserID },
                {"@Date", inventory.Date }
            };
            return _dB.ExecuteNonQuery("Inventory_Insert", parameter);
        }

        public int Update(Inventory inventory)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>()
            {
                {"@InventoryID", inventory.InventoryID },
                {"@UserID", inventory.UserID },
                {"@Date", inventory.Date }
            };
            return _dB.ExecuteNonQuery("Inventory_Update", parameter);
        }

        public List<Inventory> GetAll()
        {
            List<Inventory> listInventory = new List<Inventory>();
            using (SqlDataReader reader = _dB.ExecuteReader("Inventory_Select", null))
            {
                while (reader.Read())
                {
                    Inventory inventory = new Inventory();

                    inventory.InventoryID = Convert.ToString(reader["InventoryID"]);
                    inventory.UserName = Convert.ToString(reader["UserName"]);
                    inventory.Date = Convert.ToString(reader["Date"]);
                    inventory.UserID = Convert.ToInt32(reader["UserID"]);

                    listInventory.Add(inventory);
                }
            }
            return listInventory;
        }

        public int Delete(string InventoryID)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>()
            {
                {"@InventoryID", InventoryID }
            };
            return _dB.ExecuteNonQuery("Inventory_Delete", parameter);
        }
    }
}