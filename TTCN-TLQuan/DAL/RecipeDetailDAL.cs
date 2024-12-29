using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TTCN_TLQuan.BLL;
using TTCN_TLQuan.Models;

namespace TTCN_TLQuan.DAL
{
    public class RecipeDetailDAL
    {
        private DatabaseConnection _dB;

        public RecipeDetailDAL()
        {
            _dB = new DatabaseConnection();
        }

        public int Add(RecipeDetail recipeDetail)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>()
            {
                {"@IngredientID", recipeDetail.IngredientID },
                {"@QuantityNeed", recipeDetail.QuantityNeed},
                {"@ProductID", recipeDetail.ProductID }
            };
            return _dB.ExecuteNonQuery("RecipeDetail_Insert", parameter);
        }

        public int Update(RecipeDetail recipeDetail)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>()
            {
                {"@RecipeDetailID" , recipeDetail.RecipeDetailID},
                {"@IngredientID", recipeDetail.IngredientID },
                {"@QuantityNeed", recipeDetail.QuantityNeed},
                {"@ProductID", recipeDetail.ProductID }
            };
            return _dB.ExecuteNonQuery("RecipeDetail_Update", parameter);
        }

        public int Delete(int RecipeDetailID)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>()
            {
                {"@ProductID",RecipeDetailID }
            };
            return _dB.ExecuteNonQuery("RecipeDetail_Delete", parameter);
        }

        public List<RecipeDetail> GetAll()
        {
            List<RecipeDetail> listRecipeDetail = new List<RecipeDetail>();
            using (SqlDataReader reader = _dB.ExecuteReader("RecipeDetail_Select", null))
            {
                while (reader.Read())
                {
                    RecipeDetail recipeDetail = new RecipeDetail();

                    recipeDetail.RecipeDetailID = Convert.ToInt32(reader["RecipeDetailID"]);
                    recipeDetail.IngredientID = Convert.ToInt32(reader["IngredientID"]);
                    recipeDetail.Name = Convert.ToString(reader["IngredientName"]);
                    recipeDetail.QuantityNeed = Convert.ToInt32(reader["QuantityNeed"]);
                    recipeDetail.ProductID = Convert.ToInt32(reader["ProductID"]);

                    listRecipeDetail.Add(recipeDetail);
                }
            }
            return listRecipeDetail;
        }

        public List<RecipeDetail> GetAllByRecipeID(int ProductID)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>()
            {
                {"@ProductID",ProductID }
            };
            List<RecipeDetail> listRecipeDetail = new List<RecipeDetail>();
            using (SqlDataReader reader = _dB.ExecuteReader("RecipeDetail_Select_By_ProductID",parameter))
            {
                while (reader.Read())
                {
                    RecipeDetail recipeDetail = new RecipeDetail();

                    recipeDetail.RecipeDetailID = Convert.ToInt32(reader["RecipeDetailID"]);
                    recipeDetail.IngredientID = Convert.ToInt32(reader["IngredientID"]);
                    recipeDetail.Name = Convert.ToString(reader["Name"]);
                    recipeDetail.QuantityNeed = Convert.ToInt32(reader["QuantityNeed"]);
                    recipeDetail.UnitName = Convert.ToString(reader["UnitName"]);
                    recipeDetail.ProductID = Convert.ToInt32(reader["ProductID"]);

                    listRecipeDetail.Add(recipeDetail);
                }
            }
            return listRecipeDetail;
        }
    }
}