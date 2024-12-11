using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Xml.Linq;
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

        public List<Ingredient> GetAll()
        {
            List<Ingredient> listIngredient = new List<Ingredient>();
            using (SqlDataReader reader = _dB.ExecuteReader("Ingredient_Select", null))
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

        public List<Ingredient> GetByName(string Name)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>()
            {
                {"@Name",Name }
            };

            List<Ingredient> listIngredient = new List<Ingredient>();
            using (SqlDataReader reader = _dB.ExecuteReader("Ingredient_Select_By_Name", parameter))
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

        public Ingredient GetByID(int IngredientID)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>()
            {
                {"@IngredientID",IngredientID }
            };
            Ingredient ingredient = new Ingredient();
            using (SqlDataReader reader = _dB.ExecuteReader("Ingredient_Select_By_ID", parameter))
            {
                while (reader.Read())
                {
                    ingredient.IngredientID = Convert.ToInt32(reader["IngredientID"]);
                    ingredient.Name = Convert.ToString(reader["Name"]);
                    ingredient.Price = Convert.ToSingle(reader["Price"]);
                    ingredient.Quantity = Convert.ToInt32(reader["Quantity"]);
                    ingredient.UnitID = Convert.ToInt32(reader["UnitID"]);
                    ingredient.UnitName = Convert.ToString(reader["UnitName"]);
                }
            }
            return ingredient;
        }
    }
}