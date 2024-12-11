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
            List<Ingredient> listIngredient = new List<Ingredient>();
            using (SqlDataReader reader = _ingredientDAL.GetAll())
            {
                while (reader.Read())
                {
                    Ingredient ingredient = new Ingredient();

                    ingredient.IngredientID = Convert.ToInt32(reader["IngredientID"]);
                    ingredient.Name = Convert.ToString(reader["Name"]);
                    ingredient.Price = Convert.ToSingle(reader["Price"]);
                    ingredient.Quantity = Convert.ToInt32(reader["Quantity"]);
                    ingredient.UnitID = Convert.ToInt32(reader["UnitID"]);
                    ingredient.UnitName = Convert.ToString(reader["UnitName"]);

                    listIngredient.Add(ingredient);
                }
            }
            return listIngredient;
        }
    }
}