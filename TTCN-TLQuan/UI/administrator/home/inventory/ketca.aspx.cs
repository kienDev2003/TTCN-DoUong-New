using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using TTCN_TLQuan.BLL;
using TTCN_TLQuan.Models;

namespace TTCN_TLQuan.UI.administrator.home.inventory
{
    public partial class ketca : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static List<Ingredient> GetIngredients()
        {
            IngredientBLL ingredientBLL = new IngredientBLL();
            List<Ingredient> listIngredient = ingredientBLL.GetAll();
            return listIngredient;
        }

        [WebMethod]
        public static bool Add(List<InventoryDetail> InventoryDetails)
        {
            Inventory inventory = new Inventory();
            IngredientBLL ingredientBLL = new IngredientBLL();
            

            inventory.InventoryID = DateTime.Now.ToString("yyyyMMddHHmmssffff");
            inventory.Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ff");
            inventory.UserID = (HttpContext.Current.Session["login"] as User).UserID;

            foreach(InventoryDetail detail in InventoryDetails)
            {
                detail.InventoryID = inventory.InventoryID;
                detail.NumberOfSystem = ingredientBLL.GetByID(detail.IngredientID).Quantity;
            }

            if (AddInventory(inventory, InventoryDetails)) return true;
            return false;
        }

        private static bool AddInventory(Inventory inventory, List<InventoryDetail> inventoryDetails)
        {
            InventoryBLL inventoryBLL = new InventoryBLL();
            InventoryDetailBLL inventoryDetailBLL = new InventoryDetailBLL();

            if (inventoryBLL.Add(inventory))
            {
                foreach (InventoryDetail detail in inventoryDetails)
                {
                    inventoryDetailBLL.Add(detail);
                }
            }
            else return false;

            return true;
        }
    }
}