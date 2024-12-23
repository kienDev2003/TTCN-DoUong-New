using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TTCN_TLQuan.Models
{
    public class InventoryDetail
    {
        public int InventoryDetailID {  get; set; }
        public string InventoryID { get; set; }
        public int IngredientID { get; set; }
        public string IngredientName { get; set; }
        public int NumberOfSystem {  get; set; }
        public int ActualQuantity { get; set; }
    }
}