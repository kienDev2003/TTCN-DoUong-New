using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TTCN_TLQuan.DAL;
using TTCN_TLQuan.Models;

namespace TTCN_TLQuan.BLL
{
    public class OrderDetailBLL
    {
        private OrderDetailDAL _orderDetailDAL;

        public OrderDetailBLL()
        {
            _orderDetailDAL = new OrderDetailDAL();
        }

        public bool Add(OrderDetail orderDetail)
        {
            if (_orderDetailDAL.Add(orderDetail) > 0) return true;
            return false;
        }

        public bool Update(OrderDetail orderDetail)
        {
            if (_orderDetailDAL.Update(orderDetail) > 0) return true;
            return false;
        }

        public bool Delete(int OrderDetailID)
        {
            if (_orderDetailDAL.Delete(OrderDetailID) > 0) return true;
            return false;
        }

        public List<OrderDetail> GetAll()
        {
            List<OrderDetail> listOrderDetail = new List<OrderDetail>();
            using (SqlDataReader reader = _orderDetailDAL.GetAll())
            {
                while (reader.Read())
                {
                    OrderDetail orderDetail = new OrderDetail();

                    orderDetail.OrderDetailID = Convert.ToInt32(reader["OrderDetailID"]);
                    orderDetail.ProductID = Convert.ToInt32(reader["ProductID"]);
                    orderDetail.ProductName = Convert.ToString(reader["ProductName"]);
                    orderDetail.OrderID = Convert.ToInt32(reader["OrderID"]);
                    orderDetail.Quantity = Convert.ToInt32(reader["Quantity"]);
                    orderDetail.TotalMoney = Convert.ToSingle(reader["TotalMoney"]);

                    listOrderDetail.Add(orderDetail);
                }
            }
            return listOrderDetail;
        }
    }
}