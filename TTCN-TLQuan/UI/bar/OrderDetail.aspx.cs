using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TTCN_TLQuan.BLL;
using TTCN_TLQuan.Models;

namespace TTCN_TLQuan.UI.bar
{
    public partial class OrderDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string tableID = Request.QueryString["tableID"].ToString();
                string orderID = Request.QueryString["orderID"].ToString();

                nameTable.InnerText = $"Chi tiết đơn bàn {tableID}";
                GetProductInOrderDetails(orderID);
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert(\"truy cap khong hop le\")</script>");
            }

        }

        public void GetProductInOrderDetails(string OrderID)
        {
            content_table.Controls.Clear();
            string contentHtml = "";

            OrderDetailBLL orderDetailBLL = new OrderDetailBLL();
            List<Models.OrderDetail> orderDetails = new List<Models.OrderDetail>();
            
            orderDetails = orderDetailBLL.GetAllByOrderIDNotServe(OrderID);

            foreach (Models.OrderDetail orderDetail in orderDetails)
            {
                ProductBLL productBLL = new ProductBLL();
                Product product = productBLL.GetByID(orderDetail.ProductID);

                string trTemp = $"<tr><th>{product.Name}</th><th>{orderDetail.Quantity}</th></tr>";
                contentHtml += trTemp;
            }

            LiteralControl literalControl = new LiteralControl(contentHtml);
            content_table.Controls.Add(literalControl);
        }

        protected void btnSuccess_ServerClick(object sender, EventArgs e)
        {
            OrderBLL orderBLL = new OrderBLL();
            OrderDetailBLL orderDetailBLL = new OrderDetailBLL();

            Order order = new Order();
            List<Models.OrderDetail> orderDetails = new List<Models.OrderDetail>();

            order = orderBLL.GetByID(Request.QueryString["orderID"].ToString());
            order.StatusServe = true;

            orderDetails = orderDetailBLL.GetAllByOrderIDNotServe(order.OrderID);
            foreach(Models.OrderDetail orderDetail in orderDetails)
            {
                orderDetail.StatusServe = true;
            }

            if(orderBLL.Update(order) && orderDetailBLL.UpdateList(orderDetails)) Response.Redirect("./");
        }
    }
}