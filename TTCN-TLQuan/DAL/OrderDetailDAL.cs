using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TTCN_TLQuan.Models;

namespace TTCN_TLQuan.DAL
{
    public class OrderDetailDAL
    {
        private DatabaseConnection _dB;

        public OrderDetailDAL()
        {
            _dB = new DatabaseConnection();
        }

        public int Add(OrderDetail orderDetail)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>()
            {
                {"@ProductID", orderDetail.ProductID },
                {"@OrderID", orderDetail.OrderID },
                {"@Quantity", orderDetail.Quantity },
                {"@TotalMoney", orderDetail.TotalMoney },
                {"@StatusServe", orderDetail.StatusServe }
            };
            return _dB.ExecuteNonQuery("OrderDetail_Insert", parameter);
        }

        public int Update(Models.OrderDetail orderDetail)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>()
            {
                {"@OrderDetailID", orderDetail.OrderDetailID },
                {"@ProductID", orderDetail.ProductID },
                {"@OrderID", orderDetail.OrderID },
                {"@Quantity", orderDetail.Quantity },
                {"@TotalMoney", orderDetail.TotalMoney },
                {"@StatusServe", orderDetail.StatusServe }
            };
            return _dB.ExecuteNonQuery("OrderDetail_Update", parameter);
        }

        public int Delete(int OrderDetailID)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>()
            {
                {"@OrderDetailID",OrderDetailID }
            };
            return _dB.ExecuteNonQuery("OrderDetail_Delete", parameter);
        }

        public List<Models.OrderDetail> GetAll()
        {
            List<Models.OrderDetail> listOrderDetail = new List<Models.OrderDetail>();
            using (SqlDataReader reader = _dB.ExecuteReader("OrderDetail_Select", null))
            {
                while (reader.Read())
                {
                    Models.OrderDetail orderDetail = new Models.OrderDetail();

                    orderDetail.OrderDetailID = Convert.ToInt32(reader["OrderDetailID"]);
                    orderDetail.ProductID = Convert.ToInt32(reader["ProductID"]);
                    orderDetail.ProductName = Convert.ToString(reader["ProductName"]);
                    orderDetail.OrderID = Convert.ToString(reader["OrderID"]);
                    orderDetail.Quantity = Convert.ToInt32(reader["Quantity"]);
                    orderDetail.TotalMoney = Convert.ToSingle(reader["TotalMoney"]);

                    listOrderDetail.Add(orderDetail);
                }
            }
            return listOrderDetail;
        }

        public List<Models.OrderDetail> GetAllByOrderIDNotServe(string OrderID)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>()
            {
                {"@OrderID",OrderID }
            };

            List<Models.OrderDetail> listOrderDetail = new List<Models.OrderDetail>();
            using (SqlDataReader reader = _dB.ExecuteReader("OrderDetail_Select_By_OrderID_Not_Serve", parameter))
            {
                while (reader.Read())
                {
                    Models.OrderDetail orderDetail = new Models.OrderDetail();

                    orderDetail.OrderDetailID = Convert.ToInt32(reader["OrderDetailID"]);
                    orderDetail.ProductID = Convert.ToInt32(reader["ProductID"]);
                    orderDetail.ProductName = Convert.ToString(reader["Name"]);
                    orderDetail.OrderID = Convert.ToString(reader["OrderID"]);
                    orderDetail.Quantity = Convert.ToInt32(reader["Quantity"]);
                    orderDetail.TotalMoney = Convert.ToSingle(reader["TotalMoney"]);

                    listOrderDetail.Add(orderDetail);
                }
            }
            return listOrderDetail;
        }
    }
}