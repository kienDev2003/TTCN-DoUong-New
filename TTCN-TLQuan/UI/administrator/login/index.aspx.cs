using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QLBH_TTCN_DoUong;
using TTCN_TLQuan.BLL;
using TTCN_TLQuan.Models;

namespace TTCN_TLQuan.UI.administrator.login
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Session["login"] = null;
        }

        protected void btnLogin_ServerClick(object sender, EventArgs e)
        {
            string userName = txtUserName.Value.Trim();
            string password = txtPassword.Value.Trim();

            UserBLL userBLL = new UserBLL();
            User user = new User();

            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                string script = "Swal.fire({title: 'Thông báo!', text: 'Vui lòng nhập đầy đủ các trường', icon: 'error', confirmButtonText: 'OK'});";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
            }
            else
            {
                user = userBLL.Login(userName, password);

                if (string.IsNullOrEmpty(user.FullName))
                {
                    string script = "Swal.fire({title: 'Thông báo!', text: 'Sai thông tin đăng nhập', icon: 'error', confirmButtonText: 'OK'});";
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
                }
                else
                {
                    Session["login"] = user;
                    Response.Redirect("../home/user/");
                }
            }

        }
    }
}