using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TTCN_TLQuan.DAL;
using TTCN_TLQuan.Models;

namespace TTCN_TLQuan.BLL
{
    public class IngredientBLL
    {
        private IngredientDAL _ingredientDAL;

        public IngredientBLL()
        {
            _ingredientDAL = new IngredientDAL();
        }

        public bool Add(Ingredient ingredient)
        {
            if (_ingredientDAL.Add(ingredient) > 0) return true;
            return false;
        }

        public bool Update(Ingredient ingredient)
        {
            if (_ingredientDAL.Update(ingredient) > 0) return true;
            return false;
        }

        public bool Delete(int IngredientID)
        {
            if (_ingredientDAL.Delete(IngredientID) > 0) return true;
            return false;
        }

        public List<Ingredient> GetAll()
        {
            return _ingredientDAL.GetAll();
        }

        public List<Ingredient> GetByName(string Name)
        {
            return _ingredientDAL.GetByName(Name);
        }

        public Ingredient GetByID(int IngredientID)
        {
            return _ingredientDAL.GetByID(IngredientID);
        }
    }
}