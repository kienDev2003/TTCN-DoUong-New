using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TTCN_TLQuan.BLL;
using TTCN_TLQuan.Models;
using TTCN_TLQuan.UI.bar;

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
            List<Models.OrderDetail> orderDetails = new List<Models.OrderDetail>();

            OrderBLL orderBLL = new OrderBLL();
            OrderDetailBLL orderDetailBLL = new OrderDetailBLL();

            Product product = new Product();
            ProductBLL productBLL = new ProductBLL();

            order = orderBLL.GetByID(OrderID);
            orderDetails = orderDetailBLL.GetAllByOrderID(OrderID);

            string html = "";
            int index = 0;
            for (int i = 0; i < orderDetails.Count; i++)
            {
                product = productBLL.GetByID(orderDetails[i].ProductID);

                string htmlItem = $"<tr>" +
                                    $"<td>{++index}.{product.Name}</td>" +
                                    $"<td>{orderDetails[i].Quantity}</td>" +
                                    $"<td>{product.Price}</td>" +
                                    $"<td>{product.Price * orderDetails[i].Quantity}</td>" +
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