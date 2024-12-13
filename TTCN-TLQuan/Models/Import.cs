using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TTCN_TLQuan.Models
{
    public class Import
    {
        public string ImportID { get; set; }
        public string Date { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }
        public float TotalMoney { get; set; }
    }
}