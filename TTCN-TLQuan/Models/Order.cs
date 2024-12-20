﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TTCN_TLQuan.Models
{
    public class Order
    {
        public Order()
        {
            StatusServe = false;
            StatusPay = false;
        }
        public string OrderID { get; set; }
        public int TableID { get; set; }
        public string Date { get; set; }
        public float TotalMoney { get; set; }
        public bool StatusServe { get; set; }
        public bool StatusPay { get; set; }
        public int PaymentMethodID { get; set; }
        public string PaymentMethodName { get; set; }
    }
}