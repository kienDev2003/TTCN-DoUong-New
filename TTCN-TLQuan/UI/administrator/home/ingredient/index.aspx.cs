using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using TTCN_TLQuan.BLL;
using TTCN_TLQuan.Models;

namespace TTCN_TLQuan.UI.administrator.home.ingredient
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static List<Ingredient> GetIngredient()
        {
            IngredientBLL ingredientBLL = new IngredientBLL();

            return ingredientBLL.GetAll();
        }

        [WebMethod]
        public static bool DeleteIngredient(int IngredientID)
        {
            IngredientBLL ingredientBLL = new IngredientBLL();

            return ingredientBLL.Delete(IngredientID);
        }

        [WebMethod]
        public static List<Ingredient> SearchIngredientByName(string Name)
        {
            IngredientBLL ingredientBLL = new IngredientBLL();

            return ingredientBLL.GetByName(Name);
        }
    }
}