using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TTCN_TLQuan.Models
{
    public class ImportDetail
    {
        public int ImportDetailID { get; set; }
        public int IngredientID { get; set; }
        public string IngredientName { get; set; }
        public int Quantity { get; set; }
        public float TotalMoney { get; set; }
        public int ImportID { get; set; }
    }
}