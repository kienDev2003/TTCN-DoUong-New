using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TTCN_TLQuan.DAL;
using TTCN_TLQuan.Models;

namespace TTCN_TLQuan.BLL
{
    public class RecipeDetailBLL
    {
        private RecipeDetailDAL _recipeDetailBLL;

        public RecipeDetailBLL()
        {
            _recipeDetailBLL = new RecipeDetailDAL();
        }

        public bool Add(RecipeDetail recipeDetail)
        {
            if (_recipeDetailBLL.Add(recipeDetail) > 0) return true;
            return false;
        }

        public bool Update(RecipeDetail recipeDetail)
        {
            if (_recipeDetailBLL.Update(recipeDetail) > 0) return true;
            return false;
        }

        public bool Delete(int RecipeDetailID)
        {
            if (_recipeDetailBLL.Delete(RecipeDetailID) > 0) return true;
            return false;
        }

        public List<RecipeDetail> GetAll()
        {
            return _recipeDetailBLL.GetAll();
        }

        public List<RecipeDetail> GetAllByRecipeID(string RecipeID)
        {
            return _recipeDetailBLL.GetAllByRecipeID(RecipeID);
        }
    }
}