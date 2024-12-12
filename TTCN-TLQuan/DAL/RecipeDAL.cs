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

        public int Add(int ProductID)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>()
            {
                {"@ProductID", ProductID}
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

        public int Delete(int RecipeID)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>()
            {
                {"@RecipeID",RecipeID }
            };
            return _dB.ExecuteNonQuery("Recipe_Delete", parameter);
        }

        public List<Recipe> GetAll()
        {
            List<Recipe> listRecipe = new List<Recipe>();
            using (SqlDataReader reader = _dB.ExecuteReader("Recipe_Select", null))
            {
                while (reader.Read())
                {
                    Recipe recipe = new Recipe();

                    recipe.RecipeID = Convert.ToInt32(reader["RecipeID"]);
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
                    recipe.RecipeID = int.Parse(dataReader["Recipe_ID"].ToString());
                    recipe.ProductID = int.Parse(dataReader["Product_ID"].ToString());
                    recipe.ProductName = dataReader["ProductName"].ToString();
                }
            }
            return recipe;
        }
    }
}