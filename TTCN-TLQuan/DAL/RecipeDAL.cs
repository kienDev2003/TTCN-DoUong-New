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

        public SqlDataReader GetAll()
        {
            return _dB.ExecuteReader("Recipe_Select", null);
        }
    }
}