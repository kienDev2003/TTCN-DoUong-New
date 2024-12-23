using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TTCN_TLQuan.DAL;
using TTCN_TLQuan.Models;

namespace TTCN_TLQuan.BLL
{
    public class InventoryBLL
    {
        private InventoryDAL _inventoryDAL;

        public InventoryBLL()
        {
            _inventoryDAL = new InventoryDAL();
        }

        public bool Add(Inventory inventory)
        {
            if (_inventoryDAL.Add(inventory) > 0) return true;
            return false;
        }

        public bool Update(Inventory inventory)
        {
            if (_inventoryDAL.Update(inventory) > 0) return true;
            return false;
        }

        public bool Delete(string InventoryID)
        {
            if (_inventoryDAL.Delete(InventoryID) > 0) return true;
            return false;
        }

        public List<Inventory> GetAll()
        {
            return _inventoryDAL.GetAll();
        }
    }
}