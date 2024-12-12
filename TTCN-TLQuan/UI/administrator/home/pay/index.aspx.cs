using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using TTCN_TLQuan.BLL;
using TTCN_TLQuan.Models;

namespace TTCN_TLQuan.UI.administrator.home.pay
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static List<Order> GetAll()
        {
            OrderBLL orderBLL = new OrderBLL();
            return orderBLL.GetAll();
        }

        [WebMethod]
        public static bool Pay(string OrderID, string PaymentMethodID)
        {
            if (Convert.ToInt32(PaymentMethodID) == 1) return false;

            return UpdateStatusPay(OrderID, PaymentMethodID);
        }

        private static bool UpdateStatusPay(string orderID, string paymentMethodID)
        {
            OrderBLL orderBLL = new OrderBLL();
            Order order = orderBLL.GetByID(orderID);

            order.PaymentMethodID = Convert.ToInt32(paymentMethodID);
            order.StatusPay = true;

            return orderBLL.Update(order);
        }
    }
}