using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TTCN_TLQuan.DAL;
using TTCN_TLQuan.Models;

namespace TTCN_TLQuan.BLL
{
    public class OrderBLL
    {
        private OrderDAL _orderDAL;

        public OrderBLL()
        {
            _orderDAL = new OrderDAL();
        }

        public bool Add(Order order)
        {
            if (_orderDAL.Add(order) > 0) return true;
            return false;
        }

        public bool Update(Order order)
        {
            if (_orderDAL.Update(order) > 0) return true;
            return false;
        }

        public bool Delete(int OrderID)
        {
            if (_orderDAL.Delete(OrderID) > 0) return true;
            return false;
        }

        public List<Order> GetAll()
        {
            List<Order> listOrder = new List<Order>();
            using (SqlDataReader reader = _orderDAL.GetAll())
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