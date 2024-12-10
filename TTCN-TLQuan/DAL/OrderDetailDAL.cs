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
                {"@TotalMoney", orderDetail.TotalMoney }
            };
            return _dB.ExecuteNonQuery("OrderDetail_Insert", parameter);
        }

        public int Update(OrderDetail orderDetail)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>()
            {
                {"@OrderDetailID", orderDetail.OrderDetailID },
                {"@ProductID", orderDetail.ProductID },
                {"@OrderID", orderDetail.OrderID },
                {"@Quantity", orderDetail.Quantity },
                {"@TotalMoney", orderDetail.TotalMoney }
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

        public SqlDataReader GetAll()
        {
            return _dB.ExecuteReader("OrderDetail_Select", null);
        }
    }
}