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

        public List<Order> GetAll()
        {
            List<Order> listOrder = new List<Order>();
            using (SqlDataReader reader = _dB.ExecuteReader("Order_Select", null))
            {
                while (reader.Read())
                {
                    Order order = new Order();

                    order.OrderID = Convert.ToInt32(reader["OrderID"]);
                    order.TableID = Convert.ToInt32(reader["TableID"]);
                    order.Date = Convert.ToDateTime(reader["Date"]);
                    order.TotalMoney = Convert.ToSingle(reader["TotalMoney"]);
                    order.StatusServe = Convert.ToBoolean(reader["StatusServe"]);
                    order.StatusPay = Convert.ToBoolean(reader["StatusPay"]);
                    order.PaymentMethodID = Convert.ToInt32(reader["PaymentMethodID"]);
                    order.PaymentMethodName = Convert.ToString(reader["PaymentMethodName"]);

                    listOrder.Add(order);
                }
            }
            return listOrder;
        }
    }
}