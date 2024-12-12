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

        public bool AddList(List<OrderDetail> orderDetails)
        {
            foreach(OrderDetail orderDetail in orderDetails)
            {
                if (Add(orderDetail)) continue;
                return false;
            }

            return true;
        }

        public bool Update(OrderDetail orderDetail)
        {
            if (_orderDetailDAL.Update(orderDetail) > 0) return true;
            return false;
        }

        public bool UpdateList(List<OrderDetail> orderDetails)
        {
            foreach (OrderDetail orderDetail in orderDetails)
            {
                if (Update(orderDetail)) continue;
                return false;
            }
            return true;
        }

        public bool Delete(int OrderDetailID)
        {
            if (_orderDetailDAL.Delete(OrderDetailID) > 0) return true;
            return false;
        }

        public List<OrderDetail> GetAll()
        {
            return _orderDetailDAL.GetAll();
        }

        public List<OrderDetail> GetAllByOrderIDNotServe(string OrderID)
        {
            return _orderDetailDAL.GetAllByOrderIDNotServe(OrderID);
        }
    }
}