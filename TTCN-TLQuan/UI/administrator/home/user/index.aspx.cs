using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using TTCN_TLQuan.BLL;
using TTCN_TLQuan.Models;

namespace TTCN_TLQuan.UI.administrator.home.user
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static List<User> GetAll()
        {
            List<User> users = new List<User>();
            UserBLL userController = new UserBLL();

            users = userController.GetAll();

            return users;
        }

        [WebMethod]
        public static bool DeleteUser(int UserID)
        {
            UserBLL userBLL = new UserBLL();

            return userBLL.Delete(UserID);
        }

        [WebMethod]
        public static List<User> SearchUserByName(string FullName)
        {
            List<User> users = new List<User>();
            UserBLL userBLL = new UserBLL();

            users = userBLL.GetByFullName(FullName);

            return users;
        }
    }
}