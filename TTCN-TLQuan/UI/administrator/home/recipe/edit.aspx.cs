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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ProductID"] == null) Response.Redirect("../../login");
            LoadIngredient();
        }

        private void LoadIngredient()
        {
            string html = "";

            IngredientBLL ingredientBLL = new IngredientBLL();
            List<Ingredient> ingredients = new List<Ingredient>();

            ingredients = ingredientBLL.GetAll();

            foreach (Ingredient ingredient in ingredients)
            {
                string temp = $"<div class=\"product\" style=\"display: flex; flex-direction: row;\">" +
                                $"<div>" +
                                    $"<h2>{ingredient.Name}</h2>" +
                                    $"<p>{ingredient.Quantity}</p>" +
                                $"</div>" +
                                $"<button onclick=\"AddIngredient({ingredient.IngredientID},'{ingredient.Name}','{ingredient.UnitName}')\">+</button>" +
                              $"</div>";

                html += temp;
            }

            LiteralControl literalControl = new LiteralControl(html);
            listingredient.Controls.Clear();
            listingredient.Controls.Add(literalControl);
        }

        [WebMethod]
        public static bool Add(int ProductID, List<RecipeDetail> recipeDetails)
        {
            Recipe recipe = new Recipe();

            recipe.RecipeID = DateTime.Now.ToString("yyyyMMddHHmmssffff");
            recipe.ProductID = ProductID;
            
            foreach(RecipeDetail recipeDetail in recipeDetails)
            {
                recipeDetail.RecipeID = recipe.RecipeID;
            }

            return AddRecipe(recipe,recipeDetails);
        }

        private static bool AddRecipe(Recipe recipe, List<RecipeDetail> recipeDetails)
        {
            RecipeBLL recipeBLL = new RecipeBLL();
            RecipeDetailBLL recipeDetailBLL = new RecipeDetailBLL();

            if (recipeBLL.Add(recipe))
            {
                foreach (RecipeDetail recipeDetail in recipeDetails)
                {
                    recipeDetailBLL.Add(recipeDetail);
                }
            }
            else return false;

            return true;
        }
    }
}