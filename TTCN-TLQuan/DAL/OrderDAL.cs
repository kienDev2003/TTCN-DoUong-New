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
                {"@OrderID",order.OrderID },
                {"@TableID", order.TableID },
                {"@Date", order.Date },
                {"@TotalMoney", order.TotalMoney },
                {"@StatusServe", order.StatusServe },
                {"@StatusPay", order.StatusPay},
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
                {"@Date", order.Date },
                {"@TotalMoney", order.TotalMoney },
                {"@StatusServe", order.StatusServe },
                {"@StatusPay", order.StatusPay},
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

                    order.OrderID = Convert.ToString(reader["OrderID"]);
                    order.TableID = Convert.ToInt32(reader["TableID"]);
                    order.Date = Convert.ToString(reader["Date"]);
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

        public Order GetByID(string OrderID)
        {
            Order order = new Order();
            Dictionary<string, object> parameter = new Dictionary<string, object>()
            {
                {"@OrderID",OrderID }
            };
            using (SqlDataReader reader = _dB.ExecuteReader("Order_Select_By_ID", parameter))
            {
                if (reader.Read())
                {
                    order.OrderID = Convert.ToString(reader["OrderID"]);
                    order.TableID = Convert.ToInt32(reader["TableID"]);
                    order.Date = Convert.ToString(reader["Date"]);
                    order.TotalMoney = Convert.ToSingle(reader["TotalMoney"]);
                    order.StatusServe = Convert.ToBoolean(reader["StatusServe"]);
                    order.StatusPay = Convert.ToBoolean(reader["StatusPay"]);
                    order.PaymentMethodID = Convert.ToInt32(reader["PaymentMethodID"]);
                    order.PaymentMethodName = Convert.ToString(reader["PaymentMethodName"]);
                }
            }
            return order;
        }

        public List<Order> GetAllNotServe()
        {
            List<Order> listOrder = new List<Order>();
            using (SqlDataReader reader = _dB.ExecuteReader("Order_Select_Not_Serve", null))
            {
                while (reader.Read())
                {
                    Order order = new Order();

                    order.OrderID = Convert.ToString(reader["OrderID"]);
                    order.TableID = Convert.ToInt32(reader["TableID"]);
                    order.Date = Convert.ToString(reader["Date"]);
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

        public List<Order> GetAllNotPay()
        {
            List<Order> listOrder = new List<Order>();
            using (SqlDataReader reader = _dB.ExecuteReader("Order_Select_Not_Pay", null))
            {
                while (reader.Read())
                {
                    Order order = new Order();

                    order.OrderID = Convert.ToString(reader["OrderID"]);
                    order.TableID = Convert.ToInt32(reader["TableID"]);
                    order.Date = Convert.ToString(reader["Date"]);
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

        public Order GetByTableIDAndNotPay(int TableID)
        {
            Order order = new Order();
            Dictionary<string, object> parameter = new Dictionary<string, object>()
            {
                {"@TableID",TableID }
            };
            using (SqlDataReader reader = _dB.ExecuteReader("Order_Select_Table_Not_Pay", parameter))
            {
                if (reader.Read())
                {
                    order.OrderID = Convert.ToString(reader["OrderID"]);
                    order.TableID = Convert.ToInt32(reader["TableID"]);
                    order.Date = Convert.ToString(reader["Date"]);
                    order.TotalMoney = Convert.ToSingle(reader["TotalMoney"]);
                    order.StatusServe = Convert.ToBoolean(reader["StatusServe"]);
                    order.StatusPay = Convert.ToBoolean(reader["StatusPay"]);
                    order.PaymentMethodID = Convert.ToInt32(reader["PaymentMethodID"]);
                    order.PaymentMethodName = Convert.ToString(reader["PaymentMethodName"]);
                }
            }
            return order;
        }
    }
}