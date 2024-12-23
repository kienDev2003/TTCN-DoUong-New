using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using TTCN_TLQuan.BLL;
using TTCN_TLQuan.Models;

namespace TTCN_TLQuan.UI.administrator.home.recipe
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static List<Product> GetAllNotStatusExistRecipe()
        {
            ProductBLL productBLL = new ProductBLL();

            return productBLL.GetAllByNotExistRecipe();
        }

        [WebMethod]
        public static bool DeleteRecipeByProductID(int ProductID)
        {
            RecipeBLL recipeBLL = new RecipeBLL();

            return recipeBLL.DeleteByProductID(ProductID);
        }
    }
}