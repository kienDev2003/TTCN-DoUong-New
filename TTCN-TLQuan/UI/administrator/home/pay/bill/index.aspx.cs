using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TTCN_TLQuan.BLL;
using TTCN_TLQuan.Models;

namespace TTCN_TLQuan.UI.administrator.home.pay.bill
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["OrderID"] != null)
            {
                LoadBill(Request.QueryString["OrderID"]);
            }
        }

        private void LoadBill(string OrderID)
        {
            Order order = new Order();
            List<OrderDetail> orderDetails = new List<OrderDetail>();

            OrderBLL orderBLL = new OrderBLL();
            OrderDetailBLL orderDetailBLL = new OrderDetailBLL();

            order = orderBLL.GetByID(OrderID);
            orderDetails = orderDetailBLL.GetAllByOrderID(OrderID);

            string html = "";
            int index = 0;
            foreach (OrderDetail orderDetail in orderDetails)
            {
                Product product = new Product();
                ProductBLL productBLL = new ProductBLL();

                product = productBLL.GetByID(orderDetail.ProductID);

                string htmlItem = $"<tr>" +
                                    $"<td>{++index}.{product.Name}</td>" +
                                    $"<td>{orderDetail.Quantity}</td>" +
                                    $"<td>{product.Price}</td>" +
                                    $"<td>{product.Price * orderDetail.Quantity}</td>" +
                                  $"</tr>";

                html += htmlItem;
            }

            LiteralControl literalControl = new LiteralControl(html);
            tbody_content.Controls.Add(literalControl);
            txtOrderDate.InnerText = order.Date;
            txtOrderID.InnerText = $"Số Phiếu :{order.OrderID}";
            txtTotalMoney.InnerText = order.TotalMoney.ToString();

            string script = @"
                                var content = document.getElementById('form1').innerHTML;
                                var originalContent = document.body.innerHTML;
                                document.body.innerHTML = content;
                                window.print();
                                document.body.innerHTML = originalContent;
                              ";

            ClientScript.RegisterStartupScript(this.GetType(), "printPage", script, true);
        }
    }
}