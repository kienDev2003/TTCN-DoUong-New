using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
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
            if (Session["login"] == null) Response.Redirect("../../login");
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
                                    $"<h2>{ingredient.Name}</h2>"+
                                $"</div>" +
                                $"<input type=\"button\" onclick=\"AddIngredient({ingredient.IngredientID},{ingredient.Price},'{ingredient.Name}',{ingredient.UnitID},'{ingredient.UnitName}')\" value=\"+\">" +
                              $"</div>";

                html += temp;
            }

            LiteralControl literalControl = new LiteralControl(html);
            listingredient.Controls.Clear();
            listingredient.Controls.Add(literalControl);
        }

        [WebMethod]
        public static bool Add(List<ImportDetail> ImportDetails, float TotalMoney)
        {
            User userLogin = HttpContext.Current.Session["login"] as User;
            Import import = new Import();

            import.ImportID = DateTime.Now.ToString("yyyyMMddHHmmssffff");
            import.Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff");
            import.TotalMoney = TotalMoney;
            import.UserID = userLogin.UserID;

            foreach (ImportDetail importDetail in ImportDetails)
            {
                importDetail.ImportID = import.ImportID;
            }

            return AddImport(import, ImportDetails);
        }

        private static bool AddImport(Import import, List<ImportDetail> importDetails)
        {
            ImportBLL importBLL = new ImportBLL();
            ImportDetailBLL importDetailBLL = new ImportDetailBLL();

            if (importBLL.Add(import))
            {
                foreach (ImportDetail importDetail in importDetails)
                {
                    importDetailBLL.Add(importDetail);
                }
            }
            else return false;

            return true;
        }
    }
}