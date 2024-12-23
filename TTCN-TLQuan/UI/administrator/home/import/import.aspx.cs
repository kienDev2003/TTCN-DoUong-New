using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TTCN_TLQuan.BLL;
using TTCN_TLQuan.Models;

namespace TTCN_TLQuan.UI.administrator.home.import
{
    public partial class import : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadIngredient();
        }

        private void LoadIngredient()
        {
            string html = "";
            List<Ingredient> listIngredient = new List<Ingredient>();

            IngredientBLL ingredientBLL = new IngredientBLL();
            listIngredient = ingredientBLL.GetAll();

            foreach(Ingredient ingredient in listIngredient)
            {
                string temp = $"<div class=\"product\" style=\"display: flex; flex-direction: row; width: fit-content;\">" +
                                    $"<div>" +
                                        $"<h2>{ingredient.Name}</h2>" +
                                        $"<p>Giá: {ingredient.Price}</p>" +
                                    $"</div>" +
                                    $"<input type=\"button\" class=\"add-to-cart\" data-dvi=\"{ingredient.UnitID}\" data-dviName=\"{ingredient.UnitName}\" data-id=\"{ingredient.IngredientID}\" data-price=\"{ingredient.Price}\" value=\"+\">" +
                              $"</div>";
                html += temp;
            }

            LiteralControl literalControl = new LiteralControl(html);
            ingredient_content.Controls.Clear();
            ingredient_content.Controls.Add(literalControl);
        }
    }
}