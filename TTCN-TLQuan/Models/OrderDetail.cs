using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace TTCN_TLQuan.Models
{
    public class OrderDetail
    {
        public int OrderDetailID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int OrderID { get; set; }
        public int Quantity { get; set; }
        public float TotalMoney { get; set; }
    }
}