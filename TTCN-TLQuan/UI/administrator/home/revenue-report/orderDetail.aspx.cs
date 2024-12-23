using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using TTCN_TLQuan.BLL;
using TTCN_TLQuan.Models;

namespace TTCN_TLQuan.UI.administrator.home.revenue_report
{
    public partial class orderDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static List<OrderDetail> GetAllByOrderID(string OrderID)
        {
            OrderDetailBLL orderDetailBLL = new OrderDetailBLL();
            return orderDetailBLL.GetAllByOrderID(OrderID);
        }
    }
}