using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TTCN_TLQuan.Models
{
    public class Inventory
    {
        public string InventoryID { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Date {  get; set; }
    }
}