using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using QLBH_TTCN_DoUong;
using TTCN_TLQuan.BLL;
using TTCN_TLQuan.Models;

namespace TTCN_TLQuan.UI.administrator.home.pay.bank_transfer
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["OrderID"] != null)
                {
                    string OrderID = Request.QueryString["OrderID"].ToString();
                    LoadDataBankTransfer(OrderID);
                }
            }
        }

        private void LoadDataBankTransfer(string OrderID)
        {
            Order order = new Order();
            OrderBLL orderBLL = new OrderBLL();

            order = orderBLL.GetByID(OrderID);

            bank.Value = ConfigurationManager.ConnectionStrings["id_bank"].ConnectionString;
            nameAccount.Value = ConfigurationManager.ConnectionStrings["name_bank"].ConnectionString;
            account_number.Value = ConfigurationManager.ConnectionStrings["stk_bank"].ConnectionString;
            bank_content.Value = Common.MD5_Hash(DateTime.Now.ToString("yyyyMMddHHmmssffff"));
            amount.Value = order.TotalMoney.ToString();

            string url_qr_bank = $"https://img.vietqr.io/image/{bank.Value}-{account_number.Value}-compact.png?amount={amount.Value}&addInfo={bank_content.Value}&accountName={nameAccount.Value}";
            img_qr_bank.Src = url_qr_bank;
        }

        [WebMethod]
        public static bool CheckPaymentBank(string OrderID,string content_payment, string price)
        {
            bool status_payment = false;

            string url_check_payment = $"https://script.google.com/macros/s/AKfycby7-FooKyZ9DEPjMj9DbbcpXX8V2KOyWgh9lVd6tGgfmnnulB-aFf_mZRW-NI-Ks1C9rw/exec?description={content_payment}&value={price}";
            using (WebClient webClient = new WebClient())
            {
                string status = webClient.DownloadString(url_check_payment);
                if (status.Trim().Equals("true", StringComparison.OrdinalIgnoreCase)) status_payment = true;
            }

            if (!status_payment) return false;

            return UpdateStatusPay(OrderID, "1");

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