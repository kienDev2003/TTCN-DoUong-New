using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using TTCN_TLQuan.DAL;
using TTCN_TLQuan.Models;

namespace TTCN_TLQuan.BLL
{
    public class ProductBLL
    {
        private ProductDAL _productDAL;

        public ProductBLL()
        {
            _productDAL = new ProductDAL();
        }

        public bool Add(Product product)
        {
            if (_productDAL.Add(product) > 0) return true;
            return false;
        }

        public bool Update(Product product)
        {
            if (_productDAL.Update(product) > 0) return true;
            return false;
        }

        public bool Delete(int ProductID)
        {
            if (_productDAL.Delete(ProductID) > 0) return true;
            return false;
        }

        public List<Product> GetAll()
        {
            return _productDAL.GetAll();
        }

        public List<Product> GetByName(string Name)
        {
            return _productDAL.GetByName(Name);
        }

        public Product GetByID(int ProductID)
        {
            return _productDAL.GetByID(ProductID);
        }

        public List<Product> GetAllByCategoryID(int CategoryID)
        {
            return _productDAL.GetAllByCategoryID(CategoryID);
        }

        public bool RawMaterial(int ProductID, int Quantity)
        {
            IngredientBLL ingredientBLL = new IngredientBLL();
            RecipeBLL recipeBLL = new RecipeBLL();

            Recipe recipe = recipeBLL.getByProductId(ProductID);

            if (recipe.RecipeID <= 0) return false;

            List<RecipeDetail> listRecipeDetail = new List<RecipeDetail>();
            RecipeDetailBLL recipeDetailBLL = new RecipeDetailBLL();

            listRecipeDetail = recipeDetailBLL.GetAllByRecipeID(recipe.RecipeID);

            foreach(RecipeDetail recipeDetail in listRecipeDetail)
            {
                Ingredient ingredient = ingredientBLL.GetByID(recipeDetail.IngredientID);

                if (ingredient.Quantity - recipeDetail.QuantityNeed * Quantity < 0) return false;
            }
            
            return true;
        }
    }
}