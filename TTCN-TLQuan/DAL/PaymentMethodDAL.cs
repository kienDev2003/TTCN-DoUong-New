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
                {"@Name", paymentMethod.PaymentMethodName }
            };
            return _dB.ExecuteNonQuery("PaymentMethod_Insert", parameter);
        }

        public int Update(PaymentMethod paymentMethod)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>()
            {
                {"@PaymentMethodID", paymentMethod.PaymentMethodID },
                {"@Name", paymentMethod.PaymentMethodName }
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

        public List<PaymentMethod> GetAll()
        {
            List<PaymentMethod> listPaymentMethod = new List<PaymentMethod>();
            using (SqlDataReader reader = _dB.ExecuteReader("PaymentMethod_Select", null))
            {
                while (reader.Read())
                {
                    PaymentMethod paymentMethod = new PaymentMethod();

                    paymentMethod.PaymentMethodID = Convert.ToInt32(reader["PaymentMethodID"]);
                    paymentMethod.PaymentMethodName = Convert.ToString(reader["PaymentMethodName"]);

                    listPaymentMethod.Add(paymentMethod);
                }
            }
            return listPaymentMethod;
        }
    }
}