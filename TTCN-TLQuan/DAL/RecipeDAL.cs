using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TTCN_TLQuan.Models;

namespace TTCN_TLQuan.DAL
{
    public class RecipeDAL
    {
        private DatabaseConnection _dB;

        public RecipeDAL()
        {
            _dB = new DatabaseConnection();
        }

        public int Add(Recipe recipe)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>()
            {
                {"@ProductID", recipe.ProductID},
                {"@RecipeID", recipe.RecipeID}
            };
            return _dB.ExecuteNonQuery("Recipe_Insert", parameter);
        }

        public int Update(Recipe recipe)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>()
            {
                {"@RecipeID", recipe.RecipeID},
                {"@ProductID", recipe.ProductID }
            };
            return _dB.ExecuteNonQuery("Recipe_Update", parameter);
        }

        public int DeleteByProductID(int ProductID)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>()
            {
                {"@ProductID",ProductID }
            };
            return _dB.ExecuteNonQuery("Recipe_Delete_By_ProductID", parameter);
        }

        public List<Recipe> GetAll()
        {
            List<Recipe> listRecipe = new List<Recipe>();
            using (SqlDataReader reader = _dB.ExecuteReader("Recipe_Select", null))
            {
                while (reader.Read())
                {
                    Recipe recipe = new Recipe();

                    recipe.RecipeID = Convert.ToString(reader["RecipeID"]);
                    recipe.ProductID = Convert.ToInt32(reader["ProductID"]);
                    recipe.ProductName = Convert.ToString(reader["Name"]);

                    listRecipe.Add(recipe);
                }
            }
            return listRecipe;
        }

        public Recipe GetByProductID(int ProductID)
        {
            Recipe recipe = new Recipe();

            Dictionary<string, object> prameter = new Dictionary<string, object>()
            {
                {"@ProductID",ProductID }
            };

            using (SqlDataReader dataReader = _dB.ExecuteReader("Recipe_Select_By_ProductID", prameter))
            {
                if (dataReader.Read())
                {
                    recipe.RecipeID = Convert.ToString(dataReader["RecipeID"].ToString());
                    recipe.ProductID = int.Parse(dataReader["ProductID"].ToString());
                    recipe.ProductName = dataReader["Name"].ToString();
                }
            }
            return recipe;
        }
    }
}