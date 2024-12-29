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
    public partial class edit : System.Web.UI.Page
    {
        private static int ProductID;
        protected void Page_Load(object sender, EventArgs e)
        {
            ProductID = Convert.ToInt32(Request.QueryString["ProductID"]);
            ProductBLL productBLL = new ProductBLL();
            User_FullName.InnerText = productBLL.GetByID(ProductID).Name;
        }
        [WebMethod]
        public static List<Ingredient> GetIngredients()
        {
            IngredientBLL ingredientBLL = new IngredientBLL();
            return ingredientBLL.GetAll();
        }

        [WebMethod]
        public static List<RecipeDetail> GetRecipeDetails(int ProductID)
        {
            RecipeDetailBLL recipeDetailBLL = new RecipeDetailBLL();

            return recipeDetailBLL.GetAllByRecipeID(ProductID);
        }

        [WebMethod]
        public static bool Add(List<RecipeDetail> recipeDetails)
        {
            RecipeDetailBLL recipeDetailBLL = new RecipeDetailBLL();

            if (!recipeDetailBLL.Delete(ProductID)) return false;
            
            foreach (RecipeDetail item in recipeDetails)
            {
                if (recipeDetailBLL.Add(item)) continue;
                else return false;
            }
            return true;
        }
    }
}