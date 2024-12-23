using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TTCN_TLQuan.DAL;
using TTCN_TLQuan.Models;

namespace TTCN_TLQuan.BLL
{
    public class InventoryDetailBLL
    {
        private InventoryDetailDAL _inventoryDetailDAL;

        public InventoryDetailBLL()
        {
            _inventoryDetailDAL = new InventoryDetailDAL();
        }

        public bool Add(InventoryDetail inventoryDetail)
        {
            if (_inventoryDetailDAL.Add(inventoryDetail) > 0) return true;
            return false;
        }

        public bool Update(InventoryDetail inventoryDetail)
        {
            if (_inventoryDetailDAL.Update(inventoryDetail) > 0) return true;
            return false;
        }

        public bool Delete(int InventoryDetailID)
        {
            if (_inventoryDetailDAL.Delete(InventoryDetailID) > 0) return true;
            return false;
        }

        public List<InventoryDetail> GetAllByInventoryID(string InventoryID)
        {
            return _inventoryDetailDAL.GetAllByInventoryID(InventoryID);
        }
    }
}