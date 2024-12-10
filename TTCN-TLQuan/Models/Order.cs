using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TTCN_TLQuan.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public int TableID { get; set; }
        public DateTime Date { get; set; }
        public float TotalMoney { get; set; }
        public bool StatusServe { get; set; }
        public bool StatusPay {  get; set; }
        public int PaymentMethodID { get; set; }
    }
}