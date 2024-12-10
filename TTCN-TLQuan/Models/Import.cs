using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TTCN_TLQuan.Models
{
    public class Import
    {
        public int ImportID { get; set; }
        public DateTime Date { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }
        public float TotalMoney { get; set; }
    }
}