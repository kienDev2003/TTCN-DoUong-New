using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using TTCN_TLQuan.BLL;
using TTCN_TLQuan.Models;

namespace TTCN_TLQuan.UI.bar
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string itemHtml = getListOrder();
            list_order.Controls.Clear();
            LiteralControl literalControl = new LiteralControl(itemHtml);
            list_order.Controls.Add(literalControl);
        }

        [WebMethod]
        public static string getListOrder()
        {
            string html = "";
            OrderBLL orderBLL = new OrderBLL();

            List<Order> orders = new List<Order>();

            orders = orderBLL.GetAllNotServe();

            foreach (var order in orders)
            {
                string itemTemp = $"<li class=\"item\"><a href=\"orderDetail.aspx?orderID={order.OrderID}&tableID={order.TableID}\"><img src=\"./assets/img/images (1).png\"/><p>Bàn số {order.TableID}</p></a></li>";
                html += itemTemp;
            }

            return html;
        }
    }
}