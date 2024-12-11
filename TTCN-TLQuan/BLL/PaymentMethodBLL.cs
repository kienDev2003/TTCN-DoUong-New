using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TTCN_TLQuan.DAL;
using TTCN_TLQuan.Models;

namespace TTCN_TLQuan.BLL
{
    public class PaymentMethodBLL
    {
        private PaymentMethodDAL _paymentMethodDAL;

        public PaymentMethodBLL()
        {
            _paymentMethodDAL = new PaymentMethodDAL();
        }

        public bool Add(PaymentMethod paymentMethod)
        {
            if (_paymentMethodDAL.Add(paymentMethod) > 0) return true;
            return false;
        }

        public bool Update(PaymentMethod paymentMethod)
        {
            if (_paymentMethodDAL.Update(paymentMethod) > 0) return true;
            return false;
        }

        public bool Delete(int PaymentMethodID)
        {
            if (_paymentMethodDAL.Delete(PaymentMethodID) > 0) return true;
            return false;
        }

        public List<PaymentMethod> GetAll()
        {
            return _paymentMethodDAL.GetAll();
        }
    }
}