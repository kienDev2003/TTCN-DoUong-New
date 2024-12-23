using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TTCN_TLQuan.DAL;
using TTCN_TLQuan.Models;

namespace TTCN_TLQuan.BLL
{
    public class RecipeBLL
    {
        private RecipeDAL _recipeDAL;

        public RecipeBLL()
        {
            _recipeDAL = new RecipeDAL();
        }

        public bool Add(Recipe recipe)
        {
            if (_recipeDAL.Add(recipe) > 0) return true;
            return false;
        }

        public bool Update(Recipe recipe)
        {
            if (_recipeDAL.Update(recipe) > 0) return true;
            return false;
        }

        public bool DeleteByProductID(int ProductID)
        {
            if (_recipeDAL.DeleteByProductID(ProductID) > 0) return true;
            return false;
        }

        public List<Recipe> GetAll()
        {
            return _recipeDAL.GetAll();
        }

        public Recipe getByProductId(int ProductID)
        {
            return _recipeDAL.GetByProductID(ProductID);
        }
    }
}