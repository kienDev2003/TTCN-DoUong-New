using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TTCN_TLQuan.Models;

namespace TTCN_TLQuan.DAL
{
    public class PaymentMethodDAL
    {
        private DatabaseConnection _dB;

        public PaymentMethodDAL()
        {
            _dB = new DatabaseConnection();
        }

        public int Add(PaymentMethod paymentMethod)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>()
            {
                {"@Name", paymentMethod.Name }
            };
            return _dB.ExecuteNonQuery("PaymentMethod_Insert", parameter);
        }

        public int Update(PaymentMethod paymentMethod)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>()
            {
                {"@PaymentMethodID", paymentMethod.PaymentMethodID },
                {"@Name", paymentMethod.Name }
            };
            return _dB.ExecuteNonQuery("PaymentMethod_Update", parameter);
        }

        public int Delete(int PaymentMethodID)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>()
            {
                {"@PaymentMethodID",PaymentMethodID }
            };
            return _dB.ExecuteNonQuery("PaymentMethod_Delete", parameter);
        }

        public SqlDataReader GetAll()
        {
            return _dB.ExecuteReader("PaymentMethod_Select", null);
        }
    }
}