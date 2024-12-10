using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TTCN_TLQuan.Models;

namespace TTCN_TLQuan.DAL
{
    public class IngredientDAL
    {
        private DatabaseConnection _dB;

        public IngredientDAL()
        {
            _dB = new DatabaseConnection();
        }

        public int Add(Ingredient ingredient)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>()
            {
                {"@Name", ingredient.Name},
                {"@Price", ingredient.Price },
                {"@Quantity", ingredient.Quantity },
                {"@UnitID", ingredient.UnitID }
            };
            return _dB.ExecuteNonQuery("Ingredient_Insert", parameter);
        }

        public int Update(Ingredient ingredient)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>()
            {
                {"@IngredientID", ingredient.IngredientID },
                {"@Name", ingredient.Name},
                {"@Price", ingredient.Price },
                {"@Quantity", ingredient.Quantity },
                {"@UnitID", ingredient.UnitID }
            };
            return _dB.ExecuteNonQuery("Ingredient_Update", parameter);
        }

        public int Delete(int IngredientID)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>()
            {
                {"@IngredientID",IngredientID }
            };
            return _dB.ExecuteNonQuery("Ingredient_Delete", parameter);
        }

        public SqlDataReader GetAll()
        {
            return _dB.ExecuteReader("Ingredient_Select", null);
        }
    }
}