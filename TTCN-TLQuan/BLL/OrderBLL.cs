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
            return _orderDAL.GetAll();
        }

        public Order GetByID(string OrderID)
        {
            return _orderDAL.GetByID(OrderID);
        }

        public List<Order> GetAllNotServe()
        {
            return _orderDAL.GetAllNotServe();
        }

        public List<Order> GetAllNotPay()
        {
            return _orderDAL.GetAllNotPay();
        }
        public Order GetByTableIDAndNotPay(int TableID)
        {
            return _orderDAL.GetByTableIDAndNotPay(TableID);
        }
    }
}