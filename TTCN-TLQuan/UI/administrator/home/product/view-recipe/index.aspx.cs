using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using TTCN_TLQuan.BLL;
using TTCN_TLQuan.Models;

namespace TTCN_TLQuan.UI.administrator.home.product.view_recipe
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ProductBLL productBLL = new ProductBLL();
            User_FullName.InnerText = Convert.ToString(productBLL.GetByID(Convert.ToInt32(Request.QueryString["ProductID"])).Name);
        }

        [WebMethod]
        public static List<RecipeDetail> GetRecipeByProductID(int ProductID)
        {
            RecipeDetailBLL recipeDetailBLL = new RecipeDetailBLL();

            return recipeDetailBLL.GetAllByRecipeID(ProductID);
        }
    }
}