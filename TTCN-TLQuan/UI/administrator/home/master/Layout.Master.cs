using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TTCN_TLQuan.Models;

namespace TTCN_TLQuan.UI.administrator.home.master
{
    public partial class Layout : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] == null)
            {
                Response.Redirect("../../login");
            }
            else
            {
                User user = new User();
                user = Session["login"] as User;
                nameUser.InnerText = user.FullName;

                if(user.RoleID == 1)
                {
                    liUser.Visible = false;
                    liReport.Visible = false;
                }
            }
        }
    }
}