using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TTCN_TLQuan.Models;

namespace TTCN_TLQuan.DAL
{
    public class OrderDAL
    {
        private DatabaseConnection _dB;

        public OrderDAL()
        {
            _dB = new DatabaseConnection();
        }

        public int Add(Order order)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>()
            {
                {"@TableID", order.TableID },
                {"@Date", order.Date.ToString("yyyy-MM-dd HH:mm:ss:fff") },
                {"@TotalMoney", order.TotalMoney },
                {"@StatusServe", false },
                {"@StatusPay", false},
                {"@PaymentMethodID", order.PaymentMethodID }
            };
            return _dB.ExecuteNonQuery("Order_Insert", parameter);
        }

        public int Update(Order order)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>()
            {
                {"@OrderID", order.OrderID },
                {"@TableID", order.TableID },
                {"@Date", order.Date.ToString("yyyy-MM-dd HH:mm:ss:fff") },
                {"@TotalMoney", order.TotalMoney },
                {"@StatusServe", false },
                {"@StatusPay", false},
                {"@PaymentMethodID", order.PaymentMethodID }
            };
            return _dB.ExecuteNonQuery("Order_Update", parameter);
        }

        public int Delete(int OrderID)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>()
            {
                {"@OrderID",OrderID }
            };
            return _dB.ExecuteNonQuery("Order_Delete", parameter);
        }

        public SqlDataReader GetAll()
        {
            return _dB.ExecuteReader("Order_Select", null);
        }
    }
}