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
    public partial class edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadRole();
            }
        }

        private void LoadRole()
        {
            List<Role> roles = new List<Role>();
            RoleBLL roleBLL = new RoleBLL();

            roles = roleBLL.GetAll();

            foreach (var role in roles)
            {
                cboRole.Items.Add(new ListItem { Value = Convert.ToString(role.RoleID), Text = role.RoleName });
            }
        }

        [WebMethod]
        public static bool Add(User user)
        {
            UserBLL UserBLL = new UserBLL();

            return UserBLL.Add(user);
        }

        [WebMethod]
        public static bool Update(User user)
        {
            UserBLL UserBLL = new UserBLL();

            return UserBLL.Update(user);
        }

        [WebMethod]
        public static User GetByID(int userID)
        {
            UserBLL UserBLL = new UserBLL();

            return UserBLL.GetByID(userID);
        }
    }
}